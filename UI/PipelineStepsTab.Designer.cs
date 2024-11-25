namespace Neuron.Pipelines.Design
{
    partial class PipelineStepsTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PipelineStepsTab));
            this.tvSteps = new System.Windows.Forms.TreeView();
            this.stepImageList = new System.Windows.Forms.ImageList(this.components);
            this.labelPipelineStepsTitle = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tvSteps
            // 
            this.tvSteps.AllowDrop = true;
            this.tvSteps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvSteps.ImageIndex = 0;
            this.tvSteps.ImageList = this.stepImageList;
            this.tvSteps.ItemHeight = 20;
            this.tvSteps.LabelEdit = true;
            this.tvSteps.Location = new System.Drawing.Point(0, 38);
            this.tvSteps.Name = "tvSteps";
            this.tvSteps.SelectedImageIndex = 0;
            this.tvSteps.ShowLines = false;
            this.tvSteps.ShowNodeToolTips = true;
            this.tvSteps.Size = new System.Drawing.Size(372, 532);
            this.tvSteps.TabIndex = 11;
            this.tvSteps.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvSteps_AfterCollapse);
            this.tvSteps.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvSteps_AfterExpand);
            this.tvSteps.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvSteps_ItemDrag);
            // 
            // stepImageList
            // 
            this.stepImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("stepImageList.ImageStream")));
            this.stepImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.stepImageList.Images.SetKeyName(0, "book.png");
            this.stepImageList.Images.SetKeyName(1, "package.png");
            this.stepImageList.Images.SetKeyName(2, "folder.png");
            this.stepImageList.Images.SetKeyName(3, "folder_closed.png");
            this.stepImageList.Images.SetKeyName(4, "folder_closed_add.png");
            this.stepImageList.Images.SetKeyName(5, "document-open-folder.png");
            this.stepImageList.Images.SetKeyName(6, "folder1.png");
            this.stepImageList.Images.SetKeyName(7, "folder-new-7.png");
            // 
            // labelPipelineStepsTitle
            // 
            this.labelPipelineStepsTitle.BackColor = System.Drawing.Color.DimGray;
            this.labelPipelineStepsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPipelineStepsTitle.ForeColor = System.Drawing.Color.White;
            this.labelPipelineStepsTitle.Location = new System.Drawing.Point(0, 0);
            this.labelPipelineStepsTitle.Name = "labelPipelineStepsTitle";
            this.labelPipelineStepsTitle.Size = new System.Drawing.Size(372, 20);
            this.labelPipelineStepsTitle.TabIndex = 13;
            this.labelPipelineStepsTitle.Text = "Process Steps";
            this.labelPipelineStepsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 20);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(372, 18);
            this.textBox1.TabIndex = 14;
            // 
            // PipelineStepsTab
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96.0F, 96.0F);
            this.Controls.Add(this.tvSteps);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelPipelineStepsTitle);
            this.Name = "PipelineStepsTab";
            this.Size = new System.Drawing.Size(372, 570);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvSteps;
        private System.Windows.Forms.ImageList stepImageList;
        private System.Windows.Forms.Label labelPipelineStepsTitle;
        private System.Windows.Forms.TextBox textBox1;
    }
}
