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
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();

            string appVersion = Application.ProductVersion;
            labelAoutVerNo.Text = appVersion;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormAbout_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void LabelAboutLicense_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.apache.org/licenses/LICENSE-2.0");
        }

        private void labelPDFComp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(labelPDFComp.Text);
        }
    }
}
