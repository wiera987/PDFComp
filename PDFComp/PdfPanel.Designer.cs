namespace PDFComp
{
    partial class PdfPanel
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfPanel));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBoxFile = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonNextPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPrevPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelPages = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelPer = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelPage = new System.Windows.Forms.ToolStripLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pdfViewer = new PdfiumViewer.PdfViewer();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripTextBoxFile,
            this.toolStripButtonNextPage,
            this.toolStripButtonPrevPage,
            this.toolStripLabelPages,
            this.toolStripLabelPer,
            this.toolStripLabelPage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(600, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpen.Image")));
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(35, 22);
            this.toolStripButtonOpen.Text = "Open";
            this.toolStripButtonOpen.ToolTipText = "Open PDF file.";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.ToolStripButtonOpen_Click);
            // 
            // toolStripTextBoxFile
            // 
            this.toolStripTextBoxFile.Name = "toolStripTextBoxFile";
            this.toolStripTextBoxFile.Size = new System.Drawing.Size(400, 25);
            // 
            // toolStripButtonNextPage
            // 
            this.toolStripButtonNextPage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonNextPage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNextPage.Image")));
            this.toolStripButtonNextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNextPage.Name = "toolStripButtonNextPage";
            this.toolStripButtonNextPage.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNextPage.Text = ">";
            this.toolStripButtonNextPage.ToolTipText = "Next Page";
            this.toolStripButtonNextPage.Click += new System.EventHandler(this.ToolStripButtonNextPage_Click);
            // 
            // toolStripButtonPrevPage
            // 
            this.toolStripButtonPrevPage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonPrevPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonPrevPage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPrevPage.Image")));
            this.toolStripButtonPrevPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrevPage.Name = "toolStripButtonPrevPage";
            this.toolStripButtonPrevPage.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPrevPage.Text = "<";
            this.toolStripButtonPrevPage.ToolTipText = "Prev Page";
            this.toolStripButtonPrevPage.Click += new System.EventHandler(this.ToolStripButtonPrevPage_Click);
            // 
            // toolStripLabelPages
            // 
            this.toolStripLabelPages.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelPages.Name = "toolStripLabelPages";
            this.toolStripLabelPages.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabelPages.Text = "Pages";
            // 
            // toolStripLabelPer
            // 
            this.toolStripLabelPer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelPer.Name = "toolStripLabelPer";
            this.toolStripLabelPer.Size = new System.Drawing.Size(11, 22);
            this.toolStripLabelPer.Text = "/";
            // 
            // toolStripLabelPage
            // 
            this.toolStripLabelPage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelPage.Name = "toolStripLabelPage";
            this.toolStripLabelPage.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabelPage.Text = "page";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "pdf";
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // pdfViewer
            // 
            this.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer.Location = new System.Drawing.Point(0, 25);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.ShowBookmarks = false;
            this.pdfViewer.ShowToolbar = false;
            this.pdfViewer.Size = new System.Drawing.Size(600, 590);
            this.pdfViewer.TabIndex = 1;
            // 
            // PdfPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pdfViewer);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PdfPanel";
            this.Size = new System.Drawing.Size(600, 615);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxFile;
        private System.Windows.Forms.ToolStripButton toolStripButtonNextPage;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrevPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabelPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabelPer;
        private System.Windows.Forms.ToolStripLabel toolStripLabelPages;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        public PdfiumViewer.PdfViewer pdfViewer;
        public System.Windows.Forms.ToolStripButton toolStripButtonOpen;
    }
}
