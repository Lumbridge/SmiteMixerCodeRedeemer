using System;
using System.Collections.Generic;

using DolphinScript.Lib.ScriptEventClasses;
using static DolphinScript.Lib.Backend.WinAPI;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DolphinScript.Lib.Backend
{
    /// <summary>
    /// This is a general class to keep methods and variables which are required in multiple different classes.
    /// </summary>
    public class Common
    {
        private static string status;
        
        // public window properties used for 
        //
        public static string WindowClass { get; set; }
        public static string WindowTitle { get; set; }

        // this is a public string string which is used to update the last action label on the main form
        // it is here in the common class so all the sub events can update it
        //
        public static string LastAction { get; set; }

        // this is a public string which is used to update the status label on the main form
        // it is here in the common class so all sub events can update it
        //
        public static string Status
        {
            get { return status; }
            set
            {
                // when the status property is changed then we change the last action property also
                //
                LastAction = Status;

                // then override the current status
                //
                status = value;
            }
        }

        // the amount of time the script will pause before re-searching during some pause events
        //
        public static double                    ReSearchPause = 0.5;

        // this is the speed the mouse will move at during mouse move events
        //
        public static int                       MouseSpeed       = 15;

        // this is a list of lists of scripts events which stores the grouped events
        //
        public static List<List<ScriptEvent>>   AllGroups        = new List<List<ScriptEvent>>();

        // this is a list of all events in the event listbox
        //
        public static List<ScriptEvent>         AllEvents        = new List<ScriptEvent>();

        // public bools which will be used to flag when the user is registering an event
        // or running the script
        //
        public static bool                      IsRegistering    = false, 
                                                IsRunning        = false;

        // list of special sendkey codes
        //
        public static List<string> SpecialKeys = new List<string>()
        {
            "+",
            "%",
            "{LEFT}",
            "{RIGHT}",
            "{UP}",
            "{DOWN}",
            "{BACKSPACE}",
            "{BREAK}",
            "{CAPSLOCK}",
            "{DELETE}",
            "{END}",
            "{ENTER}",
            "{ESC}",
            "{HELP}",
            "{HOME}",
            "{INSERT}",
            "{NUMLOCK}",
            "{PGDN}",
            "{PGUP}",
            "{PRTSC}",
            "{SCROLLLOCK}",
            "{TAB}",
            "{F1}",
            "{F2}",
            "{F3}",
            "{F4}",
            "{F5}",
            "{F6}",
            "{F7}",
            "{F8}",
            "{F9}",
            "{F10}",
            "{F11}",
            "{F12}",
            "{F13}",
            "{F14}",
            "{F15}",
            "{F16}",
            "{ADD}",
            "{SUBTRACT}",
            "{MULTIPLY}",
            "{DIVIDE}"
        };
        
        /// <summary>
        /// this method is used to determine if the user is pressing the F5 key to stop the script
        /// </summary>
        public static void CheckForTerminationKey()
        {
            // listen for the F5 key
            //
            if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
            {
                // set is running flag to false
                IsRunning = false;
                return;
            }
        }

        /// <summary>
        /// shortcut function to write to the console
        /// </summary>
        /// <param name="text"></param>
        public static void Write(string text)
        {
            Console.WriteLine("[{0}] {1}", DateTime.Now.ToShortTimeString(), text);
        }

        /// <summary>
        /// swaps position of two elements in a collection
        /// </summary>
        /// <param name="list"></param>
        /// <param name="indexA"></param>
        /// <param name="indexB"></param>
        public static void Swap(IList<ScriptEvent> list, int indexA, int indexB)
        {
            // store temp version of element object
            //
            ScriptEvent tmp = list[indexA];
            
            // move element at index b to the location of the element we stored
            //
            list[indexA] = list[indexB];

            // move the stored element to the location of index b
            //
            list[indexB] = tmp;
        }

        /// <summary>
        /// moves a list item to another position in the collection
        /// </summary>
        /// <param name="list"></param>
        /// <param name="startIndex"></param>
        /// <param name="shiftAmount"></param>
        public static void ShiftItem(IList<ScriptEvent> list, int startIndex, int shiftAmount)
        {
            for(int i = startIndex; i < startIndex + shiftAmount; i++)
            {
                Swap(list, i, i + 1);
            }
        }

        /// <summary>
        /// moves a range of elements down a list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="startIndex"></param>
        /// <param name="groupSize"></param>
        /// <param name="shiftAmount"></param>
        public static void ShiftRange(IList<ScriptEvent> list, int startIndex, int groupSize, int shiftAmount)
        {
            for(int i = startIndex; i < shiftAmount; i++)
            {
                Swap(list, i, i + groupSize);
            }
        }

        /// <summary>
        /// This method goes through the event list once and carries out each event in the list.
        /// </summary>
        /// <param name="Events"></param>
        public static void DoLoop(List<ScriptEvent> Events)
        {
            // loop through all events in the list
            //
            foreach (var ev in Events)
            {
                // each script event has overriden the DoEvent method so each
                // script event completes their own DoEvent method before the next one is carried out
                //
                ev.DoEvent();                
            }
        }
    }
}