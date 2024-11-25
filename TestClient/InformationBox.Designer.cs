namespace Neuron.TestClient
{
    partial class InformationBox
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
            this.textBoxInformation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxInformation
            // 
            this.textBoxInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInformation.Location = new System.Drawing.Point(0, 0);
            this.textBoxInformation.Multiline = true;
            this.textBoxInformation.Name = "textBoxInformation";
            this.textBoxInformation.Size = new System.Drawing.Size(508, 279);
            this.textBoxInformation.TabIndex = 0;
            // 
            // InformationBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(508, 279);
            this.Controls.Add(this.textBoxInformation);
            this.Name = "InformationBox";
            this.ShowIcon = false;
            this.Text = "Information Box";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInformation;

    }
}