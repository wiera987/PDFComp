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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.nextDifferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousDifferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearMarker1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMarker2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutPDFCompToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panelBoth = new System.Windows.Forms.Panel();
            this.pdfPanel2 = new PDFComp.PdfPanel();
            this.pdfPanel1 = new PDFComp.PdfPanel();
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.trackBarZoom = new System.Windows.Forms.TrackBar();
            this.labelZoom = new System.Windows.Forms.Label();
            this.timerButton = new System.Windows.Forms.Timer(this.components);
            this.buttonPrevPage = new System.Windows.Forms.Button();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonCompare = new System.Windows.Forms.Button();
            this.buttonBookmark = new System.Windows.Forms.Button();
            this.buttonRotateLeft = new System.Windows.Forms.Button();
            this.buttonRotateRight = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.comboBoxDiffType = new System.Windows.Forms.ComboBox();
            this.radioButtonPan = new System.Windows.Forms.RadioButton();
            this.radioButtonText = new System.Windows.Forms.RadioButton();
            this.buttonFindDiff = new System.Windows.Forms.Button();
            this.radioButtonBounds = new System.Windows.Forms.RadioButton();
            this.buttonPrevDiff = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonBookmarks = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPanel1Prev = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPanel1Next = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPrevPages = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNextPages = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPanel2Prev = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPanel2Next = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonComparePage = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelResult = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonNextDiff = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPrevDiff = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxDiffType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonHandmode = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTextmode = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectmode = new System.Windows.Forms.ToolStripButton();
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
            this.menuStrip.SuspendLayout();
            this.panelBoth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
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
            this.toolStripMenuItem1,
            this.nextDifferenceToolStripMenuItem,
            this.previousDifferenceToolStripMenuItem,
            this.toolStripSeparator2,
            this.clearMarker1ToolStripMenuItem,
            this.clearMarker2ToolStripMenuItem});
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.compareToolStripMenuItem.Text = "&Compare";
            // 
            // comparePageToolStripMenuItem
            // 
            this.comparePageToolStripMenuItem.Name = "comparePageToolStripMenuItem";
            this.comparePageToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.comparePageToolStripMenuItem.Text = "Compare page";
            this.comparePageToolStripMenuItem.Click += new System.EventHandler(this.ComparePageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
            // 
            // nextDifferenceToolStripMenuItem
            // 
            this.nextDifferenceToolStripMenuItem.Name = "nextDifferenceToolStripMenuItem";
            this.nextDifferenceToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.nextDifferenceToolStripMenuItem.Text = "Next Difference";
            this.nextDifferenceToolStripMenuItem.Click += new System.EventHandler(this.previousDifferenceToolStripMenuItem_Click);
            // 
            // previousDifferenceToolStripMenuItem
            // 
            this.previousDifferenceToolStripMenuItem.Name = "previousDifferenceToolStripMenuItem";
            this.previousDifferenceToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.previousDifferenceToolStripMenuItem.Text = "Previous Difference";
            this.previousDifferenceToolStripMenuItem.Click += new System.EventHandler(this.previousDifferenceToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(172, 6);
            // 
            // clearMarker1ToolStripMenuItem
            // 
            this.clearMarker1ToolStripMenuItem.Name = "clearMarker1ToolStripMenuItem";
            this.clearMarker1ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.clearMarker1ToolStripMenuItem.Text = "Clear marker1";
            this.clearMarker1ToolStripMenuItem.Click += new System.EventHandler(this.ClearMarker1ToolStripMenuItem_Click);
            // 
            // clearMarker2ToolStripMenuItem
            // 
            this.clearMarker2ToolStripMenuItem.Name = "clearMarker2ToolStripMenuItem";
            this.clearMarker2ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.clearMarker2ToolStripMenuItem.Text = "Clear marker2";
            this.clearMarker2ToolStripMenuItem.Click += new System.EventHandler(this.ClearMarker2ToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usageToolStripMenuItem,
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
            // aboutPDFCompToolStripMenuItem
            // 
            this.aboutPDFCompToolStripMenuItem.Name = "aboutPDFCompToolStripMenuItem";
            this.aboutPDFCompToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.aboutPDFCompToolStripMenuItem.Text = "About PDFComp ...";
            this.aboutPDFCompToolStripMenuItem.Click += new System.EventHandler(this.AboutPDFCompToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1192, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
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
            // buttonZoomIn
            // 
            this.buttonZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZoomIn.Location = new System.Drawing.Point(1150, 24);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(23, 23);
            this.buttonZoomIn.TabIndex = 16;
            this.buttonZoomIn.Text = "+";
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            this.buttonZoomIn.Click += new System.EventHandler(this.ButtonZoomIn_Click);
            this.buttonZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonZoomIn_MouseDown);
            this.buttonZoomIn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonZoomIn_MouseUp);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZoomOut.Location = new System.Drawing.Point(939, 24);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(23, 23);
            this.buttonZoomOut.TabIndex = 14;
            this.buttonZoomOut.Text = "-";
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            this.buttonZoomOut.Click += new System.EventHandler(this.ButtonZoomOut_Click);
            this.buttonZoomOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonZoomOut_MouseDown);
            this.buttonZoomOut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonZoomOut_MouseUp);
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarZoom.AutoSize = false;
            this.trackBarZoom.Location = new System.Drawing.Point(968, 24);
            this.trackBarZoom.Maximum = 30;
            this.trackBarZoom.Minimum = -30;
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(176, 22);
            this.trackBarZoom.TabIndex = 15;
            this.trackBarZoom.TickFrequency = 30;
            this.trackBarZoom.ValueChanged += new System.EventHandler(this.TrackBarZoom_ValueChanged);
            // 
            // labelZoom
            // 
            this.labelZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelZoom.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelZoom.Location = new System.Drawing.Point(882, 24);
            this.labelZoom.Name = "labelZoom";
            this.labelZoom.Size = new System.Drawing.Size(51, 17);
            this.labelZoom.TabIndex = 6;
            this.labelZoom.Text = "100 %";
            // 
            // timerButton
            // 
            this.timerButton.Tick += new System.EventHandler(this.TimerButton_Tick);
            // 
            // buttonPrevPage
            // 
            this.buttonPrevPage.Location = new System.Drawing.Point(12, 24);
            this.buttonPrevPage.Name = "buttonPrevPage";
            this.buttonPrevPage.Size = new System.Drawing.Size(69, 23);
            this.buttonPrevPage.TabIndex = 7;
            this.buttonPrevPage.Text = "< Prev";
            this.buttonPrevPage.UseVisualStyleBackColor = true;
            this.buttonPrevPage.Click += new System.EventHandler(this.ButtonPrevPage_Click);
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Location = new System.Drawing.Point(81, 24);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(69, 23);
            this.buttonNextPage.TabIndex = 8;
            this.buttonNextPage.Text = "> Next";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.ButtonNextPage_Click);
            // 
            // buttonCompare
            // 
            this.buttonCompare.Location = new System.Drawing.Point(553, 24);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(99, 23);
            this.buttonCompare.TabIndex = 12;
            this.buttonCompare.Text = "Compare Page";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.ButtonCompare_Click);
            // 
            // buttonBookmark
            // 
            this.buttonBookmark.Location = new System.Drawing.Point(167, 24);
            this.buttonBookmark.Name = "buttonBookmark";
            this.buttonBookmark.Size = new System.Drawing.Size(75, 23);
            this.buttonBookmark.TabIndex = 9;
            this.buttonBookmark.Text = "Bookmark";
            this.buttonBookmark.UseVisualStyleBackColor = true;
            this.buttonBookmark.Click += new System.EventHandler(this.ButtonBookmark_Click);
            // 
            // buttonRotateLeft
            // 
            this.buttonRotateLeft.Image = ((System.Drawing.Image)(resources.GetObject("buttonRotateLeft.Image")));
            this.buttonRotateLeft.Location = new System.Drawing.Point(251, 24);
            this.buttonRotateLeft.Name = "buttonRotateLeft";
            this.buttonRotateLeft.Size = new System.Drawing.Size(52, 23);
            this.buttonRotateLeft.TabIndex = 10;
            this.buttonRotateLeft.UseVisualStyleBackColor = true;
            this.buttonRotateLeft.Click += new System.EventHandler(this.ButtonRotateLeft_Click);
            // 
            // buttonRotateRight
            // 
            this.buttonRotateRight.Image = ((System.Drawing.Image)(resources.GetObject("buttonRotateRight.Image")));
            this.buttonRotateRight.Location = new System.Drawing.Point(304, 24);
            this.buttonRotateRight.Name = "buttonRotateRight";
            this.buttonRotateRight.Size = new System.Drawing.Size(52, 23);
            this.buttonRotateRight.TabIndex = 11;
            this.buttonRotateRight.UseVisualStyleBackColor = true;
            this.buttonRotateRight.Click += new System.EventHandler(this.ButtonRotateRight_Click);
            // 
            // labelResult
            // 
            this.labelResult.BackColor = System.Drawing.Color.Transparent;
            this.labelResult.Font = new System.Drawing.Font("MS UI Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelResult.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelResult.Location = new System.Drawing.Point(657, 33);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(26, 10);
            this.labelResult.TabIndex = 17;
            this.labelResult.Text = "...";
            // 
            // comboBoxDiffType
            // 
            this.comboBoxDiffType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDiffType.FormattingEnabled = true;
            this.comboBoxDiffType.Items.AddRange(new object[] {
            "Character mode",
            "Line mode - Semantic",
            "Line mode - Efficiency 4",
            "Line mode - Efficiency 5",
            "Line mode - Efficiency 3"});
            this.comboBoxDiffType.Location = new System.Drawing.Point(689, 26);
            this.comboBoxDiffType.Name = "comboBoxDiffType";
            this.comboBoxDiffType.Size = new System.Drawing.Size(181, 20);
            this.comboBoxDiffType.TabIndex = 13;
            this.comboBoxDiffType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDiffType_SelectedIndexChanged);
            // 
            // radioButtonPan
            // 
            this.radioButtonPan.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonPan.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonPan.Image")));
            this.radioButtonPan.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.radioButtonPan.Location = new System.Drawing.Point(373, 24);
            this.radioButtonPan.Name = "radioButtonPan";
            this.radioButtonPan.Size = new System.Drawing.Size(34, 23);
            this.radioButtonPan.TabIndex = 18;
            this.radioButtonPan.TabStop = true;
            this.radioButtonPan.UseVisualStyleBackColor = true;
            this.radioButtonPan.CheckedChanged += new System.EventHandler(this.RadioButtonPan_CheckedChanged);
            // 
            // radioButtonText
            // 
            this.radioButtonText.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonText.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonText.Location = new System.Drawing.Point(406, 24);
            this.radioButtonText.Name = "radioButtonText";
            this.radioButtonText.Size = new System.Drawing.Size(34, 23);
            this.radioButtonText.TabIndex = 19;
            this.radioButtonText.TabStop = true;
            this.radioButtonText.Text = "T";
            this.radioButtonText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonText.UseVisualStyleBackColor = true;
            this.radioButtonText.CheckedChanged += new System.EventHandler(this.RadioButtonText_CheckedChanged);
            // 
            // buttonFindDiff
            // 
            this.buttonFindDiff.Location = new System.Drawing.Point(519, 24);
            this.buttonFindDiff.Name = "buttonFindDiff";
            this.buttonFindDiff.Size = new System.Drawing.Size(34, 23);
            this.buttonFindDiff.TabIndex = 20;
            this.buttonFindDiff.Text = ">>";
            this.buttonFindDiff.UseVisualStyleBackColor = true;
            this.buttonFindDiff.Click += new System.EventHandler(this.buttonFindDiff_Click);
            // 
            // radioButtonBounds
            // 
            this.radioButtonBounds.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonBounds.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonBounds.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonBounds.Image")));
            this.radioButtonBounds.Location = new System.Drawing.Point(439, 24);
            this.radioButtonBounds.Name = "radioButtonBounds";
            this.radioButtonBounds.Size = new System.Drawing.Size(34, 23);
            this.radioButtonBounds.TabIndex = 21;
            this.radioButtonBounds.TabStop = true;
            this.radioButtonBounds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonBounds.UseVisualStyleBackColor = true;
            this.radioButtonBounds.CheckedChanged += new System.EventHandler(this.radioButtonBounds_CheckedChanged);
            // 
            // buttonPrevDiff
            // 
            this.buttonPrevDiff.Location = new System.Drawing.Point(486, 24);
            this.buttonPrevDiff.Name = "buttonPrevDiff";
            this.buttonPrevDiff.Size = new System.Drawing.Size(34, 23);
            this.buttonPrevDiff.TabIndex = 22;
            this.buttonPrevDiff.Text = "<<";
            this.buttonPrevDiff.UseVisualStyleBackColor = true;
            this.buttonPrevDiff.Click += new System.EventHandler(this.buttonPrevDiff_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonBookmarks,
            this.toolStripButtonPanel1Prev,
            this.toolStripButtonPanel1Next,
            this.toolStripButtonPrevPages,
            this.toolStripButtonNextPages,
            this.toolStripButtonPanel2Prev,
            this.toolStripButtonPanel2Next,
            this.toolStripSeparator4,
            this.toolStripButtonComparePage,
            this.toolStripLabelResult,
            this.toolStripButtonPrevDiff,
            this.toolStripButtonNextDiff,
            this.toolStripLabel2,
            this.toolStripComboBoxDiffType,
            this.toolStripSeparator6,
            this.toolStripButtonHandmode,
            this.toolStripButtonTextmode,
            this.toolStripButtonSelectmode,
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
            this.toolStrip2.Location = new System.Drawing.Point(0, 49);
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
            // toolStripButtonComparePage
            // 
            this.toolStripButtonComparePage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonComparePage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonComparePage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonComparePage.Image")));
            this.toolStripButtonComparePage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonComparePage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonComparePage.Name = "toolStripButtonComparePage";
            this.toolStripButtonComparePage.Size = new System.Drawing.Size(91, 30);
            this.toolStripButtonComparePage.Text = "Compare Page";
            this.toolStripButtonComparePage.ToolTipText = "Compare Page | SPACE key";
            this.toolStripButtonComparePage.Click += new System.EventHandler(this.toolStripButtonComparePage_Click);
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
            "Line mode - Semantic",
            "Line mode - Efficiency 4",
            "Line mode - Efficiency 5",
            "Line mode - Efficiency 3"});
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
            // toolStripButtonSelectmode
            // 
            this.toolStripButtonSelectmode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSelectmode.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSelectmode.Image")));
            this.toolStripButtonSelectmode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSelectmode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectmode.Name = "toolStripButtonSelectmode";
            this.toolStripButtonSelectmode.Size = new System.Drawing.Size(28, 30);
            this.toolStripButtonSelectmode.Text = "Selecting mode";
            this.toolStripButtonSelectmode.Click += new System.EventHandler(this.toolStripButtonSelectmode_Click);
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
            this.toolStripButtonZoomIn.Click += new System.EventHandler(this.toolStripButtonZoomIn_Click);
            this.toolStripButtonZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButtonZoomIn_MouseDown);
            this.toolStripButtonZoomIn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripButtonZoomIn_MouseUp);
            // 
            // toolStripTrackBarZoom
            // 
            this.toolStripTrackBarZoom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTrackBarZoom.AutoSize = false;
            this.toolStripTrackBarZoom.Maximum = 30;
            this.toolStripTrackBarZoom.Minimum = -30;
            this.toolStripTrackBarZoom.Name = "toolStripTrackBarZoom";
            this.toolStripTrackBarZoom.Size = new System.Drawing.Size(176, 45);
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
            this.toolStripButtonZoomOut.Click += new System.EventHandler(this.toolStripButtonZoomOut_Click);
            this.toolStripButtonZoomOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButtonZoomOut_MouseDown);
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 773);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.buttonPrevDiff);
            this.Controls.Add(this.radioButtonBounds);
            this.Controls.Add(this.buttonFindDiff);
            this.Controls.Add(this.radioButtonText);
            this.Controls.Add(this.radioButtonPan);
            this.Controls.Add(this.comboBoxDiffType);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonRotateRight);
            this.Controls.Add(this.buttonRotateLeft);
            this.Controls.Add(this.buttonBookmark);
            this.Controls.Add(this.buttonCompare);
            this.Controls.Add(this.buttonNextPage);
            this.Controls.Add(this.buttonPrevPage);
            this.Controls.Add(this.labelZoom);
            this.Controls.Add(this.trackBarZoom);
            this.Controls.Add(this.buttonZoomOut);
            this.Controls.Add(this.buttonZoomIn);
            this.Controls.Add(this.panelBoth);
            this.Controls.Add(this.toolStrip1);
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panelBoth;
        private PdfPanel pdfPanel2;
        private PdfPanel pdfPanel1;
        private System.Windows.Forms.Button buttonZoomIn;
        private System.Windows.Forms.Button buttonZoomOut;
        private System.Windows.Forms.TrackBar trackBarZoom;
        private System.Windows.Forms.Label labelZoom;
        private System.Windows.Forms.Timer timerButton;
        private System.Windows.Forms.Button buttonPrevPage;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonCompare;
        private System.Windows.Forms.Button buttonBookmark;
        private System.Windows.Forms.Button buttonRotateLeft;
        private System.Windows.Forms.Button buttonRotateRight;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFile1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFile2ToolStripMenuItem;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutPDFCompToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyBookmarks1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyBookmarks2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comparePageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearMarker1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMarker2ToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxDiffType;
        private System.Windows.Forms.RadioButton radioButtonPan;
        private System.Windows.Forms.RadioButton radioButtonText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.Button buttonFindDiff;
        private System.Windows.Forms.ToolStripMenuItem usageToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButtonBounds;
        private System.Windows.Forms.Button buttonPrevDiff;
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
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectmode;
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
        private System.Windows.Forms.ToolStripButton toolStripButtonComparePage;
        private ToolStripTrackBar toolStripTrackBarZoom;
        private System.Windows.Forms.ToolStripLabel toolStripLabelResult;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxDiffType;
    }
}

