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
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Comparation");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Display");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Others");
            this.treeViewOptions = new System.Windows.Forms.TreeView();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.tabPageComparation = new System.Windows.Forms.TabPage();
            this.checkBoxCompareStyles = new System.Windows.Forms.CheckBox();
            this.groupBoxCompareStyle = new System.Windows.Forms.GroupBox();
            this.chkCompareFillColor = new System.Windows.Forms.CheckBox();
            this.chkCompareStrokeColor = new System.Windows.Forms.CheckBox();
            this.chkCompareUnderlined = new System.Windows.Forms.CheckBox();
            this.chkCompareStrikethrough = new System.Windows.Forms.CheckBox();
            this.chkCompareHighlighted = new System.Windows.Forms.CheckBox();
            this.chkCompareSquiggly = new System.Windows.Forms.CheckBox();
            this.chkCompareAnnotationColor = new System.Windows.Forms.CheckBox();
            this.tabPageDisplay = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.labelBlinkingPeriod = new System.Windows.Forms.Label();
            this.trackBarBlinkingPeriod = new System.Windows.Forms.TrackBar();
            this.checkBoxBlinkingDiffMarker = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageOthers = new System.Windows.Forms.TabPage();
            this.numericUpDownReducedColor = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.labelReduceColorCount = new System.Windows.Forms.Label();
            this.chkCopyBookmarkPage = new System.Windows.Forms.CheckBox();
            this.chkReduceColorCopy = new System.Windows.Forms.CheckBox();
            this.tabControlOptions.SuspendLayout();
            this.tabPageComparation.SuspendLayout();
            this.groupBoxCompareStyle.SuspendLayout();
            this.tabPageDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlinkingPeriod)).BeginInit();
            this.tabPageOthers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReducedColor)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewOptions
            // 
            this.treeViewOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewOptions.HideSelection = false;
            this.treeViewOptions.ItemHeight = 20;
            this.treeViewOptions.Location = new System.Drawing.Point(12, 12);
            this.treeViewOptions.Name = "treeViewOptions";
            treeNode16.Name = "";
            treeNode16.Text = "Comparation";
            treeNode17.Name = "";
            treeNode17.Text = "Display";
            treeNode18.Name = "";
            treeNode18.Text = "Others";
            this.treeViewOptions.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18});
            this.treeViewOptions.Size = new System.Drawing.Size(151, 260);
            this.treeViewOptions.TabIndex = 0;
            this.treeViewOptions.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewOptions_AfterSelect);
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(320, 282);
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
            this.buttonCancel.Location = new System.Drawing.Point(401, 282);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Controls.Add(this.tabPageComparation);
            this.tabControlOptions.Controls.Add(this.tabPageDisplay);
            this.tabControlOptions.Controls.Add(this.tabPageOthers);
            this.tabControlOptions.Location = new System.Drawing.Point(181, 3);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(362, 269);
            this.tabControlOptions.TabIndex = 7;
            // 
            // tabPageComparation
            // 
            this.tabPageComparation.Controls.Add(this.checkBoxCompareStyles);
            this.tabPageComparation.Controls.Add(this.groupBoxCompareStyle);
            this.tabPageComparation.Location = new System.Drawing.Point(4, 24);
            this.tabPageComparation.Name = "tabPageComparation";
            this.tabPageComparation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageComparation.Size = new System.Drawing.Size(354, 241);
            this.tabPageComparation.TabIndex = 0;
            this.tabPageComparation.Text = "tabPage1";
            this.tabPageComparation.UseVisualStyleBackColor = true;
            // 
            // checkBoxCompareStyles
            // 
            this.checkBoxCompareStyles.AutoSize = true;
            this.checkBoxCompareStyles.Checked = true;
            this.checkBoxCompareStyles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCompareStyles.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCompareStyles.Location = new System.Drawing.Point(4, 11);
            this.checkBoxCompareStyles.Name = "checkBoxCompareStyles";
            this.checkBoxCompareStyles.Size = new System.Drawing.Size(118, 21);
            this.checkBoxCompareStyles.TabIndex = 16;
            this.checkBoxCompareStyles.Text = "Compare Styles";
            this.checkBoxCompareStyles.UseVisualStyleBackColor = true;
            this.checkBoxCompareStyles.CheckedChanged += new System.EventHandler(this.CheckBoxCompareStyles_CheckedChanged);
            // 
            // groupBoxCompareStyle
            // 
            this.groupBoxCompareStyle.Controls.Add(this.chkCompareFillColor);
            this.groupBoxCompareStyle.Controls.Add(this.chkCompareStrokeColor);
            this.groupBoxCompareStyle.Controls.Add(this.chkCompareUnderlined);
            this.groupBoxCompareStyle.Controls.Add(this.chkCompareStrikethrough);
            this.groupBoxCompareStyle.Controls.Add(this.chkCompareHighlighted);
            this.groupBoxCompareStyle.Controls.Add(this.chkCompareSquiggly);
            this.groupBoxCompareStyle.Controls.Add(this.chkCompareAnnotationColor);
            this.groupBoxCompareStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCompareStyle.Location = new System.Drawing.Point(12, 15);
            this.groupBoxCompareStyle.Name = "groupBoxCompareStyle";
            this.groupBoxCompareStyle.Size = new System.Drawing.Size(279, 189);
            this.groupBoxCompareStyle.TabIndex = 15;
            this.groupBoxCompareStyle.TabStop = false;
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
            this.chkCompareAnnotationColor.Enabled = false;
            this.chkCompareAnnotationColor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompareAnnotationColor.Location = new System.Drawing.Point(14, 153);
            this.chkCompareAnnotationColor.Name = "chkCompareAnnotationColor";
            this.chkCompareAnnotationColor.Size = new System.Drawing.Size(118, 19);
            this.chkCompareAnnotationColor.TabIndex = 6;
            this.chkCompareAnnotationColor.Text = "Annotation Color";
            this.chkCompareAnnotationColor.UseVisualStyleBackColor = true;
            // 
            // tabPageDisplay
            // 
            this.tabPageDisplay.Controls.Add(this.label3);
            this.tabPageDisplay.Controls.Add(this.labelBlinkingPeriod);
            this.tabPageDisplay.Controls.Add(this.trackBarBlinkingPeriod);
            this.tabPageDisplay.Controls.Add(this.checkBoxBlinkingDiffMarker);
            this.tabPageDisplay.Controls.Add(this.label2);
            this.tabPageDisplay.Location = new System.Drawing.Point(4, 24);
            this.tabPageDisplay.Name = "tabPageDisplay";
            this.tabPageDisplay.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDisplay.Size = new System.Drawing.Size(354, 241);
            this.tabPageDisplay.TabIndex = 1;
            this.tabPageDisplay.Text = "tabPage2";
            this.tabPageDisplay.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(32, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Blinking Period : ";
            // 
            // labelBlinkingPeriod
            // 
            this.labelBlinkingPeriod.Location = new System.Drawing.Point(123, 69);
            this.labelBlinkingPeriod.Name = "labelBlinkingPeriod";
            this.labelBlinkingPeriod.Size = new System.Drawing.Size(56, 19);
            this.labelBlinkingPeriod.TabIndex = 16;
            this.labelBlinkingPeriod.Text = "label3";
            this.labelBlinkingPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackBarBlinkingPeriod
            // 
            this.trackBarBlinkingPeriod.Location = new System.Drawing.Point(181, 60);
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
            this.checkBoxBlinkingDiffMarker.Location = new System.Drawing.Point(24, 40);
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
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Diff Marker Behavior\n";
            // 
            // tabPageOthers
            // 
            this.tabPageOthers.Controls.Add(this.numericUpDownReducedColor);
            this.tabPageOthers.Controls.Add(this.label1);
            this.tabPageOthers.Controls.Add(this.labelReduceColorCount);
            this.tabPageOthers.Controls.Add(this.chkCopyBookmarkPage);
            this.tabPageOthers.Controls.Add(this.chkReduceColorCopy);
            this.tabPageOthers.Location = new System.Drawing.Point(4, 24);
            this.tabPageOthers.Name = "tabPageOthers";
            this.tabPageOthers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOthers.Size = new System.Drawing.Size(354, 241);
            this.tabPageOthers.TabIndex = 2;
            this.tabPageOthers.Text = "tabPage3";
            this.tabPageOthers.UseVisualStyleBackColor = true;
            // 
            // numericUpDownReducedColor
            // 
            this.numericUpDownReducedColor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownReducedColor.Location = new System.Drawing.Point(187, 60);
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
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Copy Behavior\n";
            // 
            // labelReduceColorCount
            // 
            this.labelReduceColorCount.AutoSize = true;
            this.labelReduceColorCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReduceColorCount.Location = new System.Drawing.Point(48, 63);
            this.labelReduceColorCount.Name = "labelReduceColorCount";
            this.labelReduceColorCount.Size = new System.Drawing.Size(130, 15);
            this.labelReduceColorCount.TabIndex = 13;
            this.labelReduceColorCount.Text = "Reduced Color Count:  ";
            // 
            // chkCopyBookmarkPage
            // 
            this.chkCopyBookmarkPage.AutoSize = true;
            this.chkCopyBookmarkPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCopyBookmarkPage.Location = new System.Drawing.Point(24, 91);
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
            this.chkReduceColorCopy.Location = new System.Drawing.Point(24, 40);
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
            this.ClientSize = new System.Drawing.Size(588, 312);
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
            this.tabPageComparation.ResumeLayout(false);
            this.tabPageComparation.PerformLayout();
            this.groupBoxCompareStyle.ResumeLayout(false);
            this.groupBoxCompareStyle.PerformLayout();
            this.tabPageDisplay.ResumeLayout(false);
            this.tabPageDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlinkingPeriod)).EndInit();
            this.tabPageOthers.ResumeLayout(false);
            this.tabPageOthers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReducedColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewOptions;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabControl tabControlOptions;
        private System.Windows.Forms.TabPage tabPageComparation;
        private System.Windows.Forms.TabPage tabPageDisplay;
        private System.Windows.Forms.TabPage tabPageOthers;
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
    }
}
