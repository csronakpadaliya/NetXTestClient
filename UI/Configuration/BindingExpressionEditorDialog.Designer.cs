namespace Neuron.UI.Configuration
{
    partial class BindingExpressionEditorDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BindingExpressionEditorDialog));
            this.btnOK = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lstBindings = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBindingExpression = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlEdit = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnOK.Location = new System.Drawing.Point(427, 395);
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
            this.label7.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label7.Location = new System.Drawing.Point(14, 385);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(570, 2);
            this.label7.TabIndex = 70;
            // 
            // lstBindings
            // 
            this.lstBindings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstBindings.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstBindings.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lstBindings.FormattingEnabled = true;
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
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(0, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "Binding Expression:";
            // 
            // txtBindingExpression
            // 
            this.txtBindingExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBindingExpression.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtBindingExpression.Location = new System.Drawing.Point(3, 32);
            this.txtBindingExpression.Name = "txtBindingExpression";
            this.txtBindingExpression.Size = new System.Drawing.Size(344, 21);
            this.txtBindingExpression.TabIndex = 77;
            this.txtBindingExpression.TextChanged += new System.EventHandler(this.txtBindingExpression_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(0, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(357, 26);
            this.label3.TabIndex = 78;
            this.label3.Text = "Environment variables can be referenced in the format {$variable_name}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
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
            this.pnlEdit.Controls.Add(this.txtBindingExpression);
            this.pnlEdit.Controls.Add(this.label2);
            this.pnlEdit.Controls.Add(this.label3);
            this.pnlEdit.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pnlEdit.Location = new System.Drawing.Point(221, 12);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(362, 360);
            this.pnlEdit.TabIndex = 83;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnCancel.Location = new System.Drawing.Point(509, 395);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 84;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BindingExpressionEditorDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(595, 430);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstBindings);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label7);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BindingExpressionEditorDialog";
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
        private System.Windows.Forms.TextBox txtBindingExpression;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlEdit;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.ListBox lstBindings;
    }
}