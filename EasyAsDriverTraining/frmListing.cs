using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using EasyAsDriverTraining.Data;
using EasyAsDriverTraining.Properties;
using EasyAsDriverTraining.Tools;

namespace EasyAsDriverTraining
{
    public partial class frmListing : Form
    {
        private const String MTitle = "Listing";
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

        public frmListing()
        {
            InitializeComponent();
        }

        private void frmListingLoad(object sender, EventArgs e)
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
                _dt = Listing.LoadBySearchOption(txtSuburbSearch.Text, txtTrainerSearch.Text);
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
                        dgView.Rows[dgView.SelectedRows[0].Index].Cells[1].Value = txtSuburb.Text;
                        dgView.Rows[dgView.SelectedRows[0].Index].Cells[2].Value = txtTrainer.Text;
                        dgView.Rows[dgView.SelectedRows[0].Index].Cells[3].Value = txtQualification.Text;
                        dgView.Rows[dgView.SelectedRows[0].Index].Cells[4].Value = txtTransmission.Text;
                        dgView.Rows[dgView.SelectedRows[0].Index].Cells[5].Value = txtModel.Text;
                        dgView.Rows[dgView.SelectedRows[0].Index].Cells[6].Value = txtRegNo.Text;
                        dgView.Rows[dgView.SelectedRows[0].Index].Cells[7].Value = txtArea.Text;
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
                this.Load -= new System.EventHandler(this.frmListingLoad);

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
            txtSuburb.Text = String.Empty;
            txtTrainer.Text = String.Empty;
            txtQualification.Text = String.Empty;
            txtTransmission.Text = String.Empty;
            txtModel.Text = String.Empty;
            txtRegNo.Text = String.Empty;
            txtArea.Text = String.Empty;
        }


        private void LoadNewData()
        {
            if (Utilities.GetCurrentRow(dgView, 0).Length <= 0)
                return;

            txtID.Text = Utilities.GetCurrentRow(dgView, 0);
            txtSuburb.Text = Utilities.GetCurrentRow(dgView, 1);
            txtTrainer.Text = Utilities.GetCurrentRow(dgView, 2);
            txtQualification.Text = Utilities.GetCurrentRow(dgView, 3);
            txtTransmission.Text = Utilities.GetCurrentRow(dgView, 4);
            txtModel.Text = Utilities.GetCurrentRow(dgView, 5);
            txtRegNo.Text = Utilities.GetCurrentRow(dgView, 6);
            txtArea.Text = Utilities.GetCurrentRow(dgView, 7);
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
                        txtSuburb.Focus();
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

                    if (Listing.Delete(Utilities.GetCurrentRow(dgView, 0)))
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
            if (txtSuburb.Text.Length <= 0)
            {
                MessageBox.Show("Please Enter A Valid Suburb", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSuburb.Focus();
                return;
            }

            if (txtTrainer.Text.Length <= 0)
            {
                MessageBox.Show("Please Enter A Valid Trainer", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTrainer.Focus();
                return;
            }

            bool isSuccess = false;
            switch (_mModule)
            {
                case "EDIT":
                    isSuccess = Listing.Update(txtID.Text, txtSuburb.Text, txtTrainer.Text, txtQualification.Text, txtTransmission.Text, txtModel.Text, txtRegNo.Text, txtArea.Text);
                    break;
                case "NEW":
                    isSuccess = Listing.Insert(txtSuburb.Text, txtTrainer.Text, txtQualification.Text, txtTransmission.Text, txtModel.Text, txtRegNo.Text, txtArea.Text);
                    break;
            }
            if (isSuccess)
                FrmClose();
            else
                MessageBox.Show(Resources.Please_try_again, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
