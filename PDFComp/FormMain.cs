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

namespace PDFComp
{
    public partial class FormMain : Form
    {
        readonly Double ZoomInScale = 0.1;      // zoom : 10%..50%..100%..200%..400%...900%  
        readonly Double ZoomOutScale = 0.01;    // scale:   -2%, -5%, +10%, +20%, +50%
        FormFind formFind = null;
        PdfRotation rotation;
        Double zoom;
        Boolean zoomIn;
        Boolean zoomOut;
        int FindDiffPage1;
        int FindDiffPage2;
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
        }

        public void OpenFiles(String[] files)
        {
            pdfPanel1.OpenFile(files[0]);
            pdfPanel2.OpenFile(files[1]);
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
                    toolStripButtonComparePage.PerformClick();
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

        private void ComparePage()
        {
            Console.WriteLine("Compare Button click!");

            if ((pdfPanel1.pdfViewer.Document == null) || (pdfPanel2.pdfViewer.Document == null))
            {
                toolStripLabelResult.Text = "0.0";
                return;
            }

            var stopwatch = new System.Diagnostics.Stopwatch();

            int page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
            int page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;

            //if ((pdfPanel1.GetComparedPage(page1) == page2) && (pdfPanel2.GetComparedPage(page2) == page1))
            //{
            //    toolStripLabelResult.Text = "0.0";
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

            toolStripLabelResult.Text = String.Format("{0:0.0}", stopwatch.ElapsedMilliseconds / 1000.0);
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

            stopwatch.Start();

            diff_match_patch dmp;
            List<Diff> diffs;

            //int diffType = comboBoxDiffType.SelectedIndex;
            int diffType = toolStripComboBoxDiffType.SelectedIndex;
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
            stopwatch.Start();

            pdfPanel1.SetPageDiff(index1);
            pdfPanel2.SetPageDiff(index2);

            pdfPanel1.AddDiffMarker(page2);
            pdfPanel2.AddDiffMarker(page1);

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

        private void AboutPDFCompToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void ComparePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButtonComparePage.PerformClick();
        }

        private void ClearMarker1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdfPanel1.ClearDiffMarker(pdfPanel1.pdfViewer.Renderer.ComparisonPage, true);
        }

        private void ClearMarker2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdfPanel2.ClearDiffMarker(pdfPanel2.pdfViewer.Renderer.ComparisonPage, true);
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

        private void FindDiff()
        {
            Console.WriteLine("Find diff Button click!");

            if ((pdfPanel1.pdfViewer.Document == null) || (pdfPanel2.pdfViewer.Document == null))
            {
                toolStripLabelResult.Text = "0.0";
                return;
            }

            var stopwatch = new System.Diagnostics.Stopwatch();

            int pages = pdfPanel1.pdfViewer.Document.PageCount;
            int page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
            int page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;

            for (int i=page1; i<pages; i++)
            {
                page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
                page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;

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

            toolStripLabelResult.Text = String.Format("{0:0.0}", stopwatch.ElapsedMilliseconds / 1000.0);

        }

        private void PrevDiff()
        {
            Console.WriteLine("Prev diff Button click!");

            if ((pdfPanel1.pdfViewer.Document == null) || (pdfPanel2.pdfViewer.Document == null))
            {
                toolStripLabelResult.Text = "0.0";
                return;
            }

            var stopwatch = new System.Diagnostics.Stopwatch();

            int pages = pdfPanel1.pdfViewer.Document.PageCount;
            int page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
            int page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;

            for (int i=page1; i>=0; i--)
            {
                page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
                page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;

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

            toolStripLabelResult.Text = String.Format("{0:0.0}", stopwatch.ElapsedMilliseconds / 1000.0);

        }

        private void previousDifferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButtonNextDiff.PerformClick();
        }

        private void previousDifferenceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            toolStripButtonPrevDiff.PerformClick();
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
                // Zoom in
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
                // Zoom out
                if (value >= -10)
                {
                    zoom = 1.0 + value * ZoomOutScale * 5;
                }
                else
                {
                    zoom = 0.5 + (value + 10) * ZoomOutScale * 2;
                }
            }
            
            return zoom;			
		}

		private int GetTBValueFromZoom(double inZoom)
		{
			int value = 0;
			
            if (inZoom >= 1.0)
            {
                // Zoom in
                if (inZoom <= 2.0)
                {
                    value = (int)(0 + (inZoom - 1.0) / ZoomInScale);
                }
                else if (inZoom <= 4.0)
                {
                    value = (int)(10 + (inZoom - 2.0) / (ZoomInScale * 2));
                }
                else
                {
                    value = (int)(20 + (inZoom - 4.0) / (ZoomInScale * 5));
                }
            }
            else
            {
                if (inZoom >= 0.5)
                {
                    value = (int)(0 + (inZoom - 1.0) / (ZoomOutScale * 5));
                }
                else
                {
                    value = (int)(-10 + (inZoom - 0.5) / (ZoomOutScale * 2));
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

        private void toolStripButtonComparePage_Click(object sender, EventArgs e)
        {
            ComparePage();
        }

        private void toolStripButtonPrevDiff_Click(object sender, EventArgs e)
        {
            PrevDiff();
        }

        private void toolStripButtonNextDiff_Click(object sender, EventArgs e)
        {
            FindDiff();
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
            toolStripButtonComparePage.PerformClick();
        }


    }
}
