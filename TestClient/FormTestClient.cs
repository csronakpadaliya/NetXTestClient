
// ***************************************************
// *                                                 *
// *  Enterprise Service Bus - WinForms test client  *
// *                                                 *
// ***************************************************

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Transactions;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
//using ActiproSoftware.UI.WinForms.Controls.SyntaxEditor;
//using ActiproSoftware.Text.Languages.Xml.Implementation;
using Neuron.NetX.Internal;
using Neuron.NetX.Administration;
using System.Reflection;
using System.Runtime.Serialization;
using Neuron.NetX;
using Neuron.NetX.Channels;
using Neuron.UI;
using System.Net;
using System.Net.NetworkInformation;
namespace Neuron.TestClient
{
    using System.Globalization;
    using System.ComponentModel;
    using Neuron.NetX.Pipelines;
    //using ActiproSoftware.Text;

    /// <summary>
    /// *********************
    /// *                   *
    /// *  ESB Test Client  *
    /// *                   *
    /// *********************
    /// </summary>

    public partial class FormTestClient : Form
    {
        CommandArguments Arguments = null;
        NetworkCredential _clientCredentials = null;

        /// <summary> The Party object that does all the sending and recieving of messages. </summary>
        Party _client = null;

        Neuron.NetX.Data.MessageCounter sendMessageCounter = new Neuron.NetX.Data.MessageCounter();
        Neuron.NetX.Data.MessageCounter receiveMessageCounter = new Neuron.NetX.Data.MessageCounter();

        private object _syncStatus = new object();

        private System.Timers.Timer onlineTimer = null;
        private bool timerExecuting = false;

        private bool _stopSending = false;
        private ReaderWriterLockSlim _syncStopSending = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        private static class MessageMenuConstants
        {
            public const string Format = "Format";
        }

        private enum MessageMenuOptions
        {
            [Description(MessageMenuConstants.Format)]
            Format
        }
        private bool StopSending
        {
            get
            {
                try
                {
                    _syncStopSending.EnterReadLock();
                    return _stopSending;
                }
                finally
                {
                    _syncStopSending.ExitReadLock();
                }
            }
            set
            {
                try
                {
                    _syncStopSending.EnterWriteLock();
                    _stopSending = value;
                }
                finally
                {
                    _syncStopSending.ExitWriteLock();
                }
            }
        }

        private ESBMessage _sendCustomProperties = new ESBMessage();   // Custom properties to send with.

        private ESBMessage _historySelectedMessage = null;

        //private XmlSchemaResolver schemaResolver;

        private ESBMessage _lastReceivedMessage = null;    // Last message received.
        private ESBMessage _lastSentMessage = null;        // Last message sent.
        public string _requestId = "";             // Id of last request message waiting for a reply.

        Dictionary<string, ESBMessage> _messageHistory = new Dictionary<string, ESBMessage>();
        // Collection of messages for message history.
        int _messageHistoryLimit = 10;             // Maximum messages to keep in history setting.

        static Thread _sendThread = null;

        private bool _sending = false;

        // properties used to connect to esb server. populated by testclientsettings
        private string InstanceName { get; set; }
        private string Machine { get; set; }
        private int Port { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string Domain { get; set; }
        private string ServiceIdentity { get; set; }

        public FormTestClient(CommandArguments arguments) : this()
        {
            this.Arguments = arguments;
        }

        public FormTestClient()
        {
            InitializeComponent();

            EnableFilterComponents(false);

            // Start the parser service (only call this once at the start of your application)
            //SemanticParserService.Start();

            // Load the language definitions (reuse language instance)
            //XmlSyntaxLanguage xmlLanguage = new XmlSyntaxLanguage();
            //xmlEditorSend.Document.FileName = "SendXml.xml";
            //xmlEditorSend.Document.Language = xmlLanguage;

            //xmlEditorBody.Document.FileName = "HistoryXml.xml";
            //xmlEditorBody.Document.Language = xmlLanguage;

            //xmlEditorReceive.Document.FileName = "ReceiveXml.xml";
            //xmlEditorReceive.Document.Language = xmlLanguage;

            // Initialize a schema resolver for the XML document and initialize it with the dynamic language schema
            //schemaResolver = new XmlSchemaResolver();
            //xmlEditorSend.Document.LanguageData = schemaResolver;
            //xmlEditorReceive.Document.LanguageData = schemaResolver;
            //xmlEditorBody.Document.LanguageData = schemaResolver;

            xmlEditorSend.ContextMenuStrip = new ContextMenuStrip();
            xmlEditorReceive.ContextMenuStrip = new ContextMenuStrip();
            xmlEditorBody.ContextMenuStrip = new ContextMenuStrip();

            AddContextMenuItems();
        }
        /// <summary>
        /// Clears and adds menue items to the context menu
        /// </summary>
        private void AddContextMenuItems()
        {
            //if(xmlEditorSend.ContextMenuStrip == null)
            //{
            //    xmlEditorSend.ContextMenuStrip = new
            //}

            //xmlEditorSend.MenuRequested -= new EventHandler<SyntaxEditorMenuEventArgs>(xmlEditorSend_ContextMenuRequested);
            //xmlEditorReceive.MenuRequested -= new EventHandler<SyntaxEditorMenuEventArgs>(xmlEditorReceive_ContextMenuRequested);
            //xmlEditorBody.MenuRequested -= new EventHandler<SyntaxEditorMenuEventArgs>(xmlEditorBody_ContextMenuRequested);

            //xmlEditorSend.MenuRequested += new EventHandler<SyntaxEditorMenuEventArgs>(xmlEditorSend_ContextMenuRequested);
            //xmlEditorReceive.MenuRequested += new EventHandler<SyntaxEditorMenuEventArgs>(xmlEditorReceive_ContextMenuRequested);
            //xmlEditorBody.MenuRequested += new EventHandler<SyntaxEditorMenuEventArgs>(xmlEditorBody_ContextMenuRequested);
        }

        //private void xmlEditorSend_ContextMenuRequested(object sender, SyntaxEdit`orMenuEventArgs e)
        //{
        //    //MenuItem menuFormatMessage = new MenuItem(MessageMenuOptions.Format.Description(), new EventHandler(MessageMenu_Events))
        //    //{
        //    //    Enabled = true
        //    //};

        //    ContextMenuStrip menu = e.Menu;// xmlEditorSend.ContextMenu;
        //    menu.Items.Add("-");// new MenuItem("-"));
        //    var formatItem = menu.Items.Add(MessageMenuOptions.Format.Description());
        //    formatItem.Enabled = true;
        //    formatItem.Click += new EventHandler(MessageMenu_Events);
        //    //xmlEditorSend.IsDefaultContextMenuEnabled = false;
        //    menu.Show(xmlEditorSend, Cursor.Position);
        //}
        //private void xmlEditorReceive_ContextMenuRequested(object sender, SyntaxEditorMenuEventArgs e)
        //{
        //    ContextMenuStrip menu = e.Menu;
        //    menu.Items.Add("-");
        //    var formatItem = menu.Items.Add(MessageMenuOptions.Format.Description());
        //    formatItem.Enabled = true;
        //    formatItem.Click += new EventHandler(MessageMenu_Events);
        //    menu.Show(xmlEditorReceive, Cursor.Position);
        //}
        //private void xmlEditorBody_ContextMenuRequested(object sender, SyntaxEditorMenuEventArgs e)
        //{
        //    ContextMenuStrip menu = e.Menu;
        //    menu.Items.Add("-");
        //    var formatItem = menu.Items.Add(MessageMenuOptions.Format.Description());
        //    formatItem.Enabled = true;
        //    formatItem.Click += new EventHandler(MessageMenu_Events);
        //    menu.Show(xmlEditorBody, Cursor.Position);
        //}
        //private void MessageMenu_Events(Object sender, EventArgs e)
        //{
        //    if (sender == null) MessageBox.Show("Could not determine the menu to use.", "Invalid Menu Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    ToolStripMenuItem currentItem = (ToolStripMenuItem)sender;

        //    if (currentItem.Text == MessageMenuOptions.Format.Description())
        //    {
        //        xmlSyntaxLanguage1.GetService<ITextFormatter>().Format(xmlEditorSend.Document.CurrentSnapshot, TextPositionRange.CreateCollection(xmlEditorSend.Document.CurrentSnapshot.TextRangeToPositionRange(xmlEditorSend.Document.CurrentSnapshot.TextRange), false));
        //        xmlSyntaxLanguage1.GetService<ITextFormatter>().Format(xmlEditorReceive.Document.CurrentSnapshot, TextPositionRange.CreateCollection(xmlEditorReceive.Document.CurrentSnapshot.TextRangeToPositionRange(xmlEditorReceive.Document.CurrentSnapshot.TextRange), false));
        //        xmlSyntaxLanguage1.GetService<ITextFormatter>().Format(xmlEditorBody.Document.CurrentSnapshot, TextPositionRange.CreateCollection(xmlEditorBody.Document.CurrentSnapshot.TextRangeToPositionRange(xmlEditorBody.Document.CurrentSnapshot.TextRange), false)); 
        //    }
        //}
        private void DisplaySubscriptions(PartyConnectExceptions result)
        {
            lock (_syncStatus)
            {
                dataGridViewSubscriptions.Rows.Clear();

                // Clear out the send topic combo box as it will be re-populated with subscriber subscriptions.
                comboBoxSendTopic.Items.Clear();
                comboBoxSendTopic.Text = "";

                if (_client.Context == null) return;
                if (_client.Context.Subscriber.Subscriptions == null || _client.Context.Subscriber.Subscriptions.Length == 0) return;

                Array.Sort(_client.Context.Subscriber.Subscriptions);

                foreach (Subscription subscription in _client.Context.Subscriber.Subscriptions)
                {
                    ESBTopicContext topicContext = _client.Context.TopicContexts[ESBHelper.TopicRoot(subscription.TopicName)];

                    DataGridViewRow row = new DataGridViewRow();

                    DataGridViewTextBoxCell cellTopic = new DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell cellDirection = new DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell cellStatus = new DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell cellTransport = new DataGridViewTextBoxCell();

                    row.Cells.Add(cellTopic);
                    row.Cells.Add(cellDirection);
                    row.Cells.Add(cellStatus);
                    row.Cells.Add(cellTransport);

                    bool online = topicContext.IsOnline == 1; // 1 == online, -1 means unitialized, 0 means offline
                    cellTopic.Value = subscription.TopicName;
                    cellTransport.Value = EsbChannelFactory.CreateChannelProperties(topicContext.ChannelType).DisplayName;

                    cellDirection.Value = "Unspecified";

                    if (subscription.CanWrite && subscription.CanRead) cellDirection.Value = "Send, Receive";
                    else if (subscription.CanRead) cellDirection.Value = "Receive";
                    else if (subscription.CanWrite) cellDirection.Value = "Send";

                    cellStatus.Value = online ? "ONLINE" : "OFFLINE";

                    PartyConnectExceptionItem item = result.GetResult(ESBHelper.TopicRoot(subscription.TopicName));
                    if (item != null)
                    {
                        ErrorListBoxItem errorItem = new ErrorListBoxItem();
                        errorItem.Exception = item.Exception;
                        errorItem.Detail = "Error occurred on topic : " + item.Topic + ". " + item.Exception.Message;
                        listBoxErrors.Items.Add(errorItem);
                    }

                    if (online)
                    {
                        cellStatus.Style.ForeColor = Color.ForestGreen;
                        cellStatus.Style.SelectionForeColor = Color.ForestGreen;
                    }
                    else
                    {
                        cellStatus.Style.ForeColor = Color.IndianRed;
                        cellStatus.Style.SelectionForeColor = Color.IndianRed;
                    }
                    dataGridViewSubscriptions.Rows.Add(row);

                    // Populate the send topic combo box with the topic subscription, but strip off the .* from the subscription.
                    String comboBoxEntry = subscription.TopicName;

                    if (ESBHelper.TopicWritePermitted(subscription.TopicName, _client.Context.Subscriber.Subscriptions))
                    {
                        if (subscription.TopicName.EndsWith(".*")) comboBoxEntry = subscription.TopicName.Substring(0, subscription.TopicName.Length - 2);
                        comboBoxSendTopic.Items.Add(comboBoxEntry);

                        if (comboBoxSendTopic.Text == "") comboBoxSendTopic.Text = comboBoxEntry;
                    }
                }

                comboBoxSendTopic.DropDownWidth = DropDownWidth(comboBoxSendTopic);
            }
        }

        public int DropDownWidth(System.Windows.Forms.ComboBox myCombo)
        {
            try
            {
                int maxWidth = 0, temp = 0;
                foreach (var obj in myCombo.Items)
                {
                    temp = System.Windows.Forms.TextRenderer.MeasureText(myCombo.GetItemText(obj), myCombo.Font).Width;
                    if (temp > maxWidth)
                    {
                        maxWidth = temp;
                    }
                }
                return maxWidth + System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
            }
            catch { return myCombo.DropDownWidth; }
        }

        private void InstantiateClientForBulkTestMode(object partyId)
        {
            try
            {
                DisconnectParty();

            }
            catch { }

            _client = new Party(partyId.ToString()) { ClientCredentials = _clientCredentials };
        }


        /// <summary>
        /// *************************
        /// *                       *
        /// *  buttonConnect_Click  *
        /// *                       *
        /// *************************
        /// User has clicked the Connect button. Establish a message bus connection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                // Establish a connection.
                SubscriberOptions connectOptions = SubscriberOptions.None;
                if (checkBoxTx.Checked) connectOptions |= SubscriberOptions.Transacted;

                PartyConnectExceptions result;

                if (!IsNeuronAvailable()) return;
                if (checkBoxBulkTestMode.Checked)
                {
                    result = this.ConnectToParty(connectOptions, true);

                    AddTestModeTabPages();
                }
                else
                {
                    result = this.ConnectToParty(connectOptions);

                    AddStandardModeTabPages();
                    buttonPause.Enabled = true;
                    buttonResume.Enabled = true;
                    EnableFilterComponents(true);
                    this.largePurchaseOrderXSDToolStripMenuItem.Enabled = true;
                    this.insertTestMessageOrderToolStripMenuItem.Enabled = true;
                    this.formatXMLToolStripMenuItem.Enabled = true;
                    this.viewFullMessageXMLToolStripMenuItem.Enabled = true;
                }

                comboBoxSubscriberId.Enabled = false;
                checkBoxBulkTestMode.Enabled = false;
                comboBoxSendTopic.Enabled = true;
                buttonPublish.Enabled = true;
                buttonSendClear.Enabled = true;
                buttonConnect.Enabled = false;
                buttonConnect.Visible = false;
                timerStatus.Enabled = true;
                buttonDisconnect.Enabled = true;
                buttonDisconnect.Visible = true;
                buttonBulkSend.Enabled = true;

                Text = "Neuron Test Client - " + comboBoxSubscriberId.Text + " (" + ESBHelper.GetCurrentProcessId().ToString() + ")";

                DisplaySubscriptions(result);

                // Start the timer that checks the online / offline status of the subscriptions.
                if (onlineTimer != null)
                {
                    onlineTimer.Stop();
                    onlineTimer.Elapsed -= new ElapsedEventHandler(onlineTimer_Elapsed);
                    onlineTimer.Dispose();
                }
                onlineTimer = new System.Timers.Timer();
                onlineTimer.Elapsed += new ElapsedEventHandler(onlineTimer_Elapsed);
                onlineTimer.Interval = 2000;
                onlineTimer.Start();

            }
            catch (FaultException<UnauthorizedAccessException> ex)
            {
                MessageBox.Show("Access was denied due to the following authorization error:\r\n\r\n" + ex.Detail.Message, "Unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect due to the following error:\r\n\r\n" + ex.Message, "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor = Cursors.Default;
                Application.DoEvents();
            }
        }

        private PartyConnectExceptions ConnectToParty(SubscriberOptions connectOptions, bool bulk = false)
        {

            // create the subscriber config option
            SubscriberConfiguration config = new SubscriberConfiguration();

            var locatorServiceAddress = string.Empty;
            locatorServiceAddress = Neuron.NetX.EsbService.ESBServiceFactory.ConfigurationServiceAddress(this.Machine, this.Port, false, "");

            config.Zone = "Enterprise";
            config.ServiceIdentity = this.ServiceIdentity;
            config.ServiceAddress = locatorServiceAddress;
            config.SubscriberId = this.comboBoxSubscriberId.Text;

            CreateParty(config, connectOptions, bulk);

            try
            {
                return this._client.Connect();
            }
            catch (Exception ex)
            {
                if (ex is EndpointNotFoundException ||
                        (ex.InnerException != null && ex.InnerException is EndpointNotFoundException))
                {

                    // check the current url. determine if configured for port sharing
                    // try using other address in case port shaing is enabled..
                    locatorServiceAddress = Neuron.NetX.EsbService.ESBServiceFactory.ConfigurationServiceAddress(this.Machine, this.Port, false, this.InstanceName);
                    config.ServiceAddress = locatorServiceAddress;
                    CreateParty(config, connectOptions, bulk);
                    return this._client.Connect();
                }
                else
                    throw;
            }
        }

        private void CreateParty(SubscriberConfiguration config, SubscriberOptions options, bool bulk = false)
        {
            DisconnectParty();

            this._client = new Party(config, options) { ClientCredentials = this._clientCredentials };

            if (bulk)
            {
                this._client.OnConfigurationChanged += this.OnConfigurationChanged;
                this._client.OnOnline += this.Online;
                this._client.OnOffline += this.Offline;
                this._client.OnReceive += this.testModeReceive;
            }
            else
            {
                this._client.OnReceive += this.receive;
                this._client.OnSend += this.OnSend;
                this._client.OnOnline += this.Online;
                this._client.OnOffline += this.Offline;
                //this._client.OnMessageSequenceGap += this.OnSequenceGap;
                //this._client.OnMessagePartReceive += this.OnMessagePartReceive;
                //this._client.OnMessagePartSend += this.OnMessagePartSend;
                this._client.OnPipelineBegin += this.OnPipelineBegin;
                this._client.OnPipelineEnd += this.OnPipelineEnd;
                this._client.OnPipelineError += this.OnPipelineError;
                this._client.OnConfigurationChanged += this.OnConfigurationChanged;
                this._client.OnSubscriberDisabled += this.OnSubscriberDisabled;
                //this._client.OnError += this.OnError;
            }
        }
        private void onlineTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (timerExecuting)
                return;

            timerExecuting = true;

            // this could happen....if machine when into hibernation mode for example...
            if (_client == null)
            {
                try
                {
                    SubscriberOptions connectOptions = SubscriberOptions.None;
                    if (checkBoxTx.Checked) connectOptions |= SubscriberOptions.Transacted;

                    PartyConnectExceptions result;
                    result = this.ConnectToParty(connectOptions, checkBoxBulkTestMode.Checked);

                    DisplaySubscriptions(result);
                }
                catch { }

            }
            try
            {
                lock (_syncStatus)
                {
                    foreach (DataGridViewRow row in dataGridViewSubscriptions.Rows)
                    {
                        String topic = ESBHelper.TopicRoot(row.Cells[0].Value.ToString());
                        if (_client == null || _client.Context == null) continue;
                        bool online = _client.Context.TopicContexts[topic].IsOnline == 1;
                        if (!online)
                        {
                            row.Cells[2].Value = "OFFLINE";
                            row.Cells[2].Style.ForeColor = Color.IndianRed;
                            row.Cells[2].Style.SelectionForeColor = Color.IndianRed;
                        }
                        else
                        {
                            row.Cells[2].Value = "ONLINE";
                            row.Cells[2].Style.ForeColor = Color.ForestGreen;
                            row.Cells[2].Style.SelectionForeColor = Color.ForestGreen;
                        }
                    }
                }

            }
            catch (KeyNotFoundException)
            {
            }
            finally
            {
                timerExecuting = false;
            }


        }

        void displayMessageTooLarge()
        {
            xmlEditorReceive.Visible = false;
            hexBoxReceive.Visible = false;
        }




        /// <summary>
        ///  Event handler - a sequence gap in received messages occurred.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OnSequenceGap(object sender, MessageSequenceEventArgs e)
        {
            Invoke((EventHandler)delegate
            {
                if (checkBoxDebugMessageSequenceGap.Checked)
                {
                    FormDebug form = new FormDebug();
                    form.Text = "ESB Client Event - " + _client.Context.PartyId;
                    form.labelEventType.Text = "OnMessageSequenceGap";
                    form.labelEventDesc.Text = "This event fires after a gap has been detected in the received message sequence";
                    form.labelEventDetail.Text = "Sequence Gap";
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Expected sequence", e.Sequence1.ToString() }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Received sequence", e.Sequence2.ToString() }));
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.Cancel)
                        ClearDebugEvents();
                }
            });
        }

        /// <summary>
        /// Event handler - a message part (partial message) was received.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OnMessagePartReceive(object sender, MessageEventArgs e)
        {
            Invoke((EventHandler)delegate
            {
                if (checkBoxDebugMessagePartReceive.Checked)
                {
                    ESBMessageHeader header = e.Message.Header;
                    FormDebug form = new FormDebug();

                    if (_client != null) form.Text = "ESB Client Event - " + _client.Context.PartyId;
                    else form.Text = "ESB Client Event";

                    form.labelEventType.Text = "OnMessagePartReceive";
                    form.labelEventDesc.Text = "This event fires after a message part has been received";
                    form.labelEventDetail.Text = "Message Header";
                    listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Action", header.Action }));
                    listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Binary", header.Binary.ToString() }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "BodyType", header.BodyType }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "CompressedBodySize", header.CompressedBodySize.ToString() }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "CompressionFactor", header.CompressionFactor.ToString("G") + ":1" }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Created", ESBHelper.FormatDateTimeToString(header.Created.ToLocalTime()) }));

                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "DestId", header.DestId }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Event", header.Event }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Expires", ESBHelper.FormatDateTimeToString(header.Expires.ToLocalTime()) }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "FaultTo", header.FaultTo }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "FaultType", header.FaultType.ToString() }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "From", header.From }));

                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Machine", header.Machine }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "MessageId", header.MessageId }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "ParentMessageId", header.ParentMessageId }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Priority", header.Priority.ToString() }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "ProcessOnReply", header.ProcessOnReply.ToString() }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "RelatesTo", header.RelatesTo }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "ReplyTo", header.ReplyTo }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "ReplyToMessageId", header.ReplyToMessageId }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "ReplyToPartyId", header.ReplyToPartyId }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "ReplyToSessionId", header.ReplyToSessionId }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "RequestHeadersToPreserve", header.RequestHeadersToPreserve }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "RoutingSlip", header.RoutingSlip }));
                    //form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Schema", header.Schema }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Semantic", header.Semantic.ToString() }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Sequence", header.Sequence.ToString() }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Service", header.Service }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Session", header.Session }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "SID", header.SID }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "SourceId", header.SourceId }));
                    //form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "SubmissionCount", header.SubmissionCount.ToString() }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "TargetId", header.TargetId }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "To", header.To }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Topic", header.Topic }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "TransactionId", header.TransactionId }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "TrackingSequence", header.TrackingSequence.ToString() }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "UncompressedBodySize", header.UncompressedBodySize.ToString() }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Username", header.Username }));

                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Process Name", header.ProcessName }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Workflow Name", header.WorkflowName }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Workflow Endpoint Name", header.WorkflowEndpointName }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Workflow Instance Id", header.WorkflowInstanceId }));

                    if (e.Message.Http != null)
                    {
                        var grp = new ListViewGroup("Http");
                        grp.Items.Add(new ListViewItem(new string[] { "Method", e.Message.Http.Method }));
                        grp.Items.Add(new ListViewItem(new string[] { "StatusCode", e.Message.Http.StatusCode.ToString() }));
                        var httpItem = new ListViewItem(grp);
                        form.listViewEventDetail.Items.Add(httpItem);
                    }

                    if (e.Message.Soap != null)
                    {
                        var allHeaders = new StringBuilder();
                        foreach (var head in e.Message.Soap.Headers)
                        {
                            allHeaders.AppendFormat(CultureInfo.CurrentCulture, "{0}={1};", head.Key, head.Value);
                        }

                        var grpSoap = new ListViewGroup("SOAP");
                        grpSoap.Items.Add(new ListViewItem(new[] { "Headers", allHeaders.ToString() }));
                        var soapItem = new ListViewItem(grpSoap);
                        form.listViewEventDetail.Items.Add(soapItem);
                    }

                    if (e.Message.Header.Binary)
                    {
                        if (e.Message.InternalBytes.Length < 1024 * 1024)
                        {
                            hexBoxReceive.ByteProvider = new Neuron.UI.DynamicByteProvider(e.Message.InternalBytes);
                            hexBoxReceive.Visible = true;
                            hexBox1.Visible = true;
                            xmlEditorReceive.Visible = false;
                        }
                        else
                        {
                            displayMessageTooLarge();
                        }
                    }
                    else
                    {
                        form.xmlEditorBody.Text = e.Message.Text;

                        hexBoxReceive.Visible = false;
                        hexBox1.Visible = false;
                        xmlEditorReceive.Visible = true;
                    }
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.Cancel)
                        ClearDebugEvents();
                }
            });
        }

        /// <summary>
        /// Event handler - a partial message was sent.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OnMessagePartSend(object sender, MessageEventArgs e)
        {
            Invoke((EventHandler)delegate
            {
                if (checkBoxDebugMessagePartSend.Checked)
                {
                    ESBMessageHeader header = e.Message.Header;
                    FormDebug form = new FormDebug();
                    if (_client != null) form.Text = "ESB Client Event - " + _client.Context.PartyId;
                    else form.Text = "ESB Client Event";

                    form.labelEventType.Text = "OnMessagePartSend";
                    form.labelEventDesc.Text = "This event fires after a message part has been sent";
                    form.labelEventDetail.Text = "Message Header";
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Message Id", header.MessageId }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Action", header.Action }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Binary", header.Binary.ToString() }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Body type", header.BodyType }));
                    //form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Body schema", header.Schema }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Event", header.Event }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Source", header.SourceId }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Session", header.Session }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Sequence", header.Sequence.ToString() }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Topic", header.Topic }));
                    if (e.Message.Header.Binary)
                    {
                        if (e.Message.InternalBytes.Length < 1024 * 1024)
                        {
                            form.hexBoxReceive.ByteProvider = new DynamicByteProvider(e.Message.Bytes);
                            form.hexBoxReceive.Visible = true;
                            form.xmlEditorBody.Visible = false;
                        }
                        else
                        {
                            displayMessageTooLarge();
                        }
                    }
                    else
                    {
                        form.xmlEditorBody.Text = e.Message.Text;

                        form.hexBoxReceive.Visible = false;
                        form.xmlEditorBody.Visible = true;
                    }
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.Cancel)
                        ClearDebugEvents();
                }
            });
        }

        void testModeReceive(object sender, MessageEventArgs e)
        {
            updateReceivedCount(e.Message);
        }

        /// <summary>
        /// Event handler - a message was received.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        void receive(object sender, MessageEventArgs e)
        {
            bool doCompleteTx = true;

            if (_messageHistoryLimit > 0)
            {
                if (_messageHistory.ContainsKey(e.Message.Header.MessageId))
                    _messageHistory[e.Message.Header.MessageId] = e.Message.Clone(true); // was: new ESBMessage(e.Message);   // Copy message, same message ID.
                else
                    _messageHistory.Add(e.Message.Header.MessageId, e.Message.Clone(true)); // Copy message, same message ID. new ESBMessage(e.Message));

                ListViewItem itemToInsert = new ListViewItem(new string[] { "Receive", e.Message.Header.MessageId });
                itemToInsert.Tag = e.Message.Header.MessageId;
                listViewMessageHistory.Items.Add(itemToInsert);

                if (listViewMessageHistory.Items.Count > _messageHistoryLimit)
                {
                    ListViewItem itemToRemove = listViewMessageHistory.Items[0];
                    _messageHistory.Remove(itemToRemove.Tag.ToString());
                    listViewMessageHistory.Items[0].Remove();
                }
                buttonHistoryClearAll.Enabled = listViewMessageHistory.Items.Count > 0;
            }

            if (checkBoxDebugReceive.Checked)
            {
                ESBMessageHeader header = e.Message.Header;
                FormDebug form = new FormDebug();

                if (_client != null) form.Text = "ESB Client Event - " + _client.Context.PartyId;
                else form.Text = "ESB Client Event";

                form.labelEventType.Text = "OnReceive";
                form.labelEventDesc.Text = "This event fires after a message has been received";
                form.labelEventDetail.Text = "Message Header";
                if (e.Transaction != null)
                {
                    form.checkBoxCompleteTx.Visible = true;
                    form.checkBoxCompleteTx.Checked = true;
                }
                form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Message Id", header.MessageId }));
                form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Action", header.Action }));
                form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Binary", header.Binary.ToString() }));
                form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Body type", header.BodyType }));
                //form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Body schema", header.Schema }));
                form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Event", header.Event }));
                form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Source", header.SourceId }));
                form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Session", header.Session }));
                //form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Sequence", header.Sequence.ToString() }));
                form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Topic", header.Topic }));

                if (e.Message.Header.Binary)
                {
                    if (e.Message.InternalBytes.Length < 1024 * 1024)
                    {
                        form.hexBoxReceive.ByteProvider = new DynamicByteProvider(e.Message.Bytes);
                        form.hexBoxReceive.Visible = true;
                        form.xmlEditorBody.Visible = false;
                    }
                    else
                    {
                        displayMessageTooLarge();
                    }
                }
                else
                {
                    form.xmlEditorBody.Text = e.Message.Text;
                    form.hexBoxReceive.Visible = false;
                    form.xmlEditorBody.Visible = true;
                }

                form.ShowDialog();
                if (form.DialogResult == DialogResult.Cancel)
                    ClearDebugEvents();
                doCompleteTx = form.checkBoxCompleteTx.Checked;
            }

            xmlEditorReceive.UseWaitCursor = true;

            ESBMessage message = e.Message;

            updateReceivedCount(message);
            showReceivedMessage(message);

            // Test facility: if message contains [test:throw], throw an exception.

            if (!e.Message.Header.Binary && e.Message.Text.IndexOf("[test:throw]") != -1)
                throw new IndexOutOfRangeException("Test exception for ESB testing");

            xmlEditorReceive.UseWaitCursor = false;

            if (e.Transaction != null)
            {
                if (e.Transaction.TransactionInformation.Status == TransactionStatus.Active)
                    if (doCompleteTx)
                        e.Transaction.Commit();
                    else
                    {
                        e.Cancel = true;
                        e.Transaction.Rollback();
                    }
            }
        }

        /// <summary>
        /// Event handler - a message was sent.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OnSend(object sender, MessageEventArgs e)
        {
            Invoke((EventHandler)delegate
            {
                if (checkBoxDebugSend.Checked)
                {
                    ESBMessageHeader header = e.Message.Header;
                    FormDebug form = new FormDebug();

                    if (_client != null) form.Text = "ESB Client Event - " + _client.Context.PartyId;
                    else form.Text = "ESB Client Event";

                    form.labelEventType.Text = "OnSend";
                    form.labelEventDesc.Text = "This event fires after a message has been sent";
                    form.labelEventDetail.Text = "Message Header";
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Message Id", header.MessageId }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Action", header.Action }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Binary", header.Binary.ToString() }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Body type", header.BodyType }));
                    //form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Body schema", header.Schema }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Event", header.Event }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Source", header.SourceId }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Session", header.Session }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Sequence", header.Sequence.ToString() }));
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Topic", header.Topic }));

                    if (e.Message.Header.Binary)
                    {
                        if (e.Message.InternalBytes.Length < 1024 * 1024)
                        {
                            form.hexBoxReceive.Visible = true;
                            form.xmlEditorBody.Visible = false;

                            form.hexBoxReceive.ByteProvider = new DynamicByteProvider(e.Message.Bytes);

                        }
                        else
                        {
                            displayMessageTooLarge();
                        }
                    }
                    else
                    {
                        form.xmlEditorBody.Text = e.Message.Text;
                        form.hexBoxReceive.Visible = false;
                        form.xmlEditorBody.Visible = true;
                    }
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.Cancel)
                        ClearDebugEvents();
                }
            });
        }

        void updateReceivedCount(ESBMessage message)
        {
            receiveMessageCounter.IncrementMessageProcessed();
            _lastReceivedMessage = message;
        }

        // Display a message that was received.

        void showReceivedMessage(ESBMessage message)
        {
            textBoxReceiveSource.Text = message.Header.SourceId;
            textBoxReceiveTopic.Text = message.Header.Topic;

            if (message.Header.Binary)
            {
                if (message.InternalBytes.Length < 1024 * 1024)
                {
                    hexBoxReceive.Visible = true;
                    xmlEditorReceive.Visible = false;

                    hexBoxReceive.ByteProvider = new DynamicByteProvider(message.Bytes);
                }
                else
                {
                    displayMessageTooLarge();
                }
            }
            else
            {
                xmlEditorReceive.Text = message.Text;

                hexBoxReceive.Visible = false;
                xmlEditorReceive.Visible = true;
            }

            switch (message.Header.Semantic)
            {
                case Semantic.Direct:
                    comboBoxReceiveSemantic.Text = "Direct";
                    _requestId = "";
                    break;
                case Semantic.Multicast:
                    comboBoxReceiveSemantic.Text = "Multicast";
                    _requestId = "";
                    break;
                case Semantic.Request:
                    comboBoxReceiveSemantic.Text = "Request";
                    _requestId = message.Header.MessageId;
                    break;
                case Semantic.Reply:
                    comboBoxReceiveSemantic.Text = "Reply";
                    _requestId = message.Header.ReplyToMessageId;
                    break;
            }
        }

        private void EnableFilterComponents(bool enable)
        {
            checkBoxFilter.Enabled = enable;
            labelFilter.Enabled = enable;
            textBoxFilter.Enabled = enable;
            buttonSetFilter.Enabled = enable;
            buttonClearFilter.Enabled = enable;
            if (enable == false) textBoxFilter.Text = "";
        }

        /// <summary>
        /// Event handler - online with other subscribers. Has little meaning outside of WCF PeerChannel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Online(object sender, TopicEventArgs e)
        {
            Invoke((EventHandler)delegate
            {
                if (checkBoxDebugOnline.Checked)
                {
                    //ESBMessageHeader header = e.Message.Header;
                    FormDebug form = new FormDebug();

                    if (_client != null) form.Text = "ESB Client Event - " + _client.Context.PartyId;
                    else form.Text = "ESB Client Event";

                    form.labelEventType.Text = "OnOnline";
                    form.labelEventDesc.Text = "This event fires after a channel indicates an on-line condition";
                    form.labelEventDetail.Text = "TopicEventArgs";
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Topic", e.Topic }));
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.Cancel)
                        ClearDebugEvents();
                }
            });
        }

        /// <summary>
        /// Event handler - offline (no other subscribers). Has little meaning outside of WCF PeerChannel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Offline(object sender, TopicEventArgs e)
        {
            if (checkBoxDebugOffline.Checked)
            {
                //ESBMessageHeader header = e.Message.Header;
                FormDebug form = new FormDebug();
                if (_client != null) form.Text = "ESB Client Event - " + _client.Context.PartyId;
                else form.Text = "ESB Client Event";

                form.labelEventType.Text = "OnOffline";
                form.labelEventDesc.Text = "This event fires after a channel indicates an off-line condition";
                form.labelEventDetail.Text = "TopicEventArgs";
                form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Topic", e.Topic }));
                form.ShowDialog();
                if (form.DialogResult == DialogResult.Cancel)
                    ClearDebugEvents();
            }
        }
        private void DisconnectParty()
        {
            if (this._client != null)
            {
                if (this._client.Context != null)
                {
                    try
                    {
                        if (checkBoxBulkTestMode.Checked)
                        {
                            this._client.OnConfigurationChanged -= OnConfigurationChanged;
                            this._client.OnOnline -= this.Online;
                            this._client.OnOffline -= this.Offline;
                            this._client.OnReceive -= testModeReceive;
                        }
                        else
                        {
                            this._client.OnReceive -= this.receive;
                            this._client.OnSend -= this.OnSend;
                            this._client.OnOnline -= this.Online;
                            this._client.OnOffline -= this.Offline;
                            this._client.OnMessageSequenceGap -= this.OnSequenceGap;
                            this._client.OnMessagePartReceive -= this.OnMessagePartReceive;
                            this._client.OnMessagePartSend -= this.OnMessagePartSend;
                            this._client.OnPipelineBegin -= this.OnPipelineBegin;
                            this._client.OnPipelineEnd -= this.OnPipelineEnd;
                            this._client.OnPipelineError -= this.OnPipelineError;
                            this._client.OnConfigurationChanged -= this.OnConfigurationChanged;
                            this._client.OnSubscriberDisabled -= this.OnSubscriberDisabled;
                            //this._client.OnError -= this.OnError;
                        }
                    }
                    catch { }
                }

                try
                {
                    this._client.Dispose();
                }
                catch { }
                finally
                {
                    _client = null;
                }
            }
        }
        /// <summary>
        /// Disconnect subscriber.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                ClearSend();
                ClearReceive();
                ClearAllMessageHistory();

                RemoveTabPages();

                if (onlineTimer != null)
                {
                    onlineTimer.Stop();
                    onlineTimer.Elapsed -= new ElapsedEventHandler(onlineTimer_Elapsed);
                    onlineTimer.Dispose();
                }
                dataGridViewSubscriptions.Rows.Clear();

                timerStatus.Enabled = false;

                DisconnectParty();

                buttonDisconnect.Enabled = false;
                buttonDisconnect.Visible = false;
                buttonConnect.Enabled = true;
                buttonConnect.Visible = true;
                buttonPublish.Enabled = false;
                buttonBulkSend.Enabled = false;
                buttonPause.Enabled = false;
                buttonResume.Enabled = false;
                EnableFilterComponents(false);
                comboBoxSendTopic.Enabled = false;
                checkBoxBulkTestMode.Enabled = true;
                this.insertTestMessageOrderToolStripMenuItem.Enabled = false;
                this.largePurchaseOrderXSDToolStripMenuItem.Enabled = false;
                this.viewFullMessageXMLToolStripMenuItem.Enabled = false;
                this.formatXMLToolStripMenuItem.Enabled = false;
            }
            catch { }
            finally
            {
                comboBoxSubscriberId.Enabled = true;

                Cursor = Cursors.Default;
                Application.DoEvents();
            }
        }

        private void buttonSendClear_Click(object sender, EventArgs e)
        {
            ClearSend();
        }

        private void ClearSend()
        {
            textBoxSendDest.Text = "";
            xmlEditorSend.Text = "";
            hexBox.ByteProvider = new DynamicByteProvider(Encoding.UTF8.GetBytes(xmlEditorSend.Text));
            ResetSendStats();

            if (radioButtonSendBinary.Checked)
            {
                hexBox.Focus();
            }
            else
            {
                xmlEditorSend.Focus();
            }
        }

        private ESBMessage SendMessage(FormData formData)
        {
            _client.DefaultCustomProperties = _sendCustomProperties.Header.CustomProperties;

            ESBMessage message = null;
            ESBMessage esbMessage = null;
            if ((formData.SendOptions & SendOptions.Direct) == SendOptions.Direct)
            {
                message = _client.Send(formData.SendTopicText, formData.MessageText, formData.SendOptions, formData.SendDestText);
                AddMessageToMessageHistory(message, "Send");
            }
            else if ((formData.SendOptions & SendOptions.Reply) == SendOptions.Reply)
            {
                if (formData.SendString)
                    message = _client.Reply(_lastReceivedMessage, formData.MessageText);
                else if (formData.SendObject)
                {
                    Object objectToSend = getDynamicObjectToSend();
                    message = _client.Reply(_lastReceivedMessage, objectToSend);
                }
                else if (formData.SendBinary)
                {
                    message = this._client.Reply(_lastReceivedMessage, this.GetBinaryPayload(formData.MessageText));
                }
                else
                {
                    message = _client.ReplyXml(_lastReceivedMessage, formData.MessageText);
                }

                AddMessageToMessageHistory(message, "Send");
            }
            else
            {
                if (formData.SendXml)
                {
                    esbMessage = new ESBMessage(formData.SendTopicText, formData.MessageText, "")
                    {
                        Header =
                        {
                            Expires = DateTime.MaxValue,
                            SID = _client.Context.SID,
                            Username = _client.Context.Username,
                            Machine = _client.Context.Machine,
                            Action = formData.ActionText,
                            BodyType = "text/xml"
                        }
                    };

                    message = _client.SendMessage(esbMessage, formData.SendOptions, null, formData.ActionText);

                }
                else if (formData.SendString)
                {
                    esbMessage = new ESBMessage(formData.SendTopicText, formData.MessageText)
                    {
                        Header =
                        {
                            Expires = DateTime.MaxValue,
                            SID = _client.Context.SID,
                            Username = _client.Context.Username,
                            Machine = _client.Context.Machine,
                            Action = formData.ActionText,
                            BodyType = "text/plain"
                        }
                    };

                    message = _client.SendMessage(esbMessage, formData.SendOptions, null, formData.ActionText);

                }
                else if (formData.SendBinary)
                {
                    Byte[] bytes = GetBinaryPayload(formData.MessageText);
                    esbMessage = new ESBMessage(formData.SendTopicText, bytes)
                    {
                        Header =
                                             {
                                                 Expires = DateTime.MaxValue,
                                                 SID = _client.Context.SID,
                                                 Username = _client.Context.Username,
                                                 Machine = _client.Context.Machine,
                                                 Action = formData.ActionText,
                                                 BodyType = "binary/bytes"
                                             }
                    };
                    message = _client.SendMessage(esbMessage, formData.SendOptions, null, formData.ActionText);

                    bytes = null;

                }
                else
                {
                    esbMessage = new ESBMessage(formData.SendTopicText, formData.MessageText)
                    {
                        Header =
                                             {
                                                 Expires = DateTime.MaxValue,
                                                 SID = _client.Context.SID,
                                                 Username = _client.Context.Username,
                                                 Machine = _client.Context.Machine,
                                                 Action = formData.ActionText
                                             }
                    };
                    message = _client.SendMessage(esbMessage, formData.SendOptions, null, formData.ActionText);

                }
                AddMessageToMessageHistory(esbMessage, "Send");

            }

            _lastSentMessage = message;


            sendMessageCounter.IncrementMessageProcessed();

            if (formData.SemanticText == "Request")
            {
                updateReceivedCount(message);
                AddMessageToMessageHistory(message, "Receive");
            }

            return message;
        }

        /// <summary>
        /// Send a message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        void buttonPublish_Click(object sender, EventArgs e)
        {
            FormData formData = new FormData();

            formData.MessageText = xmlEditorSend.Text;
            formData.ActionText = textBoxSendAction.Text;
            formData.SemanticText = comboBoxSendSemantic.Text;
            formData.PriorityText = comboBoxPriority.Text;
            formData.SendTopicText = comboBoxSendTopic.Text;
            formData.SendDestText = textBoxSendDest.Text;

            formData.SendString = radioButtonSendString.Checked;
            formData.SendXml = radioButtonSendXml.Checked;
            formData.SendObject = radioButtonSendObject.Checked;
            formData.SendBinary = radioButtonSendBinary.Checked;

            SendOptions options = SendOptions.None;
            if (formData.SemanticText == "Direct") options |= SendOptions.Direct;
            else if (formData.SemanticText == "Multicast") options |= SendOptions.Multicast;
            else if (formData.SemanticText == "Request") options |= SendOptions.Request;
            else if (formData.SemanticText == "Reply") options |= SendOptions.Reply;

            if (formData.PriorityText == "High") options |= SendOptions.High;
            else if (formData.PriorityText == "Normal") options |= SendOptions.Normal;
            else if (formData.PriorityText == "Low") options |= SendOptions.Low;

            formData.SendOptions = options;

            try
            {
                Cursor = Cursors.WaitCursor;

                ESBMessage message = SendMessage(formData);

                if (formData.SemanticText == "Request")
                {
                    showReceivedMessage(message);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("The message cannot be sent because the payload is not binary.\r\n\r\nEnter hex digit pairs for a binary message. White space characters (space, tab, carriage return, line feed) are ignored.", "Invalid Message Format", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                {
                    inner = ex.InnerException.Message;
                }
                MessageBox.Show("An exception occurred during the send:\r\n\r\n" + ex.Message + "\r\n\r\n" + inner, "Send Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor = Cursors.Default;
                Application.DoEvents();
            }
        }

        private Object getDynamicObjectToSend()
        {
            DynamicAssemblyLoader.DynamicClassInfo classInfo = DynamicAssemblyLoader.GetClassReference(textBoxObjectAssembly.Text.Trim(), comboBoxClassName.Text.Trim());

            Object objectToSend = classInfo.ClassObject;

            // Attempt to deserialize the text in the editor window as the object type from the choosen assembly.
            // If it works this will override the object created by the dynamic load assembly
            // If an exception occurs then just ignore it and use the original object from the dynamic load assembly.
            if (!String.IsNullOrEmpty(xmlEditorSend.Text.Trim()))
            {
                try
                {
                    XmlSerializer sz = new XmlSerializer(classInfo.type);
                    using (StringReader sr = new StringReader(xmlEditorSend.Text.Trim()))
                    {
                        using (XmlTextReader xtr = new XmlTextReader(sr))
                        {
                            // Override the object from the dynamic load assembly.
                            objectToSend = sz.Deserialize(xtr);
                            sr.Close();
                            xtr.Close();
                        }
                    }


                }
                catch (Exception) { }
            }
            return objectToSend;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Environment.Exit(0);
        }


        /// <summary>
        /// Send bulk messages.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonBulkSend_Click(object sender, EventArgs e)
        {
            String errorMessage = "";

            if (comboBoxSendSemantic.Text == "Reply") errorMessage = "Send semantic Reply is not supported by the bulk test.";
            if (radioButtonSendObject.Checked) errorMessage = "Send Object is not supported by the bulk test.";

            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage, "Error During Send", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (_sending) return;

            buttonBulkSend.Enabled = false;
            buttonStop.Enabled = true;
            StopSending = false;

            _sending = true;

            FormData formData = new FormData();
            formData.messageCount = Convert.ToInt32(textBoxMessageCount.Text);
            formData.messageSize = Convert.ToInt32(textBoxMessageSize.Text);
            formData.sendDelay = Convert.ToInt32(textBoxSendDelay.Text);
            formData.sendInterval = Convert.ToInt32(textBoxSendInterval.Text);

            formData.NonRepeatingMessage = radioButtonMessageTypeNonRepeating.Checked;

            // Set the initial message to send.
            if (radioButtonMessageSendTab.Checked) formData.MessageText = xmlEditorSend.Text;
            else if (radioButtonMessageTypeRepeating.Checked) formData.MessageText = TestMessageBody_Repeating(formData.messageSize);
            else if (formData.NonRepeatingMessage) formData.MessageText = TestMessageBody_NonRepeating(formData.messageSize);

            formData.ActionText = textBoxSendAction.Text;
            formData.SemanticText = comboBoxSendSemantic.Text;
            formData.PriorityText = comboBoxPriority.Text;
            formData.SendTopicText = comboBoxSendTopic.Text;
            formData.SendDestText = textBoxSendDest.Text;

            // enable binary send
            if (radioButtonSendBinary.Checked)
                formData.SendBinary = true;

            SendOptions options = SendOptions.None;
            if (formData.SemanticText == "Direct") options |= SendOptions.Direct;
            else if (formData.SemanticText == "Multicast") options |= SendOptions.Multicast;
            else if (formData.SemanticText == "Request") options |= SendOptions.Request;
            else if (formData.SemanticText == "Reply") options |= SendOptions.Reply;

            if (formData.PriorityText == "High") options |= SendOptions.High;
            else if (formData.PriorityText == "Normal") options |= SendOptions.Normal;
            else if (formData.PriorityText == "Low") options |= SendOptions.Low;

            formData.SendOptions = options;

            ParameterizedThreadStart operation = new ParameterizedThreadStart(BulkSendThreadRoutine);
            _sendThread = new Thread(operation);
            _sendThread.IsBackground = true;
            _sendThread.Name = "Send";
            _sendThread.Start(formData);
        }

        private void BulkSendThreadRoutine(object data)
        {
            Application.DoEvents();

            try
            {
                FormData formData = (FormData)data;

                int intervalCountdown = formData.sendInterval;

                _client.DefaultCustomProperties = _sendCustomProperties.Header.CustomProperties;


                int batchSize;
                if (!Int32.TryParse(txtBatchSize.Text, out batchSize))
                {
                    batchSize = 1;
                }
                batchSize = Math.Max(1, batchSize);

                for (int i = 0; i < formData.messageCount && !StopSending;)
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, TimeSpan.MaxValue))
                    {
                        for (int j = 0; j < batchSize && i < formData.messageCount; j++, i++)
                        {
                            if (formData.NonRepeatingMessage) formData.MessageText = TestMessageBody_NonRepeating(formData.messageSize);

                            SendMessage(formData);

                            if (--intervalCountdown == 0)
                            {

                                // If the delay is less than 2 seconds then just sleep that amount
                                // Otherwise, we want to sleep in 100 ms increments so we can detect and act upon
                                // the StopSending flag without having to wait for a potentially long delay to finish.
                                if (formData.sendDelay > 0 && formData.sendDelay <= 2000) Thread.Sleep(formData.sendDelay);
                                else
                                {
                                    int counter = formData.sendDelay / 100;
                                    int remaining = formData.sendDelay % 100;
                                    while (!StopSending && counter > 0)
                                    {
                                        counter--;
                                        Thread.Sleep(100);
                                    }
                                    Thread.Sleep(remaining);
                                }
                                intervalCountdown = formData.sendInterval;
                            }
                        }
                        scope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following exception occurred attemping to send a message:\r\n\r\n" +
                    ex.Message, "Error During Send", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                _sending = false;
                Invoke((EventHandler)delegate
                {
                    buttonBulkSend.Enabled = true;
                    buttonStop.Enabled = false;
                });
                StopSending = false;
            }
        }

        /// <summary>
        /// Generate a test message body of a specific size.
        /// </summary>
        /// <param name="messageSize"></param>
        /// <returns></returns>

        private string TestMessageBody_Repeating(int messageSize)
        {
            string prefix = "<TestMessage>";
            string suffix = "</TestMessage>";
            StringBuilder data = new StringBuilder();
            string refrain = "Now is the time for all good men to come to the aid of their country. ";
            int targetLength = messageSize - (prefix.Length + suffix.Length);
            if (targetLength < 0) targetLength = 0;
            while (data.Length < targetLength)
            {
                data.Append(refrain);
            }
            data.Length = targetLength;
            return prefix + data.ToString() + suffix;
        }

        private string TestMessageBody_NonRepeating(int messageSize)
        {
            string prefix = "<TestMessage>";
            string suffix = "</TestMessage>";
            StringBuilder data = new StringBuilder();
            int targetLength = messageSize - (prefix.Length + suffix.Length);
            if (targetLength < 0) targetLength = 0;
            while (data.Length < targetLength)
            {
                data.Append(Guid.NewGuid().ToString());
            }
            data.Length = targetLength;
            return prefix + data.ToString() + suffix;
        }

        private bool IsNeuronAvailable()
        {
            InitializeConnectionProperties();

            var isAvailable = true;

            if (Neuron.NetX.Internal.ESBHelper.IsLocalMachine(this.Machine))
            {
                if (!Neuron.NetX.Internal.ESBHelper.PingTcpHost(this.Machine, this.Port))
                {
                    MessageBox.Show(this, string.Format(CultureInfo.CurrentCulture,
                                        "Unable to ping the local Neuron ESB Server on port, '{0}'. " +
                                        "This could indicate that there is a firewall " +
                                        "blocking access to the port or the Neuron ESB service is not running. Connection " +
                                        "settings can be modified by selecting 'Connection Settings...' from the 'Tools' menu.",
                                        this.Port), "Neuron ESB Service Unreachable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isAvailable = false;
                }
            }
            else
            {
                // we're here because we determined the machine we're connecting to is remote
                var pingStatus = Neuron.NetX.Internal.ESBHelper.PingMachine(this.Machine);
                if (pingStatus != IPStatus.Success)
                {
                    isAvailable = false;
                    MessageBox.Show(this, string.Format(CultureInfo.CurrentCulture,
                                    "Unable to ping the remote '{0}' Neuron ESB Server. " +
                                    "This could indicate that there is a firewall " +
                                    "blocking access to the remote machine. Connection " +
                                    "settings can be modified by selecting 'Connection Settings...' from the 'Tools' menu.", this.Machine), "Neuron ESB Server Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // I can ping the machine....now I should try to ping the port....if
                    if (!Neuron.NetX.Internal.ESBHelper.PingTcpHost(this.Machine, this.Port))
                    {
                        isAvailable = false;
                        MessageBox.Show(this, string.Format(CultureInfo.CurrentCulture,
                                        "Unable to ping the remote '{0}' Neuron ESB Server on port, '{1}'. " +
                                        "This could indicate that there is a firewall " +
                                        "blocking access to the port or the Neuron ESB service is not running. Connection " +
                                        "settings can be modified by selecting 'Connection Settings...' from the 'Tools' menu.",
                                        this.Machine, this.Port), "Neuron ESB Service Unreachable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return isAvailable;
        }
        /// <summary>
        /// Timer tick - update status bar stats.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private long _previousNumberOfRecvMessagesProcessed = 0;
        private void timerStatus_Tick(object sender, EventArgs e)
        {
            timerStatus.Enabled = false;
            try
            {
                var numberOfRecvMessagesProcessed = receiveMessageCounter.MessagesProcessed;
                statusRecvCount.Text = "Recv: " + numberOfRecvMessagesProcessed.ToString();

                if (checkBoxBulkTestMode.Checked)
                {
                    if (numberOfRecvMessagesProcessed != _previousNumberOfRecvMessagesProcessed)
                        statusRecvMsgPerSec.Text = receiveMessageCounter.MessageRate.ToString("F2") + "/sec";

                    _previousNumberOfRecvMessagesProcessed = numberOfRecvMessagesProcessed;
                }
                else
                {
                    statusRecvMsgPerSec.Text = receiveMessageCounter.MessageRate.ToString("F2") + "/sec";
                }

                var numberOfSentMessagesProcessed = sendMessageCounter.MessagesProcessed;
                statusSentCount.Text = "Sent: " + numberOfSentMessagesProcessed.ToString();

                if (checkBoxBulkTestMode.Checked)
                {
                    if (numberOfSentMessagesProcessed < Convert.ToInt32(textBoxMessageCount.Text))
                        statusSentMsgPerSec.Text = sendMessageCounter.MessageRate.ToString("F2") + "/sec";
                }
                else
                {
                    statusSentMsgPerSec.Text = sendMessageCounter.MessageRate.ToString("F2") + "/sec";
                }

            }
            finally
            {
                timerStatus.Enabled = true;
            }
        }

        private void RemoveTabPages()
        {
            tabControl1.TabPages.Clear();
            tabControl1.Controls.Add(tabPageConnect);
        }

        private void AddTestModeTabPages()
        {
            tabControl1.Controls.Add(tabPageSend);
            tabControl1.Controls.Add(tabPageTest);
        }

        private void AddStandardModeTabPages()
        {
            this.tabControl1.Controls.Add(this.tabPageSend);
            this.tabControl1.Controls.Add(this.tabPageReceive);
            this.tabControl1.Controls.Add(this.tabPageHistory);
            this.tabControl1.Controls.Add(this.tabPageDebug);
            this.tabControl1.Controls.Add(this.tabPageErrors);
        }

        /// <summary>
        /// Initialize form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void FormTestClient_Load(object sender, EventArgs e)
        {
            RemoveTabPages();

            comboBoxSendSemantic.Text = "Multicast";

            bool connect = false;
            if (Arguments.PartyId != null)
            {
                if (Arguments.PartyId.Trim() == String.Empty)
                {
                    MessageBox.Show("The PartyId command line arguments is blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    connect = true;
                    comboBoxSubscriberId.Text = Arguments.PartyId;
                }
            }

            if (Arguments.FileName != null)
            {
                if (Arguments.FileName.Trim() == String.Empty || !File.Exists(Arguments.FileName))
                {
                    MessageBox.Show("The message file " + Arguments.FileName + " does not exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        loadMessage(Arguments.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not read the message file " + Arguments.FileName + "." + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            if (connect) buttonConnect.PerformClick();
        }


        /// <summary>
        /// Send a reply message to a request message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonReply_Click(object sender, EventArgs e)
        {
            if (_requestId == "" || comboBoxSendSemantic.Text != "Reply")
            {
                MessageBox.Show("You can only reply after an incoming request-reply message has been received");
                return;
            }

            //Cursor = Cursors.WaitCursor;

            _requestId = "";

            _client.Reply(_lastReceivedMessage, xmlEditorSend.Text);

            sendMessageCounter.IncrementMessageProcessed();

            //Cursor = Cursors.Default;
        }


        /// <summary>
        /// Semantic combo box selection changed - enable/disable controls as a result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void comboBoxSendSemantic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSendSemantic.Text == "Direct")
                textBoxSendDest.Enabled = true;
            else
                textBoxSendDest.Enabled = false;
        }


        /// <summary>
        /// Clear received message fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonReceiveClear_Click(object sender, EventArgs e)
        {
            ClearReceive();
        }

        private void ClearReceive()
        {
            textBoxReceiveSource.Text = "";
            textBoxReceiveTopic.Text = "";
            xmlEditorReceive.Text = "";
            hexBoxReceive.ByteProvider = new DynamicByteProvider(Encoding.UTF8.GetBytes(xmlEditorReceive.Text));
            ResetReceiveStats();
        }

        /// <summary>
        /// Display Help About information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string assemblyFileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            MessageBox.Show("Neuron ESB Test Client\r\n\r\nFile Version " + assemblyFileVersion + "\r\n\r\nCopyright (C) 2022 Peregrine Connect, LLC. All Rights Reserved.", "About Neuron ESB Test Client");
        }

        private void ResetSendStats()
        {
            sendMessageCounter = new Neuron.NetX.Data.MessageCounter();
        }

        private void ResetReceiveStats()
        {
            receiveMessageCounter = new Neuron.NetX.Data.MessageCounter();
        }

        private void buttonTestReset_Click(object sender, EventArgs e)
        {
            ResetSendStats();
            ResetReceiveStats();
        }

        /// <summary>
        /// Form is closing. If we haven't disconnected, do so now.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void FormTestClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            buttonDisconnect_Click(sender, e);

            if (timerStatus != null)
                timerStatus.Dispose();

        }

        /// <summary>
        /// Create binary data to send. OBSOLETE.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>

        //private static byte[] CreateBinaryData(int length)
        //{
        //    byte[] data = new byte[length];
        //    byte x = 0;
        //    for (int i = 0; i < length; i++)
        //    {
        //        data[i] = x;
        //        x++;
        //        if (x > 127) x = 0;
        //    }
        //    return data;
        //}

        /// <summary>
        /// View message as XML. OBSOLETE.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonReceiveViewXml_Click(object sender, EventArgs e)
        {
            xmlEditorReceive.Text = "";
            //xmlEditorReceive.Text = _lastReceivedMessage.XmlString;
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer xsz = new XmlSerializer(typeof(ESBMessage));
                xsz.Serialize(stream, _lastReceivedMessage);
                stream.Seek(0, SeekOrigin.Begin);
                XmlDocument doc = new XmlDocument();
                doc.Load(stream);
                xmlEditorReceive.Text = doc.DocumentElement.OuterXml;
                stream.Close();
            }
        }

        /// <summary>
        /// Pause a topic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (dataGridViewSubscriptions.SelectedRows.Count == 0)
            {
                MessageBox.Show("To pause a topic, first select a topic from the list box, then click Pause", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string topicName = dataGridViewSubscriptions.SelectedRows[0].Cells[0].Value.ToString();
            int pos = topicName.IndexOfAny(new char[] { '.', '/' });
            if (pos != -1)
                topicName = topicName.Substring(0, pos);
            _client.Pause(topicName);
            MessageBox.Show("The topic " + topicName + " has been paused", "Topic Paused");
        }

        /// <summary>
        /// Resume a topic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonResume_Click(object sender, EventArgs e)
        {
            if (dataGridViewSubscriptions.SelectedRows.Count == 0)
            {
                MessageBox.Show("To resume a topic, first select a topic from the list box, then click Resume", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string topicName = dataGridViewSubscriptions.SelectedRows[0].Cells[0].Value.ToString();
            int pos = topicName.IndexOfAny(new char[] { '.', '/' });
            if (pos != -1)
                topicName = topicName.Substring(0, pos);
            _client.Resume(topicName);
            MessageBox.Show("The topic " + topicName + " has been resumed", "Topic Resumed");
        }


        /// <summary>
        /// Set a topic filter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonSetFilter_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxFilter.Text.Trim())) return;

            try { _client.SetTopicFilter(textBoxFilter.Text.Trim(), checkBoxFilter.Checked); }
            catch (KeyNotFoundException) { MessageBox.Show(this, "The topic " + ESBHelper.TopicRoot(textBoxFilter.Text.Trim()) + " is not in the subscription list.", "Topic Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }


        /// <summary>
        /// Clear a topic filter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxFilter.Text.Trim())) return;

            try { _client.ClearTopicFilter(textBoxFilter.Text.Trim()); }
            catch (KeyNotFoundException) { MessageBox.Show(this, "The topic " + ESBHelper.TopicRoot(textBoxFilter.Text.Trim()) + " is not in the subscription list.", "Topic Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        /// <summary>
        /// Event handler - a pipe is starting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OnPipelineBegin(object sender, PipelineEventArgs e)
        {
            Invoke((EventHandler)delegate
            {
                if (checkBoxDebugPipelineBegin.Checked)
                {
                    FormDebug form = new FormDebug();
                    if (_client != null) form.Text = "ESB Client Event - " + _client.Context.PartyId;
                    else form.Text = "ESB Client Event";

                    form.labelEventType.Text = "OnProcessBegin";
                    form.labelEventDesc.Text = "This event fires just before a process executes";
                    form.labelEventDetail.Text = "Process";
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Name", e.Pipeline.Name }));
                    //form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Items", e.Pipeline.Items.Count.ToString() }));
                    if (e.Message.Header.Binary)
                    {
                        if (e.Message.InternalBytes.Length < 1024 * 1024)
                        {
                            form.hexBoxReceive.Visible = true;
                            form.xmlEditorBody.Visible = false;

                            form.hexBoxReceive.ByteProvider = new DynamicByteProvider(e.Message.Bytes);
                        }
                        else
                        {
                            displayMessageTooLarge();
                        }
                    }
                    else
                    {
                        form.xmlEditorBody.Text = e.Message.Text;

                        form.hexBoxReceive.Visible = false;
                        form.xmlEditorBody.Visible = true;
                    }
                    form.ShowDialog(this);
                    if (form.DialogResult == DialogResult.Cancel)
                        ClearDebugEvents();
                    //                MessageBox.Show("The pipeline " + e.Pipeline.Name + " is about to execute.", "OnPipelineBegin");
                }
            });
        }


        /// <summary>
        /// Event handler - a pipeline has finished.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OnPipelineEnd(object sender, PipelineEventArgs e)
        {
            Invoke((EventHandler)delegate
            {
                if (checkBoxDebugPipelineEnd.Checked)
                {
                    FormDebug form = new FormDebug();
                    if (_client != null) form.Text = "ESB Client Event - " + _client.Context.PartyId;
                    else form.Text = "ESB Client Event";
                    form.labelEventType.Text = "OnProcessEnd";
                    form.labelEventDesc.Text = "This event fires after a process completes executing";
                    form.labelEventDetail.Text = "Process";
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Name", e.Pipeline.Name }));
                    //form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Items", e.Pipeline.Items.Count.ToString() }));
                    if (e.Message.Header.Binary)
                    {
                        if (e.Message.InternalBytes.Length < 1024 * 1024)
                        {
                            form.hexBoxReceive.Visible = true;
                            form.xmlEditorBody.Visible = false;
                            form.hexBoxReceive.ByteProvider = new DynamicByteProvider(e.Message.Bytes);
                        }
                        else
                        {
                            displayMessageTooLarge();
                        }
                    }
                    else
                    {
                        form.xmlEditorBody.Text = e.Message.Text;

                        form.hexBoxReceive.Visible = false;
                        form.xmlEditorBody.Visible = true;
                    }
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.Cancel)
                        ClearDebugEvents();
                    //MessageBox.Show("The pipeline " + e.Pipeline.Name + " completed.", "OnPipelineEnd");
                }
            });
        }

        /// <summary>
        /// Event handler - a pipeline error has occurred.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OnPipelineError(object sender, PipelineErrorEventArgs e)
        {
            if (checkBoxDebugPipelineError.Checked)
            {
                FormDebug form = new FormDebug();
                if (_client != null) form.Text = "ESB Client Event - " + _client.Context.PartyId;
                else form.Text = "ESB Client Event";

                form.labelEventType.Text = "OnProcessError";
                form.labelEventDesc.Text = "This event fires after an error has occurred during execution of a process";
                form.labelEventDetail.Text = "Process and Error";
                form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Name", e.Pipeline.Name }));
                //form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Items", e.Pipeline.Items.Count.ToString() }));
                form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Exception Type", e.Exception.GetType().Name }));
                form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Exception Message", e.Exception.Message }));
                //form.xmlEditorBody.Text = e.Message.ToXml();
                form.ShowDialog();
                if (form.DialogResult == DialogResult.Cancel)
                    ClearDebugEvents();
                //MessageBox.Show("The pipeline " + e.Pipeline.Name + " completed.", "OnPipelineEnd");
            }

            ErrorListBoxItem errorItem = new ErrorListBoxItem();
            errorItem.Exception = e.Exception;
            errorItem.Detail = "Error occurred on process : " + e.Exception.Message;
            listBoxErrors.Items.Add(errorItem);

        }

        private void OnError(object sender, Neuron.NetX.ErrorEventArgs e)
        {
            Invoke((EventHandler)delegate
            {

                if (listBoxErrors.Items.Count > 100)
                {
                    listBoxErrors.Items.RemoveAt(0);
                }

                ErrorListBoxItem item = new ErrorListBoxItem();
                item.Exception = e.Exception;
                item.Detail = "Error occurred on topic : " + e.Topic + ". " + e.Message;
                listBoxErrors.Items.Add(item);
            });
        }

        /// <summary>
        /// Event handler - configuration changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OnConfigurationChanged(object sender, ConfigurationEventArgs e)
        {
            Invoke((EventHandler)delegate
            {
                if (checkBoxDebugConfigChanged.Checked)
                {
                    FormDebug form = new FormDebug();

                    var client = _client;

                    if (client != null && client.Context != null)
                    {
                        form.Text = "ESB Client Event - " + client.Context.PartyId;
                    }
                    else
                    {
                        form.Text = "ESB Client Event";
                    }

                    form.labelEventType.Text = "OnConfigurationChanged";
                    form.labelEventDesc.Text = "This event fires after the server notifies the client that the ESB configuration has changed";
                    form.labelEventDetail.Text = "ConfigurationEventArgs";
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Version", e.Version.ToString() }));

                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.Cancel) ClearDebugEvents();
                }

                // Since the subscriptions may have changed for the subscriber we need to re-display them.
                var connectOptions = SubscriberOptions.None;
                if (checkBoxTx.Checked)
                {
                    connectOptions |= SubscriberOptions.Transacted;
                }

                //this.ConnectToParty(connectOptions);

                DisplaySubscriptions(new PartyConnectExceptions());
            });
        }


        /// <summary>
        /// Event handler - subscriber disabled as a result of a configuration change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OnSubscriberDisabled(object sender, ConfigurationEventArgs e)
        {
            Invoke((EventHandler)delegate
            {
                if (checkBoxDebugSubscriberDisabled.Checked)
                {
                    FormDebug form = new FormDebug();
                    if (_client != null) form.Text = "ESB Client Event - " + _client.Context.PartyId;
                    else form.Text = "ESB Client Event";
                    form.labelEventType.Text = "OnSubscriberDisabled";
                    form.labelEventDesc.Text = "This event fires after the suscriber has been disabled after as a result of an ESB configuration change";
                    form.labelEventDetail.Text = "ConfigurationEventArgs";
                    form.listViewEventDetail.Items.Add(new ListViewItem(new string[] { "Version", e.Version.ToString() }));

                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.Cancel) ClearDebugEvents();
                }
            });
        }

        private void buttonDebugCheckAll_Click(object sender, EventArgs e)
        {
            SelectDebugEvents();
        }

        private void SelectDebugEvents()
        {
            checkBoxDebugOnline.Checked = true;
            checkBoxDebugOffline.Checked = true;
            checkBoxDebugMessagePartReceive.Checked = true;
            checkBoxDebugMessagePartSend.Checked = true;
            checkBoxDebugMessageSequenceGap.Checked = true;
            checkBoxDebugPipelineBegin.Checked = true;
            checkBoxDebugPipelineEnd.Checked = true;
            checkBoxDebugPipelineError.Checked = true;
            checkBoxDebugReceive.Checked = true;
            checkBoxDebugSend.Checked = true;
            checkBoxDebugConfigChanged.Checked = true;
            checkBoxDebugSubscriberDisabled.Checked = true;
        }

        private void buttonDebugClearAll_Click(object sender, EventArgs e)
        {
            ClearDebugEvents();
        }

        private void ClearDebugEvents()
        {
            checkBoxDebugOnline.Checked = false;
            checkBoxDebugOffline.Checked = false;
            checkBoxDebugMessagePartReceive.Checked = false;
            checkBoxDebugMessagePartSend.Checked = false;
            checkBoxDebugMessageSequenceGap.Checked = false;
            checkBoxDebugPipelineBegin.Checked = false;
            checkBoxDebugPipelineEnd.Checked = false;
            checkBoxDebugPipelineError.Checked = false;
            checkBoxDebugReceive.Checked = false;
            checkBoxDebugSend.Checked = false;
            checkBoxDebugConfigChanged.Checked = false;
            checkBoxDebugSubscriberDisabled.Checked = false;
        }

        private void buttonReceiveCopy_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(xmlEditorReceive.Text))
                return;
            Clipboard.SetText(xmlEditorReceive.Text, TextDataFormat.UnicodeText);
        }

        #region Send Tab

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (radioButtonSendObject.Checked)
            {
                try
                {
                    if (String.IsNullOrEmpty(textBoxObjectAssembly.Text.Trim())) throw new Exception("Please specify an assembly.");
                    if (String.IsNullOrEmpty(comboBoxClassName.Text.Trim())) throw new Exception("Please specify the class name.");

                    DynamicAssemblyLoader.DynamicClassInfo classInfo = DynamicAssemblyLoader.GetClassReference(textBoxObjectAssembly.Text.Trim(), comboBoxClassName.Text.Trim());

                    Serializer serializer = Serializer.XmlSerializer;
                    object[] attributes = classInfo.type.GetCustomAttributes(typeof(DataContractAttribute), true);
                    if (attributes == null || attributes.Length == 0) attributes = classInfo.type.GetCustomAttributes(typeof(SerializableAttribute), true);

                    if (attributes != null && attributes.Length > 0) serializer = Serializer.DataContractSerializer;

                    using (StringWriter sw = new StringWriter())
                    {
                        using (XmlTextWriter writer = new XmlTextWriter(sw))
                        {
                            writer.Formatting = Formatting.Indented;

                            switch (serializer)
                            {
                                case Serializer.XmlSerializer:
                                    XmlSerializer xmlSerializer = new XmlSerializer(classInfo.type);
                                    xmlSerializer.Serialize(writer, classInfo.ClassObject);
                                    writer.Flush();
                                    break;

                                case Serializer.DataContractSerializer:
                                    DataContractSerializer dcSerializer = new DataContractSerializer(classInfo.type);
                                    dcSerializer.WriteObject(writer, classInfo.ClassObject);
                                    writer.Flush();
                                    break;
                            }
                            xmlEditorSend.Text = sw.ToString();
                            writer.Close();
                        }
                        sw.Close();
                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error loading assembly and serializing the object to xml. " + exception.Message, "Error Loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Open Message Text/XML File";
                dialog.Filter = "XML Files (*.xml)|*.xml|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    using (TextReader tr = new StreamReader(dialog.FileName))
                    {
                        xmlEditorSend.Text = tr.ReadToEnd();

                        // close the stream
                        tr.Close();
                    }
                }
            }
        }

        #endregion

        #region General

        private void MaskInteger(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Back:
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }

        #endregion

        #region History Tab

        /// <summary>
        /// Message history list selection index changed - display the header and body of the newly selected message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void listViewMessageHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            _historySelectedMessage = null;

            bool selectionExists = listViewMessageHistory.SelectedIndices.Count == 1;

            buttonHistoryClear.Enabled = selectionExists;
            linkLabelCustomPropeties.Enabled = selectionExists;

            if (!selectionExists) return;

            ESBMessage message;

            if (!_messageHistory.TryGetValue(listViewMessageHistory.Items[listViewMessageHistory.SelectedIndices[0]].SubItems[1].Text, out message))
            {
                MessageBox.Show("The specified message is no longer in the history cache.", "Message Not Found",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ESBMessageHeader header = message.Header;
            listViewMessageHeader.Items.Clear();

            ListViewGroup lvgMessage = listViewMessageHeader.Groups.Add("A", "Default Properties");
            ListViewGroup lvgCustom = listViewMessageHeader.Groups.Add("D", "Custom Properties");
            ListViewGroup lvgHttp = listViewMessageHeader.Groups.Add("B", "HTTP Header");
            ListViewGroup lvgSoap = listViewMessageHeader.Groups.Add("C", "SOAP Header");


            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Action", header.Action }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Binary", header.Binary.ToString() }, lvgMessage));


            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "BodyType", header.BodyType }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "CompressedBodySize", header.CompressedBodySize.ToString() }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "CompressionFactor", header.CompressionFactor.ToString("G") + ":1" }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Created", ESBHelper.FormatDateTimeToString(header.Created.ToLocalTime()) }, lvgMessage));

            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "DestId", header.DestId }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Event", header.Event }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Expires", ESBHelper.FormatDateTimeToString(header.Expires.ToLocalTime()) }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "FaultTo", header.FaultTo }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "FaultType", header.FaultType.ToString() }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "From", header.From }, lvgMessage));

            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Machine", header.Machine }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "MessageId", header.MessageId }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "ParentMessageId", header.ParentMessageId }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Priority", header.Priority.ToString() }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "ProcessOnReply", header.ProcessOnReply.ToString() }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "RelatesTo", header.RelatesTo }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "ReplyTo", header.ReplyTo }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "ReplyToMessageId", header.ReplyToMessageId }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "ReplyToPartyId", header.ReplyToPartyId }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "ReplyToSessionId", header.ReplyToSessionId }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "RequestHeadersToPreserve", header.RequestHeadersToPreserve }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "RoutingSlip", header.RoutingSlip }, lvgMessage));
            //listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Schema", header.Schema }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Semantic", header.Semantic.ToString() }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Sequence", header.Sequence.ToString() }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Service", header.Service }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Session", header.Session }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "SID", header.SID }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "SourceId", header.SourceId }, lvgMessage));
            //listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "SubmissionCount", header.SubmissionCount.ToString() }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "TargetId", header.TargetId }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "To", header.To }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Topic", header.Topic }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "TransactionId", header.TransactionId }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "TrackingSequence", header.TrackingSequence.ToString() }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "UncompressedBodySize", header.UncompressedBodySize.ToString() }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Username", header.Username }, lvgMessage));

            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Process Name", header.ProcessName }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Workflow Name", header.WorkflowName }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Workflow Endpoint Name", header.WorkflowEndpointName }, lvgMessage));
            listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Workflow Instance Id", header.WorkflowInstanceId }, lvgMessage));

            if (message.Http != null)
            {
                string allHeaders = string.Empty;
                foreach (var head in message.Http.Headers)
                {
                    allHeaders += head.Key + "=" + head.Value + ";";
                }

                string query = string.Empty;
                foreach (var s in message.Http.Query)
                    query += s.Key + "=" + s.Value + "&";

                if (query.Length > 0) query = query.Substring(0, query.Length - 1);

                listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Headers", allHeaders }, lvgHttp));
                listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Method", message.Http.Method }, lvgHttp));
                listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Query", query }, lvgHttp));
                listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "StatusCode", message.Http.StatusCode.ToString() }, lvgHttp));
                listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "StatusDescription", message.Http.StatusDescription }, lvgHttp));
                listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "SuppressEntityBody", message.Http.SuppressEntityBody.ToString() }, lvgHttp));
                listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "SuppressPreamble", message.Http.SuppressPreamble.ToString() }, lvgHttp));
                listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "RemoteAddress", message.Http.RemoteAddress }, lvgHttp));
                listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "RemotePort", message.Http.RemotePort.ToString() }, lvgHttp));

            }

            if (message.Soap != null)
            {
                string allHeaders = string.Empty;
                foreach (var head in message.Soap.Headers)
                {
                    allHeaders += head.Key + "=" + head.Value + ";";
                }
                listViewMessageHeader.Items.Add(new ListViewItem(new string[] { "Headers", allHeaders }, lvgSoap));
            }

            if (header.CustomProperties != null)
            {
                foreach (NameValuePair nvp in header.CustomProperties)
                {
                    listViewMessageHeader.Items.Add(new ListViewItem(new string[] { nvp.Name, nvp.Value }, lvgCustom));

                }
            }



            listViewMessageHeader.Sort();
            listViewMessageHeader.GridLines = true;
            listViewMessageHeader.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            if (message.Header.Binary)
            {
                if (message.InternalBytes.Length < 1024 * 1024)
                {
                    hexBoxReceive.Visible = true;
                    hexBox1.Visible = true;
                    xmlEditorReceive.Visible = false;

                    hexBoxReceive.ByteProvider = new DynamicByteProvider(message.Bytes);
                    hexBox1.ByteProvider = new DynamicByteProvider(message.Bytes);
                }
                else
                {
                    displayMessageTooLarge();
                }
            }
            else
            {
                xmlEditorBody.Text = message.Text;

                hexBoxReceive.Visible = false;
                hexBox1.Visible = false;
                xmlEditorReceive.Visible = true;
            }
            //xmlSyntaxHighlighter.ColorText();
            _historySelectedMessage = message;
        }

        private void buttonHistoryCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(xmlEditorBody.Text, TextDataFormat.Rtf);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to copy: " + ex.Message);
            }
        }

        /// <summary>
        /// Clear the selected message from message history.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonHistoryClear_Click(object sender, EventArgs e)
        {
            if (listViewMessageHistory.SelectedItems.Count != 1)
            {
                MessageBox.Show("Select a message from the list.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string messageId = listViewMessageHistory.Items[listViewMessageHistory.SelectedIndices[0]].SubItems[1].Text;

            listViewMessageHistory.Items.RemoveAt(listViewMessageHistory.SelectedIndices[0]);
            buttonHistoryClearAll.Enabled = listViewMessageHistory.Items.Count > 0;

            _messageHistory.Remove(messageId);
            xmlEditorBody.Text = "";

            hexBox1.ByteProvider = new DynamicByteProvider(Encoding.UTF8.GetBytes(xmlEditorBody.Text));
            listViewMessageHeader.Items.Clear();
        }

        /// <summary>
        /// Clear all message history.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonHistoryClearAll_Click(object sender, EventArgs e)
        {
            ClearAllMessageHistory();
        }

        private void ClearAllMessageHistory()
        {
            listViewMessageHistory.Items.Clear();
            buttonHistoryClearAll.Enabled = listViewMessageHistory.Items.Count > 0;

            _messageHistory.Clear();
            xmlEditorBody.Text = "";
            hexBox1.ByteProvider = new DynamicByteProvider(Encoding.UTF8.GetBytes(xmlEditorBody.Text));

            listViewMessageHeader.Items.Clear();
        }

        /// <summary>
        /// Set the message count limit for history.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void textBoxMessageHistoryCount_TextChanged(object sender, EventArgs e)
        {
            int limit = Convert.ToInt32(textBoxMessageHistoryCount.Text);
            if (limit >= 0 && limit <= 1000)
                _messageHistoryLimit = limit;
            else
            {
                MessageBox.Show("The message history limit must be in the range 0-1000",
                    "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxMessageHistoryCount.Text = _messageHistoryLimit.ToString();

            }
        }


        #endregion

        private void nongracefulExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void viewFullMessageXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.Name)
            {
                case "tabPageReceive":
                    if (_lastReceivedMessage == null)
                        return;
                    xmlEditorReceive.Text = _lastReceivedMessage.ToSOAPMessage("Send");
                    break;
                case "tabPageSend":
                    if (_lastSentMessage == null)
                        return;
                    xmlEditorReceive.Text = _lastSentMessage.ToSOAPMessage("Send");
                    break;
            }
        }

        private void garbageCollectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            MessageBox.Show("Garbage collection complete", "Action Completed");

            Cursor = Cursors.Default;
            Application.DoEvents();
        }

        private void msgToXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xmlEditorReceive.Text = ConvertESBMessageToXml(_lastReceivedMessage);
        }

        private void xmlToMsgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ESBMessage message = ConvertXmlToESBMessage(xmlEditorReceive.Text);
            MessageBox.Show("Message created - payload = " + message.ToXml());
        }


        /// <summary>
        /// Convert an ESBMessage object into an XML string.
        /// </summary>
        /// <param name="message">ESBMessage object</param>
        /// <returns>string containing XML (serialized ESBMessage)</returns>

        private string ConvertESBMessageToXml(ESBMessage message)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                XmlSerializer sz = new XmlSerializer(typeof(ESBMessage));
                sz.Serialize(sw, message);
                return sb.ToString();
            }
        }

        /// <summary>
        /// Convert an XML string into an ESBMessage object.
        /// </summary>
        /// <param name="xml">string containing XML (deserialized ESBMessage)</param>
        /// <returns>ESBMessage object</returns>

        private ESBMessage ConvertXmlToESBMessage(string xml)
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer sz = new XmlSerializer(typeof(ESBMessage));
                return (ESBMessage)sz.Deserialize(sr);
            }
        }

        private void insertTestMessageOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["tabPageSend"];
            xmlEditorSend.Text = CreatePurchaseOrderXml();
        }

        private string CreatePurchaseOrderXsd()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("");

            sb.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\r\n");
            sb.Append("<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" elementFormDefault=\"qualified\">\r\n");
            sb.Append("	<xs:element name=\"orderxml\">\r\n");
            sb.Append("		<xs:complexType>\r\n");
            sb.Append("			<xs:sequence>\r\n");
            sb.Append("				<xs:element ref=\"PurchaseOrder\"/>\r\n");
            sb.Append("			</xs:sequence>\r\n");
            sb.Append("		</xs:complexType>\r\n");
            sb.Append("	</xs:element>\r\n");
            sb.Append("	<xs:element name=\"PurchaseOrder\">\r\n");
            sb.Append("		<xs:complexType>\r\n");
            sb.Append("			<xs:sequence>\r\n");
            sb.Append("				<xs:element ref=\"Company\"/>\r\n");
            sb.Append("				<xs:element ref=\"Supplier\"/>\r\n");
            sb.Append("				<xs:element ref=\"OrderHeader\"/>\r\n");
            sb.Append("				<xs:element ref=\"OrderLines\"/>\r\n");
            sb.Append("				<xs:element ref=\"OrderTotals\"/>\r\n");
            sb.Append("			</xs:sequence>\r\n");
            sb.Append("		</xs:complexType>\r\n");
            sb.Append("	</xs:element>\r\n");
            sb.Append("	<xs:element name=\"Company\">\r\n");
            sb.Append("		<xs:complexType>\r\n");
            sb.Append("			<xs:sequence>\r\n");
            sb.Append("				<xs:element ref=\"Name\"/>\r\n");
            sb.Append("				<xs:element ref=\"Address1\"/>\r\n");
            sb.Append("				<xs:element ref=\"Address2\"/>\r\n");
            sb.Append("				<xs:element ref=\"City\"/>\r\n");
            sb.Append("				<xs:element ref=\"State\"/>\r\n");
            sb.Append("				<xs:element ref=\"PostCode\"/>\r\n");
            sb.Append("				<xs:element ref=\"Phone\"/>\r\n");
            sb.Append("				<xs:element ref=\"Fax\"/>\r\n");
            sb.Append("				<xs:element ref=\"ACN\"/>\r\n");
            sb.Append("				<xs:element ref=\"SalesTaxCertificate\"/>\r\n");
            sb.Append("			</xs:sequence>\r\n");
            sb.Append("		</xs:complexType>\r\n");
            sb.Append("	</xs:element>\r\n");
            sb.Append("	<xs:element name=\"Phone\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"Fax\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"ACN\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"SalesTaxCertificate\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"Supplier\">\r\n");
            sb.Append("		<xs:complexType>\r\n");
            sb.Append("			<xs:sequence>\r\n");
            sb.Append("				<xs:element ref=\"SupplierCode\"/>\r\n");
            sb.Append("				<xs:element ref=\"Name\"/>\r\n");
            sb.Append("				<xs:element ref=\"Address1\"/>\r\n");
            sb.Append("				<xs:element ref=\"Address2\"/>\r\n");
            sb.Append("				<xs:element ref=\"City\"/>\r\n");
            sb.Append("				<xs:element ref=\"State\"/>\r\n");
            sb.Append("				<xs:element ref=\"PostCode\"/>\r\n");
            sb.Append("				<xs:element ref=\"Contact\"/>\r\n");
            sb.Append("			</xs:sequence>\r\n");
            sb.Append("		</xs:complexType>\r\n");
            sb.Append("	</xs:element>\r\n");
            sb.Append("	<xs:element name=\"SupplierCode\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"Name\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"Address1\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"Address2\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"City\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"State\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"PostCode\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"Contact\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"OrderHeader\">\r\n");
            sb.Append("		<xs:complexType>\r\n");
            sb.Append("			<xs:sequence>\r\n");
            sb.Append("				<xs:element ref=\"OrderType\"/>\r\n");
            sb.Append("				<xs:element ref=\"OrderNumber\"/>\r\n");
            sb.Append("				<xs:element ref=\"OrderDate\"/>\r\n");
            sb.Append("				<xs:element ref=\"ReceivingSite\"/>\r\n");
            sb.Append("				<xs:element ref=\"ReceivingWarehouse\"/>\r\n");
            sb.Append("				<xs:element ref=\"Cancelled\"/>\r\n");
            sb.Append("				<xs:element ref=\"Reprint\"/>\r\n");
            sb.Append("				<xs:element ref=\"BuyerName\"/>\r\n");
            sb.Append("				<xs:element ref=\"BuyerPhone\"/>\r\n");
            sb.Append("				<xs:element ref=\"Currency\"/>\r\n");
            sb.Append("				<xs:element ref=\"PrintDate\"/>\r\n");
            sb.Append("				<xs:element ref=\"DeliveryInstructionCode\"/>\r\n");
            sb.Append("				<xs:element ref=\"DeliveryInstructions\"/>\r\n");
            sb.Append("				<xs:element ref=\"DeliveryLocationCode\"/>\r\n");
            sb.Append("				<xs:element ref=\"DeliveryLocation\"/>\r\n");
            sb.Append("				<xs:element ref=\"SpecialInstructionCode\"/>\r\n");
            sb.Append("				<xs:element ref=\"SpecialInstructions\"/>\r\n");
            sb.Append("				<xs:element ref=\"OrderTerms\"/>\r\n");
            sb.Append("				<xs:element ref=\"Revision\"/>\r\n");
            sb.Append("				<xs:element ref=\"Remarks\"/>\r\n");
            sb.Append("			</xs:sequence>\r\n");
            sb.Append("		</xs:complexType>\r\n");
            sb.Append("	</xs:element>\r\n");
            sb.Append("	<xs:element name=\"OrderType\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"OrderNumber\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"OrderDate\" type=\"xs:dateTime\"/>\r\n");
            sb.Append("	<xs:element name=\"ReceivingSite\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"ReceivingWarehouse\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"Cancelled\">\r\n");
            sb.Append("		<xs:simpleType>\r\n");
            sb.Append("			<xs:restriction base=\"xs:string\">\r\n");
            sb.Append("				<xs:enumeration value=\"Y\"/>\r\n");
            sb.Append("				<xs:enumeration value=\"N\"/>\r\n");
            sb.Append("			</xs:restriction>\r\n");
            sb.Append("		</xs:simpleType>\r\n");
            sb.Append("	</xs:element>\r\n");
            sb.Append("	<xs:element name=\"Reprint\">\r\n");
            sb.Append("		<xs:simpleType>\r\n");
            sb.Append("			<xs:restriction base=\"xs:string\">\r\n");
            sb.Append("				<xs:enumeration value=\"Y\"/>\r\n");
            sb.Append("				<xs:enumeration value=\"N\"/>\r\n");
            sb.Append("			</xs:restriction>\r\n");
            sb.Append("		</xs:simpleType>\r\n");
            sb.Append("	</xs:element>\r\n");
            sb.Append("	<xs:element name=\"BuyerName\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"BuyerPhone\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"Currency\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"PrintDate\" type=\"xs:dateTime\"/>\r\n");
            sb.Append("	<xs:element name=\"DeliveryInstructionCode\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"DeliveryInstructions\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"DeliveryLocationCode\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"DeliveryLocation\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"SpecialInstructionCode\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"SpecialInstructions\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"OrderTerms\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"Revision\" type=\"xs:integer\"/>\r\n");
            sb.Append("	<xs:element name=\"Remarks\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"OrderLines\">\r\n");
            sb.Append("		<xs:complexType>\r\n");
            sb.Append("			<xs:sequence>\r\n");
            sb.Append("				<xs:element maxOccurs=\"unbounded\" ref=\"Line\"/>\r\n");
            sb.Append("			</xs:sequence>\r\n");
            sb.Append("		</xs:complexType>\r\n");
            sb.Append("	</xs:element>\r\n");
            sb.Append("	<xs:element name=\"Line\">\r\n");
            sb.Append("		<xs:complexType>\r\n");
            sb.Append("			<xs:sequence>\r\n");
            sb.Append("				<xs:element ref=\"LineNumber\"/>\r\n");
            sb.Append("				<xs:element ref=\"Action\"/>\r\n");
            sb.Append("				<xs:element ref=\"DestinationSite\"/>\r\n");
            sb.Append("				<xs:element ref=\"DestinationWarehouse\"/>\r\n");
            sb.Append("				<xs:element ref=\"DueDate\"/>\r\n");
            sb.Append("				<xs:element ref=\"Agreement\"/>\r\n");
            sb.Append("				<xs:element ref=\"Quantity\"/>\r\n");
            sb.Append("				<xs:element ref=\"UnitPurchase\"/>\r\n");
            sb.Append("				<xs:element ref=\"Requisition\"/>\r\n");
            sb.Append("				<xs:element ref=\"Status\"/>\r\n");
            sb.Append("				<xs:element ref=\"Priority\"/>\r\n");
            sb.Append("				<xs:element ref=\"UnitPrice\"/>\r\n");
            sb.Append("				<xs:element ref=\"LineValue\"/>\r\n");
            sb.Append("				<xs:element ref=\"GSTValue\"/>\r\n");
            sb.Append("				<xs:element ref=\"DiscountValue\"/>\r\n");
            sb.Append("				<xs:element ref=\"SalesTaxDescription\"/>\r\n");
            sb.Append("				<xs:element ref=\"SalesTaxValue\"/>\r\n");
            sb.Append("				<xs:element ref=\"GSTExempt\"/>\r\n");
            sb.Append("				<xs:element ref=\"FreightValue\"/>\r\n");
            sb.Append("				<xs:element ref=\"OnCostValue\"/>\r\n");
            sb.Append("				<xs:element ref=\"StockNumber\"/>\r\n");
            sb.Append("				<xs:element ref=\"SubStock\"/>\r\n");
            sb.Append("				<xs:element ref=\"ItemDescription\"/>\r\n");
            sb.Append("				<xs:element ref=\"PatternedDescription\"/>\r\n");
            sb.Append("				<xs:element ref=\"UnpatternedDescription\"/>\r\n");
            sb.Append("				<xs:element ref=\"Manufacturer\"/>\r\n");
            sb.Append("				<xs:element ref=\"PartNumber\"/>\r\n");
            sb.Append("				<xs:element ref=\"TBACode\"/>\r\n");
            sb.Append("				<xs:element ref=\"TBADetails\"/>\r\n");
            sb.Append("				<xs:element ref=\"LineRemarks\"/>\r\n");
            sb.Append("				<xs:element ref=\"PackingInstructions\"/>\r\n");
            sb.Append("			</xs:sequence>\r\n");
            sb.Append("		</xs:complexType>\r\n");
            sb.Append("	</xs:element>\r\n");
            sb.Append("	<xs:element name=\"LineNumber\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"Action\">\r\n");
            sb.Append("		<xs:simpleType>\r\n");
            sb.Append("			<xs:restriction base=\"xs:string\">\r\n");
            sb.Append("				<xs:enumeration value=\"\"/>\r\n");
            sb.Append("				<xs:enumeration value=\"Added\"/>\r\n");
            sb.Append("				<xs:enumeration value=\"Modified\"/>\r\n");
            sb.Append("			</xs:restriction>\r\n");
            sb.Append("		</xs:simpleType>\r\n");
            sb.Append("	</xs:element>\r\n");
            sb.Append("	<xs:element name=\"DestinationSite\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"DestinationWarehouse\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"DueDate\" type=\"xs:dateTime\"/>\r\n");
            sb.Append("	<xs:element name=\"Agreement\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"Quantity\" type=\"xs:decimal\"/>\r\n");
            sb.Append("	<xs:element name=\"UnitPurchase\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"Requisition\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"Status\">\r\n");
            sb.Append("		<xs:simpleType>\r\n");
            sb.Append("			<xs:restriction base=\"xs:string\">\r\n");
            sb.Append("				<xs:enumeration value=\"Active\"/>\r\n");
            sb.Append("				<xs:enumeration value=\"Cancelled\"/>\r\n");
            sb.Append("			</xs:restriction>\r\n");
            sb.Append("		</xs:simpleType>\r\n");
            sb.Append("	</xs:element>\r\n");
            sb.Append("	<xs:element name=\"Priority\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"UnitPrice\" type=\"xs:decimal\"/>\r\n");
            sb.Append("	<xs:element name=\"LineValue\" type=\"xs:decimal\"/>\r\n");
            sb.Append("	<xs:element name=\"GSTValue\" type=\"xs:decimal\"/>\r\n");
            sb.Append("	<xs:element name=\"DiscountValue\" type=\"xs:decimal\"/>\r\n");
            sb.Append("	<xs:element name=\"SalesTaxDescription\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"SalesTaxValue\" type=\"xs:decimal\"/>\r\n");
            sb.Append("	<xs:element name=\"GSTExempt\">\r\n");
            sb.Append("		<xs:simpleType>\r\n");
            sb.Append("			<xs:restriction base=\"xs:string\">\r\n");
            sb.Append("				<xs:enumeration value=\"Y\"/>\r\n");
            sb.Append("				<xs:enumeration value=\"N\"/>\r\n");
            sb.Append("			</xs:restriction>\r\n");
            sb.Append("		</xs:simpleType>\r\n");
            sb.Append("	</xs:element>\r\n");
            sb.Append("	<xs:element name=\"FreightValue\" type=\"xs:decimal\"/>\r\n");
            sb.Append("	<xs:element name=\"OnCostValue\" type=\"xs:decimal\"/>\r\n");
            sb.Append("	<xs:element name=\"StockNumber\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"SubStock\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"ItemDescription\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"PatternedDescription\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"UnpatternedDescription\" type=\"xs:string\r\n");
            sb.Append("	<xs:element name=\"Manufacturer\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"PartNumber\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"TBACode\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"TBADetails\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"LineRemarks\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"PackingInstructions\" type=\"xs:string\"/>\r\n");
            sb.Append("	<xs:element name=\"OrderTotals\">\r\n");
            sb.Append("		<xs:complexType>\r\n");
            sb.Append("			<xs:sequence>\r\n");
            sb.Append("				<xs:element ref=\"FreightTotal\"/>\r\n");
            sb.Append("				<xs:element ref=\"OnCostTotal\"/>\r\n");
            sb.Append("				<xs:element ref=\"OrderTotal\"/>\r\n");
            sb.Append("			</xs:sequence>\r\n");
            sb.Append("		</xs:complexType>\r\n");
            sb.Append("	</xs:element>\r\n");
            sb.Append("	<xs:element name=\"FreightTotal\" type=\"xs:decimal\"/>\r\n");
            sb.Append("	<xs:element name=\"OnCostTotal\" type=\"xs:decimal\"/>\r\n");
            sb.Append("	<xs:element name=\"OrderTotal\" type=\"xs:decimal\"/>\r\n");
            sb.Append("</xs:schema>\r\n");

            return sb.ToString();
        }


        private string CreatePurchaseOrderXml()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>\r\n");
            sb.Append("<orderxml>\r\n");
            sb.Append("  <PurchaseOrder>\r\n");
            sb.Append("		<Company>\r\n");
            sb.Append("			<Name>Fictional Company</Name>\r\n");
            sb.Append("			<Address1>ADDRESS LINE 1</Address1>\r\n");
            sb.Append("			<Address2/>\r\n");
            sb.Append("			<City>MELBOURNE</City>\r\n");
            sb.Append("			<State>VIC</State>\r\n");
            sb.Append("			<PostCode>3182</PostCode>\r\n");
            sb.Append("			<Phone>03 99999999</Phone>\r\n");
            sb.Append("			<Fax>03 99999999</Fax>\r\n");
            sb.Append("			<ACN>99 999 999</ACN>\r\n");
            sb.Append("			<SalesTaxCertificate>E9999999</SalesTaxCertificate>\r\n");
            sb.Append("		</Company>\r\n");
            sb.Append("		<Supplier>\r\n");
            sb.Append("			<SupplierCode>9999</SupplierCode>\r\n");
            sb.Append("			<Name>SUPPLIER XYZ</Name>\r\n");
            sb.Append("			<Address1>ADDRESS LINE 1</Address1>\r\n");
            sb.Append("			<Address2/>\r\n");
            sb.Append("			<City>MELBOURNE</City>\r\n");
            sb.Append("			<State>VIC</State>\r\n");
            sb.Append("			<PostCode>3182</PostCode>\r\n");
            sb.Append("			<Contact>J BLOGGS</Contact>\r\n");
            sb.Append("		</Supplier>\r\n");
            sb.Append("		<OrderHeader>\r\n");
            sb.Append("			<OrderType>ST</OrderType>\r\n");
            sb.Append("			<OrderNumber>00099999</OrderNumber>\r\n");
            sb.Append("			<OrderDate>2004-04-26T00:00:00</OrderDate>\r\n");
            sb.Append("			<ReceivingSite>01</ReceivingSite>\r\n");
            sb.Append("			<ReceivingWarehouse>01</ReceivingWarehouse>\r\n");
            sb.Append("			<Cancelled>Y</Cancelled>\r\n");
            sb.Append("			<Reprint>N</Reprint>\r\n");
            sb.Append("			<BuyerName>Buyer Name</BuyerName>\r\n");
            sb.Append("			<BuyerPhone>03 99999999</BuyerPhone>\r\n");
            sb.Append("			<Currency>AU</Currency>\r\n");
            sb.Append("			<PrintDate>2004-04-26T14:00:42</PrintDate>\r\n");
            sb.Append("			<DeliveryInstructionCode>9</DeliveryInstructionCode>\r\n");
            sb.Append("			<DeliveryInstructions>NOTE: On completion, Please fax a copy of the invoice (Include Order No) to</DeliveryInstructions>\r\n");
            sb.Append("			<DeliveryLocationCode>4</DeliveryLocationCode>\r\n");
            sb.Append("			<DeliveryLocation>CENTRAL WAREHOUSE ADDRESS</DeliveryLocation>\r\n");
            sb.Append("			<SpecialInstructionCode/>\r\n");
            sb.Append("			<SpecialInstructions/>\r\n");
            sb.Append("			<OrderTerms>NET FROM STATEMENT 30 DAYS</OrderTerms>\r\n");
            sb.Append("			<Revision>0</Revision>\r\n");
            sb.Append("			<Remarks/>\r\n");
            sb.Append("		</OrderHeader>\r\n");
            sb.Append("		<OrderLines>\r\n");
            sb.Append("			<Line>\r\n");
            sb.Append("				<LineNumber>0001</LineNumber>\r\n");
            sb.Append("				<Action/>\r\n");
            sb.Append("				<DestinationSite>01</DestinationSite>\r\n");
            sb.Append("				<DestinationWarehouse>01</DestinationWarehouse>\r\n");
            sb.Append("				<DueDate>2004-04-30T00:00:00</DueDate>\r\n");
            sb.Append("				<Agreement/>\r\n");
            sb.Append("				<Quantity>1.0000</Quantity>\r\n");
            sb.Append("				<UnitPurchase>EA</UnitPurchase>\r\n");
            sb.Append("				<Requisition/>\r\n");
            sb.Append("				<Status>Active</Status>\r\n");
            sb.Append("				<Priority>U</Priority>\r\n");
            sb.Append("				<UnitPrice>21.0000</UnitPrice>\r\n");
            sb.Append("				<LineValue>21.00</LineValue>\r\n");
            sb.Append("				<GSTValue>2.10</GSTValue>\r\n");
            sb.Append("				<DiscountValue>0.00</DiscountValue>\r\n");
            sb.Append("				<SalesTaxDescription>TAX EXEMPT</SalesTaxDescription>\r\n");
            sb.Append("				<SalesTaxValue>0.00</SalesTaxValue>\r\n");
            sb.Append("				<GSTExempt>N</GSTExempt>\r\n");
            sb.Append("				<FreightValue>0.00</FreightValue>\r\n");
            sb.Append("				<OnCostValue>0.00</OnCostValue>\r\n");
            sb.Append("				<StockNumber>00004004</StockNumber>\r\n");
            sb.Append("				<SubStock>01</SubStock>\r\n");
            sb.Append("				<ItemDescription>FLANGE PIPE BLACK 250MM NB BST D 10IN ABC</ItemDescription>\r\n");
            sb.Append("				<PatternedDescription/>\r\n");
            sb.Append("				<UnpatternedDescription/>\r\n");
            sb.Append("				<Manufacturer>BLKWOODS</Manufacturer>\r\n");
            sb.Append("				<PartNumber>03230505</PartNumber>\r\n");
            sb.Append("				<TBACode/>\r\n");
            sb.Append("				<TBADetails/>\r\n");
            sb.Append("				<LineRemarks/>\r\n");
            sb.Append("				<PackingInstructions/>\r\n");
            sb.Append("			</Line>\r\n");
            sb.Append("			<Line>\r\n");
            sb.Append("				<LineNumber>0002</LineNumber>\r\n");
            sb.Append("				<Action/>\r\n");
            sb.Append("				<DestinationSite>01</DestinationSite>\r\n");
            sb.Append("				<DestinationWarehouse>01</DestinationWarehouse>\r\n");
            sb.Append("				<DueDate>2004-04-30T00:00:00</DueDate>\r\n");
            sb.Append("				<Agreement/>\r\n");
            sb.Append("				<Quantity>50.0000</Quantity>\r\n");
            sb.Append("				<UnitPurchase>ROLL</UnitPurchase>\r\n");
            sb.Append("				<Requisition/>\r\n");
            sb.Append("				<Status>Active</Status>\r\n");
            sb.Append("				<Priority>U</Priority>\r\n");
            sb.Append("				<UnitPrice>0.3700</UnitPrice>\r\n");
            sb.Append("				<LineValue>18.50</LineValue>\r\n");
            sb.Append("				<GSTValue>1.85</GSTValue>\r\n");
            sb.Append("				<DiscountValue>0.00</DiscountValue>\r\n");
            sb.Append("				<SalesTaxDescription>TAX EXEMPT</SalesTaxDescription>\r\n");
            sb.Append("				<SalesTaxValue>0.00</SalesTaxValue>\r\n");
            sb.Append("				<GSTExempt>N</GSTExempt>\r\n");
            sb.Append("				<FreightValue>0.00</FreightValue>\r\n");
            sb.Append("				<OnCostValue>0.00</OnCostValue>\r\n");
            sb.Append("				<StockNumber>00006219</StockNumber>\r\n");
            sb.Append("				<SubStock>01</SubStock>\r\n");
            sb.Append("				<ItemDescription>TAPE THREAD SEALING 12MM X 10M TEFLON PTFE</ItemDescription>\r\n");
            sb.Append("				<PatternedDescription/>\r\n");
            sb.Append("				<UnpatternedDescription/>\r\n");
            sb.Append("				<Manufacturer>BLKWOODS</Manufacturer>\r\n");
            sb.Append("				<PartNumber>05122404</PartNumber>\r\n");
            sb.Append("				<TBACode/>\r\n");
            sb.Append("				<TBADetails/>\r\n");
            sb.Append("				<LineRemarks/>\r\n");
            sb.Append("				<PackingInstructions/>\r\n");
            sb.Append("			</Line>\r\n");
            sb.Append("		</OrderLines>\r\n");
            sb.Append("		<OrderTotals>\r\n");
            sb.Append("			<FreightTotal>0.00</FreightTotal>\r\n");
            sb.Append("			<OnCostTotal>0.00</OnCostTotal>\r\n");
            sb.Append("			<OrderTotal>43.45</OrderTotal>\r\n");
            sb.Append("		</OrderTotals>\r\n");
            sb.Append("  </PurchaseOrder>\r\n");
            sb.Append("</orderxml>\r\n");
            return sb.ToString();
        }

        //private void formatXMLToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    xmlSyntaxLanguage1.GetService<ITextFormatter>().Format(xmlEditorSend.Document.CurrentSnapshot, TextPositionRange.CreateCollection(xmlEditorSend.Document.CurrentSnapshot.TextRangeToPositionRange(xmlEditorSend.Document.CurrentSnapshot.TextRange), false));
        //    xmlSyntaxLanguage1.GetService<ITextFormatter>().Format(xmlEditorReceive.Document.CurrentSnapshot, TextPositionRange.CreateCollection(xmlEditorReceive.Document.CurrentSnapshot.TextRangeToPositionRange(xmlEditorReceive.Document.CurrentSnapshot.TextRange), false));
        //    xmlSyntaxLanguage1.GetService<ITextFormatter>().Format(xmlEditorBody.Document.CurrentSnapshot, TextPositionRange.CreateCollection(xmlEditorBody.Document.CurrentSnapshot.TextRangeToPositionRange(xmlEditorBody.Document.CurrentSnapshot.TextRange), false));
        //}

        private void largePurchaseOrderXSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["tabPageSend"];
            xmlEditorSend.Text = CreatePurchaseOrderXsd();
        }

        private void radioButtonSendObject_CheckedChanged(object sender, EventArgs e)
        {
            textBoxObjectAssembly.Enabled = radioButtonSendObject.Checked;
            comboBoxClassName.Enabled = radioButtonSendObject.Checked;
            buttonAssemblyBrowse.Enabled = radioButtonSendObject.Checked;
        }

        private void buttonAssemblyBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Locate Assembly File";
            dialog.Filter = "Assemblies (*.dll, *.exe)|*.dll;*.exe";

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxObjectAssembly.Text = dialog.FileName;

                Assembly assembly = Assembly.LoadFile(dialog.FileName);
                Type[] types = assembly.GetTypes();
                if (types != null)
                {
                    List<String> classNames = new List<string>();
                    comboBoxClassName.Items.Clear();

                    foreach (Type type in types)
                    {
                        if (!type.IsInterface && !type.IsAbstract && !type.ContainsGenericParameters)
                        {
                            classNames.Add(type.FullName);
                        }
                    }

                    classNames.Sort();
                    comboBoxClassName.Items.AddRange(classNames.ToArray());
                    if (classNames.Count > 0) comboBoxClassName.Text = classNames[0];
                }
            }

        }

        /// <summary>
        /// Creates an Adminstrator object based on configuration from testclientsettings
        /// </summary>
        /// <returns></returns>
        private Administrator GetAdministrator()
        {
            Administrator admin = null;
            if (IsNeuronAvailable())
            {
                var locatorServiceAddress = string.Empty;
                try
                {
                    locatorServiceAddress = Neuron.NetX.EsbService.ESBServiceFactory.ConfigurationServiceAddress(this.Machine, this.Port, false, "");
                    admin = new Administrator(locatorServiceAddress, this.ServiceIdentity, _clientCredentials);
                    admin.OpenConfiguration(true);
                }
                catch (Exception ex)
                {
                    if (ex is EndpointNotFoundException ||
                            (ex.InnerException != null && ex.InnerException is EndpointNotFoundException))
                    {
                        if (admin != null)
                            admin.Dispose();

                        // check the current url. determine if configured for port sharing
                        // try using other address in case port shaing is enabled..
                        locatorServiceAddress = Neuron.NetX.EsbService.ESBServiceFactory.ConfigurationServiceAddress(this.Machine, this.Port, false, this.InstanceName);
                        if (admin != null) admin.Dispose();
                        admin = new Administrator(locatorServiceAddress, this.ServiceIdentity, _clientCredentials);
                        admin.OpenConfiguration(true);

                    }
                    else
                        throw;
                }
            }
            return admin;
        }
        private void buttonBrowseSubscribers_Click(object sender, EventArgs e)
        {
            var locatorServiceAddress = string.Empty;
            Administrator admin = null;
            try
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                comboBoxSubscriberId.Items.Clear();

                admin = GetAdministrator();
                if (admin == null) return;

                var zone = string.Empty;
                if (_client != null) zone = _client.Context.Zone.Name;
                else zone = "Enterprise";

                string[] idList = ESBHelper.GetESBEntityNames<ESBSubscriber>(admin.GetAllSubscribers(zone));
                if (idList != null)
                {
                    comboBoxSubscriberId.Items.AddRange(idList);
                    if (comboBoxSubscriberId.Items.Count > 0)
                        comboBoxSubscriberId.SelectedIndex = 0;
                }

                comboBoxSubscriberId.DropDownWidth = DropDownWidth(comboBoxSubscriberId);
            }
            catch (Exception ex)
            {
                var message = string.Format(CultureInfo.CurrentCulture,
                    "Unable to connect to the '{0}' runtime instance on the '{1}' Neuron ESB machine using port '{2}'. {3}",
                    this.InstanceName,
                    this.Machine,
                    this.Port,
                    ex.Message);

                MessageBox.Show(this, message, "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (admin != null && admin.Configuration != null)
                    admin.CloseConfiguration();

                if (admin != null)
                    admin.Dispose();
                admin = null;

                Cursor = Cursors.Default;
                Application.DoEvents();
            }
        }

        private void buttonBrowseTopics_Click(object sender, EventArgs e)
        {
            Administrator admin = null;
            try
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                comboBoxSendTopic.Items.Clear();

                admin = GetAdministrator();
                if (admin == null) return;

                List<string> topicsList = new List<string>();

                var zone = string.Empty;
                if (_client != null) zone = _client.Context.Zone.Name;
                else zone = "Enterprise";

                List<ESBTopic> topics = admin.GetAllTopics("Enterprise");
                foreach (ESBTopic topic in topics)
                {
                    topicsList.Add(topic.Name);

                    if (topic.Hierarchy != null)
                    {
                        foreach (Subtopic subtopic in topic.Hierarchy)
                        {
                            if (subtopic != null) topicsList.Add(subtopic.Name);
                        }
                    }
                }

                comboBoxSendTopic.Items.AddRange(topicsList.ToArray());
                if (comboBoxSendTopic.Items.Count > 0)
                    comboBoxSendTopic.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                var message = string.Format(CultureInfo.CurrentCulture,
                    "Unable to connect to the '{0}' runtime instance on the '{1}' Neuron ESB machine using port '{2}'. {3}",
                    this.InstanceName,
                    this.Machine,
                    this.Port,
                    ex.Message);

                MessageBox.Show(this, message, "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (admin != null && admin.Configuration != null)
                    admin.CloseConfiguration();

                if (admin != null)
                    admin.Dispose();
                admin = null;

                Cursor = Cursors.Default;
                Application.DoEvents();
            }
        }

        private void updateConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Force the management thread routine to check for a configuration update.

        }

        private void buttonDisplayMessageRecipients_Click(object sender, EventArgs e)
        {
            if (_client == null) return;

            ESBMessage message = new ESBMessage(comboBoxSendTopic.Text, xmlEditorSend.Text);

            if (comboBoxSendSemantic.Text == "Direct") message.Header.Semantic = Semantic.Direct;
            if (comboBoxSendSemantic.Text == "Multicast") message.Header.Semantic = Semantic.Multicast;
            if (comboBoxSendSemantic.Text == "Request") message.Header.Semantic = Semantic.Request;
            if (comboBoxSendSemantic.Text == "Reply") message.Header.Semantic = Semantic.Reply;

            string[] recipients = _client.ComputeMessageRecipients(message);

            if (recipients == null || recipients.Length == 0)
                MessageBox.Show("No subscibers are eligible to receive this message.", "No Eligible Subscribers", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                //remove system objects
                List<string> filteredRecipients = new List<string>();
                foreach (string s in recipients)
                {
                    if (!s.StartsWith(ESBHelper.TCP_SERVER_RELAY_SUBSCRIBERID_BASE))
                        filteredRecipients.Add(s);
                }
                MessageBox.Show("The following subscribers are eligible to receive this message:\r\n\r\n" + String.Join("\r\n", filteredRecipients.ToArray()), "Eligible Subscribers", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSaveReceivedMessage_Click(object sender, EventArgs e)
        {
            if (_lastReceivedMessage == null)
            {
                MessageBox.Show("A message must be received before you can save it.",
                    "No Message to Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (Stream file = saveFileDialog1.OpenFile())
                    {
                        file.Write(_lastReceivedMessage.InternalBytes, 0, _lastReceivedMessage.InternalBytes.Length);
                        file.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load content from file.\r\n\r\n" + ex.ToString(), "Load from File Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        byte[] _largeMessageBytes;

        void displaySendMessageTooLarge()
        {
            hexBox.Visible = false;
            xmlEditorSend.Visible = false;
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    byte[] buffer = File.ReadAllBytes(openFileDialog1.FileName);
                    Encoding enc = ESBHelper.DetermineEncoding(buffer, buffer.Length);

                    if (enc == null) // Binary
                    {
                        radioButtonSendBinary.Checked = true;
                        if (buffer.Length < 1024 * 1024)
                        {
                            hexBox.ByteProvider = new DynamicByteProvider(buffer);
                        }
                        else
                        {
                            _largeMessageBytes = buffer;
                            displaySendMessageTooLarge();
                        }
                    }
                    else // Text
                    {
                        ESBMessage message = new ESBMessage(comboBoxSendTopic.Text, enc.GetString(buffer));
                        xmlEditorSend.Text = message.Text;
                        radioButtonSendXml.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load content from file.\r\n\r\n" + ex.ToString(), "Load from File Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void linkLabelCustomPropeties_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_historySelectedMessage == null) return;

            FormCustomProperties form = new FormCustomProperties();
            CenterForm(form);
            form.Message = _historySelectedMessage;
            form.ShowDialog();
        }

        private void linkLabelSendCustomProperties_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_sendCustomProperties == null) return;

            FormCustomProperties form = new FormCustomProperties();
            CenterForm(form);
            form.Message = _sendCustomProperties;
            form.ShowDialog();
        }

        private void linkLabelReceiveCustomProperties_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_lastReceivedMessage == null) return;

            FormCustomProperties form = new FormCustomProperties();
            CenterForm(form);
            form.Message = _lastReceivedMessage;
            form.ShowDialog();
        }


        // Center a form in the main form.

        public void CenterForm(Form form)
        {
            int xCenter = this.Left + (this.Width / 2);
            int yCenter = this.Top + (this.Height / 2);
            form.Left = xCenter - (form.Width / 2);
            form.Top = yCenter - (form.Height / 2);
        }

        public Byte[] GetBinaryPayload(string text)
        {
            Byte[] bytes = ((DynamicByteProvider)hexBox.ByteProvider).Bytes.ToArray();


            // ** the hexBox.Visible property is always false....regardless if its set to true. A bug probably with the custom control
            if (bytes.Length < 1024 * 1024)
                return bytes;
            else
                return _largeMessageBytes;

        }


        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopSending = true;
        }

        private void comboBoxSubscriberId_DropDown(object sender, EventArgs e)
        {
            // If the drop down combo box is empty then populate it.
            if (comboBoxSubscriberId.Items.Count == 0)
            {
                buttonBrowseSubscribers_Click(sender, e);
            }
        }

        private void listBoxErrors_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxErrors.SelectedItem != null)
            {
                ErrorListBoxItem item = (ErrorListBoxItem)listBoxErrors.SelectedItem;

                String message = item.Detail;
                if (item.Exception != null)
                {
                    message += "\r\n\r\n" + item.Exception.ToString();
                }

                InformationBox info = new InformationBox();
                info.SetText(message);
                info.ShowDialog();
            }

        }

        private void radioButtonMessageSendTab_CheckedChanged(object sender, EventArgs e)
        {
            labelMessageSize.Enabled = !radioButtonMessageSendTab.Checked;
            textBoxMessageSize.Enabled = !radioButtonMessageSendTab.Checked;
        }

        private void tabPageStats_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonSendBinary_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSendBinary.Checked)
            {
                hexBox.Visible = true;
                xmlEditorSend.Visible = !hexBox.Visible;
                hexBox.ByteProvider = new Neuron.UI.DynamicByteProvider(Encoding.UTF8.GetBytes(xmlEditorSend.Text));
            }
            else
            {
                hexBox.Visible = false;
                xmlEditorSend.Visible = !hexBox.Visible;
                xmlEditorSend.Text = System.Text.Encoding.UTF8.GetString(((Neuron.UI.DynamicByteProvider)hexBox.ByteProvider).Bytes.ToArray());
            }
        }

        void resizeHexBoxes()
        {
            using (Graphics g = Graphics.FromHwnd(this.Handle))
            {
                hexBox.BytesPerLine = Math.Max(1, Width / ((int)g.MeasureString("F", hexBox.Font, Width).Width) / 3 - 2);
            }

            using (Graphics g = Graphics.FromHwnd(this.Handle))
            {
                hexBoxReceive.BytesPerLine = Math.Max(1, Width / ((int)g.MeasureString("F", hexBoxReceive.Font, Width).Width) / 3 - 2);
            }
        }

        private void hexBox_Resize(object sender, EventArgs e)
        {
            resizeHexBoxes();
        }

        private void hexBoxReceive_Resize(object sender, EventArgs e)
        {
            resizeHexBoxes();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            resizeHexBoxes();
        }
        private static int cnt = 0;
        private void AddMessageToMessageHistory(ESBMessage esbMessage, string semantic)
        {
            if (_messageHistoryLimit > 0)
            {
                if (!_messageHistory.ContainsKey(esbMessage.Header.MessageId))
                {
                    _messageHistory.Add(esbMessage.Header.MessageId, esbMessage.Clone(true));    // Copy message, same ID. new ESBMessage(e.Message));
                    ListViewItem itemToInsert = new ListViewItem(new[] { semantic, esbMessage.Header.MessageId }) { Tag = esbMessage.Header.MessageId };
                    listViewMessageHistory.Items.Add(itemToInsert);

                    if (listViewMessageHistory.Items.Count > _messageHistoryLimit)
                    {
                        ListViewItem itemToRemove = listViewMessageHistory.Items[0];
                        _messageHistory.Remove(itemToRemove.Tag.ToString());
                        listViewMessageHistory.Items[0].Remove();
                    }
                    buttonHistoryClearAll.Enabled = listViewMessageHistory.Items.Count > 0;
                }
                else
                {
                    var msgId = string.Format("{0}_{1}", esbMessage.Header.MessageId, cnt++);

                    _messageHistory.Add(msgId, esbMessage.Clone(true));    // Copy message, same ID. new ESBMessage(e.Message));
                    ListViewItem itemToInsert = new ListViewItem(new[] { semantic, msgId }) { Tag = msgId };
                    listViewMessageHistory.Items.Add(itemToInsert);

                    if (listViewMessageHistory.Items.Count > _messageHistoryLimit)
                    {
                        ListViewItem itemToRemove = listViewMessageHistory.Items[0];
                        _messageHistory.Remove(itemToRemove.Tag.ToString());
                        listViewMessageHistory.Items[0].Remove();
                    }
                    buttonHistoryClearAll.Enabled = listViewMessageHistory.Items.Count > 0;
                    //MessageBox.Show(this, "The message could not be added to the message history because a message with the same ID is already in the message history.");
                }
            }
        }

        void loadMessage(String fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                ESBMessage message = ESBMessage.ReadMessage(fileStream);

                if (message.Header.Binary) // Binary
                {
                    radioButtonSendBinary.Checked = true;
                    hexBox.ByteProvider = new DynamicByteProvider(message.InternalBytes);
                }
                else // Text
                {
                    xmlEditorSend.Text = message.Text;
                    radioButtonSendXml.Checked = true;
                }

                textBoxSendAction.Text = message.Header.Action;
                textBoxSendDest.Text = message.Header.DestId;
                comboBoxSendTopic.Text = message.Header.Topic;
                _sendCustomProperties.Header.CustomProperties = message.Header.CustomProperties;

                switch (message.Header.Priority)
                {
                    case 0: comboBoxPriority.Text = ""; break;
                    case 1: comboBoxPriority.Text = "High"; break;
                    case 2: comboBoxPriority.Text = "Normal"; break;
                    case 3: comboBoxPriority.Text = "Low"; break;
                }

                switch (message.Header.Semantic)
                {
                    case Semantic.Direct: comboBoxSendSemantic.Text = "Direct"; break;
                    case Semantic.Multicast: comboBoxSendSemantic.Text = "Multicast"; break;
                    case Semantic.Request: comboBoxSendSemantic.Text = "Request"; break;
                    case Semantic.Reply: comboBoxSendSemantic.Text = "Reply"; break;
                }
            }
        }

        private void buttonLoadMessage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.Filter = "ESBMSG files (*.esbmsg)|*.esbmsg|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    loadMessage(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load content from file.\r\n\r\n" + ex.Message, "Load from File Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonSaveMessage_Click(object sender, EventArgs e)
        {
            if (_lastReceivedMessage == null)
            {
                MessageBox.Show("A message must be received before you can save it.",
                    "No Message to Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "ESBMSG files (*.esbmsg)|*.esbmsg|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (Stream file = saveFileDialog1.OpenFile())
                    {
                        _lastReceivedMessage.WriteMessage(file);
                        file.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load content from file.\r\n\r\n" + ex.ToString(), "Load from File Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void InitializeConnectionProperties()
        {
            var appSettingsConfig = AppSettingsConfig.GetAppSetting();
            Uri serviceAddress = new Uri(appSettingsConfig.AppSettings.SDKHost.ServiceAddress);

            this.InstanceName = appSettingsConfig.AppSettings.SDKHost.InstanceName;
            this.Machine = serviceAddress.Host;

            int port = 50000;
            if (int.TryParse(serviceAddress.Port.ToString(), NumberStyles.Integer, CultureInfo.InvariantCulture, out port))
                this.Port = port;
            else
                this.Port = 50000;

            this.ServiceIdentity = appSettingsConfig.AppSettings.SDKHost.ServiceIdentity;

            if (appSettingsConfig.AppSettings.SDKHost.WinADAuthCredentials != null)
            {
                var userName = appSettingsConfig.AppSettings.SDKHost.WinADAuthCredentials.Username;
                var passWord = appSettingsConfig.AppSettings.SDKHost.WinADAuthCredentials.Password;
                var domain = appSettingsConfig.AppSettings.SDKHost.WinADAuthCredentials.Domain;

                if (!String.IsNullOrEmpty(userName))
                {
                    _clientCredentials = new NetworkCredential(userName, passWord, domain);
                }
                else
                {
                    _clientCredentials = null;
                }
            }

        }
        private void connectionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (TestClientSettings settings = new TestClientSettings())
                {
                    InitializeConnectionProperties();

                    settings.InstanceName = this.InstanceName;
                    settings.Machine = this.Machine;
                    settings.Port = this.Port;
                    settings.ServiceIdentity = this.ServiceIdentity;

                    if (_clientCredentials != null)
                    {
                        settings.Username = _clientCredentials.UserName;
                        settings.Password = _clientCredentials.Password;
                        settings.Domain = _clientCredentials.Domain;
                    }

                    DialogResult result = settings.ShowDialog();
                    if (result == DialogResult.OK)
                    {
						var appSettingsConfig = AppSettingsConfig.GetAppSetting();
						Uri serviceAddress = new Uri(appSettingsConfig.AppSettings.SDKHost.ServiceAddress);

                        appSettingsConfig.AppSettings.SDKHost.ServiceIdentity = settings.ServiceIdentity;
                        appSettingsConfig.AppSettings.SDKHost.InstanceName = settings.InstanceName;
                        appSettingsConfig.AppSettings.SDKHost.ServiceAddress = $"http://{settings.Machine}:{settings.Port}/";

                        this.InstanceName = settings.InstanceName;
                        this.Machine = settings.Machine;
                        this.Port = settings.Port;
                        this.ServiceIdentity = settings.ServiceIdentity;
                        this.Username = settings.Username;
                        this.Password = settings.Password;
                        this.Domain = settings.Domain;

                        if (appSettingsConfig.AppSettings.SDKHost.WinADAuthCredentials != null)
                        {
							appSettingsConfig.AppSettings.SDKHost.WinADAuthCredentials.Username = this.Username;
							appSettingsConfig.AppSettings.SDKHost.WinADAuthCredentials.Password = this.Password;
							appSettingsConfig.AppSettings.SDKHost.WinADAuthCredentials.Domain = this.Domain;
                        }
						appSettingsConfig.SaveESBSettingsConfiguration();


						if (!String.IsNullOrEmpty(settings.Username))
                        {
                            _clientCredentials = new NetworkCredential(settings.Username, settings.Password, settings.Domain);
                        }
                        else
                        {
                            _clientCredentials = null;
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void listViewMessageHistory_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listViewMessageHistory.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void copyToSendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xmlEditorSend.Text = xmlEditorBody.Text;
            _sendCustomProperties = _historySelectedMessage.Clone(true);
            tabControl1.SelectedTab = tabPageSend;
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearSend();
            ClearReceive();
            ClearAllMessageHistory();
        }

        private void hexBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
