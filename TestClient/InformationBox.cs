using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neuron.TestClient
{
    public partial class InformationBox : Form
    {
        public InformationBox()
        {
            InitializeComponent();
        }

        public void SetText(String text)
        {
            textBoxInformation.Clear();
            textBoxInformation.Text = text;
            textBoxInformation.Select(0, 0);
        }
    }
}
