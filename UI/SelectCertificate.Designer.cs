namespace Neuron.UI
{
    partial class SelectCertificate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectCertificate));
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lstCerts = new System.Windows.Forms.ListBox();
            this.cbStore = new System.Windows.Forms.ComboBox();
            this.cbFindBy = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnFindTypeHelp = new System.Windows.Forms.LinkLabel();
            this.rbMachine = new System.Windows.Forms.RadioButton();
            this.rbPersonal = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPermissions = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(-8, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1000, 2);
            this.label4.TabIndex = 38;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(-4, -1);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(925, 82);
            this.panel2.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "Select a certificate from your current machine";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label5.Location = new System.Drawing.Point(18, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "Certificate Configuration";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 279);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 14);
            this.label3.TabIndex = 39;
            this.label3.Text = "Certificate Store:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 335);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 14);
            this.label6.TabIndex = 40;
            this.label6.Text = "Find type:";
            // 
            // lstCerts
            // 
            this.lstCerts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCerts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstCerts.FormattingEnabled = true;
            this.lstCerts.ItemHeight = 42;
            this.lstCerts.Location = new System.Drawing.Point(28, 400);
            this.lstCerts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstCerts.Name = "lstCerts";
            this.lstCerts.Size = new System.Drawing.Size(732, 214);
            this.lstCerts.TabIndex = 5;
            this.lstCerts.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstCerts_DrawItem);
            this.lstCerts.SelectedIndexChanged += new System.EventHandler(this.lstCerts_SelectedIndexChanged);
            this.lstCerts.DoubleClick += new System.EventHandler(this.lstCerts_DoubleClick);
            // 
            // cbStore
            // 
            this.cbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStore.FormattingEnabled = true;
            this.cbStore.Location = new System.Drawing.Point(28, 299);
            this.cbStore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbStore.Name = "cbStore";
            this.cbStore.Size = new System.Drawing.Size(298, 21);
            this.cbStore.TabIndex = 2;
            this.cbStore.SelectedIndexChanged += new System.EventHandler(this.cbStore_SelectedIndexChanged);
            // 
            // cbFindBy
            // 
            this.cbFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFindBy.FormattingEnabled = true;
            this.cbFindBy.Location = new System.Drawing.Point(28, 355);
            this.cbFindBy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbFindBy.Name = "cbFindBy";
            this.cbFindBy.Size = new System.Drawing.Size(298, 21);
            this.cbFindBy.TabIndex = 3;
            this.cbFindBy.SelectedIndexChanged += new System.EventHandler(this.cbFindBy_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(28, 661);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(732, 2);
            this.label7.TabIndex = 48;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(666, 671);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 31);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(565, 671);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 31);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnFindTypeHelp
            // 
            this.btnFindTypeHelp.AutoSize = true;
            this.btnFindTypeHelp.Location = new System.Drawing.Point(100, 335);
            this.btnFindTypeHelp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnFindTypeHelp.Name = "btnFindTypeHelp";
            this.btnFindTypeHelp.Size = new System.Drawing.Size(82, 14);
            this.btnFindTypeHelp.TabIndex = 49;
            this.btnFindTypeHelp.TabStop = true;
            this.btnFindTypeHelp.Text = "(what\'s this?)";
            this.btnFindTypeHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnFindTypeHelp_LinkClicked);
            // 
            // rbMachine
            // 
            this.rbMachine.AutoSize = true;
            this.rbMachine.Checked = true;
            this.rbMachine.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.rbMachine.Location = new System.Drawing.Point(35, 116);
            this.rbMachine.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbMachine.Name = "rbMachine";
            this.rbMachine.Size = new System.Drawing.Size(143, 18);
            this.rbMachine.TabIndex = 0;
            this.rbMachine.TabStop = true;
            this.rbMachine.Text = "Machine certificate";
            this.rbMachine.UseVisualStyleBackColor = true;
            this.rbMachine.CheckedChanged += new System.EventHandler(this.rbMachine_CheckedChanged);
            // 
            // rbPersonal
            // 
            this.rbPersonal.AutoSize = true;
            this.rbPersonal.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.rbPersonal.Location = new System.Drawing.Point(35, 202);
            this.rbPersonal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbPersonal.Name = "rbPersonal";
            this.rbPersonal.Size = new System.Drawing.Size(145, 18);
            this.rbPersonal.TabIndex = 1;
            this.rbPersonal.Text = "Personal certificate";
            this.rbPersonal.UseVisualStyleBackColor = true;
            this.rbPersonal.CheckedChanged += new System.EventHandler(this.rbPersonal_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(56, 141);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(691, 40);
            this.label8.TabIndex = 52;
            this.label8.Text = "Select this option to use a machine wide certificate. The same certificate will b" +
    "e used regardless of the account that the process is running under.";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(56, 228);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(691, 40);
            this.label9.TabIndex = 53;
            this.label9.Text = "Select this option if you want the certificate to vary by user. A certificate wil" +
    "l be selected that has been installed for the executing user account.";
            // 
            // btnPermissions
            // 
            this.btnPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPermissions.Enabled = false;
            this.btnPermissions.Location = new System.Drawing.Point(31, 622);
            this.btnPermissions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPermissions.Name = "btnPermissions";
            this.btnPermissions.Size = new System.Drawing.Size(108, 31);
            this.btnPermissions.TabIndex = 6;
            this.btnPermissions.Text = "Permissions...";
            this.btnPermissions.UseVisualStyleBackColor = true;
            this.btnPermissions.Click += new System.EventHandler(this.btnPermissions_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 14);
            this.label1.TabIndex = 36;
            this.label1.Text = "Certificate type:";
            // 
            // SelectCertificate
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(788, 725);
            this.Controls.Add(this.btnPermissions);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rbPersonal);
            this.Controls.Add(this.rbMachine);
            this.Controls.Add(this.btnFindTypeHelp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbFindBy);
            this.Controls.Add(this.cbStore);
            this.Controls.Add(this.lstCerts);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectCertificate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Certificate";
            this.Click += new System.EventHandler(this.SelectCertificate_Click);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstCerts;
        private System.Windows.Forms.ComboBox cbStore;
        private System.Windows.Forms.ComboBox cbFindBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.LinkLabel btnFindTypeHelp;
        private System.Windows.Forms.RadioButton rbMachine;
        private System.Windows.Forms.RadioButton rbPersonal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPermissions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}