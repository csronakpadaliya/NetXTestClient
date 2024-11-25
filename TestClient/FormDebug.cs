using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using ActiproSoftware.Text.Languages.Xml.Implementation;

namespace Neuron.TestClient
{
    public partial class FormDebug : Form
    {
        //private XmlSchemaResolver schemaResolver;

        public FormDebug()
        {
            InitializeComponent();

            // Start the parser service (only call this once at the start of your application)
            //SemanticParserService.Start();

            // Load the language definitions (reuse language instance)
            //XmlSyntaxLanguage xmlLanguage = new XmlSyntaxLanguage();
            //xmlEditorBody.Document.FileName = "XmlBody.xml";
            //xmlEditorBody.Document.Language = xmlLanguage;

            // Initialize a schema resolver for the XML document and initialize it with the dynamic language schema
            //schemaResolver = new XmlSchemaResolver();
            //xmlEditorBody.Document.LanguageData = schemaResolver;
        }

        private void FormDebug_Load(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonContinueWithoutDebugging_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelBottomRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonCopyMessage_Click(object sender, EventArgs e)
        {
            //Clipboard.SetText(xmlEditorBody.Text, TextDataFormat.Rtf);
            try
            {
                Clipboard.SetText(xmlEditorBody.Text, TextDataFormat.Rtf);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to copy: " + ex.Message);
            }
        }
    }
}