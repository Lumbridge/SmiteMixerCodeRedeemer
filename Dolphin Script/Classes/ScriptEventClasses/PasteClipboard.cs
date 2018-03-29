using DolphinScript.Lib.ScriptEventClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DolphinScript.Lib.Backend.WinAPI;

namespace DolphinScript.Classes.ScriptEventClasses
{
    [Serializable]
    public class PasteClipboard : ScriptEvent
    {
        public override void DoEvent()
        {
            // placeholder for CTRL+V //
            // down CTRL
            keybd_event((byte)VirtualKeyStates.VK_LCONTROL, 0, 0, 0);
            // down V key
            keybd_event(0x56, 0, 0, 0);
            Thread.Sleep(100);
            keybd_event((byte)VirtualKeyStates.VK_LCONTROL, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(0x56, 0, KEYEVENTF_KEYUP, 0);
        }

        public override string GetEventListBoxString()
        {
            throw new NotImplementedException();
        }

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,
            int dwExtraInfo);

        const uint KEYEVENTF_KEYUP = 0x0002;
    }
}
