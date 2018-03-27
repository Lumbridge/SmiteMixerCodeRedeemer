using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmiteMixerCodeGrabberGUI.Classes
{
    public class LogWriter : TextWriter
    {
        private RichTextBox textbox;
        public LogWriter(RichTextBox textbox)
        {
            this.textbox = textbox;
        }

        public override void Write(char value)
        {
            textbox.Text += value;
        }

        public override void Write(string value)
        {
            textbox.Text += (value + Environment.NewLine);
        }

        public override void WriteLine(string value)
        {
            textbox.Text += ("[" + DateTime.Now + "] " + value + Environment.NewLine);
        }

        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }
}
