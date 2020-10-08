using System;
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
            serverInfo = new CustomServerInfo(nameTextBox.Text, ipTextBox.Text, (ushort)portNumericUD.Value);
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
