using ServerApp.Utilities;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Client
    {
        public void GetInfoFromServer(DataGridView dataGridView, ListBox lstBox, Label lblText)
        {
            TransferUtilities.SendBytes(TransferUtilities.ClientStates.ConnectionToServer, _serverStream);

            DataSet dataSet;
            TransferUtilities.RecieveBytes(out dataSet, _serverStream);
            dataGridView.DataSource = dataSet?.Tables[0]?.DefaultView;

            lblText.Text = $@"Table: {dataSet?.Tables[0]?.TableName}";

            List<string> list;
            TransferUtilities.RecieveBytes(out list, _serverStream);
            if (list != null)
                foreach (var item in list)
                    if (item != "STUDENT_MARKS" && item != "sysdiagrams")
                        lstBox.Items.Add(item);
        }

        public void SelectTable(DataGridView dataGridView, ComboBox cmbTables, Label lblText)
        {
            dataGridView.DataSource = null;

            TransferUtilities.SendBytes(TransferUtilities.ClientStates.SelectTable, _serverStream);

            var tableName = cmbTables.SelectedItem.ToString();
            TransferUtilities.SendBytes(tableName, _serverStream);

            lblText.Text = $@"Table: {tableName}";

            DataSet dataSet;
            TransferUtilities.RecieveBytes(out dataSet, _serverStream);
            dataGridView.DataSource = dataSet?.Tables[tableName]?.DefaultView;
        }

        public void SelectTable(DataGridView dataGridView, ListBox lstBox, Label lblText)
        {
            dataGridView.DataSource = null;

            TransferUtilities.SendBytes(TransferUtilities.ClientStates.SelectTable, _serverStream);

            var tableName = lstBox.SelectedItem.ToString();
            TransferUtilities.SendBytes(tableName, _serverStream);

            lblText.Text = $@"Table: {tableName}";

            DataSet dataSet;
            TransferUtilities.RecieveBytes(out dataSet, _serverStream);
            dataGridView.DataSource = dataSet?.Tables[tableName]?.DefaultView;
        }

        private void SelectTable(DataGridView dataGridView, Label lblText)
        {
            dataGridView.DataSource = null;

            TransferUtilities.SendBytes(TransferUtilities.ClientStates.SelectTable, _serverStream);

            var tableName = lblText.Text.Replace("Table: ", "");
            TransferUtilities.SendBytes(tableName, _serverStream);

            DataSet dataSet;
            TransferUtilities.RecieveBytes(out dataSet, _serverStream);
            dataGridView.DataSource = dataSet?.Tables[tableName]?.DefaultView;
        }

        public void UpdateTable(DataGridView dataGridView, TextBox txtEdit, Label lblText)
        {
            TransferUtilities.SendBytes(TransferUtilities.ClientStates.Edit, _serverStream);

            var editTable = new Dictionary<string, string>
            {
                { "tableName", lblText.Text.Replace("Table: ", "") },
                { "ID", (dataGridView.CurrentCell.RowIndex + 1).ToString() },
                { "columnName" , dataGridView.Columns[dataGridView.CurrentCell.ColumnIndex].Name },
                { "newValue" , txtEdit.Text }
            };

            TransferUtilities.SendBytes(editTable, _serverStream);

            SelectTable(dataGridView, lblText);
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