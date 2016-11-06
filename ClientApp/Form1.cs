using ServerApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
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
            var binaryFormatter = new BinaryFormatter();

            var dataSet = binaryFormatter.Deserialize(_serverStream) as DataSet;
            mainDataGridView.DataSource = dataSet?.Tables["TestTable"]?.DefaultView;

            var list = binaryFormatter.Deserialize(_serverStream) as List<string>;
            foreach (var item in list)
                cmbTables.Items.Add(item);
            cmbTables.SelectedIndex = 0;
            btnSelectTable.Enabled = true;
        }

        private void btnSelectTable_Click(object sender, EventArgs e)
        {
            _server = new TcpClient("127.0.0.1", 200);
            _serverStream = _server.GetStream();

            var tableName = cmbTables.SelectedItem.ToString();
            var resultBytes = Utilities.GetBytesFrom(tableName);
            _serverStream.Write(resultBytes, 0, resultBytes.Length);

            var binaryFormatter = new BinaryFormatter();
            var dataSet = binaryFormatter.Deserialize(_serverStream) as DataSet;
            mainDataGridView.DataSource = dataSet?.Tables[tableName]?.DefaultView;
        }
    }
}