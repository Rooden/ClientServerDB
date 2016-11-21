using System;
using System.Windows.Forms;

namespace ClientApp.Forms
{
    public partial class SignInForm : Form
    {
        private Client _client;
        private MainForm _mainForm;

        public static EventHandler MainFormCloseHandler;

        public SignInForm()
        {
            InitializeComponent();
            MainFormCloseHandler += btnDisconnect_Click;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                _client = new Client();
                _client.ConnectToServer(200, "127.0.0.1");

                _mainForm = new MainForm(_client);
                _mainForm.Show();

                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show(@"Turn on server or check server address.", @"Server cannot be found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void btnDisconnect_Click(object sender, EventArgs e)
        {
            _mainForm.Dispose();

            _client.DisconnectFromServer();

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
        }
    }
}