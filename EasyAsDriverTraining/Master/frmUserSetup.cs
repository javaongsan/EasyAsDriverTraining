using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using EasyAsDriverTraining.Data;
using EasyAsDriverTraining.Properties;
using EasyAsDriverTraining.Tools;

namespace EasyAsDriverTraining
{
    public partial class FrmUserSetup : Form
    {
        private const String MTitle = "USER SETUP";
        private DataTable _dt;
        private BackgroundWorker _bgWrkr;
        private String _mModule = String.Empty;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool result = false;
            try
            {
                switch (keyData)
                {
                    case (Keys.Up):
                    case (Keys.Down):
                        if (gbNew.Visible)
                            return base.ProcessCmdKey(ref msg, keyData);
                        else
                            GridView.KeyUpDown(dgView, keyData);
                        result = true;
                        break;
                    case (Keys.Enter):
                        if (gbNew.Visible)
                            return base.ProcessCmdKey(ref msg, keyData);
                        else
                            LoadAll();
                        result = true;
                        break;
                    case (Keys.F10):
                        ClearSearch();
                        result = true;
                        break;
                    case (Keys.Escape):
                        FrmClose();
                        result = true;
                        break;
                    case (Keys.Alt | Keys.N):
                        if (gbNew.Visible)
                            return base.ProcessCmdKey(ref msg, keyData);
                        else
                            NewItem();
                        result = true;
                        break;
                    case (Keys.Alt | Keys.E):
                        if (gbNew.Visible)
                            return base.ProcessCmdKey(ref msg, keyData);
                        else
                            Edit();
                        result = true;
                        break;
                    case (Keys.Alt | Keys.D):
                        if (gbNew.Visible)
                            return base.ProcessCmdKey(ref msg, keyData);
                        else
                            Delete();
                        result = true;
                        break;
                    case (Keys.Alt | Keys.S):
                        if (!gbNew.Visible)
                            return base.ProcessCmdKey(ref msg, keyData);
                        else
                            Save();
                        result = true;
                        break;
                    default:
                        return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            catch (Exception ex) { MessageClass.ShowError(ex.Message, this.Text); }

            return result;
        }

        private void ClearSearch()
        {
            FrmClass.ClearSearch(this);
        }

        public FrmUserSetup()
        {
            InitializeComponent();
        }

        private void FrmUserSetupLoad(object sender, EventArgs e)
        {
            lblTitle.Text = MTitle;
            this.Text = MTitle;
            LoadinBackground();
        }

        private void LoadGrid(object sender, DoWorkEventArgs e)
        {
            if (_bgWrkr.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                _dt = User.LoadBySearchOption(txtSearch.Text);
            }
        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgView.DataSource = _dt;
            var gridViewColumn = dgView.Columns["PW"];
            if (gridViewColumn != null) gridViewColumn.Visible = false;

            this.dgView.MouseDoubleClick += this.DgViewMouseDoubleClick;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearchClick);
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            this.btnDel.Click += new System.EventHandler(this.BtnDelClick);
            this.btnEdit.Click += new System.EventHandler(this.BtnEditClick);
            this.btNew.Click += new System.EventHandler(this.BtNewClick);
        }

        private void DgViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            Edit();
        }

        private void LoadAll()
        {
            LoadinBackground();
        }

        private void BtnSearchClick(object sender, EventArgs e)
        {
            LoadAll();
        }

        private void LoadinBackground()
        {
            _bgWrkr = new BackgroundWorker { WorkerSupportsCancellation = true };
            _bgWrkr.DoWork += LoadGrid;
            _bgWrkr.RunWorkerCompleted += WorkerCompleted;
            _bgWrkr.RunWorkerAsync();
        }

        private void BtnCloseClick(object sender, EventArgs e)
        {
            FrmClose();
        }

        private void FrmClose(bool isCancel = false)
        {
            if (gbNew.Visible)
            {
                this.btnNewClose.Click -= this.BtnNewCloseClick;
                this.btnNewSave.Click -= this.BtnNewSaveClick;
                gbNew.Visible = false;
                tableLayoutPanel1.Enabled = true;
                if (_mModule == "NEW")
                    LoadAll();
                else
                {
                    if (!isCancel)
                    {
                        dgView.Rows[dgView.SelectedRows[0].Index].Cells[1].Value = txtUserID.Text;
                        dgView.Rows[dgView.SelectedRows[0].Index].Cells[2].Value = txtUserName.Text;
                        dgView.Rows[dgView.SelectedRows[0].Index].Cells[4].Value = chkStatus.Checked ? RecordStatus.Active : RecordStatus.Cancel;
                        dgView.Rows[dgView.SelectedRows[0].Index].Cells[5].Value = txtPwd.Text;
                    }
                }

                EmptyAll();

            }
            else
            {
                this.dgView.MouseDoubleClick -= this.DgViewMouseDoubleClick;
                this.btnSearch.Click -= new System.EventHandler(this.BtnSearchClick);
                this.btnClose.Click -= new System.EventHandler(this.BtnCloseClick);
                this.btnDel.Click -= new System.EventHandler(this.BtnDelClick);
                this.btnEdit.Click -= new System.EventHandler(this.BtnEditClick);
                this.btNew.Click -= new System.EventHandler(this.BtNewClick);
                this.Load -= new System.EventHandler(this.FrmUserSetupLoad);

                FrmClass.CloseForm(this, _bgWrkr);
            }
        }



        private void BtnEditClick(object sender, EventArgs e)
        {
            Edit();
        }

        private void Edit()
        {
            _mModule = "EDIT";
            FrmCustomerNewLoad();
        }

        private void BtNewClick(object sender, EventArgs e)
        {

            NewItem();
        }

        private void NewItem()
        {
            _mModule = "NEW";
            FrmCustomerNewLoad();
        }

        private void EmptyAll()
        {
            txtID.Text = String.Empty;
            txtUserID.Text = String.Empty;
            txtUserName.Text = String.Empty;
            txtPwd.Text = String.Empty;
            chkStatus.Checked = false;
        }


        private void LoadNewData()
        {
            if (Utilities.GetCurrentRow(dgView, 0).Length <= 0)
                return;

            txtID.Text = Utilities.GetCurrentRow(dgView, 0);
            txtUserID.Text = Utilities.GetCurrentRow(dgView, 1);
            txtUserName.Text = Utilities.GetCurrentRow(dgView, 2);
            txtPwd.Text = Utilities.GetCurrentRow(dgView, 5);
            chkStatus.Checked = Utilities.GetCurrentRow(dgView, 4) != RecordStatus.Cancel;
        }

        private void FrmCustomerNewLoad()
        {
            try
            {
                tableLayoutPanel1.Enabled = false;
                Utilities.CentraliseGroupBox(gbNew);
                txtID.ReadOnly = true;

                switch (_mModule)
                {
                    case "NEW":
                        btnNewSave.Visible = true;
                        btnNewSave.Text ="Save";
                        txtID.Visible = false;
                        txtUserID.Focus();
                        EmptyAll();

                        break;
                    case "EDIT":
                        btnNewSave.Visible = true;
                        btnNewSave.Text = "Update";
                        txtID.Visible = true;
                        LoadNewData();

                        break;
                }
                this.btnNewClose.Click += this.BtnNewCloseClick;
                this.btnNewSave.Click += this.BtnNewSaveClick;

            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, MTitle);
            }
        }


        private void BtnDelClick(object sender, EventArgs e)
        {
            Delete();
        }

        private void Delete()
        {
            try
            {
                using (new HourGlass())
                {

                    if (Utilities.GetCurrentRow(dgView, 0).Length <= 0)
                        return;

                    if (
                        MessageBox.Show(Resources.Do_you_want_to_delete_this_record, Resources.Delete,
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                        return;

                    if (User.Delete(Utilities.GetCurrentRow(dgView, 0)))
                    {
                        MessageBox.Show(Resources.Data_Deleted, Resources.Saved, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAll();
                    }
                    else
                        MessageBox.Show(Resources.Please_try_again, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, this.Text);
            }
        }

        private void BtnNewSaveClick(object sender, EventArgs e)
        {
            Save();
        }

        private void BtnNewCloseClick(object sender, EventArgs e)
        {
            FrmClose(true);
        }

        private void Save()
        {
            if (txtUserID.Text.Length <= 0)
            {
                MessageBox.Show(Resources.Please_enter_A_valid_LOGIN_NAME, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUserID.Focus();
                return;
            }

            if (txtUserName.Text.Length <= 0)
            {
                MessageBox.Show(Resources.Please_enter_A_valid_USER_NAME, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUserName.Focus();
                return;
            }

            bool isSuccess = false;
            switch (_mModule)
            {
                case "EDIT":
                    isSuccess = User.Update(txtID.Text, txtUserName.Text, txtPwd.Text,
                                            chkStatus.Checked == true ? RecordStatus.Active : RecordStatus.Cancel,
                                            txtUserID.Text);
                    break;
                case "NEW":
                    isSuccess = User.Insert(txtUserName.Text,  "1900-01-01",txtPwd.Text,chkStatus.Checked == true ? RecordStatus.Active : RecordStatus.Cancel, "","",txtUserID.Text, 2);
                    break;
            }
            if (isSuccess)
                FrmClose();
            else
                MessageBox.Show(Resources.Please_try_again, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
