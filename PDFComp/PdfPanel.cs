using System;
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

        public void AddDiffMarker()
        {
            if (_indexes != null)
            {
                Console.WriteLine("AddDiffMarker Page{0}:Count{1}", pdfViewer.Renderer.Page, _indexes.Count);

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
                            pdfViewer.Renderer.Page,
                            boundsRect,
                            Color.FromArgb(64, Color.Red),
                            Color.FromArgb(64, Color.Red),
                            0);

                        pdfViewer.Renderer.Markers.Add(marker);

                        //Console.WriteLine("Added");
                    }

                }

            }
        }

        private void ToolStripButtonOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = toolStripTextBoxFile.Text;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                toolStripTextBoxFile.Text = openFileDialog.FileName;
                pdfViewer.Document = PdfDocument.Load(toolStripTextBoxFile.Text);
                pdfViewer.Renderer.Zoom = _zoom;
                pdfViewer.Renderer.Rotation = _rotation;

                toolStripLabelPage.Text = 1.ToString();
                toolStripLabelPages.Text = pdfViewer.Document.PageCount.ToString();
                toolStripTextBoxFile.ToolTipText = toolStripTextBoxFile.Text;
            }
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
