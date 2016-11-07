using ServerApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        private NetworkStream _serverStream;
        private TcpClient _server;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnectServer_Click(object sender, EventArgs e)
        {
            _server = new TcpClient("127.0.0.1", 200);
            _serverStream = _server.GetStream();

            Utilities.SendBytes(Utilities.ClientStates.ConnectionToServer, _serverStream);

            DataSet dataSet;
            Utilities.RecieveBytes(out dataSet, _serverStream);
            mainDataGridView.DataSource = dataSet?.Tables["TestTable"]?.DefaultView;

            List<string> list;
            Utilities.RecieveBytes(out list, _serverStream);
            if (list != null)
                foreach (var item in list)
                    cmbTables.Items.Add(item);

            cmbTables.SelectedIndex = 0;
            btnSelectTable.Enabled = true;
        }

        private void btnSelectTable_Click(object sender, EventArgs e)
        {
            Utilities.SendBytes(Utilities.ClientStates.SelectTable, _serverStream);

            var tableName = cmbTables.SelectedItem.ToString();
            Utilities.SendBytes(tableName, _serverStream);

            DataSet dataSet;
            Utilities.RecieveBytes(out dataSet, _serverStream);
            mainDataGridView.DataSource = dataSet?.Tables[tableName]?.DefaultView;
        }

        ~Form1()
        {
            _serverStream.Close();
            _server.Close();
        }
    }
}