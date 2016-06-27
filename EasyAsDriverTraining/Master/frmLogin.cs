using System;
using System.Windows.Forms;
using EasyAsDriverTraining.Data;
using EasyAsDriverTraining.Properties;
using EasyAsDriverTraining.Tools;

namespace EasyAsDriverTraining
{
    public sealed partial class FrmLogin : Form
    {
        private int _loginCounts;

        public FrmLogin()
        {
            InitializeComponent();
            this.Font = Gobal.Myfont;
        }

        private void FrmLoginLoad(object sender, EventArgs e)
        {
            this.btnLogin.Click += this.BtnLoginClick;
            this.btnExit.Click += this.BtnExitClick;
            this.lnkResetConifg.LinkClicked += LnkResetConifgLinkClicked;
            this.txtPassword.KeyDown += this.TxtPasswordKeyDown;
            _loginCounts = 0;
        }

        private void BtnLoginClick(object sender, EventArgs e)
        {
            Login();
        }

        private void BtnExitClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.FrmClose();
        }

        private void TxtPasswordKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Login();
        }

        private void Login()
        {
            var usr = new User();
            if (usr.CheckUsernamePassword(txtUsername.Text, txtPassword.Text))
            {
                Gobal.GUserName = txtUsername.Text;
                this.DialogResult = DialogResult.OK;
                this.FrmClose();
                return;
            }

            if (_loginCounts < 3)
            {
                MessageBox.Show("Incorrect login", Resources.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Incorrect_Username_or_password_Application_will_be_exit", Resources.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                try
                {
                    System.IO.File.Delete(Application.ExecutablePath + ".config");
                    System.IO.File.Delete(Config.GetPermanentConfigFile());
                }
                catch (Exception ex) { MessageClass.ShowError(ex.Message, this.Text); }

                this.DialogResult = DialogResult.No;
                this.FrmClose();
            }

            _loginCounts++;
        }

        private static void LnkResetConifgLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utilities.DelConfig();
            Application.Exit();
            return;
        }

        private void FrmClose()
        {
            this.Load -= new System.EventHandler(this.FrmLoginLoad);

            this.Close();
            this.Dispose(true);
        }
    }
}
