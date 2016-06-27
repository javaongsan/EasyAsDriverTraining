#define DEBUG
using System.Windows.Forms;

namespace EasyAsDriverTraining.Tools
{
    static class MessageClass
    {

        public static void ShowError(string message, string title)
        {
            title = "Error - " + title;
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            Log.LogError(title + ":" + message);
        }

        public static void HideError(string message, string title)
        {
            title = "Error - " + title;
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            Log.LogError(title + ":" + message);
        }

       
    }
}