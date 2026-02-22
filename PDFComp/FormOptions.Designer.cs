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
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Comparation");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Display");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Others");
            this.treeViewOptions = new System.Windows.Forms.TreeView();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelCompare = new System.Windows.Forms.Panel();
            this.checkBoxCompareStyles = new System.Windows.Forms.CheckBox();
            this.groupBoxCompareStyle = new System.Windows.Forms.GroupBox();
            this.chkCompareFillColor = new System.Windows.Forms.CheckBox();
            this.chkCompareStrokeColor = new System.Windows.Forms.CheckBox();
            this.chkCompareUnderlined = new System.Windows.Forms.CheckBox();
            this.chkCompareStrikethrough = new System.Windows.Forms.CheckBox();
            this.chkCompareHighlighted = new System.Windows.Forms.CheckBox();
            this.chkCompareSquiggly = new System.Windows.Forms.CheckBox();
            this.chkCompareAnnotationColor = new System.Windows.Forms.CheckBox();
            this.panelDisplay = new System.Windows.Forms.Panel();
            this.labelDisp = new System.Windows.Forms.Label();
            this.panelOthers = new System.Windows.Forms.Panel();
            this.numericUpDownReducedColor = new System.Windows.Forms.NumericUpDown();
            this.labelReduceColorCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkReduceColorCopy = new System.Windows.Forms.CheckBox();
            this.chkCopyBookmarkPage = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelRight.SuspendLayout();
            this.panelCompare.SuspendLayout();
            this.groupBoxCompareStyle.SuspendLayout();
            this.panelDisplay.SuspendLayout();
            this.panelOthers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReducedColor)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewOptions
            // 
            this.treeViewOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewOptions.ItemHeight = 16;
            this.treeViewOptions.Location = new System.Drawing.Point(12, 12);
            this.treeViewOptions.Name = "treeViewOptions";
            treeNode4.Name = "";
            treeNode4.Text = "Comparation";
            treeNode5.Name = "";
            treeNode5.Text = "Display";
            treeNode6.Name = "";
            treeNode6.Text = "Others";
            this.treeViewOptions.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            this.treeViewOptions.Size = new System.Drawing.Size(151, 260);
            this.treeViewOptions.TabIndex = 0;
            this.treeViewOptions.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewOptions_AfterSelect);
            // 
            // panelRight
            // 
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.panelCompare);
            this.panelRight.Controls.Add(this.panelDisplay);
            this.panelRight.Controls.Add(this.panelOthers);
            this.panelRight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelRight.Location = new System.Drawing.Point(180, 12);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(320, 260);
            this.panelRight.TabIndex = 1;
            // 
            // panelCompare
            // 
            this.panelCompare.Controls.Add(this.checkBoxCompareStyles);
            this.panelCompare.Controls.Add(this.groupBoxCompareStyle);
            this.panelCompare.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelCompare.Location = new System.Drawing.Point(200, 0);
            this.panelCompare.Name = "panelCompare";
            this.panelCompare.Size = new System.Drawing.Size(318, 258);
            this.panelCompare.TabIndex = 2;
            // 
            // checkBoxCompareStyles
            // 
            this.checkBoxCompareStyles.AutoSize = true;
            this.checkBoxCompareStyles.Checked = true;
            this.checkBoxCompareStyles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCompareStyles.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCompareStyles.Location = new System.Drawing.Point(12, 10);
            this.checkBoxCompareStyles.Name = "checkBoxCompareStyles";
            this.checkBoxCompareStyles.Size = new System.Drawing.Size(118, 21);
            this.checkBoxCompareStyles.TabIndex = 7;
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
            this.groupBoxCompareStyle.Location = new System.Drawing.Point(20, 14);
            this.groupBoxCompareStyle.Name = "groupBoxCompareStyle";
            this.groupBoxCompareStyle.Size = new System.Drawing.Size(279, 189);
            this.groupBoxCompareStyle.TabIndex = 0;
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
            // panelDisplay
            // 
            this.panelDisplay.Controls.Add(this.labelDisp);
            this.panelDisplay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelDisplay.Location = new System.Drawing.Point(100, 0);
            this.panelDisplay.Name = "panelDisplay";
            this.panelDisplay.Size = new System.Drawing.Size(318, 258);
            this.panelDisplay.TabIndex = 3;
            // 
            // labelDisp
            // 
            this.labelDisp.AutoSize = true;
            this.labelDisp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisp.Location = new System.Drawing.Point(12, 10);
            this.labelDisp.Name = "labelDisp";
            this.labelDisp.Size = new System.Drawing.Size(62, 17);
            this.labelDisp.TabIndex = 0;
            this.labelDisp.Text = "Reserved";
            // 
            // panelOthers
            // 
            this.panelOthers.Controls.Add(this.numericUpDownReducedColor);
            this.panelOthers.Controls.Add(this.labelReduceColorCount);
            this.panelOthers.Controls.Add(this.label1);
            this.panelOthers.Controls.Add(this.chkReduceColorCopy);
            this.panelOthers.Controls.Add(this.chkCopyBookmarkPage);
            this.panelOthers.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelOthers.Location = new System.Drawing.Point(0, 0);
            this.panelOthers.Name = "panelOthers";
            this.panelOthers.Size = new System.Drawing.Size(318, 258);
            this.panelOthers.TabIndex = 4;
            // 
            // numericUpDownReducedColor
            // 
            this.numericUpDownReducedColor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownReducedColor.Location = new System.Drawing.Point(177, 55);
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
            this.numericUpDownReducedColor.TabIndex = 4;
            this.numericUpDownReducedColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownReducedColor.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // labelReduceColorCount
            // 
            this.labelReduceColorCount.AutoSize = true;
            this.labelReduceColorCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReduceColorCount.Location = new System.Drawing.Point(38, 58);
            this.labelReduceColorCount.Name = "labelReduceColorCount";
            this.labelReduceColorCount.Size = new System.Drawing.Size(130, 15);
            this.labelReduceColorCount.TabIndex = 3;
            this.labelReduceColorCount.Text = "Reduced Color Count:  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Copy Behavior\n";
            // 
            // chkReduceColorCopy
            // 
            this.chkReduceColorCopy.AutoSize = true;
            this.chkReduceColorCopy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReduceColorCopy.Location = new System.Drawing.Point(14, 35);
            this.chkReduceColorCopy.Name = "chkReduceColorCopy";
            this.chkReduceColorCopy.Size = new System.Drawing.Size(219, 19);
            this.chkReduceColorCopy.TabIndex = 0;
            this.chkReduceColorCopy.Text = "Reduce colors when copying images";
            this.chkReduceColorCopy.UseVisualStyleBackColor = true;
            this.chkReduceColorCopy.CheckedChanged += new System.EventHandler(this.ChkReduceColorCopy_CheckedChanged);
            // 
            // chkCopyBookmarkPage
            // 
            this.chkCopyBookmarkPage.AutoSize = true;
            this.chkCopyBookmarkPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCopyBookmarkPage.Location = new System.Drawing.Point(14, 80);
            this.chkCopyBookmarkPage.Name = "chkCopyBookmarkPage";
            this.chkCopyBookmarkPage.Size = new System.Drawing.Size(284, 19);
            this.chkCopyBookmarkPage.TabIndex = 1;
            this.chkCopyBookmarkPage.Text = "Include page numbers when copying bookmarks";
            this.chkCopyBookmarkPage.UseVisualStyleBackColor = true;
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
            // FormOptions
            // 
            this.AcceptButton = this.buttonOK;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(514, 317);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.treeViewOptions);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.FormOptions_Load);
            this.panelRight.ResumeLayout(false);
            this.panelCompare.ResumeLayout(false);
            this.panelCompare.PerformLayout();
            this.groupBoxCompareStyle.ResumeLayout(false);
            this.groupBoxCompareStyle.PerformLayout();
            this.panelDisplay.ResumeLayout(false);
            this.panelDisplay.PerformLayout();
            this.panelOthers.ResumeLayout(false);
            this.panelOthers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownReducedColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewOptions;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelDisplay;
        private System.Windows.Forms.Panel panelOthers;
        private System.Windows.Forms.CheckBox chkReduceColorCopy;
        private System.Windows.Forms.CheckBox chkCopyBookmarkPage;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelDisp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownReducedColor;
        private System.Windows.Forms.Label labelReduceColorCount;
        private System.Windows.Forms.Panel panelCompare;
        private System.Windows.Forms.CheckBox checkBoxCompareStyles;
        private System.Windows.Forms.GroupBox groupBoxCompareStyle;
        private System.Windows.Forms.CheckBox chkCompareFillColor;
        private System.Windows.Forms.CheckBox chkCompareStrokeColor;
        private System.Windows.Forms.CheckBox chkCompareUnderlined;
        private System.Windows.Forms.CheckBox chkCompareStrikethrough;
        private System.Windows.Forms.CheckBox chkCompareHighlighted;
        private System.Windows.Forms.CheckBox chkCompareSquiggly;
        private System.Windows.Forms.CheckBox chkCompareAnnotationColor;
    }
}
