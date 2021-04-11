using System;
using System.Net;
using System.Windows.Forms;

namespace CustomServersClient.UI
{
    public partial class EditServerForm : Form
    {
        public CustomServerInfo serverInfo;

        public event Action<CustomServerInfo> savePressed;
        public event Action cancelPressed;

        public EditServerForm()
        {
            InitializeComponent();
        }

        private void EditServerForm_Load(object sender, EventArgs e)
        {
            if (serverInfo != null)
            {
                nameTextBox.Text = serverInfo.name;
                ipTextBox.Text = serverInfo.ip;
                portNumericUD.Value = serverInfo.port;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string address = ipTextBox.Text;

            if (!IPAddress.TryParse(address, out _))
            {
                try
                {
                    CustomServersPlugin.Logger.LogWarning($"Resolving IP address for domain \"{address}\"...");

                    var adresses = Dns.GetHostAddresses(address);
                    if (adresses.Length > 0)
                    {
                        address = adresses[0].ToString();
                    }
                    else
                    {
                        CustomServersPlugin.Logger.LogWarning($"Failed to resolve IP adress from domain name! DNS resolution failed for address \"{address}\"");
                    }
                }
                catch (Exception ex)
                {
                    CustomServersPlugin.Logger.LogWarning($"Failed to resolve IP adress from domain name! Exception:\n{ex}");
                }
            }

            serverInfo = new CustomServerInfo(nameTextBox.Text, address, (ushort)portNumericUD.Value);
            savePressed?.Invoke(serverInfo);
            Hide();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            serverInfo = null;
            cancelPressed?.Invoke();
            Hide();
        }

        private void EditServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
