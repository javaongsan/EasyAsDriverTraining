using System;
using System.Windows.Forms;
using EasyAsDriverTraining.Tools;

namespace EasyAsDriverTraining
{
    public sealed partial class FrmNewVersion : Form
    {	 
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool result=false;
            try
            {
                switch (keyData)
                {
                    case (Keys.Enter):
                        return base.ProcessCmdKey(ref msg, keyData);
                    case (Keys.F10):
                        ClearSearch();
                        result=true;
                        break;
                    case (Keys.Escape):
                        FrmClose();
                        result=true;
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

        public FrmNewVersion()
        {
            InitializeComponent();
            this.Font = Gobal.Myfont;
        }

        private void FrmNewVersionLoad(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Version Upgrade";
                this.lblMsg.Text =Utilities.CheckforNewVersion() +
                              "A new version is available. Would you like to upgrade";
                this.buttonOK.Click += new EventHandler(ButtonOkClick);
                this.buttonCancel.Click += new EventHandler(ButtonCancelClick);
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            FrmClose();
        }

        private void ButtonOkClick(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                buttonOK.Enabled = false;
                buttonCancel.Enabled = false;

                lblMsg.Text = "Updating";
                Application.DoEvents();
                var success = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.Update();
                if (success)
                {
                    lblMsg.Text = "Application will now restart";
                    Application.Restart();
                }
                else
                {
                    lblMsg.Text =  "Update Failed! Please do a manual update";
                }
                this.DialogResult = DialogResult.OK;
                FrmClose();
            }
        }        
		
		private void FrmClose()
        {
            this.Load -= new System.EventHandler(this.FrmNewVersionLoad);
            this.Close();
			this.Dispose(true);
        }
		
    }
}
