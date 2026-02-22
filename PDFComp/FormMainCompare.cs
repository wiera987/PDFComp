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

namespace PDFComp
{
    [System.ComponentModel.DesignerCategory("Code")]
    internal class DesignerBlocker { }

    public partial class FormMain
    {

        public void PagePairClearAll()
        {
            // Initialize the page pair list.
            pagePairList.ClearAll();
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

        private void CompareDocument()
        {
            Console.WriteLine("Compare Document Button click!");

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

            Console.WriteLine("CompareDocument():({0},{1})-({2},{3})", startPage1+1, endPage1+1, startPage2+1, endPage2+1);

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

            SetFlashPage(page1, page2);

            return found_diff;
        }


        private bool ComparePages(System.Diagnostics.Stopwatch stopwatch, int startPage1, int endPage1, int startPage2, int endPage2)
        {
            var oneFullPage1 = pdfPanel1.pdfViewer.Renderer.CompareBounds.IsEmpty;
            var oneFullPage2 = pdfPanel2.pdfViewer.Renderer.CompareBounds.IsEmpty;
            var textData1 = new PageTextList();
            var textData2 = new PageTextList();

            Console.WriteLine("PDF1 = {0}", pdfPanel1.toolStripTextBoxFile.Text);
            Console.WriteLine("PDF2 = {0}", pdfPanel2.toolStripTextBoxFile.Text);
            Console.WriteLine("PDF1 CompareBounds = {0}", pdfPanel1.pdfViewer.Renderer.CompareBounds);
            Console.WriteLine("PDF2 CompareBounds = {0}", pdfPanel2.pdfViewer.Renderer.CompareBounds);

            // Once compared, clear the page number and diff markers.
            // It's translucent and overwritten, so if you don't erase it, it will get darker.
            for (int i = startPage1; i <= endPage1; i++)
            {
                pdfPanel1.ClearDiffMarker(i, oneFullPage1);
                textData1.Add(pdfPanel1.GetPageTextData(i));
                //Console.WriteLine("Get1-{0}:{1}", i+1, pdfPanel1.GetPageTextData(i).Text);
            }
            for (int i = startPage2; i <= endPage2; i++)
            {
                pdfPanel2.ClearDiffMarker(i, oneFullPage2);
                textData2.Add(pdfPanel2.GetPageTextData(i));
                //Console.WriteLine("Get2-{0}:{1}", i+1, pdfPanel2.GetPageTextData(i).Text);
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

            CompareStyle(diffs, textData1, textData2);
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

        /// <summary>
        /// Performs post-comparison processing to analyze style-based differences in the text.
        /// For EQUAL operations, checks if corresponding characters have different styles.
        /// If styles differ consistently, replaces EQUAL with INSERT and DELETE operations.
        /// If styles match, keeps as EQUAL.
        /// </summary>
        /// <param name="diffs"></param>
        /// <param name="textData1"></param>
        /// <param name="textData2"></param>
        private void CompareStyle(List<Diff> diffs, PageTextList textData1, PageTextList textData2)
        {
            if (diffs.Count == 0)
                return;

            List<Diff> newDiffs = new List<Diff>();
            int offset1 = 0;
            int offset2 = 0;
            int count;

            foreach (Diff diff in diffs)
            {
                count = diff.text.Length;
                switch (diff.operation)
                {
                    // Process EQUAL operation: check for style differences
                    case Operation.EQUAL:
                        SplitEqualByTextStyle(diff.text, textData1, textData2, offset1, offset2, newDiffs);
                        offset1 += count;
                        offset2 += count;
                        break;
                    // Non-EQUAL operations are kept as-is
                    case Operation.INSERT:
                        newDiffs.Add(diff);
                        offset2 += count;
                        break;
                    case Operation.DELETE:
                        newDiffs.Add(diff);
                        offset1 += count;
                        break;
                }
            }

            // Replace the original diffs with the modified list
            diffs.Clear();
            diffs.AddRange(newDiffs);
        }

        private int SplitEqualByTextStyle(string textEqual, PageTextList textData1, PageTextList textData2, int offset1, int offset2, List<Diff> newDiffs)
        {
            int i = 0;
            int count_eq = textEqual.Length;
            
            while (i < count_eq)
            {
                // Get style information for current character
                var style1 = pdfPanel1.GetTextStyle(textData1.GetPagePos(offset1 + i));
                var style2 = pdfPanel2.GetTextStyle(textData2.GetPagePos(offset2 + i));
                bool styleMatches = PdfTextStyle.IsMatched(style1, style2, styleFlags);

                // Accumulate consecutive characters with the same style relationship
                int j = i + 1;
                while (j < count_eq)
                {
                    style1 = pdfPanel1.GetTextStyle(textData1.GetPagePos(offset1 + j));
                    style2 = pdfPanel2.GetTextStyle(textData2.GetPagePos(offset2 + j));
                    bool currentStyleMatches = PdfTextStyle.IsMatched(style1, style2, styleFlags);

                    // Stop when style relationship changes
                    if (currentStyleMatches != styleMatches)
                        break;

                    j++;
                }

                // Add diff based on whether styles match
                string text = textEqual.Substring(i, j - i);
                if (styleMatches)
                {
                    // Styles are the same, keep as EQUAL
                    newDiffs.Add(new Diff(Operation.EQUAL, text));
                }
                else
                {
                    // Styles differ, split into DELETE and INSERT
                    newDiffs.Add(new Diff(Operation.DELETE, text));
                    newDiffs.Add(new Diff(Operation.INSERT, text));

                    //formDiffInfo.WriteText(text, Color.Red);
                    //formDiffInfo.WriteText(text, Color.Blue);
                }

                i = j;
            }

            return i;
        }

        /// <summary>
        /// To register difference markers, create a DELETE list for File1 and an INSERT list
        /// for File2 from the differences.
        /// Elements that span multiple pages are split at page boundaries.
        /// </summary>
        /// <param name="spanList1"></param>
        /// <param name="spanList2"></param>
        /// <param name="diffs"></param>
        /// <param name="textData1"></param>
        /// <param name="textData2"></param>
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

        /// <summary>
        /// Create a PdfTextSpan from the offset and count and add it to the list. 
        /// If the element spans pages, it will be split.
        /// </summary>
        /// <param name="spanList"></param>
        /// <param name="textList"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
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
            int previousOffset1 = 0, previousOffset2 = 0;       // Store the offset to append to the previously compared TextSpan

            (int page1, _) = textList1.GetPagePos(offset1);     // Page number currently being processed
            (int page2, _) = textList2.GetPagePos(offset2);
            int previousPage1 = page1;                          // Store the page to append to the previously compared TextSpan
            int previousPage2 = page2;
            int nextOffset1 = textList1.GetOffset(page1 + 1);   // Start position of the next page
            int nextOffset2 = textList2.GetOffset(page2 + 1);
            bool hasContent1 = false;
            bool hasContent2 = false;
            bool hasDiffEqu1 = false;
            bool hasDiffEqu2 = false;
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

                    hasDiffEqu1 |= (diff.operation == Operation.EQUAL);
                    hasDiffEqu2 |= (diff.operation == Operation.EQUAL);

                    // Console.WriteLine("F1P{0}, offs={1}, count={2}, len={3}, nextOffs={4}", page1+1, offset1, count, length1, nextOffset1);
                    // Console.WriteLine("F2P{0}, offs={1}, count={2}, len={3}, nextOffs={4}", page2+1, offset2, count, length2, nextOffset2);

                    if (minLength == int.MaxValue)
                    {
                        // Neither page reaches its boundary within count steps.
                        // Slide by count, which is the length of diff.text.
                        SlideOffsetByOperation(diff, count, ref offset1, ref offset2, ref hasContent1, ref hasContent2);
                        count = 0;
                        flag = true;
                    }
                    else
                    {
                        // One or both pages reach their boundary within count steps.
                        // Slide by the minLength, which is the shorter distance to the boundary.
                        SlideOffsetByOperation(diff, minLength, ref offset1, ref offset2, ref hasContent1, ref hasContent2);
                        // Console.WriteLine($"[F1p{page1+1}]" + textList1.GetText(startOffset1, offset1));
                        // Console.WriteLine($"[F2p{page2+1}]" + textList2.GetText(startOffset2, offset2));

                        int page1a = page1;
                        int page2a = page2;
                        int startOffset1a = startOffset1;
                        int startOffset2a = startOffset2;

                        if ((minLength == length1) && (minLength == length2))
                        {
                            SlideNextPage(ref page1, ref nextOffset1, textList1);
                            SlideNextPage(ref page2, ref nextOffset2, textList2);

                            hasContent1 = false;
                            hasContent2 = false;
                            hasDiffEqu1 = false;
                            hasDiffEqu2 = false;
                        }
                        else if (minLength == length1)
                        {
                            SlideNextPage(ref page1, ref nextOffset1, textList1);

                            // If only Page1 has remaining unprocessed text, pair Page1 with the preceding Page2.
                            // - Page1 has unprocessed diff text remaining.
                            // - Page1 contains processed text that should be grouped with the unprocessed segment.
                            // - Page2 has no diff text yet and is available to be paired with Page1.
                            if ((length1 > 0) && hasDiffEqu1 && !hasContent2)
                            {
                                page2a = previousPage2;
                                startOffset1a = previousOffset1;
                                startOffset2a = previousOffset2;
                            }
                            hasContent1 = false;
                            hasDiffEqu1 = false;
                        }
                        else if (minLength == length2)
                        {
                            SlideNextPage(ref page2, ref nextOffset2, textList2);

                            // If only Page2 has remaining unprocessed text, pair Page2 with the preceding Page1.
                            // - Page2 has unprocessed diff text remaining.
                            // - Page2 contains processed text that should be grouped with the unprocessed segment.
                            // - Page1 has no diff text yet and is available to be paired with Page2.
                            if ((length2 > 0) && hasDiffEqu2 && !hasContent1)
                            {
                                page1a = previousPage1;
                                startOffset1a = previousOffset1;
                                startOffset2a = previousOffset2;
                            }
                            hasContent2 = false;
                            hasDiffEqu2 = false;
                        }

                        var span1 = textList1.GetTextSpans(startOffset1a, offset1);
                        var span2 = textList2.GetTextSpans(startOffset2a, offset2);
                        pagePairList.SetPagePair(page1a, page2a, span1, span2);
                        pdfPanel1.SetComparedPage(page1a, page2a);
                        pdfPanel2.SetComparedPage(page2a, page1a);

                        Console.WriteLine($"SetComparedPage({page1a+1},{page2a+1})");

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

        private void SlideNextPage(ref int page, ref int nextOffset, PageTextList textList)
        {
            if (page < textList.LastPage)
            {
                page++;
                nextOffset = textList.GetOffset(page + 1);
            }
            else
            {
                // Sets the position to the end of the last page. 
                Console.WriteLine("Lastpage");
                page = textList.LastPage;
                nextOffset = 0;
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

        private void SlideOffsetByOperation(Diff diff, int slide, ref int offset1, ref int offset2,
                                            ref bool hasText1, ref bool hasText2)
        {
            switch (diff.operation)
            {
                case Operation.EQUAL:
                    offset1 += slide;
                    offset2 += slide;
                    hasText1 = true;
                    hasText2 = true;
                    break;
                case Operation.INSERT:
                    // Present only in the 2nd text
                    offset2 += slide;
                    hasText2 = true;
                    break;
                case Operation.DELETE:
                    // Present only in the 1st text
                    offset1 += slide;
                    hasText1 = true;
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
                
        private void OutputDebugLog()
        {
            int i = 0;

            try
            {
                foreach (var PagePair in pagePairList)
                {
                    string result1 = "";
                    string result2 = "";
                    if (PagePair.Span1.Count > 0)
                    {
                        string span1text = pdfPanel1.pdfViewer.Document.GetPdfText(PagePair.Span1[0]);
                        int pos1 = span1text.IndexOfAny(new[] { '\r', '\n' });
                        result1 = pos1 >= 0 ? span1text.Substring(0, pos1) : span1text;
                    }
                    if (PagePair.Span2.Count > 0)
                    {
                        string span2text = pdfPanel2.pdfViewer.Document.GetPdfText(PagePair.Span2[0]);
                        int pos2 = span2text.IndexOfAny(new[] { '\r', '\n' });
                        result2 = pos2 >= 0 ? span2text.Substring(0, pos2) : span2text;
                    }

                    Console.WriteLine("[{0}]\t{1}{3}\t{2}{4}\t{5},{6}", i, PagePair.Page1 + 1, PagePair.Page2 + 1,
                                                                  pdfPanel1.pdfViewer.Renderer.HasMarkers(PagePair.Page1) ? "*" : " ",
                                                                  pdfPanel2.pdfViewer.Renderer.HasMarkers(PagePair.Page2) ? "*" : " ",
                                                                  result1, result2);
                    i++;
                }
                
                if (i==0)
                {
                    Console.WriteLine("[-] no pair");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
