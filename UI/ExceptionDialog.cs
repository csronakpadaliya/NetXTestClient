namespace Neuron.UI
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public partial class ExceptionDialog : Form
    {
        public ExceptionDialog()
        {
            InitializeComponent();
            ResizeUtil.Initialize(this);
            SetDisplay(false, true);
        }

        public string AdditionalInformation
        {
            get;
            set;
        }

        Exception _exception;
        public Exception Exception
        {
            get
            {
                return _exception;
            }
            set
            {
                _exception = value;                
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (String.IsNullOrEmpty(Message))
            {
                if (_exception != null)
                {
                    txtMessage.Text = _exception.Message;
                }
                else
                {
                    txtMessage.Text = "";
                }
            }
            else
            {
                txtMessage.Text = Message;
            }

            btnMore.Visible = !HideDetails;

            StringBuilder sb = new StringBuilder();

            if (_exception != null)
            {
                sb.AppendLine("Exception Details");
                sb.AppendLine("-------------------------------------");
                sb.AppendLine(_exception.ToString());
            }

            if (!String.IsNullOrEmpty(AdditionalInformation))
            {
                sb.AppendLine("Additional Information");
                sb.AppendLine("-------------------------------------");
                sb.AppendLine(AdditionalInformation);
            }
            txtDetails.Text = sb.ToString();
        }

        const string moreText = "Show Details";
        const string lessText = "Hide Details";
        const int displayPadding = 10;

        bool _more;

        public void ToggleDisplay()
        {
            SetDisplay(!_more);
        }
        public void SetDisplay(bool more, bool calledFromConstructor = false)
        {
            //needs to give dpiScale as 1 if called from constructor since we scale after the constructor.
            var dpiScale = calledFromConstructor && (!ResizeUtil.StartedOnPrimaryScreen && DPIUtil.PrimaryScaleFactor(this) == 100.0) ? 1 : (float)DPIUtil.RawScaleFactor(GetActiveOwnerForm(this), GetActiveOwnerForm(this).Location) / 100;
            if (!more)
            {
                layout.RowStyles[1].Height = 0;
            }
            else
            {
                layout.RowStyles[1].Height = (int)(250 * dpiScale);
            }

            int height = 0;
            for (int i = 0; i < layout.RowStyles.Count; i++)
            {
                height += (int)layout.RowStyles[i].Height;
            }
            Height = height + 
                (int)(displayPadding * dpiScale) + 
                (int)(39 * dpiScale);

            btnMore.Text = more ? lessText : moreText;
            _more = more;
        }


        private void btnMore_Click(object sender, EventArgs e)
        {
            ToggleDisplay();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public string Message
        {
            get;
            set;
        }

        public bool HideDetails
        {
            get;
            set;
        }

        public static void Show(Exception ex)
        {
            ExceptionDialog dlg = new ExceptionDialog();
            dlg.Exception = ex;
            dlg.StartPosition = FormStartPosition.CenterParent;
            ResizeUtil.ScaleAll(dlg);

            dlg.ShowDialog();
        }

        public static void Show(string title, Exception ex)
        {
            ExceptionDialog dlg = new ExceptionDialog();
            dlg.Text = title;
            dlg.Exception = ex;
            dlg.StartPosition = FormStartPosition.CenterParent;
            ResizeUtil.ScaleAll(dlg);

            dlg.ShowDialog();
        }

        public static void Show(string title, string message, Exception ex)
        {
            ExceptionDialog dlg = new ExceptionDialog();
            dlg.Text = title;
            dlg.Message = message; 
            dlg.Exception = ex;
            dlg.StartPosition = FormStartPosition.CenterParent;
            ResizeUtil.ScaleAll(dlg);

            dlg.ShowDialog();
        }

        /// <summary>
        /// this will center the form , if passing in owner
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        /// <param name="hideDetails"></param>
        public static void Show(Form owner, string title, string message, Exception ex, bool hideDetails)
        {
            //If form handle is yet not created then find current active form if found.
            owner = GetActiveOwnerForm(owner); 
            ExceptionDialog dlg = new ExceptionDialog();
            dlg.Text = title;
            dlg.Message = message;
            dlg.Exception = ex;
            dlg.HideDetails = hideDetails;
            Point p = new Point((owner.Location.X + (owner.Width / 2)) - (dlg.Width / 2), (owner.Location.Y + (owner.Height / 2)) - (dlg.Height / 2));
            dlg.Location = p;
            ResizeUtil.ScaleAll(dlg);

            dlg.ShowDialog(owner);
        }

        public enum iConDialogEnum
        {
            Warning = 0,
            Info = 1,
            Error = 2
        }
        public static void Show(Form owner, string title, string message, Exception ex, bool hideDetails, iConDialogEnum icon)
        {
            //If form handle is yet not created then find current active form if found.
            owner = GetActiveOwnerForm(owner);

            ExceptionDialog dlg = new ExceptionDialog();

            switch (icon)
            {
                case iConDialogEnum.Warning: // warning
                    dlg.pictureBox1.Visible = false;
                    dlg.pictureBoxWarning.Visible = true;
                    dlg.pictureBoxInfo.Visible = false;
                    break;
                case iConDialogEnum.Info:
                    dlg.pictureBox1.Visible = false;
                    dlg.pictureBoxWarning.Visible = false;
                    dlg.pictureBoxInfo.Visible = true;
                    break;
                default:
                    break;
            }
            dlg.Text = title;
            dlg.Message = message;
            dlg.Exception = ex;
            dlg.HideDetails = hideDetails;
            Point p = new Point((owner.Location.X + (owner.Width / 2)) - (dlg.Width / 2), (owner.Location.Y + (owner.Height / 2)) - (dlg.Height / 2));
            dlg.Location = p;
            ResizeUtil.ScaleAll(dlg);

            dlg.ShowDialog(owner);
        }

        public static void Show(IWin32Window owner, string title, string message, Exception ex, bool hideDetails, iConDialogEnum icon)
        {
            ExceptionDialog dlg = new ExceptionDialog();

            switch (icon)
            {
                case iConDialogEnum.Warning: // warning
                    dlg.pictureBox1.Visible = false;
                    dlg.pictureBoxWarning.Visible = true;
                    dlg.pictureBoxInfo.Visible = false;
                    break;
                case iConDialogEnum.Info:
                    dlg.pictureBox1.Visible = false;
                    dlg.pictureBoxWarning.Visible = false;
                    dlg.pictureBoxInfo.Visible = true;
                    break;
                default:
                    break;
            }
            dlg.Text = title;
            dlg.Message = message;
            dlg.Exception = ex;
            dlg.HideDetails = hideDetails;
            dlg.StartPosition = FormStartPosition.CenterScreen;
            ResizeUtil.ScaleAll(dlg);

            dlg.ShowDialog(owner);
        }
        public static void Show(string title, string message, Exception ex, bool hideDetails)
        {
            ExceptionDialog dlg = new ExceptionDialog();
            dlg.Text = title;
            dlg.Message = message;
            dlg.Exception = ex;
            dlg.HideDetails = hideDetails;
            ResizeUtil.ScaleAll(dlg);

            dlg.ShowDialog();
        }

        public static void Show(string title, string message, string additionalInformation, Exception ex, bool hideDetails)
        {
            ExceptionDialog dlg = new ExceptionDialog();
            dlg.Text = title;
            dlg.Message = message;
            dlg.AdditionalInformation = additionalInformation;
            dlg.Exception = ex;
            dlg.HideDetails = hideDetails;
            ResizeUtil.ScaleAll(dlg);

            dlg.ShowDialog();
        }

        public static void Show(string title, string message, string additionalInformation, Exception ex, bool hideDetails, iConDialogEnum icon)
        {
            ExceptionDialog dlg = new ExceptionDialog();

            switch (icon)
            {
                case iConDialogEnum.Warning: // warning
                    dlg.pictureBox1.Visible = false;
                    dlg.pictureBoxWarning.Visible = true;
                    dlg.pictureBoxInfo.Visible = false;
                    break;
                case iConDialogEnum.Info:
                    dlg.pictureBox1.Visible = false;
                    dlg.pictureBoxWarning.Visible = false;
                    dlg.pictureBoxInfo.Visible = true;
                    break;
                default:
                    break;
            }

            dlg.Text = title;
            dlg.Message = message;
            dlg.AdditionalInformation = additionalInformation;
            dlg.Exception = ex;
            dlg.HideDetails = hideDetails;
            ResizeUtil.ScaleAll(dlg);

            dlg.ShowDialog();
        }

        /// <summary>
        /// If owner form handle is yet not created, then try to use 
        /// Form.ActiveForm static memeber if not null and has handle, othewise it will use input owner form as default.
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static Form GetActiveOwnerForm(Form owner)
        {
            if (owner.IsHandleCreated)
            {
                return owner;
            }
            else if (Form.ActiveForm != null && (Form.ActiveForm.IsHandleCreated))
            {
                return Form.ActiveForm;
            }
            else
            {
                //Need to handle it better, but for now keep same owner form.
                return owner;
            }
        }

        /// <summary>
        /// If for any such cases where form is constructed properly but error comes at dialog.show()
        /// then use of active form is better to avoid miss alignment of error box
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static Form GetActiveForm(Form owner)
        {
            Form activeForm = Form.ActiveForm;
            if (activeForm == null)
            {
                activeForm = owner;
            }
            return activeForm;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            var t = new System.Threading.Thread(copytoClipboardThreadSafe);
            t.IsBackground = true;
            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.Start();

            
        }

        private void btnGrab_Click(object sender, EventArgs e)
        {

        }

        private void copytoClipboardThreadSafe()
        {
            Clipboard.SetText(txtDetails.Text);
        }
        private void btnSupport_Click(object sender, EventArgs e)
        {
            Process.Start(SupportUrl);
        }

        public const string SupportUrl = "http://support.peregrineconnect.com/";

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMessage_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
