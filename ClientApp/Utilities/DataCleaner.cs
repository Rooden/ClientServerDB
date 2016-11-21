using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace ClientApp.Utilities
{
    internal static class DataCleaner
    {
        public static void CleanDataGridView(DataGridView dataGridView)
        {
            foreach (var columnName in ColumnNames(dataGridView))
            {
                if (!columnName.Contains("_ID"))
                    continue;

                Debug.WriteLine(columnName);
                dataGridView.Columns[columnName].Visible = false;
            }
        }

        private static IEnumerable<string> ColumnNames(DataGridView dataGridView)
        {
            for (var i = 0; i < dataGridView.ColumnCount; i++)
            {
                yield return dataGridView.Columns[i].HeaderText;
            }
        }
    }
}