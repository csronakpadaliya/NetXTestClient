using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Neuron.TestClient
{
    /// <summary>
    /// Summary description for InputBox.
    /// 
    public class InputBox : System.Windows.Forms.Form
    {

        #region Windows Contols and Constructor

        private Panel panelMain;
        private Label labelSpacer;
        private Label labelCaption;
        private Label labelSpacer2;
        private TextBox txtInput;
        private Label labelPrompt;
        private Panel panelButtons;
        private Button buttonCancel;
        private Label labelSpacer3;
        private Button btnOK;
        /// <summary>
        /// Required designer variable.
        /// 
        private System.ComponentModel.Container components = null;

        public InputBox()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// 
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelSpacer3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.labelPrompt = new System.Windows.Forms.Label();
            this.labelSpacer2 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.labelSpacer = new System.Windows.Forms.Label();
            this.labelCaption = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelButtons);
            this.panelMain.Controls.Add(this.labelPrompt);
            this.panelMain.Controls.Add(this.labelSpacer2);
            this.panelMain.Controls.Add(this.txtInput);
            this.panelMain.Controls.Add(this.labelSpacer);
            this.panelMain.Controls.Add(this.labelCaption);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(10);
            this.panelMain.Size = new System.Drawing.Size(398, 128);
            this.panelMain.TabIndex = 5;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonCancel);
            this.panelButtons.Controls.Add(this.labelSpacer3);
            this.panelButtons.Controls.Add(this.btnOK);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(10, 88);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(378, 30);
            this.panelButtons.TabIndex = 10;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonCancel.Location = new System.Drawing.Point(85, 0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 30);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelSpacer3
            // 
            this.labelSpacer3.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelSpacer3.Location = new System.Drawing.Point(75, 0);
            this.labelSpacer3.Name = "labelSpacer3";
            this.labelSpacer3.Size = new System.Drawing.Size(10, 30);
            this.labelSpacer3.TabIndex = 10;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOK.Location = new System.Drawing.Point(0, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelPrompt
            // 
            this.labelPrompt.AutoSize = true;
            this.labelPrompt.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPrompt.Location = new System.Drawing.Point(10, 63);
            this.labelPrompt.Name = "labelPrompt";
            this.labelPrompt.Size = new System.Drawing.Size(0, 13);
            this.labelPrompt.TabIndex = 9;
            // 
            // labelSpacer2
            // 
            this.labelSpacer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSpacer2.Location = new System.Drawing.Point(10, 53);
            this.labelSpacer2.Name = "labelSpacer2";
            this.labelSpacer2.Size = new System.Drawing.Size(378, 10);
            this.labelSpacer2.TabIndex = 8;
            // 
            // txtInput
            // 
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtInput.Location = new System.Drawing.Point(10, 33);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(378, 20);
            this.txtInput.TabIndex = 7;
            // 
            // labelSpacer
            // 
            this.labelSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSpacer.Location = new System.Drawing.Point(10, 23);
            this.labelSpacer.Name = "labelSpacer";
            this.labelSpacer.Size = new System.Drawing.Size(378, 10);
            this.labelSpacer.TabIndex = 6;
            // 
            // labelCaption
            // 
            this.labelCaption.AutoSize = true;
            this.labelCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCaption.Location = new System.Drawing.Point(10, 10);
            this.labelCaption.Name = "labelCaption";
            this.labelCaption.Size = new System.Drawing.Size(0, 13);
            this.labelCaption.TabIndex = 5;
            // 
            // InputBox
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(398, 128);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputBox";
            this.Load += new System.EventHandler(this.InputBox_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Private Variables
        string formCaption = string.Empty;
        string formPrompt = string.Empty;
        string inputResponse = string.Empty;
        string defaultValue = string.Empty;
        #endregion

        #region Public Properties
        public string FormCaption
        {
            get { return formCaption; }
            set { formCaption = value; }
        } // property FormCaption
        public string FormPrompt
        {
            get { return formPrompt; }
            set { formPrompt = value; }
        } // property FormPrompt
        public string InputResponse
        {
            get { return inputResponse; }
            set { inputResponse = value; }
        } // property InputResponse
        public string DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        } // property DefaultValue

        #endregion

        #region Form and Control Events
        private void InputBox_Load(object sender, System.EventArgs e)
        {
            this.txtInput.Text = defaultValue;
            this.labelCaption.Text = formCaption;
            this.labelPrompt.Text = formPrompt;
            this.Text = formCaption;
            this.txtInput.SelectionStart = 0;
            this.txtInput.SelectionLength = this.txtInput.Text.Length;
            this.txtInput.Focus();
        }


        private void btnOK_Click(object sender, System.EventArgs e)
        {
            InputResponse = this.txtInput.Text;
            this.Close();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion


    }

}
