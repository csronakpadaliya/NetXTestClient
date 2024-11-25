namespace Neuron.UI.Configuration
{
    partial class EntityBindingExpressionEditorDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntityBindingExpressionEditorDialog));
            this.btnOK = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lstBindings = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlEdit = new System.Windows.Forms.Panel();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPropertyActualDescription = new System.Windows.Forms.Label();
            this.labelPropertyDescription = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnOK.Location = new System.Drawing.Point(424, 393);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 71;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.Location = new System.Drawing.Point(14, 385);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(564, 2);
            this.label7.TabIndex = 70;
            // 
            // lstBindings
            // 
            this.lstBindings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstBindings.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstBindings.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lstBindings.FormattingEnabled = true;
            this.lstBindings.HorizontalExtent = 100;
            this.lstBindings.HorizontalScrollbar = true;
            this.lstBindings.ItemHeight = 18;
            this.lstBindings.Location = new System.Drawing.Point(12, 44);
            this.lstBindings.Name = "lstBindings";
            this.lstBindings.Size = new System.Drawing.Size(196, 328);
            this.lstBindings.TabIndex = 73;
            this.lstBindings.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstBindings_DrawItem);
            this.lstBindings.SelectedIndexChanged += new System.EventHandler(this.lstBindings_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "Binding Expression:";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(351, 35);
            this.label3.TabIndex = 78;
            this.label3.Text = "Environment variables can be referenced in the format {$variable_name}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 82;
            this.label4.Text = "Property bindings:";
            // 
            // pnlEdit
            // 
            this.pnlEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEdit.BackColor = System.Drawing.Color.Transparent;
            this.pnlEdit.Controls.Add(this.elementHost1);
            this.pnlEdit.Controls.Add(this.label1);
            this.pnlEdit.Controls.Add(this.labelPropertyActualDescription);
            this.pnlEdit.Controls.Add(this.labelPropertyDescription);
            this.pnlEdit.Controls.Add(this.label2);
            this.pnlEdit.Controls.Add(this.label3);
            this.pnlEdit.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.pnlEdit.Location = new System.Drawing.Point(221, 12);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(360, 360);
            this.pnlEdit.TabIndex = 83;
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost1.BackColor = System.Drawing.Color.White;
            this.elementHost1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.elementHost1.Location = new System.Drawing.Point(3, 32);
            this.elementHost1.Margin = new System.Windows.Forms.Padding(2);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(355, 22);
            this.elementHost1.TabIndex = 82;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(98, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 14);
            this.label1.TabIndex = 81;
            this.label1.Text = "Type in Ctrl + SPACE to see list of variables";
            // 
            // labelPropertyActualDescription
            // 
            this.labelPropertyActualDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPropertyActualDescription.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelPropertyActualDescription.Location = new System.Drawing.Point(0, 112);
            this.labelPropertyActualDescription.Name = "labelPropertyActualDescription";
            this.labelPropertyActualDescription.Size = new System.Drawing.Size(343, 248);
            this.labelPropertyActualDescription.TabIndex = 80;
            // 
            // labelPropertyDescription
            // 
            this.labelPropertyDescription.AutoSize = true;
            this.labelPropertyDescription.Location = new System.Drawing.Point(3, 90);
            this.labelPropertyDescription.Name = "labelPropertyDescription";
            this.labelPropertyDescription.Size = new System.Drawing.Size(109, 13);
            this.labelPropertyDescription.TabIndex = 79;
            this.labelPropertyDescription.Text = "Property Description:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(506, 393);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 84;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EntityBindingExpressionEditorDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(593, 428);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstBindings);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label7);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EntityBindingExpressionEditorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Binding Expressions";
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelPropertyActualDescription;
        private System.Windows.Forms.Label labelPropertyDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        public System.Windows.Forms.ListBox lstBindings;
    }
}