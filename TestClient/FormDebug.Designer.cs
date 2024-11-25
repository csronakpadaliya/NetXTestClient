//using ActiproSoftware.Text;

namespace Neuron.TestClient
{
    partial class FormDebug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDebug));
            panelDebugTop = new System.Windows.Forms.Panel();
            labelEventDesc = new System.Windows.Forms.Label();
            labelEventType = new System.Windows.Forms.Label();
            panelDebugBottom = new System.Windows.Forms.Panel();
            checkBoxCompleteTx = new System.Windows.Forms.CheckBox();
            panelBottomRight = new System.Windows.Forms.Panel();
            buttonCopyMessage = new System.Windows.Forms.Button();
            buttonContinueWithoutDebugging = new System.Windows.Forms.Button();
            buttonClose = new System.Windows.Forms.Button();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            labelEventDetail = new System.Windows.Forms.Label();
            listViewEventDetail = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            xmlEditorBody = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            panelDebugTop.SuspendLayout();
            panelDebugBottom.SuspendLayout();
            panelBottomRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // panelDebugTop
            // 
            panelDebugTop.Controls.Add(labelEventDesc);
            panelDebugTop.Controls.Add(labelEventType);
            panelDebugTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelDebugTop.Location = new System.Drawing.Point(0, 0);
            panelDebugTop.Name = "panelDebugTop";
            panelDebugTop.Size = new System.Drawing.Size(563, 47);
            panelDebugTop.TabIndex = 0;
            // 
            // labelEventDesc
            // 
            labelEventDesc.AutoSize = true;
            labelEventDesc.Location = new System.Drawing.Point(8, 28);
            labelEventDesc.Name = "labelEventDesc";
            labelEventDesc.Size = new System.Drawing.Size(120, 13);
            labelEventDesc.TabIndex = 3;
            labelEventDesc.Text = "Client event description";
            // 
            // labelEventType
            // 
            labelEventType.AutoSize = true;
            labelEventType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelEventType.Location = new System.Drawing.Point(8, 8);
            labelEventType.Name = "labelEventType";
            labelEventType.Size = new System.Drawing.Size(76, 13);
            labelEventType.TabIndex = 2;
            labelEventType.Text = "Client Event";
            // 
            // panelDebugBottom
            // 
            panelDebugBottom.Controls.Add(checkBoxCompleteTx);
            panelDebugBottom.Controls.Add(panelBottomRight);
            panelDebugBottom.Controls.Add(buttonContinueWithoutDebugging);
            panelDebugBottom.Controls.Add(buttonClose);
            panelDebugBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelDebugBottom.Location = new System.Drawing.Point(0, 361);
            panelDebugBottom.Name = "panelDebugBottom";
            panelDebugBottom.Size = new System.Drawing.Size(563, 39);
            panelDebugBottom.TabIndex = 1;
            // 
            // checkBoxCompleteTx
            // 
            checkBoxCompleteTx.AutoSize = true;
            checkBoxCompleteTx.Checked = true;
            checkBoxCompleteTx.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxCompleteTx.Location = new System.Drawing.Point(278, 12);
            checkBoxCompleteTx.Name = "checkBoxCompleteTx";
            checkBoxCompleteTx.Size = new System.Drawing.Size(130, 17);
            checkBoxCompleteTx.TabIndex = 5;
            checkBoxCompleteTx.Text = "Complete Transaction";
            checkBoxCompleteTx.UseVisualStyleBackColor = true;
            checkBoxCompleteTx.Visible = false;
            // 
            // panelBottomRight
            // 
            panelBottomRight.Controls.Add(buttonCopyMessage);
            panelBottomRight.Dock = System.Windows.Forms.DockStyle.Right;
            panelBottomRight.Location = new System.Drawing.Point(481, 0);
            panelBottomRight.Name = "panelBottomRight";
            panelBottomRight.Size = new System.Drawing.Size(82, 39);
            panelBottomRight.TabIndex = 2;
            panelBottomRight.Paint += panelBottomRight_Paint;
            // 
            // buttonCopyMessage
            // 
            buttonCopyMessage.Location = new System.Drawing.Point(13, 8);
            buttonCopyMessage.Name = "buttonCopyMessage";
            buttonCopyMessage.Size = new System.Drawing.Size(59, 23);
            buttonCopyMessage.TabIndex = 14;
            buttonCopyMessage.Text = "Copy";
            buttonCopyMessage.UseVisualStyleBackColor = true;
            buttonCopyMessage.Click += buttonCopyMessage_Click;
            // 
            // buttonContinueWithoutDebugging
            // 
            buttonContinueWithoutDebugging.Location = new System.Drawing.Point(90, 8);
            buttonContinueWithoutDebugging.Name = "buttonContinueWithoutDebugging";
            buttonContinueWithoutDebugging.Size = new System.Drawing.Size(168, 23);
            buttonContinueWithoutDebugging.TabIndex = 1;
            buttonContinueWithoutDebugging.Text = "Continue without Debugging";
            buttonContinueWithoutDebugging.UseVisualStyleBackColor = true;
            buttonContinueWithoutDebugging.Click += buttonContinueWithoutDebugging_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new System.Drawing.Point(8, 8);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new System.Drawing.Size(75, 23);
            buttonClose.TabIndex = 0;
            buttonClose.Text = "Continue";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 47);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(labelEventDetail);
            splitContainer1.Panel1.Controls.Add(listViewEventDetail);
            splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8, 24, 8, 8);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(xmlEditorBody);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(8, 32, 8, 8);
            splitContainer1.Size = new System.Drawing.Size(563, 314);
            splitContainer1.SplitterDistance = 187;
            splitContainer1.TabIndex = 2;
            // 
            // labelEventDetail
            // 
            labelEventDetail.AutoSize = true;
            labelEventDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelEventDetail.Location = new System.Drawing.Point(8, 8);
            labelEventDetail.Name = "labelEventDetail";
            labelEventDetail.Size = new System.Drawing.Size(77, 13);
            labelEventDetail.TabIndex = 10;
            labelEventDetail.Text = "Event Detail";
            // 
            // listViewEventDetail
            // 
            listViewEventDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewEventDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewEventDetail.GridLines = true;
            listViewEventDetail.Location = new System.Drawing.Point(8, 24);
            listViewEventDetail.Name = "listViewEventDetail";
            listViewEventDetail.Scrollable = false;
            listViewEventDetail.Size = new System.Drawing.Size(171, 282);
            listViewEventDetail.TabIndex = 9;
            listViewEventDetail.UseCompatibleStateImageBehavior = false;
            listViewEventDetail.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Property";
            columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Value";
            columnHeader2.Width = 240;
            // 
            // xmlEditorBody
            // 
            xmlEditorBody.Location = new System.Drawing.Point(8, 35);
            xmlEditorBody.Multiline = true;
            xmlEditorBody.Name = "xmlEditorBody";
            xmlEditorBody.Size = new System.Drawing.Size(354, 268);
            xmlEditorBody.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(8, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(89, 13);
            label1.TabIndex = 7;
            label1.Text = "Message Body";
            // 
            // FormDebug
            // 
            AcceptButton = buttonClose;
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(563, 400);
            Controls.Add(splitContainer1);
            Controls.Add(panelDebugBottom);
            Controls.Add(panelDebugTop);
            Font = new System.Drawing.Font("Tahoma", 8.25F);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormDebug";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ESB Client Event";
            Load += FormDebug_Load;
            panelDebugTop.ResumeLayout(false);
            panelDebugTop.PerformLayout();
            panelDebugBottom.ResumeLayout(false);
            panelDebugBottom.PerformLayout();
            panelBottomRight.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelDebugTop;
        public System.Windows.Forms.Label labelEventDesc;
        public System.Windows.Forms.Label labelEventType;
        private System.Windows.Forms.Panel panelDebugBottom;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonContinueWithoutDebugging;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.ListView listViewEventDetail;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelEventDetail;
        private System.Windows.Forms.Panel panelBottomRight;
        private System.Windows.Forms.Button buttonCopyMessage;
        //private ActiproSoftware.Text.Languages.Xml.Implementation.XmlSyntaxLanguage xmlSyntaxLanguage1;
        public System.Windows.Forms.CheckBox checkBoxCompleteTx;
        public Neuron.UI.HexBox hexBoxReceive;
        public System.Windows.Forms.TextBox xmlEditorBody;
    }
}