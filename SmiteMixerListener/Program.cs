using System;
using MixerChat;
using MixerChat.Classes;
using System.Collections.Generic;

using DolphinScript;
using DolphinScript.Lib.Backend;
using DolphinScript.Lib.ScriptEventClasses;

using SmiteMixerListener.Classes;

namespace SmiteMixerListener
{
    class Program
    {
        static void Main(string[] args)
        {
            Mixer chat = new Mixer();
            chat.OnMessageReceived += Chat_OnMessageReceived;
            chat.OnUserJoined += Chat_OnUserJoined;
            chat.OnUserLeft += Chat_OnUserLeft;
            chat.OnError += Chat_OnError;
            chat.Connect("SmiteGame");
            Console.ReadLine();
        }

        private static void Chat_OnMessageReceived(ChatMessageEventArgs e)
        {
            if (e.Message.Contains("AP"))
            {
                var m = e.Message;
                try
                {
                    var code = m.Substring(m.IndexOf("AP"), 17);
                    
                    if (!Properties.Settings.Default.RedeemedCodes.Contains(code) && !CodeQueue.GetCodeQueue().Contains(code) && !code.Contains(" "))
                    {
                        CodeQueue.AddCodeToQueue(code);

                        foreach(var queuedCode in CodeQueue.GetCodeQueue())
                        {
                            var loop = GetRedeemLoop(queuedCode);
                            DolphinScript.Lib.Backend.Common.DoLoop(loop);

                            Properties.Settings.Default.RedeemedCodes.Add(code);

                            CodeQueue.RemoveCodeFromQueue(code);
                        }
                    }
                }
                catch { }
            }
        }

        private static void Chat_OnError(ErrorEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
        }

        private static void Chat_OnUserLeft(UserEventArgs e)
        {
            //Console.WriteLine(string.Format("{0} left", e.User));
        }

        private static void Chat_OnUserJoined(UserEventArgs e)
        {
            //Console.WriteLine(string.Format("{0} joined", e.User));
        }

        private static List<ScriptEvent> GetRedeemLoop(string code)
        {
            return new List<ScriptEvent>()
            {
                GetMouseMoveToWindow(new WinAPI.RECT(43, 788, 101, 1014)),
                GetLeftMouseClick(),
                GetPause(0.5, 1.0),
                GetMouseMoveToWindow(new WinAPI.RECT(57, 521, 86, 658)),
                GetLeftMouseClick(),
                GetPause(0.5, 1.0),
                GetMouseMoveToWindow(new WinAPI.RECT(569, 160, 610, 297)),
                GetLeftMouseClick(),
                GetPause(0.5, 1.0),
                GetMouseMoveToWindow(new WinAPI.RECT(358, 703, 372, 759)),
                GetLeftMouseClick(),
                GetPause(0.5, 1.0),
                new KeyboardKeyPress() { KeyboardKeys = code },
                GetMouseMoveToWindow(new WinAPI.RECT(396, 810, 416, 907)),
                GetLeftMouseClick(),
                GetPause(0.5, 1.0),
                GetMouseMoveToWindow(new WinAPI.RECT(603, 822, 622, 969)),
                GetLeftMouseClick(),
                GetPause(0.5, 1.0)
            };
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
