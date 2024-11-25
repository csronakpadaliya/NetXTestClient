using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Neuron.UI
{
    // Summary:
    //     Specifies the name of the X.509 certificate store to open.
    public enum StoreName
    {
        //
        // Summary:
        //     The X.509 certificate store for third-party certificate authorities (CAs).
        AuthRoot = 2,
        //
        // Summary:
        //     The X.509 certificate store for intermediate certificate authorities (CAs).
        CertificateAuthority = 3,
        //
        // Summary:
        //     The X.509 certificate store for revoked certificates.
        Disallowed = 4,
        //
        // Summary:
        //     The X.509 certificate store for personal certificates.
        My = 5,
        //
        // Summary:
        //     The X.509 certificate store for trusted root certificate authorities (CAs).
        Root = 6,
        //
        // Summary:
        //     The X.509 certificate store for directly trusted people and resources.
        TrustedPeople = 7,
        //
        // Summary:
        //     The X.509 certificate store for directly trusted publishers.
        TrustedPublisher = 8,
    }
    public partial class SelectCertificate : Form
    {
        private bool startup = false;

        public SelectCertificate(Neuron.UI.StoreName storeName, StoreLocation storeLocation, X509FindType findType, string findValue)
        {
            InitializeComponent();

            cbStore.DataSource = Enum.GetValues(typeof(Neuron.UI.StoreName));
            //cbFindBy.DataSource = Enum.GetValues(typeof(X509FindType));
            cbFindBy.Items.Add(X509FindType.FindBySubjectDistinguishedName);
            cbFindBy.Items.Add(X509FindType.FindByThumbprint);
            cbFindBy.Items.Add(X509FindType.FindBySerialNumber);
            cbFindBy.Items.Add(X509FindType.FindByIssuerName);
            cbFindBy.Items.Add(X509FindType.FindByIssuerDistinguishedName);

            startup = true;
            rbMachine.Checked = (storeLocation == System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine);
            rbPersonal.Checked = (storeLocation == System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser);

            cbStore.Text = storeName.ToString();
            cbFindBy.Text = findType.ToString();

            FindValue = findValue;

            startup = false;
        }
        public SelectCertificate()
        {
            InitializeComponent();

            cbStore.DataSource = Enum.GetValues(typeof(Neuron.UI.StoreName));
            //cbFindBy.DataSource = Enum.GetValues(typeof(X509FindType));  
            
            cbFindBy.Items.Add(X509FindType.FindBySubjectDistinguishedName);
            cbFindBy.Items.Add(X509FindType.FindByThumbprint);
            cbFindBy.Items.Add(X509FindType.FindBySerialNumber);
            cbFindBy.Items.Add(X509FindType.FindByIssuerName);
            cbFindBy.Items.Add(X509FindType.FindByIssuerDistinguishedName);

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            refreshList();
            
        }

        class CertWrapper
        {
            public CertWrapper(X509Certificate2 cert)
            {
                Cert = cert;
            }

            public X509Certificate2 Cert
            {
                get;
                private set;
            }

            public override string ToString()
            {
                return Cert.GetNameInfo(X509NameType.SimpleName, false);
            }
        }

        void refreshList()
        {
            if (startup) return;

            X509Store store = new X509Store((System.Security.Cryptography.X509Certificates.StoreName)cbStore.SelectedItem, rbMachine.Checked ? StoreLocation.LocalMachine : StoreLocation.CurrentUser);
            
            try
            {
                store.Open(OpenFlags.OpenExistingOnly);
            }
            catch(CryptographicException ex)
            {
                Neuron.UI.ExceptionDialog.Show(this, "Store Unavailable", string.Format(CultureInfo.CurrentCulture,
                    "The '{0}' selected Certificate Store is unavailable on this machine", store.Name), ex, true);
                return;
            }
            lstCerts.DisplayMember = "FriendlyName";
            List<CertWrapper> list = new List<CertWrapper>();
            CertWrapper selected = null;
            foreach (var cert in store.Certificates)
            {
                list.Add(new CertWrapper(cert));

                if (GetValue(cert, this.FindType) == FindValue)
                {
                    selected = list.Last();
                }
                
            }
            list.Sort((a, b) => String.Compare(a.ToString(), b.ToString()));
            lstCerts.DataSource = list;
            if (selected != null)
            {
                lstCerts.SelectedItem = selected;
            }
            store.Close();

            btnPermissions.Enabled = false;
            if (lstCerts.SelectedItem != null)
            {
                try
                {
                    var key = ((CertWrapper)lstCerts.SelectedItem).Cert.GetRSAPrivateKey();
                    if (key != null && key is RSACng)
                        btnPermissions.Enabled = true;
                }
                catch (CryptographicException) { }

            } 
        }

        

        private void cbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshList();
        }

        private void cbStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshList();
        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshList();
        }

        string getFirstCn(string cn)
        {
            cn = cn.Substring(3);
            
            int sepIndex = cn.IndexOf(",");
            if(sepIndex > -1)
            {
            cn = cn.Substring(0, sepIndex);            
            }
            return cn;
        }

        private void lstCerts_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            Rectangle boxBounds = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 2);
            //e.DrawBackground();     
            Color backgroundColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected  ? Color.FromArgb(0xe0,0xf0,0xff) : Color.White;
            using(SolidBrush brush = new SolidBrush(backgroundColor))
            {
                e.Graphics.FillRectangle(brush, boxBounds);
                e.Graphics.DrawRectangle(Pens.White, boxBounds);
            }
            
            if(e.State == DrawItemState.Focus) e.DrawFocusRectangle();

            string expires;
            DateTime expiration = DateTime.Parse(((List<CertWrapper>)lstCerts.DataSource)[e.Index].Cert.GetExpirationDateString());
            TimeSpan timeTillExpiration = expiration - DateTime.Now;
            Color detailColor = Color.FromArgb(0x4,0x4,0x4);

            if (timeTillExpiration.TotalDays > 365)
            {
                expires = "Expires in " + ((int)timeTillExpiration.TotalDays / 365) + " years";
            }
            else if (timeTillExpiration.TotalDays > 30)
            {
                expires = "Expires in " + ((int)timeTillExpiration.TotalDays / 30) + " months";
            }
            else if (timeTillExpiration.TotalDays > 7)
            {
                expires = "Expires in " + ((int)timeTillExpiration.TotalDays / 30) + " weeks";
            }
            else if (timeTillExpiration.TotalDays > 1)
            {
                expires = "Expires in " + ((int)timeTillExpiration.TotalDays / 30) + " days";
            }
            else if (timeTillExpiration.TotalDays > 0)
            {
                expires = "Expires today";
            }
            else
            {                
                expires = "Expired on " + expiration;
                detailColor = Color.FromArgb(0xa0,0x00,0x00);
            }
            var cert = ((List<CertWrapper>)lstCerts.DataSource)[e.Index].Cert;

            string name = cert.GetNameInfo(X509NameType.SimpleName, false);
            string details = expires; // ((List<CertWrapper>)lstCerts.DataSource)[e.Index].Cert.Subject;

            if (expiration < DateTime.Now)
            {
                e.Graphics.DrawImage(Properties.Resources.ExpiredCert, e.Bounds.X + 1, e.Bounds.Y + 13);
                details += " (issued by " + getFirstCn(cert.Issuer) + ")";
            }
            else
            {
                if (cert.Issuer == cert.Subject)
                {
                    details += " (self signed)";
                    e.Graphics.DrawImage(Properties.Resources.SelfSignCert, e.Bounds.X + 1, e.Bounds.Y + 13);
                }
                else
                {                    
                    e.Graphics.DrawImage(Properties.Resources.Certificate, e.Bounds.X + 1, e.Bounds.Y + 13);
                    details += " (issued by " + getFirstCn(cert.Issuer)  + ")";
                }
            }

            e.Graphics.DrawString(name, Font, Brushes.Black, new Point(e.Bounds.X+18, e.Bounds.Y + 8));
            using (Font smallFont = new Font(Font.FontFamily, Font.Size * .80F))
            {                
                using(Brush detailBrush = new SolidBrush(detailColor))
                {
                    e.Graphics.DrawString(details, smallFont, detailBrush, new Point(e.Bounds.X+18, e.Bounds.Y+22));
                }
            }


            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                using (Pen pen = new Pen(Color.FromArgb(0xb0,0xc0,0xff), 1))
                {
                    e.Graphics.DrawRectangle(pen, boxBounds);
                }
            }
            else
            {
                using (Pen pen = new Pen(Color.LightGray, 1))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    e.Graphics.DrawLine(pen, 0, e.Bounds.Bottom - 1, e.Bounds.Width, e.Bounds.Bottom - 1);
                }
            }

        }

        protected string GetValue(X509Certificate2 cert, X509FindType findType)
        {
            switch (findType)
            {
                case X509FindType.FindBySubjectDistinguishedName:
                    return cert.SubjectName.Name;
                case X509FindType.FindByThumbprint:
                    return cert.Thumbprint;
                case X509FindType.FindBySerialNumber:
                    return cert.SerialNumber;
                case X509FindType.FindByIssuerName:
                    return cert.Issuer;
                case X509FindType.FindByIssuerDistinguishedName:
                    return cert.IssuerName.Name;
            }
            throw new NotSupportedException("The selected 'Find Type' is not supported for retrieving certificates");
        }

        private void lstCerts_DoubleClick(object sender, EventArgs e)
        {
            if(lstCerts.SelectedItem != null)
                X509Certificate2UI.DisplayCertificate(((CertWrapper)lstCerts.SelectedItem).Cert,this.Handle);

        }
        private void lstCerts_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPermissions.Enabled = false;
            if (lstCerts.SelectedItem != null)
            {
                try
                {
                    var key = ((CertWrapper)lstCerts.SelectedItem).Cert.GetRSAPrivateKey();
                    if (key != null && key is RSACng)
                        btnPermissions.Enabled = true;
                }
                catch (CryptographicException) { }

                FindValue = GetValue(((CertWrapper)lstCerts.SelectedItem).Cert, FindType);
            }                
        }

        private enum eShOPType : uint    
        {      
            SHOP_PRINTERNAME = 0x00000001, // lpObject points to a printer friendly name      
            SHOP_FILEPATH = 0x00000002, // lpObject points to a fully qualified path+file name      
            SHOP_VOLUMEGUID = 0x00000004 // lpObject points to a Volume GUID    
        };    
        [DllImport("shell32.dll", EntryPoint = "SHObjectProperties", CharSet = CharSet.Unicode)]    
        private static extern bool SHObjectProperties(IntPtr hwnd, eShOPType dwType, string szObject, string szPage);
        
        private void btnPermissions_Click(object sender, EventArgs e)
        {
            SHObjectProperties(Handle, eShOPType.SHOP_FILEPATH, CertificateUtil.GetFileInfo(((CertWrapper)lstCerts.SelectedItem).Cert).FullName, "Security");
        }

        public string FindValue
        {
            get;
            set;
        }

        public X509FindType FindType
        {
            get
            {
                if (cbFindBy.SelectedItem != null)
                    return (X509FindType)cbFindBy.SelectedItem;
                else
                    return X509FindType.FindByThumbprint;
            }
            set
            {
                cbFindBy.SelectedItem = value;
            }
        }

        public StoreName StoreName
        {
            get
            {
                return (StoreName)cbStore.SelectedItem;
            }
            set
            {
                cbStore.SelectedItem = value;
            }
        }

        public StoreLocation StoreLocation
        {
            get
            {
                return rbMachine.Checked ? StoreLocation.LocalMachine : StoreLocation.CurrentUser;
            }
            set
            {
                rbMachine.Checked = value == StoreLocation.LocalMachine;
                rbPersonal.Checked = !rbMachine.Checked;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void rbMachine_CheckedChanged(object sender, EventArgs e)
        {
            refreshList();
        }

        private void rbPersonal_CheckedChanged(object sender, EventArgs e)
        {
            refreshList();
        }

        private void btnFindTypeHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            toolTip1.Hide(btnFindTypeHelp);
            toolTip1.Show("'Find Type' is the method in which Neuron ESB will look up the certificate at runtime.", btnFindTypeHelp, 5, -5);
        }

        private void SelectCertificate_Click(object sender, EventArgs e)
        {
            toolTip1.Hide(btnFindTypeHelp);
        }
        
    }

	public class CertificateUtil
	{
        public static FileInfo GetFileInfo(X509Certificate2 cert)
        {
            RSACryptoServiceProvider rsa = cert.PrivateKey as RSACryptoServiceProvider;

            if (rsa != null)
            {
                string keyfilepath = FindKeyLocation(rsa.CspKeyContainerInfo.UniqueKeyContainerName);

                FileInfo file = new FileInfo(keyfilepath + "\\" +
                    rsa.CspKeyContainerInfo.UniqueKeyContainerName);

                return file;
            }
            return null;
        }

        
        private static void AddAccessToCertificate(X509Certificate2 cert, string user)
        {            
            FileInfo file = GetFileInfo(cert);
            if (file == null)
            {
                throw new FileNotFoundException();
            }

            FileSecurity fs = file.GetAccessControl();
            NTAccount account = new NTAccount(user);
            fs.AddAccessRule(new FileSystemAccessRule(account,
            FileSystemRights.FullControl, AccessControlType.Allow));
            file.SetAccessControl(fs);            
        }

        public static string FindKeyLocation(string keyFileName)
        {
            string text1 =
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string text2 = text1 + @"\Microsoft\Crypto\RSA\MachineKeys";
            string[] textArray1 = Directory.GetFiles(text2, keyFileName);
            if (textArray1.Length > 0)
            {
                return text2;
            }
            string text3 =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string text4 = text3 + @"\Microsoft\Crypto\RSA\";
            textArray1 = Directory.GetDirectories(text4);
            if (textArray1.Length > 0)
            {
                foreach (string text5 in textArray1)
                {
                    textArray1 = Directory.GetFiles(text5, keyFileName);
                    if (textArray1.Length != 0)
                    {
                        return text5;
                    }
                }
            }
            return "Private key exists but is not accessible";
        }

	}
}
