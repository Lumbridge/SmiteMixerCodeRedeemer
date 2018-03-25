using System;
using System.Windows.Forms;

using static DolphinScript.Lib.Backend.Common;

namespace DolphinScript.Lib.ScriptEventClasses
{
    [Serializable]
    public class KeyboardKeyPress : ScriptEvent
    {
        public override void DoEvent()
        {
            // update the status label on the main form
            //
            Status = $"";

            SendKeys.SendWait(KeyboardKeys);
        }

        public override string GetEventListBoxString()
        {
            if (GroupID == -1)
                return "Keypress (Key(s): " + KeyboardKeys + ")";
            else
                return "[Group " + GroupID + " Repeat x" + NumberOfCycles + "] Keypress (Key: " + KeyboardKeys + ").";
        }
    }
}