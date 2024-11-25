using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Neuron.NetX;

namespace Neuron.TestClient
{
    public partial class FormCustomProperties : Form
    {
        public ESBMessage Message;

        public FormCustomProperties()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormCustomProperties_Load(object sender, EventArgs e)
        {
            DisplayProperties();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            Close();
        }

        private void DisplayProperties()
        {
            DataGridViewRow row;

            dataGridViewProperties.Rows.Clear();

            if (Message.Header.CustomProperties != null)
                foreach (NameValuePair nvp in Message.Header.CustomProperties)
                {
                    string prefix = "";
                    string name = "";

                    if (nvp.Name.Contains("."))
                    {
                        int indexOfPrefixSep = nvp.Name.IndexOf('.');
                        prefix = nvp.Name.Substring(0, indexOfPrefixSep);
                        name = nvp.Name.Substring(indexOfPrefixSep + 1);
                    }

                    DataGridViewTextBoxCell cellPrefix = new DataGridViewTextBoxCell { Value = prefix };
                    DataGridViewTextBoxCell cellName = new DataGridViewTextBoxCell { Value = name };
                    DataGridViewTextBoxCell cellValue = new DataGridViewTextBoxCell { Value = nvp.Value };

                    row = new DataGridViewRow();
                    row.Cells.Add(cellPrefix);
                    row.Cells.Add(cellName);
                    row.Cells.Add(cellValue);

                    dataGridViewProperties.Rows.Add(row);
                }
        }

        private void ApplyChanges()
        {
            List<NameValuePair> properties = new List<NameValuePair>();

            for (int r = 0; r < dataGridViewProperties.Rows.Count - 1; r++)
            {
                string prefix = (string)dataGridViewProperties.Rows[r].Cells[0].Value;
                string name = (string)dataGridViewProperties.Rows[r].Cells[1].Value;
                string value = (string)dataGridViewProperties.Rows[r].Cells[2].Value;

                if (!String.IsNullOrEmpty(name))
                {
                    NameValuePair nvp = new NameValuePair(prefix + "." + name, value);
                    properties.Add(nvp);
                }
            }
            Message.Header.CustomProperties = properties.Count == 0 ? null : properties.ToArray();
        }
    }
}
