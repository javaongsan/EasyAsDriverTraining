using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using EasyAsDriverTraining.Properties;
using EasyAsDriverTraining.Tools;

namespace EasyAsDriverTraining
{
    public sealed partial class FrmDbSetting : Form
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool result = false;
            try
            {
                switch (keyData)
                {
                    case (Keys.Enter):
                        return base.ProcessCmdKey(ref msg, keyData);
                    case (Keys.F10):
                        ClearSearch();
                        result = true;
                        break;
                    case (Keys.Escape):
                        FrmClose();
                        result = true;
                        break;
                    default:
                        return base.ProcessCmdKey(ref msg, keyData);
                }
            }
             catch (Exception ex) {  MessageClass.ShowError(ex.Message, this.Text); }

            return result;
        }

        private void ClearSearch()
        {
            FrmClass.ClearSearch(this);
        }

        public FrmDbSetting()
        {
            InitializeComponent();
            this.Font = Gobal.Myfont;
        }

        private void ButtonOkClick(object sender, EventArgs e)
        {
            try
            {
                if (txtServer.Text.Trim().Length <= 0)
                {
                    MessageBox.Show(Resources.Server_cannot_be_empty, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtServer.Focus();
                    return;
                }

                if (txtPort.Text.Trim().Length <= 0)
                {
                    MessageBox.Show(Resources.Port_cannot_be_empty, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPort.Focus();
                    return;
                }

                if (txtDatabase.Text.Trim().Length <= 0)
                {
                    MessageBox.Show(Resources.Database_cannot_be_empty, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDatabase.Focus();
                    return;
                }

                if (txtUserid.Text.Trim().Length <= 0)
                {
                    MessageBox.Show(Resources.User_Id_cannot_be_empty, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUserid.Focus();
                    return;
                }

                String strConnString = String.Empty;
                string strLocalConnString = String.Empty;
                string strRemoteConnString = String.Empty;
                if (txtServer.Text.Trim().Length > 0)
                    strConnString = @"Server=" + txtServer.Text.Trim() + ";Port=" + txtPort.Text.Trim() + ";Database=" + txtDatabase.Text.Trim() + ";Uid=" + txtUserid.Text.Trim() + ";Pwd=" + txtPassword.Text.Trim() + ";CheckParameters=false";
              
                var dBs = new Dictionary<string, string>
                    {
                        {Config.OfficeDb, strConnString},
                        {Config.LocalDb, strLocalConnString},
                        {Config.RemoteDb, strRemoteConnString},
                        {Config.Server, txtServer.Text.Trim()},
                        {Config.Port, txtPort.Text.Trim()},
                        {Config.Database, txtDatabase.Text.Trim()},
                        {Config.Uid, txtUserid.Text.Trim()},
                        {Config.Pwd, txtPassword.Text.Trim()},
                    };

                if (Config.ModifiedConfig(dBs))
                {
                    var cacheFile = Config.GetPermanentConfigFile();
                    if (cacheFile.Length > 0)
                    {
                        if (File.Exists(cacheFile))
                            File.Delete(cacheFile);

                        File.Copy(Application.ExecutablePath + ".config", cacheFile, true);
                    }
                    else
                        MessageBox.Show(Resources.Cannot_locate_path_ + cacheFile);
                    MessageBox.Show(Resources.The_database_has_been_updated__and_the_application_will_now_restart);
                    Application.Restart();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            FrmClose();
        }

        private void FrmDbSettingLoad(object sender, EventArgs e)
        {
            this.Text = "Database Setup";
            txtServer.Text = Config.Read(Config.Server);
            txtPort.Text = Config.Read(Config.Port);
            txtDatabase.Text = Config.Read(Config.Database);
            txtUserid.Text = Config.Read(Config.Uid);
            txtPassword.Text = Config.Read(Config.Pwd);
      
            buttonOK.Click+=new EventHandler(ButtonOkClick);
            buttonCancel.Click+=new EventHandler(ButtonCancelClick);
            btnTest.Click += new EventHandler(BtnTestClick);
        }


        private void TestConnection(String strConnString)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var db = new Mysql(strConnString);
                MessageBox.Show(db.TestDb() ? "Connection Success" :"Connection Failed",
                                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, this.Text);
            }
            finally
            {
                
                Cursor.Current = Cursors.Default;
            }
        }

        private void BtnTestClick(object sender, EventArgs e)
        {
            String strConnString = "Server=" + txtServer.Text.Trim() + ";Port=" + txtPort.Text.Trim() + ";Database=" + txtDatabase.Text.Trim() + ";Uid=" + txtUserid.Text.Trim() + ";Pwd=" + txtPassword.Text.Trim() + ";";
            TestConnection(strConnString);

        }

        private void FrmClose()
        {
            this.Load -= new System.EventHandler(this.FrmDbSettingLoad);
            this.Close();
            this.Dispose(true);
        }
    }
}
