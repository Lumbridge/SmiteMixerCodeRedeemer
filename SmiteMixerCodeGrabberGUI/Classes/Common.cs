using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmiteMixerCodeGrabberGUI.Classes.ThreadHelperClass;

namespace SmiteMixerCodeGrabberGUI.Classes
{
    class Common
    {
        public static void DisplayNotification(string msg)
        {
            MessageBox.Show(msg, "Smite Code Grabber Notification", MessageBoxButtons.OK);
        }
    }
}
