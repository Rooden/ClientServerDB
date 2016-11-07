using ServerApp;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ClientApp
{
    internal partial class Client
    {
        public void ConnectToServer(DataGridView mainDataGridView, ComboBox cmbTables, Control btnSelectTable)
        {
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

        public void SelectTable(DataGridView mainDataGridView, ComboBox cmbTables)
        {
            Utilities.SendBytes(Utilities.ClientStates.SelectTable, _serverStream);

            var tableName = cmbTables.SelectedItem.ToString();
            Utilities.SendBytes(tableName, _serverStream);

            DataSet dataSet;
            Utilities.RecieveBytes(out dataSet, _serverStream);
            mainDataGridView.DataSource = dataSet?.Tables[tableName]?.DefaultView;
        }
    }
}