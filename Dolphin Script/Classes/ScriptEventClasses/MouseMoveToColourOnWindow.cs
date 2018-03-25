using System;

using static DolphinScript.Lib.Backend.Common;
using static DolphinScript.Lib.Backend.WinAPI;
using static DolphinScript.Lib.Backend.PointReturns;
using static DolphinScript.Lib.Backend.WindowControl;
using static DolphinScript.Lib.ScriptEventClasses.MouseMoveToColour;

namespace DolphinScript.Lib.ScriptEventClasses
{
    [Serializable]
    class MouseMoveToColourOnWindow : ScriptEvent
    {
        /// <summary>
        /// main overriden method used to perform this script event
        /// </summary>
        public override void DoEvent()
        {
            // update the status label on the main form
            //
            Status = $"Mouse move to colour: {SearchColour} on window: {WindowToClickTitle}.";

            // bring the window associated with this event to the front
            //
            BringEventWindowToFront(this);

            // don't override original click area or it will cause the mouse position to incrememnt every time this method is called
            RECT NewSearchArea = GetClickAreaPositionOnWindow(WindowToClickHandle, ClickArea);

            MoveMouseToColour(NewSearchArea, SearchColour);
        }

        /// <summary>
        /// returns a string which is added to the listbox to give information about the event which was added to the event list
        /// </summary>
        /// <returns></returns>
        public override string GetEventListBoxString()
        {
            if (GroupID == -1)
                return "Move mouse to random pixel matching colour " + SearchColour + " in area " + ClickArea.PrintArea() + " on " + GetWindowTitle(WindowToClickHandle) + " window.";
            else
                return "[Group " + GroupID + " Repeat x" + NumberOfCycles + "] Move mouse to random pixel matching colour " + SearchColour + " in area " + ClickArea.PrintArea() + " on " + GetWindowTitle(WindowToClickHandle) + " window.";
        }
    }
}
