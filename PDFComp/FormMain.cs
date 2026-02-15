using DiffMatchPatch;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PDFComp.PdfPanel;

namespace PDFComp
{
    public partial class FormMain : Form
    {
        readonly Double ZoomInScale = 0.1;      // zoom : 10%..26%..80%..100%..200%..400%...900%  
        readonly Double ZoomOutScale = 0.01;    // scale:    -2%, -3%, -5%, +10%, +20%, +50%
        FormFind formFind = null;
        FormDiffInfo formDiffInfo = null;
        FormOptions formOptions = null;
        ToolTip tipJump1 = null;
        ToolTip tipJump2 = null;
        PdfTextStyleFlags styleFlags = PdfTextStyleFlags.None;
        PagePairList pagePairList = null;
        PdfRotation rotation;
        Double zoom;
        Boolean zoomIn;
        Boolean zoomOut;
        Boolean reduceColor = true;
        bool holdZoom = false;

        public FormMain()
        {
            InitializeComponent();
            toolStripSplitButtonCompare.Text = bookmarkToolStripMenuItem.Text;
            toolStripComboBoxDiffType.SelectedIndex = 0;
            // Designer settings are not reflected in TrackBar.AutoSize.
            toolStripTrackBarZoom.Height = 22;
            toolStripTrackBarZoom.TrackBar.AutoSize = toolStripTrackBarZoom.AutoSize;

            pdfPanel1.toolStripButtonNextPage.ToolTipText = "Next Page / Ctrl + RIGHT_ARROW";
            pdfPanel1.toolStripButtonPrevPage.ToolTipText = "Prev Page / Ctrl + LEFT_ARROW";
            pdfPanel2.toolStripButtonNextPage.ToolTipText = "Next Page / Alt + RIGHT_ARROW";
            pdfPanel2.toolStripButtonPrevPage.ToolTipText = "Prev Page / Alt + LEFT_ARROW";

            // Operate Jump scope navigation like a toggle button
            SwitchJumpScopeToDiffMode();

            zoom = 1.0;
            zoomIn = false;
            zoomOut = false;
            rotation = PdfRotation.Rotate0;

            tipJump1 = new ToolTip();
            tipJump2 = new ToolTip();

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
            // Reload options
            formOptions = new FormOptions();
            styleFlags = formOptions.StyleFlags;

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
                reduceColor = Properties.Settings.Default.EnableColorReductionCopy;
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
                reduceColor = Properties.Settings.Default.EnableColorReductionCopy;
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
                reduceColor = Properties.Settings.Default.EnableColorReductionCopy;
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

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formOptions.StartPosition = FormStartPosition.CenterParent;
            var result = formOptions.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                styleFlags = formOptions.StyleFlags;
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

        private void compareDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompareDocument();
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
            // The data couldn’t be merged, so...
            // Clear PdfPanel’s page comparison data and MainForm’s PagePairList.
            pdfPanel1.ClearAllDiffMarker();
            PagePairClearAll();
        }

        private void clearBook2MarkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // The data couldn’t be merged, so...
            // Clear PdfPanel’s page comparison data and MainForm’s PagePairList.
            pdfPanel2.ClearAllDiffMarker();
            PagePairClearAll();
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

            int page1end = pdfPanel1.pdfViewer.Document.PageCount-1;
            int page2end = pdfPanel2.pdfViewer.Document.PageCount-1;
            int page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
            int page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;
            int pageCount1 = 0;
            int pageCount2 = 0;

            tipJump1.Hide(pdfPanel1);
            tipJump2.Hide(pdfPanel2);

            // Search for diff pages.
            while ((page1 < page1end) || (page2 < page2end))
            {
                // Compare if not already compared.
                if ((pagePairList.GetPage1Counter(page1) < 0) || (pagePairList.GetPage2Counter(page2) < 0))
                {
                    CompareByMode();
                    if (pdfPanel1.pdfViewer.Renderer.HasMarkers(page1) || pdfPanel2.pdfViewer.Renderer.HasMarkers(page2))
                    {
                        break;
                    }
                    // Stops at the first comparison page in Page Jump mode.
                    if (toolStripButtonJumpScopePage.Visible == true)
                    {
                        break;
                    }
                }

                // Determine whether a page turn occurred.
                if (pagePairList.GetPagePair(page1, page2 + 1) != null)
                {
                    // If only page2 has changed, moves page2 only.
                    pdfPanel2.NextPage();
                    pageCount2++;
                }
                else if (pagePairList.GetPagePair(page1 + 1, page2) != null)
                {
                    // If only page1 has changed, moves page1 only.
                    pdfPanel1.NextPage();
                    pageCount1++;
                }
                else if (pagePairList.GetPagePair(page1 + 1, page2 + 1) != null)
                {
                    pdfPanel1.NextPage();
                    pdfPanel2.NextPage();
                    pageCount1++;
                    pageCount2++;
                }
                else
                {
                    // Moves so that misalignments are further reduced.
                    var currPage1Counter = pagePairList.GetPage1Counter(page1);
                    var currPage2Counter = pagePairList.GetPage2Counter(page2);
                    if (currPage1Counter < 0)
                    {
                        // Move page1 when it has no counter (blank page or hasn't been compared).
                        pdfPanel1.NextPage();
                        pageCount1++;
                    }
                    else if (currPage1Counter >= page2)
                    {
                        // Moves page2 because it is lagging.
                        pdfPanel2.NextPage();
                        pageCount2++;
                    }

                    if (currPage2Counter < 0)
                    {
                        // Move page2 when it has no counter (blank page or hasn't been compared).
                        pdfPanel2.NextPage();
                        pageCount2++;
                    }
                    else if (currPage2Counter >= page1)
                    {
                        // Moves page1 because it is lagging.
                        pdfPanel1.NextPage();
                        pageCount1++;
                    }

                    // Since no PagePair was found for the moved page,
                    // compare the moved page if it hasn't been compared yet.
                    page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
                    page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;
                    if ((pagePairList.GetPage1Counter(page1) < 0) || (pagePairList.GetPage2Counter(page2) < 0))
                    {
                        CompareByMode();
                    }
                }


                // Show the page if differences are found after moving.
                page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
                page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;

                Console.WriteLine("\t\t{0}{2}\t{1}{3}", page1+1, page2+1, 
                                                        pdfPanel1.pdfViewer.Renderer.HasMarkers(page1) ? "*" : " ",
                                                        pdfPanel2.pdfViewer.Renderer.HasMarkers(page2) ? "*" : " ");
                // Stop condition for Diff Jump
                if (pdfPanel1.pdfViewer.Renderer.HasMarkers(page1) || pdfPanel2.pdfViewer.Renderer.HasMarkers(page2))
                {
                    break;
                }
                // Stop condition for Page Jump
                if (toolStripButtonJumpScopePage.Visible == true)
                {
                    break;
                }
            }

            stopwatch.Stop();

            SetFlashPage(page1, page2);

            // Show a tip if there are undisplayed pages.
            if (pageCount1 > 1)
            {
                Point pos = new Point(100, 64);
                tipJump1.Hide(pdfPanel1);
                tipJump1.Show($"Jumped {pageCount1} pages to next diff.", pdfPanel1, pos, 2000);
            }
            if (pageCount2 > 1)
            {
                Point pos = new Point(100, 64);
                tipJump2.Hide(pdfPanel2);
                tipJump2.Show($"Jumped {pageCount2} pages to next diff.", pdfPanel2, pos, 2000);
            }

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

            int page1start = 0;
            int page2start = 0;
            int page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
            int page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;
            int pageCount1 = 0;
            int pageCount2 = 0;

            tipJump1.Hide(pdfPanel1);
            tipJump2.Hide(pdfPanel2);

            // Search for diff pages.
            while ((page1 >= page1start) || (page2 >= page2start))
            {
                // Compare if not already compared.
                if ((pagePairList.GetPage1Counter(page1) < 0) || (pagePairList.GetPage2Counter(page2) < 0))
                {
                    CompareByMode();
                    if (pdfPanel1.pdfViewer.Renderer.HasMarkers(page1) || pdfPanel2.pdfViewer.Renderer.HasMarkers(page2))
                    {
                        break;
                    }
                    // Stops at the first comparison page in Page Jump mode.
                    if (toolStripButtonJumpScopePage.Visible == true)
                    {
                        break;
                    }
                }

                // Determine whether a page turn occurred.
                if (pagePairList.GetPagePair(page1, page2 - 1) != null)
                {
                    // If only page2 has changed, moves page2 only.
                    pdfPanel2.PrevPage();
                    pageCount2++;
                }
                else if (pagePairList.GetPagePair(page1 - 1, page2) != null)
                {
                    // If only page1 has changed, moves page1 only.
                    pdfPanel1.PrevPage();
                    pageCount1++;
                }
                else if (pagePairList.GetPagePair(page1 - 1, page2 - 1) != null)
                {
                    pdfPanel1.PrevPage();
                    pdfPanel2.PrevPage();
                    pageCount1++;
                    pageCount2++;
                }
                else
                {
                    // Moves so that misalignments are further reduced.
                    var currPage1Counter = pagePairList.GetPage1Counter(page1);
                    var currPage2Counter = pagePairList.GetPage2Counter(page2);
                    if (currPage1Counter < 0)
                    {
                        // Move page1 when it has no counter (blank page or hasn't been compared).
                        pdfPanel1.PrevPage();
                        pageCount1++;
                    }
                    else if (currPage1Counter <= page2)
                    {
                        // Moves page2 because it is lagging.
                        pdfPanel2.PrevPage();
                        pageCount2++;
                    }

                    if (currPage2Counter < 0)
                    {
                        // Move page2 when it has no counter (blank page or hasn't been compared).
                        pdfPanel2.PrevPage();
                        pageCount2++;
                    }
                    else if (currPage2Counter <= page1)
                    {
                        // Moves page1 because it is lagging.
                        pdfPanel1.PrevPage();
                        pageCount1++;
                    }

                    // Since no PagePair was found for the moved page,
                    // compare the moved page if it hasn't been compared yet.
                    page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
                    page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;
                    if ((pagePairList.GetPage1Counter(page1) < 0) || (pagePairList.GetPage2Counter(page2) < 0))
                    {
                        CompareByMode();
                    }
                }

                // Show the page if differences are found after moving.
                page1 = pdfPanel1.pdfViewer.Renderer.ComparisonPage;
                page2 = pdfPanel2.pdfViewer.Renderer.ComparisonPage;

                Console.WriteLine("\t\t{0}{2}\t{1}{3}", page1+1, page2+1,
                                                        pdfPanel1.pdfViewer.Renderer.HasMarkers(page1) ? "*" : " ",
                                                        pdfPanel2.pdfViewer.Renderer.HasMarkers(page2) ? "*" : " ");

                // For Prev, stop when reaching the first page.
                if ((page1 == page1start) && (page2 == page2start))
                {
                    break;
                }

                // Stop condition for Diff Jump
                if (pdfPanel1.pdfViewer.Renderer.HasMarkers(page1) || pdfPanel2.pdfViewer.Renderer.HasMarkers(page2))
                {
                    break;
                }
                // Stop condition for Page Jump
                if (toolStripButtonJumpScopePage.Visible == true)
                {
                    break;
                }
            }

            stopwatch.Stop();

            SetFlashPage(page1, page2);

            // Show a tip if there are undisplayed pages.
            if (pageCount1 > 1)
            {
                Point pos = new Point(100, 64);
                tipJump1.Hide(pdfPanel1);
                tipJump1.Show($"Jumped {pageCount1} pages to prev diff.", pdfPanel1, pos, 2000);
            }
            if (pageCount2 > 1)
            {
                Point pos = new Point(100, 64);
                tipJump2.Hide(pdfPanel2);
                tipJump2.Show($"Jumped {pageCount2} pages to prev diff.", pdfPanel2, pos, 2000);
            }

            toolStripLabelResult.Text = String.Format("{0:0.0}", stopwatch.ElapsedMilliseconds / 1000.0);

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
                CompareDocument();
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

        private void toolStripButtonJumpScopeDiff_Click(object sender, EventArgs e)
        {
            // Switched from Diff mode to Page mode.
            SwitchJumpScopeToPageMode();
        }
        private void toolStripButtonJumpScopePage_Click(object sender, EventArgs e)
        {
            // Switched from Page mode to Diff mode.
            SwitchJumpScopeToDiffMode();
        }

        private void SwitchJumpScopeToPageMode()
        {
            toolStripButtonJumpScopeDiff.Visible = false;
            toolStripButtonJumpScopePage.Visible = true;
            toolStripButtonPrevDiff.Text = "Jump to Previous Page";
            toolStripButtonNextDiff.Text = "Jump to Next Page";
            previousDifferenceToolStripMenuItem.Text = "Jump to Previous Page";
            nextDifferenceToolStripMenuItem.Text = "Jump to Next Page";
        }

        private void SwitchJumpScopeToDiffMode()
        {
            toolStripButtonJumpScopeDiff.Visible = true;
            toolStripButtonJumpScopePage.Visible = false;
            toolStripButtonPrevDiff.Text = "Jump to Previous Difference";
            toolStripButtonNextDiff.Text = "Jump to Next Difference";
            previousDifferenceToolStripMenuItem.Text = "Jump to Previous Difference"; ;
            nextDifferenceToolStripMenuItem.Text = "Jump to Next Difference";
        }
    }
}
