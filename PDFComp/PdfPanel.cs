using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using PdfiumViewer;
using NetDiff;

namespace PDFComp
{
    public partial class PdfPanel : UserControl
    {
        private List<int> _comparePage = null;
        private List<PdfTextSpan> _indexes = null;
        private double _zoom = 1.0;
        private PdfRotation _rotation = PdfRotation.Rotate0;
        private PdfPoint _contextMenuPosition;
        private PdfSearchManager _searchManager;

        public PdfPanel()
        {
            InitializeComponent();
            pdfViewer.Renderer.DisplayRectangleChanged += Renderer_DisplayRectangleChanged;

            pdfViewer.Renderer.ContextMenuStrip = contextMenuStripPdf;

        }

        public void NextPage()
        {
            toolStripButtonNextPage.PerformClick();
        }

        public void PrevPage()
        {
            toolStripButtonPrevPage.PerformClick();
        }

        public void SetZoom(double zoom)
        {
            _zoom = zoom;

            if (pdfViewer.Document != null)
            {
                pdfViewer.Renderer.Zoom = _zoom;
            }
        }

        public String GetBookmarksText()
        {
            if (pdfViewer.Document != null)
            {
                StringBuilder sb = new StringBuilder();
                PdfBookmarkCollection bookmarks = pdfViewer.Document.Bookmarks;

                GetBookmarkText(sb, bookmarks);

                return sb.ToString();
            }

            return null;
        }

        private static void GetBookmarkText(StringBuilder sb, PdfBookmarkCollection bookmarks)
        {
            foreach (var bookmark in bookmarks)
            {
                sb.AppendLine(bookmark.Title);
                if (bookmark.Children != null)
                {
                    GetBookmarkText(sb, bookmark.Children);
                }
            }
        }

        public String GetPageText()
        {
            if (pdfViewer.Document != null)
            {
                return pdfViewer.Document.GetPdfText(pdfViewer.Renderer.Page);
            }

            return "NULL";
        }

        internal void SetPageDiff(List<PdfTextSpan> indexes)
        {
            _indexes = indexes;
        }

        public void ToggleBookmarks()
        {
            pdfViewer.ShowBookmarks = !pdfViewer.ShowBookmarks;
        }

        public void Rotate(PdfRotation rotation)
        {
            _rotation = rotation;

            if (pdfViewer.Document != null)
            {
                pdfViewer.Renderer.Rotation = _rotation;
            }
        }

        public int GetComparedPage(int page)
        {
            if (_comparePage != null)
            {
                if (page < _comparePage.Count)
                {
                    return _comparePage[page];
                }
            }

            // Not any page
            return -1;
        }

        public void ClearDiffMarker(int diffpage)
        {
            if (diffpage >= 0)
            {
                // Delete difference markers in the diffpage.
                for (int i = pdfViewer.Renderer.Markers.Count - 1; i >= 0; i--)
                {
                    if ((pdfViewer.Renderer.Markers[i].Page == diffpage) && (pdfViewer.Renderer.Markers[i].Tag == 1))
                    {
                        pdfViewer.Renderer.Markers.RemoveAt(i);
                    }
                }

                if (_comparePage != null)
                {
                    _comparePage[diffpage] = -1;
                }
            }
        }

        public void AddDiffMarker(int comparePage)
        {
            if (_indexes != null)
            {
                int page = pdfViewer.Renderer.Page;
                Console.WriteLine("AddDiffMarker Page{0}:Count{1}", page, _indexes.Count);

                foreach (PdfTextSpan textSpan in _indexes)
                {
                    //Console.WriteLine("textSpan Page{0}: Offset{1}, Len{2}", textSpan.Page, textSpan.Offset, textSpan.Length);

                    var bounds = pdfViewer.Renderer.Document.GetTextBounds(textSpan);

                    foreach (PdfRectangle pdfrect in bounds)
                    {

                        var boundsRect = new RectangleF(
                            pdfrect.Bounds.Left - 1,
                            pdfrect.Bounds.Top + 1,
                            pdfrect.Bounds.Width + 2,
                            pdfrect.Bounds.Height - 2);

                        //Console.Write("({0}, {1}, {2}, {3})", boundsText.Left, boundsText.Top, boundsText.Right, boundsText.Bottom);

                        var marker = new PdfMarker(
                            page,
                            boundsRect,
                            Color.FromArgb(64, Color.Red),
                            Color.FromArgb(64, Color.Red),
                            0,
                            1);			// Add a tag1 that is a difference marker.

                        pdfViewer.Renderer.Markers.Add(marker);

                        //Console.WriteLine("Added");
                    }

                }

                _comparePage[page] = comparePage;	// Remember the compared page
            }
        }

        private void PdfPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PdfPanel_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            string fileName = files[0];       // Drop only the first file.
            OpenFile(fileName);
        }
        
        private void ToolStripButtonOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = toolStripTextBoxFile.Text;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                OpenFile(fileName);
            }
        }

        private void OpenFile(string fileName)
        {
            pdfViewer.Document = PdfDocument.Load(fileName);
            pdfViewer.Renderer.Zoom = _zoom;
            pdfViewer.Renderer.Rotation = _rotation;

            toolStripLabelPage.Text = 1.ToString();
            toolStripLabelPages.Text = pdfViewer.Document.PageCount.ToString();
            toolStripTextBoxFile.Text = fileName;                   // Drop only the first file.
            toolStripTextBoxFile.SelectionStart = fileName.Length;  // Move the caret to the end of the text box
            toolStripTextBoxFile.ToolTipText = fileName;

            _comparePage = new List<int>(pdfViewer.Document.PageCount);
            for (int i = 0; i < pdfViewer.Document.PageCount; i++)
            {
                _comparePage.Add(-1);
            }

            _indexes = null;
            pdfViewer.Renderer.Markers.Clear();
        }

        private void ToolStripButtonPrevPage_Click(object sender, EventArgs e)
        {
            if (pdfViewer.Document != null)
            {
                if (pdfViewer.Renderer.Page > 0)
                {
                    pdfViewer.Renderer.Page = pdfViewer.Renderer.Page - 1;
                    toolStripLabelPage.Text = (pdfViewer.Renderer.Page + 1).ToString();
                }
            }

        }

        private void ToolStripButtonNextPage_Click(object sender, EventArgs e)
        {
            if (pdfViewer.Document != null)
            {
                if (pdfViewer.Renderer.Page < pdfViewer.Document.PageCount - 1)
                {
                    pdfViewer.Renderer.Page = pdfViewer.Renderer.Page + 1;
                    toolStripLabelPage.Text = (pdfViewer.Renderer.Page + 1).ToString();
                }
            }

        }

        private void Renderer_DisplayRectangleChanged(object sender, EventArgs e)
        {
            toolStripLabelPage.Text = (pdfViewer.Renderer.Page + 1).ToString();
        }

        private void ContextMenuStripPdf_Opening(object sender, CancelEventArgs e)
        {
            copyTextToolStripMenuItem.Enabled = pdfViewer.Renderer.IsTextSelected;
        }

        private void ClearMarkersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Point screenPosition = Control.MousePosition;
            Point controlPosition = pdfViewer.Renderer.PointToClient(screenPosition);
            _contextMenuPosition = pdfViewer.Renderer.PointToPdf(controlPosition);

            //Console.WriteLine(_contextMenuPosition.Page);
            //Console.WriteLine(_contextMenuPosition.Location);

            ClearDiffMarker(_contextMenuPosition.Page);
        }

        private void CopyTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdfViewer.Renderer.CopySelection();
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdfViewer.Renderer.SelectAll();
        }

        private void PdfPanel_Enter(object sender, EventArgs e)
        {
            Parent.Parent.Tag = this.Name;
            Console.WriteLine("Enter:{0}", this.Name);
        }

        public bool Search(string text, bool matchCase = false, bool matchWholeWord = false, bool highlight = false)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (_searchManager == null)
            {
                _searchManager = new PdfSearchManager(pdfViewer.Renderer);
            }
            _searchManager.MatchCase = matchCase;
            _searchManager.MatchWholeWord = matchWholeWord;
            _searchManager.HighlightAllMatches = highlight;
            bool result = _searchManager.Search(text);

            Cursor.Current = Cursors.Default;

            return result;
        }

        public bool FindNext(bool forward)
        {
            Debug.Assert(_searchManager != null);

            return _searchManager.FindNext(forward);
        }

    }
}
