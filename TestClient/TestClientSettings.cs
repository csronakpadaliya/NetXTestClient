using System;
using System.Windows.Forms;
using Neuron.NetX.Discovery;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace Neuron.TestClient
{
    public partial class TestClientSettings : Form
    {
        private Dictionary<string, InstanceRegistration> neuronRuntimes = null;
        private Neuron.NetX.Discovery.RuntimeDiscovery runtimeDiscovery = null;

        public string InstanceName { get; set; }
        public string Machine { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string ServiceIdentity { get; set; }
        public TestClientSettings()
        {
            InitializeComponent();

            runtimeDiscovery = new Neuron.NetX.Discovery.RuntimeDiscovery(null);
            neuronRuntimes = runtimeDiscovery.NeuronEsbInstances();

            this.textBoxConnectServer.Enabled = true;
            this.textBoxPort.Enabled = true;
            this.comboBoxInstance.Enabled = true;          
        }
        private void EnableConnect()
        {
            if (this.Port > 1000 && this.Port < 65535 && !string.IsNullOrEmpty(this.Machine) && !string.IsNullOrEmpty(this.InstanceName))
                this.buttonOk.Enabled = true;
            else
                this.buttonOk.Enabled = false;

        }
        private void TestClientSettings_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
        }

        
        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Machine = this.textBoxConnectServer.Text.Trim();
            this.InstanceName = this.comboBoxInstance.Text.Trim();
            this.Username = this.textBoxUsername.Text.Trim();
            this.Password = this.textBoxPassword.Text.Trim();
            this.Domain = this.textBoxDomain.Text.Trim();
            this.ServiceIdentity = this.textBoxIdentity.Text.Trim();

            int port;
            try
            {
                if (int.TryParse(this.textBoxPort.Text.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out port))
                {
                    if (port < 1000 || port > 65535)
                    {
                        throw new Exception(
                            "The Neuron ESB Boostrap port must be a number between 1000 and 65535.");
                    }

                    this.Port = port;

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    throw new Exception(
                        "The Neuron ESB Boostrap port must be a number less than 65535.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Validation Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void textBoxPort_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int port;
                if (int.TryParse(this.textBoxPort.Text.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out port))
                {
                    if (port < 1000 || port > 65535)
                    {
                        throw new Exception(
                            "The Neuron ESB Boostrap port must be a number between 1000 and 65535.");
                    }

                    this.Port = port;
                }
                else
                {
                    throw new Exception(
                        "The Neuron ESB Boostrap port must be a number less than 65535.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Validation Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            EnableConnect();
        }

        private void textBoxConnectServer_TextChanged(object sender, EventArgs e)
        {
            this.buttonOk.Enabled = false;
            this.comboBoxInstance.Items.Clear();
            this.comboBoxInstance.Text = "";

            // if the server is the local machine, then find it in the list of local runtimes and populate the instances
            this.Machine = textBoxConnectServer.Text.Trim();

            if (!string.IsNullOrEmpty(this.Machine))
            {
                if (Neuron.NetX.Internal.ESBHelper.IsLocalMachine(this.Machine))
                {
                    if (neuronRuntimes.Count > 0)
                    {
                        var tempMachine = neuronRuntimes.First().Value.MachineName;
                        if (Neuron.NetX.Internal.ESBHelper.IsLocalMachine(tempMachine))
                        {
                            foreach (var runtime in neuronRuntimes)
                                this.comboBoxInstance.Items.Add(runtime.Value.Name);
                        }
                        else
                        {
                            // repopulate with local instance
                            neuronRuntimes = runtimeDiscovery.NeuronEsbInstances();
                            foreach (var runtime in neuronRuntimes)
                                this.comboBoxInstance.Items.Add(runtime.Value.Name);
                        }
                    }
                    else
                    {
                        // repopulate with local instances
                        neuronRuntimes = runtimeDiscovery.NeuronEsbInstances();
                        foreach (var runtime in neuronRuntimes)
                            this.comboBoxInstance.Items.Add(runtime.Value.Name);
                    }
                }
            }
            EnableConnect();
        }

        private void comboBoxInstance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxInstance.SelectedIndex == -1)
            {
                this.Port = 0;
                return;
            }
            this.textBoxPort.Text = "50000";

            if (!string.IsNullOrEmpty(comboBoxInstance.Text))
            {
                var machine = textBoxConnectServer.Text.Trim();
                this.InstanceName = comboBoxInstance.Text.Trim();

                // find the instance name and set the port
                if (neuronRuntimes.ContainsKey(this.InstanceName))
                {
                    var port = 0;
                    if (int.TryParse(neuronRuntimes[this.InstanceName].Port, out port))
                    {
                        this.Port = port;
                        this.textBoxPort.Text = this.Port.ToString();
                    }
                }
            }

            EnableConnect();
        }

        private void TestClientSettings_Load(object sender, EventArgs e)
        {
            // restore settings
            if (!string.IsNullOrEmpty(this.Machine))
                this.textBoxConnectServer.Text = this.Machine;
            if (!string.IsNullOrEmpty(this.InstanceName))
                this.comboBoxInstance.Text = this.InstanceName;
            if (this.Port > 0)
                this.textBoxPort.Text = this.Port.ToString();

            if (!string.IsNullOrEmpty(this.Username))
                this.textBoxUsername.Text = this.Username;
            if (!string.IsNullOrEmpty(this.Password))
                this.textBoxPassword.Text = this.Password;
            if (!string.IsNullOrEmpty(this.Domain))
                this.textBoxDomain.Text = this.Domain;
            if (!string.IsNullOrEmpty(this.ServiceIdentity))
                this.textBoxIdentity.Text = this.ServiceIdentity;

            // populate based on registry
            if (!string.IsNullOrEmpty(this.textBoxConnectServer.Text))
            {
                this.InstanceName = this.comboBoxInstance.Text;
                var matchInstance = false;
                this.Machine = textBoxConnectServer.Text.Trim();
                if (Neuron.NetX.Internal.ESBHelper.IsLocalMachine(this.Machine))
                {
                    foreach (var runtime in neuronRuntimes)
                    {
                        if (this.InstanceName.Equals(runtime.Key, StringComparison.InvariantCultureIgnoreCase))
                        {
                            this.InstanceName = runtime.Key;
                            matchInstance = true;
                        }

                        this.comboBoxInstance.Items.Add(runtime.Key);
                    }
                    if (matchInstance)
                        this.comboBoxInstance.Text = this.InstanceName;
                    else
                    {
                        if (neuronRuntimes.Count > 0)
                            this.comboBoxInstance.SelectedIndex = 0;
                        else
                        {
                            this.comboBoxInstance.Text = string.Empty;
                        }
                    }
                }
            }

            this.Machine = this.textBoxConnectServer.Text.Trim();
            this.InstanceName = this.comboBoxInstance.Text.Trim();

            EnableConnect();
        }    
    }
}
