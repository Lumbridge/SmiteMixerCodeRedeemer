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
            Task.Run(()=> SetWindowTopMostIfExists("LaunchUnrealUWindowsClient", "Smite (32-bit, DX9)"));
            Thread.Sleep(100);
            RECT smiteRECT = PointReturns.GetWindowPosition(smiteHandle);
            Console.WriteLine("Current Smite Resolution: " + smiteRECT.Width + "x" + smiteRECT.Height);
            return smiteRECT;
        }
        
        public static List<ScriptEvent> GetRedeemLoop(string code)
        {
            RECT currentSmiteResolution = GetSmiteWindowResolution();
            POINT aspectRatio = GetAspectRatio(currentSmiteResolution);
            RECT m1, m2, m3, m4, m5, m6;

            Write("Current Aspect Ratio: " + aspectRatio.X + ":" + aspectRatio.Y + ".", true);

            if (aspectRatio.X == 16 && aspectRatio.Y == 9) // 16:9 ratios
            {
                Write("Using 16:9 automation script.", true);
                m1 = ReScaleRECT(new RECT(20, 844, 73, 1068), currentSmiteResolution, aspectRatio);
                m2 = ReScaleRECT(new RECT(31, 554, 59, 696), currentSmiteResolution, aspectRatio);
                m3 = ReScaleRECT(new RECT(586, 198, 619, 320), currentSmiteResolution, aspectRatio);
                m4 = ReScaleRECT(new RECT(354, 749, 367, 858), currentSmiteResolution, aspectRatio);
                m5 = ReScaleRECT(new RECT(392, 860, 417, 972), currentSmiteResolution, aspectRatio);
                m6 = ReScaleRECT(new RECT(613, 875, 635, 1042), currentSmiteResolution, aspectRatio);
            }
            else if (aspectRatio.X == 8 && aspectRatio.Y == 5) // 16:10 ratios
            {
                Write("Using 16:10 automation script.", true);
                m1 = ReScaleRECT(new RECT(16, 735, 65, 940), currentSmiteResolution, aspectRatio);
                m2 = ReScaleRECT(new RECT(29, 482, 53, 612), currentSmiteResolution, aspectRatio);
                m3 = ReScaleRECT(new RECT(568, 100, 607, 220), currentSmiteResolution, aspectRatio);
                m4 = ReScaleRECT(new RECT(342, 633, 360, 774), currentSmiteResolution, aspectRatio);
                m5 = ReScaleRECT(new RECT(382, 745, 405, 850), currentSmiteResolution, aspectRatio);
                m6 = ReScaleRECT(new RECT(597, 758, 619, 916), currentSmiteResolution, aspectRatio);
            }
            else if (aspectRatio.X == 4 && aspectRatio.Y == 3) // 4:3 ratios
            {
                Write("Using 4:3 automation script.", true);
                m1 = ReScaleRECT(new RECT(13, 563, 50, 713), currentSmiteResolution, aspectRatio);
                m2 = ReScaleRECT(new RECT(19, 368, 38, 462), currentSmiteResolution, aspectRatio);
                m3 = ReScaleRECT(new RECT(449, 52, 480, 143), currentSmiteResolution, aspectRatio);
                m4 = ReScaleRECT(new RECT(272, 478, 284, 552), currentSmiteResolution, aspectRatio);
                m5 = ReScaleRECT(new RECT(304, 564, 321, 647), currentSmiteResolution, aspectRatio);
                m6 = ReScaleRECT(new RECT(546, 566, 567, 713), currentSmiteResolution, aspectRatio);
            }
            else // unsupported aspect ratio
            {
                Write("Unsupported aspect ratio detected, defaulting to 16:9 automation script.", true);
                m1 = ReScaleRECT(new RECT(20, 844, 73, 1068), currentSmiteResolution, aspectRatio);
                m2 = ReScaleRECT(new RECT(31, 554, 59, 696), currentSmiteResolution, aspectRatio);
                m3 = ReScaleRECT(new RECT(586, 198, 619, 320), currentSmiteResolution, aspectRatio);
                m4 = ReScaleRECT(new RECT(354, 749, 367, 858), currentSmiteResolution, aspectRatio);
                m5 = ReScaleRECT(new RECT(392, 860, 417, 972), currentSmiteResolution, aspectRatio);
                m6 = ReScaleRECT(new RECT(613, 875, 635, 1042), currentSmiteResolution, aspectRatio);
            }
            
            return new List<ScriptEvent>()
            {
                GetMouseMoveToWindow(m1),
                GetLeftMouseClick(),
                GetPause(1.0, 2.0),
                GetMouseMoveToWindow(m2),
                GetLeftMouseClick(),
                GetPause(1.0, 2.0),
                GetMouseMoveToWindow(m3),
                GetLeftMouseClick(),
                GetPause(1.0, 2.0),
                GetMouseMoveToWindow(m4),
                GetLeftMouseClick(),
                GetPause(1.0, 2.0),
                new KeyboardKeyPress() { KeyboardKeys = code },
                GetMouseMoveToWindow(m5),
                GetLeftMouseClick(),
                GetPause(1.0, 2.0),
                GetMouseMoveToWindow(m6),
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
