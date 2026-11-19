using System;
using System.IO;
using System.Windows.Forms;

namespace PDFComp
{
    // Keeps application-specific resource and settings choices outside the reusable language service.
    internal static class UiLanguages
    {
        internal static readonly Languages Current = new Languages(typeof(UiLanguages).Assembly,
            "PDFComp.Localization.UiStrings", "en", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Languages"));

        static UiLanguages()
        {
            Current.LanguageChanged += UpdatePasswordDialogTexts;
            UpdatePasswordDialogTexts(null, EventArgs.Empty);
        }

        private static void UpdatePasswordDialogTexts(object sender, EventArgs args)
        {
            PdfiumViewer.PdfDocument.PasswordDialogTitle = Current.GetString("PdfiumViewer.PasswordForm.$this.Text");
            PdfiumViewer.PdfDocument.PasswordDialogPrompt = Current.GetString("PdfiumViewer.PasswordForm._helpLabel.Text");
            PdfiumViewer.PdfDocument.PasswordDialogLabel = Current.GetString("PdfiumViewer.PasswordForm.label2.Text");
            PdfiumViewer.PdfDocument.PasswordDialogAcceptText = Current.GetString("PdfiumViewer.PasswordForm._acceptButton.Text");
            PdfiumViewer.PdfDocument.PasswordDialogCancelText = Current.GetString("PdfiumViewer.PasswordForm._cancelButton.Text");
        }

        internal static void Initialize()
        {
            Current.SetLanguage(Properties.Settings.Default.UiLanguage);
        }

        internal static string Text(string key, string defaultText) { return Current.GetString(key, defaultText); }

        internal static string Format(string key, string defaultText, params object[] values)
        {
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, Text(key, defaultText), values);
        }

        internal static void Bind(Control root, Action afterApply = null, params ContextMenuStrip[] menus)
        {
            Current.Bind(root, root.GetType().Name, afterApply, menus);
        }
    }
}
