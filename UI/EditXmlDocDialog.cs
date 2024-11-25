//extern alias actiproforms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using ActiproSoftware.Products.SyntaxEditor.Addons.Xml;
using System.Xml.Xsl;
using System.Xml;
using System.Xml.Schema;
using System.IO;
//using actiproforms::ActiproSoftware.Text.Languages.Xml.Implementation;
//using ActiproSoftware.Windows.Controls.SyntaxEditor;
using ActiproSoftware.Text.Languages.Xml.Implementation;
using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
using Neuron.Explorer;

namespace Neuron.UI
{
    public enum XmlDocType
    {
        Xslt,
        Xsd,
        Xml
    }

    public partial class EditXmlDocDialog : Form
    {        
        public EditXmlDocDialog()
        {
            InitializeComponent();
            ResizeUtil.ScaleAll(this);

            XmlSyntaxLanguage xmlLanguage = new XmlSyntaxLanguage();
            xmlEditor.Document.FileName = "Xslt.xml";
            xmlEditor.Document.Language = (ActiproSoftware.Text.ISyntaxLanguage)xmlLanguage;
            //xmlEditor = ActiproSoftware.Windows.Controls.SyntaxEditor.IndentMode.Smart;
            //syntaxEditorTransform.WordWrap = ActiproSoftware.SyntaxEditor.WordWrapType.Word;

            // Initialize a schema resolver for the XML document and initialize it with the dynamic language schema
            XmlSchemaResolver schemaResolver = new XmlSchemaResolver();
            xmlEditor.Document.LanguageData = schemaResolver;

            xmlEditor.Document.IsReadOnly = false;

            XmlDocType = XmlDocType.Xslt;

        }
        
        public XmlDocType XmlDocType { get; set; }

        public string Xml
        {
            get
            {
                return XmlDocument == null ? null : XmlDocument.OuterXml;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    XmlDocument = null;
                }
                else
                {
                    if (XmlDocument == null)
                    {
                        XmlDocument = new System.Xml.XmlDocument();
                        XmlDocument.PreserveWhitespace = true;
                    }
                    XmlDocument.LoadXml(value);
                }
            }
        }
        private XmlDocument _xmlDocument;
        public XmlDocument XmlDocument 
        {
            get 
            {
                if (xmlEditor != null && xmlEditor.Text.Length > 0)
                {
                    _xmlDocument = new XmlDocument();
                    _xmlDocument.PreserveWhitespace = true;
                    _xmlDocument.LoadXml(xmlEditor.Text);
                }
                return _xmlDocument;
            }
            set
            {
                _xmlDocument = value;
                if (value != null)
                {
                    xmlEditor.Text = _xmlDocument.OuterXml;
                }                       
           }
        }

        public string Heading
        {
            get
            {
                return lblHeader.Text;
            }
            set
            {
                lblHeader.Text = value;
            }
        }

        private void EditXmlDocDialog_Load(object sender, EventArgs e)
        {
            if (_xmlDocument != null)
            {
                xmlEditor.Text = _xmlDocument.OuterXml;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (XmlDocType == XmlDocType.Xslt) 
                {
                    XslCompiledTransform compiledTransform = new XslCompiledTransform();
                    compiledTransform.Load(XmlDocument.CreateNavigator());
                }
                else if (XmlDocType == XmlDocType.Xsd)
                {
                    XmlDocument doc = XmlDocument; //force a validation
                    XmlSchema schema = XmlSchema.Read(new XmlTextReader(new StringReader(doc.OuterXml)), new ValidationEventHandler(SchemaReadError));
                }
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show("The Xml document is invalid", ex);
                return;
            }


            this.DialogResult = DialogResult.OK;

            Close();
        }

        protected static void SchemaReadError(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    throw new XmlException(e.Message);
                case XmlSeverityType.Warning:
                    break;
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (XmlDocType == XmlDocType.Xslt)
            {
                dialog.Title = "Open XSLT Document";
                dialog.Filter = "XSLT Documents (*.xml;*.xsl;*.xslt)|*.xml;*.xsl;*.xslt|All Files (*.*)|*.*";
            }
            else if (XmlDocType == XmlDocType.Xsd)
            {
                dialog.Title = "Open XSD Document";
                dialog.Filter = "XSD Documents (*.xml;*.xsd)|*.xml;*.xsd|All Files (*.*)|*.*";
            }
            else
            {
                dialog.Title = "Open XML Document";
                dialog.Filter = "XML Documents (*.xml)|*.xml|All Files (*.*)|*.*";
            }
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string xml;
                    using (TextReader tr = File.OpenText(dialog.FileName))
                    {
                        xml = tr.ReadToEnd();
                    }
                    xmlEditor.Text = xml;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load document: " + ex.Message);
                }
            }
        }

         private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xmlEditor.ActiveView.CopyToClipboard();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xmlEditor.ActiveView.PasteFromClipboard();
        }
    }
}
