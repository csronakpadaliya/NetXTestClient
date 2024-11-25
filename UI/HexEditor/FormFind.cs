using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Neuron.UI
{
    /// <summary>
    ///     Summary description for FormFind.
    /// </summary>
    public class FormFind : Form
    {
        private FindOptions _findOptions;
        private bool _finding;
        private Button btnCancel;
        private Button btnOK;
        private CheckBox chkMatchCase;
        private IContainer components;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox groupBox1;
        private HexBox hexFind;
        private Label label1;
        private Label lblFinding;
        private Label lblPercent;
        private RadioButton rbHex;
        private RadioButton rbString;
        private Timer timer;
        private Timer timerPercent;
        private TextBox txtFind;

        public FormFind()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            rbString.CheckedChanged += rb_CheckedChanged;
            rbHex.CheckedChanged += rb_CheckedChanged;
        }

        public FindOptions FindOptions
        {
            get { return _findOptions; }
            set
            {
                _findOptions = value;
                Reinitialize();
            }
        }

        public HexBox HexBox { get; set; }

        private void ByteProvider_Changed(object sender, EventArgs e)
        {
            ValidateFind();
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
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

        private void Reinitialize()
        {
            rbString.Checked = _findOptions.Type == FindType.Text;
            txtFind.Text = _findOptions.Text;
            chkMatchCase.Checked = _findOptions.MatchCase;

            rbHex.Checked = _findOptions.Type == FindType.Hex;

            if (hexFind.ByteProvider != null)
                hexFind.ByteProvider.Changed -= new EventHandler(ByteProvider_Changed);

            var hex = _findOptions.Hex != null ? _findOptions.Hex : new byte[0];
            hexFind.ByteProvider = new DynamicByteProvider(hex);
            hexFind.ByteProvider.Changed += new EventHandler(ByteProvider_Changed);
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            txtFind.Enabled = rbString.Checked;
            hexFind.Enabled = !txtFind.Enabled;

            if (txtFind.Enabled)
                txtFind.Focus();
            else
                hexFind.Focus();
        }

        private void rbString_Enter(object sender, EventArgs e)
        {
            txtFind.Focus();
        }

        private void rbHex_Enter(object sender, EventArgs e)
        {
            hexFind.Focus();
        }

        private void FormFind_Activated(object sender, EventArgs e)
        {
            if (rbString.Checked)
                txtFind.Focus();
            else
                hexFind.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _findOptions.MatchCase = chkMatchCase.Checked;

            var provider = hexFind.ByteProvider as DynamicByteProvider;
            _findOptions.Hex = provider.Bytes.ToArray();
            _findOptions.Text = txtFind.Text;
            _findOptions.Type = rbHex.Checked ? FindType.Hex : FindType.Text;
            _findOptions.MatchCase = chkMatchCase.Checked;
            _findOptions.IsValid = true;

            FindNext();
        }

        public void FindNext()
        {
            if (!_findOptions.IsValid)
                return;

            UpdateUIToFindingState();

            // start find process
            long res = HexBox.Find(_findOptions);

            UpdateUIToNormalState();

            Application.DoEvents();

            if (res == -1) // -1 = no match
            {
                MessageBox.Show(strings.FindOperationEndOfFile, Util.SoftwareName,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (res == -2) // -2 = find was aborted
            {
            }
            else // something was found
            {
                Close();

                Application.DoEvents();

                if (!HexBox.Focused)
                    HexBox.Focus();
            }
        }

        private void UpdateUIToNormalState()
        {
            timer.Stop();
            timerPercent.Stop();
            _finding = false;
            txtFind.Enabled = chkMatchCase.Enabled = rbHex.Enabled = rbString.Enabled
                = hexFind.Enabled = btnOK.Enabled = true;
        }

        private void UpdateUIToFindingState()
        {
            _finding = true;
            timer.Start();
            timerPercent.Start();
            txtFind.Enabled = chkMatchCase.Enabled = rbHex.Enabled = rbString.Enabled
                = hexFind.Enabled = btnOK.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_finding)
                HexBox.AbortFind();
            else
                Close();
        }

        private void txtString_TextChanged(object sender, EventArgs e)
        {
            ValidateFind();
        }

        private void ValidateFind()
        {
            bool isValid = false;
            if (rbString.Checked && txtFind.Text.Length > 0)
                isValid = true;
            if (rbHex.Checked && hexFind.ByteProvider.Length > 0)
                isValid = true;
            btnOK.Enabled = isValid;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (lblFinding.Text.Length == 13)
                lblFinding.Text = "";

            lblFinding.Text += ".";
        }

        private void timerPercent_Tick(object sender, EventArgs e)
        {
            long pos = HexBox.CurrentFindingPosition;
            long length = HexBox.ByteProvider.Length;
            double percent = pos/(double) length*100;

            NumberFormatInfo nfi =
                new CultureInfo("en-US").NumberFormat;

            string text = percent.ToString("0.00", nfi) + " %";
            lblPercent.Text = text;
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof (FormFind));
            this.txtFind = new System.Windows.Forms.TextBox();
            this.rbString = new System.Windows.Forms.RadioButton();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblFinding = new System.Windows.Forms.Label();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.timerPercent = new System.Windows.Forms.Timer(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.hexFind = new HexBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFind
            // 
            resources.ApplyResources(this.txtFind, "txtFind");
            this.txtFind.Name = "txtFind";
            this.txtFind.TextChanged += new System.EventHandler(this.txtString_TextChanged);
            // 
            // rbString
            // 
            resources.ApplyResources(this.rbString, "rbString");
            this.rbString.Checked = true;
            this.rbString.Name = "rbString";
            this.rbString.TabStop = true;
            // 
            // rbHex
            // 
            resources.ApplyResources(this.rbHex, "rbHex");
            this.rbHex.Name = "rbHex";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Name = "label1";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lblPercent
            // 
            resources.ApplyResources(this.lblPercent, "lblPercent");
            this.lblPercent.Name = "lblPercent";
            // 
            // lblFinding
            // 
            resources.ApplyResources(this.lblFinding, "lblFinding");
            this.lblFinding.ForeColor = System.Drawing.Color.Blue;
            this.lblFinding.Name = "lblFinding";
            // 
            // chkMatchCase
            // 
            resources.ApplyResources(this.chkMatchCase, "chkMatchCase");
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // timerPercent
            // 
            this.timerPercent.Tick += new System.EventHandler(this.timerPercent_Tick);
            // 
            // timer
            // 
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // hexFind
            // 
            resources.ApplyResources(this.hexFind, "hexFind");
            // 
            // 
            // 
            this.hexFind.BuiltInContextMenu.CopyMenuItemImage = global::Neuron.UI.images.CopyHS;
            this.hexFind.BuiltInContextMenu.CopyMenuItemText =
                resources.GetString("hexFind.BuiltInContextMenu.CopyMenuItemText");
            this.hexFind.BuiltInContextMenu.CutMenuItemImage = global::Neuron.UI.images.CutHS;
            this.hexFind.BuiltInContextMenu.CutMenuItemText =
                resources.GetString("hexFind.BuiltInContextMenu.CutMenuItemText");
            this.hexFind.BuiltInContextMenu.PasteMenuItemImage = global::Neuron.UI.images.PasteHS;
            this.hexFind.BuiltInContextMenu.PasteMenuItemText =
                resources.GetString("hexFind.BuiltInContextMenu.PasteMenuItemText");
            this.hexFind.BuiltInContextMenu.SelectAllMenuItemText =
                resources.GetString("hexFind.BuiltInContextMenu.SelectAllMenuItemText");
            this.hexFind.InfoForeColor = System.Drawing.Color.Empty;
            this.hexFind.Name = "hexFind";
            this.hexFind.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int) (((byte) (100)))),
                ((int) (((byte) (60)))), ((int) (((byte) (188)))), ((int) (((byte) (255)))));
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // FormFind
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.chkMatchCase);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.lblFinding);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rbHex);
            this.Controls.Add(this.rbString);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.hexFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFind";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Activated += new System.EventHandler(this.FormFind_Activated);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}