using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace EasyAsDriverTraining.Tools
{
    public class FrmClass
    {
        public static bool IsFormAlreadyOpen(Form newMdiChild)
        {
            return IsFormAlreadyOpen(newMdiChild, false);
        }

        public static bool IsFormAlreadyOpen(Form newMdiChild, bool isDialog)
        {
            if (newMdiChild != null && newMdiChild.IsDisposed)
                return false;

            foreach (
                Form openForm in
                    Application.OpenForms.Cast<Form>().Where(
                        openForm => newMdiChild != null && openForm.Name.ToUpper() == newMdiChild.Name.ToUpper()))
            {
                openForm.BringToFront();
                if (isDialog)
                    openForm.ShowDialog();
                else
                    openForm.Show();
                openForm.Focus();
                return true;
            }
            return false;
        }

        public static void LoadSubfrmClose(Form newMdiChild, Form parentForm, bool isResize)
        {
            foreach (Form childForm in parentForm.MdiChildren)
                if (newMdiChild.Name == childForm.Name && newMdiChild.Text == childForm.Text)
                {
                    childForm.BringToFront();
                    childForm.Focus();
                    return;
                }


            LoadSubfrm(newMdiChild, parentForm, isResize);
        }

        public static void LoadSubfrm(Form newMdiChild, Form parentForm, bool isResize)
        {
            try
            {
                using (new HourGlass())
                {
                    GC.Collect();

                    newMdiChild.Font = Gobal.Myfont;
                    if (isResize)
                    {
                        newMdiChild.WindowState = FormWindowState.Maximized;
                        newMdiChild.MinimumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width - 2,
                                                           Screen.PrimaryScreen.WorkingArea.Height - 20);
                        newMdiChild.MdiParent = parentForm;
                    }
                    else
                    {
                        newMdiChild.StartPosition = FormStartPosition.CenterParent;
                    }
                }

                if (isResize)
                    newMdiChild.Show();
                else
                    newMdiChild.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
        }

        public static void CloseAllChild(Form[] mdiChildren)
        {
            try
            {
                using (new HourGlass())
                {
                    foreach (Form childForm in mdiChildren)
                    {
                        childForm.Close();
                        childForm.Dispose();
                    }
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
        }


        public static void CloseForm(Form frm, BackgroundWorker bgWrkr)
        {
            try
            {
                if (bgWrkr != null)
                    if (bgWrkr.IsBusy)
                        bgWrkr.CancelAsync();

                frm.Close();
                frm.Dispose();
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
        }

        
        public static void ClearSearch(Form frm)
        {
            try
            {
                foreach (Control c in frm.Controls)
                {
                    if (c is Panel || c is GroupBox)
                    {
                        foreach (Control ct in c.Controls)
                            ClearControl(c);
                    }
                    else
                    {
                        ClearControl(c);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
        }

        private static void ClearControl(Control c)
        {
            try
            {
                if (c is TextBox && c.Enabled)
                    c.Text = String.Empty;

                if (c is ComboBox && c.Enabled)
                {
                    var t = (ComboBox)c;
                    t.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
        }
    }
}