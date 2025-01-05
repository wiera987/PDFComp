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
using System.Runtime.CompilerServices;

namespace PDFComp
{
    public partial class PdfPanel : UserControl
    {
        readonly int pagesPerTick = 10;
        private List<int> _comparePage = null;                  // Remember which page the function compared to the other page.
        private double _zoom = 1.0;
        private PdfRotation _rotation = PdfRotation.Rotate0;
        private PdfPoint _contextMenuPosition;
        private PdfSearchManager _searchManager;
        private int _pageReading;
        private bool _mouseDrag = false;
        private PdfPoint _mouseDown;
        private PdfPoint _mouseUp;

        enum PdfMarkerTag {
            Search,
            Diff
        };

        /// <summary>
        /// Data class for text enclosed in bounds.
        /// </summary>
        public class PageTextData
        {
        	// Page with Text
            public int Page { get; }
            // Text enclosed in bounds
            public string Text { get; }
            // Array to hold the position of each character in the text on the page
            private int[] PagePos { get; }

			// Get text enclosed in bounds
            public PageTextData(int page, string text, int[] pagePos)
            {
                Page = page;
                Text = text;
                PagePos = pagePos;
            }

            // Get position of characters on the page.
            public int GetPagePos(int textIndex)
            {
                if (PagePos == null)
                {
                    // If PagePos is null, the selection is the entire page, so return it as is.
                    return textIndex;
                }
                return PagePos[textIndex];
            }
        }

        /// <summary>
        /// List class for text enclosed in bounds.
        /// Add one page of text at a time.
        /// </summary>
        public class PageTextList
        {
            private List<PageTextData> _pageTextList;

            // Text enclosed in bounds
            public string Text
            {
                get
                {
                    return GetText();
                }
            }

            public PageTextList()
            {
                _pageTextList = new List<PageTextData>();
            }

            public PageTextList(PageTextData pageTextData)
            {
                _pageTextList = new List<PageTextData>
                {
                    pageTextData
                };
            }

            // Add one page of text at a time.
            public void Add(PageTextData pageTextData)
            {
                _pageTextList.Add(pageTextData);
            }

            public string GetText()
            {
                StringBuilder sb = new StringBuilder();
                foreach (PageTextData pageTextData in _pageTextList)
                {
                    sb.Append(pageTextData.Text);
                }
                return sb.ToString();
            }

            // Get the page and the position of the character in the text on the page
            public (int page, int pagePos) GetPagePos(int offset)
            {
                foreach (PageTextData pageTextData in _pageTextList)
                {
                    if (offset < pageTextData.Text.Length)
                    {
                        return (pageTextData.Page, pageTextData.GetPagePos(offset));
                    }
                    offset -= pageTextData.Text.Length;
                }
                return (-1, -1);
            }

            public int GetOffset(int page)
            {
                int offset = 0;

                // Get the offset of the page in the text.
                foreach (PageTextData pageTextData in _pageTextList)
                {
                    if (pageTextData.Page == page)
                    {
                        return offset;
                    }
                    offset += pageTextData.Text.Length;
                }

                //throw new ArgumentOutOfRangeException("page");
                return int.MaxValue;
            }
        }


        /// <summary>
        /// Constructor
        /// </summary>
        public PdfPanel()
        {
            InitializeComponent();
            this.MouseWheel += PdfPanel_MouseWheel;

            pdfViewer.PanelBookmarkClosed += PanelBookmarkClosed;
            pdfViewer.Renderer.DisplayRectangleChanged += Renderer_DisplayRectangleChanged;
            pdfViewer.Renderer.MouseDown += Renderer_MouseDown;
            pdfViewer.Renderer.MouseMove += Renderer_MouseMove;
            pdfViewer.Renderer.MouseUp += Renderer_MouseUp;

            pdfViewer.Renderer.ContextMenuStrip = contextMenuStripPdf;

            pdfViewer.Renderer.ZoomMin = 0.1;
            pdfViewer.Renderer.ZoomMax = 9.0;

            _pageReading = -1;
        }

        public void NextPage()
        {
            toolStripButtonNextPage.PerformClick();
        }

        public void PrevPage()
        {
            toolStripButtonPrevPage.PerformClick();
        }

        private void PdfPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            // Adjust trackbar value when wheel zoomed.

            Form parentForm = FindForm();
            ((FormMain)parentForm).AdjustTrackBarZoom(GetZoom());
        }

        public double GetZoom()
        {
            if (pdfViewer.Document != null)
            {
                _zoom = pdfViewer.Renderer.Zoom;
            }
            return _zoom;
        }

        public void SetZoom(double zoom)
        {
            _zoom = zoom;

            if (pdfViewer.Document != null)
            {
                pdfViewer.Renderer.Zoom = _zoom;
            }
        }

        public void FitHeight()
        {
            if (pdfViewer.Document != null)
            {
                int page = pdfViewer.Renderer.Page;
                pdfViewer.ZoomMode = PdfViewerZoomMode.FitHeight;
                pdfViewer.Renderer.Zoom = 1;
                pdfViewer.Renderer.Page = page;

            }
        }

        public void FitWidth()
        {
            if (pdfViewer.Document != null)
            {
                int page = pdfViewer.Renderer.Page;
                pdfViewer.ZoomMode = PdfViewerZoomMode.FitWidth;
                pdfViewer.Renderer.Zoom = 1;
                pdfViewer.Renderer.Page = page;

            }
        }

        public String GetBookmarksText()
        {
            if (pdfViewer.Document != null)
            {
                StringBuilder sb = new StringBuilder();
                PdfBookmarkCollection bookmarks = pdfViewer.Document.Bookmarks;

                GetBookmarkText(sb, bookmarks);

                if (sb.Length > 0)
                {
                    return sb.ToString();
                }
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

        public PageTextData GetPageTextData(int page)
        {
            pdfViewer.Renderer.Page = page;                 // TODO: Prevent pages from moving
            return GetPageTextData();
        }

        public PageTextData GetPageTextData()
        {
            if (pdfViewer.Document != null)
            {
                if (pdfViewer.Renderer.CompareBounds.IsEmpty)
                {
                    // Extract the entire page.
                    int[] pagePos = null;
                    string text = pdfViewer.Document.GetPdfText(pdfViewer.Renderer.ComparisonPage);
                    return new PageTextData(pdfViewer.Renderer.ComparisonPage, text, pagePos);
                }
                else
                {
                    // Extract a range of CompareBounds.
                    var page = pdfViewer.Renderer.ComparisonPage;
                    var text = pdfViewer.Document.GetPdfText(page);
                    var pageText = string.Empty;
                    var compBounds = pdfViewer.Renderer.CompareBounds;
                    var count = 0;

                    int[] pagePos = new int[text.Length];

                    for (int i = 0; i < text.Length; i++)
                    {
                        var textSpan = new PdfTextSpan(page, i, 1);
                        //Console.WriteLine("textSpan Page{0}: Offset{1}, Len{2} = {3}", textSpan.Page, textSpan.Offset, textSpan.Length, text[i]);

                        var charBounds = pdfViewer.Renderer.Document.GetTextBounds(textSpan);
                        var charRect = charBounds[0].Bounds;
                        NormRectangle(ref charRect);

                        // If the entire charRect is included in the compBounds, extract the character.
                        if (IsIncludedEntire(compBounds, charRect))
                        {
                            pageText += text[i];
                            pagePos[count] = i;
                            count++;
                        }

                    }
                    //Console.WriteLine("GetPageTextData = {0}", pageText);
                    return new PageTextData(page, pageText, pagePos);
                }
            }

            return new PageTextData(-1, "NULL", null);
        }

        public void NormRectangle(ref RectangleF rect)
        {
            if (rect.Width < 0)
            {
                rect.X += rect.Width;
                rect.Width = -rect.Width;
            }
            if (rect.Height < 0)
            {
                rect.Y += rect.Height;
                rect.Height = -rect.Height;
            }
        }

        public bool IsIncludedEntire(RectangleF base_rect, RectangleF rect)
        {
            // If the entire rect is included in the comp_rect, extract the character.
            if ((rect.X + rect.Width <= base_rect.X + base_rect.Width) &&
                (base_rect.X <= rect.X) &&
                (rect.Y + rect.Height <= base_rect.Y + base_rect.Height) &&
                (base_rect.Y <= rect.Y))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the page range of the bookmark that corresponds to the specified page.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public (int start, int end) GetBookmarkPages(int page)
        {
            int start = -1;
            int end = -1;
            
            if (pdfViewer.Document != null)
            {
                pdfViewer.GetBookmarkPageRange(page, out start, out end);
            }
            return (start, end);
        }

        public void ToggleBookmarks()
        {
            pdfViewer.ShowBookmarks = !pdfViewer.ShowBookmarks;
        }

        public bool GetShowBookmarks()
        {
            return pdfViewer.ShowBookmarks;
        }

        public void SetShowBookmarks(bool show)
        {
            pdfViewer.ShowBookmarks = show;
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
                if ((page >= 0) && (page < _comparePage.Count))
                {
                    return _comparePage[page];
                }
            }

            // Not any page
            return -1;
        }

        public void SetComparedPage(int page, int oppositePage)
        {
            if (_comparePage != null)
            {
                if (_comparePage[page] < 0)
                {
                    _comparePage[page] = oppositePage;
                }
            }
        }

        /// <summary>
        /// Clear difference markers in diffpage.
        /// </summary>
        /// <param name="diffpage">Difference comparison page</param>
        /// <param name="OneFullPage">If comparing the entire page, clear regardless of CompareBounds.</param>
        public void ClearDiffMarker(int diffpage, bool OneFullPage)
        {
            if (diffpage >= 0)
            {
                // Delete difference markers in the diffpage.
                for (int i = pdfViewer.Renderer.Markers.Count - 1; i >= 0; i--)
                {
                    PdfMarker marker = (PdfMarker)pdfViewer.Renderer.Markers[i];
                    var comp_rect = pdfViewer.Renderer.CompareBounds;
                    // Decrease the amount increased in AddDiffMarker().
                    var boundsRect = new RectangleF(
                                        marker.Bounds.Left + 1,
                                        marker.Bounds.Top - 1,
                                        marker.Bounds.Width - 2,
                                        marker.Bounds.Height + 2);

                    if ((marker.Page == diffpage) &&
                        (marker.Tag == (int)PdfMarkerTag.Diff) &&
                        (OneFullPage || IsIncludedEntire(comp_rect, boundsRect)))
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

        public void AddDiffMarker(List<PdfTextSpan> indexes)
        {
            if (indexes != null)
            {
                Console.WriteLine("AddDiffMarker Page{0}:Count{1}", -999, indexes.Count);

                foreach (PdfTextSpan textSpan in indexes)
                {
                    //Console.WriteLine("textSpan Page{0}: Offset{1}, Len{2}", textSpan.Page, textSpan.Offset, textSpan.Length);
                    var page = textSpan.Page;
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
                            (int)PdfMarkerTag.Diff);            // Add a difference marker.

                        pdfViewer.Renderer.Markers.Add(marker);

                        //Console.WriteLine("Added");
                    }
                }
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

            if (files.Length == 1)
            {
                // Drop only the first file.
                string fileName = files[0];
                OpenFile(fileName);
            }
            else
            {
                // Drop in FormMain.
                ((FormMain)FindForm()).OpenFiles(files);
            }
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

        public void OpenFile(string fileName)
        {
            pdfViewer.Document?.Dispose();
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

            pdfViewer.Renderer.Markers.Clear();
            pdfViewer.SelectBookmarkForPage(0);                     // Set the first page bookmark to selected

            // Load PageData with Timer event.
            _pageReading = 0;
            timerPageData.Enabled = true;
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
            pdfViewer.SelectBookmarkForPage(pdfViewer.Renderer.Page);
        }

        private void Renderer_MouseDown(object sender, MouseEventArgs e)
        {
            if (pdfViewer.Renderer.CursorMode == PdfCursorMode.Bounds)
            {
                _mouseDrag = true;
                _mouseDown = pdfViewer.Renderer.PointToPdf(e.Location);
                _mouseUp = _mouseDown;

                var bounds = new RectangleF(_mouseDown.Location, new SizeF(0, 0));
                pdfViewer.Renderer.CompareBounds = bounds;

                //Console.WriteLine("Down:{0}", bounds);
            }
        }
        private void Renderer_MouseMove(object sender, MouseEventArgs e)
        {
            if (pdfViewer.Renderer.CursorMode == PdfCursorMode.Bounds)
            {
                if (_mouseDrag)
                {
                    _mouseUp = pdfViewer.Renderer.PointToPdf(e.Location);

                    var bounds = new RectangleF(
                            _mouseDown.Location.X,
                            _mouseDown.Location.Y,
                            _mouseUp.Location.X - _mouseDown.Location.X,
                            _mouseUp.Location.Y - _mouseDown.Location.Y
                            );

                    pdfViewer.Renderer.CompareBounds = bounds;

                    //Console.WriteLine("Move:{0}", bounds);
                }
            }
        }

        private void Renderer_MouseUp(object sender, MouseEventArgs e)
        {
            if (pdfViewer.Renderer.CursorMode == PdfCursorMode.Bounds)
            {
                _mouseDrag = false;
                _mouseUp = pdfViewer.Renderer.PointToPdf(e.Location);

                var bounds = new RectangleF(
                    _mouseDown.Location.X,
                    _mouseDown.Location.Y,
                    _mouseUp.Location.X - _mouseDown.Location.X,
                    _mouseUp.Location.Y - _mouseDown.Location.Y
                    );

                pdfViewer.Renderer.CompareBounds = bounds;

                //Console.WriteLine("Up  :{0}", bounds);
            }
        }

        private void ContextMenuStripPdf_Opening(object sender, CancelEventArgs e)
        {
            copyTextToolStripMenuItem.Enabled = pdfViewer.Renderer.IsTextSelected;
            selectAllToolStripMenuItem.Enabled = (pdfViewer.Document != null);
        }

        private void ClearMarkersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Point screenPosition = Control.MousePosition;
            Point controlPosition = pdfViewer.Renderer.PointToClient(screenPosition);
            _contextMenuPosition = pdfViewer.Renderer.PointToPdf(controlPosition);

            //Console.WriteLine(_contextMenuPosition.Page);
            //Console.WriteLine(_contextMenuPosition.Location);

            ClearDiffMarker(_contextMenuPosition.Page, true);
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

        private void timerPageData_Tick(object sender, EventArgs e)
        {
            // Read PageData in the Timer event because the search takes a long time.
            for (int i = _pageReading; i < pdfViewer.Document.PageCount; i++)
            {
                if (i == _pageReading + pagesPerTick)
                {
                    _pageReading = i;
                    return;
                }

                // dummy job
                pdfViewer.Renderer.Document.GetPdfText(new PdfTextSpan(i, 0, 1));
            }

            // PageData caching completed.
            _pageReading = -1;
            timerPageData.Enabled = false;
        }

        private void toolStripLabelPage_Click(object sender, EventArgs e)
        {
            // Switch Label to TextBox.
            toolStripTextBoxPageInput.Size = toolStripLabelPage.Size;
            toolStripLabelPage.Visible = false;

            if (pdfViewer.Document != null)
            {
                toolStripTextBoxPageInput.Text = (pdfViewer.Renderer.Page + 1).ToString();
            }
            toolStripTextBoxPageInput.Visible = true;
            toolStripTextBoxPageInput.SelectAll();
            toolStripTextBoxPageInput.Focus();

        }

        private void toolStripTextBoxPageInput_Leave(object sender, EventArgs e)
        {
            // Switch TextBox to Label.
            toolStripTextBoxPageInput.Visible = false;
            toolStripLabelPage.Visible = true;

            if (pdfViewer.Document != null)
            {
                int newPage;
                if (int.TryParse(toolStripTextBoxPageInput.Text, out newPage))
                {
                    if (newPage <= pdfViewer.Document.PageCount)
                    {
                        newPage = (newPage > 0) ? newPage : 1;
                        pdfViewer.Renderer.Page = newPage - 1;
                        toolStripLabelPage.Text = newPage.ToString();
                    }
                }
            }
        }

        private void toolStripTextBoxPageInput_KeyDown(object sender, KeyEventArgs e)
        {
            // Confirm the input with the Enter key.
            if (e.KeyCode == Keys.Enter)
            {
                // Move the focus anywhere to generate a Leave event.
                toolStrip1.Focus();
                // Mute the beep sound.
                e.SuppressKeyPress = true;
            }
        }

        private void PanelBookmarkClosed(object sender, EventArgs e)
        {
            //Console.WriteLine("PanelBookmar has closed in PdfParent.");
            ((FormMain)FindForm()).PanelBookmarkClosed(this);
        }

    }
}
