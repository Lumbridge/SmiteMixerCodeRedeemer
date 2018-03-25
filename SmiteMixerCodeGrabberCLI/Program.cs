using System;
using MixerChat;
using MixerChat.Classes;
using System.Collections.Generic;

using DolphinScript;
using DolphinScript.Lib.Backend;
using DolphinScript.Lib.ScriptEventClasses;

using SmiteMixerListener.Classes;
using static SmiteMixerListener.Classes.Common;
using System.Threading;
using System.Threading.Tasks;

namespace SmiteMixerListener
{
    class Program
    {
        static void Main(string[] args)
        {
            // if the internal list of redeemed codes isn't instanciated yet then we need to make a new one
            if (Properties.Settings.Default.RedeemedCodes == null)
            {
                Properties.Settings.Default.RedeemedCodes = new List<string>();
                Properties.Settings.Default.Save();
            }
            
            // meta info
            Write("\n\tSmite Code Redeemer v0.9.2-Beta (Mixer) By github.com/Lumbridge.\n\n" +
                "\tCredits to myself for Dolphin Script & SmiteMixerListener Projects,\n" + 
                "\tCredits to github.com/Breeser for the Mixer Chat API.\n\n" + 
                "\tAttempting to connect to SmiteGame Mixer Chat...", false);

            if (Properties.Settings.Default.RedeemedCodes.Count > 0)
            {
                Write("\tList of redeemed codes:\n", false);
                foreach (var code in Properties.Settings.Default.RedeemedCodes)
                    Write("\t" + code + "\n", false);
            }
            else
                Write("Redeemed codes list is currently empty.", true);

            Mixer chat = new Mixer();
            chat.OnMessageReceived += Chat_OnMessageReceived;
            chat.OnUserJoined += Chat_OnUserJoined;
            chat.OnUserLeft += Chat_OnUserLeft;
            chat.OnError += Chat_OnError;
            var connected = chat.Connect("SmiteGame");

            if (connected)
                Task.Run(() => RedeemQueue());

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
                    }
                    else
                        Write("Code Spotted: " + code + " (Already Redeemed).", true);
                }
                catch { }
            }
        }

        private static void Chat_OnError(ErrorEventArgs e)
        {
            Write(e.Exception.Message, true);
        }

        private static void Chat_OnUserLeft(UserEventArgs e)
        {
            //Console.WriteLine(string.Format("{0} left", e.User));
        }

        private static void Chat_OnUserJoined(UserEventArgs e)
        {
            //Console.WriteLine(string.Format("{0} joined", e.User));
        }
        
        private static void RedeemQueue()
        {
            Write("Probing Queue in 15 seconds...", true);
            Thread.Sleep(15000);
            while (true)
            {
                if (CodeQueue.GetCodeQueue().Count > 0)
                {
                    foreach (var queuedCode in CodeQueue.GetCodeQueue())
                    {
                        // get the event list and pass it the code we want it to type
                        //
                        var loop = GetRedeemLoop(queuedCode);

                        // call the main loop to carry out the event of redeeming the code
                        //
                        DolphinScript.Lib.Backend.Common.DoLoop(loop);

                        // save the code to the internal list of redeemed codes
                        //
                        Properties.Settings.Default.RedeemedCodes.Add(queuedCode);

                        // remove the redeemed code from the code queue
                        //
                        CodeQueue.RemoveCodeFromQueue(queuedCode);
                    }
                }
                else
                    Write("No codes currently in the queue...", true);

                Thread.Sleep(15000);
            }
        }

        private static List<ScriptEvent> GetRedeemLoop(string code)
        {
            return new List<ScriptEvent>()
            {
                new MoveWindowToFront() { WindowToClickTitle = "Smite (32-bit, DX9)" },
                GetPause(0.5, 1.0),
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
