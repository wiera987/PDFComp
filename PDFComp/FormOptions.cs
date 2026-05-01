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

            // Hide TabControl tab
            tabControlOptions.Appearance = TabAppearance.FlatButtons;
            tabControlOptions.SizeMode = TabSizeMode.Fixed;
            tabControlOptions.ItemSize = new System.Drawing.Size(0, 1);

            LoadSettings();
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
            switch (nodeText)
            {
                case "Text Styling":
                    tabControlOptions.SelectedTab = tabPageStyles;
                    break;
                case "Spaces & Breaks":
                    tabControlOptions.SelectedTab = tabPageWs;
                    break;
                case "Display Setting":
                    tabControlOptions.SelectedTab = tabPageDisplay;
                    break;
                case "Others":
                    tabControlOptions.SelectedTab = tabPageOthers;
                    break;
                default:
                    break;
            }
        }

        private void FormOptions_Shown(object sender, EventArgs e)
        {
            // Reload saved settings.
            LoadSettings();

            // Select first node
            if (treeViewOptions.Nodes.Count > 0)
            {
                treeViewOptions.SelectedNode = treeViewOptions.Nodes[0];
                treeViewOptions.Focus();
            }

            // Initialize the linked controls.
            int timeMS = Properties.Settings.Default.BlinkingPeriodMS;
            labelBlinkingPeriod.Text = timeMS + " ms";

            UpdateIgnoreWsWarning();
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

            // Load "Display" panel settings
            try
            {
                checkBoxBlinkingDiffMarker.Checked = Properties.Settings.Default.UseBlinkingDiffMarker;
            }
            catch { }
            try
            {
                trackBarBlinkingPeriod.Value = Properties.Settings.Default.BlinkingPeriodMS / 100;
            }
            catch { }

            // Load "Space & Breaks" panel settings
            try
            {
                checkBoxIgnoreWsOnly.Checked = Properties.Settings.Default.IgnoreWsOnly;
            }
            catch { }
            try
            {
                checkBoxWsSpace.Checked = Properties.Settings.Default.IgnoreWsSpace;
            }
            catch { }
            try
            {
                checkBoxWsTab.Checked = Properties.Settings.Default.IgnoreWsTab;
            }
            catch { }
            try
            {
                checkBoxWsBreaks.Checked = Properties.Settings.Default.IgnoreWsBreaks;
            }
            catch { }
            try
            {
                checkBoxWsFullWidthSpace.Checked = Properties.Settings.Default.IgnoreWsFullwidthSpace;
            }
            catch { }
            try
            {
                checkBoxWsOthers.Checked = Properties.Settings.Default.IgnoreWsOthers;
            }
            catch { }

            // Load "Text Styling" panel settings
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

            // Update UI state based on Ignore Whitespace only checkbox
            groupBoxIgnoreWsDetail.Enabled = checkBoxIgnoreWsOnly.Checked;

            // Update UI state based on Reduce Color Copy checkbox
            numericUpDownReducedColor.Enabled = chkReduceColorCopy.Checked;
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

                // Save "Display" panel settings
                Properties.Settings.Default.UseBlinkingDiffMarker = checkBoxBlinkingDiffMarker.Checked;
                Properties.Settings.Default.BlinkingPeriodMS = trackBarBlinkingPeriod.Value * 100;

                // Save "Space & Breaks" panel settings
                Properties.Settings.Default.IgnoreWsOnly = checkBoxIgnoreWsOnly.Checked;
                Properties.Settings.Default.IgnoreWsSpace = checkBoxWsSpace.Checked;
                Properties.Settings.Default.IgnoreWsTab = checkBoxWsTab.Checked;
                Properties.Settings.Default.IgnoreWsBreaks = checkBoxWsBreaks.Checked;
                Properties.Settings.Default.IgnoreWsFullwidthSpace = checkBoxWsFullWidthSpace.Checked;
                Properties.Settings.Default.IgnoreWsOthers = checkBoxWsOthers.Checked;

                // Save "Text Styling" panel settings
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

        private void checkBoxIgnoreWsOnly_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxIgnoreWsDetail.Enabled = checkBoxIgnoreWsOnly.Checked;
            UpdateIgnoreWsWarning();
        }

        private void ChkReduceColorCopy_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownReducedColor.Enabled = chkReduceColorCopy.Checked;
        }

        private void checkBoxBlinkDiffMarker_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBlinkingDiffMarker.Checked)
            {
                // Blink the diff marker for preview in the options form.
                label3.Enabled = true;
                labelBlinkingPeriod.Enabled = true;
                trackBarBlinkingPeriod.Enabled = true;
                int value = trackBarBlinkingPeriod.Value;
                int timeMS = value * 100;
                (this.Owner as FormMain)?.StartMarkerFlashing(timeMS);

            }
            else
            {
                // Stop blinking the diff marker.
                label3.Enabled = false;
                labelBlinkingPeriod.Enabled = false;
                trackBarBlinkingPeriod.Enabled = false;
                (this.Owner as FormMain)?.StopMarkerFlashing();
            }
        }

        private void trackBarBlinkingPeriod_ValueChanged(object sender, EventArgs e)
        {
            int value = trackBarBlinkingPeriod.Value;
            int timeMS = value * 100;
            labelBlinkingPeriod.Text = timeMS + " ms";
            (this.Owner as FormMain)?.StartMarkerFlashing(timeMS);
        }

        private void checkBoxWs_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxWsSpace.Checked = true;
            UpdateIgnoreWsWarning();
        }

        private void UpdateIgnoreWsWarning()
        {
            bool check = checkBoxWsSpace.Checked
                        || checkBoxWsTab.Checked
                        || checkBoxWsBreaks.Checked
                        || checkBoxWsFullWidthSpace.Checked
                        || checkBoxWsOthers.Checked;

            bool visible = checkBoxIgnoreWsOnly.Checked && (check == false);

            labelWsWarning.Visible = visible;
        }
    }
}
