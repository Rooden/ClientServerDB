using System;
using System.Data;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnectServer_Click(object sender, EventArgs e)
        {
            var client = new TcpClient("127.0.0.1", 200);
            var clientStream = client.GetStream();
            var binaryFormatter = new BinaryFormatter();

            var dataSet = binaryFormatter.Deserialize(clientStream) as DataSet;
            mainDataGridView.DataSource = dataSet?.Tables["TestTable"].DefaultView;
        }
    }
}