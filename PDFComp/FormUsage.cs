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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormUsage_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }
    }
}
