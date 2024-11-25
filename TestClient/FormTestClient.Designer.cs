//using ActiproSoftware.Text;

namespace Neuron.TestClient
{
    partial class FormTestClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTestClient));
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            nongracefulExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewFullMessageXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            insertTestMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            insertTestMessageOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            largePurchaseOrderXSDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            formatXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            connectionSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            updateConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            garbageCollectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            msgToXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            xmlToMsgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            statusSentCount = new System.Windows.Forms.ToolStripStatusLabel();
            statusSentTime = new System.Windows.Forms.ToolStripStatusLabel();
            statusSentMsgPerSec = new System.Windows.Forms.ToolStripStatusLabel();
            statusRecvCount = new System.Windows.Forms.ToolStripStatusLabel();
            statusRecvTime = new System.Windows.Forms.ToolStripStatusLabel();
            statusRecvMsgPerSec = new System.Windows.Forms.ToolStripStatusLabel();
            timerStatus = new System.Windows.Forms.Timer(components);
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPageConnect = new System.Windows.Forms.TabPage();
            panelConnectMain = new System.Windows.Forms.Panel();
            label21 = new System.Windows.Forms.Label();
            dataGridViewSubscriptions = new System.Windows.Forms.DataGridView();
            ColumnTopic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ColumnDirection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ColumnTransport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panelConnectBottom = new System.Windows.Forms.Panel();
            buttonResume = new System.Windows.Forms.Button();
            buttonPause = new System.Windows.Forms.Button();
            panelConnectBottom2 = new System.Windows.Forms.Panel();
            labelFilter = new System.Windows.Forms.Label();
            textBoxFilter = new System.Windows.Forms.TextBox();
            checkBoxFilter = new System.Windows.Forms.CheckBox();
            buttonClearFilter = new System.Windows.Forms.Button();
            buttonSetFilter = new System.Windows.Forms.Button();
            panelConnectTop = new System.Windows.Forms.Panel();
            checkBoxBulkTestMode = new System.Windows.Forms.CheckBox();
            checkBoxTx = new System.Windows.Forms.CheckBox();
            buttonBrowseSubscribers = new System.Windows.Forms.Button();
            comboBoxSubscriberId = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            buttonDisconnect = new System.Windows.Forms.Button();
            buttonConnect = new System.Windows.Forms.Button();
            tabPageSend = new System.Windows.Forms.TabPage();
            panelSendMain = new System.Windows.Forms.Panel();
            xmlEditorSend = new System.Windows.Forms.TextBox();
            linkLabelSendCustomProperties = new System.Windows.Forms.LinkLabel();
            label10 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            hexBox = new UI.HexBox();
            panelSendBottom2 = new System.Windows.Forms.Panel();
            radioButtonSendBinary = new System.Windows.Forms.RadioButton();
            comboBoxClassName = new System.Windows.Forms.ComboBox();
            buttonAssemblyBrowse = new System.Windows.Forms.Button();
            labelObjectClass = new System.Windows.Forms.Label();
            labelObjectAssembly = new System.Windows.Forms.Label();
            textBoxObjectAssembly = new System.Windows.Forms.TextBox();
            radioButtonSendObject = new System.Windows.Forms.RadioButton();
            textBoxSendAction = new System.Windows.Forms.TextBox();
            label20 = new System.Windows.Forms.Label();
            radioButtonSendXml = new System.Windows.Forms.RadioButton();
            radioButtonSendString = new System.Windows.Forms.RadioButton();
            comboBoxPriority = new System.Windows.Forms.ComboBox();
            label39 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            comboBoxSendSemantic = new System.Windows.Forms.ComboBox();
            panelSendBottom = new System.Windows.Forms.Panel();
            buttonLoadMessage = new System.Windows.Forms.Button();
            buttonLoadFile = new System.Windows.Forms.Button();
            buttonLoad = new System.Windows.Forms.Button();
            buttonPublish = new System.Windows.Forms.Button();
            buttonSendClear = new System.Windows.Forms.Button();
            panelSendTop2 = new System.Windows.Forms.Panel();
            textBoxSendDest = new System.Windows.Forms.TextBox();
            labelSendDest = new System.Windows.Forms.Label();
            panelSendTop = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            comboBoxSendTopic = new System.Windows.Forms.ComboBox();
            labelSpacer = new System.Windows.Forms.Label();
            buttonBrowseTopics = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            tabPageReceive = new System.Windows.Forms.TabPage();
            panelReceiveMain = new System.Windows.Forms.Panel();
            hexBoxReceive = new UI.HexBox();
            xmlEditorReceive = new System.Windows.Forms.TextBox();
            linkLabelReceiveCustomProperties = new System.Windows.Forms.LinkLabel();
            label7 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            panelReceiveBottom = new System.Windows.Forms.Panel();
            buttonSaveMessage = new System.Windows.Forms.Button();
            buttonSaveReceivedMessage = new System.Windows.Forms.Button();
            buttonReceiveCopy = new System.Windows.Forms.Button();
            label13 = new System.Windows.Forms.Label();
            comboBoxReceiveSemantic = new System.Windows.Forms.ComboBox();
            buttonReceiveClear = new System.Windows.Forms.Button();
            panelReceiveTop2 = new System.Windows.Forms.Panel();
            textBoxReceiveSource = new System.Windows.Forms.TextBox();
            label57 = new System.Windows.Forms.Label();
            panelReceiveTop = new System.Windows.Forms.Panel();
            label9 = new System.Windows.Forms.Label();
            textBoxReceiveTopic = new System.Windows.Forms.TextBox();
            tabPageHistory = new System.Windows.Forms.TabPage();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            labelEventDetail = new System.Windows.Forms.Label();
            listViewMessageHistory = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            linkLabelCustomPropeties = new System.Windows.Forms.LinkLabel();
            label62 = new System.Windows.Forms.Label();
            listViewMessageHeader = new System.Windows.Forms.ListView();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            hexBox1 = new UI.HexBox();
            xmlEditorBody = new System.Windows.Forms.TextBox();
            label60 = new System.Windows.Forms.Label();
            panelHistoryBottom = new System.Windows.Forms.Panel();
            buttonHistoryClearAll = new System.Windows.Forms.Button();
            buttonHistoryClear = new System.Windows.Forms.Button();
            panelHistoryTop = new System.Windows.Forms.Panel();
            textBoxMessageHistoryCount = new System.Windows.Forms.TextBox();
            label59 = new System.Windows.Forms.Label();
            tabPageDebug = new System.Windows.Forms.TabPage();
            checkBoxDebugPipelineError = new System.Windows.Forms.CheckBox();
            checkBoxDebugSubscriberDisabled = new System.Windows.Forms.CheckBox();
            checkBoxDebugConfigChanged = new System.Windows.Forms.CheckBox();
            label28 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            checkBoxDebugOffline = new System.Windows.Forms.CheckBox();
            checkBoxDebugOnline = new System.Windows.Forms.CheckBox();
            buttonDebugClearAll = new System.Windows.Forms.Button();
            buttonDebugCheckAll = new System.Windows.Forms.Button();
            checkBoxDebugMessageSequenceGap = new System.Windows.Forms.CheckBox();
            checkBoxDebugPipelineEnd = new System.Windows.Forms.CheckBox();
            checkBoxDebugPipelineBegin = new System.Windows.Forms.CheckBox();
            checkBoxDebugMessagePartReceive = new System.Windows.Forms.CheckBox();
            checkBoxDebugReceive = new System.Windows.Forms.CheckBox();
            checkBoxDebugMessagePartSend = new System.Windows.Forms.CheckBox();
            checkBoxDebugSend = new System.Windows.Forms.CheckBox();
            label55 = new System.Windows.Forms.Label();
            label53 = new System.Windows.Forms.Label();
            tabPageTest = new System.Windows.Forms.TabPage();
            label2 = new System.Windows.Forms.Label();
            txtBatchSize = new System.Windows.Forms.TextBox();
            buttonStop = new System.Windows.Forms.Button();
            radioButtonMessageSendTab = new System.Windows.Forms.RadioButton();
            radioButtonMessageTypeNonRepeating = new System.Windows.Forms.RadioButton();
            label22 = new System.Windows.Forms.Label();
            radioButtonMessageTypeRepeating = new System.Windows.Forms.RadioButton();
            label17 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            textBoxSendInterval = new System.Windows.Forms.TextBox();
            label15 = new System.Windows.Forms.Label();
            textBoxSendDelay = new System.Windows.Forms.TextBox();
            buttonTestReset = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            textBoxMessageCount = new System.Windows.Forms.TextBox();
            labelMessageSize = new System.Windows.Forms.Label();
            textBoxMessageSize = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            buttonBulkSend = new System.Windows.Forms.Button();
            tabPageErrors = new System.Windows.Forms.TabPage();
            listBoxErrors = new System.Windows.Forms.ListBox();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            columnHeader5 = new System.Windows.Forms.ColumnHeader();
            columnHeader6 = new System.Windows.Forms.ColumnHeader();
            dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            copyToSendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageConnect.SuspendLayout();
            panelConnectMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubscriptions).BeginInit();
            panelConnectBottom.SuspendLayout();
            panelConnectBottom2.SuspendLayout();
            panelConnectTop.SuspendLayout();
            tabPageSend.SuspendLayout();
            panelSendMain.SuspendLayout();
            panelSendBottom2.SuspendLayout();
            panelSendBottom.SuspendLayout();
            panelSendTop2.SuspendLayout();
            panelSendTop.SuspendLayout();
            panel1.SuspendLayout();
            tabPageReceive.SuspendLayout();
            panelReceiveMain.SuspendLayout();
            panelReceiveBottom.SuspendLayout();
            panelReceiveTop2.SuspendLayout();
            panelReceiveTop.SuspendLayout();
            tabPageHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panelHistoryBottom.SuspendLayout();
            panelHistoryTop.SuspendLayout();
            tabPageDebug.SuspendLayout();
            tabPageTest.SuspendLayout();
            tabPageErrors.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(668, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { clearAllToolStripMenuItem, exitToolStripMenuItem, nongracefulExitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // clearAllToolStripMenuItem
            // 
            clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            clearAllToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            clearAllToolStripMenuItem.Text = "&Clear All";
            clearAllToolStripMenuItem.Click += clearAllToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // nongracefulExitToolStripMenuItem
            // 
            nongracefulExitToolStripMenuItem.Name = "nongracefulExitToolStripMenuItem";
            nongracefulExitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            nongracefulExitToolStripMenuItem.Text = "&Non-graceful exit";
            nongracefulExitToolStripMenuItem.Visible = false;
            nongracefulExitToolStripMenuItem.Click += nongracefulExitToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { viewFullMessageXMLToolStripMenuItem, toolStripMenuItem1, insertTestMessageToolStripMenuItem, toolStripMenuItem2, formatXMLToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            viewToolStripMenuItem.Text = "&Message";
            // 
            // viewFullMessageXMLToolStripMenuItem
            // 
            viewFullMessageXMLToolStripMenuItem.Enabled = false;
            viewFullMessageXMLToolStripMenuItem.Name = "viewFullMessageXMLToolStripMenuItem";
            viewFullMessageXMLToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            viewFullMessageXMLToolStripMenuItem.Text = "&View Full Message XML";
            viewFullMessageXMLToolStripMenuItem.Click += viewFullMessageXMLToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(194, 6);
            // 
            // insertTestMessageToolStripMenuItem
            // 
            insertTestMessageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { insertTestMessageOrderToolStripMenuItem, largePurchaseOrderXSDToolStripMenuItem });
            insertTestMessageToolStripMenuItem.Name = "insertTestMessageToolStripMenuItem";
            insertTestMessageToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            insertTestMessageToolStripMenuItem.Text = "Insert Test Message";
            // 
            // insertTestMessageOrderToolStripMenuItem
            // 
            insertTestMessageOrderToolStripMenuItem.Enabled = false;
            insertTestMessageOrderToolStripMenuItem.Name = "insertTestMessageOrderToolStripMenuItem";
            insertTestMessageOrderToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            insertTestMessageOrderToolStripMenuItem.Text = "Large Purchase Order XML";
            insertTestMessageOrderToolStripMenuItem.Click += insertTestMessageOrderToolStripMenuItem_Click;
            // 
            // largePurchaseOrderXSDToolStripMenuItem
            // 
            largePurchaseOrderXSDToolStripMenuItem.Enabled = false;
            largePurchaseOrderXSDToolStripMenuItem.Name = "largePurchaseOrderXSDToolStripMenuItem";
            largePurchaseOrderXSDToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            largePurchaseOrderXSDToolStripMenuItem.Text = "Large Purchase Order XSD";
            largePurchaseOrderXSDToolStripMenuItem.Click += largePurchaseOrderXSDToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(194, 6);
            // 
            // formatXMLToolStripMenuItem
            // 
            formatXMLToolStripMenuItem.Enabled = false;
            formatXMLToolStripMenuItem.Name = "formatXMLToolStripMenuItem";
            formatXMLToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            formatXMLToolStripMenuItem.Text = "Format XML";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { connectionSettingsToolStripMenuItem, toolStripMenuItem3, updateConfigurationToolStripMenuItem, garbageCollectToolStripMenuItem, msgToXmlToolStripMenuItem, xmlToMsgToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // connectionSettingsToolStripMenuItem
            // 
            connectionSettingsToolStripMenuItem.Name = "connectionSettingsToolStripMenuItem";
            connectionSettingsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            connectionSettingsToolStripMenuItem.Text = "Connection Settings...";
            connectionSettingsToolStripMenuItem.Click += connectionSettingsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size(187, 6);
            // 
            // updateConfigurationToolStripMenuItem
            // 
            updateConfigurationToolStripMenuItem.Name = "updateConfigurationToolStripMenuItem";
            updateConfigurationToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            updateConfigurationToolStripMenuItem.Text = "Update Configuration";
            updateConfigurationToolStripMenuItem.Click += updateConfigurationToolStripMenuItem_Click;
            // 
            // garbageCollectToolStripMenuItem
            // 
            garbageCollectToolStripMenuItem.Name = "garbageCollectToolStripMenuItem";
            garbageCollectToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            garbageCollectToolStripMenuItem.Text = "&Garbage Collect";
            garbageCollectToolStripMenuItem.Visible = false;
            garbageCollectToolStripMenuItem.Click += garbageCollectToolStripMenuItem_Click;
            // 
            // msgToXmlToolStripMenuItem
            // 
            msgToXmlToolStripMenuItem.Name = "msgToXmlToolStripMenuItem";
            msgToXmlToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            msgToXmlToolStripMenuItem.Text = "Msg to Xml";
            msgToXmlToolStripMenuItem.Visible = false;
            msgToXmlToolStripMenuItem.Click += msgToXmlToolStripMenuItem_Click;
            // 
            // xmlToMsgToolStripMenuItem
            // 
            xmlToMsgToolStripMenuItem.Name = "xmlToMsgToolStripMenuItem";
            xmlToMsgToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            xmlToMsgToolStripMenuItem.Text = "Xml to Msg";
            xmlToMsgToolStripMenuItem.Visible = false;
            xmlToMsgToolStripMenuItem.Click += xmlToMsgToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            aboutToolStripMenuItem.Text = "&About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click_1;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusSentCount, statusSentTime, statusSentMsgPerSec, statusRecvCount, statusRecvTime, statusRecvMsgPerSec });
            statusStrip1.Location = new System.Drawing.Point(0, 693);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            statusStrip1.Size = new System.Drawing.Size(668, 22);
            statusStrip1.TabIndex = 24;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusSentCount
            // 
            statusSentCount.Name = "statusSentCount";
            statusSentCount.Size = new System.Drawing.Size(42, 17);
            statusSentCount.Text = "Sent: 0";
            // 
            // statusSentTime
            // 
            statusSentTime.Name = "statusSentTime";
            statusSentTime.Size = new System.Drawing.Size(12, 17);
            statusSentTime.Text = "-";
            // 
            // statusSentMsgPerSec
            // 
            statusSentMsgPerSec.Name = "statusSentMsgPerSec";
            statusSentMsgPerSec.Size = new System.Drawing.Size(12, 17);
            statusSentMsgPerSec.Text = "-";
            // 
            // statusRecvCount
            // 
            statusRecvCount.Name = "statusRecvCount";
            statusRecvCount.Size = new System.Drawing.Size(66, 17);
            statusRecvCount.Text = "Received: 0";
            // 
            // statusRecvTime
            // 
            statusRecvTime.Name = "statusRecvTime";
            statusRecvTime.Size = new System.Drawing.Size(12, 17);
            statusRecvTime.Text = "-";
            // 
            // statusRecvMsgPerSec
            // 
            statusRecvMsgPerSec.Name = "statusRecvMsgPerSec";
            statusRecvMsgPerSec.Size = new System.Drawing.Size(12, 17);
            statusRecvMsgPerSec.Text = "-";
            // 
            // timerStatus
            // 
            timerStatus.Interval = 500;
            timerStatus.Tick += timerStatus_Tick;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageConnect);
            tabControl1.Controls.Add(tabPageSend);
            tabControl1.Controls.Add(tabPageReceive);
            tabControl1.Controls.Add(tabPageHistory);
            tabControl1.Controls.Add(tabPageDebug);
            tabControl1.Controls.Add(tabPageTest);
            tabControl1.Controls.Add(tabPageErrors);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 24);
            tabControl1.Margin = new System.Windows.Forms.Padding(4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(668, 669);
            tabControl1.TabIndex = 37;
            // 
            // tabPageConnect
            // 
            tabPageConnect.Controls.Add(panelConnectMain);
            tabPageConnect.Controls.Add(panelConnectBottom);
            tabPageConnect.Controls.Add(panelConnectBottom2);
            tabPageConnect.Controls.Add(panelConnectTop);
            tabPageConnect.Location = new System.Drawing.Point(4, 22);
            tabPageConnect.Margin = new System.Windows.Forms.Padding(4);
            tabPageConnect.Name = "tabPageConnect";
            tabPageConnect.Size = new System.Drawing.Size(660, 643);
            tabPageConnect.TabIndex = 8;
            tabPageConnect.Text = "Connect";
            tabPageConnect.UseVisualStyleBackColor = true;
            // 
            // panelConnectMain
            // 
            panelConnectMain.Controls.Add(label21);
            panelConnectMain.Controls.Add(dataGridViewSubscriptions);
            panelConnectMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelConnectMain.Location = new System.Drawing.Point(0, 71);
            panelConnectMain.Margin = new System.Windows.Forms.Padding(4);
            panelConnectMain.Name = "panelConnectMain";
            panelConnectMain.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            panelConnectMain.Size = new System.Drawing.Size(660, 484);
            panelConnectMain.TabIndex = 6;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(10, 10);
            label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(70, 13);
            label21.TabIndex = 9;
            label21.Text = "Subscriptions";
            // 
            // dataGridViewSubscriptions
            // 
            dataGridViewSubscriptions.AllowUserToAddRows = false;
            dataGridViewSubscriptions.AllowUserToDeleteRows = false;
            dataGridViewSubscriptions.AllowUserToResizeRows = false;
            dataGridViewSubscriptions.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewSubscriptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ColumnTopic, ColumnDirection, ColumnStatus, ColumnTransport });
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewSubscriptions.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewSubscriptions.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewSubscriptions.GridColor = System.Drawing.SystemColors.Window;
            dataGridViewSubscriptions.Location = new System.Drawing.Point(10, 30);
            dataGridViewSubscriptions.Margin = new System.Windows.Forms.Padding(4);
            dataGridViewSubscriptions.MultiSelect = false;
            dataGridViewSubscriptions.Name = "dataGridViewSubscriptions";
            dataGridViewSubscriptions.ReadOnly = true;
            dataGridViewSubscriptions.RowHeadersVisible = false;
            dataGridViewSubscriptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSubscriptions.ShowEditingIcon = false;
            dataGridViewSubscriptions.Size = new System.Drawing.Size(640, 444);
            dataGridViewSubscriptions.TabIndex = 10;
            // 
            // ColumnTopic
            // 
            ColumnTopic.HeaderText = "Topic";
            ColumnTopic.Name = "ColumnTopic";
            ColumnTopic.ReadOnly = true;
            ColumnTopic.Width = 150;
            // 
            // ColumnDirection
            // 
            ColumnDirection.HeaderText = "Direction";
            ColumnDirection.Name = "ColumnDirection";
            ColumnDirection.ReadOnly = true;
            ColumnDirection.Width = 120;
            // 
            // ColumnStatus
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            ColumnStatus.DefaultCellStyle = dataGridViewCellStyle1;
            ColumnStatus.HeaderText = "Status";
            ColumnStatus.Name = "ColumnStatus";
            ColumnStatus.ReadOnly = true;
            // 
            // ColumnTransport
            // 
            ColumnTransport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            ColumnTransport.HeaderText = "Transport";
            ColumnTransport.Name = "ColumnTransport";
            ColumnTransport.ReadOnly = true;
            // 
            // panelConnectBottom
            // 
            panelConnectBottom.Controls.Add(buttonResume);
            panelConnectBottom.Controls.Add(buttonPause);
            panelConnectBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelConnectBottom.Location = new System.Drawing.Point(0, 555);
            panelConnectBottom.Margin = new System.Windows.Forms.Padding(4);
            panelConnectBottom.Name = "panelConnectBottom";
            panelConnectBottom.Size = new System.Drawing.Size(660, 39);
            panelConnectBottom.TabIndex = 5;
            panelConnectBottom.Visible = false;
            // 
            // buttonResume
            // 
            buttonResume.Enabled = false;
            buttonResume.Location = new System.Drawing.Point(121, 0);
            buttonResume.Margin = new System.Windows.Forms.Padding(4);
            buttonResume.Name = "buttonResume";
            buttonResume.Size = new System.Drawing.Size(94, 29);
            buttonResume.TabIndex = 12;
            buttonResume.Text = "&Resume";
            buttonResume.UseVisualStyleBackColor = true;
            buttonResume.Click += buttonResume_Click;
            // 
            // buttonPause
            // 
            buttonPause.Enabled = false;
            buttonPause.Location = new System.Drawing.Point(20, 0);
            buttonPause.Margin = new System.Windows.Forms.Padding(4);
            buttonPause.Name = "buttonPause";
            buttonPause.Size = new System.Drawing.Size(94, 29);
            buttonPause.TabIndex = 11;
            buttonPause.Text = "&Pause";
            buttonPause.UseVisualStyleBackColor = true;
            buttonPause.Click += buttonPause_Click;
            // 
            // panelConnectBottom2
            // 
            panelConnectBottom2.Controls.Add(labelFilter);
            panelConnectBottom2.Controls.Add(textBoxFilter);
            panelConnectBottom2.Controls.Add(checkBoxFilter);
            panelConnectBottom2.Controls.Add(buttonClearFilter);
            panelConnectBottom2.Controls.Add(buttonSetFilter);
            panelConnectBottom2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelConnectBottom2.Location = new System.Drawing.Point(0, 594);
            panelConnectBottom2.Margin = new System.Windows.Forms.Padding(4);
            panelConnectBottom2.Name = "panelConnectBottom2";
            panelConnectBottom2.Padding = new System.Windows.Forms.Padding(60, 10, 238, 10);
            panelConnectBottom2.Size = new System.Drawing.Size(660, 49);
            panelConnectBottom2.TabIndex = 3;
            panelConnectBottom2.Visible = false;
            // 
            // labelFilter
            // 
            labelFilter.AutoSize = true;
            labelFilter.Location = new System.Drawing.Point(10, 16);
            labelFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelFilter.Name = "labelFilter";
            labelFilter.Size = new System.Drawing.Size(31, 13);
            labelFilter.TabIndex = 13;
            labelFilter.Text = "Filter";
            // 
            // textBoxFilter
            // 
            textBoxFilter.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBoxFilter.Location = new System.Drawing.Point(60, 10);
            textBoxFilter.Margin = new System.Windows.Forms.Padding(4);
            textBoxFilter.Name = "textBoxFilter";
            textBoxFilter.Size = new System.Drawing.Size(268, 23);
            textBoxFilter.TabIndex = 14;
            // 
            // checkBoxFilter
            // 
            checkBoxFilter.AutoSize = true;
            checkBoxFilter.Checked = true;
            checkBoxFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxFilter.Location = new System.Drawing.Point(336, 15);
            checkBoxFilter.Margin = new System.Windows.Forms.Padding(4);
            checkBoxFilter.Name = "checkBoxFilter";
            checkBoxFilter.Size = new System.Drawing.Size(61, 17);
            checkBoxFilter.TabIndex = 15;
            checkBoxFilter.Text = "receive";
            checkBoxFilter.UseVisualStyleBackColor = true;
            // 
            // buttonClearFilter
            // 
            buttonClearFilter.Location = new System.Drawing.Point(489, 10);
            buttonClearFilter.Margin = new System.Windows.Forms.Padding(4);
            buttonClearFilter.Name = "buttonClearFilter";
            buttonClearFilter.Size = new System.Drawing.Size(68, 29);
            buttonClearFilter.TabIndex = 17;
            buttonClearFilter.Text = "Clear";
            buttonClearFilter.UseVisualStyleBackColor = true;
            buttonClearFilter.Click += buttonClearFilter_Click;
            // 
            // buttonSetFilter
            // 
            buttonSetFilter.Location = new System.Drawing.Point(414, 10);
            buttonSetFilter.Margin = new System.Windows.Forms.Padding(4);
            buttonSetFilter.Name = "buttonSetFilter";
            buttonSetFilter.Size = new System.Drawing.Size(68, 29);
            buttonSetFilter.TabIndex = 16;
            buttonSetFilter.Text = "Set";
            buttonSetFilter.UseVisualStyleBackColor = true;
            buttonSetFilter.Click += buttonSetFilter_Click;
            // 
            // panelConnectTop
            // 
            panelConnectTop.Controls.Add(checkBoxBulkTestMode);
            panelConnectTop.Controls.Add(checkBoxTx);
            panelConnectTop.Controls.Add(buttonBrowseSubscribers);
            panelConnectTop.Controls.Add(comboBoxSubscriberId);
            panelConnectTop.Controls.Add(label1);
            panelConnectTop.Controls.Add(buttonDisconnect);
            panelConnectTop.Controls.Add(buttonConnect);
            panelConnectTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelConnectTop.Location = new System.Drawing.Point(0, 0);
            panelConnectTop.Margin = new System.Windows.Forms.Padding(4);
            panelConnectTop.Name = "panelConnectTop";
            panelConnectTop.Padding = new System.Windows.Forms.Padding(110, 10, 10, 10);
            panelConnectTop.Size = new System.Drawing.Size(660, 71);
            panelConnectTop.TabIndex = 0;
            // 
            // checkBoxBulkTestMode
            // 
            checkBoxBulkTestMode.AutoSize = true;
            checkBoxBulkTestMode.Location = new System.Drawing.Point(14, 45);
            checkBoxBulkTestMode.Margin = new System.Windows.Forms.Padding(4);
            checkBoxBulkTestMode.Name = "checkBoxBulkTestMode";
            checkBoxBulkTestMode.Size = new System.Drawing.Size(131, 17);
            checkBoxBulkTestMode.TabIndex = 64;
            checkBoxBulkTestMode.Text = "Run in Bulk Test Mode";
            checkBoxBulkTestMode.UseVisualStyleBackColor = true;
            // 
            // checkBoxTx
            // 
            checkBoxTx.AutoSize = true;
            checkBoxTx.Location = new System.Drawing.Point(548, 45);
            checkBoxTx.Margin = new System.Windows.Forms.Padding(4);
            checkBoxTx.Name = "checkBoxTx";
            checkBoxTx.Size = new System.Drawing.Size(80, 17);
            checkBoxTx.TabIndex = 63;
            checkBoxTx.Text = "Transacted";
            checkBoxTx.UseVisualStyleBackColor = true;
            // 
            // buttonBrowseSubscribers
            // 
            buttonBrowseSubscribers.Location = new System.Drawing.Point(300, 10);
            buttonBrowseSubscribers.Margin = new System.Windows.Forms.Padding(4);
            buttonBrowseSubscribers.Name = "buttonBrowseSubscribers";
            buttonBrowseSubscribers.Size = new System.Drawing.Size(32, 29);
            buttonBrowseSubscribers.TabIndex = 10;
            buttonBrowseSubscribers.Text = "...";
            buttonBrowseSubscribers.UseVisualStyleBackColor = true;
            buttonBrowseSubscribers.Click += buttonBrowseSubscribers_Click;
            // 
            // comboBoxSubscriberId
            // 
            comboBoxSubscriberId.FormattingEnabled = true;
            comboBoxSubscriberId.Location = new System.Drawing.Point(69, 11);
            comboBoxSubscriberId.Margin = new System.Windows.Forms.Padding(4);
            comboBoxSubscriberId.Name = "comboBoxSubscriberId";
            comboBoxSubscriberId.Size = new System.Drawing.Size(223, 21);
            comboBoxSubscriberId.TabIndex = 4;
            comboBoxSubscriberId.DropDown += comboBoxSubscriberId_DropDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 16);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(50, 13);
            label1.TabIndex = 3;
            label1.Text = "Party Id:";
            // 
            // buttonDisconnect
            // 
            buttonDisconnect.Enabled = false;
            buttonDisconnect.Location = new System.Drawing.Point(340, 10);
            buttonDisconnect.Margin = new System.Windows.Forms.Padding(4);
            buttonDisconnect.Name = "buttonDisconnect";
            buttonDisconnect.Size = new System.Drawing.Size(94, 29);
            buttonDisconnect.TabIndex = 6;
            buttonDisconnect.Text = "&Disconnect";
            buttonDisconnect.UseVisualStyleBackColor = true;
            buttonDisconnect.Visible = false;
            buttonDisconnect.Click += buttonDisconnect_Click;
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new System.Drawing.Point(340, 10);
            buttonConnect.Margin = new System.Windows.Forms.Padding(4);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new System.Drawing.Size(94, 29);
            buttonConnect.TabIndex = 5;
            buttonConnect.Text = "&Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // tabPageSend
            // 
            tabPageSend.Controls.Add(panelSendMain);
            tabPageSend.Controls.Add(panelSendBottom2);
            tabPageSend.Controls.Add(panelSendBottom);
            tabPageSend.Controls.Add(panelSendTop2);
            tabPageSend.Controls.Add(panelSendTop);
            tabPageSend.Location = new System.Drawing.Point(4, 24);
            tabPageSend.Margin = new System.Windows.Forms.Padding(4);
            tabPageSend.Name = "tabPageSend";
            tabPageSend.Size = new System.Drawing.Size(660, 641);
            tabPageSend.TabIndex = 9;
            tabPageSend.Text = "Send";
            tabPageSend.UseVisualStyleBackColor = true;
            // 
            // panelSendMain
            // 
            panelSendMain.Controls.Add(xmlEditorSend);
            panelSendMain.Controls.Add(linkLabelSendCustomProperties);
            panelSendMain.Controls.Add(label10);
            panelSendMain.Controls.Add(label8);
            panelSendMain.Controls.Add(hexBox);
            panelSendMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelSendMain.Location = new System.Drawing.Point(0, 82);
            panelSendMain.Margin = new System.Windows.Forms.Padding(4);
            panelSendMain.Name = "panelSendMain";
            panelSendMain.Padding = new System.Windows.Forms.Padding(10, 40, 10, 10);
            panelSendMain.Size = new System.Drawing.Size(660, 355);
            panelSendMain.TabIndex = 4;
            // 
            // xmlEditorSend
            // 
            xmlEditorSend.Location = new System.Drawing.Point(3, 26);
            xmlEditorSend.Multiline = true;
            xmlEditorSend.Name = "xmlEditorSend";
            xmlEditorSend.Size = new System.Drawing.Size(654, 324);
            xmlEditorSend.TabIndex = 41;
            // 
            // linkLabelSendCustomProperties
            // 
            linkLabelSendCustomProperties.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            linkLabelSendCustomProperties.AutoSize = true;
            linkLabelSendCustomProperties.Location = new System.Drawing.Point(503, 10);
            linkLabelSendCustomProperties.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabelSendCustomProperties.Name = "linkLabelSendCustomProperties";
            linkLabelSendCustomProperties.Size = new System.Drawing.Size(116, 13);
            linkLabelSendCustomProperties.TabIndex = 0;
            linkLabelSendCustomProperties.TabStop = true;
            linkLabelSendCustomProperties.Text = "Edit Custom Properties";
            linkLabelSendCustomProperties.LinkClicked += linkLabelSendCustomProperties_LinkClicked;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(10, 10);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(49, 13);
            label10.TabIndex = 38;
            label10.Text = "Message";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(129, 178);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(310, 13);
            label8.TabIndex = 40;
            label8.Text = "Messages larger than 1 MB are not displayed by the test client.";
            // 
            // hexBox
            // 
            hexBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            hexBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            hexBox.InfoForeColor = System.Drawing.Color.Empty;
            hexBox.Location = new System.Drawing.Point(8, 32);
            hexBox.Name = "hexBox";
            hexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(100, 60, 188, 255);
            hexBox.Size = new System.Drawing.Size(405, 129);
            hexBox.StringViewVisible = true;
            hexBox.TabIndex = 39;
            hexBox.UseFixedBytesPerLine = true;
            hexBox.VScrollBarVisible = true;
            hexBox.Resize += hexBox_Resize;
            // 
            // panelSendBottom2
            // 
            panelSendBottom2.Controls.Add(radioButtonSendBinary);
            panelSendBottom2.Controls.Add(comboBoxClassName);
            panelSendBottom2.Controls.Add(buttonAssemblyBrowse);
            panelSendBottom2.Controls.Add(labelObjectClass);
            panelSendBottom2.Controls.Add(labelObjectAssembly);
            panelSendBottom2.Controls.Add(textBoxObjectAssembly);
            panelSendBottom2.Controls.Add(radioButtonSendObject);
            panelSendBottom2.Controls.Add(textBoxSendAction);
            panelSendBottom2.Controls.Add(label20);
            panelSendBottom2.Controls.Add(radioButtonSendXml);
            panelSendBottom2.Controls.Add(radioButtonSendString);
            panelSendBottom2.Controls.Add(comboBoxPriority);
            panelSendBottom2.Controls.Add(label39);
            panelSendBottom2.Controls.Add(label11);
            panelSendBottom2.Controls.Add(comboBoxSendSemantic);
            panelSendBottom2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelSendBottom2.Location = new System.Drawing.Point(0, 437);
            panelSendBottom2.Margin = new System.Windows.Forms.Padding(4);
            panelSendBottom2.Name = "panelSendBottom2";
            panelSendBottom2.Padding = new System.Windows.Forms.Padding(80, 10, 10, 40);
            panelSendBottom2.Size = new System.Drawing.Size(660, 166);
            panelSendBottom2.TabIndex = 2;
            // 
            // radioButtonSendBinary
            // 
            radioButtonSendBinary.AutoSize = true;
            radioButtonSendBinary.Location = new System.Drawing.Point(204, 4);
            radioButtonSendBinary.Margin = new System.Windows.Forms.Padding(4);
            radioButtonSendBinary.Name = "radioButtonSendBinary";
            radioButtonSendBinary.Size = new System.Drawing.Size(82, 17);
            radioButtonSendBinary.TabIndex = 2;
            radioButtonSendBinary.Text = "Send Binary";
            radioButtonSendBinary.UseVisualStyleBackColor = true;
            radioButtonSendBinary.CheckedChanged += radioButtonSendBinary_CheckedChanged;
            // 
            // comboBoxClassName
            // 
            comboBoxClassName.Enabled = false;
            comboBoxClassName.FormattingEnabled = true;
            comboBoxClassName.Location = new System.Drawing.Point(84, 124);
            comboBoxClassName.Margin = new System.Windows.Forms.Padding(4);
            comboBoxClassName.Name = "comboBoxClassName";
            comboBoxClassName.Size = new System.Drawing.Size(559, 21);
            comboBoxClassName.TabIndex = 10;
            // 
            // buttonAssemblyBrowse
            // 
            buttonAssemblyBrowse.Enabled = false;
            buttonAssemblyBrowse.Location = new System.Drawing.Point(606, 88);
            buttonAssemblyBrowse.Margin = new System.Windows.Forms.Padding(4);
            buttonAssemblyBrowse.Name = "buttonAssemblyBrowse";
            buttonAssemblyBrowse.Size = new System.Drawing.Size(38, 29);
            buttonAssemblyBrowse.TabIndex = 9;
            buttonAssemblyBrowse.Text = "...";
            buttonAssemblyBrowse.UseVisualStyleBackColor = true;
            buttonAssemblyBrowse.Click += buttonAssemblyBrowse_Click;
            // 
            // labelObjectClass
            // 
            labelObjectClass.AutoSize = true;
            labelObjectClass.Location = new System.Drawing.Point(14, 128);
            labelObjectClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelObjectClass.Name = "labelObjectClass";
            labelObjectClass.Size = new System.Drawing.Size(36, 13);
            labelObjectClass.TabIndex = 58;
            labelObjectClass.Text = "Class:";
            // 
            // labelObjectAssembly
            // 
            labelObjectAssembly.AutoSize = true;
            labelObjectAssembly.Location = new System.Drawing.Point(10, 91);
            labelObjectAssembly.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelObjectAssembly.Name = "labelObjectAssembly";
            labelObjectAssembly.Size = new System.Drawing.Size(56, 13);
            labelObjectAssembly.TabIndex = 57;
            labelObjectAssembly.Text = "Assembly:";
            // 
            // textBoxObjectAssembly
            // 
            textBoxObjectAssembly.Enabled = false;
            textBoxObjectAssembly.Location = new System.Drawing.Point(84, 90);
            textBoxObjectAssembly.Margin = new System.Windows.Forms.Padding(4);
            textBoxObjectAssembly.Name = "textBoxObjectAssembly";
            textBoxObjectAssembly.Size = new System.Drawing.Size(514, 21);
            textBoxObjectAssembly.TabIndex = 8;
            // 
            // radioButtonSendObject
            // 
            radioButtonSendObject.AutoSize = true;
            radioButtonSendObject.Location = new System.Drawing.Point(204, 64);
            radioButtonSendObject.Margin = new System.Windows.Forms.Padding(4);
            radioButtonSendObject.Name = "radioButtonSendObject";
            radioButtonSendObject.Size = new System.Drawing.Size(84, 17);
            radioButtonSendObject.TabIndex = 4;
            radioButtonSendObject.Text = "Send Object";
            radioButtonSendObject.UseVisualStyleBackColor = true;
            radioButtonSendObject.CheckedChanged += radioButtonSendObject_CheckedChanged;
            // 
            // textBoxSendAction
            // 
            textBoxSendAction.Location = new System.Drawing.Point(376, 8);
            textBoxSendAction.Margin = new System.Windows.Forms.Padding(4);
            textBoxSendAction.Name = "textBoxSendAction";
            textBoxSendAction.Size = new System.Drawing.Size(266, 21);
            textBoxSendAction.TabIndex = 7;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(318, 11);
            label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(37, 13);
            label20.TabIndex = 52;
            label20.Text = "Action";
            // 
            // radioButtonSendXml
            // 
            radioButtonSendXml.AutoSize = true;
            radioButtonSendXml.Location = new System.Drawing.Point(204, 24);
            radioButtonSendXml.Margin = new System.Windows.Forms.Padding(4);
            radioButtonSendXml.Name = "radioButtonSendXml";
            radioButtonSendXml.Size = new System.Drawing.Size(68, 17);
            radioButtonSendXml.TabIndex = 3;
            radioButtonSendXml.Text = "Send Xml";
            radioButtonSendXml.UseVisualStyleBackColor = true;
            // 
            // radioButtonSendString
            // 
            radioButtonSendString.AutoSize = true;
            radioButtonSendString.Checked = true;
            radioButtonSendString.Location = new System.Drawing.Point(204, 44);
            radioButtonSendString.Margin = new System.Windows.Forms.Padding(4);
            radioButtonSendString.Name = "radioButtonSendString";
            radioButtonSendString.Size = new System.Drawing.Size(74, 17);
            radioButtonSendString.TabIndex = 5;
            radioButtonSendString.TabStop = true;
            radioButtonSendString.Text = "Send Text";
            radioButtonSendString.UseVisualStyleBackColor = true;
            // 
            // comboBoxPriority
            // 
            comboBoxPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxPriority.FormattingEnabled = true;
            comboBoxPriority.Items.AddRange(new object[] { "High", "Normal", "Low" });
            comboBoxPriority.Location = new System.Drawing.Point(84, 6);
            comboBoxPriority.Margin = new System.Windows.Forms.Padding(4);
            comboBoxPriority.Name = "comboBoxPriority";
            comboBoxPriority.Size = new System.Drawing.Size(100, 21);
            comboBoxPriority.TabIndex = 0;
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new System.Drawing.Point(10, 11);
            label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label39.Name = "label39";
            label39.Size = new System.Drawing.Size(41, 13);
            label39.TabIndex = 45;
            label39.Text = "Priority";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(10, 45);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(50, 13);
            label11.TabIndex = 44;
            label11.Text = "Semantic";
            // 
            // comboBoxSendSemantic
            // 
            comboBoxSendSemantic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxSendSemantic.FormattingEnabled = true;
            comboBoxSendSemantic.Items.AddRange(new object[] { "Direct", "Multicast", "Request", "Reply" });
            comboBoxSendSemantic.Location = new System.Drawing.Point(84, 40);
            comboBoxSendSemantic.Margin = new System.Windows.Forms.Padding(4);
            comboBoxSendSemantic.Name = "comboBoxSendSemantic";
            comboBoxSendSemantic.Size = new System.Drawing.Size(100, 21);
            comboBoxSendSemantic.TabIndex = 1;
            comboBoxSendSemantic.SelectedIndexChanged += comboBoxSendSemantic_SelectedIndexChanged;
            // 
            // panelSendBottom
            // 
            panelSendBottom.Controls.Add(buttonLoadMessage);
            panelSendBottom.Controls.Add(buttonLoadFile);
            panelSendBottom.Controls.Add(buttonLoad);
            panelSendBottom.Controls.Add(buttonPublish);
            panelSendBottom.Controls.Add(buttonSendClear);
            panelSendBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelSendBottom.Location = new System.Drawing.Point(0, 603);
            panelSendBottom.Margin = new System.Windows.Forms.Padding(4);
            panelSendBottom.Name = "panelSendBottom";
            panelSendBottom.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            panelSendBottom.Size = new System.Drawing.Size(660, 38);
            panelSendBottom.TabIndex = 3;
            // 
            // buttonLoadMessage
            // 
            buttonLoadMessage.Location = new System.Drawing.Point(415, 0);
            buttonLoadMessage.Margin = new System.Windows.Forms.Padding(4);
            buttonLoadMessage.Name = "buttonLoadMessage";
            buttonLoadMessage.Size = new System.Drawing.Size(108, 29);
            buttonLoadMessage.TabIndex = 4;
            buttonLoadMessage.Text = "Load &Message";
            buttonLoadMessage.UseVisualStyleBackColor = true;
            buttonLoadMessage.Click += buttonLoadMessage_Click;
            // 
            // buttonLoadFile
            // 
            buttonLoadFile.Location = new System.Drawing.Point(300, 0);
            buttonLoadFile.Margin = new System.Windows.Forms.Padding(4);
            buttonLoadFile.Name = "buttonLoadFile";
            buttonLoadFile.Size = new System.Drawing.Size(108, 29);
            buttonLoadFile.TabIndex = 3;
            buttonLoadFile.Text = "Load &Body";
            buttonLoadFile.UseVisualStyleBackColor = true;
            buttonLoadFile.Click += buttonLoadFile_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new System.Drawing.Point(186, 0);
            buttonLoad.Margin = new System.Windows.Forms.Padding(4);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new System.Drawing.Size(106, 29);
            buttonLoad.TabIndex = 2;
            buttonLoad.Text = "&Load Object";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonPublish
            // 
            buttonPublish.Enabled = false;
            buttonPublish.Location = new System.Drawing.Point(10, 0);
            buttonPublish.Margin = new System.Windows.Forms.Padding(4);
            buttonPublish.Name = "buttonPublish";
            buttonPublish.Size = new System.Drawing.Size(80, 29);
            buttonPublish.TabIndex = 0;
            buttonPublish.Text = "&Send";
            buttonPublish.UseVisualStyleBackColor = true;
            buttonPublish.Click += buttonPublish_Click;
            // 
            // buttonSendClear
            // 
            buttonSendClear.Location = new System.Drawing.Point(98, 0);
            buttonSendClear.Margin = new System.Windows.Forms.Padding(4);
            buttonSendClear.Name = "buttonSendClear";
            buttonSendClear.Size = new System.Drawing.Size(81, 29);
            buttonSendClear.TabIndex = 1;
            buttonSendClear.Text = "Clea&r";
            buttonSendClear.UseVisualStyleBackColor = true;
            buttonSendClear.Click += buttonSendClear_Click;
            // 
            // panelSendTop2
            // 
            panelSendTop2.Controls.Add(textBoxSendDest);
            panelSendTop2.Controls.Add(labelSendDest);
            panelSendTop2.Dock = System.Windows.Forms.DockStyle.Top;
            panelSendTop2.Location = new System.Drawing.Point(0, 42);
            panelSendTop2.Margin = new System.Windows.Forms.Padding(4);
            panelSendTop2.Name = "panelSendTop2";
            panelSendTop2.Padding = new System.Windows.Forms.Padding(75, 10, 10, 0);
            panelSendTop2.Size = new System.Drawing.Size(660, 40);
            panelSendTop2.TabIndex = 1;
            // 
            // textBoxSendDest
            // 
            textBoxSendDest.Dock = System.Windows.Forms.DockStyle.Fill;
            textBoxSendDest.Enabled = false;
            textBoxSendDest.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBoxSendDest.Location = new System.Drawing.Point(75, 10);
            textBoxSendDest.Margin = new System.Windows.Forms.Padding(4);
            textBoxSendDest.Name = "textBoxSendDest";
            textBoxSendDest.Size = new System.Drawing.Size(575, 23);
            textBoxSendDest.TabIndex = 0;
            // 
            // labelSendDest
            // 
            labelSendDest.AutoSize = true;
            labelSendDest.Location = new System.Drawing.Point(10, 14);
            labelSendDest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSendDest.Name = "labelSendDest";
            labelSendDest.Size = new System.Drawing.Size(19, 13);
            labelSendDest.TabIndex = 41;
            labelSendDest.Text = "To";
            // 
            // panelSendTop
            // 
            panelSendTop.Controls.Add(panel1);
            panelSendTop.Controls.Add(label5);
            panelSendTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelSendTop.Location = new System.Drawing.Point(0, 0);
            panelSendTop.Margin = new System.Windows.Forms.Padding(4);
            panelSendTop.Name = "panelSendTop";
            panelSendTop.Padding = new System.Windows.Forms.Padding(75, 10, 10, 0);
            panelSendTop.Size = new System.Drawing.Size(660, 42);
            panelSendTop.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(comboBoxSendTopic);
            panel1.Controls.Add(labelSpacer);
            panel1.Controls.Add(buttonBrowseTopics);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(75, 10);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(575, 32);
            panel1.TabIndex = 38;
            // 
            // comboBoxSendTopic
            // 
            comboBoxSendTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            comboBoxSendTopic.Enabled = false;
            comboBoxSendTopic.FormattingEnabled = true;
            comboBoxSendTopic.Location = new System.Drawing.Point(0, 0);
            comboBoxSendTopic.Margin = new System.Windows.Forms.Padding(4);
            comboBoxSendTopic.Name = "comboBoxSendTopic";
            comboBoxSendTopic.Size = new System.Drawing.Size(533, 21);
            comboBoxSendTopic.TabIndex = 0;
            // 
            // labelSpacer
            // 
            labelSpacer.Dock = System.Windows.Forms.DockStyle.Right;
            labelSpacer.Location = new System.Drawing.Point(533, 0);
            labelSpacer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSpacer.Name = "labelSpacer";
            labelSpacer.Size = new System.Drawing.Size(10, 32);
            labelSpacer.TabIndex = 1;
            // 
            // buttonBrowseTopics
            // 
            buttonBrowseTopics.Dock = System.Windows.Forms.DockStyle.Right;
            buttonBrowseTopics.Location = new System.Drawing.Point(543, 0);
            buttonBrowseTopics.Margin = new System.Windows.Forms.Padding(4);
            buttonBrowseTopics.Name = "buttonBrowseTopics";
            buttonBrowseTopics.Size = new System.Drawing.Size(32, 32);
            buttonBrowseTopics.TabIndex = 44;
            buttonBrowseTopics.Text = "...";
            buttonBrowseTopics.UseVisualStyleBackColor = true;
            buttonBrowseTopics.Visible = false;
            buttonBrowseTopics.Click += buttonBrowseTopics_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(10, 16);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(32, 13);
            label5.TabIndex = 37;
            label5.Text = "Topic";
            // 
            // tabPageReceive
            // 
            tabPageReceive.Controls.Add(panelReceiveMain);
            tabPageReceive.Controls.Add(panelReceiveBottom);
            tabPageReceive.Controls.Add(panelReceiveTop2);
            tabPageReceive.Controls.Add(panelReceiveTop);
            tabPageReceive.Location = new System.Drawing.Point(4, 24);
            tabPageReceive.Margin = new System.Windows.Forms.Padding(4);
            tabPageReceive.Name = "tabPageReceive";
            tabPageReceive.Size = new System.Drawing.Size(660, 641);
            tabPageReceive.TabIndex = 10;
            tabPageReceive.Text = "Receive";
            tabPageReceive.UseVisualStyleBackColor = true;
            // 
            // panelReceiveMain
            // 
            panelReceiveMain.Controls.Add(hexBoxReceive);
            panelReceiveMain.Controls.Add(xmlEditorReceive);
            panelReceiveMain.Controls.Add(linkLabelReceiveCustomProperties);
            panelReceiveMain.Controls.Add(label7);
            panelReceiveMain.Controls.Add(label4);
            panelReceiveMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelReceiveMain.Location = new System.Drawing.Point(0, 93);
            panelReceiveMain.Margin = new System.Windows.Forms.Padding(4);
            panelReceiveMain.Name = "panelReceiveMain";
            panelReceiveMain.Padding = new System.Windows.Forms.Padding(10, 40, 10, 10);
            panelReceiveMain.Size = new System.Drawing.Size(660, 500);
            panelReceiveMain.TabIndex = 3;
            // 
            // hexBoxReceive
            // 
            hexBoxReceive.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            hexBoxReceive.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            hexBoxReceive.InfoForeColor = System.Drawing.Color.Empty;
            hexBoxReceive.Location = new System.Drawing.Point(8, 26);
            hexBoxReceive.Name = "hexBoxReceive";
            hexBoxReceive.ShadowSelectionColor = System.Drawing.Color.FromArgb(100, 60, 188, 255);
            hexBoxReceive.Size = new System.Drawing.Size(649, 467);
            hexBoxReceive.StringViewVisible = true;
            hexBoxReceive.TabIndex = 40;
            hexBoxReceive.UseFixedBytesPerLine = true;
            hexBoxReceive.Visible = false;
            hexBoxReceive.VScrollBarVisible = true;
            hexBoxReceive.Resize += hexBoxReceive_Resize;
            // 
            // xmlEditorReceive
            // 
            xmlEditorReceive.Location = new System.Drawing.Point(3, 26);
            xmlEditorReceive.Multiline = true;
            xmlEditorReceive.Name = "xmlEditorReceive";
            xmlEditorReceive.Size = new System.Drawing.Size(654, 469);
            xmlEditorReceive.TabIndex = 42;
            // 
            // linkLabelReceiveCustomProperties
            // 
            linkLabelReceiveCustomProperties.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            linkLabelReceiveCustomProperties.AutoSize = true;
            linkLabelReceiveCustomProperties.Location = new System.Drawing.Point(502, 10);
            linkLabelReceiveCustomProperties.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabelReceiveCustomProperties.Name = "linkLabelReceiveCustomProperties";
            linkLabelReceiveCustomProperties.Size = new System.Drawing.Size(120, 13);
            linkLabelReceiveCustomProperties.TabIndex = 0;
            linkLabelReceiveCustomProperties.TabStop = true;
            linkLabelReceiveCustomProperties.Text = "View Custom Properties";
            linkLabelReceiveCustomProperties.LinkClicked += linkLabelReceiveCustomProperties_LinkClicked;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(10, 10);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(49, 13);
            label7.TabIndex = 39;
            label7.Text = "Message";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(161, 232);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(310, 13);
            label4.TabIndex = 41;
            label4.Text = "Messages larger than 1 MB are not displayed by the test client.";
            // 
            // panelReceiveBottom
            // 
            panelReceiveBottom.Controls.Add(buttonSaveMessage);
            panelReceiveBottom.Controls.Add(buttonSaveReceivedMessage);
            panelReceiveBottom.Controls.Add(buttonReceiveCopy);
            panelReceiveBottom.Controls.Add(label13);
            panelReceiveBottom.Controls.Add(comboBoxReceiveSemantic);
            panelReceiveBottom.Controls.Add(buttonReceiveClear);
            panelReceiveBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelReceiveBottom.Location = new System.Drawing.Point(0, 593);
            panelReceiveBottom.Margin = new System.Windows.Forms.Padding(4);
            panelReceiveBottom.Name = "panelReceiveBottom";
            panelReceiveBottom.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            panelReceiveBottom.Size = new System.Drawing.Size(660, 48);
            panelReceiveBottom.TabIndex = 2;
            // 
            // buttonSaveMessage
            // 
            buttonSaveMessage.Location = new System.Drawing.Point(316, 10);
            buttonSaveMessage.Margin = new System.Windows.Forms.Padding(4);
            buttonSaveMessage.Name = "buttonSaveMessage";
            buttonSaveMessage.Size = new System.Drawing.Size(115, 29);
            buttonSaveMessage.TabIndex = 46;
            buttonSaveMessage.Text = "Save Message";
            buttonSaveMessage.UseVisualStyleBackColor = true;
            buttonSaveMessage.Click += buttonSaveMessage_Click;
            // 
            // buttonSaveReceivedMessage
            // 
            buttonSaveReceivedMessage.Location = new System.Drawing.Point(215, 10);
            buttonSaveReceivedMessage.Margin = new System.Windows.Forms.Padding(4);
            buttonSaveReceivedMessage.Name = "buttonSaveReceivedMessage";
            buttonSaveReceivedMessage.Size = new System.Drawing.Size(94, 29);
            buttonSaveReceivedMessage.TabIndex = 2;
            buttonSaveReceivedMessage.Text = "Save Body";
            buttonSaveReceivedMessage.UseVisualStyleBackColor = true;
            buttonSaveReceivedMessage.Click += buttonSaveReceivedMessage_Click;
            // 
            // buttonReceiveCopy
            // 
            buttonReceiveCopy.Location = new System.Drawing.Point(114, 10);
            buttonReceiveCopy.Margin = new System.Windows.Forms.Padding(4);
            buttonReceiveCopy.Name = "buttonReceiveCopy";
            buttonReceiveCopy.Size = new System.Drawing.Size(94, 29);
            buttonReceiveCopy.TabIndex = 1;
            buttonReceiveCopy.Text = "Copy";
            buttonReceiveCopy.UseVisualStyleBackColor = true;
            buttonReceiveCopy.Click += buttonReceiveCopy_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(475, 16);
            label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(50, 13);
            label13.TabIndex = 45;
            label13.Text = "Semantic";
            label13.Visible = false;
            // 
            // comboBoxReceiveSemantic
            // 
            comboBoxReceiveSemantic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxReceiveSemantic.Enabled = false;
            comboBoxReceiveSemantic.FormattingEnabled = true;
            comboBoxReceiveSemantic.Items.AddRange(new object[] { "Direct", "Multicast", "Queued", "Request", "Reply" });
            comboBoxReceiveSemantic.Location = new System.Drawing.Point(546, 12);
            comboBoxReceiveSemantic.Margin = new System.Windows.Forms.Padding(4);
            comboBoxReceiveSemantic.Name = "comboBoxReceiveSemantic";
            comboBoxReceiveSemantic.Size = new System.Drawing.Size(100, 21);
            comboBoxReceiveSemantic.TabIndex = 3;
            comboBoxReceiveSemantic.Visible = false;
            // 
            // buttonReceiveClear
            // 
            buttonReceiveClear.Location = new System.Drawing.Point(14, 10);
            buttonReceiveClear.Margin = new System.Windows.Forms.Padding(4);
            buttonReceiveClear.Name = "buttonReceiveClear";
            buttonReceiveClear.Size = new System.Drawing.Size(94, 29);
            buttonReceiveClear.TabIndex = 0;
            buttonReceiveClear.Text = "Clear";
            buttonReceiveClear.UseVisualStyleBackColor = true;
            buttonReceiveClear.Click += buttonReceiveClear_Click;
            // 
            // panelReceiveTop2
            // 
            panelReceiveTop2.Controls.Add(textBoxReceiveSource);
            panelReceiveTop2.Controls.Add(label57);
            panelReceiveTop2.Dock = System.Windows.Forms.DockStyle.Top;
            panelReceiveTop2.Location = new System.Drawing.Point(0, 42);
            panelReceiveTop2.Margin = new System.Windows.Forms.Padding(4);
            panelReceiveTop2.Name = "panelReceiveTop2";
            panelReceiveTop2.Padding = new System.Windows.Forms.Padding(75, 10, 10, 0);
            panelReceiveTop2.Size = new System.Drawing.Size(660, 51);
            panelReceiveTop2.TabIndex = 1;
            // 
            // textBoxReceiveSource
            // 
            textBoxReceiveSource.Dock = System.Windows.Forms.DockStyle.Fill;
            textBoxReceiveSource.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBoxReceiveSource.Location = new System.Drawing.Point(75, 10);
            textBoxReceiveSource.Margin = new System.Windows.Forms.Padding(4);
            textBoxReceiveSource.Name = "textBoxReceiveSource";
            textBoxReceiveSource.ReadOnly = true;
            textBoxReceiveSource.Size = new System.Drawing.Size(575, 23);
            textBoxReceiveSource.TabIndex = 0;
            // 
            // label57
            // 
            label57.AutoSize = true;
            label57.Location = new System.Drawing.Point(10, 14);
            label57.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label57.Name = "label57";
            label57.Size = new System.Drawing.Size(31, 13);
            label57.TabIndex = 22;
            label57.Text = "From";
            // 
            // panelReceiveTop
            // 
            panelReceiveTop.Controls.Add(label9);
            panelReceiveTop.Controls.Add(textBoxReceiveTopic);
            panelReceiveTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelReceiveTop.Location = new System.Drawing.Point(0, 0);
            panelReceiveTop.Margin = new System.Windows.Forms.Padding(4);
            panelReceiveTop.Name = "panelReceiveTop";
            panelReceiveTop.Padding = new System.Windows.Forms.Padding(75, 10, 10, 0);
            panelReceiveTop.Size = new System.Drawing.Size(660, 42);
            panelReceiveTop.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(10, 16);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(32, 13);
            label9.TabIndex = 22;
            label9.Text = "Topic";
            // 
            // textBoxReceiveTopic
            // 
            textBoxReceiveTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            textBoxReceiveTopic.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            textBoxReceiveTopic.Location = new System.Drawing.Point(75, 10);
            textBoxReceiveTopic.Margin = new System.Windows.Forms.Padding(4);
            textBoxReceiveTopic.Name = "textBoxReceiveTopic";
            textBoxReceiveTopic.Size = new System.Drawing.Size(575, 23);
            textBoxReceiveTopic.TabIndex = 0;
            // 
            // tabPageHistory
            // 
            tabPageHistory.Controls.Add(splitContainer1);
            tabPageHistory.Controls.Add(panelHistoryBottom);
            tabPageHistory.Controls.Add(panelHistoryTop);
            tabPageHistory.Location = new System.Drawing.Point(4, 22);
            tabPageHistory.Margin = new System.Windows.Forms.Padding(4);
            tabPageHistory.Name = "tabPageHistory";
            tabPageHistory.Size = new System.Drawing.Size(660, 643);
            tabPageHistory.TabIndex = 11;
            tabPageHistory.Text = "Message History";
            tabPageHistory.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 50);
            splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(labelEventDetail);
            splitContainer1.Panel1.Controls.Add(listViewMessageHistory);
            splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new System.Drawing.Size(660, 555);
            splitContainer1.SplitterDistance = 217;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 2;
            // 
            // labelEventDetail
            // 
            labelEventDetail.AutoSize = true;
            labelEventDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelEventDetail.Location = new System.Drawing.Point(10, 10);
            labelEventDetail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelEventDetail.Name = "labelEventDetail";
            labelEventDetail.Size = new System.Drawing.Size(46, 13);
            labelEventDetail.TabIndex = 10;
            labelEventDetail.Text = "History";
            // 
            // listViewMessageHistory
            // 
            listViewMessageHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewMessageHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewMessageHistory.FullRowSelect = true;
            listViewMessageHistory.GridLines = true;
            listViewMessageHistory.Location = new System.Drawing.Point(10, 30);
            listViewMessageHistory.Margin = new System.Windows.Forms.Padding(4);
            listViewMessageHistory.MultiSelect = false;
            listViewMessageHistory.Name = "listViewMessageHistory";
            listViewMessageHistory.Size = new System.Drawing.Size(197, 515);
            listViewMessageHistory.TabIndex = 0;
            listViewMessageHistory.UseCompatibleStateImageBehavior = false;
            listViewMessageHistory.View = System.Windows.Forms.View.Details;
            listViewMessageHistory.SelectedIndexChanged += listViewMessageHistory_SelectedIndexChanged;
            listViewMessageHistory.MouseClick += listViewMessageHistory_MouseClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Action";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Message Id";
            columnHeader2.Width = 180;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer2.Location = new System.Drawing.Point(0, 0);
            splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(linkLabelCustomPropeties);
            splitContainer2.Panel1.Controls.Add(label62);
            splitContainer2.Panel1.Controls.Add(listViewMessageHeader);
            splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(hexBox1);
            splitContainer2.Panel2.Controls.Add(xmlEditorBody);
            splitContainer2.Panel2.Controls.Add(label60);
            splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            splitContainer2.Size = new System.Drawing.Size(438, 555);
            splitContainer2.SplitterDistance = 234;
            splitContainer2.SplitterWidth = 5;
            splitContainer2.TabIndex = 0;
            // 
            // linkLabelCustomPropeties
            // 
            linkLabelCustomPropeties.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            linkLabelCustomPropeties.AutoSize = true;
            linkLabelCustomPropeties.Location = new System.Drawing.Point(277, 10);
            linkLabelCustomPropeties.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabelCustomPropeties.Name = "linkLabelCustomPropeties";
            linkLabelCustomPropeties.Size = new System.Drawing.Size(120, 13);
            linkLabelCustomPropeties.TabIndex = 0;
            linkLabelCustomPropeties.TabStop = true;
            linkLabelCustomPropeties.Text = "View Custom Properties";
            linkLabelCustomPropeties.LinkClicked += linkLabelCustomPropeties_LinkClicked;
            // 
            // label62
            // 
            label62.AutoSize = true;
            label62.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label62.Location = new System.Drawing.Point(10, 10);
            label62.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label62.Name = "label62";
            label62.Size = new System.Drawing.Size(102, 13);
            label62.TabIndex = 17;
            label62.Text = "Message Header";
            // 
            // listViewMessageHeader
            // 
            listViewMessageHeader.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader3, columnHeader4 });
            listViewMessageHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewMessageHeader.FullRowSelect = true;
            listViewMessageHeader.GridLines = true;
            listViewMessageHeader.Location = new System.Drawing.Point(10, 30);
            listViewMessageHeader.Margin = new System.Windows.Forms.Padding(4);
            listViewMessageHeader.MultiSelect = false;
            listViewMessageHeader.Name = "listViewMessageHeader";
            listViewMessageHeader.Size = new System.Drawing.Size(418, 194);
            listViewMessageHeader.TabIndex = 1;
            listViewMessageHeader.UseCompatibleStateImageBehavior = false;
            listViewMessageHeader.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Property";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Value";
            columnHeader4.Width = 160;
            // 
            // hexBox1
            // 
            hexBox1.BytesPerLine = 9;
            hexBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            hexBox1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            hexBox1.InfoForeColor = System.Drawing.Color.Empty;
            hexBox1.Location = new System.Drawing.Point(10, 30);
            hexBox1.Name = "hexBox1";
            hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(100, 60, 188, 255);
            hexBox1.Size = new System.Drawing.Size(418, 276);
            hexBox1.StringViewVisible = true;
            hexBox1.TabIndex = 41;
            hexBox1.UseFixedBytesPerLine = true;
            hexBox1.Visible = false;
            hexBox1.VScrollBarVisible = true;
            hexBox1.Click += hexBox1_Click;
            // 
            // xmlEditorBody
            // 
            xmlEditorBody.Location = new System.Drawing.Point(10, 26);
            xmlEditorBody.Multiline = true;
            xmlEditorBody.Name = "xmlEditorBody";
            xmlEditorBody.Size = new System.Drawing.Size(420, 277);
            xmlEditorBody.TabIndex = 1;
            // 
            // label60
            // 
            label60.AutoSize = true;
            label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label60.Location = new System.Drawing.Point(10, 10);
            label60.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label60.Name = "label60";
            label60.Size = new System.Drawing.Size(89, 13);
            label60.TabIndex = 0;
            label60.Text = "Message Body";
            // 
            // panelHistoryBottom
            // 
            panelHistoryBottom.Controls.Add(buttonHistoryClearAll);
            panelHistoryBottom.Controls.Add(buttonHistoryClear);
            panelHistoryBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelHistoryBottom.Location = new System.Drawing.Point(0, 605);
            panelHistoryBottom.Margin = new System.Windows.Forms.Padding(4);
            panelHistoryBottom.Name = "panelHistoryBottom";
            panelHistoryBottom.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            panelHistoryBottom.Size = new System.Drawing.Size(660, 38);
            panelHistoryBottom.TabIndex = 1;
            // 
            // buttonHistoryClearAll
            // 
            buttonHistoryClearAll.Enabled = false;
            buttonHistoryClearAll.Location = new System.Drawing.Point(99, 0);
            buttonHistoryClearAll.Margin = new System.Windows.Forms.Padding(4);
            buttonHistoryClearAll.Name = "buttonHistoryClearAll";
            buttonHistoryClearAll.Size = new System.Drawing.Size(81, 29);
            buttonHistoryClearAll.TabIndex = 2;
            buttonHistoryClearAll.Text = "Clear &All";
            buttonHistoryClearAll.UseVisualStyleBackColor = true;
            buttonHistoryClearAll.Click += buttonHistoryClearAll_Click;
            // 
            // buttonHistoryClear
            // 
            buttonHistoryClear.Enabled = false;
            buttonHistoryClear.Location = new System.Drawing.Point(10, 0);
            buttonHistoryClear.Margin = new System.Windows.Forms.Padding(4);
            buttonHistoryClear.Name = "buttonHistoryClear";
            buttonHistoryClear.Size = new System.Drawing.Size(81, 29);
            buttonHistoryClear.TabIndex = 1;
            buttonHistoryClear.Text = "Clea&r";
            buttonHistoryClear.UseVisualStyleBackColor = true;
            buttonHistoryClear.Click += buttonHistoryClear_Click;
            // 
            // panelHistoryTop
            // 
            panelHistoryTop.Controls.Add(textBoxMessageHistoryCount);
            panelHistoryTop.Controls.Add(label59);
            panelHistoryTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelHistoryTop.Location = new System.Drawing.Point(0, 0);
            panelHistoryTop.Margin = new System.Windows.Forms.Padding(4);
            panelHistoryTop.Name = "panelHistoryTop";
            panelHistoryTop.Padding = new System.Windows.Forms.Padding(75, 10, 10, 0);
            panelHistoryTop.Size = new System.Drawing.Size(660, 50);
            panelHistoryTop.TabIndex = 0;
            // 
            // textBoxMessageHistoryCount
            // 
            textBoxMessageHistoryCount.Location = new System.Drawing.Point(256, 11);
            textBoxMessageHistoryCount.Margin = new System.Windows.Forms.Padding(4);
            textBoxMessageHistoryCount.Name = "textBoxMessageHistoryCount";
            textBoxMessageHistoryCount.Size = new System.Drawing.Size(70, 21);
            textBoxMessageHistoryCount.TabIndex = 0;
            textBoxMessageHistoryCount.Text = "10";
            textBoxMessageHistoryCount.TextChanged += textBoxMessageHistoryCount_TextChanged;
            textBoxMessageHistoryCount.KeyPress += MaskInteger;
            // 
            // label59
            // 
            label59.AutoSize = true;
            label59.Location = new System.Drawing.Point(6, 15);
            label59.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label59.Name = "label59";
            label59.Size = new System.Drawing.Size(200, 13);
            label59.TabIndex = 4;
            label59.Text = "Number of messages to store in memory";
            // 
            // tabPageDebug
            // 
            tabPageDebug.Controls.Add(checkBoxDebugPipelineError);
            tabPageDebug.Controls.Add(checkBoxDebugSubscriberDisabled);
            tabPageDebug.Controls.Add(checkBoxDebugConfigChanged);
            tabPageDebug.Controls.Add(label28);
            tabPageDebug.Controls.Add(label26);
            tabPageDebug.Controls.Add(label25);
            tabPageDebug.Controls.Add(label24);
            tabPageDebug.Controls.Add(checkBoxDebugOffline);
            tabPageDebug.Controls.Add(checkBoxDebugOnline);
            tabPageDebug.Controls.Add(buttonDebugClearAll);
            tabPageDebug.Controls.Add(buttonDebugCheckAll);
            tabPageDebug.Controls.Add(checkBoxDebugMessageSequenceGap);
            tabPageDebug.Controls.Add(checkBoxDebugPipelineEnd);
            tabPageDebug.Controls.Add(checkBoxDebugPipelineBegin);
            tabPageDebug.Controls.Add(checkBoxDebugMessagePartReceive);
            tabPageDebug.Controls.Add(checkBoxDebugReceive);
            tabPageDebug.Controls.Add(checkBoxDebugMessagePartSend);
            tabPageDebug.Controls.Add(checkBoxDebugSend);
            tabPageDebug.Controls.Add(label55);
            tabPageDebug.Controls.Add(label53);
            tabPageDebug.Location = new System.Drawing.Point(4, 24);
            tabPageDebug.Margin = new System.Windows.Forms.Padding(4);
            tabPageDebug.Name = "tabPageDebug";
            tabPageDebug.Size = new System.Drawing.Size(660, 641);
            tabPageDebug.TabIndex = 7;
            tabPageDebug.Text = "Debug";
            tabPageDebug.UseVisualStyleBackColor = true;
            // 
            // checkBoxDebugPipelineError
            // 
            checkBoxDebugPipelineError.AutoSize = true;
            checkBoxDebugPipelineError.Location = new System.Drawing.Point(124, 226);
            checkBoxDebugPipelineError.Margin = new System.Windows.Forms.Padding(4);
            checkBoxDebugPipelineError.Name = "checkBoxDebugPipelineError";
            checkBoxDebugPipelineError.Size = new System.Drawing.Size(101, 17);
            checkBoxDebugPipelineError.TabIndex = 9;
            checkBoxDebugPipelineError.Text = "OnProcessError";
            checkBoxDebugPipelineError.UseVisualStyleBackColor = true;
            // 
            // checkBoxDebugSubscriberDisabled
            // 
            checkBoxDebugSubscriberDisabled.AutoSize = true;
            checkBoxDebugSubscriberDisabled.Location = new System.Drawing.Point(329, 268);
            checkBoxDebugSubscriberDisabled.Margin = new System.Windows.Forms.Padding(4);
            checkBoxDebugSubscriberDisabled.Name = "checkBoxDebugSubscriberDisabled";
            checkBoxDebugSubscriberDisabled.Size = new System.Drawing.Size(130, 17);
            checkBoxDebugSubscriberDisabled.TabIndex = 11;
            checkBoxDebugSubscriberDisabled.Text = "OnSubscriberDisabled";
            checkBoxDebugSubscriberDisabled.UseVisualStyleBackColor = true;
            // 
            // checkBoxDebugConfigChanged
            // 
            checkBoxDebugConfigChanged.AutoSize = true;
            checkBoxDebugConfigChanged.Location = new System.Drawing.Point(124, 266);
            checkBoxDebugConfigChanged.Margin = new System.Windows.Forms.Padding(4);
            checkBoxDebugConfigChanged.Name = "checkBoxDebugConfigChanged";
            checkBoxDebugConfigChanged.Size = new System.Drawing.Size(148, 17);
            checkBoxDebugConfigChanged.TabIndex = 10;
            checkBoxDebugConfigChanged.Text = "OnConfigurationChanged";
            checkBoxDebugConfigChanged.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new System.Drawing.Point(10, 268);
            label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(72, 13);
            label28.TabIndex = 37;
            label28.Text = "Configuration";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(10, 198);
            label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(55, 13);
            label26.TabIndex = 16;
            label26.Text = "Processes";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new System.Drawing.Point(10, 100);
            label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(73, 13);
            label25.TabIndex = 5;
            label25.Text = "Send/Receive";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new System.Drawing.Point(10, 62);
            label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(61, 13);
            label24.TabIndex = 2;
            label24.Text = "Connection";
            // 
            // checkBoxDebugOffline
            // 
            checkBoxDebugOffline.AutoSize = true;
            checkBoxDebugOffline.Location = new System.Drawing.Point(330, 62);
            checkBoxDebugOffline.Margin = new System.Windows.Forms.Padding(4);
            checkBoxDebugOffline.Name = "checkBoxDebugOffline";
            checkBoxDebugOffline.Size = new System.Drawing.Size(72, 17);
            checkBoxDebugOffline.TabIndex = 1;
            checkBoxDebugOffline.Text = "OnOffline";
            checkBoxDebugOffline.UseVisualStyleBackColor = true;
            // 
            // checkBoxDebugOnline
            // 
            checkBoxDebugOnline.AutoSize = true;
            checkBoxDebugOnline.Location = new System.Drawing.Point(124, 62);
            checkBoxDebugOnline.Margin = new System.Windows.Forms.Padding(4);
            checkBoxDebugOnline.Name = "checkBoxDebugOnline";
            checkBoxDebugOnline.Size = new System.Drawing.Size(70, 17);
            checkBoxDebugOnline.TabIndex = 0;
            checkBoxDebugOnline.Text = "OnOnline";
            checkBoxDebugOnline.UseVisualStyleBackColor = true;
            // 
            // buttonDebugClearAll
            // 
            buttonDebugClearAll.Location = new System.Drawing.Point(111, 581);
            buttonDebugClearAll.Margin = new System.Windows.Forms.Padding(4);
            buttonDebugClearAll.Name = "buttonDebugClearAll";
            buttonDebugClearAll.Size = new System.Drawing.Size(94, 29);
            buttonDebugClearAll.TabIndex = 13;
            buttonDebugClearAll.Text = "C&lear All";
            buttonDebugClearAll.UseVisualStyleBackColor = true;
            buttonDebugClearAll.Click += buttonDebugClearAll_Click;
            // 
            // buttonDebugCheckAll
            // 
            buttonDebugCheckAll.Location = new System.Drawing.Point(10, 581);
            buttonDebugCheckAll.Margin = new System.Windows.Forms.Padding(4);
            buttonDebugCheckAll.Name = "buttonDebugCheckAll";
            buttonDebugCheckAll.Size = new System.Drawing.Size(94, 29);
            buttonDebugCheckAll.TabIndex = 12;
            buttonDebugCheckAll.Text = "&Select All";
            buttonDebugCheckAll.UseVisualStyleBackColor = true;
            buttonDebugCheckAll.Click += buttonDebugCheckAll_Click;
            // 
            // checkBoxDebugMessageSequenceGap
            // 
            checkBoxDebugMessageSequenceGap.AutoSize = true;
            checkBoxDebugMessageSequenceGap.Location = new System.Drawing.Point(124, 155);
            checkBoxDebugMessageSequenceGap.Margin = new System.Windows.Forms.Padding(4);
            checkBoxDebugMessageSequenceGap.Name = "checkBoxDebugMessageSequenceGap";
            checkBoxDebugMessageSequenceGap.Size = new System.Drawing.Size(148, 17);
            checkBoxDebugMessageSequenceGap.TabIndex = 6;
            checkBoxDebugMessageSequenceGap.Text = "OnMessageSequenceGap";
            checkBoxDebugMessageSequenceGap.UseVisualStyleBackColor = true;
            // 
            // checkBoxDebugPipelineEnd
            // 
            checkBoxDebugPipelineEnd.AutoSize = true;
            checkBoxDebugPipelineEnd.Location = new System.Drawing.Point(330, 198);
            checkBoxDebugPipelineEnd.Margin = new System.Windows.Forms.Padding(4);
            checkBoxDebugPipelineEnd.Name = "checkBoxDebugPipelineEnd";
            checkBoxDebugPipelineEnd.Size = new System.Drawing.Size(95, 17);
            checkBoxDebugPipelineEnd.TabIndex = 8;
            checkBoxDebugPipelineEnd.Text = "OnProcessEnd";
            checkBoxDebugPipelineEnd.UseVisualStyleBackColor = true;
            // 
            // checkBoxDebugPipelineBegin
            // 
            checkBoxDebugPipelineBegin.AutoSize = true;
            checkBoxDebugPipelineBegin.Location = new System.Drawing.Point(124, 198);
            checkBoxDebugPipelineBegin.Margin = new System.Windows.Forms.Padding(4);
            checkBoxDebugPipelineBegin.Name = "checkBoxDebugPipelineBegin";
            checkBoxDebugPipelineBegin.Size = new System.Drawing.Size(103, 17);
            checkBoxDebugPipelineBegin.TabIndex = 7;
            checkBoxDebugPipelineBegin.Text = "OnProcessBegin";
            checkBoxDebugPipelineBegin.UseVisualStyleBackColor = true;
            // 
            // checkBoxDebugMessagePartReceive
            // 
            checkBoxDebugMessagePartReceive.AutoSize = true;
            checkBoxDebugMessagePartReceive.Location = new System.Drawing.Point(330, 128);
            checkBoxDebugMessagePartReceive.Margin = new System.Windows.Forms.Padding(4);
            checkBoxDebugMessagePartReceive.Name = "checkBoxDebugMessagePartReceive";
            checkBoxDebugMessagePartReceive.Size = new System.Drawing.Size(140, 17);
            checkBoxDebugMessagePartReceive.TabIndex = 5;
            checkBoxDebugMessagePartReceive.Text = "OnMessagePartReceive";
            checkBoxDebugMessagePartReceive.UseVisualStyleBackColor = true;
            // 
            // checkBoxDebugReceive
            // 
            checkBoxDebugReceive.AutoSize = true;
            checkBoxDebugReceive.Location = new System.Drawing.Point(330, 100);
            checkBoxDebugReceive.Margin = new System.Windows.Forms.Padding(4);
            checkBoxDebugReceive.Name = "checkBoxDebugReceive";
            checkBoxDebugReceive.Size = new System.Drawing.Size(78, 17);
            checkBoxDebugReceive.TabIndex = 3;
            checkBoxDebugReceive.Text = "OnReceive";
            checkBoxDebugReceive.UseVisualStyleBackColor = true;
            // 
            // checkBoxDebugMessagePartSend
            // 
            checkBoxDebugMessagePartSend.AutoSize = true;
            checkBoxDebugMessagePartSend.Location = new System.Drawing.Point(124, 128);
            checkBoxDebugMessagePartSend.Margin = new System.Windows.Forms.Padding(4);
            checkBoxDebugMessagePartSend.Name = "checkBoxDebugMessagePartSend";
            checkBoxDebugMessagePartSend.Size = new System.Drawing.Size(126, 17);
            checkBoxDebugMessagePartSend.TabIndex = 4;
            checkBoxDebugMessagePartSend.Text = "OnMessagePartSend";
            checkBoxDebugMessagePartSend.UseVisualStyleBackColor = true;
            // 
            // checkBoxDebugSend
            // 
            checkBoxDebugSend.AutoSize = true;
            checkBoxDebugSend.Location = new System.Drawing.Point(124, 100);
            checkBoxDebugSend.Margin = new System.Windows.Forms.Padding(4);
            checkBoxDebugSend.Name = "checkBoxDebugSend";
            checkBoxDebugSend.Size = new System.Drawing.Size(64, 17);
            checkBoxDebugSend.TabIndex = 2;
            checkBoxDebugSend.Text = "OnSend";
            checkBoxDebugSend.UseVisualStyleBackColor = true;
            // 
            // label55
            // 
            label55.AutoSize = true;
            label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label55.Location = new System.Drawing.Point(10, 10);
            label55.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label55.Name = "label55";
            label55.Size = new System.Drawing.Size(87, 13);
            label55.TabIndex = 1;
            label55.Text = "Debug Events";
            // 
            // label53
            // 
            label53.AutoSize = true;
            label53.Location = new System.Drawing.Point(10, 30);
            label53.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label53.Name = "label53";
            label53.Size = new System.Drawing.Size(219, 13);
            label53.TabIndex = 0;
            label53.Text = "Check events the debugger should break on";
            // 
            // tabPageTest
            // 
            tabPageTest.Controls.Add(label2);
            tabPageTest.Controls.Add(txtBatchSize);
            tabPageTest.Controls.Add(buttonStop);
            tabPageTest.Controls.Add(radioButtonMessageSendTab);
            tabPageTest.Controls.Add(radioButtonMessageTypeNonRepeating);
            tabPageTest.Controls.Add(label22);
            tabPageTest.Controls.Add(radioButtonMessageTypeRepeating);
            tabPageTest.Controls.Add(label17);
            tabPageTest.Controls.Add(label16);
            tabPageTest.Controls.Add(textBoxSendInterval);
            tabPageTest.Controls.Add(label15);
            tabPageTest.Controls.Add(textBoxSendDelay);
            tabPageTest.Controls.Add(buttonTestReset);
            tabPageTest.Controls.Add(label6);
            tabPageTest.Controls.Add(textBoxMessageCount);
            tabPageTest.Controls.Add(labelMessageSize);
            tabPageTest.Controls.Add(textBoxMessageSize);
            tabPageTest.Controls.Add(label3);
            tabPageTest.Controls.Add(buttonBulkSend);
            tabPageTest.Location = new System.Drawing.Point(4, 24);
            tabPageTest.Margin = new System.Windows.Forms.Padding(4);
            tabPageTest.Name = "tabPageTest";
            tabPageTest.Size = new System.Drawing.Size(660, 641);
            tabPageTest.TabIndex = 5;
            tabPageTest.Text = "Test";
            tabPageTest.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 182);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(88, 13);
            label2.TabIndex = 58;
            label2.Text = "Transaction size:";
            // 
            // txtBatchSize
            // 
            txtBatchSize.Location = new System.Drawing.Point(126, 179);
            txtBatchSize.Margin = new System.Windows.Forms.Padding(4);
            txtBatchSize.Name = "txtBatchSize";
            txtBatchSize.Size = new System.Drawing.Size(93, 21);
            txtBatchSize.TabIndex = 57;
            txtBatchSize.Text = "100";
            txtBatchSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonStop
            // 
            buttonStop.Enabled = false;
            buttonStop.Location = new System.Drawing.Point(116, 55);
            buttonStop.Margin = new System.Windows.Forms.Padding(4);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new System.Drawing.Size(95, 29);
            buttonStop.TabIndex = 9;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // radioButtonMessageSendTab
            // 
            radioButtonMessageSendTab.AutoSize = true;
            radioButtonMessageSendTab.Location = new System.Drawing.Point(402, 171);
            radioButtonMessageSendTab.Margin = new System.Windows.Forms.Padding(4);
            radioButtonMessageSendTab.Name = "radioButtonMessageSendTab";
            radioButtonMessageSendTab.Size = new System.Drawing.Size(145, 17);
            radioButtonMessageSendTab.TabIndex = 6;
            radioButtonMessageSendTab.Text = "Message in the Send Tab";
            radioButtonMessageSendTab.UseVisualStyleBackColor = true;
            radioButtonMessageSendTab.CheckedChanged += radioButtonMessageSendTab_CheckedChanged;
            // 
            // radioButtonMessageTypeNonRepeating
            // 
            radioButtonMessageTypeNonRepeating.AutoSize = true;
            radioButtonMessageTypeNonRepeating.Location = new System.Drawing.Point(402, 142);
            radioButtonMessageTypeNonRepeating.Margin = new System.Windows.Forms.Padding(4);
            radioButtonMessageTypeNonRepeating.Name = "radioButtonMessageTypeNonRepeating";
            radioButtonMessageTypeNonRepeating.Size = new System.Drawing.Size(166, 17);
            radioButtonMessageTypeNonRepeating.TabIndex = 5;
            radioButtonMessageTypeNonRepeating.Text = "Non-Repeating Test Message";
            radioButtonMessageTypeNonRepeating.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(286, 116);
            label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(88, 13);
            label22.TabIndex = 56;
            label22.Text = "Message to send";
            // 
            // radioButtonMessageTypeRepeating
            // 
            radioButtonMessageTypeRepeating.AutoSize = true;
            radioButtonMessageTypeRepeating.Checked = true;
            radioButtonMessageTypeRepeating.Location = new System.Drawing.Point(402, 114);
            radioButtonMessageTypeRepeating.Margin = new System.Windows.Forms.Padding(4);
            radioButtonMessageTypeRepeating.Name = "radioButtonMessageTypeRepeating";
            radioButtonMessageTypeRepeating.Size = new System.Drawing.Size(182, 17);
            radioButtonMessageTypeRepeating.TabIndex = 4;
            radioButtonMessageTypeRepeating.TabStop = true;
            radioButtonMessageTypeRepeating.Text = "Repeating Pattern Test Message";
            radioButtonMessageTypeRepeating.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(10, 224);
            label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(34, 13);
            label17.TabIndex = 43;
            label17.Text = "Delay";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(241, 224);
            label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(54, 13);
            label16.TabIndex = 48;
            label16.Text = "messages";
            // 
            // textBoxSendInterval
            // 
            textBoxSendInterval.Location = new System.Drawing.Point(171, 220);
            textBoxSendInterval.Margin = new System.Windows.Forms.Padding(4);
            textBoxSendInterval.Name = "textBoxSendInterval";
            textBoxSendInterval.Size = new System.Drawing.Size(62, 21);
            textBoxSendInterval.TabIndex = 3;
            textBoxSendInterval.Text = "0";
            textBoxSendInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(106, 224);
            label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(51, 13);
            label15.TabIndex = 46;
            label15.Text = "ms every";
            // 
            // textBoxSendDelay
            // 
            textBoxSendDelay.Location = new System.Drawing.Point(59, 220);
            textBoxSendDelay.Margin = new System.Windows.Forms.Padding(4);
            textBoxSendDelay.Name = "textBoxSendDelay";
            textBoxSendDelay.Size = new System.Drawing.Size(43, 21);
            textBoxSendDelay.TabIndex = 2;
            textBoxSendDelay.Text = "0";
            textBoxSendDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonTestReset
            // 
            buttonTestReset.Location = new System.Drawing.Point(462, 11);
            buttonTestReset.Margin = new System.Windows.Forms.Padding(4);
            buttonTestReset.Name = "buttonTestReset";
            buttonTestReset.Size = new System.Drawing.Size(185, 29);
            buttonTestReset.TabIndex = 7;
            buttonTestReset.Text = "&Reset Message Counts";
            buttonTestReset.UseVisualStyleBackColor = true;
            buttonTestReset.Click += buttonTestReset_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(10, 18);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(267, 13);
            label6.TabIndex = 33;
            label6.Text = "Batch message testing can be performed from this tab";
            // 
            // textBoxMessageCount
            // 
            textBoxMessageCount.Location = new System.Drawing.Point(126, 112);
            textBoxMessageCount.Margin = new System.Windows.Forms.Padding(4);
            textBoxMessageCount.Name = "textBoxMessageCount";
            textBoxMessageCount.Size = new System.Drawing.Size(93, 21);
            textBoxMessageCount.TabIndex = 0;
            textBoxMessageCount.Text = "100";
            textBoxMessageCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelMessageSize
            // 
            labelMessageSize.AutoSize = true;
            labelMessageSize.Location = new System.Drawing.Point(10, 150);
            labelMessageSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelMessageSize.Name = "labelMessageSize";
            labelMessageSize.Size = new System.Drawing.Size(74, 13);
            labelMessageSize.TabIndex = 41;
            labelMessageSize.Text = "Message size:";
            // 
            // textBoxMessageSize
            // 
            textBoxMessageSize.Location = new System.Drawing.Point(126, 146);
            textBoxMessageSize.Margin = new System.Windows.Forms.Padding(4);
            textBoxMessageSize.Name = "textBoxMessageSize";
            textBoxMessageSize.Size = new System.Drawing.Size(93, 21);
            textBoxMessageSize.TabIndex = 1;
            textBoxMessageSize.Text = "100";
            textBoxMessageSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(10, 116);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(83, 13);
            label3.TabIndex = 39;
            label3.Text = "Message count:";
            // 
            // buttonBulkSend
            // 
            buttonBulkSend.Enabled = false;
            buttonBulkSend.Location = new System.Drawing.Point(14, 55);
            buttonBulkSend.Margin = new System.Windows.Forms.Padding(4);
            buttonBulkSend.Name = "buttonBulkSend";
            buttonBulkSend.Size = new System.Drawing.Size(95, 29);
            buttonBulkSend.TabIndex = 8;
            buttonBulkSend.Text = "&Send";
            buttonBulkSend.UseVisualStyleBackColor = true;
            buttonBulkSend.Click += buttonBulkSend_Click;
            // 
            // tabPageErrors
            // 
            tabPageErrors.Controls.Add(listBoxErrors);
            tabPageErrors.Location = new System.Drawing.Point(4, 24);
            tabPageErrors.Margin = new System.Windows.Forms.Padding(4);
            tabPageErrors.Name = "tabPageErrors";
            tabPageErrors.Padding = new System.Windows.Forms.Padding(4);
            tabPageErrors.Size = new System.Drawing.Size(660, 641);
            tabPageErrors.TabIndex = 12;
            tabPageErrors.Text = "Errors";
            tabPageErrors.UseVisualStyleBackColor = true;
            // 
            // listBoxErrors
            // 
            listBoxErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            listBoxErrors.FormattingEnabled = true;
            listBoxErrors.ItemHeight = 13;
            listBoxErrors.Location = new System.Drawing.Point(4, 4);
            listBoxErrors.Margin = new System.Windows.Forms.Padding(4);
            listBoxErrors.Name = "listBoxErrors";
            listBoxErrors.Size = new System.Drawing.Size(652, 633);
            listBoxErrors.TabIndex = 0;
            listBoxErrors.MouseDoubleClick += listBoxErrors_MouseDoubleClick;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Topic";
            columnHeader5.Width = 129;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Status";
            columnHeader6.Width = 138;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Topic";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Direction";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTextBoxColumn3.HeaderText = "Status";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn4.HeaderText = "Transport";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { copyToSendToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(146, 26);
            // 
            // copyToSendToolStripMenuItem
            // 
            copyToSendToolStripMenuItem.Name = "copyToSendToolStripMenuItem";
            copyToSendToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            copyToSendToolStripMenuItem.Text = "&Copy to Send";
            copyToSendToolStripMenuItem.Click += copyToSendToolStripMenuItem_Click;
            // 
            // FormTestClient
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(668, 715);
            Controls.Add(tabControl1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "FormTestClient";
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "Neuron Test Client";
            FormClosing += FormTestClient_FormClosing;
            Load += FormTestClient_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPageConnect.ResumeLayout(false);
            panelConnectMain.ResumeLayout(false);
            panelConnectMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubscriptions).EndInit();
            panelConnectBottom.ResumeLayout(false);
            panelConnectBottom2.ResumeLayout(false);
            panelConnectBottom2.PerformLayout();
            panelConnectTop.ResumeLayout(false);
            panelConnectTop.PerformLayout();
            tabPageSend.ResumeLayout(false);
            panelSendMain.ResumeLayout(false);
            panelSendMain.PerformLayout();
            panelSendBottom2.ResumeLayout(false);
            panelSendBottom2.PerformLayout();
            panelSendBottom.ResumeLayout(false);
            panelSendTop2.ResumeLayout(false);
            panelSendTop2.PerformLayout();
            panelSendTop.ResumeLayout(false);
            panelSendTop.PerformLayout();
            panel1.ResumeLayout(false);
            tabPageReceive.ResumeLayout(false);
            panelReceiveMain.ResumeLayout(false);
            panelReceiveMain.PerformLayout();
            panelReceiveBottom.ResumeLayout(false);
            panelReceiveBottom.PerformLayout();
            panelReceiveTop2.ResumeLayout(false);
            panelReceiveTop2.PerformLayout();
            panelReceiveTop.ResumeLayout(false);
            panelReceiveTop.PerformLayout();
            tabPageHistory.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panelHistoryBottom.ResumeLayout(false);
            panelHistoryTop.ResumeLayout(false);
            panelHistoryTop.PerformLayout();
            tabPageDebug.ResumeLayout(false);
            tabPageDebug.PerformLayout();
            tabPageTest.ResumeLayout(false);
            tabPageTest.PerformLayout();
            tabPageErrors.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusSentCount;
        private System.Windows.Forms.ToolStripStatusLabel statusSentTime;
        private System.Windows.Forms.ToolStripStatusLabel statusRecvCount;
        private System.Windows.Forms.ToolStripStatusLabel statusRecvTime;
        private System.Windows.Forms.ToolStripStatusLabel statusSentMsgPerSec;
        private System.Windows.Forms.ToolStripStatusLabel statusRecvMsgPerSec;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageTest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxMessageCount;
        private System.Windows.Forms.Label labelMessageSize;
        private System.Windows.Forms.TextBox textBoxMessageSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonBulkSend;
        private System.Windows.Forms.Button buttonTestReset;
        private System.Windows.Forms.TabPage tabPageDebug;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.CheckBox checkBoxDebugMessagePartReceive;
        private System.Windows.Forms.CheckBox checkBoxDebugReceive;
        private System.Windows.Forms.CheckBox checkBoxDebugMessagePartSend;
        private System.Windows.Forms.CheckBox checkBoxDebugSend;
        private System.Windows.Forms.CheckBox checkBoxDebugMessageSequenceGap;
        private System.Windows.Forms.CheckBox checkBoxDebugPipelineEnd;
        private System.Windows.Forms.CheckBox checkBoxDebugPipelineBegin;
        private System.Windows.Forms.Button buttonDebugClearAll;
        private System.Windows.Forms.Button buttonDebugCheckAll;
        private System.Windows.Forms.TabPage tabPageConnect;
        private System.Windows.Forms.Panel panelConnectTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.TabPage tabPageSend;
        private System.Windows.Forms.Panel panelSendTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelSendTop2;
        private System.Windows.Forms.TextBox textBoxSendDest;
        private System.Windows.Forms.Label labelSendDest;
        private System.Windows.Forms.Panel panelSendBottom2;
        private System.Windows.Forms.RadioButton radioButtonSendXml;
        private System.Windows.Forms.RadioButton radioButtonSendString;
        private System.Windows.Forms.ComboBox comboBoxPriority;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxSendSemantic;
        private System.Windows.Forms.Panel panelSendBottom;
        private System.Windows.Forms.Button buttonPublish;
        private System.Windows.Forms.Button buttonSendClear;
        private System.Windows.Forms.Panel panelSendMain;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPageReceive;
        private System.Windows.Forms.Panel panelReceiveTop;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxReceiveTopic;
        private System.Windows.Forms.Panel panelReceiveBottom;
        private System.Windows.Forms.Button buttonReceiveClear;
        private System.Windows.Forms.Panel panelReceiveTop2;
        private System.Windows.Forms.TextBox textBoxReceiveSource;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Panel panelReceiveMain;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBoxReceiveSemantic;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelConnectBottom2;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Panel panelConnectMain;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridView dataGridViewSubscriptions;
        private System.Windows.Forms.Panel panelConnectBottom;
        private System.Windows.Forms.Button buttonResume;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.CheckBox checkBoxFilter;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.Button buttonSetFilter;
        private System.Windows.Forms.Button buttonReceiveCopy;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.TabPage tabPageHistory;
        private System.Windows.Forms.Panel panelHistoryTop;
        private System.Windows.Forms.TextBox textBoxMessageHistoryCount;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Panel panelHistoryBottom;
        private System.Windows.Forms.Button buttonHistoryClear;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Label labelEventDetail;
        public System.Windows.Forms.ListView listViewMessageHistory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button buttonHistoryClearAll;
        private System.Windows.Forms.SplitContainer splitContainer2;
        public System.Windows.Forms.ListView listViewMessageHeader;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        public System.Windows.Forms.Label label60;
        public System.Windows.Forms.Label label62;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewFullMessageXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem garbageCollectToolStripMenuItem;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxSendDelay;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxSendInterval;
        private System.Windows.Forms.ToolStripMenuItem msgToXmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xmlToMsgToolStripMenuItem;
        //private ActiproSoftware.Text.Languages.Xml.Implementation.XmlSyntaxLanguage xmlSyntaxLanguage1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem insertTestMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertTestMessageOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem formatXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largePurchaseOrderXSDToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxSendAction;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxObjectAssembly;
        private System.Windows.Forms.RadioButton radioButtonSendObject;
        private System.Windows.Forms.Label labelObjectClass;
        private System.Windows.Forms.Label labelObjectAssembly;
        private System.Windows.Forms.Button buttonAssemblyBrowse;
        private System.Windows.Forms.ComboBox comboBoxClassName;
        private System.Windows.Forms.ComboBox comboBoxSubscriberId;
        private System.Windows.Forms.Button buttonBrowseSubscribers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonBrowseTopics;
        private System.Windows.Forms.Label labelSpacer;
        private System.Windows.Forms.ComboBox comboBoxSendTopic;
        private System.Windows.Forms.ToolStripMenuItem updateConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.RadioButton radioButtonMessageSendTab;
        private System.Windows.Forms.RadioButton radioButtonMessageTypeNonRepeating;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.RadioButton radioButtonMessageTypeRepeating;
        private System.Windows.Forms.Button buttonSaveReceivedMessage;
        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.CheckBox checkBoxDebugOffline;
        private System.Windows.Forms.CheckBox checkBoxDebugOnline;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox checkBoxDebugSubscriberDisabled;
        private System.Windows.Forms.CheckBox checkBoxDebugConfigChanged;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox checkBoxDebugPipelineError;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nongracefulExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.LinkLabel linkLabelCustomPropeties;
        private System.Windows.Forms.LinkLabel linkLabelSendCustomProperties;
        private System.Windows.Forms.LinkLabel linkLabelReceiveCustomProperties;
        private System.Windows.Forms.RadioButton radioButtonSendBinary;
        private System.Windows.Forms.CheckBox checkBoxTx;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TabPage tabPageErrors;
        private System.Windows.Forms.ListBox listBoxErrors;
        private System.Windows.Forms.CheckBox checkBoxBulkTestMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTopic;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDirection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTransport;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Neuron.UI.HexBox hexBox;
        private Neuron.UI.HexBox hexBoxReceive;
        private System.Windows.Forms.Button buttonLoadMessage;
        private System.Windows.Forms.Button buttonSaveMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBatchSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem connectionSettingsToolStripMenuItem;
        private UI.HexBox hexBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToSendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.TextBox xmlEditorSend;
        private System.Windows.Forms.TextBox xmlEditorReceive;
        public System.Windows.Forms.TextBox xmlEditorBody;
    }
}

