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
    public partial class FormDiffInfo : Form
    {
        private Color richBackColor;

        public FormDiffInfo()
        {
            InitializeComponent();
            richBackColor = Color.White;
        }

        public void ToggleBackColor()
        {
            if (richBackColor == Color.White)
            {
                richBackColor = Color.Gainsboro;
            }
            else
            {
                richBackColor = Color.White;
            }
        }

        public void WriteText(string text, Color color)
        {
#if DEBUG
            richTextBoxInfo.SelectionStart = richTextBoxInfo.TextLength;
            richTextBoxInfo.SelectionLength = 0;
            richTextBoxInfo.SelectionColor = color;
            richTextBoxInfo.SelectionBackColor = richBackColor;

            // Slapdash way to change the background of an entire line.
            text = text.Replace("\r\n", new string(' ', 256)+"\r\n");
            richTextBoxInfo.AppendText(text);
#endif
        }

        public void ScrollToCaret()
        {
            richTextBoxInfo.ScrollToCaret();
        }


        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBoxInfo.Clear();
        }

        private void FormDiffInfo_Resize(object sender, EventArgs e)
        {
            pictureBoxRight.Width = richTextBoxInfo.Width / 2 - 5;
            pictureBoxLeft.Width = richTextBoxInfo.Width / 2 - 5;
            pictureBoxRight.Location = new Point(richTextBoxInfo.Width / 2 + 8, pictureBoxRight.Location.Y);
        }

        private void FormDiffInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            // イベントキャンセルしてフォームが閉じないようにする
            Hide();
            e.Cancel = true;
        }
    }
}
