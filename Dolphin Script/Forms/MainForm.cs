//
// native namespace references
//
using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

//
// script event object reference
//
using DolphinScript.Lib.ScriptEventClasses;

//
// static class references
//
using static DolphinScript.Lib.Backend.Common;
using static DolphinScript.Lib.Backend.WinAPI;
using static DolphinScript.Lib.Backend.ColourEvent;
using static DolphinScript.Lib.Backend.PointReturns;
using static DolphinScript.Lib.Backend.WindowControl;
using static DolphinScript.Lib.Backend.ScreenCapture;

namespace DolphinScript
{
    public partial class MainForm : Form
    {        
        /// <summary>
        /// main form constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            Status = "Status: Idle";
            LastAction = "Last Action: None";

            // add all keys to the key event combo box
            //
            foreach (string key in SpecialKeys)
                ComboBox_SpecialKeys.Items.Add(key);

            // set the default index for the keys combo box
            //
            ComboBox_SpecialKeys.SelectedIndex = 17;

            // run the cursor update method on a new thread
            //
            Task.Run(() => UpdateMouse());
        }

        #region Main Form Methods

        /// <summary>
        /// main loop which runs all of the script events in the event list
        /// </summary>
        private void MainLoop()
        {
            // loop while the IsRunning varaible is true
            //
            while (IsRunning)
            {
                // loop through all events in the list
                //
                foreach (var ev in AllEvents)
                {
                    // check if the event if part of a repeat group
                    //
                    if (ev.IsPartOfGroup && ev.EventsInGroup.IndexOf(ev) == 0)
                    {
                        for (int i = 0; i < ev.NumberOfCycles; i++)
                        {
                            // do each subevent in the group list
                            //
                            foreach (var subEvent in ev.EventsInGroup)
                            {
                                if (UpdateListboxCurrentEventIndex(subEvent))
                                    break;

                                // call overriden do method
                                //
                                subEvent.DoEvent();
                            }
                        }
                    }
                    else if (ev.IsPartOfGroup && ev.EventsInGroup.IndexOf(ev) != 0)
                    {
                        // skip the event because it was completed by the group loop
                        //
                    }
                    else
                    {
                        if (UpdateListboxCurrentEventIndex(ev))
                            break;

                        // each script event has overriden the DoEvent method so each
                        // script event completes their own DoEvent method before the next one is carried out
                        //
                        ev.DoEvent();
                    }
                }
            }

            // change the text back to normal while the script isn't running
            //
            button_StartScript.Text = "Start Script";

            // if the loop has ended then we reenable the form buttons
            //
            ToggleControls(true);
        }

        /// <summary>
        /// toggles certain controls on the form between enabled and disabled
        /// </summary>
        /// <param name="State"></param>
        private void ToggleControls(bool State)
        {
            // start button
            //
            button_StartScript.Enabled = State;

            // move element buttons
            //
            button_MoveEventUp.Enabled = State;
            button_RemoveEvent.Enabled = State;
            button_MoveEventDown.Enabled = State;

            // mouse speed toggles
            //
            NumericUpDown_MouseSpeed.Enabled = State;
            TrackBar_MouseSpeed.Enabled = State;

            // repeat group toggles
            //
            NumericUpDown_RepeatAmount.Enabled = State;
            button_AddRepeatGroup.Enabled = State;
            button_RemoveRepeatGroup.Enabled = State;
        }

        /// <summary>
        /// clears the contents of the main form listbox and updates it with the items in the event list
        /// </summary>
        /// <param name="mf"></param>
        public void UpdateListBox()
        {
            // clear the listbox
            //
            ListBox_Events.Items.Clear();

            // add all events in the eventlist to the listbox
            //
            foreach (var scriptevent in AllEvents)
                ListBox_Events.Items.Add(scriptevent.GetEventListBoxString());
        }

        /// <summary>
        /// updates the cursor position & current active window title in form text boxes
        /// </summary>
        /// <returns></returns>
        private void UpdateMouse()
        {
            try
            {
                // stop updating if the form is being disposed
                //
                while (!IsDisposed && !Disposing)
                {
                    // check if the user wants to end the script
                    //
                    CheckForTerminationKey();

                    // update the current script status
                    //
                    statusLabel.Text = Status;
                    lastActionLabel.Text = LastAction;

                    // update the colour buttons with the colour of the pixel underneath the cursor position
                    //
                    Button_ColourPreview1.BackColor = GetColorAt(GetCursorPosition());
                    Button_ColourPreview2.BackColor = GetColorAt(GetCursorPosition());
                    Button_ColourPreview3.BackColor = GetColorAt(GetCursorPosition());

                    // update the position of the cursor in screen coordinates
                    //
                    TextBox_MousePosX_1.Text = Cursor.Position.X.ToString();
                    TextBox_MousePosY_1.Text = Cursor.Position.Y.ToString();
                    TextBox_MousePosX_2.Text = Cursor.Position.X.ToString();
                    TextBox_MousePosY_2.Text = Cursor.Position.Y.ToString();

                    // update the active window title box
                    //
                    TextBox_ActiveWindowTitle_1.Text = GetActiveWindowTitle();
                    TextBox_ActiveWindowTitle_2.Text = GetActiveWindowTitle();

                    // update the position of the cursor inside the currently active window
                    //
                    TextBox_ActiveWindowMouseX_1.Text = GetCursorPositionOnWindow(GetForegroundWindow()).X.ToString();
                    TextBox_ActiveWindowMouseY_1.Text = GetCursorPositionOnWindow(GetForegroundWindow()).Y.ToString();
                    TextBox_ActiveWindowMouseX_2.Text = GetCursorPositionOnWindow(GetForegroundWindow()).X.ToString();
                    TextBox_ActiveWindowMouseY_2.Text = GetCursorPositionOnWindow(GetForegroundWindow()).Y.ToString();


                    // add a delay to minimise CPU usage
                    //
                    Thread.Sleep(50);
                }
            }
            catch { }
        }

        /// <summary>
        /// updates the selected index in the events listbox and provides a way of breaking the main
        /// loop if the script should no longer be running
        /// </summary>
        /// <param name="ev"></param>
        /// <returns></returns>
        private bool UpdateListboxCurrentEventIndex(ScriptEvent ev)
        {
            if (!IsRunning)
            {
                ListBox_Events.ClearSelected();
                return true;
            }
            else
            {
                ListBox_Events.ClearSelected();
                ListBox_Events.SelectedIndex = AllEvents.IndexOf(ev);
                return false;
            }
        }

        #endregion

        #region Form Control Events

        #region Buttons

        /// <summary>
        /// button which starts the script
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, EventArgs e)
        {
            // check that there are events in the list before starting
            //
            if (AllEvents.Count > 0)
            {
                // set is running to true
                //
                IsRunning = true;

                // change script button text while running
                //
                button_StartScript.Text = "Script Running (F5 to stop)...";

                // disable controls while script is running
                //
                ToggleControls(false);

                // run the main loop
                //
                Task.Run(() => MainLoop());
            }
            else
            {
                // if the user clicks start when there are no events then
                // we show them this message box
                //
                MessageBox.Show("No events have been added.");
            }
        }

        /// <summary>
        /// when this button is clicked, the selected item in the listbox will be moved up a space
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moveElementUpButton_Click(object sender, EventArgs e)
        {
            /* 
             * possibilities include:
             * non-group selected, group above
             * group selected, non-group above
             * group selected, same group above
             * group selected, different group above
             * non-group selected, non-group above
            */

            if (ListBox_Events.SelectedIndex > 0)
            {
                // first get the selected and above events
                //
                ScriptEvent selected = AllEvents[ListBox_Events.SelectedIndex];
                ScriptEvent above = AllEvents[ListBox_Events.SelectedIndex - 1];

                // get the indices of the events we're using
                //
                int selectedIndex = ListBox_Events.SelectedIndex;
                int aboveIndex = ListBox_Events.SelectedIndex - 1;

                //
                // non-group selected, non-group above (normal swap - selected moves above, above event moves below)
                //
                if (!selected.IsPartOfGroup && !above.IsPartOfGroup)
                {
                    Swap(AllEvents, aboveIndex, selectedIndex);
                }
                //
                // group selected, non-group above (group moves above non-group event & non-group event above moves below group)
                //
                else if (selected.IsPartOfGroup && !above.IsPartOfGroup)
                {
                    // get the size of the group we need to shift
                    //
                    int groupSize = selected.EventsInGroup.Count;

                    // shift the events one by one until the non-group event is below the group
                    //
                    ShiftItem(AllEvents, aboveIndex, groupSize);
                }
                //
                // group selected, same group above (move the group event up within the group)
                //
                else if (selected.IsPartOfGroup && above.IsPartOfGroup && selected.GroupID == above.GroupID)
                {
                    // get the indices of the events in their group-event lists so we can swap them
                    //
                    int selectedGroupIndex = selected.GroupEventIndex;
                    int aboveGroupIndex = above.GroupEventIndex;

                    // swap the events in the main event list
                    //
                    Swap(AllEvents, selectedIndex, aboveIndex);

                    // swap the events within the group list
                    //
                    Swap(AllGroups[AllEvents[selectedIndex].GroupID - 1], selectedGroupIndex, aboveGroupIndex);
                }
                //
                // group selected, different group above (swap the position of both groups)
                //
                else if (selected.IsPartOfGroup && above.IsPartOfGroup && selected.GroupID != above.GroupID)
                {
                    int aboveGroupSize = above.EventsInGroup.Count;
                    int selectedGroupSize = selected.EventsInGroup.Count;

                    ShiftRange(AllEvents, aboveIndex - aboveGroupSize + 1, aboveGroupSize, selectedGroupSize);
                }
                //
                // some error occurred
                //
                else
                {
                    MessageBox.Show("Error moving event.");
                }

                UpdateListBox();

                // select the item again after it's moved so the user can move it again if needed
                //
                if (selected.IsPartOfGroup)
                {
                    // if we move a group past another group then set the selected index to the top of the group
                    //
                    ListBox_Events.SelectedIndex = selected.EventsInGroup.Count - selectedIndex;
                }
                else
                {
                    // select the event we just moved so we can move it again quickly if we want to
                    //
                    if (selectedIndex - 1 >= 0)
                        ListBox_Events.SelectedIndex = selectedIndex - 1;
                    else
                        ListBox_Events.SelectedIndex = selectedIndex;
                }
            }
        }

        /// <summary>
        /// when this button is clicked, the selected item in the listbox will be moved down a space
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moveElementDownButton_Click(object sender, EventArgs e)
        {
            /* 
             * possibilities include:
             * non-group selected, group below
             * group selected, non-group below
             * group selected, same group below
             * group selected, different group below
             * non-group selected, non-group below
            */

            if (ListBox_Events.SelectedIndex < ListBox_Events.Items.Count)
            {
                // first get the selected and above events
                //
                ScriptEvent selected = AllEvents[ListBox_Events.SelectedIndex];
                ScriptEvent below = AllEvents[ListBox_Events.SelectedIndex + 1];

                // get the indices of the events we're using
                //
                int selectedIndex = ListBox_Events.SelectedIndex;
                int belowIndex = ListBox_Events.SelectedIndex + 1;

                //
                // non-group selected, non-group below (normal swap - selected moves below, below event moves above)
                //
                if (!selected.IsPartOfGroup && !below.IsPartOfGroup)
                {
                    Swap(AllEvents, belowIndex, selectedIndex);
                }
                //
                // group selected, non-group below (group moves below non-group event & non-group event below moves above group)
                //
                else if (selected.IsPartOfGroup && !below.IsPartOfGroup)
                {
                    // get the size of the group we're shifting
                    //
                    int selectedGroupSize = selected.EventsInGroup.Count;

                    // move the whole group under the event below us
                    //
                    ShiftRange(AllEvents, selectedIndex - selectedGroupSize + 1, selectedGroupSize, 1);
                }
                //
                // group selected, same group below (move the group event down within the group)
                //
                else if (selected.IsPartOfGroup && below.IsPartOfGroup && selected.GroupID == below.GroupID)
                {
                    // get the indices of the events in their group-event lists so we can swap them
                    //
                    int selectedGroupIndex = selected.GroupEventIndex;
                    int belowGroupIndex = below.GroupEventIndex;

                    // swap the events in the main event list
                    //
                    Swap(AllEvents, selectedIndex, belowIndex);

                    // swap the events within the group list
                    //
                    Swap(AllGroups[AllEvents[selectedIndex].GroupID - 1], selectedGroupIndex, belowGroupIndex);
                }
                //
                // group selected, different group below (swap the position of both groups)
                //
                else if (selected.IsPartOfGroup && below.IsPartOfGroup && selected.GroupID != below.GroupID)
                {
                    // get the size of the group below us
                    //
                    int belowGroupSize = below.EventsInGroup.Count;

                    // get the size of the group we're shifting
                    //
                    int selectedGroupSize = selected.EventsInGroup.Count;

                    // move the whole selected group under the group below us
                    //
                    ShiftRange(AllEvents, selectedIndex - selectedGroupSize + 1, selectedGroupSize, belowGroupSize);
                }
                //
                // some error occurred
                //
                else
                {
                    MessageBox.Show("Error moving event.");
                }

                UpdateListBox();

                // select the item again after it's moved so the user can move it again if needed
                //
                if (selectedIndex + 1 <= ListBox_Events.Items.Count)
                    ListBox_Events.SelectedIndex = selectedIndex + 1;
                else
                    ListBox_Events.SelectedIndex = selectedIndex;
            }
        }

        /// <summary>
        /// this button removes an event from the event list and the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeEventButton_Click(object sender, EventArgs e)
        {
            // check that the selected item is between the bounds of the listbox
            //
            if (ListBox_Events.SelectedIndex >= 0 && ListBox_Events.SelectedIndex <= ListBox_Events.Items.Count)
            {
                // create a temp variable of the selected index so it's easier to type
                //
                int temp = ListBox_Events.SelectedIndex;

                // remove the script event from the allevents list
                //
                AllEvents.RemoveAt(temp);

                // update the listbox to show the changes
                //
                UpdateListBox();

                // select the item next to the one we removed so the user quickly delete multiple events if needed
                //
                if (temp >= ListBox_Events.Items.Count)
                    ListBox_Events.SelectedIndex = temp - 1;
                else if (temp < 0)
                    ListBox_Events.SelectedIndex = temp + 1;
                else
                    ListBox_Events.SelectedIndex = temp;
            }
            else
            {
                // disable the remove event button if there are no items left in the listbox
                //
                button_RemoveEvent.Enabled = false;
            }
        }

        /// <summary>
        /// this button adds the selected items to a group, sub groups can be looped a number of times before the script continues
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repeatGroupButton_Click(object sender, EventArgs e)
        {
            // check that we have more than one event selected in the listbox
            //
            if (ListBox_Events.SelectedIndices.Count > 1)
            {
                // check that none of the selected events are part of a group already
                //
                for (int i = ListBox_Events.SelectedIndex; i < ListBox_Events.SelectedIndices.Count; i++)
                {
                    if (AllEvents[i].IsPartOfGroup)
                    {
                        MessageBox.Show("One or more selected events are already part of a group, events can only be part of one group.");
                        return;
                    }
                }

                // add a new list of script events to the all groups list
                //
                AllGroups.Add(new List<ScriptEvent>());

                // loop through all the selected events in the listbox
                //
                for (int i = ListBox_Events.SelectedIndex; i < ListBox_Events.SelectedIndices.Count + ListBox_Events.SelectedIndex; i++)
                {
                    // set the event as part of a group
                    //
                    AllEvents[i].IsPartOfGroup = true;

                    // set the group ID of the selected event
                    //
                    AllEvents[i].GroupID = AllGroups.Count;

                    // set the number of times the group is going to repeat
                    //
                    AllEvents[i].NumberOfCycles = (int)NumericUpDown_RepeatAmount.Value;

                    // add the event to the all groups sub-list
                    //
                    AllGroups[AllGroups.Count - 1].Add(AllEvents[i]);
                }

                // loop through all the selected events again
                //
                for (int i = ListBox_Events.SelectedIndex; i < ListBox_Events.SelectedIndices.Count + ListBox_Events.SelectedIndex; i++)
                {
                    // update their events in group list
                    //
                    AllEvents[i].EventsInGroup = AllGroups[AllGroups.Count - 1];
                }

                // update the listbox to show any changes
                //
                UpdateListBox();
            }
            else
            {
                // if the user doesn't have multiple events selected then they can't make a group
                //
                MessageBox.Show("Select more than 1 item to create a group.");
            }
        }

        /// <summary>
        /// this button disbands the group associated with the selected event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_RemoveRepeatGroup_Click(object sender, EventArgs e)
        {
            // check that we only have one event selected
            //
            if (ListBox_Events.SelectedIndices.Count > 1)
            {
                // we have more than one event selected
                //
                MessageBox.Show("Select only one event from the group and try again.");
            }
            else
            {
                // check that the item we have selected is part of a group
                //
                if (!AllEvents[ListBox_Events.SelectedIndex].IsPartOfGroup)
                {
                    // event isn't part of a group
                    //
                    MessageBox.Show("Error: Event not part of group.");
                }
                else
                {
                    // create a local variable of the group we're removing
                    //
                    int removeGroupID = AllEvents[ListBox_Events.SelectedIndex].GroupID;

                    // remove the group flags from the allevents events
                    //
                    foreach (ScriptEvent ev in AllEvents)
                    {
                        if (ev.GroupID == removeGroupID)
                        {
                            ev.GroupID = -1;
                            ev.IsPartOfGroup = false;
                            ev.NumberOfCycles = -1;
                            ev.EventsInGroup.Clear();
                        }
                    }

                    // remove the group from the all groups collection
                    //
                    AllGroups[removeGroupID - 1].Clear();

                    // update the main event list box
                    //
                    UpdateListBox();
                }
            }
        }

        #endregion

        #region Menu Items

        /// <summary>
        /// this menu item is used in the event that the script ends but the button is not re-enabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleControls(true);
            IsRunning = false;
            IsRegistering = false;
        }

        /// <summary>
        /// this will be called when the save script button is pressed on the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            // Save Config File Function
            //

            // create a new instance of the save file dialog object
            //
            SaveFileDialog sfd = new SaveFileDialog();

            // set the default file extension
            //
            sfd.DefaultExt = ".txt";

            // make windows attach the extension to the end of the filename
            //
            sfd.AddExtension = true;

            // set the initial directory to the desktop
            //
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // make windows use the directory we set initially
            //
            sfd.RestoreDirectory = true;

            // set a default name to use for the file being saved
            //
            sfd.FileName = "My Script";

            // store the result of the open file dialog interaction
            //
            var result = sfd.ShowDialog();

            if (result == DialogResult.OK)
            {
                using (Stream s = File.Open(sfd.FileName, FileMode.Create))
                {
                    BinaryFormatter b = new BinaryFormatter();

                    b.Serialize(s, AllEvents);

                    //// use overriden save config string method on each script event in the list to save them to the file
                    ////
                    //foreach (var ev in AllEvents)
                    //    writer.Write(ev.SaveConfigString());
                }
            }
        }

        /// <summary>
        /// this will be called when the load script button is pressed on the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadScriptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //
            // Load Config File Function
            //

            // create a new instance of the open file dialog object
            //
            OpenFileDialog ofd = new OpenFileDialog();

            // set the default file extension
            //
            ofd.DefaultExt = ".txt";

            // make windows attach the extension to the end of the filename
            //
            ofd.AddExtension = true;

            // set the initial directory to the desktop
            //
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // make windows use the directory we set initially
            //
            ofd.RestoreDirectory = true;

            // store the result of the open file dialog interaction
            //
            var result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                using (Stream s = File.Open(ofd.FileName, FileMode.Open))
                {
                    BinaryFormatter b = new BinaryFormatter();

                    AllEvents = (List<ScriptEvent>)b.Deserialize(s);
                }
            }

            // show the changes in the listbox
            //
            UpdateListBox();
        }

        /// <summary>
        /// basic information about creator github
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Ryan Sainty @ https://github.com/Lumbridge");
        }

        /// <summary>
        /// opens the program wiki in user's default browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Lumbridge/Dolphin-Script/wiki");
        }

        #endregion

        #region Numeric Up/Down controls

        /// <summary>
        /// the primary function here is to make sure that the lower bound value doesn't go above the upper bound value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lowerRandomDelayNumberBox_ValueChanged(object sender, EventArgs e)
        {
            if (lowerRandomDelayNumberBox.Value > upperRandomDelayNumberBox.Value)
                // if the lower bound value is above the upper bound value then
                // add 0.2 to the upper bound value to make it higher than the lower
                // bound value...
                //
                upperRandomDelayNumberBox.Value += (decimal)0.2;
        }

        /// <summary>
        /// the primary function here is to make sure that the upper bound value doesn't go below the lower bound value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upperRandomDelayNumberBox_ValueChanged(object sender, EventArgs e)
        {
            if (upperRandomDelayNumberBox.Value < lowerRandomDelayNumberBox.Value)
                // if the upper bound value is below the lower bound value then
                // minus 0.2 from the lower bound value to lower than the upper
                // bound value...
                //
                lowerRandomDelayNumberBox.Value -= (decimal)0.2;
        }

        /// <summary>
        /// when this value is changed we update the global mouse speed variable and the value on the mouse speed track bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDown_MouseSpeed_ValueChanged(object sender, EventArgs e)
        {
            // update the global mouse speed variable
            //
            MouseSpeed = (int)NumericUpDown_MouseSpeed.Value;

            // update the mouse speed trackbar with the new speed
            //
            TrackBar_MouseSpeed.Value = (int)NumericUpDown_MouseSpeed.Value;
        }

        #endregion

        #region Listbox Control Events

        /// <summary>
        /// called when an item in the events listbox is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_Events_SelectedIndexChanged(object sender, EventArgs e)
        {
            // disable the move item up button if it's already at the top
            //
            if (ListBox_Events.SelectedIndex <= 0)
                button_MoveEventUp.Enabled = false;
            else
                button_MoveEventUp.Enabled = true;

            // disable the move item down button if it's already at the bottom
            //
            if (ListBox_Events.SelectedIndex >= ListBox_Events.Items.Count - 1)
                button_MoveEventDown.Enabled = false;
            else
                button_MoveEventDown.Enabled = true;

            // if the listbox has no item selected then diable the remove item button
            //
            if (ListBox_Events.SelectedIndex <= ListBox_Events.Items.Count - 1 && ListBox_Events.SelectedIndex >= 0)
                button_RemoveEvent.Enabled = true;
            else
                button_RemoveEvent.Enabled = false;
        }

        #endregion

        #region Trackbar Events

        /// <summary>
        /// when this value is changed we update the global mouse speed variable and the value in the mouse speed number box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackBar_MouseSpeed_Scroll(object sender, EventArgs e)
        {
            // update the global mouse speed variable
            //
            NumericUpDown_MouseSpeed.Value = TrackBar_MouseSpeed.Value;

            // update the mouse speed number box with the new speed
            //
            MouseSpeed = TrackBar_MouseSpeed.Value;
        }

        #endregion
        
        #endregion Form Control Events

        #region Pause Event Buttons

        private void Button_AddFixedPause_Click(object sender, EventArgs e)
        {
            AllEvents.Add(new FixedPause() { DelayDuration = (double)fixedDelayNumberBox.Value });

            UpdateListBox();
        }

        private void Button_AddRandomPause_Click(object sender, EventArgs e)
        {
            AllEvents.Add(new RandomPauseInRange() { DelayMinimum = (double)lowerRandomDelayNumberBox.Value, DelayMaximum = (double)upperRandomDelayNumberBox.Value });

            UpdateListBox();
        }

        private void Button_InsertPauseWhileColourExistsInArea_Click(object sender, EventArgs e)
        {
            Task.Run(() => PauseWhileColourExistsInAreaLoop());
        }

        private void Button_InsertPauseWhileColourDoesntExistInArea_Click(object sender, EventArgs e)
        {
            Task.Run(() => PauseWhileColourDoesntExistInAreaLoop());
        }

        private void Button_InsertPauseWhileColourExistsInAreaOnWindow_Click(object sender, EventArgs e)
        {
            Task.Run(() => PauseWhileColourExistsInAreaOnWindowLoop());
        }

        private void Button_InsertPauseWhileColourDoesntExistInAreaOnWindow_Click(object sender, EventArgs e)
        {
            Task.Run(() => PauseWhileColourDoesntExistInAreaOnWindowLoop());
        }

        #endregion

        #region Keyboard Event Buttons

        private void Button_AddSpecialButton_Click(object sender, EventArgs e)
        {
            // add the selected special key to the keyboard event text box
            //
            RichTextBox_KeyboardEvent.AppendText(ComboBox_SpecialKeys.SelectedItem.ToString());
        }

        private void Button_AddKeypressEvent_Click(object sender, EventArgs e)
        {
            // add the keyboard event to the event list
            //
            AllEvents.Add(new KeyboardKeyPress { KeyboardKeys = RichTextBox_KeyboardEvent.Text });

            // update the event list box with the new event
            //
            UpdateListBox();
        }

        #endregion

        #region Mouse Move Button Events

        private void button_InsertMouseMoveEvent_Click(object sender, EventArgs e)
        {
            Task.Run(() => MouseMoveToFixedPointLoop());
        }

        private void button_InsertMouseMoveToAreaEvent_Click(object sender, EventArgs e)
        {
            Task.Run(() => MouseMoveToAreaLoop());
        }

        private void button_InsertMouseMoveToPointOnWindowEvent_Click(object sender, EventArgs e)
        {
            Task.Run(() => MouseMoveToPointOnWindowLoop());
        }

        private void button_InsertMouseMoveToAreaOnWindowEvent_Click(object sender, EventArgs e)
        {
            Task.Run(() => MouseMoveToAreaOnWindowLoop());
        }

        #endregion

        #region Mouse Move To Colour Button Events

        private void Button_InsertColourSearchAreaEvent_Click(object sender, EventArgs e)
        {
            Task.Run(() => MouseMoveToColourInAreaLoop());
        }

        private void Button_InsertColourSearchAreaWindowEvent_Click(object sender, EventArgs e)
        {
            Task.Run(() => MouseMoveToColourInAreaOnWindowLoop());
        }

        private void Button_InsertMultiColourSearchAreaWindowEvent_Click(object sender, EventArgs e)
        {
            Task.Run(() => MouseMoveToMutliColourInAreaOnWindowLoop());
        }

        #endregion

        #region Mouse Click Button Events

        private void Button_InsertLeftClickEvent_Click(object sender, EventArgs e)
        {
            AllEvents.Add(new MouseClick() { MouseButton = VirtualMouseStates.Left_Click });

            UpdateListBox();
        }

        private void Buton_InsertMiddleMouseClickEvent_Click(object sender, EventArgs e)
        {
            AllEvents.Add(new MouseClick() { MouseButton = VirtualMouseStates.Middle_Click });

            UpdateListBox();
        }

        private void Button_InsertRightClickEvent_Click(object sender, EventArgs e)
        {
            AllEvents.Add(new MouseClick() { MouseButton = VirtualMouseStates.Right_Click });

            UpdateListBox();
        }

        private void Button_InsertLMBDown_Click(object sender, EventArgs e)
        {
            AllEvents.Add(new MouseClick() { MouseButton = VirtualMouseStates.LMB_Down });

            UpdateListBox();
        }

        private void Button_InsertMMBDown_Click(object sender, EventArgs e)
        {
            AllEvents.Add(new MouseClick() { MouseButton = VirtualMouseStates.MMB_Down });

            UpdateListBox();
        }

        private void Button_InsertRMBDown_Click(object sender, EventArgs e)
        {
            AllEvents.Add(new MouseClick() { MouseButton = VirtualMouseStates.RMB_Down });

            UpdateListBox();
        }

        private void Button_InsertLMBUp_Click(object sender, EventArgs e)
        {
            AllEvents.Add(new MouseClick() { MouseButton = VirtualMouseStates.LMB_Up });

            UpdateListBox();
        }

        private void Button_InsertMMBUp_Click(object sender, EventArgs e)
        {
            AllEvents.Add(new MouseClick() { MouseButton = VirtualMouseStates.MMB_Up });

            UpdateListBox();
        }

        private void Button_InsertRMBUp_Click(object sender, EventArgs e)
        {
            AllEvents.Add(new MouseClick() { MouseButton = VirtualMouseStates.RMB_Up });

            UpdateListBox();
        }


        #endregion Mouse Click Button Events

        #region Pause Event Register Loops

        /// <summary>
        /// this function will be called when the user is registering a
        /// pause while colour exists in area event, it should be run in a thread
        /// to prevent the UI from locking up...
        /// </summary>
        void PauseWhileColourExistsInAreaLoop()
        {
            POINT p1 = new POINT(), p2 = new POINT();
            Color SearchColour = Color.Empty;

            bool xChosen = false, yChosen = false, colourChosen = false;

            string temp = Button_InsertPauseWhileColourExistsInArea.Text;

            Button_InsertPauseWhileColourExistsInArea.Text = "Selecting area to search... (F5 to cancel).";

            while (xChosen == false)
            {
                if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                {
                    p1 = GetCursorPosition();

                    xChosen = true;

                    while (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0) { /*Pauses until user has let go of left shift button...*/
                }
            }
                else if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                {
                    Button_InsertPauseWhileColourExistsInArea.Text = temp;
                    return;
                }

                while (yChosen == false && xChosen == true)
                {
                    p2 = GetCursorPosition();

                    break;
                }
            }

            Button_InsertPauseWhileColourExistsInArea.Text = "Selecting colour to search for in area... (F5 to cancel).";

            while (!colourChosen)
            {
                if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                {
                    SearchColour = GetColorAt(Cursor.Position);
                    colourChosen = true;
                }
                else if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                {
                    Button_InsertPauseWhileColourExistsInArea.Text = temp;
                    return;
                }
            }

            AllEvents.Add(new PauseWhileColourExistsInArea() { ColourSearchArea = new RECT(p1, p2), SearchColour = SearchColour.ToArgb() });

            UpdateListBox();

            Button_InsertPauseWhileColourExistsInArea.Text = temp;
        }

        /// <summary>
        /// this function will be called when the user is registering a
        /// pause while colour doesn't exist in area event, it should be run in a thread
        /// to prevent the UI from locking up...
        /// </summary>
        void PauseWhileColourDoesntExistInAreaLoop()
        {
            POINT p1 = new POINT(), p2 = new POINT();
            Color SearchColour = Color.Empty;

            bool xChosen = false, yChosen = false, colourChosen = false;

            string temp = Button_InsertPauseWhileColourDoesntExistInArea.Text;

            Button_InsertPauseWhileColourDoesntExistInArea.Text = "Selecting area to search... (F5 to cancel).";

            while (xChosen == false)
            {
                if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                {
                    p1 = GetCursorPosition();

                    xChosen = true;

                    while (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0) { /*Pauses until user has let go of left shift button...*/ }
                }
                else if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                {
                    Button_InsertPauseWhileColourDoesntExistInArea.Text = temp;
                    return;
                }

                while (yChosen == false && xChosen == true)
                {
                    p2 = GetCursorPosition();

                    break;
                }
            }

            Button_InsertPauseWhileColourDoesntExistInArea.Text = "Selecting colour to search for in area... (F5 to cancel).";

            while (!colourChosen)
            {
                if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                {
                    SearchColour = GetColorAt(Cursor.Position);
                    colourChosen = true;
                }
                else if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                {
                    Button_InsertPauseWhileColourDoesntExistInArea.Text = temp;
                    return;
                }
            }

            AllEvents.Add(new PauseWhileColourDoesntExistInArea() { ColourSearchArea = new RECT(p1, p2), SearchColour = SearchColour.ToArgb() });

            UpdateListBox();

            Button_InsertPauseWhileColourDoesntExistInArea.Text = temp;
        }

        /// <summary>
        /// this function will be called when the user is registering a
        /// pause while colour exists in area on window event, it should be run in a thread
        /// to prevent the UI from locking up...
        /// </summary>
        void PauseWhileColourExistsInAreaOnWindowLoop()
        {
            POINT p1 = new POINT(), p2 = new POINT();
            Color SearchColour = Color.Empty;

            bool xChosen = false, yChosen = false, colourChosen = false;

            string temp = Button_InsertPauseWhileColourExistsInAreaOnWindow.Text;

            Button_InsertPauseWhileColourExistsInAreaOnWindow.Text = "Selecting area to search... (F5 to cancel).";

            while (xChosen == false)
            {
                if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                {
                    p1 = GetCursorPositionOnWindow(GetForegroundWindow());

                    xChosen = true;

                    while (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0) { /*Pauses until user has let go of left shift button...*/ }
                }
                else if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                {
                    Button_InsertPauseWhileColourExistsInAreaOnWindow.Text = temp;
                    return;
                }

                while (yChosen == false && xChosen == true)
                {
                    p2 = GetCursorPositionOnWindow(GetForegroundWindow());

                    break;
                }
            }

            Button_InsertPauseWhileColourExistsInAreaOnWindow.Text = "Selecting colour to search for in area... (F5 to cancel).";

            while (!colourChosen)
            {
                if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                {
                    SearchColour = GetColorAt(Cursor.Position);
                    colourChosen = true;
                }
                else if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                {
                    Button_InsertPauseWhileColourExistsInAreaOnWindow.Text = temp;
                    return;
                }
            }

            AllEvents.Add(new PauseWhileColourExistsInAreaOnWindow() { WindowToClickHandle = GetForegroundWindow(), WindowToClickTitle = GetActiveWindowTitle(), ColourSearchArea = new RECT(p1, p2), ClickArea = new RECT(p1, p2), SearchColour = SearchColour.ToArgb() });

            UpdateListBox();

            Button_InsertPauseWhileColourExistsInAreaOnWindow.Text = temp;
        }

        /// <summary>
        /// this function will be called when the user is registering a
        /// pause while colour doesn't exist in area on window event, it should be run in a thread
        /// to prevent the UI from locking up...
        /// </summary>
        void PauseWhileColourDoesntExistInAreaOnWindowLoop()
        {
            POINT p1 = new POINT(), p2 = new POINT();
            Color SearchColour = Color.Empty;

            bool xChosen = false, yChosen = false, colourChosen = false;

            string temp = Button_InsertPauseWhileColourDoesntExistInAreaOnWindow.Text;

            Button_InsertPauseWhileColourDoesntExistInAreaOnWindow.Text = "Selecting area to search... (F5 to cancel).";

            while (xChosen == false)
            {
                if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                {
                    p1 = GetCursorPositionOnWindow(GetForegroundWindow());

                    xChosen = true;

                    while (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0) { /*Pauses until user has let go of left shift button...*/ }
                }
                else if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                {
                    Button_InsertPauseWhileColourDoesntExistInAreaOnWindow.Text = temp;
                    return;
                }

                while (yChosen == false && xChosen == true)
                {
                    p2 = GetCursorPositionOnWindow(GetForegroundWindow());

                    break;
                }
            }

            Button_InsertPauseWhileColourDoesntExistInAreaOnWindow.Text = "Selecting colour to search for in area... (F5 to cancel).";

            while (!colourChosen)
            {
                if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                {
                    SearchColour = GetColorAt(Cursor.Position);
                    colourChosen = true;
                }
                else if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                {
                    Button_InsertPauseWhileColourDoesntExistInAreaOnWindow.Text = temp;
                    return;
                }
            }

            AllEvents.Add(new PauseWhileColourDoesntExistInAreaOnWindow() { WindowToClickHandle = GetForegroundWindow(), WindowToClickTitle = GetActiveWindowTitle(), ColourSearchArea = new RECT(p1, p2), ClickArea = new RECT(p1, p2), SearchColour = SearchColour.ToArgb() });

            UpdateListBox();

            Button_InsertPauseWhileColourDoesntExistInAreaOnWindow.Text = temp;
        }

        #endregion

        #region Mouse Move Event Register Loops

        /// <summary>
        /// this is the register loop used to register a mouse move to a fixed point event
        /// </summary>
        void MouseMoveToFixedPointLoop()
        {
            POINT p1 = new POINT();

            IsRegistering = true;

            string temp = Button_InsertMouseMoveEvent.Text;

            Button_InsertMouseMoveEvent.Text = "Selecting points to click... (F5 to finish).";

            while (IsRegistering)
            {
                if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                {
                    p1 = GetCursorPosition();

                    AllEvents.Add(new MouseMove() { CoordsToMoveTo = p1 });

                    UpdateListBox();

                    Thread.Sleep(200);
                }
                else if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                {
                    Button_InsertMouseMoveEvent.Text = temp;
                    IsRegistering = false;
                    return;
                }
            }

            Button_InsertMouseMoveEvent.Text = temp;
        }

        /// <summary>
        /// this is the register loop used to register a mouse move to area on screen event
        /// </summary>
        void MouseMoveToAreaLoop()
        {
            POINT p1 = new POINT(), p2 = new POINT();

            IsRegistering = true;

            string temp = Button_InsertMouseMoveToAreaEvent.Text;

            Button_InsertMouseMoveToAreaEvent.Text = "Selecting area to click... (F5 to cancel).";

            while (IsRegistering)
            {
                if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                {
                    p1 = GetCursorPosition();

                    while (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0) { /*Pauses until user has let go of left shift button...*/ }

                    p2 = GetCursorPosition();

                    AllEvents.Add(new MouseMoveToArea() { ClickArea = new RECT(p1, p2) });

                    UpdateListBox();

                    Thread.Sleep(200);
                }
                else if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                {
                    Button_InsertMouseMoveToAreaEvent.Text = temp;

                    IsRegistering = false;

                    return;
                }
            }

            Button_InsertMouseMoveToAreaEvent.Text = temp;
        }

        /// <summary>
        /// this is the register loop used to register a mouse move to point on window event
        /// </summary>
        void MouseMoveToPointOnWindowLoop()
        {
            POINT p1 = new POINT();

            IsRegistering = true;

            string temp = Button_InsertMouseMoveToPointOnWindowEvent.Text;

            Button_InsertMouseMoveToPointOnWindowEvent.Text = "Selecting point to click... (F5 to cancel).";

            while (IsRegistering)
            {
                if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                {
                    p1 = GetCursorPositionOnWindow(GetForegroundWindow());

                    AllEvents.Add(new MouseMoveToPointOnWindow() { WindowToClickHandle = GetForegroundWindow(), WindowToClickTitle = GetActiveWindowTitle(), CoordsToMoveTo = p1 });

                    UpdateListBox();

                    Thread.Sleep(200);
                }
                else if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                {
                    Button_InsertMouseMoveToPointOnWindowEvent.Text = temp;
                    IsRegistering = false;
                    return;
                }
            }

            Button_InsertMouseMoveToPointOnWindowEvent.Text = temp;
        }

        /// <summary>
        /// this is the register loop used to register a mouse move to area on window event
        /// </summary>
        void MouseMoveToAreaOnWindowLoop()
        {
            POINT p1 = new POINT(), p2 = new POINT();

            IsRegistering = true;

            string temp = Button_InsertMouseMoveToAreaOnWindowEvent.Text;

            Button_InsertMouseMoveToAreaOnWindowEvent.Text = "Selecting area to click... (F5 to cancel).";

            while (IsRegistering)
            {
                if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                {
                    p1 = GetCursorPositionOnWindow(GetForegroundWindow());

                    while (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0) { /*Pauses until user has let go of left shift button...*/ }

                    p2 = GetCursorPositionOnWindow(GetForegroundWindow());

                    AllEvents.Add(new MouseMoveToAreaOnWindow() { WindowToClickHandle = GetForegroundWindow(), WindowToClickTitle = GetActiveWindowTitle(), ClickArea = new RECT(p1, p2) });

                    UpdateListBox();

                    Thread.Sleep(200);
                }
                else if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                {
                    Button_InsertMouseMoveToAreaOnWindowEvent.Text = temp;

                    IsRegistering = false;

                    return;
                }
            }

            Button_InsertMouseMoveToAreaOnWindowEvent.Text = temp;
        }

        /// <summary>
        /// this is the register loop used to register a mouse move to colour in area event
        /// </summary>
        void MouseMoveToColourInAreaLoop()
        {
            POINT p1 = new POINT(), p2 = new POINT();
            Color SearchColour = Color.White;

            IsRegistering = true;

            string temp = Button_InsertColourSearchAreaEvent.Text;

            Button_InsertColourSearchAreaEvent.Text = "Selecting area to search... (F5 to cancel).";

            while (IsRegistering)
            {
                bool ColourPicked = false;

                if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                {
                    p1 = GetCursorPosition();

                    while (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0) { /*Pauses until user has let go of left shift button...*/ }

                    p2 = GetCursorPosition();

                    Button_InsertColourSearchAreaEvent.Text = "Selecting colour to search for in area... (F5 to cancel).";

                    while (!ColourPicked)
                    {
                        if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                        {
                            ColourPicked = true;

                            Button_InsertColourSearchAreaEvent.Text = "Selecting area to search... (F5 to cancel).";

                            SearchColour = GetColorAt(Cursor.Position);

                            AllEvents.Add(new MouseMoveToColour() { ColourSearchArea = new RECT(p1, p2), ClickArea = new RECT(p1, p2), SearchColour = SearchColour.ToArgb() });

                            UpdateListBox();

                            Thread.Sleep(200);
                        }
                        else if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                        {
                            Button_InsertColourSearchAreaEvent.Text = temp;

                            IsRegistering = false;

                            return;
                        }
                    }
                }
                else if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                {
                    Button_InsertColourSearchAreaEvent.Text = temp;

                    IsRegistering = false;

                    return;
                }
            }

            Button_InsertColourSearchAreaEvent.Text = temp;
        }

        /// <summary>
        /// this is the register loop used to register a mouse move to colour in area on window event
        /// </summary>
        void MouseMoveToColourInAreaOnWindowLoop()
        {
            POINT p1 = new POINT(), p2 = new POINT();
            Color SearchColour = Color.White;

            IsRegistering = true;

            string temp = Button_InsertColourSearchAreaWindowEvent.Text;

            Button_InsertColourSearchAreaWindowEvent.Text = "Selecting area to search... (F5 to cancel).";

            while (IsRegistering)
            {
                bool ColourPicked = false;

                if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                {
                    p1 = GetCursorPositionOnWindow(GetForegroundWindow());

                    while (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0) { /*Pauses until user has let go of left shift button...*/ }

                    p2 = GetCursorPositionOnWindow(GetForegroundWindow());

                    Button_InsertColourSearchAreaWindowEvent.Text = "Selecting colour to search for in area... (F5 to cancel).";

                    while (!ColourPicked)
                    {
                        if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                        {
                            ColourPicked = true;
                            Button_InsertColourSearchAreaWindowEvent.Text = "Selecting area to search... (F5 to cancel).";

                            SearchColour = GetColorAt(Cursor.Position);

                            AllEvents.Add(new MouseMoveToColourOnWindow() { WindowToClickHandle = GetForegroundWindow(), WindowToClickTitle = GetActiveWindowTitle(), ColourSearchArea = new RECT(p1, p2), ClickArea = new RECT(p1, p2), SearchColour = SearchColour.ToArgb() });

                            UpdateListBox();

                            Thread.Sleep(200);
                        }
                        else if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                        {
                            Button_InsertColourSearchAreaWindowEvent.Text = temp;

                            IsRegistering = false;

                            return;
                        }
                    }
                }
                else if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                {
                    Button_InsertColourSearchAreaWindowEvent.Text = temp;

                    IsRegistering = false;

                    return;
                }
            }

            Button_InsertColourSearchAreaWindowEvent.Text = temp;
        }

        /// <summary>
        /// this is the register loop used to register a mouse move to multi colour in area on window event
        /// </summary>
        void MouseMoveToMutliColourInAreaOnWindowLoop()
        {
            // will store the colours we will be searching for
            //
            List<int> searchColours = new List<int>();

            // will store the two points used for the search area
            //
            POINT p1 = new POINT(), p2 = new POINT();

            // will store the screenshot we take of the search area
            //
            Bitmap ColourSelectionScreenshot;

            // set global registering to true
            //
            IsRegistering = true;

            // these will be used to control register flow later
            //
            bool DonePickingColours = false, AreaPicked = false;

            // store the original text of the button we just clicked
            //
            string temp = Button_InsertMultiColourSearchAreaWindowEvent.Text;

            // change the button text to show we're currently registering
            //
            Button_InsertMultiColourSearchAreaWindowEvent.Text = "Selecting area to search... (F6 to cancel).";

            // register loop
            //
            while (IsRegistering)
            {
                // listen for the left shift key
                //
                if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                {
                    // store the top left of the search area
                    //
                    p1 = GetCursorPosition();

                    // pause here while the user is still holding shift
                    //
                    while (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0) { /*Pauses until user has let go of left shift button...*/ }

                    // store bottom left of search area after user lets go of shift key
                    //
                    p2 = GetCursorPosition();

                    // calculate the width and height of the search area
                    //
                    int w = p2.X - p1.X,
                        h = p2.Y - p1.Y;

                    // take a screenshot of the search area and store it in our bitmap
                    //
                    ColourSelectionScreenshot = ScreenshotArea(new RECT(p1, p2));

                    // set the picturebox image to the screenshot we took
                    //
                    Picturebox_ColourSelectionArea.Image = ColourSelectionScreenshot;

                    // change the button text to show we've moved on to selecting the search colours
                    //
                    Button_InsertMultiColourSearchAreaWindowEvent.Text = "Selecting colours to search for in area... (F5 to continue).";

                    // loop here while we're not done selecting colours to search for
                    //
                    while (!DonePickingColours)
                    {
                        // listen for the shift key
                        //
                        if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                        {
                            // each time we hit shift key we add the colour under the mouse to the search colours list
                            //
                            searchColours.Add(GetColorAt(Cursor.Position).ToArgb());

                            // change the colour we selected on the screenshot to red to show we've added it to the search list
                            //
                            ColourSelectionScreenshot = SetMatchingColourPixels(ColourSelectionScreenshot, searchColours[searchColours.Count - 1], Color.Red);

                            // override the original picturebox image with the new one to show the selected colours
                            //
                            Picturebox_ColourSelectionArea.Image = ColourSelectionScreenshot;

                            // sleep here so we don't add more than one colour when we press shift once
                            //
                            Thread.Sleep(200);
                        }
                        else if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                        {
                            // if we click F5 then the colour selection process is marked as complete
                            //
                            DonePickingColours = true;

                            // we change the button text to ask the user to choose the area on the window they'd like to search for these colours on
                            //
                            Button_InsertMultiColourSearchAreaWindowEvent.Text = "Selecting area & window to search for colour in.... (Make sure window is top-most)";

                            // loop here while the area hasn't been selected
                            //
                            while (!AreaPicked)
                            {
                                // listen for the shift key
                                //
                                if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                                {
                                    // set the top left of the search area to the point under the mouse
                                    //
                                    p1 = GetCursorPositionOnWindow(GetForegroundWindow());

                                    // wait here while the user holds shift key
                                    //
                                    while (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0) { /*Pauses until user has let go of left shift button...*/ }

                                    // set the bottom right of the search area to the point under the mouse
                                    //
                                    p2 = GetCursorPositionOnWindow(GetForegroundWindow());

                                    // set the area marked as complete
                                    //
                                    AreaPicked = true;
                                }
                            }

                            // add the event to the event list
                            //
                            AllEvents.Add(new MouseMoveToMultiColourOnWindow() { WindowToClickHandle = GetForegroundWindow(), WindowToClickTitle = GetActiveWindowTitle(), ColourSearchArea = new RECT(p1, p2), ClickArea = new RECT(p1, p2), SearchColours = new List<int>(searchColours) });

                            // update the event listbox to show the new event
                            //
                            UpdateListBox();

                            // set the button text back to normal
                            //
                            Button_InsertMultiColourSearchAreaWindowEvent.Text = temp;

                            // set global registering as false
                            //
                            IsRegistering = false;

                            // clear the search colours list
                            //
                            searchColours.Clear();

                            // we're done here
                            //
                            return;
                        }
                    }
                }
                else if (GetAsyncKeyState(VirtualKeyStates.VK_F6) < 0)
                {
                    //
                    // user can cancel the operation early by pressing F6
                    //

                    // set the button text back to normal
                    //
                    Button_InsertMultiColourSearchAreaWindowEvent.Text = temp;

                    // set global registering as false
                    //
                    IsRegistering = false;

                    // we're done here
                    //
                    return;
                }
            }

            // set the button text back to normal if the normal operation fails somehow
            //
            Button_InsertMultiColourSearchAreaWindowEvent.Text = temp;
        }

        #endregion
    }
}