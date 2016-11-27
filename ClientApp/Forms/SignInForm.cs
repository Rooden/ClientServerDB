using System;
using System.Windows.Forms;

namespace ClientApp.Forms
{
    public partial class SignInForm : Form
    {
        private Client _client;
        private MainForm _mainForm;

        public SignInForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var ip = txtIp.Text;
            var login = txtLogin.Text;
            var password = txtPassword.Text;
            var database = txtDatabase.Text;

            try
            {
                _client = new Client();
                _client.ConnectToServer(200, ip);
                _client.ConnectToDatabase(login, password, database);

                _mainForm = new MainForm(_client);
                _mainForm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show(@"Turn on server or check server address.", @"Server cannot be found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}