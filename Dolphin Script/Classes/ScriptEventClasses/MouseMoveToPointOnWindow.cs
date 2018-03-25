using System;

using static DolphinScript.Lib.Backend.Common;
using static DolphinScript.Lib.Backend.WinAPI;
using static DolphinScript.Lib.Backend.PointReturns;
using static DolphinScript.Lib.Backend.WindowControl;

using static DolphinScript.Lib.ScriptEventClasses.MouseMove;

namespace DolphinScript.Lib.ScriptEventClasses
{
    [Serializable]
    class MouseMoveToPointOnWindow : ScriptEvent
    {
        /// <summary>
        /// main overriden method used to perform this script event
        /// </summary>
        public override void DoEvent()
        {
            // update the status label on the main form
            //
            Status = $"Move mouse to {CoordsToMoveTo.ToString()} on window: {WindowTitle}.";

            // bring the window associated with this event to the front
            //
            BringEventWindowToFront(this);

            POINT NewClickPoint = new POINT(
                GetWindowPosition(WindowToClickHandle).Left + CoordsToMoveTo.X,
                GetWindowPosition(WindowToClickHandle).Top + CoordsToMoveTo.Y);

            MoveMouse(NewClickPoint);
        }

        /// <summary>
        /// returns a string which is added to the listbox to give information about the event which was added to the event list
        /// </summary>
        /// <returns></returns>
        public override string GetEventListBoxString()
        {
            if (GroupID == -1)
                return "Move mouse to Point X: " + CoordsToMoveTo.X + " Y: " + CoordsToMoveTo.Y + " on " + WindowToClickTitle + " window.";
            else
                return "[Group " + GroupID + " Repeat x" + NumberOfCycles + "] Move mouse to random point in area " + ClickArea.PrintArea() + " on " + WindowToClickTitle + " window.";
        }
    }
}
