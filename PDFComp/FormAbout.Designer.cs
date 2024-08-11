namespace PDFComp
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.labelAboutApp = new System.Windows.Forms.Label();
            this.labelAboutVersion = new System.Windows.Forms.Label();
            this.labelAboutAuth = new System.Windows.Forms.Label();
            this.labelAboutLicense = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelAoutVerNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIcon.Image")));
            this.pictureBoxIcon.Location = new System.Drawing.Point(41, 29);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxIcon.TabIndex = 0;
            this.pictureBoxIcon.TabStop = false;
            // 
            // labelAboutApp
            // 
            this.labelAboutApp.AutoSize = true;
            this.labelAboutApp.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAboutApp.Location = new System.Drawing.Point(204, 29);
            this.labelAboutApp.Name = "labelAboutApp";
            this.labelAboutApp.Size = new System.Drawing.Size(209, 60);
            this.labelAboutApp.TabIndex = 1;
            this.labelAboutApp.Text = "PDFComp";
            // 
            // labelAboutVersion
            // 
            this.labelAboutVersion.AutoSize = true;
            this.labelAboutVersion.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAboutVersion.Location = new System.Drawing.Point(409, 62);
            this.labelAboutVersion.Name = "labelAboutVersion";
            this.labelAboutVersion.Size = new System.Drawing.Size(59, 16);
            this.labelAboutVersion.TabIndex = 3;
            this.labelAboutVersion.Text = "Version ";
            // 
            // labelAboutAuth
            // 
            this.labelAboutAuth.AutoSize = true;
            this.labelAboutAuth.Location = new System.Drawing.Point(219, 136);
            this.labelAboutAuth.Name = "labelAboutAuth";
            this.labelAboutAuth.Size = new System.Drawing.Size(238, 12);
            this.labelAboutAuth.TabIndex = 4;
            this.labelAboutAuth.Text = "(C) 2019-2024  Wiera987  All rights reserved.";
            // 
            // labelAboutLicense
            // 
            this.labelAboutLicense.AutoSize = true;
            this.labelAboutLicense.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAboutLicense.ForeColor = System.Drawing.Color.Blue;
            this.labelAboutLicense.Location = new System.Drawing.Point(216, 101);
            this.labelAboutLicense.Name = "labelAboutLicense";
            this.labelAboutLicense.Size = new System.Drawing.Size(299, 14);
            this.labelAboutLicense.TabIndex = 6;
            this.labelAboutLicense.Text = "licensed under the Apache License, Version2.0";
            this.labelAboutLicense.Click += new System.EventHandler(this.LabelAboutLicense_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(400, 184);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(93, 31);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // labelAoutVerNo
            // 
            this.labelAoutVerNo.AutoSize = true;
            this.labelAoutVerNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAoutVerNo.Location = new System.Drawing.Point(467, 62);
            this.labelAoutVerNo.Name = "labelAoutVerNo";
            this.labelAoutVerNo.Size = new System.Drawing.Size(55, 16);
            this.labelAoutVerNo.TabIndex = 8;
            this.labelAoutVerNo.Text = "number";
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 244);
            this.Controls.Add(this.labelAoutVerNo);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelAboutLicense);
            this.Controls.Add(this.labelAboutAuth);
            this.Controls.Add(this.labelAboutVersion);
            this.Controls.Add(this.labelAboutApp);
            this.Controls.Add(this.pictureBoxIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAbout";
            this.Text = "About PDFComp";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormAbout_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label labelAboutApp;
        private System.Windows.Forms.Label labelAboutVersion;
        private System.Windows.Forms.Label labelAboutAuth;
        private System.Windows.Forms.Label labelAboutLicense;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelAoutVerNo;
    }
}