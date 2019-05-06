﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfiumViewer;
using NetDiff;

namespace PDFComp
{
    public partial class PdfPanel : UserControl
    {
        List<int> _comparePage = null;
        List<PdfTextSpan> _indexes = null;
        double _zoom = 1.0;
        PdfRotation _rotation = PdfRotation.Rotate0;

        public PdfPanel()
        {
            InitializeComponent();
            pdfViewer.Renderer.DisplayRectangleChanged += Renderer_DisplayRectangleChanged;

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

        public void ClearDiffMarker(int oldPage)
        {
            // Rebuild markers except oldPage
            PdfMarker[] markers = new PdfMarker[pdfViewer.Renderer.Markers.Count];
            pdfViewer.Renderer.Markers.CopyTo(markers, 0);

            pdfViewer.Renderer.Markers.Clear();

            foreach(PdfMarker marker in markers)
            {
                if (marker.Page != oldPage)
                {
                    pdfViewer.Renderer.Markers.Add(marker);
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
                            0);

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

            toolStripTextBoxFile.Text = files[0];       // Drop only the first file.

            OpenFile(toolStripTextBoxFile.Text);
        }
        
        private void ToolStripButtonOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = toolStripTextBoxFile.Text;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                toolStripTextBoxFile.Text = openFileDialog.FileName;
                string fileName = toolStripTextBoxFile.Text;
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

    }
}
