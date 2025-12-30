namespace PDFComp
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFile1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFile2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyBookmarks1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyBookmarks2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemEnableReduceColorCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comparePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareBookmarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.previousDifferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextDifferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearMarker1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMarker2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllMakersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearBook1MarkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearBook2MarkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputDebugLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutPDFCompToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBoth = new System.Windows.Forms.Panel();
            this.pdfPanel2 = new PDFComp.PdfPanel();
            this.pdfPanel1 = new PDFComp.PdfPanel();
            this.timerButton = new System.Windows.Forms.Timer(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonBookmarks = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPrevPages = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNextPages = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPanel1Prev = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPanel1Next = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPanel2Prev = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPanel2Next = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButtonCompare = new System.Windows.Forms.ToolStripSplitButton();
            this.pageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabelResult = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonPrevDiff = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNextDiff = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxDiffType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonHandmode = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTextmode = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBoundsmode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRotateAnticlockwise = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRotateClockwise = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripTrackBarZoom = new ToolStripTrackBar();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelZoom = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonFitWidth = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFitOnePage = new System.Windows.Forms.ToolStripButton();
            this.timerCyclic = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.panelBoth.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.compareToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1192, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.copyFile1ToolStripMenuItem,
            this.copyFile2ToolStripMenuItem,
            this.copyBookmarks1ToolStripMenuItem,
            this.copyBookmarks2ToolStripMenuItem,
            this.toolStripSeparator1,
            this.findToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItemEnableReduceColorCopy});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // copyFile1ToolStripMenuItem
            // 
            this.copyFile1ToolStripMenuItem.Name = "copyFile1ToolStripMenuItem";
            this.copyFile1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.copyFile1ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.copyFile1ToolStripMenuItem.Text = "Copy file1";
            this.copyFile1ToolStripMenuItem.Click += new System.EventHandler(this.CopyFile1ToolStripMenuItem_Click);
            // 
            // copyFile2ToolStripMenuItem
            // 
            this.copyFile2ToolStripMenuItem.Name = "copyFile2ToolStripMenuItem";
            this.copyFile2ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.copyFile2ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.copyFile2ToolStripMenuItem.Text = "Copy file2";
            this.copyFile2ToolStripMenuItem.Click += new System.EventHandler(this.CopyFile2ToolStripMenuItem_Click);
            // 
            // copyBookmarks1ToolStripMenuItem
            // 
            this.copyBookmarks1ToolStripMenuItem.Name = "copyBookmarks1ToolStripMenuItem";
            this.copyBookmarks1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.copyBookmarks1ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.copyBookmarks1ToolStripMenuItem.Text = "Copy bookmarks1";
            this.copyBookmarks1ToolStripMenuItem.Click += new System.EventHandler(this.CopyBookmarks1ToolStripMenuItem_Click);
            // 
            // copyBookmarks2ToolStripMenuItem
            // 
            this.copyBookmarks2ToolStripMenuItem.Name = "copyBookmarks2ToolStripMenuItem";
            this.copyBookmarks2ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.copyBookmarks2ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.copyBookmarks2ToolStripMenuItem.Text = "Copy bookmarks2";
            this.copyBookmarks2ToolStripMenuItem.Click += new System.EventHandler(this.CopyBookmarks2ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(219, 6);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.findToolStripMenuItem.Text = "Find...";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.FindToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(219, 6);
            // 
            // toolStripMenuItemEnableReduceColorCopy
            // 
            this.toolStripMenuItemEnableReduceColorCopy.Name = "toolStripMenuItemEnableReduceColorCopy";
            this.toolStripMenuItemEnableReduceColorCopy.Size = new System.Drawing.Size(222, 22);
            this.toolStripMenuItemEnableReduceColorCopy.Text = "Enable color reduction copy";
            this.toolStripMenuItemEnableReduceColorCopy.Click += new System.EventHandler(this.toolStripMenuItemEnableReduceColorCopy_Click);
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comparePageToolStripMenuItem,
            this.compareBookmarkToolStripMenuItem,
            this.compareBookToolStripMenuItem,
            this.toolStripMenuItem1,
            this.previousDifferenceToolStripMenuItem,
            this.nextDifferenceToolStripMenuItem,
            this.toolStripSeparator2,
            this.clearMarker1ToolStripMenuItem,
            this.clearMarker2ToolStripMenuItem,
            this.clearAllMakersToolStripMenuItem});
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.compareToolStripMenuItem.Text = "&Compare";
            // 
            // comparePageToolStripMenuItem
            // 
            this.comparePageToolStripMenuItem.Name = "comparePageToolStripMenuItem";
            this.comparePageToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.comparePageToolStripMenuItem.Text = "Compare page";
            this.comparePageToolStripMenuItem.Click += new System.EventHandler(this.ComparePageToolStripMenuItem_Click);
            // 
            // compareBookmarkToolStripMenuItem
            // 
            this.compareBookmarkToolStripMenuItem.Name = "compareBookmarkToolStripMenuItem";
            this.compareBookmarkToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.compareBookmarkToolStripMenuItem.Text = "Compare Bookmark";
            this.compareBookmarkToolStripMenuItem.Click += new System.EventHandler(this.compareBookmarkToolStripMenuItem_Click);
            // 
            // compareBookToolStripMenuItem
            // 
            this.compareBookToolStripMenuItem.Name = "compareBookToolStripMenuItem";
            this.compareBookToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.compareBookToolStripMenuItem.Text = "Compare Book";
            this.compareBookToolStripMenuItem.Click += new System.EventHandler(this.compareBookToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(174, 6);
            // 
            // previousDifferenceToolStripMenuItem
            // 
            this.previousDifferenceToolStripMenuItem.Name = "previousDifferenceToolStripMenuItem";
            this.previousDifferenceToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.previousDifferenceToolStripMenuItem.Text = "Previous Difference";
            this.previousDifferenceToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonPrevDiff_Click);
            // 
            // nextDifferenceToolStripMenuItem
            // 
            this.nextDifferenceToolStripMenuItem.Name = "nextDifferenceToolStripMenuItem";
            this.nextDifferenceToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.nextDifferenceToolStripMenuItem.Text = "Next Difference";
            this.nextDifferenceToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonNextDiff_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // clearMarker1ToolStripMenuItem
            // 
            this.clearMarker1ToolStripMenuItem.Name = "clearMarker1ToolStripMenuItem";
            this.clearMarker1ToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.clearMarker1ToolStripMenuItem.Text = "Clear marker1";
            this.clearMarker1ToolStripMenuItem.Click += new System.EventHandler(this.ClearMarker1ToolStripMenuItem_Click);
            // 
            // clearMarker2ToolStripMenuItem
            // 
            this.clearMarker2ToolStripMenuItem.Name = "clearMarker2ToolStripMenuItem";
            this.clearMarker2ToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.clearMarker2ToolStripMenuItem.Text = "Clear marker2";
            this.clearMarker2ToolStripMenuItem.Click += new System.EventHandler(this.ClearMarker2ToolStripMenuItem_Click);
            // 
            // clearAllMakersToolStripMenuItem
            // 
            this.clearAllMakersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearBook1MarkerToolStripMenuItem,
            this.clearBook2MarkerToolStripMenuItem});
            this.clearAllMakersToolStripMenuItem.Name = "clearAllMakersToolStripMenuItem";
            this.clearAllMakersToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.clearAllMakersToolStripMenuItem.Text = "Clear all makers";
            // 
            // clearBook1MarkerToolStripMenuItem
            // 
            this.clearBook1MarkerToolStripMenuItem.Name = "clearBook1MarkerToolStripMenuItem";
            this.clearBook1MarkerToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.clearBook1MarkerToolStripMenuItem.Text = "Clear book1 marker";
            this.clearBook1MarkerToolStripMenuItem.Click += new System.EventHandler(this.clearBook1MarkerToolStripMenuItem_Click);
            // 
            // clearBook2MarkerToolStripMenuItem
            // 
            this.clearBook2MarkerToolStripMenuItem.Name = "clearBook2MarkerToolStripMenuItem";
            this.clearBook2MarkerToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.clearBook2MarkerToolStripMenuItem.Text = "Clear book2 marker";
            this.clearBook2MarkerToolStripMenuItem.Click += new System.EventHandler(this.clearBook2MarkerToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usageToolStripMenuItem,
            this.outputDebugLogToolStripMenuItem,
            this.aboutPDFCompToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // usageToolStripMenuItem
            // 
            this.usageToolStripMenuItem.Name = "usageToolStripMenuItem";
            this.usageToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.usageToolStripMenuItem.Text = "Usage ...";
            this.usageToolStripMenuItem.Click += new System.EventHandler(this.usageToolStripMenuItem_Click);
            // 
            // outputDebugLogToolStripMenuItem
            // 
            this.outputDebugLogToolStripMenuItem.Name = "outputDebugLogToolStripMenuItem";
            this.outputDebugLogToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.outputDebugLogToolStripMenuItem.Text = "Output Debug Log";
            this.outputDebugLogToolStripMenuItem.Visible = false;
            this.outputDebugLogToolStripMenuItem.Click += new System.EventHandler(this.outputDebugLogToolStripMenuItem_Click);
            // 
            // aboutPDFCompToolStripMenuItem
            // 
            this.aboutPDFCompToolStripMenuItem.Name = "aboutPDFCompToolStripMenuItem";
            this.aboutPDFCompToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.aboutPDFCompToolStripMenuItem.Text = "About PDFComp ...";
            this.aboutPDFCompToolStripMenuItem.Click += new System.EventHandler(this.AboutPDFCompToolStripMenuItem_Click);
            // 
            // panelBoth
            // 
            this.panelBoth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBoth.Controls.Add(this.pdfPanel2);
            this.panelBoth.Controls.Add(this.pdfPanel1);
            this.panelBoth.Location = new System.Drawing.Point(0, 60);
            this.panelBoth.Name = "panelBoth";
            this.panelBoth.Size = new System.Drawing.Size(1192, 713);
            this.panelBoth.TabIndex = 2;
            this.panelBoth.SizeChanged += new System.EventHandler(this.Panel1_SizeChanged);
            // 
            // pdfPanel2
            // 
            this.pdfPanel2.AllowDrop = true;
            this.pdfPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pdfPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pdfPanel2.Location = new System.Drawing.Point(617, 0);
            this.pdfPanel2.Name = "pdfPanel2";
            this.pdfPanel2.Size = new System.Drawing.Size(575, 713);
            this.pdfPanel2.TabIndex = 2;
            // 
            // pdfPanel1
            // 
            this.pdfPanel1.AllowDrop = true;
            this.pdfPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pdfPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pdfPanel1.Location = new System.Drawing.Point(0, 0);
            this.pdfPanel1.Name = "pdfPanel1";
            this.pdfPanel1.Size = new System.Drawing.Size(512, 713);
            this.pdfPanel1.TabIndex = 1;
            // 
            // timerButton
            // 
            this.timerButton.Tick += new System.EventHandler(this.TimerButton_Tick);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonBookmarks,
            this.toolStripButtonPrevPages,
            this.toolStripButtonNextPages,
            this.toolStripButtonPanel1Prev,
            this.toolStripButtonPanel1Next,
            this.toolStripButtonPanel2Prev,
            this.toolStripButtonPanel2Next,
            this.toolStripSeparator4,
            this.toolStripSplitButtonCompare,
            this.toolStripLabelResult,
            this.toolStripButtonPrevDiff,
            this.toolStripButtonNextDiff,
            this.toolStripLabel2,
            this.toolStripComboBoxDiffType,
            this.toolStripSeparator6,
            this.toolStripButtonHandmode,
            this.toolStripButtonTextmode,
            this.toolStripButtonBoundsmode,
            this.toolStripSeparator5,
            this.toolStripButtonRotateAnticlockwise,
            this.toolStripButtonRotateClockwise,
            this.toolStripButtonZoomIn,
            this.toolStripTrackBarZoom,
            this.toolStripLabel1,
            this.toolStripButtonZoomOut,
            this.toolStripLabelZoom,
            this.toolStripButtonFitWidth,
            this.toolStripButtonFitOnePage});
            this.toolStrip2.Location = new System.Drawing.Point(0, 24);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1192, 33);
            this.toolStrip2.TabIndex = 23;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButtonBookmarks
            // 
            this.toolStripButtonBookmarks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBookmarks.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBookmarks.Image")));
            this.toolStripButtonBookmarks.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonBookmarks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBookmarks.Name = "toolStripButtonBookmarks";
            this.toolStripButtonBookmarks.Size = new System.Drawing.Size(28, 30);
            this.toolStripButtonBookmarks.Text = "Bookmarks";
            this.toolStripButtonBookmarks.ToolTipText = "Show Bookmarks";
            this.toolStripButtonBookmarks.Click += new System.EventHandler(this.toolStripButtonBookmarks_Click);
            // 
            // toolStripButtonPrevPages
            // 
            this.toolStripButtonPrevPages.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButtonPrevPages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPrevPages.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.toolStripButtonPrevPages.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPrevPages.Image")));
            this.toolStripButtonPrevPages.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonPrevPages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrevPages.Name = "toolStripButtonPrevPages";
            this.toolStripButtonPrevPages.Size = new System.Drawing.Size(28, 30);
            this.toolStripButtonPrevPages.Text = "Prev Page";
            this.toolStripButtonPrevPages.ToolTipText = "Prev Page / LEFT_ARROW";
            this.toolStripButtonPrevPages.Click += new System.EventHandler(this.toolStripButtonPrevPages_Click);
            // 
            // toolStripButtonNextPages
            // 
            this.toolStripButtonNextPages.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButtonNextPages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNextPages.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNextPages.Image")));
            this.toolStripButtonNextPages.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonNextPages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNextPages.Name = "toolStripButtonNextPages";
            this.toolStripButtonNextPages.Size = new System.Drawing.Size(28, 30);
            this.toolStripButtonNextPages.Text = "Next Page";
            this.toolStripButtonNextPages.ToolTipText = "Next Page / RIGHT_ARROW";
            this.toolStripButtonNextPages.Click += new System.EventHandler(this.toolStripButtonNextPages_Click);
            // 
            // toolStripButtonPanel1Prev
            // 
            this.toolStripButtonPanel1Prev.AutoSize = false;
            this.toolStripButtonPanel1Prev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPanel1Prev.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPanel1Prev.Image")));
            this.toolStripButtonPanel1Prev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPanel1Prev.Name = "toolStripButtonPanel1Prev";
            this.toolStripButtonPanel1Prev.Size = new System.Drawing.Size(18, 30);
            this.toolStripButtonPanel1Prev.Text = "Prev Page";
            this.toolStripButtonPanel1Prev.ToolTipText = "Prev Page / Ctrl + LEFT_ARROW";
            this.toolStripButtonPanel1Prev.Click += new System.EventHandler(this.toolStripButtonPanel1Prev_Click);
            // 
            // toolStripButtonPanel1Next
            // 
            this.toolStripButtonPanel1Next.AutoSize = false;
            this.toolStripButtonPanel1Next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPanel1Next.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPanel1Next.Image")));
            this.toolStripButtonPanel1Next.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPanel1Next.Name = "toolStripButtonPanel1Next";
            this.toolStripButtonPanel1Next.Size = new System.Drawing.Size(18, 30);
            this.toolStripButtonPanel1Next.Text = "Next Page";
            this.toolStripButtonPanel1Next.ToolTipText = "Next Page / Ctrl + RIGHT_ARROW";
            this.toolStripButtonPanel1Next.Click += new System.EventHandler(this.toolStripButtonPanel1Next_Click);
            // 
            // toolStripButtonPanel2Prev
            // 
            this.toolStripButtonPanel2Prev.AutoSize = false;
            this.toolStripButtonPanel2Prev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPanel2Prev.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPanel2Prev.Image")));
            this.toolStripButtonPanel2Prev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPanel2Prev.Name = "toolStripButtonPanel2Prev";
            this.toolStripButtonPanel2Prev.Size = new System.Drawing.Size(18, 30);
            this.toolStripButtonPanel2Prev.Text = "Prev Page";
            this.toolStripButtonPanel2Prev.ToolTipText = "Prev Page / Alt + LEFT_ARROW";
            this.toolStripButtonPanel2Prev.Click += new System.EventHandler(this.toolStripButtonPanel2Prev_Click);
            // 
            // toolStripButtonPanel2Next
            // 
            this.toolStripButtonPanel2Next.AutoSize = false;
            this.toolStripButtonPanel2Next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPanel2Next.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPanel2Next.Image")));
            this.toolStripButtonPanel2Next.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPanel2Next.Name = "toolStripButtonPanel2Next";
            this.toolStripButtonPanel2Next.Size = new System.Drawing.Size(18, 30);
            this.toolStripButtonPanel2Next.Text = "Next Page";
            this.toolStripButtonPanel2Next.ToolTipText = "Next Page / Alt + RIGHT_ARROW";
            this.toolStripButtonPanel2Next.Click += new System.EventHandler(this.toolStripButtonPanel2Next_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AutoSize = false;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(32, 33);
            // 
            // toolStripSplitButtonCompare
            // 
            this.toolStripSplitButtonCompare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButtonCompare.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pageToolStripMenuItem,
            this.bookmarkToolStripMenuItem,
            this.bookToolStripMenuItem});
            this.toolStripSplitButtonCompare.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripSplitButtonCompare.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButtonCompare.Image")));
            this.toolStripSplitButtonCompare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButtonCompare.Name = "toolStripSplitButtonCompare";
            this.toolStripSplitButtonCompare.Size = new System.Drawing.Size(103, 30);
            this.toolStripSplitButtonCompare.Text = "Compare Page";
            this.toolStripSplitButtonCompare.ButtonClick += new System.EventHandler(this.toolStripSplitButtonCompare_ButtonClick);
            // 
            // pageToolStripMenuItem
            // 
            this.pageToolStripMenuItem.Name = "pageToolStripMenuItem";
            this.pageToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.pageToolStripMenuItem.Text = "Compare Page";
            this.pageToolStripMenuItem.Click += new System.EventHandler(this.pageToolStripMenuItem_Click);
            // 
            // bookmarkToolStripMenuItem
            // 
            this.bookmarkToolStripMenuItem.Name = "bookmarkToolStripMenuItem";
            this.bookmarkToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.bookmarkToolStripMenuItem.Text = "Compare Bookmark";
            this.bookmarkToolStripMenuItem.Click += new System.EventHandler(this.bookmarkToolStripMenuItem_Click);
            // 
            // bookToolStripMenuItem
            // 
            this.bookToolStripMenuItem.Name = "bookToolStripMenuItem";
            this.bookToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.bookToolStripMenuItem.Text = "Compare Book";
            this.bookToolStripMenuItem.Click += new System.EventHandler(this.bookToolStripMenuItem_Click);
            // 
            // toolStripLabelResult
            // 
            this.toolStripLabelResult.AutoSize = false;
            this.toolStripLabelResult.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabelResult.Font = new System.Drawing.Font("Yu Gothic UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toolStripLabelResult.Name = "toolStripLabelResult";
            this.toolStripLabelResult.Size = new System.Drawing.Size(26, 10);
            this.toolStripLabelResult.Text = "0.0";
            this.toolStripLabelResult.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // toolStripButtonPrevDiff
            // 
            this.toolStripButtonPrevDiff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPrevDiff.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPrevDiff.Image")));
            this.toolStripButtonPrevDiff.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonPrevDiff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrevDiff.Name = "toolStripButtonPrevDiff";
            this.toolStripButtonPrevDiff.Size = new System.Drawing.Size(28, 30);
            this.toolStripButtonPrevDiff.Text = "Prev different page";
            this.toolStripButtonPrevDiff.Click += new System.EventHandler(this.toolStripButtonPrevDiff_Click);
            // 
            // toolStripButtonNextDiff
            // 
            this.toolStripButtonNextDiff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNextDiff.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNextDiff.Image")));
            this.toolStripButtonNextDiff.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonNextDiff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNextDiff.Name = "toolStripButtonNextDiff";
            this.toolStripButtonNextDiff.Size = new System.Drawing.Size(28, 30);
            this.toolStripButtonNextDiff.Text = "Next different page";
            this.toolStripButtonNextDiff.Click += new System.EventHandler(this.toolStripButtonNextDiff_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(16, 30);
            this.toolStripLabel2.Text = "  ";
            // 
            // toolStripComboBoxDiffType
            // 
            this.toolStripComboBoxDiffType.AutoSize = false;
            this.toolStripComboBoxDiffType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxDiffType.DropDownWidth = 161;
            this.toolStripComboBoxDiffType.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripComboBoxDiffType.Items.AddRange(new object[] {
            "Character mode",
            "Semantic mode"});
            this.toolStripComboBoxDiffType.Name = "toolStripComboBoxDiffType";
            this.toolStripComboBoxDiffType.Size = new System.Drawing.Size(161, 23);
            this.toolStripComboBoxDiffType.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.AutoSize = false;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(32, 33);
            // 
            // toolStripButtonHandmode
            // 
            this.toolStripButtonHandmode.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButtonHandmode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHandmode.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonHandmode.Image")));
            this.toolStripButtonHandmode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonHandmode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHandmode.Name = "toolStripButtonHandmode";
            this.toolStripButtonHandmode.Size = new System.Drawing.Size(28, 30);
            this.toolStripButtonHandmode.Text = "Hand mode";
            this.toolStripButtonHandmode.Click += new System.EventHandler(this.toolStripButtonHandmode_Click);
            // 
            // toolStripButtonTextmode
            // 
            this.toolStripButtonTextmode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTextmode.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTextmode.Image")));
            this.toolStripButtonTextmode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonTextmode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTextmode.Name = "toolStripButtonTextmode";
            this.toolStripButtonTextmode.Size = new System.Drawing.Size(28, 30);
            this.toolStripButtonTextmode.Text = "Text mode";
            this.toolStripButtonTextmode.Click += new System.EventHandler(this.toolStripButtonTextmode_Click);
            // 
            // toolStripButtonBoundsmode
            // 
            this.toolStripButtonBoundsmode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBoundsmode.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBoundsmode.Image")));
            this.toolStripButtonBoundsmode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonBoundsmode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBoundsmode.Name = "toolStripButtonBoundsmode";
            this.toolStripButtonBoundsmode.Size = new System.Drawing.Size(28, 30);
            this.toolStripButtonBoundsmode.Text = "Bounds mode";
            this.toolStripButtonBoundsmode.Click += new System.EventHandler(this.toolStripButtonBoundsmode_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.AutoSize = false;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(32, 33);
            // 
            // toolStripButtonRotateAnticlockwise
            // 
            this.toolStripButtonRotateAnticlockwise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRotateAnticlockwise.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRotateAnticlockwise.Image")));
            this.toolStripButtonRotateAnticlockwise.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonRotateAnticlockwise.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRotateAnticlockwise.Name = "toolStripButtonRotateAnticlockwise";
            this.toolStripButtonRotateAnticlockwise.Size = new System.Drawing.Size(28, 30);
            this.toolStripButtonRotateAnticlockwise.Text = "Rotate Anticlockwise";
            this.toolStripButtonRotateAnticlockwise.Click += new System.EventHandler(this.toolStripButtonRotateAnticlockwise_Click);
            // 
            // toolStripButtonRotateClockwise
            // 
            this.toolStripButtonRotateClockwise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRotateClockwise.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRotateClockwise.Image")));
            this.toolStripButtonRotateClockwise.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonRotateClockwise.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRotateClockwise.Name = "toolStripButtonRotateClockwise";
            this.toolStripButtonRotateClockwise.Size = new System.Drawing.Size(28, 30);
            this.toolStripButtonRotateClockwise.Text = "Rotate Clockwise";
            this.toolStripButtonRotateClockwise.Click += new System.EventHandler(this.toolStripButtonRotateClockwise_Click);
            // 
            // toolStripButtonZoomIn
            // 
            this.toolStripButtonZoomIn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonZoomIn.Image")));
            this.toolStripButtonZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomIn.Name = "toolStripButtonZoomIn";
            this.toolStripButtonZoomIn.Size = new System.Drawing.Size(28, 30);
            this.toolStripButtonZoomIn.Text = "Zoom in";
            this.toolStripButtonZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButtonZoomIn_MouseDown);
            this.toolStripButtonZoomIn.MouseLeave += new System.EventHandler(this.toolStripButtonZoomIn_MouseLeave);
            this.toolStripButtonZoomIn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripButtonZoomIn_MouseUp);
            // 
            // toolStripTrackBarZoom
            // 
            this.toolStripTrackBarZoom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTrackBarZoom.AutoSize = false;
            this.toolStripTrackBarZoom.LargeChange = 5;
            this.toolStripTrackBarZoom.Maximum = 30;
            this.toolStripTrackBarZoom.Minimum = -30;
            this.toolStripTrackBarZoom.Name = "toolStripTrackBarZoom";
            this.toolStripTrackBarZoom.Size = new System.Drawing.Size(176, 45);
            this.toolStripTrackBarZoom.SmallChange = 1;
            this.toolStripTrackBarZoom.Text = "Zoom slider";
            this.toolStripTrackBarZoom.TickFrequency = 30;
            this.toolStripTrackBarZoom.Value = 0;
            this.toolStripTrackBarZoom.ValueChanged += new System.EventHandler(this.toolStripTrackBarZoom_ValueChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(24, 30);
            // 
            // toolStripButtonZoomOut
            // 
            this.toolStripButtonZoomOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonZoomOut.Image")));
            this.toolStripButtonZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomOut.Name = "toolStripButtonZoomOut";
            this.toolStripButtonZoomOut.Size = new System.Drawing.Size(28, 30);
            this.toolStripButtonZoomOut.Text = "Zoom out";
            this.toolStripButtonZoomOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButtonZoomOut_MouseDown);
            this.toolStripButtonZoomOut.MouseLeave += new System.EventHandler(this.toolStripButtonZoomOut_MouseLeave);
            this.toolStripButtonZoomOut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripButtonZoomOut_MouseUp);
            // 
            // toolStripLabelZoom
            // 
            this.toolStripLabelZoom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelZoom.AutoSize = false;
            this.toolStripLabelZoom.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabelZoom.Name = "toolStripLabelZoom";
            this.toolStripLabelZoom.Size = new System.Drawing.Size(51, 30);
            this.toolStripLabelZoom.Text = "100 %";
            // 
            // toolStripButtonFitWidth
            // 
            this.toolStripButtonFitWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFitWidth.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFitWidth.Image")));
            this.toolStripButtonFitWidth.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonFitWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFitWidth.Name = "toolStripButtonFitWidth";
            this.toolStripButtonFitWidth.Size = new System.Drawing.Size(28, 30);
            this.toolStripButtonFitWidth.Text = "Fit width";
            this.toolStripButtonFitWidth.Click += new System.EventHandler(this.toolStripButtonFitWidth_Click);
            // 
            // toolStripButtonFitOnePage
            // 
            this.toolStripButtonFitOnePage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFitOnePage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFitOnePage.Image")));
            this.toolStripButtonFitOnePage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonFitOnePage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFitOnePage.Name = "toolStripButtonFitOnePage";
            this.toolStripButtonFitOnePage.Size = new System.Drawing.Size(28, 30);
            this.toolStripButtonFitOnePage.Text = "Fit one page";
            this.toolStripButtonFitOnePage.Click += new System.EventHandler(this.toolStripButtonFitOnePage_Click);
            // 
            // timerCyclic
            // 
            this.timerCyclic.Tick += new System.EventHandler(this.timerCyclic_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 773);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panelBoth);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Tag = "PdfPanel";
            this.Text = "PDFComp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelBoth.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panelBoth;
        private PdfPanel pdfPanel2;
        private PdfPanel pdfPanel1;
        private System.Windows.Forms.Timer timerButton;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFile1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFile2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutPDFCompToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyBookmarks1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyBookmarks2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comparePageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareBookmarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearMarker1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMarker2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextDifferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousDifferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEnableReduceColorCopy;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrevPages;
        private System.Windows.Forms.ToolStripButton toolStripButtonNextPages;
        private System.Windows.Forms.ToolStripButton toolStripButtonBookmarks;
        private System.Windows.Forms.ToolStripButton toolStripButtonRotateAnticlockwise;
        private System.Windows.Forms.ToolStripButton toolStripButtonRotateClockwise;
        private System.Windows.Forms.ToolStripLabel toolStripLabelZoom;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonHandmode;
        private System.Windows.Forms.ToolStripButton toolStripButtonTextmode;
        private System.Windows.Forms.ToolStripButton toolStripButtonBoundsmode;
        private System.Windows.Forms.ToolStripButton toolStripButtonPanel1Prev;
        private System.Windows.Forms.ToolStripButton toolStripButtonPanel1Next;
        private System.Windows.Forms.ToolStripButton toolStripButtonPanel2Prev;
        private System.Windows.Forms.ToolStripButton toolStripButtonPanel2Next;
        private System.Windows.Forms.ToolStripButton toolStripButtonFitWidth;
        private System.Windows.Forms.ToolStripButton toolStripButtonFitOnePage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomOut;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomIn;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrevDiff;
        private System.Windows.Forms.ToolStripButton toolStripButtonNextDiff;
        private ToolStripTrackBar toolStripTrackBarZoom;
        private System.Windows.Forms.ToolStripLabel toolStripLabelResult;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxDiffType;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButtonCompare;
        private System.Windows.Forms.ToolStripMenuItem bookmarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputDebugLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllMakersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearBook1MarkerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearBook2MarkerToolStripMenuItem;
        private System.Windows.Forms.Timer timerCyclic;
    }
}

