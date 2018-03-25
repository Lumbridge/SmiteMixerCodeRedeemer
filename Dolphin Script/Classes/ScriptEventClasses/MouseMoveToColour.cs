using System;
using System.Collections.Generic;

using static DolphinScript.Lib.Backend.Common;
using static DolphinScript.Lib.Backend.WinAPI;
using static DolphinScript.Lib.Backend.ColourEvent;
using static DolphinScript.Lib.Backend.RandomNumber;
using static DolphinScript.Lib.Backend.PointReturns;
using static DolphinScript.Lib.ScriptEventClasses.MouseMove;

namespace DolphinScript.Lib.ScriptEventClasses
{
    [Serializable]
    class MouseMoveToColour : ScriptEvent
    {
        /// <summary>
        /// Moves mouse to a colour in a given search area
        /// </summary>
        /// <param name="SearchArea"></param>
        /// <param name="SearchColour"></param>
        /// <returns></returns>
        static public void MoveMouseToColour(RECT SearchArea, int SearchColour)
        {
            List<POINT> temp = GetMatchingPixelList(SearchArea, SearchColour); // add matching colour pixels to list
            POINT EndPoint;
            POINT pos = GetCursorPosition();

            while (GetColorAt(pos).ToArgb() != SearchColour)
            {
                if (temp.Count > 0)
                {
                    temp = GetMatchingPixelList(SearchArea, SearchColour); // add matching colour pixels to list

                    EndPoint = temp[GetRandomNumber(0, temp.Count - 1)]; // pick random matching pixel to click

                    MoveMouse(EndPoint); // move mouse to picked pixel

                    GetCursorPos(out pos);
                }
                else
                    break;
            }
        }

        /// <summary>
        /// main overriden method used to perform this script event
        /// </summary>
        public override void DoEvent()
        {
            // update the status label on the main form
            //
            Status = $"Mouse move to colour: {SearchColour} in area: {ColourSearchArea.PrintArea()}.";

            // perform the mouse move method
            //
            MoveMouseToColour(ColourSearchArea, SearchColour);
        }

        /// <summary>
        /// returns a string which is added to the listbox to give information about the event which was added to the event list
        /// </summary>
        /// <returns></returns>
        public override string GetEventListBoxString()
        {
            if (GroupID == -1)
                return "Move mouse to random pixel of colour " + SearchColour + " in area " + ColourSearchArea.PrintArea() + ".";
            else
                return "[Group " + GroupID + " Repeat x" + NumberOfCycles + "] Move mouse to random pixel of colour " + SearchColour + " in area " + ColourSearchArea.PrintArea() + ".";
        }
    }
}
