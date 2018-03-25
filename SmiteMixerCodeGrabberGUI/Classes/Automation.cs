using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MixerChat;
using MixerChat.Classes;

using DolphinScript.Lib.Backend;
using DolphinScript.Lib.ScriptEventClasses;

using SmiteMixerListener.Classes;
using static SmiteMixerListener.Classes.Common;
using System.Threading;
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

            // call the main loop to carry out the event of redeeming the code
            //
            DolphinScript.Lib.Backend.Common.DoLoop(loop);
        }

        public static void RedeemAllActive()
        {
            Thread.Sleep(15000);
            while (true)
            {
                if (GetActiveCodes().Count > 0)
                {
                    foreach (var code in GetActiveCodes())
                    {
                        // get the event list and pass it the code we want it to type
                        //
                        var loop = GetRedeemLoop(code.GetCode());

                        // call the main loop to carry out the event of redeeming the code
                        //
                        DolphinScript.Lib.Backend.Common.DoLoop(loop);

                        // mark the code as redeemed
                        //
                        code.SetIsRedeemed(true);
                    }
                }
                Thread.Sleep(15000);
            }
        }

        public static List<ScriptEvent> GetRedeemLoop(string code)
        {
            return new List<ScriptEvent>()
            {
                GetMoveWindowToFront(),
                GetPause(1.0, 2.0),
                GetMouseMoveToWindow(new WinAPI.RECT(43, 788, 101, 1014)),
                GetLeftMouseClick(),
                GetPause(1.0, 2.0),
                GetMouseMoveToWindow(new WinAPI.RECT(57, 521, 86, 658)),
                GetLeftMouseClick(),
                GetPause(1.0, 2.0),
                GetMouseMoveToWindow(new WinAPI.RECT(569, 160, 610, 297)),
                GetLeftMouseClick(),
                GetPause(1.0, 2.0),
                GetMouseMoveToWindow(new WinAPI.RECT(358, 703, 372, 759)),
                GetLeftMouseClick(),
                GetPause(1.0, 2.0),
                new KeyboardKeyPress() { KeyboardKeys = code },
                GetMouseMoveToWindow(new WinAPI.RECT(396, 810, 416, 907)),
                GetLeftMouseClick(),
                GetPause(1.0, 2.0),
                GetMouseMoveToWindow(new WinAPI.RECT(603, 822, 622, 969)),
                GetLeftMouseClick(),
                GetPause(1.0, 2.0),
            };
        }

        static MoveWindowToFront GetMoveWindowToFront()
        {
            return new MoveWindowToFront() { WindowToClickTitle = "Smite (32-bit, DX9)" };
        }

        static RandomPauseInRange GetPause(double min, double max)
        {
            return new RandomPauseInRange() { DelayMaximum = max, DelayMinimum = min };
        }

        static MouseMoveToAreaOnWindow GetMouseMoveToWindow(WinAPI.RECT clickArea)
        {
            return new MouseMoveToAreaOnWindow() { ClickArea = clickArea, WindowToClickTitle = "Smite (32-bit, DX9)" };
        }

        static MouseClick GetLeftMouseClick()
        {
            return new MouseClick() { MouseButton = WinAPI.VirtualMouseStates.Left_Click };
        }
    }
}
