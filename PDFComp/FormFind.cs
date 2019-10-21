using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFComp
{
    public partial class FormFind : Form
    {
        private bool _findDirty1;
        private bool _findDirty2;
        public PdfPanel _pdfPanel1;
        public PdfPanel _pdfPanel2;

        public FormFind()
        {
            InitializeComponent();

            _findDirty1 = true;
            _findDirty2 = true;
        }

        private void TextBoxFind_TextChanged(object sender, EventArgs e)
        {
            _findDirty1 = true;
            _findDirty2 = true;
        }

        private void CheckBoxMatchCase_CheckedChanged(object sender, EventArgs e)
        {
            _findDirty1 = true;
            _findDirty2 = true;
        }

        private void CheckBoxMatchWholeWord_CheckedChanged(object sender, EventArgs e)
        {
            _findDirty1 = true;
            _findDirty2 = true;
        }

        private void CheckBoxHighlightAll_CheckedChanged(object sender, EventArgs e)
        {
            _findDirty1 = true;
            _findDirty2 = true;
        }

        private void FormFind_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:   // Find the left document.
                    buttonNext1.PerformClick();
                    break;
                case Keys.F4:   // Find the right document.
                    buttonNext2.PerformClick();
                    break;
            }
        }

        private void ButtonNext1_Click(object sender, EventArgs e)
        {
            bool forward = !((ModifierKeys & Keys.Shift) == Keys.Shift);

            if (_pdfPanel1.pdfViewer.Document != null)
            {
                if (_findDirty1)
                {
                    _findDirty1 = false;

                    if (!_pdfPanel1.Search(textBoxFind.Text,
                                            checkBoxMatchCase.Checked,
                                            checkBoxMatchWholeWord.Checked,
                                            checkBoxHighlightAll.Checked))
                    {
                        MessageBox.Show(this, "No matches found.", "PDFComp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (!_pdfPanel1.FindNext(forward))
                {
                    MessageBox.Show(this, "No more matches were found.", "PDFComp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ButtonNext2_Click(object sender, EventArgs e)
        {
            bool forward = !((ModifierKeys & Keys.Shift) == Keys.Shift);

            if (_pdfPanel2.pdfViewer.Document != null)
            {
                if (_findDirty2)
                {
                    _findDirty2 = false;

                    if (!_pdfPanel2.Search(textBoxFind.Text,
                                            checkBoxMatchCase.Checked,
                                            checkBoxMatchWholeWord.Checked,
                                            checkBoxHighlightAll.Checked))
                    {
                        MessageBox.Show(this, "No matches found.", "PDFComp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (!_pdfPanel2.FindNext(forward))
                {
                    MessageBox.Show(this, "No more matches were found.", "PDFComp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FormFind_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Call Hide() when the Close button is pressed.
                e.Cancel = true;
                this.Hide();
            }
        }

        private void FormFind_Activated(object sender, EventArgs e)
        {
            textBoxFind.Focus();
        }
    }
}
