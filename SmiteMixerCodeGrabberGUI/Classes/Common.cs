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
            if (Properties.Settings.Default.notificationSound)
            {
                try {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Settings.Default.notificationSoundFilePath);
                    player.Play();
                } catch { Console.WriteLine("Unable to play notification sound (invalid file format/path)."); }
            }
            MessageBox.Show(msg, "Smite Code Grabber Notification", MessageBoxButtons.OK);
        }
    }
}
