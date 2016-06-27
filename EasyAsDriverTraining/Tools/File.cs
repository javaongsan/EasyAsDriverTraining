using System;
using System.IO;

namespace EasyAsDriverTraining.Tools
{
    public class SFile
    {


        public static bool CreateFile(String dataPath)
        {
            FileStream fs = null;
            try
            {
                dataPath = dataPath.Replace((char)92, '/');
                dataPath = dataPath.Replace((char)9, '/');
                if (!File.Exists(dataPath))
                {
                    string temp = Path.GetDirectoryName(dataPath);
                    if (temp != null && !Directory.Exists(temp))
                    {
                        Directory.CreateDirectory(temp);
                    }
                    fs = new FileStream(dataPath, FileMode.CreateNew);
                    fs.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
            return false;
        }

        public static bool WriteToFile(String strfullFilepath, bool append, String data)
        {
            bool result = true;
            StreamWriter fs = null;
            try
            {
                fs = append ? new StreamWriter(strfullFilepath, true) : new StreamWriter(strfullFilepath);
                fs.WriteLine(data);
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                result = false;
            }
            finally
            {
                if (fs != null) fs.Close();
            }
            return result;
        }

        public static String ReadFromFile(String strfullFilepath)
        {
            return File.ReadAllText(strfullFilepath);
        }

        public static bool CopyFile(String source, String dest)
        {
            bool isSuccess = true;
            try
            {
                File.Copy(source, dest);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }


        public static bool DelFile(String source)
        {
            bool isSuccess = true;
            try
            {
                File.Delete(source);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
    }
}
