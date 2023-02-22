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

namespace PDFComp
{
    public partial class FormMain : Form
    {
        readonly Double ZoomInScale = 0.1;
        readonly Double ZoomOutScale = 0.03;
        FormFind formFind = null;
        PdfRotation rotation;
        Double zoom;
        Boolean zoomIn;
        Boolean zoomOut;
        int FindDiffPage1;
        int FindDiffPage2;

        public FormMain()
        {
            InitializeComponent();
            comboBoxDiffType.SelectedIndex = 0;
            radioButtonText.Checked = true;

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
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    buttonPrevPage.PerformClick();
                    return true;
                case Keys.Right:
                    buttonNextPage.PerformClick();
                    return true;
                case Keys.Space:
                    buttonCompare.PerformClick();
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
                    buttonPrevPage.PerformClick();
                    break;
                case Keys.Right:
                    buttonNextPage.PerformClick();
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

        private void ButtonZoomIn_Click(object sender, EventArgs e)
        {
            if (trackBarZoom.Value < trackBarZoom.Maximum)
            {
                trackBarZoom.Value++;
            }
        }
        private void ButtonZoomOut_Click(object sender, EventArgs e)
        {
            if (trackBarZoom.Value > trackBarZoom.Minimum)
            {
                trackBarZoom.Value--;
            }
        }

        private void TrackBarZoom_ValueChanged(object sender, EventArgs e)
        {
            if (trackBarZoom.Value >= 0)
            {
                zoom = 1.0 + trackBarZoom.Value * ZoomInScale;
            } else
            {
                zoom = 1.0 + trackBarZoom.Value * ZoomOutScale;
            }

            labelZoom.Text = String.Format("{0} %", zoom * 100);

            pdfPanel1.SetZoom(zoom);
            pdfPanel2.SetZoom(zoom);

        }

        private void ButtonZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            zoomIn = true;
            timerButton.Enabled = true;
        }

        private void ButtonZoomIn_MouseUp(object sender, MouseEventArgs e)
        {
            zoomIn = false;
            timerButton.Enabled = false;
        }

        private void ButtonZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            zoomOut = true;
            timerButton.Enabled = true;
        }

        private void ButtonZoomOut_MouseUp(object sender, MouseEventArgs e)
        {
            zoomOut = false;
            timerButton.Enabled = false;
        }

        private void TimerButton_Tick(object sender, EventArgs e)
        {
            if (zoomOut)
            {
                buttonZoomOut.PerformClick();
            }

            if (zoomIn)
            {
                buttonZoomIn.PerformClick();
            }
        }

        private void ButtonNextPage_Click(object sender, EventArgs e)
        {
            pdfPanel1.NextPage();
            pdfPanel2.NextPage();
        }

        private void ButtonPrevPage_Click(object sender, EventArgs e)
        {
            pdfPanel1.PrevPage();
            pdfPanel2.PrevPage();
        }

        private void ButtonCompare_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Compare Button click!");

            if ((pdfPanel1.pdfViewer.Document == null) || (pdfPanel2.pdfViewer.Document == null))
            {
                labelResult.Text = "0.0";
                return;
            }

            var stopwatch = new System.Diagnostics.Stopwatch();

            int page1 = pdfPanel1.pdfViewer.Renderer.Page;
            int page2 = pdfPanel2.pdfViewer.Renderer.Page;

            //if ((pdfPanel1.GetComparedPage(page1) == page2) && (pdfPanel2.GetComparedPage(page2) == page1))
            //{
            //    labelResult.Text = "0.0";
            //    return;
            //}

            ComparePage(stopwatch, page1, page2);

            stopwatch.Stop();
            Console.WriteLine("Marker:{0}", stopwatch.Elapsed);
            stopwatch.Start();

            //results.ToList().ForEach(r => Console.WriteLine(r.ToFormatString()));
            if (stopwatch.ElapsedMilliseconds < 50)
            {
                Thread.Sleep(30);
            }

            // Draw with the markers.
            pdfPanel1.Update();
            pdfPanel2.Update();

            stopwatch.Stop();
            Console.WriteLine("Draw:{0}", stopwatch.Elapsed);

            labelResult.Text = String.Format("{0:0.0}", stopwatch.ElapsedMilliseconds / 1000.0);
        }

        private bool ComparePage(System.Diagnostics.Stopwatch stopwatch, int page1, int page2)
        {
            // Once compared, clear the page number and diff markers.
            // It's translucent and overwritten, so if you don't erase it, it will get darker.
            if (pdfPanel1.GetComparedPage(page1) >= 0)
            {
                var oneFullPage = pdfPanel1.pdfViewer.Renderer.CompareBounds.IsEmpty;
                pdfPanel1.ClearDiffMarker(page1, oneFullPage);
            }
            if (pdfPanel2.GetComparedPage(page2) >= 0)
            {
                var oneFullPage = pdfPanel2.pdfViewer.Renderer.CompareBounds.IsEmpty;
                pdfPanel2.ClearDiffMarker(page2, oneFullPage);
            }

            // Draw without the marker.
            pdfPanel1.Update();
            pdfPanel2.Update();

            //stopwatch.Stop();
            //Console.WriteLine("Clear:{0}", stopwatch.Elapsed);
            //stopwatch.Start();

            String text1 = pdfPanel1.GetPageText();
            String text2 = pdfPanel2.GetPageText();
            List<PdfTextSpan> index1 = new List<PdfTextSpan>();
            List<PdfTextSpan> index2 = new List<PdfTextSpan>();

            stopwatch.Stop();
            Console.WriteLine("Get:{0}", stopwatch.Elapsed);
            labelResult.Text = ".";
            labelResult.Update();
            stopwatch.Start();

            diff_match_patch dmp;
            List<Diff> diffs;

            int diffType = comboBoxDiffType.SelectedIndex;
            switch (diffType)
            {
                case 0:     // Google Diff - Raw
                    dmp = new diff_match_patch();
                    diffs = dmp.diff_main(text1, text2);
                    ExtractDiffSpan2(index1, index2, diffs, page1, page2);
                    break;
                case 1:     // Google Diff - Semantic
                    dmp = new diff_match_patch();
                    diffs = dmp.diff_main(text1, text2);
                    dmp.diff_cleanupSemantic(diffs);
                    ExtractDiffSpan2(index1, index2, diffs, page1, page2);
                    break;
                case 2:     // Google Diff - Effective 4
                    dmp = new diff_match_patch();
                    dmp.Diff_EditCost = 4;
                    diffs = dmp.diff_main(text1, text2);
                    dmp.diff_cleanupEfficiency(diffs);
                    ExtractDiffSpan2(index1, index2, diffs, page1, page2);
                    break;
                case 3:     // Google Diff - Effective 5
                    dmp = new diff_match_patch();
                    dmp.Diff_EditCost = 5;
                    diffs = dmp.diff_main(text1, text2);
                    dmp.diff_cleanupEfficiency(diffs);
                    ExtractDiffSpan2(index1, index2, diffs, page1, page2);
                    break;
                case 4:     // Google Diff - Effective 3
                    dmp = new diff_match_patch();
                    dmp.Diff_EditCost = 3;
                    diffs = dmp.diff_main(text1, text2);
                    dmp.diff_cleanupEfficiency(diffs);
                    ExtractDiffSpan2(index1, index2, diffs, page1, page2);
                    break;

                default:
                    throw new Exception();
            }


            stopwatch.Stop();
            Console.WriteLine("Diff:{0}", stopwatch.Elapsed);
            labelResult.Text = "..";
            labelResult.Update();
            stopwatch.Start();

            pdfPanel1.SetPageDiff(index1);
            pdfPanel2.SetPageDiff(index2);


            pdfPanel1.AddDiffMarker(page2);
            labelResult.Text = "...";
            labelResult.Update();
            pdfPanel2.AddDiffMarker(page1);
            labelResult.Text = "....";
            labelResult.Update();

            // Remember the last page compared.
            FindDiffPage1 = page1;
            FindDiffPage2 = page2;

            // If there is a difference on either page.
            bool found_diff = (index1.Count>0) || (index2.Count>0);  

            return found_diff;
        }

        private void ExtractDiffSpan2(List<PdfTextSpan> spanList1, List<PdfTextSpan> spanList2, List<Diff> diffs, int page1, int page2)
        {
            if (diffs.Count() > 0)
            {
                int offset1 = 0;
                int offset2 = 0;
                int count;

                foreach(Diff diff in diffs)
                {
                    count = diff.text.Length;
                    switch (diff.operation)
                    {
                        case Operation.EQUAL:
                            offset1 += count;
                            offset2 += count;
                            break;
                        case Operation.INSERT:
                            //spanList2.Add(new PdfTextSpan(page2, offset2, count));
                            AddSpanList(spanList2, pdfPanel2, page2, offset2, count);
                            offset2 += count;
                            break;
                        case Operation.DELETE:
                            //spanList1.Add(new PdfTextSpan(page1, offset1, count));
                            AddSpanList(spanList1, pdfPanel1, page1, offset1, count);
                            offset1 += count;
                            break;
                    }
                }
            }
        }

        private void AddSpanList(List<PdfTextSpan> spanList, PdfPanel pdfpanel, int page, int offset, int count)
        {
            int comp_offset = pdfpanel.GetCompOffset(offset);

            if (comp_offset < 0)
            {
                // Extract the entire page. offset and comp_offset are the same.
                spanList.Add(new PdfTextSpan(page, offset, count));
            }
            else
            {
                // Extract a range of CompareBounds. Convert from offset to comp_offset.
                int item_offset = comp_offset;
                int item_count = 0;

                for (int i=0; i<count; i++)
                {
                    comp_offset = pdfpanel.GetCompOffset(offset+i);
                    if (comp_offset != item_offset + item_count)
                    {
                        spanList.Add(new PdfTextSpan(page, item_offset, item_count));
                        item_offset = comp_offset;
                        item_count = 1;
                    } else
                    {
                        item_count++;
                    }
                }

                if (item_count> 0)
                {
                    spanList.Add(new PdfTextSpan(page, item_offset, item_count));
                }
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
            }

            if ((string)Tag == "pdfPanel2")
            {
                var text = pdfPanel2.pdfViewer.Renderer.SelectedText;
                if (text?.Length > 0)
                {
                    data.SetData(DataFormats.Text, text);
                }
            }

            // At the same time, copy the comparison image.
            if ((pdfPanel1.pdfViewer.Document != null) || (pdfPanel2.pdfViewer.Document != null))
            {
                Bitmap bitmap = new Bitmap(panelBoth.ClientSize.Width, panelBoth.ClientSize.Height);
                panelBoth.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));

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
                Clipboard.SetImage(bitmap);
            }

        }

        private void CopyFile2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pdfPanel2.pdfViewer.Document != null)
            {
                Bitmap bitmap = new Bitmap(pdfPanel2.ClientSize.Width, pdfPanel2.ClientSize.Height);
                pdfPanel2.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
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

        private void AboutPDFCompToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void ComparePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonCompare.PerformClick();
        }

        private void ClearMarker1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdfPanel1.ClearDiffMarker(pdfPanel1.pdfViewer.Renderer.Page, true);
        }

        private void ClearMarker2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdfPanel2.ClearDiffMarker(pdfPanel2.pdfViewer.Renderer.Page, true);
        }

        private void ComboBoxDiffType_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonCompare.PerformClick();
        }

        private void RadioButtonPan_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPan.Checked)
            {
                pdfPanel1.pdfViewer.Renderer.CursorMode = PdfCursorMode.Pan;
                pdfPanel2.pdfViewer.Renderer.CursorMode = PdfCursorMode.Pan;
                pdfPanel1.pdfViewer.Renderer.MouseWheelMode = MouseWheelMode.PanAndZoom;
                pdfPanel2.pdfViewer.Renderer.MouseWheelMode = MouseWheelMode.PanAndZoom;
            }
        }

        private void RadioButtonText_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonText.Checked)
            {
                pdfPanel1.pdfViewer.Renderer.CursorMode = PdfCursorMode.TextSelection;
                pdfPanel2.pdfViewer.Renderer.CursorMode = PdfCursorMode.TextSelection;
                pdfPanel1.pdfViewer.Renderer.MouseWheelMode = MouseWheelMode.PanAndZoom;
                pdfPanel2.pdfViewer.Renderer.MouseWheelMode = MouseWheelMode.PanAndZoom;
            }
        }

        private void radioButtonBounds_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBounds.Checked)
            {
                pdfPanel1.pdfViewer.Renderer.CursorMode = PdfCursorMode.Bounds;
                pdfPanel2.pdfViewer.Renderer.CursorMode = PdfCursorMode.Bounds;
                pdfPanel1.pdfViewer.Renderer.MouseWheelMode = MouseWheelMode.Zoom;
                pdfPanel2.pdfViewer.Renderer.MouseWheelMode = MouseWheelMode.Zoom;
            }
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

        private void buttonFindDiff_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Find diff Button click!");

            if ((pdfPanel1.pdfViewer.Document == null) || (pdfPanel2.pdfViewer.Document == null))
            {
                labelResult.Text = "0.0";
                return;
            }

            var stopwatch = new System.Diagnostics.Stopwatch();

            int pages = pdfPanel1.pdfViewer.Document.PageCount;
            int page1 = pdfPanel1.pdfViewer.Renderer.Page;
            int page2 = pdfPanel2.pdfViewer.Renderer.Page;

            for (int i=page1; i<pages; i++)
            {
                page1 = pdfPanel1.pdfViewer.Renderer.Page;
                page2 = pdfPanel2.pdfViewer.Renderer.Page;

                // If the page was just compared, compare from the next page.
                if ((page1 == FindDiffPage1) && (page2 == FindDiffPage2))
                {
                    // skip compare.
                }
                else
                {
                    if (ComparePage(stopwatch, page1, page2))
                    {
                        break;
                    }
                }

                pdfPanel1.NextPage();
                pdfPanel2.NextPage();
            }

            stopwatch.Stop();

            labelResult.Text = String.Format("{0:0.0}", stopwatch.ElapsedMilliseconds / 1000.0);

        }

        private void buttonPrevDiff_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Prev diff Button click!");

            if ((pdfPanel1.pdfViewer.Document == null) || (pdfPanel2.pdfViewer.Document == null))
            {
                labelResult.Text = "0.0";
                return;
            }

            var stopwatch = new System.Diagnostics.Stopwatch();

            int pages = pdfPanel1.pdfViewer.Document.PageCount;
            int page1 = pdfPanel1.pdfViewer.Renderer.Page;
            int page2 = pdfPanel2.pdfViewer.Renderer.Page;

            for (int i=page1; i>=0; i--)
            {
                page1 = pdfPanel1.pdfViewer.Renderer.Page;
                page2 = pdfPanel2.pdfViewer.Renderer.Page;

                // If the page was just compared, compare from the next page.
                if ((page1 == FindDiffPage1) && (page2 == FindDiffPage2))
                {
                    // skip compare.
                }
                else
                {
                    if (ComparePage(stopwatch, page1, page2))
                    {
                        break;
                    }
                }

                pdfPanel1.PrevPage();
                pdfPanel2.PrevPage();
            }

            stopwatch.Stop();

            labelResult.Text = String.Format("{0:0.0}", stopwatch.ElapsedMilliseconds / 1000.0);

        }

        private void previousDifferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonFindDiff.PerformClick();
        }

        private void previousDifferenceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            buttonPrevDiff.PerformClick();
        }
    }
}
