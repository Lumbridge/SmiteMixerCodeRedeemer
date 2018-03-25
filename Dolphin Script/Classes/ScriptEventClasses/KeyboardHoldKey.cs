using System;

using static DolphinScript.Lib.Backend.Common;

namespace DolphinScript.Lib.ScriptEventClasses
{
    [Serializable]
    class KeyboardHoldKey : ScriptEvent
    {
        public override void DoEvent()
        {
            // update the status label on the main form
            //
            Status = $"";

            throw new NotImplementedException();
        }

        public override string GetEventListBoxString()
        {
            throw new NotImplementedException();
        }
    }
}
