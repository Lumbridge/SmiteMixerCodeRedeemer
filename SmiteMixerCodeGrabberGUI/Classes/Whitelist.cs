using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmiteMixerCodeGrabberGUI.Classes
{
    public static class Whitelist
    {
        private static List<string> _Whitelist;

        static Whitelist()
        {
            _Whitelist = new List<string>();
        }

        public static bool GetIsWhitelistedUser(string username)
        {
            return _Whitelist.Contains(username);
        }

        public static void SaveWhitelist(RichTextBox control)
        {
            _Whitelist.Clear();
            foreach (var username in control.Lines)
                _Whitelist.Add(username);
        }

        public static List<string> GetWhitelist()
        {
            return _Whitelist;
        }

        public static void AddUserToWhitelist(string username)
        {
            _Whitelist.Add(username);
        }

        public static void ClearWhitelist()
        {
            _Whitelist.Clear();
        }
    }
}
