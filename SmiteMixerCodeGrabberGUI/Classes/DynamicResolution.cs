using DolphinScript.Lib.Backend;
using DolphinScript.Lib.ScriptEventClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DolphinScript.Lib.Backend.WinAPI;
using static DolphinScript.Lib.Backend.WindowControl;

namespace SmiteMixerCodeGrabberGUI.Classes
{
    static class DynamicResolution
    {
        public static int GetPercentageScaleDifference(RECT resolution)
        {
            RECT original = new RECT(0, 0, 1080, 1920);

            decimal totalOriginal = original.Height * original.Width;
            decimal totalNew = resolution.Height * resolution.Width;
            decimal totalDifference = totalOriginal - totalNew;
            decimal pChange = (totalDifference / totalOriginal) * 100;

            if (pChange < 0)
                Console.WriteLine(resolution.PrintArea() + " is " + pChange + "% smaller than " + original.PrintArea());
            else
                Console.WriteLine(resolution.PrintArea() + " is " + pChange + "% larger than " + original.PrintArea());

            Console.WriteLine("\nReturning Scalar: " + (int)Math.Round((totalDifference / totalOriginal) * 100));

            return (int)Math.Round((totalDifference / totalOriginal) * 100);
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
            var scale = GetPercentageScaleDifference(GetSmiteWindowResolution());

            RECT m1, m2, m3, m4, m5, m6;

            if (scale < 0)
            {
                scale = Math.Abs(scale);
                m1 = new RECT(20, 844, 73, 1068).ScaleDown(scale);
                m2 = new RECT(31, 554, 59, 696).ScaleDown(scale);
                m3 = new RECT(586, 198, 619, 320).ScaleDown(scale);
                m4 = new RECT(354, 749, 367, 858).ScaleDown(scale);
                m5 = new RECT(392, 860, 417, 972).ScaleDown(scale);
                m6 = new RECT(613, 875, 635, 1042).ScaleDown(scale);
            }
            else if (scale == 0)
            {
                m1 = new RECT(20, 844, 73, 1068);
                m2 = new RECT(31, 554, 59, 696);
                m3 = new RECT(586, 198, 619, 320);
                m4 = new RECT(354, 749, 367, 858);
                m5 = new RECT(392, 860, 417, 972);
                m6 = new RECT(613, 875, 635, 1042);

            }
            else
            {
                m1 = new RECT(20, 844, 73, 1068).ScaleUp(scale);
                m2 = new RECT(31, 554, 59, 696).ScaleUp(scale);
                m3 = new RECT(586, 198, 619, 320).ScaleUp(scale);
                m4 = new RECT(354, 749, 367, 858).ScaleUp(scale);
                m5 = new RECT(392, 860, 417, 972).ScaleUp(scale);
                m6 = new RECT(613, 875, 635, 1042).ScaleUp(scale);
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
