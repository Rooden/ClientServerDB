using System;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        private Client _client;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnectServer_Click(object sender, EventArgs e)
        {
            _client = new Client();
            _client.ConnectToServer(200);

            _client.ConnectToServer(mainDataGridView, cmbTables);

            btnSelectTable.Enabled = true;
            btnConnectServer.Enabled = false;
            btnDisconnectServer.Enabled = true;
        }

        private void btnSelectTable_Click(object sender, EventArgs e)
        {
            _client.SelectTable(mainDataGridView, cmbTables);
        }

        private void btnDisconnectServer_Click(object sender, EventArgs e)
        {
            mainDataGridView.DataSource = null;
            cmbTables.Items.Clear();

            _client.DisconnectFromServer();

            btnSelectTable.Enabled = false;
            btnConnectServer.Enabled = true;
            btnDisconnectServer.Enabled = false;
        }
    }
}