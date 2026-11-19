namespace PDFComp
{
    partial class FormOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Text Styling");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Spaces & Breaks");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Display Setting");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Others");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptions));
            this.treeViewOptions = new System.Windows.Forms.TreeView();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.tabPageStyles = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxCompareStyles = new System.Windows.Forms.CheckBox();
            this.groupBoxCompareStyle = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkCompareFillColor = new System.Windows.Forms.CheckBox();
            this.chkCompareStrokeColor = new System.Windows.Forms.CheckBox();
            this.chkCompareUnderlined = new System.Windows.Forms.CheckBox();
            this.chkCompareStrikethrough = new System.Windows.Forms.CheckBox();
            this.chkCompareHighlighted = new System.Windows.Forms.CheckBox();
            this.chkCompareSquiggly = new System.Windows.Forms.CheckBox();
            this.chkCompareAnnotationColor = new System.Windows.Forms.CheckBox();
            this.tabPageWs = new System.Windows.Forms.TabPage();
            this.labelWsWarning = new System.Windows.Forms.Label();
            this.groupBoxIgnoreWsDetail = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxWsSpace = new System.Windows.Forms.CheckBox();
            this.checkBoxWsTab = new System.Windows.Forms.CheckBox();
            this.checkBoxWsBreaks = new System.Windows.Forms.CheckBox();
            this.checkBoxWsFullWidthSpace = new System.Windows.Forms.CheckBox();
            this.checkBoxWsOthers = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxIgnoreWsOnly = new System.Windows.Forms.CheckBox();
            this.tabPageDisplay = new System.Windows.Forms.TabPage();
            this.comboBoxBoundsFallback = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelBlinkingPeriod = new System.Windows.Forms.Label();
            this.trackBarBlinkingPeriod = new System.Windows.Forms.TrackBar();
            this.checkBoxBlinkingDiffMarker = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageOthers = new System.Windows.Forms.TabPage();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.numericUpDownReducedColor = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.labelReduceColorCount = new System.Windows.Forms.Label();
            this.chkCopyBookmarkPage = new System.Windows.Forms.CheckBox();
            this.chkReduceColorCopy = new System.Windows.Forms.CheckBox();
            this.toolTipBoundsFallback = new System.Windows.Forms.ToolTip(this.components);
            this.tabControlOptions.SuspendLayout();
            this.tabPageStyles.SuspendLayout();
            this.groupBoxCompareStyle.SuspendLayout();
            this.tabPageWs.SuspendLayout();
            this.groupBoxIgnoreWsDetail.SuspendLayout();
            this.tabPageDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlinkingPeriod)).BeginInit();
            this.tabPageOthers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReducedColor)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewOptions
            // 
            this.treeViewOptions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewOptions.HideSelection = false;
            this.treeViewOptions.ItemHeight = 20;
            this.treeViewOptions.Location = new System.Drawing.Point(12, 12);
            this.treeViewOptions.Name = "treeViewOptions";
            treeNode1.Name = "";
            treeNode1.Text = "Text Styling";
            treeNode2.Name = "";
            treeNode2.Text = "Spaces & Breaks";
            treeNode3.Name = "";
            treeNode3.Text = "Display Setting";
            treeNode4.Name = "";
            treeNode4.Text = "Others";
            this.treeViewOptions.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.treeViewOptions.Size = new System.Drawing.Size(151, 260);
            this.treeViewOptions.TabIndex = 0;
            this.treeViewOptions.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewOptions_AfterSelect);
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(374, 278);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(455, 278);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Controls.Add(this.tabPageStyles);
            this.tabControlOptions.Controls.Add(this.tabPageWs);
            this.tabControlOptions.Controls.Add(this.tabPageDisplay);
            this.tabControlOptions.Controls.Add(this.tabPageOthers);
            this.tabControlOptions.Location = new System.Drawing.Point(169, 3);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(374, 269);
            this.tabControlOptions.TabIndex = 7;
            // 
            // tabPageStyles
            // 
            this.tabPageStyles.Controls.Add(this.label8);
            this.tabPageStyles.Controls.Add(this.label7);
            this.tabPageStyles.Controls.Add(this.checkBoxCompareStyles);
            this.tabPageStyles.Controls.Add(this.groupBoxCompareStyle);
            this.tabPageStyles.Location = new System.Drawing.Point(4, 24);
            this.tabPageStyles.Name = "tabPageStyles";
            this.tabPageStyles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStyles.Size = new System.Drawing.Size(366, 241);
            this.tabPageStyles.TabIndex = 0;
            this.tabPageStyles.Text = "tabStyles";
            this.tabPageStyles.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(200, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "- Experimental";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Compare Styles";
            // 
            // checkBoxCompareStyles
            // 
            this.checkBoxCompareStyles.AutoSize = true;
            this.checkBoxCompareStyles.Checked = true;
            this.checkBoxCompareStyles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCompareStyles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCompareStyles.Location = new System.Drawing.Point(24, 33);
            this.checkBoxCompareStyles.Name = "checkBoxCompareStyles";
            this.checkBoxCompareStyles.Size = new System.Drawing.Size(179, 19);
            this.checkBoxCompareStyles.TabIndex = 16;
            this.checkBoxCompareStyles.Text = "Compare with font attributes";
            this.checkBoxCompareStyles.UseVisualStyleBackColor = true;
            this.checkBoxCompareStyles.CheckedChanged += new System.EventHandler(this.CheckBoxCompareStyles_CheckedChanged);
            // 
            // groupBoxCompareStyle
            // 
            this.groupBoxCompareStyle.Controls.Add(this.label11);
            this.groupBoxCompareStyle.Controls.Add(this.label10);
            this.groupBoxCompareStyle.Controls.Add(this.label9);
            this.groupBoxCompareStyle.Controls.Add(this.label5);
            this.groupBoxCompareStyle.Controls.Add(this.chkCompareFillColor);
            this.groupBoxCompareStyle.Controls.Add(this.chkCompareStrokeColor);
            this.groupBoxCompareStyle.Controls.Add(this.chkCompareUnderlined);
            this.groupBoxCompareStyle.Controls.Add(this.chkCompareStrikethrough);
            this.groupBoxCompareStyle.Controls.Add(this.chkCompareHighlighted);
            this.groupBoxCompareStyle.Controls.Add(this.chkCompareSquiggly);
            this.groupBoxCompareStyle.Controls.Add(this.chkCompareAnnotationColor);
            this.groupBoxCompareStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCompareStyle.Location = new System.Drawing.Point(24, 55);
            this.groupBoxCompareStyle.Name = "groupBoxCompareStyle";
            this.groupBoxCompareStyle.Size = new System.Drawing.Size(333, 179);
            this.groupBoxCompareStyle.TabIndex = 15;
            this.groupBoxCompareStyle.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(128, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(186, 15);
            this.label11.TabIndex = 11;
            this.label11.Text = "-  Color comparison varies by PDF.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(128, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(186, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "-  Color comparison varies by PDF.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(128, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "-  For selected annotations.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Details";
            // 
            // chkCompareFillColor
            // 
            this.chkCompareFillColor.AutoSize = true;
            this.chkCompareFillColor.Checked = true;
            this.chkCompareFillColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCompareFillColor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompareFillColor.Location = new System.Drawing.Point(14, 21);
            this.chkCompareFillColor.Name = "chkCompareFillColor";
            this.chkCompareFillColor.Size = new System.Drawing.Size(79, 19);
            this.chkCompareFillColor.TabIndex = 0;
            this.chkCompareFillColor.Text = "Text Color";
            this.chkCompareFillColor.UseVisualStyleBackColor = true;
            // 
            // chkCompareStrokeColor
            // 
            this.chkCompareStrokeColor.AutoSize = true;
            this.chkCompareStrokeColor.Checked = true;
            this.chkCompareStrokeColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCompareStrokeColor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompareStrokeColor.Location = new System.Drawing.Point(14, 43);
            this.chkCompareStrokeColor.Name = "chkCompareStrokeColor";
            this.chkCompareStrokeColor.Size = new System.Drawing.Size(97, 19);
            this.chkCompareStrokeColor.TabIndex = 1;
            this.chkCompareStrokeColor.Text = "Outline Color";
            this.chkCompareStrokeColor.UseVisualStyleBackColor = true;
            // 
            // chkCompareUnderlined
            // 
            this.chkCompareUnderlined.AutoSize = true;
            this.chkCompareUnderlined.Checked = true;
            this.chkCompareUnderlined.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCompareUnderlined.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompareUnderlined.Location = new System.Drawing.Point(14, 87);
            this.chkCompareUnderlined.Name = "chkCompareUnderlined";
            this.chkCompareUnderlined.Size = new System.Drawing.Size(77, 19);
            this.chkCompareUnderlined.TabIndex = 2;
            this.chkCompareUnderlined.Text = "Underline";
            this.chkCompareUnderlined.UseVisualStyleBackColor = true;
            // 
            // chkCompareStrikethrough
            // 
            this.chkCompareStrikethrough.AutoSize = true;
            this.chkCompareStrikethrough.Checked = true;
            this.chkCompareStrikethrough.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCompareStrikethrough.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompareStrikethrough.Location = new System.Drawing.Point(14, 65);
            this.chkCompareStrikethrough.Name = "chkCompareStrikethrough";
            this.chkCompareStrikethrough.Size = new System.Drawing.Size(98, 19);
            this.chkCompareStrikethrough.TabIndex = 3;
            this.chkCompareStrikethrough.Text = "Strikethrough";
            this.chkCompareStrikethrough.UseVisualStyleBackColor = true;
            // 
            // chkCompareHighlighted
            // 
            this.chkCompareHighlighted.AutoSize = true;
            this.chkCompareHighlighted.Checked = true;
            this.chkCompareHighlighted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCompareHighlighted.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompareHighlighted.Location = new System.Drawing.Point(14, 131);
            this.chkCompareHighlighted.Name = "chkCompareHighlighted";
            this.chkCompareHighlighted.Size = new System.Drawing.Size(76, 19);
            this.chkCompareHighlighted.TabIndex = 4;
            this.chkCompareHighlighted.Text = "Highlight";
            this.chkCompareHighlighted.UseVisualStyleBackColor = true;
            // 
            // chkCompareSquiggly
            // 
            this.chkCompareSquiggly.AutoSize = true;
            this.chkCompareSquiggly.Checked = true;
            this.chkCompareSquiggly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCompareSquiggly.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompareSquiggly.Location = new System.Drawing.Point(14, 109);
            this.chkCompareSquiggly.Name = "chkCompareSquiggly";
            this.chkCompareSquiggly.Size = new System.Drawing.Size(72, 19);
            this.chkCompareSquiggly.TabIndex = 5;
            this.chkCompareSquiggly.Text = "Squiggly";
            this.chkCompareSquiggly.UseVisualStyleBackColor = true;
            // 
            // chkCompareAnnotationColor
            // 
            this.chkCompareAnnotationColor.AutoSize = true;
            this.chkCompareAnnotationColor.Checked = true;
            this.chkCompareAnnotationColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCompareAnnotationColor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompareAnnotationColor.Location = new System.Drawing.Point(14, 153);
            this.chkCompareAnnotationColor.Name = "chkCompareAnnotationColor";
            this.chkCompareAnnotationColor.Size = new System.Drawing.Size(118, 19);
            this.chkCompareAnnotationColor.TabIndex = 6;
            this.chkCompareAnnotationColor.Text = "Annotation Color";
            this.chkCompareAnnotationColor.UseVisualStyleBackColor = true;
            // 
            // tabPageWs
            // 
            this.tabPageWs.Controls.Add(this.labelWsWarning);
            this.tabPageWs.Controls.Add(this.groupBoxIgnoreWsDetail);
            this.tabPageWs.Controls.Add(this.label4);
            this.tabPageWs.Controls.Add(this.checkBoxIgnoreWsOnly);
            this.tabPageWs.Location = new System.Drawing.Point(4, 22);
            this.tabPageWs.Name = "tabPageWs";
            this.tabPageWs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWs.Size = new System.Drawing.Size(366, 243);
            this.tabPageWs.TabIndex = 3;
            this.tabPageWs.Text = "tabWsBreaks";
            this.tabPageWs.UseVisualStyleBackColor = true;
            // 
            // labelWsWarning
            // 
            this.labelWsWarning.AutoSize = true;
            this.labelWsWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWsWarning.Location = new System.Drawing.Point(48, 203);
            this.labelWsWarning.Name = "labelWsWarning";
            this.labelWsWarning.Size = new System.Drawing.Size(199, 15);
            this.labelWsWarning.TabIndex = 17;
            this.labelWsWarning.Text = "No characters are selected to ignore.";
            // 
            // groupBoxIgnoreWsDetail
            // 
            this.groupBoxIgnoreWsDetail.Controls.Add(this.label6);
            this.groupBoxIgnoreWsDetail.Controls.Add(this.checkBoxWsSpace);
            this.groupBoxIgnoreWsDetail.Controls.Add(this.checkBoxWsTab);
            this.groupBoxIgnoreWsDetail.Controls.Add(this.checkBoxWsBreaks);
            this.groupBoxIgnoreWsDetail.Controls.Add(this.checkBoxWsFullWidthSpace);
            this.groupBoxIgnoreWsDetail.Controls.Add(this.checkBoxWsOthers);
            this.groupBoxIgnoreWsDetail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxIgnoreWsDetail.Location = new System.Drawing.Point(24, 55);
            this.groupBoxIgnoreWsDetail.Name = "groupBoxIgnoreWsDetail";
            this.groupBoxIgnoreWsDetail.Size = new System.Drawing.Size(292, 145);
            this.groupBoxIgnoreWsDetail.TabIndex = 16;
            this.groupBoxIgnoreWsDetail.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Details";
            // 
            // checkBoxWsSpace
            // 
            this.checkBoxWsSpace.AutoSize = true;
            this.checkBoxWsSpace.Checked = true;
            this.checkBoxWsSpace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWsSpace.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxWsSpace.Location = new System.Drawing.Point(14, 21);
            this.checkBoxWsSpace.Name = "checkBoxWsSpace";
            this.checkBoxWsSpace.Size = new System.Drawing.Size(251, 19);
            this.checkBoxWsSpace.TabIndex = 0;
            this.checkBoxWsSpace.Text = "Space  - Selecting Space is usually enough.";
            this.checkBoxWsSpace.UseVisualStyleBackColor = true;
            this.checkBoxWsSpace.CheckedChanged += new System.EventHandler(this.checkBoxWs_CheckedChanged);
            // 
            // checkBoxWsTab
            // 
            this.checkBoxWsTab.AutoSize = true;
            this.checkBoxWsTab.Checked = true;
            this.checkBoxWsTab.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWsTab.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxWsTab.Location = new System.Drawing.Point(14, 43);
            this.checkBoxWsTab.Name = "checkBoxWsTab";
            this.checkBoxWsTab.Size = new System.Drawing.Size(45, 19);
            this.checkBoxWsTab.TabIndex = 1;
            this.checkBoxWsTab.Text = "Tab";
            this.checkBoxWsTab.UseVisualStyleBackColor = true;
            this.checkBoxWsTab.CheckedChanged += new System.EventHandler(this.checkBoxWs_CheckedChanged);
            // 
            // checkBoxWsBreaks
            // 
            this.checkBoxWsBreaks.AutoSize = true;
            this.checkBoxWsBreaks.Checked = true;
            this.checkBoxWsBreaks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWsBreaks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxWsBreaks.Location = new System.Drawing.Point(14, 65);
            this.checkBoxWsBreaks.Name = "checkBoxWsBreaks";
            this.checkBoxWsBreaks.Size = new System.Drawing.Size(85, 19);
            this.checkBoxWsBreaks.TabIndex = 3;
            this.checkBoxWsBreaks.Text = "Line Breaks";
            this.checkBoxWsBreaks.UseVisualStyleBackColor = true;
            this.checkBoxWsBreaks.CheckedChanged += new System.EventHandler(this.checkBoxWs_CheckedChanged);
            // 
            // checkBoxWsFullWidthSpace
            // 
            this.checkBoxWsFullWidthSpace.AutoSize = true;
            this.checkBoxWsFullWidthSpace.Checked = true;
            this.checkBoxWsFullWidthSpace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWsFullWidthSpace.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxWsFullWidthSpace.Location = new System.Drawing.Point(14, 87);
            this.checkBoxWsFullWidthSpace.Name = "checkBoxWsFullWidthSpace";
            this.checkBoxWsFullWidthSpace.Size = new System.Drawing.Size(114, 19);
            this.checkBoxWsFullWidthSpace.TabIndex = 2;
            this.checkBoxWsFullWidthSpace.Text = "Full-width Space";
            this.checkBoxWsFullWidthSpace.UseVisualStyleBackColor = true;
            this.checkBoxWsFullWidthSpace.CheckedChanged += new System.EventHandler(this.checkBoxWs_CheckedChanged);
            // 
            // checkBoxWsOthers
            // 
            this.checkBoxWsOthers.AutoSize = true;
            this.checkBoxWsOthers.Checked = true;
            this.checkBoxWsOthers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWsOthers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxWsOthers.Location = new System.Drawing.Point(14, 109);
            this.checkBoxWsOthers.Name = "checkBoxWsOthers";
            this.checkBoxWsOthers.Size = new System.Drawing.Size(179, 19);
            this.checkBoxWsOthers.TabIndex = 5;
            this.checkBoxWsOthers.Text = "Other Whitespace Characters";
            this.checkBoxWsOthers.UseVisualStyleBackColor = true;
            this.checkBoxWsOthers.CheckedChanged += new System.EventHandler(this.checkBoxWs_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Ignore Differences";
            // 
            // checkBoxIgnoreWsOnly
            // 
            this.checkBoxIgnoreWsOnly.AutoSize = true;
            this.checkBoxIgnoreWsOnly.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIgnoreWsOnly.Location = new System.Drawing.Point(24, 33);
            this.checkBoxIgnoreWsOnly.Name = "checkBoxIgnoreWsOnly";
            this.checkBoxIgnoreWsOnly.Size = new System.Drawing.Size(211, 19);
            this.checkBoxIgnoreWsOnly.TabIndex = 13;
            this.checkBoxIgnoreWsOnly.Text = "Ignore whitespace-only differences";
            this.checkBoxIgnoreWsOnly.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreWsOnly.CheckedChanged += new System.EventHandler(this.checkBoxIgnoreWsOnly_CheckedChanged);
            // 
            // tabPageDisplay
            // 
            this.tabPageDisplay.Controls.Add(this.comboBoxBoundsFallback);
            this.tabPageDisplay.Controls.Add(this.label12);
            this.tabPageDisplay.Controls.Add(this.label3);
            this.tabPageDisplay.Controls.Add(this.labelBlinkingPeriod);
            this.tabPageDisplay.Controls.Add(this.trackBarBlinkingPeriod);
            this.tabPageDisplay.Controls.Add(this.checkBoxBlinkingDiffMarker);
            this.tabPageDisplay.Controls.Add(this.label2);
            this.tabPageDisplay.Location = new System.Drawing.Point(4, 22);
            this.tabPageDisplay.Name = "tabPageDisplay";
            this.tabPageDisplay.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDisplay.Size = new System.Drawing.Size(366, 243);
            this.tabPageDisplay.TabIndex = 1;
            this.tabPageDisplay.Text = "tabDisplay";
            this.tabPageDisplay.UseVisualStyleBackColor = true;
            // 
            // comboBoxBoundsFallback
            // 
            this.comboBoxBoundsFallback.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBoundsFallback.FormattingEnabled = true;
            this.comboBoxBoundsFallback.Items.AddRange(new object[] {
            "Do Not Rotate",
            "Rotate Right",
            "Rotate Left"});
            this.comboBoxBoundsFallback.Location = new System.Drawing.Point(24, 134);
            this.comboBoxBoundsFallback.Name = "comboBoxBoundsFallback";
            this.comboBoxBoundsFallback.Size = new System.Drawing.Size(189, 23);
            this.comboBoxBoundsFallback.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(141, 15);
            this.label12.TabIndex = 18;
            this.label12.Text = "Bounds Rotation Fallback\n";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(31, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Blinking Period : ";
            // 
            // labelBlinkingPeriod
            // 
            this.labelBlinkingPeriod.Location = new System.Drawing.Point(120, 59);
            this.labelBlinkingPeriod.Name = "labelBlinkingPeriod";
            this.labelBlinkingPeriod.Size = new System.Drawing.Size(56, 19);
            this.labelBlinkingPeriod.TabIndex = 16;
            this.labelBlinkingPeriod.Text = "label3";
            this.labelBlinkingPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackBarBlinkingPeriod
            // 
            this.trackBarBlinkingPeriod.Location = new System.Drawing.Point(181, 50);
            this.trackBarBlinkingPeriod.Maximum = 50;
            this.trackBarBlinkingPeriod.Minimum = 2;
            this.trackBarBlinkingPeriod.Name = "trackBarBlinkingPeriod";
            this.trackBarBlinkingPeriod.Size = new System.Drawing.Size(168, 45);
            this.trackBarBlinkingPeriod.TabIndex = 15;
            this.trackBarBlinkingPeriod.TickFrequency = 2;
            this.trackBarBlinkingPeriod.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarBlinkingPeriod.Value = 10;
            this.trackBarBlinkingPeriod.ValueChanged += new System.EventHandler(this.trackBarBlinkingPeriod_ValueChanged);
            // 
            // checkBoxBlinkingDiffMarker
            // 
            this.checkBoxBlinkingDiffMarker.AutoSize = true;
            this.checkBoxBlinkingDiffMarker.Location = new System.Drawing.Point(24, 33);
            this.checkBoxBlinkingDiffMarker.Name = "checkBoxBlinkingDiffMarker";
            this.checkBoxBlinkingDiffMarker.Size = new System.Drawing.Size(152, 19);
            this.checkBoxBlinkingDiffMarker.TabIndex = 14;
            this.checkBoxBlinkingDiffMarker.Text = "Use blinking diff marker";
            this.checkBoxBlinkingDiffMarker.UseVisualStyleBackColor = true;
            this.checkBoxBlinkingDiffMarker.CheckedChanged += new System.EventHandler(this.checkBoxBlinkDiffMarker_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Diff Marker Behavior\n";
            // 
            // tabPageOthers
            // 
            this.tabPageOthers.BackColor = System.Drawing.Color.Transparent;
            this.tabPageOthers.Controls.Add(this.labelLanguage);
            this.tabPageOthers.Controls.Add(this.pictureBox1);
            this.tabPageOthers.Controls.Add(this.comboBoxLanguage);
            this.tabPageOthers.Controls.Add(this.numericUpDownReducedColor);
            this.tabPageOthers.Controls.Add(this.label1);
            this.tabPageOthers.Controls.Add(this.labelReduceColorCount);
            this.tabPageOthers.Controls.Add(this.chkCopyBookmarkPage);
            this.tabPageOthers.Controls.Add(this.chkReduceColorCopy);
            this.tabPageOthers.Location = new System.Drawing.Point(4, 24);
            this.tabPageOthers.Name = "tabPageOthers";
            this.tabPageOthers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOthers.Size = new System.Drawing.Size(366, 241);
            this.tabPageOthers.TabIndex = 2;
            this.tabPageOthers.Text = "tabOthers";
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(31, 138);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(97, 15);
            this.labelLanguage.TabIndex = 19;
            this.labelLanguage.Text = "Display language";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 136);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(24, 168);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(284, 23);
            this.comboBoxLanguage.TabIndex = 20;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.Language_SelectedIndexChanged);
            // 
            // numericUpDownReducedColor
            // 
            this.numericUpDownReducedColor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownReducedColor.Location = new System.Drawing.Point(188, 58);
            this.numericUpDownReducedColor.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownReducedColor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownReducedColor.Name = "numericUpDownReducedColor";
            this.numericUpDownReducedColor.Size = new System.Drawing.Size(55, 23);
            this.numericUpDownReducedColor.TabIndex = 14;
            this.numericUpDownReducedColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownReducedColor.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Copy Behavior\n";
            // 
            // labelReduceColorCount
            // 
            this.labelReduceColorCount.AutoSize = true;
            this.labelReduceColorCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReduceColorCount.Location = new System.Drawing.Point(31, 61);
            this.labelReduceColorCount.Name = "labelReduceColorCount";
            this.labelReduceColorCount.Size = new System.Drawing.Size(130, 15);
            this.labelReduceColorCount.TabIndex = 13;
            this.labelReduceColorCount.Text = "Reduced Color Count:  ";
            // 
            // chkCopyBookmarkPage
            // 
            this.chkCopyBookmarkPage.AutoSize = true;
            this.chkCopyBookmarkPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCopyBookmarkPage.Location = new System.Drawing.Point(24, 87);
            this.chkCopyBookmarkPage.Name = "chkCopyBookmarkPage";
            this.chkCopyBookmarkPage.Size = new System.Drawing.Size(284, 19);
            this.chkCopyBookmarkPage.TabIndex = 11;
            this.chkCopyBookmarkPage.Text = "Include page numbers when copying bookmarks";
            this.chkCopyBookmarkPage.UseVisualStyleBackColor = true;
            // 
            // chkReduceColorCopy
            // 
            this.chkReduceColorCopy.AutoSize = true;
            this.chkReduceColorCopy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReduceColorCopy.Location = new System.Drawing.Point(24, 33);
            this.chkReduceColorCopy.Name = "chkReduceColorCopy";
            this.chkReduceColorCopy.Size = new System.Drawing.Size(219, 19);
            this.chkReduceColorCopy.TabIndex = 10;
            this.chkReduceColorCopy.Text = "Reduce colors when copying images";
            this.chkReduceColorCopy.UseVisualStyleBackColor = true;
            this.chkReduceColorCopy.CheckedChanged += new System.EventHandler(this.ChkReduceColorCopy_CheckedChanged);
            // 
            // FormOptions
            // 
            this.AcceptButton = this.buttonOK;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(552, 312);
            this.Controls.Add(this.tabControlOptions);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.treeViewOptions);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Shown += new System.EventHandler(this.FormOptions_Shown);
            this.tabControlOptions.ResumeLayout(false);
            this.tabPageStyles.ResumeLayout(false);
            this.tabPageStyles.PerformLayout();
            this.groupBoxCompareStyle.ResumeLayout(false);
            this.groupBoxCompareStyle.PerformLayout();
            this.tabPageWs.ResumeLayout(false);
            this.tabPageWs.PerformLayout();
            this.groupBoxIgnoreWsDetail.ResumeLayout(false);
            this.groupBoxIgnoreWsDetail.PerformLayout();
            this.tabPageDisplay.ResumeLayout(false);
            this.tabPageDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlinkingPeriod)).EndInit();
            this.tabPageOthers.ResumeLayout(false);
            this.tabPageOthers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReducedColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewOptions;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabControl tabControlOptions;
        private System.Windows.Forms.TabPage tabPageStyles;
        private System.Windows.Forms.TabPage tabPageDisplay;
        private System.Windows.Forms.TabPage tabPageOthers;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.NumericUpDown numericUpDownReducedColor;
        private System.Windows.Forms.Label labelReduceColorCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkReduceColorCopy;
        private System.Windows.Forms.CheckBox chkCopyBookmarkPage;
        private System.Windows.Forms.CheckBox checkBoxCompareStyles;
        private System.Windows.Forms.GroupBox groupBoxCompareStyle;
        private System.Windows.Forms.CheckBox chkCompareFillColor;
        private System.Windows.Forms.CheckBox chkCompareStrokeColor;
        private System.Windows.Forms.CheckBox chkCompareUnderlined;
        private System.Windows.Forms.CheckBox chkCompareStrikethrough;
        private System.Windows.Forms.CheckBox chkCompareHighlighted;
        private System.Windows.Forms.CheckBox chkCompareSquiggly;
        private System.Windows.Forms.CheckBox chkCompareAnnotationColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxBlinkingDiffMarker;
        private System.Windows.Forms.TrackBar trackBarBlinkingPeriod;
        private System.Windows.Forms.Label labelBlinkingPeriod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPageWs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxIgnoreWsOnly;
        private System.Windows.Forms.GroupBox groupBoxIgnoreWsDetail;
        private System.Windows.Forms.CheckBox checkBoxWsSpace;
        private System.Windows.Forms.CheckBox checkBoxWsTab;
        private System.Windows.Forms.CheckBox checkBoxWsBreaks;
        private System.Windows.Forms.CheckBox checkBoxWsFullWidthSpace;
        private System.Windows.Forms.CheckBox checkBoxWsOthers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelWsWarning;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxBoundsFallback;
        private System.Windows.Forms.ToolTip toolTipBoundsFallback;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelLanguage;
    }
}
