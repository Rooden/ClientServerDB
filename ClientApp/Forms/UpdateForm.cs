using ClientApp.Utilities;
using System;
using System.Windows.Forms;

namespace ClientApp.Forms
{
    public partial class UpdateForm : Form
    {
        private ListBox _lstBox;
        private DataGridView _dataGridView;
        private Client _client;

        public UpdateForm(Client client, DataGridView dataGridView, ListBox lstBox)
        {
            InitializeComponent();
            _dataGridView = dataGridView;
            _client = client;
            _lstBox = lstBox;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtNewValue.Text == "")
            {
                Close();
                return;
            }

            _client.UpdateTable(_dataGridView, _lstBox, txtNewValue.Text);
            DataCleaner.CleanDataGridView(_dataGridView);
            Close();
        }

        private void txtNewValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAccept_Click(this, new EventArgs());
            }
        }
    }
}