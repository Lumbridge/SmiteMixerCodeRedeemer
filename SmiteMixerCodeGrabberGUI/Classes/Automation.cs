using System;
using System.Collections.Generic;

using DolphinScript.Lib.ScriptEventClasses;
using static DolphinScript.Lib.Backend.Common;
using static DolphinScript.Lib.Backend.WinAPI;
using static DolphinScript.Lib.Backend.WindowControl;

using static SmiteMixerCodeGrabberGUI.Classes.AllCodes;

namespace SmiteMixerCodeGrabberGUI.Classes
{
    class Automation
    {
        public static void RedeemSingle(SmiteCode sc)
        {
            // get the event list and pass it the code we want it to type
            //
            var loop = GetRedeemLoop(sc.GetCode());

            foreach (var ev in loop)
                if(IsRunning)
                    ev.DoEvent();

            if(IsRunning)
                sc.SetIsRedeemed(true);
        }

        public static void RedeemAllActive()
        {
            foreach (var code in GetActiveCodes())
            {
                if (code.GetIsRedeemed() == false)
                {
                    // get the event list and pass it the code we want it to type
                    //
                    var loop = GetRedeemLoop(code.GetCode());

                    foreach (var ev in loop)
                        if(IsRunning)
                            ev.DoEvent();

                    if(IsRunning)
                        code.SetIsRedeemed(true);
                }
            }
        }
        
        [STAThread]
        public static List<ScriptEvent> GetRedeemLoop(string code)
        {
            System.Windows.Forms.Clipboard.SetText("/claimpromotion " + code);
            List<ScriptEvent> SlowTypingScript = new List<ScriptEvent>()
            {
                new MouseMoveToAreaOnWindow() { ClickArea = new RECT(), WindowToClickTitle = Properties.Settings.Default.smiteWindowTitle },
                GetPause(1.0, 1.5),
                GetEnterKeyClick(),
                GetPause(1.0, 1.5),
                GetPaste(),
                GetPause(1.0, 1.5),
                GetEnterKeyClick(),
                GetPause(1.0, 1.5),
                GetESCKeyClick(),
                GetPause(1.0, 1.5)
            };
            return SlowTypingScript;
        }

        static MoveWindowToFront GetMoveWindowToFront()
        {
            return new MoveWindowToFront() { WindowToClickTitle = Properties.Settings.Default.smiteWindowTitle };
        }

        static RandomPauseInRange GetPause(double min, double max)
        {
            return new RandomPauseInRange() { DelayMaximum = max, DelayMinimum = min };
        }

        static MouseMoveToAreaOnWindow GetMouseMoveToWindow(RECT clickArea)
        {
            return new MouseMoveToAreaOnWindow() { ClickArea = clickArea, WindowToClickTitle = Properties.Settings.Default.smiteWindowTitle };
        }

        static MouseClick GetLeftMouseClick()
        {
            return new MouseClick() { MouseButton = VirtualMouseStates.Left_Click };
        }

        public static void MinimiseSMITEClient()
        {
            // we check if the window exists first then if it does
            //
            if (ProcessInfo.DoesSmiteProcessExist())
            {
                // un-minimises window
                //
                ShowWindowAsync(ProcessInfo.GetSmiteWindowHandle(), SW_SHOWMINIMIZED);
            }
        }

        static DolphinScript.Classes.ScriptEventClasses.PasteClipboard GetPaste()
        {
            return new DolphinScript.Classes.ScriptEventClasses.PasteClipboard();
        }

        static DolphinScript.Classes.ScriptEventClasses.KeybdEvent GetEnterKeyClick()
        {
            return new DolphinScript.Classes.ScriptEventClasses.KeybdEvent() { KeybdEventBtn = VirtualKeyStates.VK_RETURN };
        }

        static DolphinScript.Classes.ScriptEventClasses.KeybdEvent GetESCKeyClick()
        {
            return new DolphinScript.Classes.ScriptEventClasses.KeybdEvent() { KeybdEventBtn = VirtualKeyStates.VK_ESCAPE };
        }

        static DolphinScript.Classes.ScriptEventClasses.KeybdEvent GetForwardSlashOEM()
        {
            return new DolphinScript.Classes.ScriptEventClasses.KeybdEvent() { KeybdEventBtn = VirtualKeyStates.VK_DIVIDE };
        }
    }
}
