using System;

using static DolphinScript.Lib.Backend.Common;
using static DolphinScript.Lib.Backend.WinAPI;
using static DolphinScript.Lib.Backend.PointReturns;
using static DolphinScript.Lib.Backend.WindowControl;

using static DolphinScript.Lib.ScriptEventClasses.MouseMove;
using System.Threading;

namespace DolphinScript.Lib.ScriptEventClasses
{
    /// <summary>
    /// This event moves the mouse cursor to a random point in a given area on a specific window.
    /// </summary>
    [Serializable]
    public class MouseMoveToAreaOnWindow : ScriptEvent
    {
        /// <summary>
        /// this method will move the mouse cursor to a random point in the selected area
        /// </summary>
        /// <param name="ClickArea"></param>
        static public void MoveMouseToAreaOnWindow(RECT ClickArea)
        {
            // get a random point in the area
            //
            POINT EndPoint = GetRandomPointInArea(ClickArea);

            // move the mouse cursor to the random point we got
            //
            MoveMouse(EndPoint);
        }

        /// <summary>
        /// main overriden method used to perform this script event
        /// </summary>
        public override void DoEvent()
        {
            // update the status label on the main form
            //
            Status = $"Mouse move to area: {ClickArea.PrintArea()} on window: {WindowToClickTitle}.";

            // bring the window associated with this event to the front
            //
            BringEventWindowToFront(this);

            if(ClickArea.Height > 0)
            {
                // don't override original click area or it will cause the mouse position to incrememnt every time this method is called
                RECT NewClickArea = GetClickAreaPositionOnWindow(WindowToClickHandle, ClickArea);

                // call the final mouse move method
                //
                MoveMouseToAreaOnWindow(NewClickArea);
            }
        }

        /// <summary>
        /// returns a string which is added to the listbox to give information about the event which was added to the event list
        /// </summary>
        /// <returns></returns>
        public override string GetEventListBoxString()
        {
            if (GroupID == -1)
                return "Move mouse to random point in area " + ClickArea.PrintArea() + " on " + GetWindowTitle(WindowToClickHandle) + " window.";
            else
                return "[Group " + GroupID + " Repeat x" + NumberOfCycles + "] Move mouse to random point in area " + ClickArea.PrintArea() + " on " + GetWindowTitle(WindowToClickHandle) + " window.";
        }
    }
}
