using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Neuron.UI.Properties;

namespace Neuron.UI
{
    public partial class FormOptions : Form
    {
        private int recentFilesMax;

        private bool useSystemLanguage;

        public FormOptions()
        {
            InitializeComponent();

            recentFilesMax = Settings.Default.RecentFilesMax;
            recentFilesMaxTextBox.DataBindings.Add("Text", this, "RecentFilesMax");
            useSystemLanguage = Settings.Default.UseSystemLanguage;
            useSystemLanguageCheckBox.DataBindings.Add("Checked", this, "UseSystemLanguage");

            if (string.IsNullOrEmpty(Settings.Default.SelectedLanguage))
                Settings.Default.SelectedLanguage = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            var dt = new DataTable();
            dt.Columns.Add("Name", typeof (string));
            dt.Columns.Add("Value", typeof (string));
            dt.Rows.Add(strings.English, "en");
            dt.Rows.Add(strings.German, "de");
            dt.DefaultView.Sort = "Name";

            languageComboBox.DataSource = dt.DefaultView;
            languageComboBox.DisplayMember = "Name";
            languageComboBox.ValueMember = "Value";
            languageComboBox.SelectedValue = Settings.Default.SelectedLanguage;
            if (languageComboBox.SelectedIndex == -1)
                languageComboBox.SelectedIndex = 0;
        }

        public int RecentFilesMax
        {
            get { return recentFilesMax; }
            set
            {
                if (recentFilesMax == value)
                    return;
                if (value < 0 || value > RecentFileHandler.MaxRecentFiles)
                    return;

                recentFilesMax = value;
            }
        }

        public bool UseSystemLanguage
        {
            get { return useSystemLanguage; }
            set { useSystemLanguage = value; }
        }

        private void clearRecentFilesButton_Click(object sender, EventArgs e)
        {
           // Program.ApplictionForm.RecentFileHandler.Clear();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            bool changed = false;
            if (recentFilesMax != Settings.Default.RecentFilesMax)
            {
                Settings.Default.RecentFilesMax = recentFilesMax;
                changed = true;
            }

            if (Settings.Default.UseSystemLanguage != useSystemLanguage ||
                Settings.Default.SelectedLanguage != (string) languageComboBox.SelectedValue)
            {
                Settings.Default.UseSystemLanguage = UseSystemLanguage;
                Settings.Default.SelectedLanguage = (string) languageComboBox.SelectedValue;

                //Program.ShowMessage(strings.ProgramRestartSettings);

                changed = true;
            }

            if (changed)
                Settings.Default.Save();

            DialogResult = DialogResult.OK;
        }

        private void useSystemLanguageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            languageComboBox.Enabled = selectLanguageLabel.Enabled = !useSystemLanguageCheckBox.Checked;
        }
    }
}