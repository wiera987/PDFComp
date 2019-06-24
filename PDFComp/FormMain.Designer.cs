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
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comparePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearMarker1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMarker2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutPDFCompToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panelBoth = new System.Windows.Forms.Panel();
            this.pdfPanel2 = new PDFComp.PdfPanel();
            this.pdfPanel1 = new PDFComp.PdfPanel();
            this.splitter1 = new System.Windows.Forms.Splitter();
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
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch1 = new System.Windows.Forms.Button();
            this.buttonSearch2 = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.comboBoxDiffType = new System.Windows.Forms.ComboBox();
            this.radioButtonPan = new System.Windows.Forms.RadioButton();
            this.radioButtonText = new System.Windows.Forms.RadioButton();
            this.menuStrip.SuspendLayout();
            this.panelBoth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
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
            this.copyBookmarks2ToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // copyFile1ToolStripMenuItem
            // 
            this.copyFile1ToolStripMenuItem.Name = "copyFile1ToolStripMenuItem";
            this.copyFile1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.copyFile1ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.copyFile1ToolStripMenuItem.Text = "Copy file1";
            this.copyFile1ToolStripMenuItem.Click += new System.EventHandler(this.CopyFile1ToolStripMenuItem_Click);
            // 
            // copyFile2ToolStripMenuItem
            // 
            this.copyFile2ToolStripMenuItem.Name = "copyFile2ToolStripMenuItem";
            this.copyFile2ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.copyFile2ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.copyFile2ToolStripMenuItem.Text = "Copy file2";
            this.copyFile2ToolStripMenuItem.Click += new System.EventHandler(this.CopyFile2ToolStripMenuItem_Click);
            // 
            // copyBookmarks1ToolStripMenuItem
            // 
            this.copyBookmarks1ToolStripMenuItem.Name = "copyBookmarks1ToolStripMenuItem";
            this.copyBookmarks1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.copyBookmarks1ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.copyBookmarks1ToolStripMenuItem.Text = "Copy bookmarks1";
            this.copyBookmarks1ToolStripMenuItem.Click += new System.EventHandler(this.CopyBookmarks1ToolStripMenuItem_Click);
            // 
            // copyBookmarks2ToolStripMenuItem
            // 
            this.copyBookmarks2ToolStripMenuItem.Name = "copyBookmarks2ToolStripMenuItem";
            this.copyBookmarks2ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.copyBookmarks2ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.copyBookmarks2ToolStripMenuItem.Text = "Copy bookmarks2";
            this.copyBookmarks2ToolStripMenuItem.Click += new System.EventHandler(this.CopyBookmarks2ToolStripMenuItem_Click);
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comparePageToolStripMenuItem,
            this.toolStripMenuItem1,
            this.clearMarker1ToolStripMenuItem,
            this.clearMarker2ToolStripMenuItem});
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.compareToolStripMenuItem.Text = "&Compare";
            // 
            // comparePageToolStripMenuItem
            // 
            this.comparePageToolStripMenuItem.Name = "comparePageToolStripMenuItem";
            this.comparePageToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.comparePageToolStripMenuItem.Text = "Compare page";
            this.comparePageToolStripMenuItem.Click += new System.EventHandler(this.ComparePageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(140, 6);
            // 
            // clearMarker1ToolStripMenuItem
            // 
            this.clearMarker1ToolStripMenuItem.Name = "clearMarker1ToolStripMenuItem";
            this.clearMarker1ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.clearMarker1ToolStripMenuItem.Text = "Clear marker1";
            this.clearMarker1ToolStripMenuItem.Click += new System.EventHandler(this.ClearMarker1ToolStripMenuItem_Click);
            // 
            // clearMarker2ToolStripMenuItem
            // 
            this.clearMarker2ToolStripMenuItem.Name = "clearMarker2ToolStripMenuItem";
            this.clearMarker2ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.clearMarker2ToolStripMenuItem.Text = "Clear marker2";
            this.clearMarker2ToolStripMenuItem.Click += new System.EventHandler(this.ClearMarker2ToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutPDFCompToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutPDFCompToolStripMenuItem
            // 
            this.aboutPDFCompToolStripMenuItem.Name = "aboutPDFCompToolStripMenuItem";
            this.aboutPDFCompToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.aboutPDFCompToolStripMenuItem.Text = "About PDFComp";
            this.aboutPDFCompToolStripMenuItem.Click += new System.EventHandler(this.AboutPDFCompToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1192, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panelBoth
            // 
            this.panelBoth.Controls.Add(this.pdfPanel2);
            this.panelBoth.Controls.Add(this.pdfPanel1);
            this.panelBoth.Controls.Add(this.splitter1);
            this.panelBoth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBoth.Location = new System.Drawing.Point(0, 49);
            this.panelBoth.Name = "panelBoth";
            this.panelBoth.Size = new System.Drawing.Size(1192, 724);
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
            this.pdfPanel2.Size = new System.Drawing.Size(575, 724);
            this.pdfPanel2.TabIndex = 2;
            // 
            // pdfPanel1
            // 
            this.pdfPanel1.AllowDrop = true;
            this.pdfPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pdfPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pdfPanel1.Location = new System.Drawing.Point(3, 0);
            this.pdfPanel1.Name = "pdfPanel1";
            this.pdfPanel1.Size = new System.Drawing.Size(495, 724);
            this.pdfPanel1.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 724);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
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
            this.buttonNextPage.Location = new System.Drawing.Point(87, 24);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(69, 23);
            this.buttonNextPage.TabIndex = 8;
            this.buttonNextPage.Text = "> Next";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            this.buttonNextPage.Click += new System.EventHandler(this.ButtonNextPage_Click);
            // 
            // buttonCompare
            // 
            this.buttonCompare.Location = new System.Drawing.Point(513, 24);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(99, 23);
            this.buttonCompare.TabIndex = 12;
            this.buttonCompare.Text = "Compare Page";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.ButtonCompare_Click);
            // 
            // buttonBookmark
            // 
            this.buttonBookmark.Location = new System.Drawing.Point(181, 24);
            this.buttonBookmark.Name = "buttonBookmark";
            this.buttonBookmark.Size = new System.Drawing.Size(75, 23);
            this.buttonBookmark.TabIndex = 9;
            this.buttonBookmark.Text = "Bookmark";
            this.buttonBookmark.UseVisualStyleBackColor = true;
            this.buttonBookmark.Click += new System.EventHandler(this.ButtonBookmark_Click);
            // 
            // buttonRotateLeft
            // 
            this.buttonRotateLeft.Location = new System.Drawing.Point(286, 24);
            this.buttonRotateLeft.Name = "buttonRotateLeft";
            this.buttonRotateLeft.Size = new System.Drawing.Size(52, 23);
            this.buttonRotateLeft.TabIndex = 10;
            this.buttonRotateLeft.Text = "Left";
            this.buttonRotateLeft.UseVisualStyleBackColor = true;
            this.buttonRotateLeft.Click += new System.EventHandler(this.ButtonRotateLeft_Click);
            // 
            // buttonRotateRight
            // 
            this.buttonRotateRight.Location = new System.Drawing.Point(344, 24);
            this.buttonRotateRight.Name = "buttonRotateRight";
            this.buttonRotateRight.Size = new System.Drawing.Size(52, 23);
            this.buttonRotateRight.TabIndex = 11;
            this.buttonRotateRight.Text = "Right";
            this.buttonRotateRight.UseVisualStyleBackColor = true;
            this.buttonRotateRight.Click += new System.EventHandler(this.ButtonRotateRight_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Enabled = false;
            this.textBoxSearch.Location = new System.Drawing.Point(670, 2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(151, 19);
            this.textBoxSearch.TabIndex = 14;
            this.textBoxSearch.Visible = false;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.TextBoxSearch_TextChanged);
            // 
            // buttonSearch1
            // 
            this.buttonSearch1.Enabled = false;
            this.buttonSearch1.Location = new System.Drawing.Point(827, 0);
            this.buttonSearch1.Name = "buttonSearch1";
            this.buttonSearch1.Size = new System.Drawing.Size(26, 23);
            this.buttonSearch1.TabIndex = 15;
            this.buttonSearch1.Text = "Search";
            this.buttonSearch1.UseVisualStyleBackColor = true;
            this.buttonSearch1.Visible = false;
            this.buttonSearch1.Click += new System.EventHandler(this.ButtonSearch1_Click);
            // 
            // buttonSearch2
            // 
            this.buttonSearch2.Enabled = false;
            this.buttonSearch2.Location = new System.Drawing.Point(859, 0);
            this.buttonSearch2.Name = "buttonSearch2";
            this.buttonSearch2.Size = new System.Drawing.Size(26, 23);
            this.buttonSearch2.TabIndex = 16;
            this.buttonSearch2.Text = "Search";
            this.buttonSearch2.UseVisualStyleBackColor = true;
            this.buttonSearch2.Visible = false;
            this.buttonSearch2.Click += new System.EventHandler(this.ButtonSearch2_Click);
            // 
            // labelResult
            // 
            this.labelResult.BackColor = System.Drawing.Color.Transparent;
            this.labelResult.Font = new System.Drawing.Font("MS UI Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelResult.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelResult.Location = new System.Drawing.Point(617, 33);
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
            "Line mode - Efficiency 3",
            "Character mode2"});
            this.comboBoxDiffType.Location = new System.Drawing.Point(649, 26);
            this.comboBoxDiffType.Name = "comboBoxDiffType";
            this.comboBoxDiffType.Size = new System.Drawing.Size(181, 20);
            this.comboBoxDiffType.TabIndex = 13;
            this.comboBoxDiffType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDiffType_SelectedIndexChanged);
            // 
            // radioButtonPan
            // 
            this.radioButtonPan.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonPan.AutoSize = true;
            this.radioButtonPan.Location = new System.Drawing.Point(428, 24);
            this.radioButtonPan.Name = "radioButtonPan";
            this.radioButtonPan.Size = new System.Drawing.Size(34, 22);
            this.radioButtonPan.TabIndex = 18;
            this.radioButtonPan.TabStop = true;
            this.radioButtonPan.Text = "Pan";
            this.radioButtonPan.UseVisualStyleBackColor = true;
            this.radioButtonPan.CheckedChanged += new System.EventHandler(this.RadioButtonPan_CheckedChanged);
            // 
            // radioButtonText
            // 
            this.radioButtonText.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonText.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonText.Location = new System.Drawing.Point(461, 24);
            this.radioButtonText.Name = "radioButtonText";
            this.radioButtonText.Size = new System.Drawing.Size(34, 22);
            this.radioButtonText.TabIndex = 19;
            this.radioButtonText.TabStop = true;
            this.radioButtonText.Text = "T";
            this.radioButtonText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonText.UseVisualStyleBackColor = true;
            this.radioButtonText.CheckedChanged += new System.EventHandler(this.RadioButtonText_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 773);
            this.Controls.Add(this.radioButtonText);
            this.Controls.Add(this.radioButtonPan);
            this.Controls.Add(this.comboBoxDiffType);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonSearch2);
            this.Controls.Add(this.buttonSearch1);
            this.Controls.Add(this.textBoxSearch);
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
            this.Text = "PDFComp";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelBoth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
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
        private System.Windows.Forms.Splitter splitter1;
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
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch1;
        private System.Windows.Forms.Button buttonSearch2;
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
    }
}

