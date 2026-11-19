using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Security;
using System.Threading;
using System.Windows.Forms;

namespace PDFComp
{
    // Owns language discovery and resource loading without depending on application forms or settings.
    public sealed class Languages : IDisposable
    {
        public sealed class Language
        {
            public string Code { get; private set; }
            public string NativeName { get; private set; }

            public Language(string code, string nativeName)
            {
                Code = code;
                NativeName = nativeName;
            }

            public override string ToString() { return NativeName; }
        }

        private readonly Assembly resourceAssembly;
        private readonly AssemblyName satelliteIdentity;
        private readonly ResourceManager resources;
        private readonly CultureInfo defaultCulture;
        private readonly CultureInfo automaticCulture;
        private readonly int ownerThread;
        private readonly Dictionary<string, string> satellitePaths =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private readonly List<WeakReference<Binding>> bindings = new List<WeakReference<Binding>>();
        private bool disposed;

        public ReadOnlyCollection<Language> AvailableLanguages { get; private set; }
        public string SelectedLanguage { get; private set; }
        public CultureInfo ActiveCulture { get; private set; }
        public event EventHandler LanguageChanged;

        // Capture the automatic culture before the application applies its saved language.
        // The directory inventory is fixed for this instance; restart after installing or updating language DLLs.
        public Languages(Assembly assembly, string resourceBaseName, string defaultLanguage,
            string directory, CultureInfo systemUICulture = null)
        {
            resourceAssembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
            resources = new ResourceManager(resourceBaseName, assembly);
            defaultCulture = CultureInfo.GetCultureInfo(defaultLanguage);
            automaticCulture = systemUICulture ?? CultureInfo.CurrentUICulture;
            ownerThread = Thread.CurrentThread.ManagedThreadId;
            var identity = assembly.GetName();
            satelliteIdentity = new AssemblyName(identity.FullName);
            satelliteIdentity.Name += ".resources";
            var contract = assembly.GetCustomAttribute<SatelliteContractVersionAttribute>();
            if (contract != null)
            {
                satelliteIdentity.Version = new Version(contract.Version);
            }

            Discover(Path.GetFullPath(directory));
            var languages = new List<Language>
            {
                new Language("", "Automatic"),
                new Language(defaultCulture.Name, defaultCulture.NativeName)
            };
            foreach (string code in satellitePaths.Keys.OrderBy(value => value, StringComparer.OrdinalIgnoreCase))
            {
                if (!string.Equals(code, defaultCulture.Name, StringComparison.OrdinalIgnoreCase))
                {
                    languages.Add(new Language(code, CultureInfo.GetCultureInfo(code).NativeName));
                }
            }
            AvailableLanguages = languages.AsReadOnly();
            AppDomain.CurrentDomain.AssemblyResolve += ResolveSatellite;
            SetLanguage("");
        }

        private void Discover(string directory)
        {
            try
            {
                if (!Directory.Exists(directory))
                {
                    return;
                }
                foreach (string child in Directory.GetDirectories(directory))
                {
                    try
                    {
                        var culture = CultureInfo.GetCultureInfo(Path.GetFileName(child));
                        if (culture.Equals(CultureInfo.InvariantCulture))
                        {
                            continue;
                        }
                        string path = Path.Combine(child, satelliteIdentity.Name + ".dll");
                        if (!File.Exists(path))
                        {
                            continue;
                        }
                        var candidate = AssemblyName.GetAssemblyName(path);
                        if (Matches(candidate, culture))
                        {
                            satellitePaths[culture.Name] = path;
                        }
                    }
                    catch (Exception error) when (IsUnavailable(error)) { }
                }
            }
            catch (Exception error) when (IsUnavailable(error)) { }
        }

        private bool Matches(AssemblyName candidate, CultureInfo culture)
        {
            return string.Equals(candidate.Name, satelliteIdentity.Name, StringComparison.OrdinalIgnoreCase)
                && candidate.Version == satelliteIdentity.Version
                && string.Equals(candidate.CultureName, culture.Name, StringComparison.OrdinalIgnoreCase)
                && (candidate.GetPublicKeyToken() ?? new byte[0])
                    .SequenceEqual(satelliteIdentity.GetPublicKeyToken() ?? new byte[0]);
        }

        // Resolve only this owner's satellite requests. Returning null preserves the runtime fallback chain.
        private Assembly ResolveSatellite(object sender, ResolveEventArgs args)
        {
            try
            {
                var requested = new AssemblyName(args.Name);
                if (string.IsNullOrEmpty(requested.CultureName))
                {
                    return null;
                }
                var culture = CultureInfo.GetCultureInfo(requested.CultureName);
                if (!Matches(requested, culture))
                {
                    return null;
                }
                string path;
                if (!satellitePaths.TryGetValue(culture.Name, out path) || !File.Exists(path))
                {
                    return null;
                }
                if (!Matches(AssemblyName.GetAssemblyName(path), culture))
                {
                    return null;
                }
                return Assembly.LoadFrom(path);
            }
            catch (Exception error) when (IsUnavailable(error)) { return null; }
        }

        private static bool IsUnavailable(Exception error)
        {
            return error is IOException || error is UnauthorizedAccessException || error is SecurityException
                || error is BadImageFormatException || error is ArgumentException;
        }

        public void SetLanguage(string code)
        {
            if (disposed)
            {
                throw new ObjectDisposedException(nameof(Languages));
            }
            if (Thread.CurrentThread.ManagedThreadId != ownerThread)
            {
                throw new InvalidOperationException("Change the display language on its owning UI thread.");
            }
            code = code ?? "";
            if (!AvailableLanguages.Any(language => string.Equals(language.Code, code, StringComparison.OrdinalIgnoreCase)))
            {
                code = defaultCulture.Name;
            }
            SelectedLanguage = AvailableLanguages.First(language =>
                string.Equals(language.Code, code, StringComparison.OrdinalIgnoreCase)).Code;
            ActiveCulture = SelectedLanguage.Length == 0 ? ResolveAutomaticCulture() : CultureInfo.GetCultureInfo(SelectedLanguage);

            // Numeric formatting and comparisons keep the existing CurrentCulture.
            Thread.CurrentThread.CurrentUICulture = ActiveCulture;
            CultureInfo.DefaultThreadCurrentUICulture = ActiveCulture;
            foreach (var reference in bindings.ToArray())
            {
                Binding binding;
                if (reference.TryGetTarget(out binding) && !binding.IsDisposed)
                {
                    binding.Apply();
                }
                else
                {
                    bindings.Remove(reference);
                }
            }
            LanguageChanged?.Invoke(this, EventArgs.Empty);
        }

        private CultureInfo ResolveAutomaticCulture()
        {
            for (var culture = automaticCulture; !culture.Equals(CultureInfo.InvariantCulture); culture = culture.Parent)
            {
                if (culture.Name == defaultCulture.Name || satellitePaths.ContainsKey(culture.Name))
                {
                    return culture;
                }
            }
            return defaultCulture;
        }

        public string GetString(string key, string defaultText = null)
        {
            try
            {
                for (var culture = ActiveCulture; !culture.Equals(CultureInfo.InvariantCulture)
                    && culture.Name != defaultCulture.Name; culture = culture.Parent)
                {
                    if (satellitePaths.ContainsKey(culture.Name))
                    {
                        string text = resources.GetResourceSet(culture, true, false)?.GetString(key);
                        if (text != null)
                        {
                            return text;
                        }
                    }
                }
            }
            catch (Exception error) when (IsUnavailable(error) || error is MissingManifestResourceException
                || error is MissingSatelliteAssemblyException || error is InvalidOperationException)
            {
            }
            return defaultText;
        }

        // Apply only explicitly registered resource keys. Document text, user input, and numeric labels stay untouched.
        public IDisposable Bind(Control root, string prefix, Action afterApply = null,
            params ContextMenuStrip[] contextMenus)
        {
            if (disposed)
            {
                throw new ObjectDisposedException(nameof(Languages));
            }
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            if (Thread.CurrentThread.ManagedThreadId != ownerThread)
            {
                throw new InvalidOperationException("Register controls on the language service's owning UI thread.");
            }
            var binding = new Binding(this, root, prefix, afterApply, contextMenus);
            bindings.Add(new WeakReference<Binding>(binding));
            binding.Apply();
            return binding;
        }

        public void Dispose()
        {
            if (disposed)
            {
                return;
            }
            disposed = true;
            AppDomain.CurrentDomain.AssemblyResolve -= ResolveSatellite;
            foreach (var reference in bindings)
            {
                Binding binding;
                if (reference.TryGetTarget(out binding))
                {
                    binding.Dispose();
                }
            }
            bindings.Clear();
            resources.ReleaseAllResources();
        }

        private sealed class Binding : IDisposable
        {
            private readonly Languages languages;
            private readonly Control root;
            private readonly string prefix;
            private readonly Action afterApply;
            private readonly ContextMenuStrip[] contextMenus;
            private readonly Dictionary<string, string> defaultTexts = new Dictionary<string, string>();
            public bool IsDisposed { get; private set; }

            public Binding(Languages languages, Control root, string prefix, Action afterApply,
                ContextMenuStrip[] contextMenus)
            {
                this.languages = languages;
                this.root = root;
                this.prefix = prefix;
                this.afterApply = afterApply;
                this.contextMenus = contextMenus;
                root.Disposed += RootDisposed;
            }

            public void Apply()
            {
                if (IsDisposed || root.IsDisposed)
                {
                    return;
                }
                root.SuspendLayout();
                try
                {
                    ApplyControl(root, true);
                    foreach (var menu in contextMenus)
                    {
                        ApplyItems(menu.Items);
                    }
                    afterApply?.Invoke();
                }
                finally { root.ResumeLayout(true); }
            }

            private void ApplyControl(Control control, bool isRoot = false)
            {
                // Third-party controls own their resources; do not traverse their document or bookmark contents.
                var assembly = control.GetType().Assembly;
                if (!isRoot && assembly != languages.resourceAssembly && assembly != typeof(Control).Assembly)
                {
                    return;
                }
                string key = prefix + "." + (isRoot ? "$this" : control.Name);
                string text = GetText(key + ".Text", control.Text);
                if (text != null)
                {
                    control.Text = text;
                }
                var strip = control as ToolStrip;
                if (strip != null)
                {
                    ApplyItems(strip.Items);
                }
                var tree = control as TreeView;
                if (tree != null)
                {
                    ApplyNodes(tree.Nodes, key);
                }
                foreach (Control child in control.Controls)
                {
                    ApplyControl(child);
                }
            }

            private void ApplyItems(ToolStripItemCollection items)
            {
                foreach (ToolStripItem item in items)
                {
                    string key = prefix + "." + item.Name;
                    string text = GetText(key + ".Text", item.Text);
                    string tip = GetText(key + ".ToolTipText", item.ToolTipText);
                    if (text != null)
                    {
                        item.Text = text;
                    }
                    if (tip != null)
                    {
                        item.ToolTipText = tip;
                    }
                    var dropDown = item as ToolStripDropDownItem;
                    if (dropDown != null)
                    {
                        ApplyItems(dropDown.DropDownItems);
                    }
                }
            }

            private void ApplyNodes(TreeNodeCollection nodes, string key)
            {
                foreach (TreeNode node in nodes)
                {
                    string text = GetText(key + "." + node.Name + ".Text", node.Text);
                    if (text != null)
                    {
                        node.Text = text;
                    }
                    ApplyNodes(node.Nodes, key);
                }
            }

            // Save the form's English value before its first translation; missing translations restore it.
            private string GetText(string key, string defaultText)
            {
                string text = languages.GetString(key);
                string original;
                if (defaultTexts.TryGetValue(key, out original))
                {
                    return text ?? original;
                }
                if (text != null)
                {
                    defaultTexts.Add(key, defaultText);
                }
                return text;
            }

            private void RootDisposed(object sender, EventArgs args) { Dispose(); }

            public void Dispose()
            {
                if (IsDisposed)
                {
                    return;
                }
                IsDisposed = true;
                root.Disposed -= RootDisposed;
            }
        }
    }
}
