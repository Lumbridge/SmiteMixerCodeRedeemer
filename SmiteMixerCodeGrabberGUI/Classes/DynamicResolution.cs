using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using DolphinScript.Lib.Backend;
using System.Collections.Generic;
using DolphinScript.Lib.ScriptEventClasses;
using static DolphinScript.Lib.Backend.WinAPI;
using static DolphinScript.Lib.Backend.WindowControl;
using static SmiteMixerListener.Classes.Common;


namespace SmiteMixerCodeGrabberGUI.Classes
{
    static class DynamicResolution
    {
        public static POINT GetAspectRatio(RECT r)
        {
            int x = r.Width;
            int y = r.Height;
            return new POINT(x / GCD(x, y), y / GCD(x, y));
        }
        static int GCD(int a, int b)
        {
            int Remainder;
            while (b != 0) {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }
            return a;
        }

        public static RECT ReScaleRECT(RECT toBeScaled, RECT newResolution, POINT aspectRatio)
        {
            RECT originalResolution;

            aspectRatio = GetAspectRatio(newResolution);

            if (aspectRatio.X == 16 && aspectRatio.Y == 9)
                originalResolution = new RECT(0, 0, 1080, 1920);
            else if (aspectRatio.X == 8 && aspectRatio.Y == 5)
                originalResolution = new RECT(0, 0, 1050, 1680);
            else if (aspectRatio.X == 4 && aspectRatio.Y == 3)
                originalResolution = new RECT(0, 0, 960, 1280);
            else
                originalResolution = new RECT(0, 0, 1080, 1920);

            // work out Height scalar
            double originalH = originalResolution.Height;
            double newH = newResolution.Height;
            double differenceH = originalH - newH;
            double scaleH = originalH / newH;

            // work out Width scalar
            double originalW = originalResolution.Width;
            double newW = newResolution.Width;
            double differenceW = originalW - newW;
            double scaleW = originalW / newW;

            // scale Height of passed in RECT 
            double newTop = toBeScaled.Top / scaleH;
            double newBottom = toBeScaled.Bottom / scaleH;

            // scale Width of passed in RECT
            double newRight = toBeScaled.Right / scaleW;
            double newLeft = toBeScaled.Left / scaleW;

            return new RECT(newTop, newLeft, newBottom, newRight);
        }

        public static RECT GetSmiteWindowResolution()
        {
            Process[] processes = Process.GetProcessesByName("Smite");
            Process smiteProcess = processes[0];
            IntPtr smiteHandle = smiteProcess.MainWindowHandle;
            Task.Run(()=> SetWindowTopMostIfExists("LaunchUnrealUWindowsClient", Properties.Settings.Default.smiteWindowTitle));
            Thread.Sleep(100);
            RECT smiteRECT = PointReturns.GetWindowPosition(smiteHandle);
            Write("Current Smite Resolution: " + smiteRECT.Width + "x" + smiteRECT.Height, true);
            return smiteRECT;
        }
        
        public static List<ScriptEvent> GetRedeemLoop(string code)
        {
            if(Properties.Settings.Default.UseSlowTyping)
            {
                List<ScriptEvent> SlowTypingScript = new List<ScriptEvent>()
                {
                    new MouseMoveToAreaOnWindow() { ClickArea = new RECT(), WindowToClickTitle = Properties.Settings.Default.smiteWindowTitle },
                    GetPause(1.0, 1.5),
                    new KeyboardKeyPress() { KeyboardKeys = "{ENTER}" },
                    new KeyboardKeyPress() { KeyboardKeys = "{ENTER}" },
                    GetPause(1.0, 1.5)
                };
                var fullcode = "/claimpromotion " + code;
                foreach (var letter in fullcode)
                {
                    SlowTypingScript.Add(new KeyboardKeyPress() { KeyboardKeys = letter.ToString() });
                    SlowTypingScript.Add(GetPause(0.1, 0.3));
                }
                SlowTypingScript.Add(GetPause(0.3, 0.5));
                SlowTypingScript.Add(new KeyboardKeyPress() { KeyboardKeys = "{ENTER}" });
                SlowTypingScript.Add(new KeyboardKeyPress() { KeyboardKeys = "{ENTER}" });
                SlowTypingScript.Add(GetPause(1.0, 1.5));
                SlowTypingScript.Add(new KeyboardKeyPress() { KeyboardKeys = "{ESC}" });
                SlowTypingScript.Add(new KeyboardKeyPress() { KeyboardKeys = "{ESC}" });
                return SlowTypingScript;
            }
            else
            {
                return new List<ScriptEvent>()
                {
                    new MouseMoveToAreaOnWindow() { ClickArea = new RECT(), WindowToClickTitle = Properties.Settings.Default.smiteWindowTitle },
                    GetPause(1.0, 1.5),
                    new KeyboardKeyPress() { KeyboardKeys = "{ENTER}" },
                    new KeyboardKeyPress() { KeyboardKeys = "{ENTER}" },
                    GetPause(1.0, 1.5),
                    new KeyboardKeyPress() { KeyboardKeys = "/claimpromotion " + code },
                    GetPause(0.3, 0.5),
                    new KeyboardKeyPress() { KeyboardKeys = "{ENTER}" },
                    new KeyboardKeyPress() { KeyboardKeys = "{ENTER}" },
                    GetPause(1.0, 1.5),
                    new KeyboardKeyPress() { KeyboardKeys = "{ESC}" },
                    new KeyboardKeyPress() { KeyboardKeys = "{ESC}" }
                };
            }
        }

        static MoveWindowToFront GetMoveWindowToFront()
        {
            return new MoveWindowToFront() { WindowToClickTitle = Properties.Settings.Default.smiteWindowTitle };
        }

        static RandomPauseInRange GetPause(double min, double max)
        {
            return new RandomPauseInRange() { DelayMaximum = max, DelayMinimum = min };
        }

        static MouseMoveToAreaOnWindow GetMouseMoveToWindow(WinAPI.RECT clickArea)
        {
            return new MouseMoveToAreaOnWindow() { ClickArea = clickArea, WindowToClickTitle = Properties.Settings.Default.smiteWindowTitle };
        }

        static MouseClick GetLeftMouseClick()
        {
            return new MouseClick() { MouseButton = WinAPI.VirtualMouseStates.Left_Click };
        }
    }
}
