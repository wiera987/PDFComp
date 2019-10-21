namespace PDFComp
{
    partial class FormFind
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
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.buttonNext1 = new System.Windows.Forms.Button();
            this.buttonNext2 = new System.Windows.Forms.Button();
            this.checkBoxMatchCase = new System.Windows.Forms.CheckBox();
            this.checkBoxMatchWholeWord = new System.Windows.Forms.CheckBox();
            this.checkBoxHighlightAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxFind
            // 
            this.textBoxFind.Location = new System.Drawing.Point(29, 15);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(314, 19);
            this.textBoxFind.TabIndex = 0;
            this.textBoxFind.TextChanged += new System.EventHandler(this.TextBoxFind_TextChanged);
            // 
            // buttonNext1
            // 
            this.buttonNext1.Location = new System.Drawing.Point(187, 40);
            this.buttonNext1.Name = "buttonNext1";
            this.buttonNext1.Size = new System.Drawing.Size(75, 23);
            this.buttonNext1.TabIndex = 1;
            this.buttonNext1.Text = "Next1 (F3)";
            this.buttonNext1.UseCompatibleTextRendering = true;
            this.buttonNext1.UseVisualStyleBackColor = true;
            this.buttonNext1.Click += new System.EventHandler(this.ButtonNext1_Click);
            // 
            // buttonNext2
            // 
            this.buttonNext2.Location = new System.Drawing.Point(268, 40);
            this.buttonNext2.Name = "buttonNext2";
            this.buttonNext2.Size = new System.Drawing.Size(75, 23);
            this.buttonNext2.TabIndex = 2;
            this.buttonNext2.Text = "Next2 (F4)";
            this.buttonNext2.UseVisualStyleBackColor = true;
            this.buttonNext2.Click += new System.EventHandler(this.ButtonNext2_Click);
            // 
            // checkBoxMatchCase
            // 
            this.checkBoxMatchCase.AutoSize = true;
            this.checkBoxMatchCase.Location = new System.Drawing.Point(29, 40);
            this.checkBoxMatchCase.Name = "checkBoxMatchCase";
            this.checkBoxMatchCase.Size = new System.Drawing.Size(83, 16);
            this.checkBoxMatchCase.TabIndex = 3;
            this.checkBoxMatchCase.Text = "Match case";
            this.checkBoxMatchCase.UseVisualStyleBackColor = true;
            this.checkBoxMatchCase.CheckedChanged += new System.EventHandler(this.CheckBoxMatchCase_CheckedChanged);
            // 
            // checkBoxMatchWholeWord
            // 
            this.checkBoxMatchWholeWord.AutoSize = true;
            this.checkBoxMatchWholeWord.Location = new System.Drawing.Point(29, 60);
            this.checkBoxMatchWholeWord.Name = "checkBoxMatchWholeWord";
            this.checkBoxMatchWholeWord.Size = new System.Drawing.Size(116, 16);
            this.checkBoxMatchWholeWord.TabIndex = 4;
            this.checkBoxMatchWholeWord.Text = "Match whole word";
            this.checkBoxMatchWholeWord.UseVisualStyleBackColor = true;
            this.checkBoxMatchWholeWord.CheckedChanged += new System.EventHandler(this.CheckBoxMatchWholeWord_CheckedChanged);
            // 
            // checkBoxHighlightAll
            // 
            this.checkBoxHighlightAll.AutoSize = true;
            this.checkBoxHighlightAll.Checked = true;
            this.checkBoxHighlightAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHighlightAll.Location = new System.Drawing.Point(29, 80);
            this.checkBoxHighlightAll.Name = "checkBoxHighlightAll";
            this.checkBoxHighlightAll.Size = new System.Drawing.Size(132, 16);
            this.checkBoxHighlightAll.TabIndex = 5;
            this.checkBoxHighlightAll.Text = "Highlight all matches";
            this.checkBoxHighlightAll.UseVisualStyleBackColor = true;
            this.checkBoxHighlightAll.CheckedChanged += new System.EventHandler(this.CheckBoxHighlightAll_CheckedChanged);
            // 
            // FormFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 107);
            this.Controls.Add(this.checkBoxHighlightAll);
            this.Controls.Add(this.checkBoxMatchWholeWord);
            this.Controls.Add(this.checkBoxMatchCase);
            this.Controls.Add(this.buttonNext2);
            this.Controls.Add(this.buttonNext1);
            this.Controls.Add(this.textBoxFind);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFind";
            this.ShowIcon = false;
            this.Text = "Find";
            this.Activated += new System.EventHandler(this.FormFind_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFind_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormFind_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.Button buttonNext1;
        private System.Windows.Forms.Button buttonNext2;
        private System.Windows.Forms.CheckBox checkBoxMatchCase;
        private System.Windows.Forms.CheckBox checkBoxMatchWholeWord;
        private System.Windows.Forms.CheckBox checkBoxHighlightAll;
    }
}