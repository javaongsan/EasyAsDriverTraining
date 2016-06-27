using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using EasyAsDriverTraining.Properties;
using EasyAsDriverTraining.Tools;

namespace EasyAsDriverTraining
{
    static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SystemParametersInfo(int uAction, int uParam, int lpvParam, int fuWinIni);

        private const int SpiSetkeyboardcues = 4107;
        private const int SpifSendwininichange = 2;

        private static bool _canExit = true;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var frminit = new FrmInit();
                frminit.Show();
                Application.DoEvents();

                SystemParametersInfo(SpiSetkeyboardcues, 0, 1, SpifSendwininichange);

                if (Utilities.BIsProcessOpen())
                {
                    MessageBox.Show(Resources.Application_is_already_running_);
                    Application.Exit();
                    return;
                }

                if (!File.Exists(Application.ExecutablePath + ".config"))
                {
                    if (File.Exists(Config.GetPermanentConfigFile()))
                    {
                        File.Copy(Config.GetPermanentConfigFile(), Application.ExecutablePath + ".config", true);
                        Gobal.OfficeConnString = Config.Read(Config.OfficeDb);

                        if (Gobal.OfficeConnString.Length <= 0)
                        {
                            File.Delete(Config.GetPermanentConfigFile());
                            using (var frm = new FrmDbSetting())
                            {
                                frm.TopMost = true;
                                frminit.Close();
                                frminit.Dispose();
                                frm.ShowDialog();
                                Application.Exit();
                                return;
                            }
                        }
                    }
                    else
                    {
                        using (var frm = new FrmDbSetting())
                        {
                            frm.TopMost = true;
                            frminit.Close();
                            frminit.Dispose();
                            frm.ShowDialog();
                            Application.Exit();
                            return;
                        }
                    }
                }

                if (Utilities.CheckforNewVersion().Length > 0)
                {
                    using (var frm = new FrmNewVersion())
                    {
                        frm.TopMost = true;
                        frminit.Close();
                        frminit.Dispose();
                        if (frm.ShowDialog() == DialogResult.OK) return;
                        Application.Exit();
                        return;
                    }
                }

                var connectionsuccess = false;

                Gobal.OfficeConnString = Config.Read(Config.OfficeDb);

                if (Gobal.OfficeConnString.Length <= 0)
                {
                    Utilities.DelConfig();
                    using (var frm = new FrmDbSetting())
                    {
                        frm.TopMost = true;
                        frminit.Close();
                        frminit.Dispose();
                        frm.ShowDialog();
                        Application.Exit();
                        return;
                    }
                }

                if (Gobal.OfficeConnString.Length > 0)
                {
                    Lantest();

                    if (Gobal.GConnStatus == RecordStatus.Lan )
                        connectionsuccess = true;
                }
                else
                {
                    Utilities.DelConfig();
                    MessageBox.Show(Resources.Cannot_Connect_to_Database_);
                    Application.Exit();
                    return;
                }

                frminit.Close();
                frminit.Dispose();

                using (var frm = new FrmLogin())
                {
                    frm.ShowInTaskbar = true;
                    frm.TopMost = true;
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        Application.Exit();
                        return;
                    }
                    do
                    {
                        _canExit = true;
                        Application.Run(new frmMain());
                    } while (!_canExit);
                }
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
        }

        private static void Lantest()
        {
            var db = new Mysql(Gobal.OfficeConnString);
            var connectionsuccess = db.TestDb();
            if (!connectionsuccess) return;
            Gobal.ConnString = Gobal.OfficeConnString;
            Gobal.GConnStatus = RecordStatus.Lan;
        }

    }


}