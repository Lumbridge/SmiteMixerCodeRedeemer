using System;

using static DolphinScript.Lib.Backend.Common;
using static DolphinScript.Lib.Backend.WindowControl;

namespace DolphinScript.Lib.ScriptEventClasses
{
    [Serializable]
    class MoveWindowToFront : ScriptEvent
    {
        /// <summary>
        /// main overriden method used to perform this script event
        /// </summary>
        public override void DoEvent()
        {
            // update the status label on the main form
            //
            Status = $"Bring window to front: {WindowToClickTitle}.";

            SetWindowTopMostIfExists(WindowClass, WindowTitle);
        }

        /// <summary>
        /// returns a string which is added to the listbox to give information about the event which was added to the event list
        /// </summary>
        /// <returns></returns>
        public override string GetEventListBoxString()
        {
            if (GroupID == -1)
                return "Move " + WindowTitle + " window to front.";
            else
                return "[Group " + GroupID + " Repeat x" + NumberOfCycles + "] Move " + WindowTitle + " window to front.";
        }
    }
}
