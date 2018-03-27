using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmiteMixerCodeGrabberGUI.Classes
{
    public static class ThreadHelperClass
    {
        delegate void SetTextCallback(Form f, Control ctrl, string text);
        delegate void SetCheckedCallback(Form f, CheckBox ctrl, bool isChecked);
        delegate void AppendTextbox(Form f, RichTextBox ctrl, string text);
        public static void SetText(Form form, Control ctrl, string text)
        {
            if (ctrl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                form.Invoke(d, new object[] { form, ctrl, text });
            }
            else
            {
                ctrl.Text = text;
            }
        }
        public static void SetCheckbox(Form form, CheckBox ctrl, bool isChecked)
        {
            if (ctrl.InvokeRequired)
            {
                SetCheckedCallback d = new SetCheckedCallback(SetCheckbox);
                form.Invoke(d, new object[] { form, ctrl, isChecked });
            }
            else
            {
                ctrl.Checked = isChecked;
            }
        }
        public static void AppendLog(Form form, RichTextBox ctrl, string text)
        {
            if (ctrl.InvokeRequired)
            {
                AppendTextbox d = new AppendTextbox(AppendLog);
                form.Invoke(d, new object[] { form, ctrl, text });
            }
            else
            {
                ctrl.AppendText(text + Environment.NewLine);
            }
        }
    }
}
