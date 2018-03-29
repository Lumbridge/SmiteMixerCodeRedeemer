using System;
using System.Collections.Generic;

using static DolphinScript.Lib.Backend.WinAPI;
using static DolphinScript.Lib.Backend.WindowControl;

namespace DolphinScript.Lib.ScriptEventClasses
{
    [Serializable]
    public abstract class ScriptEvent
    {
        // private window variables
        //
        private RECT windowRECT;
        private IntPtr windowHandle;

        // mandatory override methods
        //
        public abstract void DoEvent();
        public abstract string GetEventListBoxString();

        // gets the window handle by title (because handle ID can change often)
        //
        public IntPtr WindowToClickHandle
        {
            get
            {
                windowHandle = FindWindow(null, WindowToClickTitle);
                return windowHandle;
            }
            set { windowHandle = value; }
        }

        // gets the window location (because the window can move/scale often)
        //
        public RECT WindowToClickLocation
        {
            get
            {
                GetWindowRect(WindowToClickHandle, ref windowRECT);
                return windowRECT;
            }
            set { windowRECT = value; }
        }

        // gets/sets the title of the window, if the name of the window changes then the event will break
        // window title can change but it's the most consistent window feature we can use to get the handle and location of the window
        //
        public string WindowToClickTitle { get; set; }

        // POINT we are going to move the mouse to in mouse move events
        //
        public POINT CoordsToMoveTo { get; set; }

        // screen region we are going to move the mouse to in mouse move events
        //
        public RECT ClickArea { get; set; }
        
        // click event mouse button
        //
        public VirtualMouseStates MouseButton { get; set; }
        
        /// <summary>
        /// keybd event key
        /// </summary>
        public VirtualKeyStates KeybdEventBtn { get; set; }

        // string of keys we are sending during a keyboard type event
        //
        public string KeyboardKeys { get; set; }

        // double variables to use in pause events
        //
        public double DelayDuration { get; set; }
        public double DelayMinimum { get; set; }
        public double DelayMaximum { get; set; }

        // colour integer we are going to use when searching for colour in colour search events
        //
        public int SearchColour { get; set; }

        // list of search colours for multi-colour search events
        //
        public List<int> SearchColours { get; set; }

        // area we will search for colour in colour search events
        //
        public RECT ColourSearchArea { get; set; }

        // repeat group event list
        //
        public List<ScriptEvent> EventsInGroup { get; set; }

        // tells us if this event is part of a group event list
        //
        public bool IsPartOfGroup { get; set; }

        // gives us the Id of the group that this event is part of
        //
        public int GroupID { get; set; }

        // gives us the index of the event inside it's event group
        //
        public int GroupEventIndex
        {
            get
            {
                for (int i = 0; i < EventsInGroup.Count; i++)
                    if (EventsInGroup[i] == this)
                        return i;

                return -1;
            }
        }

        // tells us how many times the repeat group is going to repeat for before continuing
        //
        public int NumberOfCycles { get; set; }

        /// <summary>
        /// Script Event Constructor - sets default values for properties
        /// </summary>
        public ScriptEvent()
        {
            WindowToClickHandle = IntPtr.Zero;
            WindowToClickLocation = new RECT();
            WindowToClickTitle = "NoWindow";
            CoordsToMoveTo = new POINT();
            ClickArea = new RECT();
            MouseButton = VirtualMouseStates.None;
            KeyboardKeys = "NoKey";
            DelayDuration = -1.0;
            DelayMinimum = -1.0;
            DelayMaximum = -1.0;
            SearchColour = -1;
            SearchColours = new List<int>();
            ColourSearchArea = new RECT();
            EventsInGroup = new List<ScriptEvent>();
            IsPartOfGroup = false;
            GroupID = -1;
            NumberOfCycles = -1;
        }
    }
}
