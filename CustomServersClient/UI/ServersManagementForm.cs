using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using RegionMenu = LEIOFKPCJOO;

namespace CustomServersClient.UI
{
    public partial class ServersManagementForm : Form
    {
        public RegionMenu regionMenu;

        List<CustomServerInfo> _customServers;

        CustomServerInfo _selectedServer;

        EditServerForm _editForm;

        public ServersManagementForm()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ServersManagementForm_Load(object sender, EventArgs e)
        {
            _customServers = CustomServersPatches.customServers;

            serversListBox.Items.Clear();
            serversListBox.Items.AddRange(_customServers.ToArray());

            removeBtn.Enabled = (_selectedServer != null);
            editBtn.Enabled = (_selectedServer != null);

            _editForm = new EditServerForm();
        }

        private void ServersManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(Path.Combine(CustomServersPlugin.userDataPath, CustomServersPlugin.customServersFilePath), JsonConvert.SerializeObject(_customServers));

            RefreshRegionMenu();
        }

        private void RefreshRegionMenu()
        {
            if (regionMenu != null && regionMenu.gameObject.activeSelf)
            {
                regionMenu.OnDisable();
                CustomServersPatches.RegionMenuOnEnablePatch.forceReloadServers = true;
                regionMenu.OnEnable();
                CustomServersPatches.RegionMenuOnEnablePatch.forceReloadServers = false;
            }
        }

        private void serversListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedServer = serversListBox.SelectedItem as CustomServerInfo;

            removeBtn.Enabled = (_selectedServer != null);
            editBtn.Enabled = (_selectedServer != null);
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if(_selectedServer != null)
            {
                _customServers.Remove(_selectedServer);
                serversListBox.Items.Remove(_selectedServer);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            _editForm.serverInfo = null;
            _editForm.savePressed += AddedServerSaved;

            _editForm.ShowDialog();
        }

        private void AddedServerSaved(CustomServerInfo obj)
        {
            _editForm.savePressed -= AddedServerSaved;

            _customServers.Add(obj);
            serversListBox.Items.Add(obj);

            serversListBox.Refresh();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            _editForm.serverInfo = _selectedServer;
            _editForm.savePressed += EditedServerSaved;

            _editForm.ShowDialog();
        }

        private void EditedServerSaved(CustomServerInfo obj)
        {
            _editForm.savePressed -= EditedServerSaved;

            _selectedServer.name = obj.name;
            _selectedServer.ip = obj.ip;
            _selectedServer.port = obj.port;
        }
    }
}
