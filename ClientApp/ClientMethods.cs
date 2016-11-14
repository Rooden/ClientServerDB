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

            lblText.Text = $"Table: {dataSet?.Tables[0]?.TableName}";

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

            lblText.Text = $"Table: {tableName}";

            DataSet dataSet;
            Utilities.RecieveBytes(out dataSet, _serverStream);
            mainDataGridView.DataSource = dataSet?.Tables[tableName]?.DefaultView;
        }

        public void UpdateTable(DataGridView mainDataGridView)
        {
            Utilities.SendBytes(Utilities.ClientStates.Edit, _serverStream);

            var dataTable = new DataTable();
            foreach (DataGridViewColumn col in mainDataGridView.Columns)
            {
                dataTable.Columns.Add(col.HeaderText);
            }

            foreach (DataGridViewRow row in mainDataGridView.Rows)
            {
                var dRow = dataTable.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dataTable.Rows.Add(dRow);
            }

            Utilities.SendBytes(dataTable, _serverStream);
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