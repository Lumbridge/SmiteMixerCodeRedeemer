using System;
using System.Threading;

using static DolphinScript.Lib.Backend.Common;
using static DolphinScript.Lib.Backend.ColourEvent;

namespace DolphinScript.Lib.ScriptEventClasses
{
    [Serializable]
    class PauseWhileColourDoesntExistInArea : ScriptEvent
    {
        /// <summary>
        /// main overriden method used to perform this script event
        /// </summary>
        public override void DoEvent()
        {
            while (!ColourExistsInArea(ColourSearchArea, SearchColour))
            {
                // update the status label on the main form
                //
                Status = $"Pause while colour: {SearchColour} not found in area: {ColourSearchArea.PrintArea()}, waiting {ReSearchPause} seconds before re-searching.";

                Thread.Sleep(TimeSpan.FromSeconds(ReSearchPause));
            }
        }

        /// <summary>
        /// returns a string which is added to the listbox to give information about the event which was added to the event list
        /// </summary>
        /// <returns></returns>
        public override string GetEventListBoxString()
        {
            if (GroupID == -1)
                return "Pause while colour " + SearchColour + " doesn't exist in area " + ColourSearchArea.PrintArea() + ".";
            else
                return "[Group " + GroupID + " Repeat x" + NumberOfCycles + "] Pause while colour " + SearchColour + " doesn't exist in area " + ColourSearchArea.PrintArea() + ".";
        }
    }
}
