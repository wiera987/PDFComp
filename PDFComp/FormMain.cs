﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfiumViewer;
using NetDiff;

namespace PDFComp
{
    public partial class FormMain : Form
    {
        readonly Double ZoomInScale = 0.1;
        readonly Double ZoomOutScale = 0.03;
        private bool _findDirty1;
        private bool _findDirty2;
        PdfRotation rotation;
        Double zoom;
        Boolean zoomIn;
        Boolean zoomOut;

        public FormMain()
        {
            InitializeComponent();

            zoom = 1.0;
            zoomIn = false;
            zoomOut = false;
            rotation = PdfRotation.Rotate0;
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

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
                return;
            }

            var stopwatch = new System.Diagnostics.Stopwatch();

            int page1 = pdfPanel1.pdfViewer.Renderer.Page;
            int page2 = pdfPanel2.pdfViewer.Renderer.Page;

            if ((pdfPanel1.GetComparedPage(page1) == page2) && (pdfPanel2.GetComparedPage(page2) == page1))
            {
                return;
            }

            if (pdfPanel1.GetComparedPage(page1) >= 0)
            {
                pdfPanel1.ClearDiffMarker(page1);
            }
            if (pdfPanel2.GetComparedPage(page2) >= 0)
            {
                pdfPanel2.ClearDiffMarker(page2);
            }

            stopwatch.Stop();
            Console.WriteLine("Clear:{0}", stopwatch.Elapsed);
            stopwatch.Start();

            String text1 = pdfPanel1.GetPageText();
            String text2 = pdfPanel2.GetPageText();
            List<PdfTextSpan> index1 = new List<PdfTextSpan>();
            List<PdfTextSpan> index2 = new List<PdfTextSpan>();

            stopwatch.Stop();
            Console.WriteLine("Get:{0}", stopwatch.Elapsed);
            stopwatch.Start();

            var results = DiffUtil.Diff(text1, text2);

            stopwatch.Stop();
            Console.WriteLine("Diff:{0}", stopwatch.Elapsed);
            stopwatch.Start();



            ExtractDiffSpan(index1, index2, results, page1, page2);

            pdfPanel1.SetPageDiff(index1);
            pdfPanel2.SetPageDiff(index2);

            stopwatch.Stop();
            Console.WriteLine("Index:{0}", stopwatch.Elapsed);
            stopwatch.Start();

            pdfPanel1.AddDiffMarker(page2);
            pdfPanel2.AddDiffMarker(page1);

            stopwatch.Stop();
            Console.WriteLine("Marker:{0}", stopwatch.Elapsed);

            //results.ToList().ForEach(r => Console.WriteLine(r.ToFormatString()));

            pdfPanel1.Invalidate();
            pdfPanel2.Invalidate();
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

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            _findDirty1 = true;
            _findDirty2 = true;
        }

        private void ButtonSearch1_Click(object sender, EventArgs e)
        {
            if (pdfPanel1.pdfViewer.Document != null)
            {
                PdfSearchManager _searchManager = new PdfSearchManager(pdfPanel1.pdfViewer.Renderer);

                if (_findDirty1)
                {
                    _findDirty1 = false;

                    if (!_searchManager.Search(textBoxSearch.Text))
                    {
                        MessageBox.Show(this, "No matches found.");
                        return;
                    }
                }

                if (!_searchManager.FindNext(true))
                    MessageBox.Show(this, "Find reached the starting point of the search.");
            }

        }

        private void ButtonSearch2_Click(object sender, EventArgs e)
        {
            if (pdfPanel2.pdfViewer.Document != null)
            {
                PdfSearchManager _searchManager = new PdfSearchManager(pdfPanel2.pdfViewer.Renderer);

                if (_findDirty2)
                {
                    _findDirty2 = false;

                    if (!_searchManager.Search(textBoxSearch.Text))
                    {
                        MessageBox.Show(this, "No matches found.");
                        return;
                    }
                }

                if (!_searchManager.FindNext(true))
                    MessageBox.Show(this, "Find reached the starting point of the search.");
            }
        }


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((pdfPanel1.pdfViewer.Document != null) || (pdfPanel2.pdfViewer.Document != null))
            {
                Bitmap bitmap = new Bitmap(panelBoth.ClientSize.Width, panelBoth.ClientSize.Height);
                panelBoth.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                Clipboard.SetImage(bitmap);
            }
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

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdfPanel1.toolStripButtonOpen.PerformClick();
            pdfPanel2.toolStripButtonOpen.PerformClick();
        }
    }
}
