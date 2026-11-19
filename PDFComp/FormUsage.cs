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
    public partial class FormUsage : Form
    {
        public FormUsage()
        {
            InitializeComponent();
            string defaultLinkText = linkLabelHowTo.Text;
            LinkArea defaultLinkArea = linkLabelHowTo.LinkArea;
            UiLanguages.Bind(this, () =>
            {
                string title = UiLanguages.Text("Usage.HelpLinkText",
                    defaultLinkText.Substring(defaultLinkArea.Start, defaultLinkArea.Length));
                int start = linkLabelHowTo.Text.IndexOf(title, StringComparison.Ordinal);
                if (start >= 0)
                {
                    linkLabelHowTo.LinkArea = new LinkArea(start, title.Length);
                }
                else
                {
                    // Keep the original English link when a partial translation omits its matching title.
                    linkLabelHowTo.Text = defaultLinkText;
                    linkLabelHowTo.LinkArea = defaultLinkArea;
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormUsage_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void linkLabelHowTo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/wiera987/PDFComp/wiki");
        }
    }
}
