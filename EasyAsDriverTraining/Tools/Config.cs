using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Windows.Forms;

namespace EasyAsDriverTraining.Tools
{
    public class Config
    {
        public const string Mysection = "appSettings";
        public const string FileName = "app.config";
        public const string Server = "Server";
        public const string Port = "Port";
        public const string Database = "Database";
        public const string Uid = "Uid";
        public const string Pwd = "Pwd";
        public const string LocalServer = "LocalServer";
        public const string LocalPort = "LocalPort";
        public const string LocalDatabase = "LocalDatabase";
        public const string LocalUid = "LocalUid";
        public const string LocalPwd = "LocalPwd";
        public const string RemoteServer = "RemoteServer";
        public const string RemotePort = "RemotePort";
        public const string RemoteDatabase = "RemoteDatabase";
        public const string RemoteUid = "RemoteUid";
        public const string RemotePwd = "RemotePwd";

        public const String RemoteDb = "RemoteDBConnectionString";
        public const String LocalDb = "LocalDBConnectionString";
        public static string OfficeDb = "DBConnectionString";

        public static String Read(String strKey)
        {
            try
            {
                if (!System.IO.File.Exists(Application.ExecutablePath + ".config"))
                    return String.Empty;
                var oAppSettingsReader = new AppSettingsReader();

                string connectionstring = oAppSettingsReader.GetValue(strKey, typeof(string)).ToString();
                return Security.Decrypt(connectionstring);
            }
            catch
            {
                return String.Empty;
            }
        }

        public static bool ModifiedConfig(Dictionary<string, string> dBs)
        {
            try
            {
                String fullpathname = Application.ExecutablePath + ".config";

                if (System.IO.File.Exists(fullpathname))
                    System.IO.File.Delete(fullpathname);

                var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = fullpathname };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                config.GetSection(Mysection);
                config.AppSettings.Settings.Clear();
                foreach (KeyValuePair<string, string> pair in dBs.ToList())
                {
                    config.AppSettings.Settings.Remove(pair.Key);
                }
                foreach (KeyValuePair<string, string> pair in dBs.ToList())
                {
                    config.AppSettings.Settings.Add(pair.Key, Security.Encrypt(pair.Value));
                }

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(Mysection);
                return true;
            }
            catch (Exception ex)
            {
                MessageClass.HideError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                return false;
            }
        }

        public static string GetDefaultExeConfigPath(ConfigurationUserLevel userLevel)
        {
            try
            {
                var userConfig = ConfigurationManager.OpenExeConfiguration(userLevel);
                return userConfig.FilePath;
            }
            catch (ConfigurationException)
            {
                return String.Empty;
            }
        }

        public static string GetPermanentConfigFile()
        {
            var vPath = @Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Gobal.Permfile;
            return vPath;
        }
    }
}
