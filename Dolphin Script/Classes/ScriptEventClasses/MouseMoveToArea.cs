using System;
using static DolphinScript.Lib.Backend.Common;
using static DolphinScript.Lib.Backend.WinAPI;
using static DolphinScript.Lib.Backend.PointReturns;

using static DolphinScript.Lib.ScriptEventClasses.MouseMove;

namespace DolphinScript.Lib.ScriptEventClasses
{
    /// <summary>
    /// This event moves the mouse cursor to a random point in a given area.
    /// </summary>
    [Serializable]
    class MouseMoveToArea : ScriptEvent
    {
        /// <summary>
        /// wrote this function in here for clarity in the doevent method
        /// </summary>
        /// <param name="ClickArea"></param>
        static public void MoveMouseToArea(RECT ClickArea)
        {
            POINT EndPoint = GetRandomPointInArea(ClickArea);

            MoveMouse(EndPoint); // move mouse to picked pixel
        }

        /// <summary>
        /// main overriden method used to perform this script event
        /// </summary>
        public override void DoEvent()
        {
            // update the status label on the main form
            //
            Status = $"Mouse move to random point in area: {ClickArea.PrintArea()}.";

            MoveMouseToArea(ClickArea);
        }

        /// <summary>
        /// returns a string which is added to the listbox to give information about the event which was added to the event list
        /// </summary>
        /// <returns></returns>
        public override string GetEventListBoxString()
        {
            if (GroupID == -1)
                return "Move mouse to random point in area " + ClickArea.PrintArea() + ".";
            else
                return "[Group " + GroupID + " Repeat x" + NumberOfCycles + "] Move mouse to random point in area " + ClickArea.PrintArea() + ".";
        }
    }
}
