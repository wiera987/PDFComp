using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfiumViewer;
using DiffMatchPatch;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using static PDFComp.PdfPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PDFComp
{
    public partial class FormMain : Form
    {
        readonly Double ZoomInScale = 0.1;      // zoom : 10%..26%..80%..100%..200%..400%...900%  
        readonly Double ZoomOutScale = 0.01;    // scale:    -2%, -3%, -5%, +10%, +20%, +50%
        FormFind formFind = null;
        FormDiffInfo formDiffInfo = null;
        PagePairList pagePairList = null;
        PdfRotation rotation;
        Double zoom;
        Boolean zoomIn;
        Boolean zoomOut;
        int FindDiffPage1;
        int FindDiffPage2;
        bool flashPageFlag = true;
        Boolean reduceColor = true;
        Boolean autoReduceColor = false;
        bool holdZoom = false;

        public FormMain()
        {
            InitializeComponent();
            toolStripComboBoxDiffType.SelectedIndex = 0;
            // Designer settings are not reflected in TrackBar.AutoSize.
            toolStripTrackBarZoom.Height = 22;
            toolStripTrackBarZoom.TrackBar.AutoSize = toolStripTrackBarZoom.AutoSize;

            pdfPanel1.toolStripButtonNextPage.ToolTipText = "Next Page / Ctrl + RIGHT_ARROW";
            pdfPanel1.toolStripButtonPrevPage.ToolTipText = "Prev Page / Ctrl + LEFT_ARROW";
            pdfPanel2.toolStripButtonNextPage.ToolTipText = "Next Page / Alt + RIGHT_ARROW";
            pdfPanel2.toolStripButtonPrevPage.ToolTipText = "Prev Page / Alt + LEFT_ARROW";

            zoom = 1.0;
            zoomIn = false;
            zoomOut = false;
            rotation = PdfRotation.Rotate0;

            FindDiffPage1 = -1;
            FindDiffPage2 = -1;

            // Debug ExtractDiffSpan2
            formDiffInfo = new FormDiffInfo();
#if DEBUG
            formDiffInfo.Show();

            // Debug menu is displayed only in Debug mode.
            outputDebugLogToolStripMenuItem.Visible = true;
#endif
        }

        public void OpenFiles(String[] files)
        {
            PagePairClearAll();

            pdfPanel1.OpenFile(files[0]);
            pdfPanel2.OpenFile(files[1]);
        }

        public void PagePairClearAll()
        {
            // Initialize the page pair list.
            pagePairList.ClearAll();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    toolStripButtonPrevPages.PerformClick();
                    return true;
                case Keys.Right:
                    toolStripButtonNextPages.PerformClick();
                    return true;
                case Keys.Space:
                    toolStripSplitButtonCompare.PerformButtonClick();
                    return true;

                case Keys.Control | Keys.Left:
                    pdfPanel1.toolStripButtonPrevPage.PerformClick();
                    return true;
                case Keys.Control | Keys.Right:
                    pdfPanel1.toolStripButtonNextPage.PerformClick();
                    return true;
                case Keys.Alt | Keys.Left:
                    pdfPanel2.toolStripButtonPrevPage.PerformClick();
                    return true;
                case Keys.Alt | Keys.Right:
                    pdfPanel2.toolStripButtonNextPage.PerformClick();
                    return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    toolStripButtonPrevPages.PerformClick();
                    break;
                case Keys.Right:
                    toolStripButtonNextPages.PerformClick();
                    break;

                case Keys.Control | Keys.Left:
                    pdfPanel1.toolStripButtonPrevPage.PerformClick();
                    break;
                case Keys.Control | Keys.Right:
                    pdfPanel1.toolStripButtonNextPage.PerformClick();
                    break;
                case Keys.Alt | Keys.Left:
                    pdfPanel2.toolStripButtonPrevPage.PerformClick();
                    break;
                case Keys.Alt | Keys.Right:
                    pdfPanel2.toolStripButtonNextPage.PerformClick();
                    break;
            }
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            // Initialize the page pair list.
            pagePairList = new PagePairList();

            // Start cyclic timer.
            timerCyclic.Enabled = true;

            // First, the text mode.
            toolStripButtonTextmode.PerformClick();
            // First, one page fits.
            toolStripButtonFitOnePage.PerformClick();
            PdfPanelAutoSize();
        }

        private void Panel1_SizeChanged(object sender, EventArgs e)
        {
            PdfPanelAutoSize();
        }

        private void PdfPanelAutoSize()
        {
            pdfPanel1.Left = 0 + pdfPanel1.Margin.Left;
            pdfPanel1.Width = panelBoth.Width / 2 - pdfPanel1.Margin.Horizontal;

            pdfPanel2.Left = panelBoth.Width / 2 + pdfPanel2.Margin.Left;
            pdfPanel2.Width = panelBoth.Width / 2 - pdfPanel2.Margin.Horizontal;
        }

        private void TimerButton_Tick(object sender, EventArgs e)
        {
            timerButton.Interval = 100;

            if (zoomOut)
            {
                ZoomOut();
            }

            if (zoomIn)
            {
                ZoomIn();
            }
        }

        private void timerCyclic_Tick(object sender, EventArgs e)
        {
            if (pdfPanel1.pdfViewer.Renderer.FlashTextAlpha > 0)
            {
                pdfPanel1.pdfViewer.Renderer.CalcFlashTextAlpha();
                pdfPanel2.pdfViewer.Renderer.CalcFlashTextAlpha();
            }
        }

        private void ComparePage()
        {
            Console.WriteLine("Compare Page Button click!");

            if ((pdfPanel1.pdfViewer.Document == null) || (pdfPanel2.pdfViewer.Document == null))
            {
                toolStripLabelResult.Text = "0.0";
                return;
            }

            var stopwatch = new System.Diagnostics.Stopwatch();

            int page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
            int page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;

            ComparePage(stopwatch, page1, page2);

            stopwatch.Stop();
            Console.WriteLine("Marker:{0}", stopwatch.Elapsed);
            stopwatch.Start();

            if (stopwatch.ElapsedMilliseconds < 50)
            {
                Thread.Sleep(30);
            }

            // Draw with the markers.
            pdfPanel1.Update();
            pdfPanel2.Update();

            // Do not revert the page.
            // pdfPanel1.pdfViewer.Renderer.Page = page1;
            // pdfPanel2.pdfViewer.Renderer.Page = page2;

            stopwatch.Stop();
            Console.WriteLine("Draw:{0}", stopwatch.Elapsed);

            toolStripLabelResult.Text = String.Format("{0:0.0}", stopwatch.ElapsedMilliseconds / 1000.0);
        }

        private void CompareBookmark()
        {
            Console.WriteLine("Compare Bookmark Button click!");

            if ((pdfPanel1.pdfViewer.Document == null) || (pdfPanel2.pdfViewer.Document == null))
            {
                toolStripLabelResult.Text = "0.0";
                return;
            }

            var stopwatch = new System.Diagnostics.Stopwatch();

            int page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
            int page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;

            (int startPage1, int endPage1) = pdfPanel1.GetBookmarkPages(page1);
            (int startPage2, int endPage2) = pdfPanel2.GetBookmarkPages(page2);

            // If a bookmark cannot be obtained, make it the current page.
            if (startPage1 < 0)
            {
                startPage1 = page1;
                endPage1 = page1;
            }
            if (startPage2 < 0)
            {
                startPage2 = page2;
                endPage2 = page2;
            }

            Console.WriteLine("CompareBookmark():({0},{1})-({2},{3})", startPage1+1, endPage1+1, startPage2+1, endPage2+1);


            ComparePages(stopwatch, startPage1, endPage1, startPage2, endPage2);

            stopwatch.Stop();
            Console.WriteLine("Marker:{0}", stopwatch.Elapsed);
            stopwatch.Start();

            if (stopwatch.ElapsedMilliseconds < 50)
            {
                Thread.Sleep(30);
            }

            // Draw with the markers.
            pdfPanel1.Update();
            pdfPanel2.Update();

            // Revert the page.
            pdfPanel1.pdfViewer.Renderer.Page = page1;
            pdfPanel2.pdfViewer.Renderer.Page = page2;
            SetFlashPage(page1, page2);

            stopwatch.Stop();
            Console.WriteLine("Draw:{0}", stopwatch.Elapsed);

            toolStripLabelResult.Text = String.Format("{0:0.0}", stopwatch.ElapsedMilliseconds / 1000.0);
        }

        private void CompareBook()
        {
            Console.WriteLine("Compare Book Button click!");

            if ((pdfPanel1.pdfViewer.Document == null) || (pdfPanel2.pdfViewer.Document == null))
            {
                toolStripLabelResult.Text = "0.0";
                return;
            }

            var stopwatch = new System.Diagnostics.Stopwatch();

            int page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
            int page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;

            int startPage1 = 0;
            int endPage1 = pdfPanel1.pdfViewer.Document.PageCount - 1;
            int startPage2 = 0;
            int endPage2 = pdfPanel2.pdfViewer.Document.PageCount - 1;

            Console.WriteLine("CompareBook():({0},{1})-({2},{3})", startPage1+1, endPage1+1, startPage2+1, endPage2+1);

            Cursor.Current = Cursors.WaitCursor;
            ComparePages(stopwatch, startPage1, endPage1, startPage2, endPage2);
            Cursor.Current = Cursors.Default;

            stopwatch.Stop();
            Console.WriteLine("Marker:{0}", stopwatch.Elapsed);
            stopwatch.Start();

            if (stopwatch.ElapsedMilliseconds < 50)
            {
                Thread.Sleep(30);
            }

            // Draw with the markers.
            pdfPanel1.Update();
            pdfPanel2.Update();

            // Revert the page.
            pdfPanel1.pdfViewer.Renderer.Page = page1;
            pdfPanel2.pdfViewer.Renderer.Page = page2;
            SetFlashPage(page1, page2);

            stopwatch.Stop();
            Console.WriteLine("Draw:{0}", stopwatch.Elapsed);

            toolStripLabelResult.Text = String.Format("{0:0.0}", stopwatch.ElapsedMilliseconds / 1000.0);
        }


        private bool ComparePage(System.Diagnostics.Stopwatch stopwatch, int page1, int page2)
        {
            bool found_diff = ComparePages(stopwatch, page1, page1, page2, page2);

            // Remember the last page compared.
            FindDiffPage1 = page1;
            FindDiffPage2 = page2;

            SetFlashPage(page1, page2);

            return found_diff;
        }


        private bool ComparePages(System.Diagnostics.Stopwatch stopwatch, int startPage1, int endPage1, int startPage2, int endPage2)
        {
            // Once compared, clear the page number and diff markers.
            // It's translucent and overwritten, so if you don't erase it, it will get darker.
            var oneFullPage1 = pdfPanel1.pdfViewer.Renderer.CompareBounds.IsEmpty;
            var oneFullPage2 = pdfPanel2.pdfViewer.Renderer.CompareBounds.IsEmpty;
            var textData1 = new PageTextList();
            var textData2 = new PageTextList();

            for (int i = startPage1; i <= endPage1; i++)
            {
                pdfPanel1.ClearDiffMarker(i, oneFullPage1);
                textData1.Add(pdfPanel1.GetPageTextData(i));
            }
            for (int i = startPage2; i <= endPage2; i++)
            {
                pdfPanel2.ClearDiffMarker(i, oneFullPage2);
                textData2.Add(pdfPanel2.GetPageTextData(i));
            }
            pagePairList.Clear(startPage1, endPage1, startPage2, endPage2);

            // Draw without the marker.
            pdfPanel1.Update();
            pdfPanel2.Update();

            //stopwatch.Stop();
            //Console.WriteLine("Clear:{0}", stopwatch.Elapsed);
            //stopwatch.Start();


            List<PdfTextSpan> index1 = new List<PdfTextSpan>();
            List<PdfTextSpan> index2 = new List<PdfTextSpan>();

            stopwatch.Stop();
            Console.WriteLine("Get:{0}", stopwatch.Elapsed);

            stopwatch.Start();

            diff_match_patch dmp;
            List<Diff> diffs;

            int diffType = toolStripComboBoxDiffType.SelectedIndex;
            switch (diffType)
            {
                case 0:     // Google Diff - Character
                    dmp = new diff_match_patch();
                    diffs = dmp.diff_main(textData1.Text, textData2.Text);
                    break;
                case 1:     // Google Diff - Semantic
                    dmp = new diff_match_patch();
                    diffs = dmp.diff_main(textData1.Text, textData2.Text);
                    dmp.diff_cleanupSemantic(diffs);
                    break;

                default:
                    throw new Exception();
            }

            ExtractDiffSpan2(index1, index2, diffs, textData1, textData2);
            UpdateComparedPage2(diffs, textData1, textData2);

            stopwatch.Stop();
            Console.WriteLine("Diff:{0}", stopwatch.Elapsed);
            stopwatch.Start();


            pdfPanel1.AddDiffMarker(index1);
            pdfPanel2.AddDiffMarker(index2);

            // If there is a difference on either page.
            bool found_diff = (index1.Count > 0) || (index2.Count > 0);

            return found_diff;
        }

        private void ExtractDiffSpan2(List<PdfTextSpan> spanList1, List<PdfTextSpan> spanList2, List<Diff> diffs, PageTextList textData1, PageTextList textData2)
        {
            if (diffs.Count() > 0)
            {
                int offset1 = 0;
                int offset2 = 0;
                int count;

                foreach (Diff diff in diffs)
                {
                    count = diff.text.Length;
                    switch (diff.operation)
                    {
                        case Operation.EQUAL:
                            formDiffInfo.WriteText(diff.text, Color.Black);
                            offset1 += count;
                            offset2 += count;
                            break;
                        case Operation.INSERT:
                            formDiffInfo.WriteText(diff.text, Color.Blue);
                            AddSpanList(spanList2, textData2, offset2, count);
                            offset2 += count;
                            break;
                        case Operation.DELETE:
                            formDiffInfo.WriteText(diff.text, Color.Red);
                            AddSpanList(spanList1, textData1, offset1, count);
                            offset1 += count;
                            break;
                    }
                }
                formDiffInfo.WriteText("\r\n", Color.Black);
                formDiffInfo.ScrollToCaret();
                formDiffInfo.ToggleBackColor();
            }
        }

        private void AddSpanList(List<PdfTextSpan> spanList, PageTextList textList, int offset, int count)
        {
            // Extract a range of CompareBounds. Convert from offset to offset within the page.
            int page, pagePos;
            int item_page;
            int item_offset;
            int item_count = 0;

            (item_page, item_offset) = textList.GetPagePos(offset);

            for (int i = 0; i < count; i++)
            {
                (page, pagePos) = textList.GetPagePos(offset + i);

                // Extract consecutive characters from the original PDF text.
                if ((pagePos != item_offset + item_count) || (page != item_page))
                {
                    spanList.Add(new PdfTextSpan(item_page, item_offset, item_count));
                    item_page = page;
                    item_offset = pagePos;
                    item_count = 1;
                }
                else
                {
                    item_count++;
                }
            }

            if (item_count > 0)
            {
                spanList.Add(new PdfTextSpan(item_page, item_offset, item_count));
            }
        }

        /// <summary>
        /// Records which pages correspond to each other based on the differences between two text lists.
        /// </summary>
        /// <remarks>This method updates the page pairings of the two documents by splitting the text difference list
        /// at page boundaries and preserving the text.</remarks>
        /// <param name="diffs">A list of text differences representing changes between the two documents.</param>
        /// <param name="textList1">The text list representing the first document, used to determine page boundaries and extract text spans.</param>
        /// <param name="textList2">The text list representing the second document, used to determine page boundaries and extract text spans.</param>
        private void UpdateComparedPage2(List<Diff> diffs, PageTextList textList1, PageTextList textList2)
        {
            // Step1. Get the starting offset of each page
            int offset1 = 0, offset2 = 0;                       // Current position in the entire text
            int startOffset1 = 0, startOffset2 = 0;             // Start position of the current TextSpan
            int headOffset1 = 0, headOffset2 = 0;               // Start position of the current page
            int previousOffset1 = 0, previousOffset2 = 0;       // Store the offset to append to the previously compared TextSpan

            (int page1, _) = textList1.GetPagePos(offset1);     // Page number currently being processed
            (int page2, _) = textList2.GetPagePos(offset2);
            int previousPage1 = page1;                          // Store the page to append to the previously compared TextSpan
            int previousPage2 = page2;
            int nextOffset1 = textList1.GetOffset(page1 + 1);   // Start position of the next page
            int nextOffset2 = textList2.GetOffset(page2 + 1);
            bool flag = false;

            // Step2. Process the difference list
            foreach (Diff diff in diffs)
            {
                int count = diff.text.Length;

                while (count > 0)
                {
                    // Detect page boundaries
                    int length1 = GetPageBreakForFile1(diff, offset1, count, nextOffset1);
                    int length2 = GetPageBreakForFile2(diff, offset2, count, nextOffset2);
                    int minLength = Math.Min(length1, length2);

                    // Console.WriteLine("F1P{0}, offs={1}, count={2}, len={3}, nextOffs={4}", page1, offset1, count, length1, nextOffset1);
                    // Console.WriteLine("F2P{0}, offs={1}, count={2}, len={3}, nextOffs={4}", page2, offset2, count, length2, nextOffset2);

                    if (minLength == int.MaxValue)
                    {
                        // Neither page reaches its boundary within count steps.
                        // Slide by count, which is the length of diff.text.
                        SlideOffsetByOperation(diff, count, ref offset1, ref offset2);
                        count = 0;
                        flag = true;
                    }
                    else
                    {
                        // One or both pages reach their boundary within count steps.
                        // Slide by the minLength, which is the shorter distance to the boundary.
                        SlideOffsetByOperation(diff, minLength, ref offset1, ref offset2);
                        // Console.WriteLine($"[F1p{page1+1}]" + textList1.GetText(startOffset1, offset1));
                        // Console.WriteLine($"[F2p{page2+1}]" + textList2.GetText(startOffset2, offset2));

                        int page1a = page1;
                        int page2a = page2;
                        int startOffset1a = startOffset1;
                        int startOffset2a = startOffset2;

                        if ((minLength == length1) && (minLength == length2))
                        {
                            page1++;
                            page2++;
                            nextOffset1 = textList1.GetOffset(page1 + 1);
                            nextOffset2 = textList2.GetOffset(page2 + 1);
                        }
                        else if (minLength == length1)
                        {
                            page1++;
                            headOffset1 = nextOffset1;
                            nextOffset1 = textList1.GetOffset(page1 + 1);

                            // Only the diff from page 1 remains, so pair it with the preceding page 2.
                            if ((length1 > 0) && (offset2 == headOffset2))
                            {
                                page2a = previousPage2;
                                startOffset1a = previousOffset1;
                                startOffset2a = previousOffset2;
                            }
                        }
                        else if (minLength == length2)
                        {
                            page2++;
                            headOffset2 = nextOffset2;
                            nextOffset2 = textList2.GetOffset(page2 + 1);

                            // Only the diff from page 2 remains, so pair it with the preceding page 1.
                            if ((length2 > 0) && (offset1 == headOffset1))
                            {
                                page1a = previousPage1;
                                startOffset1a = previousOffset1;
                                startOffset2a = previousOffset2;
                            }
                        }

                        var span1 = textList1.GetTextSpans(startOffset1a, offset1);
                        var span2 = textList2.GetTextSpans(startOffset2a, offset2);
                        pagePairList.SetPagePair(page1a, page2a, span1, span2);
                        pdfPanel1.SetComparedPage(page1a, page2a);
                        pdfPanel2.SetComparedPage(page2a, page1a);

                        previousPage1 = page1a;
                        previousPage2 = page2a;
                        previousOffset1 = startOffset1a;
                        previousOffset2 = startOffset2a;
                        startOffset1 = offset1;
                        startOffset2 = offset2;
                        count -= minLength;
                        flag = false;
                    }
                }
            }

            if (flag)
            {
                var span1 = textList1.GetTextSpans(startOffset1, offset1);
                var span2 = textList2.GetTextSpans(startOffset2, offset2);
                pagePairList.SetPagePair(page1, page2, span1, span2);
                pdfPanel1.SetComparedPage(page1, page2);
                pdfPanel2.SetComparedPage(page2, page1);
            }

        }

        /// <summary>
        /// Return the length up to the page boundary.
        /// If the page boundary is reached, return the distance from the current position to the boundary.
        /// If the page boundary is not reached, return int.MaxValue.
        /// </summary>
        /// <param name="diff">the target diff</param>
        /// <param name="offset">the target offset position</param>
        /// <param name="count">the target length</param>
        /// <param name="nextOffset">the next page boundary</param>
        /// <returns>the distance to the next page boundary.</returns>
        private int GetPageBreakForFile1(Diff diff, int offset, int count, int nextOffset)
        {
            // text exists in File1.
            if ((diff.operation == Operation.EQUAL) || (diff.operation == Operation.DELETE))
            {
                return GetPageBreak(offset, count, nextOffset);
            }

            // If File1 does not contain any text, it returns a value that is ignored.
            return int.MaxValue;
        }

        private int GetPageBreakForFile2(Diff diff, int offset, int count, int nextOffset)
        {
            // text exists in File2.
            if ((diff.operation == Operation.EQUAL) || (diff.operation == Operation.INSERT))
            {
                return GetPageBreak(offset, count, nextOffset);
            }

            // If File2 does not contain any text, it returns a value that is ignored.
            return int.MaxValue;
        }

        /// <summary>
        /// Returns the length of the page break, if any.
        /// </summary>
        /// <param name="offset">Current offset in the text</param>
        /// <param name="count">Number of characters to process</param>
        /// <param name="nextOffset">Next page offset</param>
        /// <returns>Page break length, or int.MaxValue if no break within count</returns>
        private int GetPageBreak(int offset, int count, int nextOffset)
        {
            // Get the page break position.
            if (offset + count >= nextOffset)
            {
                return nextOffset - offset;
            }
            return int.MaxValue;
        }

        private void SlideOffsetByOperation(Diff diff, int slide, ref int offset1, ref int offset2)
        {
            switch (diff.operation)
            {
                case Operation.EQUAL:
                    offset1 += slide;
                    offset2 += slide;
                    break;
                case Operation.INSERT:
                    // Present only in the 2nd text
                    offset2 += slide;
                    break;
                case Operation.DELETE:
                    // Present only in the 1st text
                    offset1 += slide;
                    break;
            }
        }


        private void SetFlashPage(int page1, int page2)
        {
            PagePair pair = pagePairList.GetPagePair(page1, page2);
            if (pair != null)
            {
                pdfPanel1.pdfViewer.Renderer.SetFlashTextSpans(pair.Span1);
                pdfPanel2.pdfViewer.Renderer.SetFlashTextSpans(pair.Span2);
            }
        }


        private void ButtonBookmark_Click(object sender, EventArgs e)
        {
            pdfPanel1.ToggleBookmarks();
            pdfPanel2.ToggleBookmarks();
        }

        private void ButtonRotateLeft_Click(object sender, EventArgs e)
        {
            rotation--;
            if (rotation < PdfRotation.Rotate0)
            {
                rotation = PdfRotation.Rotate270;
            }

            pdfPanel1.Rotate(rotation);
            pdfPanel2.Rotate(rotation);
        }

        private void ButtonRotateRight_Click(object sender, EventArgs e)
        {
            rotation++;
            if (rotation > PdfRotation.Rotate270)
            {
                rotation = PdfRotation.Rotate0;
            }

            pdfPanel1.Rotate(rotation);
            pdfPanel2.Rotate(rotation);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Copy SelectedText of focused pdfPanel.
            // Tag is set when just focused on pdfPanel.
            DataObject data = new DataObject();

            if ((string)Tag == "pdfPanel1")
            {
                var text = pdfPanel1.pdfViewer.Renderer.SelectedText;
                if (text?.Length > 0)
                {
                    data.SetData(DataFormats.Text, text);
                }

                if (pdfPanel1.toolStripTextBoxFile.Focused)
                {
                    var text2 = pdfPanel1.toolStripTextBoxFile.SelectedText;
                    if (text2?.Length > 0)
                    {
                        data.SetData(DataFormats.Text, text2);
                        Clipboard.SetDataObject(data, true);
                        return;
                    }
                }

                if (pdfPanel1.toolStripTextBoxPageInput.Focused)
                {
                    var text3 = pdfPanel1.toolStripTextBoxPageInput.SelectedText;
                    if (text3?.Length > 0)
                    {
                        data.SetData(DataFormats.Text, text3);
                        Clipboard.SetDataObject(data, true);
                        return;
                    }
                }
            }

            if ((string)Tag == "pdfPanel2")
            {
                var text = pdfPanel2.pdfViewer.Renderer.SelectedText;
                if (text?.Length > 0)
                {
                    data.SetData(DataFormats.Text, text);
                }

                if (pdfPanel2.toolStripTextBoxFile.Focused)
                {
                    var text2 = pdfPanel2.toolStripTextBoxFile.SelectedText;
                    if (text2?.Length > 0)
                    {
                        data.SetData(DataFormats.Text, text2);
                        Clipboard.SetDataObject(data, true);
                        return;
                    }
                }

                if (pdfPanel2.toolStripTextBoxPageInput.Focused)
                {
                    var text3 = pdfPanel2.toolStripTextBoxPageInput.SelectedText;
                    if (text3?.Length > 0)
                    {
                        data.SetData(DataFormats.Text, text3);
                        Clipboard.SetDataObject(data, true);
                        return;
                    }
                }
            }

            // At the same time, copy the comparison image.
            if ((pdfPanel1.pdfViewer.Document != null) || (pdfPanel2.pdfViewer.Document != null))
            {
                Bitmap bitmap = new Bitmap(panelBoth.ClientSize.Width, panelBoth.ClientSize.Height);
                panelBoth.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                reduceColor = toolStripMenuItemEnableReduceColorCopy.Checked;
                if (reduceColor)
                {
                    int finalCol = (int)Properties.Settings.Default["ReduceFinalColor"];
                    int fixedCol = (int)Properties.Settings.Default["ReduceFixedColor"];
                    ImageProcess imgp = new ImageProcess(finalCol, fixedCol);
                    imgp.CountColors(bitmap);
                    imgp.Quantize256(bitmap, false);
                    //imgp.CountColors(bitmap);
                }
                data.SetData(DataFormats.Bitmap, bitmap);
            }

            Clipboard.SetDataObject(data, true);
        }

        private void CopyFile1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pdfPanel1.pdfViewer.Document != null)
            {
                Bitmap bitmap = new Bitmap(pdfPanel1.ClientSize.Width, pdfPanel1.ClientSize.Height);
                pdfPanel1.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                reduceColor = toolStripMenuItemEnableReduceColorCopy.Checked;
                if (reduceColor)
                {
                    int finalCol = (int)Properties.Settings.Default["ReduceFinalColor"];
                    int fixedCol = (int)Properties.Settings.Default["ReduceFixedColor"];
                    ImageProcess imgp = new ImageProcess(finalCol, fixedCol);
                    imgp.CountColors(bitmap);
                    imgp.Quantize256(bitmap, false);
                    //imgp.CountColors(bitmap);
                }
                Clipboard.SetImage(bitmap);
            }
        }

        private void CopyFile2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pdfPanel2.pdfViewer.Document != null)
            {
                Bitmap bitmap = new Bitmap(pdfPanel2.ClientSize.Width, pdfPanel2.ClientSize.Height);
                pdfPanel2.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                reduceColor = toolStripMenuItemEnableReduceColorCopy.Checked;
                if (reduceColor)
                {
                    int finalCol = (int)Properties.Settings.Default["ReduceFinalColor"];
                    int fixedCol = (int)Properties.Settings.Default["ReduceFixedColor"];
                    ImageProcess imgp = new ImageProcess(finalCol, fixedCol);
                    imgp.CountColors(bitmap);
                    imgp.Quantize256(bitmap, false);
                    //imgp.CountColors(bitmap);
                }
                Clipboard.SetImage(bitmap);
            }
        }

        private void CopyBookmarks1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = pdfPanel1.GetBookmarksText();
            if (text != null)
            {
                Clipboard.SetText(text);
            }
        }

        private void CopyBookmarks2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = pdfPanel2.GetBookmarksText();
            if (text != null)
            {
                Clipboard.SetText(text);
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdfPanel1.toolStripButtonOpen.PerformClick();
            pdfPanel2.toolStripButtonOpen.PerformClick();
        }

        private void usageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsage form = new FormUsage();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void outputDebugLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutputDebugLog();
        }

        private void AboutPDFCompToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void ComparePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComparePage();
        }

        private void compareBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompareBookmark();
        }

        private void compareBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompareBook();
        }

        private void ClearMarker1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdfPanel1.ClearDiffMarker(pdfPanel1.pdfViewer.Renderer.ComparisonPage, true);
        }

        private void ClearMarker2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdfPanel2.ClearDiffMarker(pdfPanel2.pdfViewer.Renderer.ComparisonPage, true);
        }

        private void clearBook1MarkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdfPanel1.ClearAllDiffMarker();
        }

        private void clearBook2MarkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdfPanel2.ClearAllDiffMarker();
        }

        private void FindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formFind == null)
            {
                formFind = new FormFind();
                formFind._pdfPanel1 = pdfPanel1;
                formFind._pdfPanel2 = pdfPanel2;
                formFind.StartPosition = FormStartPosition.Manual;
                formFind.Location = Location + formFind.Size;
            }
            formFind.Hide();
            formFind.Show(this);
        }

        private void FindDiffByMode()
        {
            Console.WriteLine("Find diff Button click!");

            if ((pdfPanel1.pdfViewer.Document == null) || (pdfPanel2.pdfViewer.Document == null))
            {
                toolStripLabelResult.Text = "0.0";
                return;
            }

            var stopwatch = new System.Diagnostics.Stopwatch();

            int pages = Math.Max(pdfPanel1.pdfViewer.Document.PageCount, pdfPanel2.pdfViewer.Document.PageCount);
            int page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
            int page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;
            int startpage1 = pdfPanel1.pdfViewer.Renderer.Page;
            int startpage2 = pdfPanel2.pdfViewer.Renderer.Page;

            // Search for diff pages.
            for (int i = page1; i < pages; i++)
            {
                if ((pdfPanel1.GetComparedPage(page1) < 0) || (pdfPanel2.GetComparedPage(page2) < 0))
                {
                    CompareByMode();
                    if (pdfPanel1.pdfViewer.Renderer.HasMarkers(page1) || pdfPanel2.pdfViewer.Renderer.HasMarkers(page2))
                    {
                        break;
                    }
                }

                bool hold_page1 = page1 == pdfPanel2.GetComparedPage(page2 + 1);
                bool hold_page2 = page2 == pdfPanel1.GetComparedPage(page1 + 1);

                if (!hold_page1)
                {
                    pdfPanel1.NextPage();
                }
                if (!hold_page2)
                {
                    pdfPanel2.NextPage();
                }

                page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
                page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;

                Console.WriteLine("\t\t{1}{3}\t{2}{4}", i, page1+1, page2+1, 
                                                              pdfPanel1.pdfViewer.Renderer.HasMarkers(page1) ? "*" : " ",
                                                              pdfPanel2.pdfViewer.Renderer.HasMarkers(page2) ? "*" : " ");

                if (pdfPanel1.pdfViewer.Renderer.HasMarkers(page1) || pdfPanel2.pdfViewer.Renderer.HasMarkers(page2))
                {
                    break;
                }
            }

            stopwatch.Stop();

            SetFlashPage(page1, page2);

            toolStripLabelResult.Text = String.Format("{0:0.0}", stopwatch.ElapsedMilliseconds / 1000.0);

        }

        private void PrevDiffByMode()
        {
            Console.WriteLine("Prev diff Button click!");

            if ((pdfPanel1.pdfViewer.Document == null) || (pdfPanel2.pdfViewer.Document == null))
            {
                toolStripLabelResult.Text = "0.0";
                return;
            }

            var stopwatch = new System.Diagnostics.Stopwatch();

            int pages = Math.Max(pdfPanel1.pdfViewer.Document.PageCount, pdfPanel2.pdfViewer.Document.PageCount);
            int page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
            int page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;
            int startpage1 = pdfPanel1.pdfViewer.Renderer.Page;
            int startpage2 = pdfPanel2.pdfViewer.Renderer.Page;

            // Search for diff pages.
            for (int i = page1; i >= 0; i--)
            {
                if ((pdfPanel1.GetComparedPage(page1-1) < 0) || (pdfPanel2.GetComparedPage(page2-1) < 0))
                {
                    pdfPanel1.PrevPage();
                    pdfPanel2.PrevPage();
                    CompareByMode();
                    pdfPanel1.pdfViewer.Renderer.Page = page1;
                    pdfPanel2.pdfViewer.Renderer.Page = page2;
                }

                bool hold_page1 = page1 == pdfPanel2.GetComparedPage(page2 - 1);
                bool hold_page2 = page2 == pdfPanel1.GetComparedPage(page1 - 1);

                if (!hold_page1)
                {
                    pdfPanel1.PrevPage();
                }
                if (!hold_page2)
                {
                    pdfPanel2.PrevPage();
                }

                page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
                page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;

                Console.WriteLine("\t\t{1}{3}\t{2}{4}", i, page1+1, page2+1,
                                              pdfPanel1.pdfViewer.Renderer.HasMarkers(page1) ? "*" : " ",
                                              pdfPanel2.pdfViewer.Renderer.HasMarkers(page2) ? "*" : " ");

                if (pdfPanel1.pdfViewer.Renderer.HasMarkers(page1) || pdfPanel2.pdfViewer.Renderer.HasMarkers(page2))
                {
                    break;
                }
            }

            stopwatch.Stop();

            SetFlashPage(page1, page2);

            toolStripLabelResult.Text = String.Format("{0:0.0}", stopwatch.ElapsedMilliseconds / 1000.0);

        }

        private void toolStripMenuItemEnableReduceColorCopy_Click(object sender, EventArgs e)
        {
            toolStripMenuItemEnableReduceColorCopy.Checked ^= true;
            Properties.Settings.Default["EnableColorReductionCopy"] = toolStripMenuItemEnableReduceColorCopy.Checked;
        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            toolStripMenuItemEnableReduceColorCopy.Checked = (bool)Properties.Settings.Default["EnableColorReductionCopy"];
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save(); // Saves settings in application configuration file.
        }

        private void toolStripButtonBookmarks_Click(object sender, EventArgs e)
        {
            pdfPanel1.ToggleBookmarks();
            pdfPanel2.ToggleBookmarks();
        }

        public void PanelBookmarkClosed(object sender)
        {
        	// When you press the close button on a bookmark,
        	// the other bookmark will also be closed.
            if (sender == pdfPanel1)
            {
                pdfPanel2.SetShowBookmarks(false);
            }

            if (sender == pdfPanel2)
            {
                pdfPanel1.SetShowBookmarks(false);
            }
        }

        private void toolStripButtonNextPages_Click(object sender, EventArgs e)
        {
            pdfPanel1.NextPage();
            pdfPanel2.NextPage();
        }

        private void toolStripButtonPrevPages_Click(object sender, EventArgs e)
        {
            pdfPanel1.PrevPage();
            pdfPanel2.PrevPage();
        }

        private void toolStripButtonPanel1Prev_Click(object sender, EventArgs e)
        {
            pdfPanel1.PrevPage();
        }

        private void toolStripButtonPanel1Next_Click(object sender, EventArgs e)
        {
            pdfPanel1.NextPage();
        }

        private void toolStripButtonPanel2Prev_Click(object sender, EventArgs e)
        {
            pdfPanel2.PrevPage();
        }

        private void toolStripButtonPanel2Next_Click(object sender, EventArgs e)
        {
            pdfPanel2.NextPage();
        }

        private void toolStripButtonRotateAnticlockwise_Click(object sender, EventArgs e)
        {
            rotation--;
            if (rotation < PdfRotation.Rotate0)
            {
                rotation = PdfRotation.Rotate270;
            }

            pdfPanel1.Rotate(rotation);
            pdfPanel2.Rotate(rotation);
        }

        private void toolStripButtonRotateClockwise_Click(object sender, EventArgs e)
        {
            rotation++;
            if (rotation > PdfRotation.Rotate270)
            {
                rotation = PdfRotation.Rotate0;
            }

            pdfPanel1.Rotate(rotation);
            pdfPanel2.Rotate(rotation);
        }

        private void toolStripButtonHandmode_Click(object sender, EventArgs e)
        {
            // like RadioButton
            toolStripButtonHandmode.BackColor = SystemColors.GradientActiveCaption;
            toolStripButtonTextmode.BackColor = SystemColors.Control;
            toolStripButtonBoundsmode.BackColor = SystemColors.Control;

            pdfPanel1.pdfViewer.Renderer.CursorMode = PdfCursorMode.Pan;
            pdfPanel2.pdfViewer.Renderer.CursorMode = PdfCursorMode.Pan;
            pdfPanel1.pdfViewer.Renderer.MouseWheelMode = MouseWheelMode.PanAndZoom;
            pdfPanel2.pdfViewer.Renderer.MouseWheelMode = MouseWheelMode.PanAndZoom;
        }

        private void toolStripButtonTextmode_Click(object sender, EventArgs e)
        {
            // like RadioButton
            toolStripButtonHandmode.BackColor = SystemColors.Control;
            toolStripButtonTextmode.BackColor = SystemColors.GradientActiveCaption;
            toolStripButtonBoundsmode.BackColor = SystemColors.Control;

            pdfPanel1.pdfViewer.Renderer.CursorMode = PdfCursorMode.TextSelection;
            pdfPanel2.pdfViewer.Renderer.CursorMode = PdfCursorMode.TextSelection;
            pdfPanel1.pdfViewer.Renderer.MouseWheelMode = MouseWheelMode.PanAndZoom;
            pdfPanel2.pdfViewer.Renderer.MouseWheelMode = MouseWheelMode.PanAndZoom;
        }

        private void toolStripButtonBoundsmode_Click(object sender, EventArgs e)
        {
            // like RadioButton
            toolStripButtonHandmode.BackColor = SystemColors.Control;
            toolStripButtonTextmode.BackColor = SystemColors.Control;
            toolStripButtonBoundsmode.BackColor = SystemColors.GradientActiveCaption;

            pdfPanel1.pdfViewer.Renderer.CursorMode = PdfCursorMode.Bounds;
            pdfPanel2.pdfViewer.Renderer.CursorMode = PdfCursorMode.Bounds;
            pdfPanel1.pdfViewer.Renderer.MouseWheelMode = MouseWheelMode.PanAndZoom;
            pdfPanel2.pdfViewer.Renderer.MouseWheelMode = MouseWheelMode.PanAndZoom;
        }

        private void toolStripTrackBarZoom_ValueChanged(object sender, EventArgs e)
        {
            zoom = GetZoomFromTBValue(toolStripTrackBarZoom.Value);

            toolStripLabelZoom.Text = String.Format("{0} %", zoom * 100);

            // If holdZoom=true, adjusting the trackbar will not change the zoom level.
            if (!holdZoom)
            {
                pdfPanel1.SetZoom(zoom);
                pdfPanel2.SetZoom(zoom);
            }
        }

        private double GetZoomFromTBValue(int value)
        {
            if (value >= 0)
            {
                // Zoom in (1.0 - 9.0x)
                if (value <= 10)
                {
                    zoom = 1.0 + value * ZoomInScale;
                }
                else if (value <= 20)
                {
                    zoom = 2.0 + (value - 10) * ZoomInScale * 2;
                }
                else
                {
                    zoom = 4.0 + (value - 20) * ZoomInScale * 5;
                }
            }
            else
            {
                // Zoom out (1.0 - 0.01x)
                if (value >= -4)
                {
                    zoom = 1.0 + value * ZoomOutScale * 5;
                }
                else if (value >= -22)
                {
                    zoom = 0.8 + (value + 4) * ZoomOutScale * 3;
                }
                else
                {
                    zoom = 0.26 + (value + 22) * ZoomOutScale * 2;
                }
            }

            return zoom;
        }

        private int GetTBValueFromZoom(double inZoom)
        {
            int value = 0;

            if (inZoom >= 1.0)
            {
                // Zoom in (1.0 - 9.0x)
                if (inZoom <= 2.0)
                {
                    value = (int)Math.Round(0 + (inZoom - 1.0) / (ZoomInScale));
                }
                else if (inZoom <= 4.0)
                {
                    value = (int)Math.Round(10 + (inZoom - 2.0) / (ZoomInScale * 2));
                }
                else
                {
                    value = (int)Math.Round(20 + (inZoom - 4.0) / (ZoomInScale * 5));
                }
            }
            else
            {
                // Zoom out (1.0 - 0.01x)
                if (inZoom >= 0.8)
                {
                    value = (int)Math.Round(0 + (inZoom - 1.0) / (ZoomOutScale * 5));
                }
                else if (inZoom >= 0.26)
                {
                    value = (int)Math.Round(-4 + (inZoom - 0.8) / (ZoomOutScale * 3));
                }
                else
                {
                    value = (int)Math.Round(-22 + (inZoom - 0.26) / (ZoomOutScale * 2));
                }
            }
            return value;
        }

        public void AdjustTrackBarZoom(double inZoom)
        {
            // Adjusting the trackbar value when wheel zoomed in the PdfPanel.
            int value = GetTBValueFromZoom(inZoom);

            holdZoom = true;
            toolStripTrackBarZoom.Value = value;
            holdZoom = false;
        }

        private void ZoomIn()
        {
            if (toolStripTrackBarZoom.Value < toolStripTrackBarZoom.Maximum)
            {
                toolStripTrackBarZoom.Value++;
            }
        }

        private void ZoomOut()
        {
            if (toolStripTrackBarZoom.Value > toolStripTrackBarZoom.Minimum)
            {
                toolStripTrackBarZoom.Value--;
            }
        }

        private void toolStripButtonZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            ZoomIn();
            zoomIn = true;
            timerButton.Interval = 250;
            timerButton.Enabled = true;
        }

        private void toolStripButtonZoomIn_MouseUp(object sender, MouseEventArgs e)
        {
            zoomIn = false;
            timerButton.Enabled = false;
        }

        private void toolStripButtonZoomIn_MouseLeave(object sender, EventArgs e)
        {
            // Stop zooming when the mouse leaves the button.
            // Because the mouse-up event does not occur.
            zoomIn = false;
            timerButton.Enabled = false;
        }

        private void toolStripButtonZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            ZoomOut();
            zoomOut = true;
            timerButton.Interval = 250;
            timerButton.Enabled = true;
        }

        private void toolStripButtonZoomOut_MouseUp(object sender, MouseEventArgs e)
        {
            zoomOut = false;
            timerButton.Enabled = false;
        }

        private void toolStripButtonZoomOut_MouseLeave(object sender, EventArgs e)
        {
            // Stop zooming when the mouse leaves the button.
            // Because the mouse-up event does not occur.
            zoomOut = false;
            timerButton.Enabled = false;
        }

        private void toolStripButtonPrevDiff_Click(object sender, EventArgs e)
        {
			PrevDiffByMode();
        }

        private void toolStripButtonNextDiff_Click(object sender, EventArgs e)
        {
			FindDiffByMode();
        }

        private void toolStripButtonFitOnePage_Click(object sender, EventArgs e)
        {
            // like RadioButton
            toolStripButtonFitOnePage.BackColor = SystemColors.GradientActiveCaption;
            toolStripButtonFitWidth.BackColor = SystemColors.Control;

            // zoom 100 %
            toolStripTrackBarZoom.Value = 0;

            pdfPanel1.FitHeight();
            pdfPanel2.FitHeight();
        }

        private void toolStripButtonFitWidth_Click(object sender, EventArgs e)
        {
            // like RadioButton
            toolStripButtonFitOnePage.BackColor = SystemColors.Control;
            toolStripButtonFitWidth.BackColor = SystemColors.GradientActiveCaption;

            // zoom 100 %
            toolStripTrackBarZoom.Value = 0;

            pdfPanel1.FitWidth();
            pdfPanel2.FitWidth();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripSplitButtonCompare.PerformClick();
        }

        private void toolStripSplitButtonCompare_ButtonClick(object sender, EventArgs e)
        {
            CompareByMode();
        }

        private void CompareByMode()
        {
            if (toolStripSplitButtonCompare.Text == "Compare Page")
            {
                ComparePage();
            }
            else if (toolStripSplitButtonCompare.Text == "Compare Bookmark")
            {
                CompareBookmark();
            }
            else
            {
                CompareBook();
            }
        }

        private void pageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripSplitButtonCompare.Text = pageToolStripMenuItem.Text;
        }

        private void bookmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripSplitButtonCompare.Text = bookmarkToolStripMenuItem.Text;
        }
        
        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripSplitButtonCompare.Text = bookToolStripMenuItem.Text;
        }

        private void OutputDebugLog()
        {
            try
            {
                int pages = Math.Max(pdfPanel1.pdfViewer.Document.PageCount, pdfPanel2.pdfViewer.Document.PageCount);
                for (int i = 0; i < pages; i++)
                {
                    Console.WriteLine("[{0}]\t{1}{3}\t{2}{4}", i, pdfPanel1.GetComparedPage(i)+1, pdfPanel2.GetComparedPage(i)+1,
                                                                  pdfPanel1.pdfViewer.Renderer.HasMarkers(i) ? "*" : " ",
                                                                  pdfPanel2.pdfViewer.Renderer.HasMarkers(i) ? "*" : " ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
