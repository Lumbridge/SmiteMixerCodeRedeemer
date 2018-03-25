using System;
using System.Threading;

using static DolphinScript.Lib.Backend.Common;
using static DolphinScript.Lib.Backend.RandomNumber;

namespace DolphinScript.Lib.ScriptEventClasses
{
    [Serializable]
    public class RandomPauseInRange : ScriptEvent
    {
        /// <summary>
        /// main overriden method used to perform this script event
        /// </summary>
        public override void DoEvent()
        {
            double delay = GetRandomDouble(DelayMinimum, DelayMaximum);

            // update the status label on the main form
            //
            Status = $"Random pause for {delay} seconds (Between {DelayMinimum} & {DelayMaximum} secs).";

            // wait for the randomly generated time before continuing
            //
            Thread.Sleep(TimeSpan.FromSeconds(delay));
        }

        /// <summary>
        /// returns a string which is added to the listbox to give information about the event which was added to the event list
        /// </summary>
        /// <returns></returns>
        public override string GetEventListBoxString()
        {
            if (GroupID == -1)
                return "Random pause between " + DelayMinimum + " and " + DelayMaximum + " seconds.";
            else
                return "[Group " + GroupID + " Repeat x" + NumberOfCycles + "] Random pause between " + DelayMinimum + " and " + DelayMaximum + " seconds.";
        }
    }
}
