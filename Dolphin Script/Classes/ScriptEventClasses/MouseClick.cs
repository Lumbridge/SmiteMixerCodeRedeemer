using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

using static DolphinScript.Lib.Backend.Common;
using static DolphinScript.Lib.Backend.WinAPI;
using static DolphinScript.Lib.Backend.RandomNumber;

namespace DolphinScript.Lib.ScriptEventClasses
{
    /// <summary>
    /// This event can be used to simulate a variety of different mouse clicks
    /// </summary>
    [Serializable]
    public class MouseClick : ScriptEvent
    {
        /// <summary>
        /// main overriden method used to perform this script event
        /// </summary>
        public override void DoEvent()
        {
            // update the status label on the main form
            //
            Status = $"Mouse Click: {MouseButton}";

            // check which virtual mouse state is associated with the event and perform that type of mouse event
            //
            if (MouseButton == VirtualMouseStates.Left_Click)
                LeftClick();
            else if (MouseButton == VirtualMouseStates.Right_Click)
                RightClick();
            else if (MouseButton == VirtualMouseStates.Middle_Click)
                MiddleClick();
            else if (MouseButton == VirtualMouseStates.LMB_Down)
                LeftDown();
            else if (MouseButton == VirtualMouseStates.LMB_Up)
                LeftUP();
            else if (MouseButton == VirtualMouseStates.MMB_Down)
                MiddleDown();
            else if (MouseButton == VirtualMouseStates.MMB_Up)
                MiddleUP();
            else if (MouseButton == VirtualMouseStates.RMB_Down)
                RightDown();
            else if (MouseButton == VirtualMouseStates.RMB_Up)
                RightUP();
        }

        /// <summary>
        /// returns a string which is added to the listbox to give information about the event which was added to the event list
        /// </summary>
        /// <returns></returns>
        public override string GetEventListBoxString()
        {
            if (GroupID == -1)
                return "Mouse Click: " + MouseButton + ".";
            else
                return "[Group " + GroupID + " Repeat x" + NumberOfCycles + "] Mouse Click:  " + MouseButton + ".";
        }

        /// <summary>
        /// this method will simulate a simple right click
        /// </summary>
        static public void RightClick()
        {
            mouse_event((uint)VirtualMouseStates.RMB_Down, 0, 0, 0, 0);
            Task.WaitAll(Task.Delay((TimeSpan.FromSeconds(GetRandomDouble(0.1, 0.3)))));
            mouse_event((uint)VirtualMouseStates.RMB_Up, 0, 0, 0, 0);

            Thread.Sleep(TimeSpan.FromSeconds(GetRandomDouble(0.1, 0.3)));
        }

        /// <summary>
        /// this method will simulate the right mouse button being held down
        /// </summary>
        static public void RightDown()
        {
            mouse_event((uint)VirtualMouseStates.RMB_Down, 0, 0, 0, 0);

            Task.WaitAll(Task.Delay((TimeSpan.FromSeconds(GetRandomDouble(0.1, 0.3)))));
        }

        /// <summary>
        /// this method will simulate the right mouse button being released
        /// </summary>
        static public void RightUP()
        {
            mouse_event((uint)VirtualMouseStates.RMB_Up, 0, 0, 0, 0);

            Task.WaitAll(Task.Delay(TimeSpan.FromSeconds(GetRandomDouble(0.1, 0.3))));
        }

        /// <summary>
        /// this method will simulate a simple left click
        /// </summary>
        static public void LeftClick()
        {
            mouse_event((uint)VirtualMouseStates.LMB_Down, 0, 0, 0, 0);
            Task.WaitAll(Task.Delay(TimeSpan.FromSeconds(GetRandomDouble(0.1, 0.3))));
            mouse_event((uint)VirtualMouseStates.LMB_Up, 0, 0, 0, 0);

            Task.WaitAll(Task.Delay(TimeSpan.FromSeconds(GetRandomDouble(0.1, 0.3))));
        }

        /// <summary>
        /// this method will simulate the left mouse button being held down
        /// </summary>
        static public void LeftDown()
        {
            mouse_event((uint)VirtualMouseStates.LMB_Down, 0, 0, 0, 0);

            Task.WaitAll(Task.Delay(TimeSpan.FromSeconds(GetRandomDouble(0.1, 0.3))));
        }

        /// <summary>
        /// this method will simulate the left mouse button being released
        /// </summary>
        static public void LeftUP()
        {
            mouse_event((uint)VirtualMouseStates.LMB_Up, 0, 0, 0, 0);

            Task.WaitAll(Task.Delay(TimeSpan.FromSeconds(GetRandomDouble(0.1, 0.3))));
        }

        /// <summary>
        /// this method will simulate a simple middle click
        /// </summary>
        static public void MiddleClick()
        {
            mouse_event((uint)VirtualMouseStates.MMB_Down, 0, 0, 0, 0);
            Task.WaitAll(Task.Delay(TimeSpan.FromSeconds(GetRandomDouble(0.1, 0.3))));
            mouse_event((uint)VirtualMouseStates.MMB_Up, 0, 0, 0, 0);

            Task.WaitAll(Task.Delay(TimeSpan.FromSeconds(GetRandomDouble(0.1, 0.3))));
        }

        /// <summary>
        /// this method will simulate the middle mouse button being held down
        /// </summary>
        static public void MiddleDown()
        {
            mouse_event((uint)VirtualMouseStates.MMB_Down, 0, 0, 0, 0);

            Task.WaitAll(Task.Delay(TimeSpan.FromSeconds(GetRandomDouble(0.1, 0.3))));
        }

        /// <summary>
        /// this method will simulate the middle mouse button being released
        /// </summary>
        static public void MiddleUP()
        {
            mouse_event((uint)VirtualMouseStates.MMB_Up, 0, 0, 0, 0);

            Task.WaitAll(Task.Delay(TimeSpan.FromSeconds(GetRandomDouble(0.1, 0.3))));
        }

        /// <summary>
        /// we import this mouse_event method so we can use it to perform different operations using the mouse buttons
        /// </summary>
        /// <param name="dwFlags"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="cButtons"></param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
    }
}
