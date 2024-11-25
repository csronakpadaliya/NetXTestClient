namespace Neuron.UI
{
    partial class ExceptionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionDialog));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSupport = new System.Windows.Forms.Button();
            this.btnGrab = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBoxInfo = new System.Windows.Forms.PictureBox();
            this.pictureBoxWarning = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtMessage = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.pnlBackground.SuspendLayout();
            this.layout.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBackground.Controls.Add(this.layout);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Padding = new System.Windows.Forms.Padding(5);
            this.pnlBackground.Size = new System.Drawing.Size(509, 470);
            this.pnlBackground.TabIndex = 75;
            // 
            // layout
            // 
            this.layout.BackColor = System.Drawing.Color.Transparent;
            this.layout.ColumnCount = 1;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.Controls.Add(this.panel1, 0, 2);
            this.layout.Controls.Add(this.panel2, 0, 1);
            this.layout.Controls.Add(this.panel3, 0, 0);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(5, 5);
            this.layout.Margin = new System.Windows.Forms.Padding(0);
            this.layout.Name = "layout";
            this.layout.RowCount = 3;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.layout.Size = new System.Drawing.Size(499, 460);
            this.layout.TabIndex = 74;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnMore);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 410);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.MinimumSize = new System.Drawing.Size(499, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 60);
            this.panel1.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(217, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 9;
            this.button1.Text = "&Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnMore
            // 
            this.btnMore.ActiveLinkColor = System.Drawing.Color.CornflowerBlue;
            this.btnMore.AutoSize = true;
            this.btnMore.LinkColor = System.Drawing.Color.Navy;
            this.btnMore.Location = new System.Drawing.Point(415, 23);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(68, 13);
            this.btnMore.TabIndex = 3;
            this.btnMore.TabStop = true;
            this.btnMore.Text = "Show Details";
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(499, 4);
            this.label1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnSupport);
            this.panel2.Controls.Add(this.btnGrab);
            this.panel2.Controls.Add(this.btnCopy);
            this.panel2.Controls.Add(this.txtDetails);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 160);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(499, 250);
            this.panel2.TabIndex = 30;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnSupport
            // 
            this.btnSupport.Image = global::Neuron.Properties.Resources.UserComment;
            this.btnSupport.Location = new System.Drawing.Point(53, 217);
            this.btnSupport.Name = "btnSupport";
            this.btnSupport.Size = new System.Drawing.Size(35, 25);
            this.btnSupport.TabIndex = 8;
            this.toolTip.SetToolTip(this.btnSupport, "Ask Support");
            this.btnSupport.UseVisualStyleBackColor = true;
            this.btnSupport.Click += new System.EventHandler(this.btnSupport_Click);
            // 
            // btnGrab
            // 
            this.btnGrab.Enabled = false;
            this.btnGrab.Image = global::Neuron.Properties.Resources.Design;
            this.btnGrab.Location = new System.Drawing.Point(94, 217);
            this.btnGrab.Name = "btnGrab";
            this.btnGrab.Size = new System.Drawing.Size(35, 25);
            this.btnGrab.TabIndex = 7;
            this.toolTip.SetToolTip(this.btnGrab, "Grab Screen");
            this.btnGrab.UseVisualStyleBackColor = true;
            this.btnGrab.Click += new System.EventHandler(this.btnGrab_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::Neuron.Properties.Resources.Copy;
            this.btnCopy.Location = new System.Drawing.Point(12, 217);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(35, 25);
            this.btnCopy.TabIndex = 3;
            this.toolTip.SetToolTip(this.btnCopy, "Copy Details to Clipboard");
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtDetails
            // 
            this.txtDetails.BackColor = System.Drawing.Color.White;
            this.txtDetails.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetails.Location = new System.Drawing.Point(12, 17);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ReadOnly = true;
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetails.Size = new System.Drawing.Size(471, 194);
            this.txtDetails.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(499, 4);
            this.label3.TabIndex = 3;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.pictureBoxInfo);
            this.panel3.Controls.Add(this.pictureBoxWarning);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.txtMessage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(493, 154);
            this.panel3.TabIndex = 31;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // pictureBoxInfo
            // 
            this.pictureBoxInfo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxInfo.Image")));
            this.pictureBoxInfo.Location = new System.Drawing.Point(9, 49);
            this.pictureBoxInfo.Name = "pictureBoxInfo";
            this.pictureBoxInfo.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxInfo.TabIndex = 32;
            this.pictureBoxInfo.TabStop = false;
            this.pictureBoxInfo.Visible = false;
            // 
            // pictureBoxWarning
            // 
            this.pictureBoxWarning.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxWarning.Image")));
            this.pictureBoxWarning.Location = new System.Drawing.Point(9, 49);
            this.pictureBoxWarning.Name = "pictureBoxWarning";
            this.pictureBoxWarning.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxWarning.TabIndex = 31;
            this.pictureBoxWarning.TabStop = false;
            this.pictureBoxWarning.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.Transparent;
            this.txtMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(62, 6);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(418, 119);
            this.txtMessage.TabIndex = 29;
            this.txtMessage.Text = "An unhandled exception was encountered";
            this.txtMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMessage.Click += new System.EventHandler(this.txtMessage_Click);
            // 
            // ExceptionDialog
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(509, 470);
            this.Controls.Add(this.pnlBackground);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Unable to complete operation";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.pnlBackground.ResumeLayout(false);
            this.layout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnGrab;
        private System.Windows.Forms.LinkLabel btnMore;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnSupport;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label txtMessage;
        internal System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.PictureBox pictureBoxWarning;
        internal System.Windows.Forms.PictureBox pictureBoxInfo;
    }
}