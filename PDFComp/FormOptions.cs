using PdfiumViewer;
using System;
using System.Windows.Forms;

namespace PDFComp
{
    public partial class FormOptions : Form
    {
        public PdfTextStyleFlags StyleFlags => styleFlags;
        private PdfTextStyleFlags styleFlags;

        public FormOptions()
        {
            InitializeComponent();

            LoadSettings();

            panelCompare.Location = new System.Drawing.Point(0, 0);
            panelDisplay.Location = new System.Drawing.Point(0, 0);
            panelOthers.Location = new System.Drawing.Point(0, 0);
        }

        private void TreeViewOptions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                ShowPanel(e.Node.Text);
            }
        }

        private void ShowPanel(string nodeText)
        {
            panelCompare.Visible = false;
            panelDisplay.Visible = false;
            panelOthers.Visible = false;

            switch (nodeText)
            {
                case "Comparation":
                    panelCompare.Visible = true;
                    break;
                case "Display":
                    panelDisplay.Visible = true;
                    break;
                case "Others":
                    panelOthers.Visible = true;
                    break;
                default:
                    panelCompare.Visible = true;
                    break;
            }
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            // Reload saved settings.
            LoadSettings();

            // Select first node
            if (treeViewOptions.Nodes.Count > 0)
            {
                treeViewOptions.SelectedNode = treeViewOptions.Nodes[0];
            }
        }

        private void LoadSettings()
        {
            // Load "Others" panel settings
            try
            {
                chkReduceColorCopy.Checked = Properties.Settings.Default.EnableColorReductionCopy;
            }
            catch { }
            try
            {
                chkCopyBookmarkPage.Checked = Properties.Settings.Default.CopyBookmarkPage;
            }
            catch { }
            try
            {
                numericUpDownReducedColor.Value = Properties.Settings.Default.ReduceFinalColor;
            }
            catch { }

            // Load "Comparison" panel settings
            try
            {
                checkBoxCompareStyles.Checked = Properties.Settings.Default.CompareStyles;
            }
            catch { }

            try
            {
                chkCompareFillColor.Checked = Properties.Settings.Default.CompareFillColor;
            }
            catch { }

            try
            {
                chkCompareStrokeColor.Checked = Properties.Settings.Default.CompareStrokeColor;
            }
            catch { }

            try
            {
                chkCompareUnderlined.Checked = Properties.Settings.Default.CompareUnderlined;
            }
            catch { }

            try
            {
                chkCompareStrikethrough.Checked = Properties.Settings.Default.CompareStrikethrough;
            }
            catch { }

            try
            {
                chkCompareHighlighted.Checked = Properties.Settings.Default.CompareHighlighted;
            }
            catch { }

            try
            {
                chkCompareSquiggly.Checked = Properties.Settings.Default.CompareSquiggly;
            }
            catch { }

            try
            {
                chkCompareAnnotationColor.Checked = Properties.Settings.Default.CompareAnnotationColor;
            }
            catch { }

            // Update style flags based on checkboxes
            UpdateStyleFlags();

            // Update UI state based on CompareStyles checkbox
            groupBoxCompareStyle.Enabled = checkBoxCompareStyles.Checked;
        }

        private void UpdateStyleFlags()
        {
            // Update flag settings based on checkbox states.
            if (checkBoxCompareStyles.Checked)
            {
                styleFlags = PdfTextStyleFlags.None;
                styleFlags |= chkCompareFillColor.Checked ? PdfTextStyleFlags.FillColor : 0;
                styleFlags |= chkCompareStrokeColor.Checked ? PdfTextStyleFlags.StrokeColor : 0;
                styleFlags |= chkCompareUnderlined.Checked ? PdfTextStyleFlags.Underline : 0;
                styleFlags |= chkCompareStrikethrough.Checked ? PdfTextStyleFlags.Strikethrough : 0;
                styleFlags |= chkCompareHighlighted.Checked ? PdfTextStyleFlags.Highlight : 0;
                styleFlags |= chkCompareSquiggly.Checked ? PdfTextStyleFlags.Squiggly : 0;
                styleFlags |= chkCompareAnnotationColor.Checked ? PdfTextStyleFlags.AnnotationColor : 0;
            }
            else
            {
                styleFlags = PdfTextStyleFlags.None;
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            UpdateStyleFlags();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SaveSettings()
        {
            try
            {
                // Save "Others" panel settings
                Properties.Settings.Default.EnableColorReductionCopy = chkReduceColorCopy.Checked;
                Properties.Settings.Default.CopyBookmarkPage = chkCopyBookmarkPage.Checked;
                Properties.Settings.Default.ReduceFinalColor = (int)numericUpDownReducedColor.Value;

                // Save "Comparison" panel settings
                Properties.Settings.Default.CompareStyles = checkBoxCompareStyles.Checked;
                Properties.Settings.Default.CompareFillColor = chkCompareFillColor.Checked;
                Properties.Settings.Default.CompareStrokeColor = chkCompareStrokeColor.Checked;
                Properties.Settings.Default.CompareUnderlined = chkCompareUnderlined.Checked;
                Properties.Settings.Default.CompareStrikethrough = chkCompareStrikethrough.Checked;
                Properties.Settings.Default.CompareHighlighted = chkCompareHighlighted.Checked;
                Properties.Settings.Default.CompareSquiggly = chkCompareSquiggly.Checked;
                Properties.Settings.Default.CompareAnnotationColor = chkCompareAnnotationColor.Checked;

                // Save all settings
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckBoxCompareStyles_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxCompareStyle.Enabled = checkBoxCompareStyles.Checked;
        }

        private void ChkReduceColorCopy_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownReducedColor.Enabled = chkReduceColorCopy.Checked;
        }
    }
}
