#define DEBUG

using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace EasyAsDriverTraining.Tools
{
    public class Utilities
    {

        public static void LoadDropDown(ComboBox ddl, DataTable dt, string textField, string valueField)
        {
            try
            {
                ddl.SuspendLayout();
                ddl.Items.Clear();
                ddl.DataSource = dt;
                //new BindingSource(dt, "");
                ddl.DisplayMember = textField;
                ddl.ValueMember = valueField;
                ddl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                ddl.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddl.ResumeLayout();

            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
        }

        public static void LoadDropDownWBlank(ComboBox ddl, DataTable dt)
        {
            try
            {
                ddl.SuspendLayout();
                ddl.Items.Clear();
                ddl.BeginUpdate();
                ddl.Items.Add("");
                for (int i = 0; i < dt.Rows.Count; i++)
                    ddl.Items.Add(dt.Rows[i][0].ToString());
                ddl.EndUpdate();
                ddl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                ddl.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddl.DropDownStyle = ComboBoxStyle.DropDown;
                ddl.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
        }

      
        public static void LoadListBox(ListBox ddl, DataTable dt, string textField, string valueField)
        {
            try
            {
                ddl.DataSource = null;
                ddl.Items.Clear();
                ddl.DisplayMember = textField;
                ddl.ValueMember = valueField;
                ddl.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
        }

        public static void AltLoadListBox(ListBox ddl, DataTable dt)
        {
            try
            {
                ddl.BeginUpdate();
                for (var i = 0; i < dt.Rows.Count; i++)
                    if (dt.Rows[i][0].ToString().Length > 0)
                        ddl.Items.Add(dt.Rows[i][0].ToString());
                ddl.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
        }

        public static void LoadListView(ListView lst, DataTable dt)
        {
            try
            {
                lst.Items.Clear();
                lst.BeginUpdate();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    var itm = new ListViewItem(dr[0].ToString());
                    for (int n = 1; n < dt.Columns.Count; n++)
                        itm.SubItems.Add(dr[n].ToString());
                    lst.Items.Add(itm);
                }
                lst.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
        }

        public static String GetCurrentRow(DataGridView dgView, int intCellNo)
        {
            var id = String.Empty;
            try
            {
                var selectedRowCount = dgView.Rows.GetRowCount(DataGridViewElementStates.Selected);

                if (selectedRowCount > 0)
                {
                    if (dgView.SelectedRows.Count > 0)
                    {
                        if (dgView.SelectedRows.Count > 1)
                        {
                            var currentRow = dgView.SelectedRows[0];
                            id = currentRow.Cells[intCellNo].Value.ToString();
                        }
                        else
                        {
                            var i = dgView.SelectedCells[0].RowIndex;
                            if (dgView.Rows[i].Cells[intCellNo].Value != null)
                                id = dgView.Rows[i].Cells[intCellNo].Value.ToString();
                        }
                    }
                    if (id.Length <= 0)
                        return string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);

            }
            return id;
        }

        public static RadioButton RdTypeCheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedrb = null;
            var rb = sender as RadioButton;

            try
            {
                if (rb == null)
                    return null;

                // Ensure that the RadioButton.Checked property
                // changed to true.
                if (rb.Checked)
                {
                    // Keep track of the selected RadioButton by saving a reference
                    // to it.
                    selectedrb = rb;
                }
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
            return selectedrb;
        }

        public static void AppendDataTable(DataTable dtSource, ref DataTable dtDestination)
        {
            try
            {
                if (dtSource == null || dtSource.Rows.Count < 1)
                    return;

                if (dtDestination == null || dtDestination.Rows.Count < 1)
                {
                    dtDestination = dtSource;
                    return;
                }

                foreach (DataRow dr in dtSource.Rows)
                {
                    dtDestination.ImportRow(dr);
                }
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                return;
            }
        }

        public static bool IsText(String strValue)
        {
            try
            {
                var rgx = new Regex("[^0-9]");
                return !rgx.IsMatch(strValue.Trim());
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                return false;
            }
        }

        public static bool IsDate(String strValue)
        {
            bool results = false;
            try
            {
                if (strValue.Length < 12)
                    return false;

                DateTime dt;
                results = DateTime.TryParse(strValue.Trim(), out dt);
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
            return results;
        }

        public static bool IsNumeric(string strValue)
        {
            var results = false;
            try
            {
                double dTmp = 0;
                results = double.TryParse(strValue.Trim(), System.Globalization.NumberStyles.Any, null, out dTmp);
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
            return results;
        }

        public static bool BIsProcessOpen()
        {
            string proc = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(proc);
#if DEBUG
            if (processes.Length > 2)
                return true;
            else
                return false;
#else
            if (processes.Length>1)
                return true;
            else
                return false;
#endif
        }

        public static String GetVersion()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Version ver = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                return String.Format("{0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision);
            }
            else
                return
                "Not Published";
        }

        public static String CheckforNewVersion()
        {
            String latestVersion = String.Empty;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                UpdateCheckInfo info = null;
                try
                {
                    info = ad.CheckForDetailedUpdate();
                }
                catch
                {
                    return latestVersion;
                }

                if (info.UpdateAvailable)
                    latestVersion = String.Format("{0}", info.AvailableVersion);

            }
            return latestVersion;
        }

        public static void DelConfig()
        {
            try
            {
                File.Delete(Application.ExecutablePath + ".config");
            }
            catch (Exception ex) { MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name); }
        }


        public static void CentraliseGroupBox(GroupBox gd)
        {
            gd.Left = (Screen.PrimaryScreen.WorkingArea.Width - gd.Width) / 2;
            gd.Top = (Screen.PrimaryScreen.WorkingArea.Height - gd.Height) / 2;
            gd.Visible = true;
            gd.BringToFront();
        }


       
    }
}

