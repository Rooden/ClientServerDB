using ServerApp.Utilities;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Client
    {
        public void GetInfoFromServer(DataGridView dataGridView, ListBox lstBox)
        {
            TransferUtilities.SendBytes(TransferUtilities.ClientStates.ConnectionToServer, _serverStream);

            DataSet dataSet;
            TransferUtilities.RecieveBytes(out dataSet, _serverStream);
            dataGridView.DataSource = dataSet?.Tables[0]?.DefaultView;

            List<string> list;
            TransferUtilities.RecieveBytes(out list, _serverStream);
            if (list != null)
                foreach (var item in list)
                    if (item != "STUDENT_MARKS" && item != "sysdiagrams")
                        lstBox.Items.Add(item);

            lstBox.SelectedIndex = lstBox.FindString("PERSON");
        }

        public void SelectTable(DataGridView dataGridView, ListBox lstBox)
        {
            dataGridView.DataSource = null;

            TransferUtilities.SendBytes(TransferUtilities.ClientStates.SelectTable, _serverStream);

            var tableName = lstBox.SelectedItem.ToString();
            TransferUtilities.SendBytes(tableName, _serverStream);

            DataSet dataSet;
            TransferUtilities.RecieveBytes(out dataSet, _serverStream);
            dataGridView.DataSource = dataSet?.Tables[tableName]?.DefaultView;
        }

        public void UpdateTable(DataGridView dataGridView, ListBox lstBox, string newValue)
        {
            if (dataGridView.CurrentCell == null)
                return;

            TransferUtilities.SendBytes(TransferUtilities.ClientStates.Edit, _serverStream);

            var editTable = new Dictionary<string, string>
                {
                    { "tableName", lstBox.SelectedItem.ToString() },
                    { "ID", (dataGridView.CurrentCell.RowIndex + 1).ToString() },
                    { "columnName" , dataGridView.Columns[dataGridView.CurrentCell.ColumnIndex].Name },
                    { "newValue" , newValue }
                };

            TransferUtilities.SendBytes(editTable, _serverStream);
            SelectTable(dataGridView, lstBox);
        }

        public void ExecuteQuery(DataGridView dataGridView, string query)
        {
            TransferUtilities.SendBytes(TransferUtilities.ClientStates.Query, _serverStream);

            TransferUtilities.SendBytes(query, _serverStream);

            DataSet dataSet;
            TransferUtilities.RecieveBytes(out dataSet, _serverStream);
            dataGridView.DataSource = dataSet?.Tables[0]?.DefaultView;
        }
    }
}