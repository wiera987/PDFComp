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
using NetDiff;
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
            Console.WriteLine("Button click!");

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

            if (pdfPanel1.GetComparedPage(page1) >= 0)
            {
                pdfPanel1.ClearDiffMarker(page1);
            }
            if (pdfPanel2.GetComparedPage(page2) >= 0)
            {
                pdfPanel2.ClearDiffMarker(page2);
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
                case 0:     // NetDiff
                    var results = DiffUtil.Diff(text1, text2);
                    ExtractDiffSpan(index1, index2, results, page1, page2);
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

                case 5:     // Google Diff - Raw
                    dmp = new diff_match_patch();
                    diffs = dmp.diff_main(text1, text2);
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

        private static void ExtractDiffSpan2(List<PdfTextSpan> spanList1, List<PdfTextSpan> spanList2, List<Diff> diffs, int page1, int page2)
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
                            spanList2.Add(new PdfTextSpan(page2, offset2, count));
                            offset2 += count;
                            break;
                        case Operation.DELETE:
                            spanList1.Add(new PdfTextSpan(page1, offset1, count));
                            offset1 += count;
                            break;
                    }
                }
            }
        }

        private static void ExtractDiffSpan(List<PdfTextSpan> spanList1, List<PdfTextSpan> spanList2, IEnumerable<DiffResult<char>> results, int page1, int page2)
        {
            if (results.Count() > 0)
            {
                List<bool> list1 = new List<bool>();
                List<bool> list2 = new List<bool>();
                bool hasDiff1 = false;
                bool hasDiff2 = false;

                foreach (DiffResult<char> result in results)
                {
                    switch (result.Status)
                    {
                        case DiffStatus.Equal:
                            list1.Add(false);
                            list2.Add(false);
                            break;
                        case DiffStatus.Inserted:
                            list2.Add(true);
                            hasDiff2 = true;
                            break;
                        case DiffStatus.Deleted:
                            list1.Add(true);
                            hasDiff1 = true;
                            break;
                    }
                }

                if (hasDiff1)
                {
                    CountDiffSpan(spanList1, page1, list1);
                }

                if (hasDiff2)
                {
                    CountDiffSpan(spanList2, page2, list2);
                }

            }
        }

        private static void CountDiffSpan(List<PdfTextSpan> spanList, int page, List<bool> list)
        {
            bool oldStatus = list[0];
            int offset = 0;
            int count = 0;

            foreach (bool status in list)
            {
                if (status == oldStatus)
                {
                    count++;
                }
                else
                {
                    if (oldStatus)
                    {
                        spanList.Add(new PdfTextSpan(page, offset, count));
                    }
                    offset += count;
                    count = 1;
                    oldStatus = status;
                }
            }

            if (oldStatus)
            {
                spanList.Add(new PdfTextSpan(page, offset, count));
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
            pdfPanel1.ClearDiffMarker(pdfPanel1.pdfViewer.Renderer.Page);
        }

        private void ClearMarker2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdfPanel2.ClearDiffMarker(pdfPanel2.pdfViewer.Renderer.Page);
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

    }
}
