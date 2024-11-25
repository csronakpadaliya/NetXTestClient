using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.Services.Description;
using System.Net;

using Wcf = System.ServiceModel.Description;
using Neuron.Design;
using System.IO;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Xml.Schema;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.Web.Services.Discovery;

namespace Neuron.UI
{
    public partial class SelectEndpointDialog : Form
    {
        public SelectEndpointDialog()
        {
            InitializeComponent();

            imageList.Images.Add(Properties.Resources.Wsdl.CreateTreeViewImage());
            imageList.Images.Add(Properties.Resources.Contract.CreateTreeViewImage());
            imageList.Images.Add(Properties.Resources.Operation.CreateTreeViewImage());                 
        }

        public Uri Url
        {
            get;
            set;
        }


        public enum BrowseBy
        {
            Neuron, UDDI, Url
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //cbBrowseType.DataSource = Enum.GetValues(typeof(BrowseBy));

            if (Url != null && !String.IsNullOrEmpty(Url.ToString()))
            {
                txtLocation.Text = Url.ToString();
                loadWsdl();
                
            }
        }



        Wcf.MetadataSet _metadata;
        public Wcf.MetadataSet Metadata
        {
            get
            {
                return _metadata;
            }
        }

        void loadWsdl()
        {
            try
            {
                if (txtLocation.Text.EndsWith(".svcmetadata"))
                {
                    using (TextReader tr = File.OpenText(txtLocation.Text))
                    {
                        using (System.Xml.XmlTextReader xr = new System.Xml.XmlTextReader(tr))
                        {
                            _metadata = System.ServiceModel.Description.MetadataSet.ReadFrom(xr);
                        }
                    }
                }
                else
                {              
                    MetadataExchangeClient client = MetadataExchangeClientHelper.CreateMetadataExchangeClient(new EndpointAddress(txtLocation.Text.Trim()), null);
                    if(!String.IsNullOrEmpty(UserName))
                    {
                        client.HttpCredentials = new NetworkCredential(UserName, Password);
                    }
                    client.MaximumResolvedReferences = Int32.MaxValue;

                    // try plain WSDL, if we fail...try mex
                    try
                    {
                        _metadata = client.GetMetadata(new Uri(txtLocation.Text), MetadataExchangeClientMode.HttpGet);
                    }
                    catch (InvalidOperationException oEx)
                    {
                        if (oEx.InnerException != null && oEx.InnerException.GetType().Equals(typeof(System.Net.WebException)))
                            _metadata = client.GetMetadata(new Uri(txtLocation.Text), MetadataExchangeClientMode.MetadataExchange);
                        else
                            throw;
                    }
                    //if(txtLocation.Text.EndsWith(@"\mex",StringComparison.InvariantCultureIgnoreCase) || txtLocation.Text.EndsWith(@"/mex",StringComparison.InvariantCultureIgnoreCase))
                    //    _metadata = client.GetMetadata(new Uri(txtLocation.Text), MetadataExchangeClientMode.MetadataExchange);
                    //else
                    //    _metadata = client.GetMetadata(new Uri(txtLocation.Text), MetadataExchangeClientMode.HttpGet);
                    try
                    {
                        bool success = displayDescription();
                        if (!success && !txtLocation.Text.EndsWith("?wsdl", StringComparison.InvariantCultureIgnoreCase))
                        {
                            _metadata = client.GetMetadata(new Uri(txtLocation.Text + "?wsdl"), MetadataExchangeClientMode.HttpGet);
                            success = displayDescription();
                            if (!success)
                                throw new Exception(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Service information cound not be located within the meta data service endpoint url, '{0}', provided. Please ensure the url is correct.", txtLocation.Text));
                            else
                                txtLocation.Text = txtLocation.Text + "?wsdl";
                        }

                    }
                    catch (Exception mex)
                    {
                        using (StringWriter sw = new StringWriter())
                        {
                            using (XmlWriter xw = XmlWriter.Create(sw, new XmlWriterSettings() { Indent = true }))
                            {
                                _metadata.WriteTo(xw);
                                xw.Flush();

                                ExceptionDialog.Show("Unable to read service definition", mex.Message, sw.ToString(), mex, false);
                                return;
                            }
                        }
                    }
                    Url = new Uri(txtLocation.Text);
                }
                btnImport.Enabled = true;
            }
            catch (Exception ex)
            {
                ExceptionDialog.Show("Unable to load WSDL", ex);
            }
        }

        public string UserName
        { 
            get
            {
                return txtUserName.Text;
            }
            set
            {
                txtUserName.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return txtPassword.Text;
            }
            set
            {
                txtPassword.Text = value;
            }
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadWsdl();
        }

        System.Web.Services.Description.Binding getBinding(XmlQualifiedName xn)
        {
            foreach (var ms in _metadata.MetadataSections)
            {
                System.Web.Services.Description.ServiceDescription desc = ms.Metadata as System.Web.Services.Description.ServiceDescription;
                if (desc != null)
                {
                    if (desc.TargetNamespace == xn.Namespace)
                    {
                        foreach (System.Web.Services.Description.Binding b in desc.Bindings)
                        {
                            if (b.Name == xn.Name)
                            {
                                return b;
                            }
                        }
                    }
                }
            }
            return null;
        }


        TreeView tvOperations;

        private bool displayDescription()
        {
            bool success = false;
            tvServices.Nodes.Clear();
            _portTreeViews.Clear();
            
            foreach (var section in Metadata.MetadataSections)
            {
                System.Web.Services.Description.ServiceDescription serviceDescription = section.Metadata as System.Web.Services.Description.ServiceDescription;
                if (serviceDescription != null)
                {
                    foreach (Service service in serviceDescription.Services)
                    {
                        success = true;

                        TreeNode serviceNode = new TreeNode();
                        serviceNode.Text = service.Name;
                        serviceNode.SelectedImageIndex = serviceNode.ImageIndex = 0;
                        serviceNode.Tag = service;
                        serviceNode.Checked = true;
                        tvServices.Nodes.Add(serviceNode);

                        foreach (Port port in service.Ports)
                        {
                            TreeNode contractNode = new TreeNode();
                            contractNode.Tag = port;
                            contractNode.SelectedImageIndex = contractNode.ImageIndex = 1;
                            contractNode.Text = port.Name;
                            contractNode.Checked = true;
                            serviceNode.Nodes.Add(contractNode);

                            tvOperations = new TreeView();
                            tvOperations.Dock = DockStyle.Fill;
                            tvOperations.HideSelection = true;
                            tvOperations.BorderStyle = BorderStyle.None;
                            tvOperations.ImageList = imageList;
                            _portTreeViews[port] = tvOperations;

                            System.Web.Services.Description.Binding binding = getBinding(port.Binding);
                            if (binding == null) throw new Exception("Could not locate the binding description for the port " + port.Name);
                            foreach (OperationBinding operation in binding.Operations)
                            {
                                TreeNode opNode = new TreeNode();
                                opNode.Text = operation.Name;
                                opNode.SelectedImageIndex = opNode.ImageIndex = 2;
                                opNode.Tag = operation;
                                opNode.Checked = true;
                                tvOperations.Nodes.Add(opNode);
                            }

                            tvOperations.ExpandAll();

                            tvServices.SelectedNode = contractNode;

                        }
                    }
                }
            }
            tvServices.ExpandAll();

            return success;
        }

        Dictionary<Port, TreeView> _portTreeViews = new Dictionary<Port, TreeView>();

        void displayOperations()
        {
            TreeNode contractNode = tvServices.SelectedNode;
            Port port = contractNode.Tag as Port;
            pnlOperations.Controls.Clear();
            if (port != null)
            {
                pnlOperations.Controls.Add(_portTreeViews[port]);
            }
            else
            {
                Label selectSomething = new Label();
                selectSomething.TextAlign = ContentAlignment.MiddleCenter;
                selectSomething.BackColor = Color.White;
                selectSomething.AutoSize = false;
                selectSomething.Dock = DockStyle.Fill;
                selectSomething.BackColor = Color.Gray;
                selectSomething.Text = "Select a contract to view its operations";
                pnlOperations.Controls.Add(selectSomething);
            }
        }

        public string ServiceName
        {
            get;
            set;
        }

        public string EndpointName
        {
            get;
            set;
        }

        public string Action
        {
            get;
            set;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (tvServices.SelectedNode == null || tvServices.SelectedNode.Parent == null)
            {
                MessageBox.Show("You must select an endpoint to continue.");
                return;
            }

            ServiceName = tvServices.SelectedNode.Parent.Text;
            EndpointName = tvServices.SelectedNode.Text;


            if (tvOperations.SelectedNode != null)
            {
                OperationBinding opBinding = tvOperations.SelectedNode.Tag as OperationBinding;
                SoapOperationBinding soapBinding = (SoapOperationBinding)opBinding.Extensions.Find(typeof(SoapOperationBinding));
                if (soapBinding != null)
                {
                    Action = soapBinding.SoapAction;
                }
            }

            DialogResult = DialogResult.OK;
            Close();        
        }

        private void tvOperations_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void tvServices_AfterSelect(object sender, TreeViewEventArgs e)
        {
            displayOperations();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


    }


    internal static class MetadataExchangeClientHelper
    {
        private const int MetadataExchangeClientTimeoutMinutes = 5;


        private static void AddDocumentToSet(MetadataSet metadataSet, object document)
        {
            System.Web.Services.Description.ServiceDescription serviceDescription = document as System.Web.Services.Description.ServiceDescription;
            XmlSchema schema = document as XmlSchema;
            XmlElement policy = document as XmlElement;
            if (serviceDescription != null)
            {
                metadataSet.MetadataSections.Add(MetadataSection.CreateFromServiceDescription(serviceDescription));
            }
            else if (schema != null)
            {
                metadataSet.MetadataSections.Add(MetadataSection.CreateFromSchema(schema));
            }
            else if ((policy != null) && IsPolicyElement(policy))
            {
                metadataSet.MetadataSections.Add(MetadataSection.CreateFromPolicy(policy, null));
            }
            else
            {
                MetadataSection item = new MetadataSection();
                item.Metadata = document;
                metadataSet.MetadataSections.Add(item);
            }
        }

        private static bool ClientEndpointExists(ClientSection clientSection, string scheme)
        {
            if (clientSection != null)
            {
                foreach (ChannelEndpointElement element in clientSection.Endpoints)
                {
                    if ((element.Name == scheme) && (element.Contract == "IMetadataExchange"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static void MaxServiceModelChannelsEncoderDefaults()
        {
            var serviceModelAssembly = AppDomain.CurrentDomain.GetAssemblies().First(a => a.FullName.StartsWith("System.ServiceModel,"));
            var encoderDefaultsType = serviceModelAssembly.GetType("System.ServiceModel.Channels.EncoderDefaults");
            var readerQuotas = (System.Xml.XmlDictionaryReaderQuotas)encoderDefaultsType.GetField("ReaderQuotas", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).GetValue(null);
            readerQuotas.MaxArrayLength = int.MaxValue;
            readerQuotas.MaxDepth = int.MaxValue;
            readerQuotas.MaxNameTableCharCount = int.MaxValue;
            readerQuotas.MaxStringContentLength = int.MaxValue; 
        }

        internal static MetadataExchangeClient CreateMetadataExchangeClient(EndpointAddress epr, ClientSection clientSection)
        {
            MaxServiceModelChannelsEncoderDefaults();
            string scheme = epr.Uri.Scheme;
            if (ClientEndpointExists(clientSection, scheme))
            {
                return new MetadataExchangeClient(epr);
            }
            if (string.Compare(scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) == 0)
            {
                WSHttpBinding binding = (WSHttpBinding)MetadataExchangeBindings.CreateMexHttpBinding();
                binding.MaxReceivedMessageSize = 0x4000000L;
                binding.ReaderQuotas.MaxArrayLength = Int32.MaxValue;
                binding.ReaderQuotas.MaxBytesPerRead = Int32.MaxValue;
                binding.ReaderQuotas.MaxDepth = Int32.MaxValue;
                binding.ReaderQuotas.MaxStringContentLength = Int32.MaxValue;
                binding.ReaderQuotas.MaxNameTableCharCount = Int32.MaxValue;
                return new MetadataExchangeClient(binding);
            }
            if (string.Compare(scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase) == 0)
            {
                WSHttpBinding binding2 = (WSHttpBinding)MetadataExchangeBindings.CreateMexHttpsBinding();
                binding2.ReaderQuotas.MaxArrayLength = Int32.MaxValue;
                binding2.ReaderQuotas.MaxBytesPerRead = Int32.MaxValue;
                binding2.ReaderQuotas.MaxDepth = Int32.MaxValue;
                binding2.ReaderQuotas.MaxStringContentLength = Int32.MaxValue;
                binding2.ReaderQuotas.MaxNameTableCharCount = Int32.MaxValue;

                return new MetadataExchangeClient(binding2);
            }
            if (string.Compare(scheme, Uri.UriSchemeNetTcp, StringComparison.OrdinalIgnoreCase) == 0)
            {
                CustomBinding binding3 = (CustomBinding)MetadataExchangeBindings.CreateMexTcpBinding();
                binding3.Elements.Find<TcpTransportBindingElement>().MaxReceivedMessageSize = 0x4000000L;

                return new MetadataExchangeClient(binding3);
            }
            if (string.Compare(scheme, Uri.UriSchemeNetPipe, StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw new InvalidOperationException("Cannot create metadata exchange client");
            }
            CustomBinding mexBinding = (CustomBinding)MetadataExchangeBindings.CreateMexNamedPipeBinding();
            mexBinding.Elements.Find<NamedPipeTransportBindingElement>().MaxReceivedMessageSize = 0x4000000L;
            return new MetadataExchangeClient(mexBinding);
        }

        internal static Uri GetDefaultMexUri(Uri serviceUri)
        {
            if (serviceUri.AbsoluteUri.EndsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                return new Uri(serviceUri, "./mex");
            }
            return new Uri(serviceUri.AbsoluteUri + "/mex");
        }

        internal static bool IsPolicyElement(XmlElement policy)
        {
            if (!(policy.NamespaceURI == "http://schemas.xmlsoap.org/ws/2004/09/policy") && !(policy.NamespaceURI == "http://www.w3.org/ns/ws-policy"))
            {
                return false;
            }
            return (policy.LocalName == "Policy");
        }


        public static MetadataSet ResolveMetadata(EndpointAddress epr, bool useDisco, ClientSection clientSection)
        {
            MetadataSet metadata;
            if (useDisco)
            {
                DiscoveryClientProtocol protocol = new DiscoveryClientProtocol();
                protocol.UseDefaultCredentials = true;
                protocol.AllowAutoRedirect = true;
                protocol.DiscoverAny(epr.Uri.AbsoluteUri);
                protocol.ResolveAll();
                metadata = new MetadataSet();
                foreach (object obj2 in protocol.Documents.Values)
                {
                    if (!(obj2 is DiscoveryDocument))
                    {
                        AddDocumentToSet(metadata, obj2);
                    }
                }
            }
            else
            {
                MetadataExchangeClient client = CreateMetadataExchangeClient(epr, clientSection);
                client.MaximumResolvedReferences = Int32.MaxValue;
                client.OperationTimeout = TimeSpan.FromMinutes(5.0);
                metadata = client.GetMetadata(epr);
            }

            return metadata;
        }

        private static bool TryResolveMetadata(Uri uri, bool useDisco, ClientSection clientSection, out Exception error, out MetadataSet resolvedMetadata)
        {
            try
            {
                resolvedMetadata = ResolveMetadata(new EndpointAddress(uri, new AddressHeader[0]), useDisco, clientSection);
                error = null;
                return true;
            }
            catch (Exception exception)
            {
                error = exception;
                resolvedMetadata = null;
                return false;
            }
        }

        private static bool UriSchemeSupportsDisco(Uri serviceUri)
        {
            if (!(serviceUri.Scheme == Uri.UriSchemeHttp))
            {
                return (serviceUri.Scheme == Uri.UriSchemeHttps);
            }
            return true;
        }

        private delegate bool TryResolveMetadataDelegate(Uri uri, bool useDisco, ClientSection clientSection, out Exception error, out IEnumerable<MetadataSection> resolvedMetadata);
    }

    
}
