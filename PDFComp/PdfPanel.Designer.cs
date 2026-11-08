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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfPanel));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBoxFile = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonNextPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPrevPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelPages = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelPer = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelPage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxPageInput = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonHistoryForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonHistoryBack = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pdfViewer = new PdfiumViewer.PdfViewer();
            this.contextMenuStripPdf = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearMarkersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllMarkersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDocumentMarkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerPageData = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.contextMenuStripPdf.SuspendLayout();
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
            this.toolStripLabelPage,
            this.toolStripTextBoxPageInput,
            this.toolStripSeparator1,
            this.toolStripButtonHistoryForward,
            this.toolStripButtonHistoryBack});
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
            this.toolStripButtonOpen.Size = new System.Drawing.Size(40, 22);
            this.toolStripButtonOpen.Text = "Open";
            this.toolStripButtonOpen.ToolTipText = "Open PDF file.";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.ToolStripButtonOpen_Click);
            // 
            // toolStripTextBoxFile
            // 
            this.toolStripTextBoxFile.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.toolStripTextBoxFile.Margin = new System.Windows.Forms.Padding(1, 0, 4, 0);
            this.toolStripTextBoxFile.Name = "toolStripTextBoxFile";
            this.toolStripTextBoxFile.Size = new System.Drawing.Size(280, 25);
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
            this.toolStripLabelPages.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabelPages.Text = "Pages";
            // 
            // toolStripLabelPer
            // 
            this.toolStripLabelPer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelPer.Name = "toolStripLabelPer";
            this.toolStripLabelPer.Size = new System.Drawing.Size(12, 22);
            this.toolStripLabelPer.Text = "/";
            this.toolStripLabelPer.Click += new System.EventHandler(this.toolStripLabelPage_Click);
            // 
            // toolStripLabelPage
            // 
            this.toolStripLabelPage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelPage.AutoSize = false;
            this.toolStripLabelPage.Name = "toolStripLabelPage";
            this.toolStripLabelPage.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabelPage.Text = "page";
            this.toolStripLabelPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripLabelPage.Click += new System.EventHandler(this.toolStripLabelPage_Click);
            // 
            // toolStripTextBoxPageInput
            // 
            this.toolStripTextBoxPageInput.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBoxPageInput.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.toolStripTextBoxPageInput.Name = "toolStripTextBoxPageInput";
            this.toolStripTextBoxPageInput.Size = new System.Drawing.Size(50, 25);
            this.toolStripTextBoxPageInput.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolStripTextBoxPageInput.Visible = false;
            this.toolStripTextBoxPageInput.Leave += new System.EventHandler(this.toolStripTextBoxPageInput_Leave);
            this.toolStripTextBoxPageInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxPageInput_KeyDown);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonHistoryForward
            // 
            this.toolStripButtonHistoryForward.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonHistoryForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHistoryForward.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonHistoryForward.Image")));
            this.toolStripButtonHistoryForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHistoryForward.Name = "toolStripButtonHistoryForward";
            this.toolStripButtonHistoryForward.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonHistoryForward.Text = "HistoryForward";
            this.toolStripButtonHistoryForward.ToolTipText = "Forward in View History";
            // 
            // toolStripButtonHistoryBack
            // 
            this.toolStripButtonHistoryBack.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonHistoryBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHistoryBack.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonHistoryBack.Image")));
            this.toolStripButtonHistoryBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHistoryBack.Name = "toolStripButtonHistoryBack";
            this.toolStripButtonHistoryBack.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonHistoryBack.Text = "HistoryBack";
            this.toolStripButtonHistoryBack.ToolTipText = "Back in View History";
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
            // contextMenuStripPdf
            // 
            this.contextMenuStripPdf.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearMarkersToolStripMenuItem,
            this.clearAllMarkersToolStripMenuItem,
            this.copyTextToolStripMenuItem,
            this.selectAllToolStripMenuItem});
            this.contextMenuStripPdf.Name = "contextMenuStripPdf";
            this.contextMenuStripPdf.ShowImageMargin = false;
            this.contextMenuStripPdf.Size = new System.Drawing.Size(150, 92);
            this.contextMenuStripPdf.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripPdf_Opening);
            // 
            // clearMarkersToolStripMenuItem
            // 
            this.clearMarkersToolStripMenuItem.Name = "clearMarkersToolStripMenuItem";
            this.clearMarkersToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.clearMarkersToolStripMenuItem.Text = "Clear Page Markers";
            this.clearMarkersToolStripMenuItem.Click += new System.EventHandler(this.ClearMarkersToolStripMenuItem_Click);
            // 
            // clearAllMarkersToolStripMenuItem
            // 
            this.clearAllMarkersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearDocumentMarkerToolStripMenuItem});
            this.clearAllMarkersToolStripMenuItem.Name = "clearAllMarkersToolStripMenuItem";
            this.clearAllMarkersToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.clearAllMarkersToolStripMenuItem.Text = "Clear All Markers";
            // 
            // clearDocumentMarkerToolStripMenuItem
            // 
            this.clearDocumentMarkerToolStripMenuItem.Name = "clearDocumentMarkerToolStripMenuItem";
            this.clearDocumentMarkerToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.clearDocumentMarkerToolStripMenuItem.Text = "This Document";
            this.clearDocumentMarkerToolStripMenuItem.ToolTipText = "This action cannot be undone.";
            this.clearDocumentMarkerToolStripMenuItem.Click += new System.EventHandler(this.clearBookMarkerToolStripMenuItem_Click);
            // 
            // copyTextToolStripMenuItem
            // 
            this.copyTextToolStripMenuItem.Name = "copyTextToolStripMenuItem";
            this.copyTextToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.copyTextToolStripMenuItem.Text = "Copy Text";
            this.copyTextToolStripMenuItem.Click += new System.EventHandler(this.CopyTextToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // timerPageData
            // 
            this.timerPageData.Interval = 10;
            this.timerPageData.Tick += new System.EventHandler(this.timerPageData_Tick);
            // 
            // PdfPanel
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pdfViewer);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PdfPanel";
            this.Size = new System.Drawing.Size(600, 615);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.PdfPanel_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.PdfPanel_DragEnter);
            this.Enter += new System.EventHandler(this.PdfPanel_Enter);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStripPdf.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabelPer;
        private System.Windows.Forms.ToolStripLabel toolStripLabelPages;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        public PdfiumViewer.PdfViewer pdfViewer;
        public System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPdf;
        private System.Windows.Forms.ToolStripMenuItem clearMarkersToolStripMenuItem;
        public System.Windows.Forms.ToolStripButton toolStripButtonNextPage;
        public System.Windows.Forms.ToolStripButton toolStripButtonPrevPage;
        private System.Windows.Forms.ToolStripMenuItem copyTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.Timer timerPageData;
        public System.Windows.Forms.ToolStripTextBox toolStripTextBoxFile;
        public System.Windows.Forms.ToolStripTextBox toolStripTextBoxPageInput;
        private System.Windows.Forms.ToolStripMenuItem clearAllMarkersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearDocumentMarkerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonHistoryBack;
        private System.Windows.Forms.ToolStripButton toolStripButtonHistoryForward;
    }
}
