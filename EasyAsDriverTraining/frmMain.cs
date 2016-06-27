using System;
using System.Windows.Forms;
using EasyAsDriverTraining.Properties;
using EasyAsDriverTraining.Tools;

namespace EasyAsDriverTraining
{

    public partial class frmMain : Form
    {
        private const String MTitle = "EasyAs Driver Training Australia";

        public frmMain()
        {
            InitializeComponent();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            Text = MTitle + Resources.FrmMain_FrmMainLoad___________________ + Gobal.GConnStatus;
            Text += Resources.FrmMain_FrmMainLoad_______________Version_ + Utilities.GetVersion();

            if (Utilities.CheckforNewVersion().Length > 0)
            {
                Text += Resources.FrmMain_FrmMainLoad_________________New_version_ + Utilities.CheckforNewVersion() + Resources.FrmMain_FrmMainLoad__available___;

            }

            settingToolStripMenuItem.Enabled = Gobal.GRoleId == "1";
            LoadListingFrm();
        }

        
        private void settingToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var newMdiChild = new FrmUserSetup();
            FrmClass.LoadSubfrmClose(newMdiChild, this, true);
        }

        private void listingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadListingFrm();
        }

        private void LoadListingFrm()
        {
            var newMdiChild = new frmListing();
            FrmClass.LoadSubfrmClose(newMdiChild, this, true);
        }
    }
}
