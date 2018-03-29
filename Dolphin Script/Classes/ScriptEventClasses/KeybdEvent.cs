using DolphinScript.Lib.ScriptEventClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DolphinScript.Classes.ScriptEventClasses
{
    [Serializable]
    public class KeybdEvent : ScriptEvent
    {
        public override void DoEvent()
        {
            keybd_event((byte)KeybdEventBtn, 0, 0, 0);
            Thread.Sleep(100);
            keybd_event((byte)KeybdEventBtn, 0, KEYEVENTF_KEYUP, 0);
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
