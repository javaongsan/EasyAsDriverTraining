using System;
using System.Security.Cryptography;

namespace EasyAsDriverTraining.Tools
{
    public class Security
    {
        public static String Encrypt(String origValue)
        {
            String enryValue = String.Empty;
            try
            {
                var enDes = new TripleDes();
                enryValue = enDes.Encrypt(origValue);
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
            return enryValue;
        }

        public static String Decrypt(String origValue)
        {
            String ederyValue = String.Empty;
            try
            {
                var enDes = new TripleDes();
                ederyValue = enDes.Decrypt(origValue);
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
            }
            return ederyValue;
        }

        private String GetPasswordwMd5(string pass)
        {
            try
            {
                var x = new MD5CryptoServiceProvider();
                byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);
                bs = x.ComputeHash(bs);
                var s = new System.Text.StringBuilder();
                foreach (byte b in bs)
                {
                    s.Append(b.ToString("x2").ToLower());
                }
                return s.ToString();
            }
            catch (Exception ex)
            {
                MessageClass.ShowError(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                return String.Empty;
            }
        }
    }

   
}
