using System;

namespace EasyAsDriverTraining.Tools
{
    public static class Log
    {
        private static readonly String ErrorFile = @Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Gobal.Errlog;

        public static void LogError(String err)
        {
            SFile.WriteToFile(ErrorFile, true, "[" + DateTime.Now + "] " + err);
        }

   
    }
}
