using System.Windows.Forms;

namespace EasyAsDriverTraining.CustomControl
{
    public class MyCombobox : ComboBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (char.IsLetter(e.KeyChar))
                e.KeyChar = char.ToUpper(e.KeyChar);

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                return true;
            }

           return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}