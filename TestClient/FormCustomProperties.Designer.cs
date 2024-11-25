namespace Neuron.TestClient
{
    partial class FormCustomProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCustomProperties));
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelSpacer = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.dataGridViewProperties = new System.Windows.Forms.DataGridView();
            this.ColumnPrefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(366, 34);
            this.panelTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Custom Message Properties";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.buttonOK);
            this.panelBottom.Controls.Add(this.labelSpacer);
            this.panelBottom.Controls.Add(this.buttonClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 286);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.panelBottom.Size = new System.Drawing.Size(366, 34);
            this.panelBottom.TabIndex = 1;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonOK.Location = new System.Drawing.Point(196, 0);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 24);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelSpacer
            // 
            this.labelSpacer.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelSpacer.Location = new System.Drawing.Point(271, 0);
            this.labelSpacer.Name = "labelSpacer";
            this.labelSpacer.Size = new System.Drawing.Size(10, 24);
            this.labelSpacer.TabIndex = 1;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.Location = new System.Drawing.Point(281, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 24);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dataGridViewProperties);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 34);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(10);
            this.panelMain.Size = new System.Drawing.Size(366, 252);
            this.panelMain.TabIndex = 2;
            // 
            // dataGridViewProperties
            // 
            this.dataGridViewProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPrefix,
            this.ColumnName,
            this.ColumnValue});
            this.dataGridViewProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProperties.Location = new System.Drawing.Point(10, 10);
            this.dataGridViewProperties.Name = "dataGridViewProperties";
            this.dataGridViewProperties.Size = new System.Drawing.Size(346, 232);
            this.dataGridViewProperties.TabIndex = 0;
            // 
            // ColumnPrefix
            // 
            this.ColumnPrefix.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnPrefix.HeaderText = "Prefix";
            this.ColumnPrefix.MinimumWidth = 75;
            this.ColumnPrefix.Name = "ColumnPrefix";
            this.ColumnPrefix.Width = 75;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.MinimumWidth = 75;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 75;
            // 
            // ColumnValue
            // 
            this.ColumnValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnValue.HeaderText = "Value";
            this.ColumnValue.Name = "ColumnValue";
            // 
            // FormCustomProperties
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(366, 320);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FormCustomProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Custom Properties";
            this.Load += new System.EventHandler(this.FormCustomProperties_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProperties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dataGridViewProperties;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelSpacer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
    }
}