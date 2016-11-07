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

            _client.ConnectToServer(mainDataGridView, cmbTables, btnSelectTable);
        }

        private void btnSelectTable_Click(object sender, EventArgs e)
        {
            _client.SelectTable(mainDataGridView, cmbTables);
        }
    }
}