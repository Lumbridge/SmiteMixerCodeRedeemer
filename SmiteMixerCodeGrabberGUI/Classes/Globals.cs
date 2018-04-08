using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmiteMixerCodeGrabberGUI.Classes
{
    class Globals
    {
        public static bool AFKMode { get; set; }
        public static bool shouldMinimise { get; set; }
        public static string smiteWindowTitle { get; set; }

        public static bool notificationSetting
        {
            get { return Properties.Settings.Default.notificationSetting; }
            set
            {
                Properties.Settings.Default.notificationSetting = value;
                SaveSettings();
            }
        }
        public static bool whitelistOnly
        {
            get { return Properties.Settings.Default.whitelistOnly; }
            set
            {
                Properties.Settings.Default.whitelistOnly = value;
                SaveSettings();
            }
        }
        public static int codeLength
        {
            get { return Properties.Settings.Default.codeLength; }
            set
            {
                Properties.Settings.Default.codeLength = value;
                SaveSettings();
            }
        }
        public static string codesStartWith
        {
            get { return Properties.Settings.Default.codesStartWith; }
            set
            {
                Properties.Settings.Default.codesStartWith = value;
                SaveSettings();
            }
        }
        public static System.Collections.Specialized.StringCollection whitelistedUsernames
        {
            get { return Properties.Settings.Default.whitelistedUsernames; }
            set
            {
                Properties.Settings.Default.whitelistedUsernames = value;
                SaveSettings();
            }
        }
        public static string notificationSoundFilePath
        {
            get { return Properties.Settings.Default.notificationSoundFilePath; }
            set
            {
                Properties.Settings.Default.notificationSoundFilePath = value;
                SaveSettings();
            }
        }
        public static bool notificationSound
        {
            get { return Properties.Settings.Default.notificationSound; }
            set
            {
                Properties.Settings.Default.notificationSound = value;
                SaveSettings();
            }
        }
        public static bool minimiseAfterRedeeming
        {
            get { return Properties.Settings.Default.minimiseAfterRedeeming; }
            set
            {
                Properties.Settings.Default.minimiseAfterRedeeming = value;
                SaveSettings();
            }
        }

        private static void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
    }
}
