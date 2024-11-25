namespace Neuron.TestClient
{
    partial class TestClientSettings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestClientSettings));
            this.labelIdentity = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelDomain = new System.Windows.Forms.Label();
            this.textBoxIdentity = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxDomain = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.grpConnect = new System.Windows.Forms.GroupBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.comboBoxInstance = new System.Windows.Forms.ComboBox();
            this.textBoxConnectServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpConnect.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelIdentity
            // 
            this.labelIdentity.AutoSize = true;
            this.labelIdentity.Location = new System.Drawing.Point(36, 132);
            this.labelIdentity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIdentity.Name = "labelIdentity";
            this.labelIdentity.Size = new System.Drawing.Size(97, 14);
            this.labelIdentity.TabIndex = 1;
            this.labelIdentity.Text = "Service Identity:";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(36, 36);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(65, 14);
            this.labelUsername.TabIndex = 3;
            this.labelUsername.Text = "Username:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(36, 69);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(62, 14);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Password:";
            // 
            // labelDomain
            // 
            this.labelDomain.AutoSize = true;
            this.labelDomain.Location = new System.Drawing.Point(36, 101);
            this.labelDomain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDomain.Name = "labelDomain";
            this.labelDomain.Size = new System.Drawing.Size(51, 14);
            this.labelDomain.TabIndex = 5;
            this.labelDomain.Text = "Domain:";
            // 
            // textBoxIdentity
            // 
            this.textBoxIdentity.Location = new System.Drawing.Point(151, 128);
            this.textBoxIdentity.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxIdentity.Name = "textBoxIdentity";
            this.textBoxIdentity.Size = new System.Drawing.Size(460, 21);
            this.textBoxIdentity.TabIndex = 4;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(151, 32);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(460, 21);
            this.textBoxUsername.TabIndex = 5;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(151, 65);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(460, 21);
            this.textBoxPassword.TabIndex = 6;
            // 
            // textBoxDomain
            // 
            this.textBoxDomain.Location = new System.Drawing.Point(151, 98);
            this.textBoxDomain.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDomain.Name = "textBoxDomain";
            this.textBoxDomain.Size = new System.Drawing.Size(460, 21);
            this.textBoxDomain.TabIndex = 7;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(466, 349);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(94, 29);
            this.buttonOk.TabIndex = 12;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(568, 349);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // grpConnect
            // 
            this.grpConnect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpConnect.Controls.Add(this.textBoxPort);
            this.grpConnect.Controls.Add(this.comboBoxInstance);
            this.grpConnect.Controls.Add(this.textBoxConnectServer);
            this.grpConnect.Controls.Add(this.label1);
            this.grpConnect.Controls.Add(this.label2);
            this.grpConnect.Controls.Add(this.label3);
            this.grpConnect.Controls.Add(this.labelIdentity);
            this.grpConnect.Controls.Add(this.textBoxIdentity);
            this.grpConnect.Location = new System.Drawing.Point(15, 13);
            this.grpConnect.Margin = new System.Windows.Forms.Padding(4);
            this.grpConnect.Name = "grpConnect";
            this.grpConnect.Padding = new System.Windows.Forms.Padding(4);
            this.grpConnect.Size = new System.Drawing.Size(646, 175);
            this.grpConnect.TabIndex = 15;
            this.grpConnect.TabStop = false;
            this.grpConnect.Text = "Connection Information";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPort.Location = new System.Drawing.Point(151, 95);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(460, 24);
            this.textBoxPort.TabIndex = 3;
            this.textBoxPort.TabStop = false;
            this.textBoxPort.Text = "50000";
            this.textBoxPort.Validated += new System.EventHandler(this.textBoxPort_TextChanged);
            // 
            // comboBoxInstance
            // 
            this.comboBoxInstance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxInstance.FormattingEnabled = true;
            this.comboBoxInstance.Location = new System.Drawing.Point(151, 64);
            this.comboBoxInstance.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxInstance.Name = "comboBoxInstance";
            this.comboBoxInstance.Size = new System.Drawing.Size(460, 25);
            this.comboBoxInstance.TabIndex = 2;
            this.comboBoxInstance.SelectedIndexChanged += new System.EventHandler(this.comboBoxInstance_SelectedIndexChanged);
            // 
            // textBoxConnectServer
            // 
            this.textBoxConnectServer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConnectServer.Location = new System.Drawing.Point(151, 30);
            this.textBoxConnectServer.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxConnectServer.Name = "textBoxConnectServer";
            this.textBoxConnectServer.Size = new System.Drawing.Size(460, 24);
            this.textBoxConnectServer.TabIndex = 1;
            this.textBoxConnectServer.Text = "localhost";
            this.textBoxConnectServer.Validated += new System.EventHandler(this.textBoxConnectServer_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Neuron Server:";
            this.toolTip1.SetToolTip(this.label1, "Address to the Neuron ESB Configuration Service");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "Instance*:";
            this.toolTip1.SetToolTip(this.label2, "Required if Port Sharing is enabled on target solution");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 99);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 14);
            this.label3.TabIndex = 16;
            this.label3.Text = "Boostrap Port:";
            this.toolTip1.SetToolTip(this.label3, "Neruon ESB Configured Zone");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxUsername);
            this.groupBox1.Controls.Add(this.labelUsername);
            this.groupBox1.Controls.Add(this.labelPassword);
            this.groupBox1.Controls.Add(this.labelDomain);
            this.groupBox1.Controls.Add(this.textBoxPassword);
            this.groupBox1.Controls.Add(this.textBoxDomain);
            this.groupBox1.Location = new System.Drawing.Point(15, 196);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(646, 145);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Security Credentials";
            this.toolTip1.SetToolTip(this.groupBox1, "Connect to Neuron ESB using the specified credentials.");
            // 
            // TestClientSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(676, 392);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpConnect);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestClientSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Neuron ESB Connection Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestClientSettings_FormClosing);
            this.Load += new System.EventHandler(this.TestClientSettings_Load);
            this.grpConnect.ResumeLayout(false);
            this.grpConnect.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }


        
        #endregion

        private System.Windows.Forms.Label labelIdentity;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelDomain;
        private System.Windows.Forms.TextBox textBoxIdentity;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxDomain;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox grpConnect;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ColumnHeader columnHeaderServer;
        private System.Windows.Forms.ColumnHeader columnHeaderZone;
        private System.Windows.Forms.ColumnHeader columnHeaderInstance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader columnHeaderDeploymentGroup;
        private System.Windows.Forms.ColumnHeader columnHeaderConfig;
        private System.Windows.Forms.ColumnHeader columnHeaderDateTime;
        private System.Windows.Forms.ColumnHeader columnHeaderInterval;
        public System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.ComboBox comboBoxInstance;
        public System.Windows.Forms.TextBox textBoxConnectServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}