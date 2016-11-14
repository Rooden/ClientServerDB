using ServerApp;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ClientApp
{
    internal partial class Client
    {
        public void GetInfoFromServer(DataGridView mainDataGridView, ComboBox cmbTables, Label lblText)
        {
            Utilities.SendBytes(Utilities.ClientStates.ConnectionToServer, _serverStream);

            DataSet dataSet;
            Utilities.RecieveBytes(out dataSet, _serverStream);
            mainDataGridView.DataSource = dataSet?.Tables[0]?.DefaultView;

            lblText.Text = $@"Table: {dataSet?.Tables[0]?.TableName}";

            List<string> list;
            Utilities.RecieveBytes(out list, _serverStream);
            if (list != null)
                foreach (var item in list)
                    cmbTables.Items.Add(item);

            cmbTables.SelectedIndex = 0;
        }

        public void SelectTable(DataGridView mainDataGridView, ComboBox cmbTables, Label lblText)
        {
            mainDataGridView.DataSource = null;

            Utilities.SendBytes(Utilities.ClientStates.SelectTable, _serverStream);

            var tableName = cmbTables.SelectedItem.ToString();
            Utilities.SendBytes(tableName, _serverStream);

            lblText.Text = $@"Table: {tableName}";

            DataSet dataSet;
            Utilities.RecieveBytes(out dataSet, _serverStream);
            mainDataGridView.DataSource = dataSet?.Tables[tableName]?.DefaultView;
        }

        public void UpdateTable(DataGridView mainDataGridView, TextBox txtEdit, Label lblText)
        {
            Utilities.SendBytes(Utilities.ClientStates.Edit, _serverStream);

            /*var editTable = new Utilities.EditTable
            {
                tableName = lblText.Text.Replace("Table: ", ""),
                ID = mainDataGridView.CurrentCell.RowIndex,
                columnName = mainDataGridView.Columns[mainDataGridView.CurrentCell.ColumnIndex].Name,
                newValue = txtEdit.Text
            };

            Utilities.SendBytes(editTable, _serverStream);*/

            var editTable = new Dictionary<string, string>
            {
                { "tableName", lblText.Text.Replace("Table: ", "") },
                { "ID", (mainDataGridView.CurrentCell.RowIndex + 1).ToString() },
                { "columnName" , mainDataGridView.Columns[mainDataGridView.CurrentCell.ColumnIndex].Name },
                { "newValue" , txtEdit.Text }
            };

            Utilities.SendBytes(editTable, _serverStream);
        }

        public void ExecuteQuery(DataGridView mainDataGridView, string query)
        {
            Utilities.SendBytes(Utilities.ClientStates.Query, _serverStream);

            Utilities.SendBytes(query, _serverStream);

            DataSet dataSet;
            Utilities.RecieveBytes(out dataSet, _serverStream);
            mainDataGridView.DataSource = dataSet?.Tables[0]?.DefaultView;
        }
    }
}