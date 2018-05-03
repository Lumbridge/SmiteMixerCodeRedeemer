using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

using MixerChat;
using MixerChat.Classes;
using SmiteMixerCodeGrabberGUI.Classes;

using static SmiteMixerListener.Classes.Common;
using static SmiteMixerCodeGrabberGUI.Classes.Common;
using static SmiteMixerCodeGrabberGUI.Classes.AllCodes;
using static SmiteMixerCodeGrabberGUI.Classes.Automation;
using static SmiteMixerCodeGrabberGUI.Classes.Globals;

using static DolphinScript.Lib.Backend.WinAPI;
using static DolphinScript.Lib.Backend.Common;
using MetroFramework;

namespace SmiteMixerCodeGrabberGUI
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        /// <summary>
        /// Main form initialisation.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Callback for when the main form has loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (useDarkTheme)
            {
                metroStyleManager.Theme = MetroThemeStyle.Dark;
                ManualControlColours(System.Drawing.Color.DarkGray);
                metroComboBox_Theme.SelectedIndex = 1;
            }
            else
            {
                metroStyleManager.Theme = MetroThemeStyle.Light;
                ManualControlColours(System.Drawing.Color.White);
                metroComboBox_Theme.SelectedIndex = 0;
            }

            this.StyleManager = metroStyleManager;
            metroTabControl1.StyleManager = metroStyleManager;

            listView_ActiveCodes.StyleManager = metroStyleManager;
            listView_ExpiredCodes.StyleManager = metroStyleManager;

            metroContextMenu_listViewRightClick.StyleManager = metroStyleManager;

            metroTabPage_Active.StyleManager = metroStyleManager;
            metroTabPage_Blacklist.StyleManager = metroStyleManager;
            metroTabPage_Whitelist.StyleManager = metroStyleManager;
            metroTabPage_Expired.StyleManager = metroStyleManager;
            metroTabPage_Logs.StyleManager = metroStyleManager;
            metroTabPage_Help.StyleManager = metroStyleManager;
            metroTabPage_Settings.StyleManager = metroStyleManager;

            metroPanel1.StyleManager = metroStyleManager;
            metroPanel2.StyleManager = metroStyleManager;
            metroPanel3.StyleManager = metroStyleManager;
            metroPanel4.StyleManager = metroStyleManager;
            metroPanel5.StyleManager = metroStyleManager;

            trackbar_RedeemDelay.StyleManager = metroStyleManager;
            metroTrackBar_minWordLength.StyleManager = metroStyleManager;
            metroTrackBar_maxWordLength.StyleManager = metroStyleManager;

            metroLabel2.StyleManager = metroStyleManager;
            metroLabel3.StyleManager = metroStyleManager;
            metroLabel4.StyleManager = metroStyleManager;
            metroLabel5.StyleManager = metroStyleManager;
            metroLabel7.StyleManager = metroStyleManager;
            metroLabel87.StyleManager = metroStyleManager;
            metroLabel9.StyleManager = metroStyleManager;
            metroLabel10.StyleManager = metroStyleManager;
            metroLink_KeyCodeHelp.StyleManager = metroStyleManager;

            label_ksNote.StyleManager = metroStyleManager;
            label_SmiteClientVersion.StyleManager = metroStyleManager;
            label_redeemDelay.StyleManager = metroStyleManager;
            label_minWordLength.StyleManager = metroStyleManager;

            metroLabel_AFKMode.StyleManager = metroStyleManager;
            metroLabel_maxWordLength.StyleManager = metroStyleManager;
            metroLabel_MinimiseSmiteAfterRedeeming.StyleManager = metroStyleManager;

            checkbox_NotificationSound.StyleManager = metroStyleManager;
            checkbox_showNotifications.StyleManager = metroStyleManager;
            checkbox_AFKMode.StyleManager = metroStyleManager;
            checkBox_disableKillswitch.StyleManager = metroStyleManager;
            checkbox_MinimiseAfterRedeeming.StyleManager = metroStyleManager;


            // set whether to catch calls on the wrong thread that access a control's handle property when an application is being debugged
            CheckForIllegalCrossThreadCalls = false;

            foreach (var key in Enum.GetNames(typeof(VirtualKeyStates)))
            {
                if(key != "VK_CONTROL" &&
                    key != "VK_LCONTROL" && 
                    key != "VK_RCONTROL" && 
                    key != "VK_ESCAPE" && 
                    key != "VK_RETURN" &&
                    key != "VK_KEY_C" &&
                    key != "VK_KEY_V")
                {
                    comboBox_vKeys.Items.Add(key);
                }
            }

            // override the console to output console.writeline to our custom console log
            Console.SetOut(new LogWriter(logbox));
            
            // load up all saved properties
            //
            // textboxes
            textbox_whitelistedUsernames.Lines = whitelistedUsernames.Cast<string>().ToArray(); 
            textbox_BlacklistedWords.Lines = blacklistedWords.Cast<string>().ToArray();
            textbox_NotificationSound.Text = notificationSoundFilePath;
            // checkboxes
            checkbox_NotificationSound.Checked = notificationSound;
            checkbox_showNotifications.Checked = notificationSetting;
            checkbox_MinimiseAfterRedeeming.Checked = minimiseAfterRedeeming;
            checkBox_disableKillswitch.Checked = killswitchEnabled;
            // combo box
            comboBox_vKeys.SelectedItem = killswitchKeyString;
            // label
            label_ksNote.Text = $"Note: Press {killswitchKeyString} to stop automation script.";
            label_redeemDelay.Text = redeemDelay + " Minutes.";
            label_minWordLength.Text = minWordLength + " Characters.";
            metroLabel_maxWordLength.Text = maxWordLength + " Characters.";
            // trackbar
            trackbar_RedeemDelay.Value = redeemDelay;
            metroTrackBar_minWordLength.Value = minWordLength;

            // write the meta info to the console
            Console.Write(MetaInfo.GetMetaInfoConsole());

            // hook up the mixer API callbacks
            Mixer chat = new Mixer();
            chat.OnMessageReceived += Chat_OnMessageReceived;
            // connect to the smite mixer chat (currently not using the connected boolean...)
            var connected = chat.Connect("SmiteGame");

            // create and spin up our threads
            //
            // killswitch thread (listens for F5 key and stops automation)
            Thread killswitch = new Thread(new ThreadStart(CheckForTerminationKey));
            killswitch.SetApartmentState(ApartmentState.STA);
            killswitch.IsBackground = true;
            killswitch.Start();
            // AFK mode thread (does afk mode stuff)
            Thread AFKModeThread = new Thread(new ThreadStart(AFKModeLoop));
            AFKModeThread.SetApartmentState(ApartmentState.STA);
            AFKModeThread.IsBackground = true;
            AFKModeThread.Start();
            // Thread to monitor whether smite process exists
            Thread CheckSmiteExists = new Thread(new ThreadStart(CheckSmiteIsOpenLoop));
            CheckSmiteExists.SetApartmentState(ApartmentState.STA);
            CheckSmiteExists.IsBackground = true;
            CheckSmiteExists.Start();

            // set is running to true by default for the AFK mode to function
            IsRunning = true;
        }

        /// <summary>
        /// Run when UI is displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (firstLaunch)
            {
                var result = MetroFramework.MetroMessageBox.Show(this,
                    "\nIf you have any issues/bugs you can submit them on the help tab!\nCheck out the Settings tab to configure the program!\n\n" +
                    "You can add me on SMITE @ RyanSensei (PC Client EU)\n" +
                    "Would you like to see this notification the next time you launch the program?", "Welcome to SMCR v2.0.0!", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                    firstLaunch = false;
            }
        }

        /// <summary>
        /// Callback for when the main form is closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // exit when we close the main form (aborts all threads)
            Application.Exit();
        }

        /// <summary>
        /// This method is called each second that passes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_MainForm_Tick(object sender, EventArgs e)
        {
            foreach(var c in GetAllCodes())
            {
                if (c.GetIsActive() == false && c.currentList == SmiteCode.Lists.Active)
                    c.SwitchList();
            }

            if (shouldUpdateActiveList)
            {
                listView_ActiveCodes.BeginUpdate();
                listView_ActiveCodes.Items.Clear();
                foreach (var aCode in GetActiveCodes())
                {
                    ListViewItem lvi = new ListViewItem(aCode.Time_GrabbedAt.ToShortTimeString());
                    lvi.SubItems.Add(aCode.Time_RedeemingAt.ToShortTimeString());
                    lvi.SubItems.Add(aCode.GetCode());
                    lvi.SubItems.Add(aCode.isRedeemed.ToString());
                    lvi.SubItems.Add(aCode.Time_GrabbedAt.Add(new TimeSpan(0, 30, 0)).ToShortTimeString());
                    lvi.ForeColor = System.Drawing.Color.White;
                    listView_ActiveCodes.Items.Add(lvi);
                }
                listView_ActiveCodes.EndUpdate();
                                
                shouldUpdateActiveList = false;
            }

            if (shouldUpdateExpiredList)
            {
                listView_ExpiredCodes.BeginUpdate();
                listView_ExpiredCodes.Items.Clear();
                foreach (var eCode in GetExpiredCodes())
                {
                    ListViewItem lvi = new ListViewItem(eCode.Time_GrabbedAt.ToShortTimeString());
                    lvi.SubItems.Add(eCode.Time_GrabbedAt.Add(new TimeSpan(0, 30, 0)).ToShortTimeString());
                    lvi.SubItems.Add(eCode.GetCode());
                    lvi.SubItems.Add(eCode.isRedeemed.ToString());
                    listView_ExpiredCodes.Items.Add(lvi);
                }
                listView_ExpiredCodes.EndUpdate();

                shouldUpdateExpiredList = false;
            }

            // check if AFK mode was disabled by any threads
            if (!AFKMode)
                // if it has been disabled then uncheck the form checkbox
                checkbox_AFKMode.Checked = false;

            // check if we need to change the smite window form label
            if (!ProcessInfo.DoesSmiteProcessExist() && label_SmiteClientVersion.Text != "SMITE Client Not Found (Automation Disabled).")
                // set the form label to no client found
                label_SmiteClientVersion.Text = "SMITE Client Not Found (Automation Disabled).";
            else if(ProcessInfo.DoesSmiteProcessExist() && label_SmiteClientVersion.Text != ProcessInfo.GetSmiteWindowTitle())
                // set the form label to the current smite window title
                label_SmiteClientVersion.Text = ProcessInfo.GetSmiteWindowTitle();
            
            // check if we need to disable automation features due to finding no smite process
            if(!ProcessInfo.DoesSmiteProcessExist())
            {
                // disable redeem buttons
                button_redeemAllActive.Enabled = false;
                button_redeemSelected.Enabled = false;

                // disable afk mode checkbox & turn it off
                checkbox_AFKMode.Checked = false;
                checkbox_AFKMode.Enabled = false;
                AFKMode = false;
            }
            else
            {
                // enable redeem buttons
                button_redeemAllActive.Enabled = true;
                button_redeemSelected.Enabled = true;

                // enable afk mode checkbox
                checkbox_AFKMode.Enabled = true;
            }
        }
        
        #region Continuous Threads
        /// <summary>
        /// This method controls AFK mode.
        /// </summary>
        public static void AFKModeLoop()
        {
            // runs until application end
            while (true)
            {
                // checks whether AFK mode is enabled by the user
                if (AFKMode)
                {
                    // loop through all active codes
                    foreach (var code in GetActiveCodesPastRedeemTimer())
                    {
                        // check that the current code hasn't already been redeemed & IsRunning is true (user hasn't pressed the killswitch)
                        if (code.GetIsRedeemed() == false && IsRunning)
                        {
                            // output message to the log box
                            Write("AFK Mode: Redeeming code (" + code.GetCode() + ").");

                            // get the event list and pass it the code we want it to type
                            var loop = GetRedeemLoop(code.GetCode());

                            // loop through each event in the script
                            foreach (var ev in loop)
                                // check that the killswitch hasn't been pressed
                                if(IsRunning)
                                    // do the script event
                                    ev.DoEvent();

                            // if at the end of the script we weren't interrupted during code redemption then
                            // set the code as redeemed
                            if (IsRunning)
                            {
                                code.SetIsRedeemed(true);
                                shouldUpdateActiveList = true;
                                shouldMinimise = true;
                            }
                        }
                    }
                    if (minimiseAfterRedeeming && shouldMinimise)
                    {
                        MinimiseSMITEClient();
                        shouldUpdateActiveList = true;
                        shouldMinimise = false;
                    }
                }
                // sleep the thread for 100 ms so we don't max out CPU usage
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// This method listens for the killswitch key which disables automation.
        /// </summary>
        public static void CheckForTerminationKey()
        {
            // runs until application is closed
            while (true)
            {
                // listen for the killswitch key
                if (killswitchEnabled &&
                    AFKMode &&
                    GetAsyncKeyState((VirtualKeyStates)Properties.Settings.Default.killswitchKey) < 0)
                {
                    // set is running flag to false
                    IsRunning = false;

                    // disable afk mode
                    AFKMode = false;

                    // output notification to show afk mode is disabled
                    DisplayNotification("Killswitch Key Detected: AFK Mode disabled.");
                }
                // sleep to reduce CPU usage
                Thread.Sleep(50);
            }
        }

        /// <summary>
        /// This method checks if the smite process is running.
        /// </summary>
        public static void CheckSmiteIsOpenLoop()
        {
            // runs until application is closed
            while (true)
            {
                // check if smite process exists
                if (ProcessInfo.DoesSmiteProcessExist())
                    // get the name of the smite window from the process handle
                    smiteWindowTitle = ProcessInfo.GetSmiteWindowTitle();
                else
                    // no process found: set smite window title to error message
                    smiteWindowTitle = "SMITE Client Not Found (Automation Disabled).";
                // sleep to reduce CPU usage
                Thread.Sleep(100);
            }
        }
        #endregion

        #region Mixer Chat Handlers
        private static void Chat_OnMessageReceived(ChatMessageEventArgs e)
        {
            if (!useAggressiveParser)
            {
                if (e.User == "Scottybot" &&
                    e.Message.Contains("code:") ||
                    e.Message.Contains("Code:") ||
                    e.Message.Contains(":"))
                {
                    var code = e.Message.Substring(e.Message.IndexOf(':') + 1).Trim();
                    shouldAddCode(code, e.User);
                }
            }
            else
            {
                if (isWhitelistedUser(e.User))
                {
                    var words = GetPotentialCodesFromMessage(e.Message);
                    foreach (var word in words)
                    {
                        shouldAddCode(word, e.User);
                        blacklistedWords.Add(word);
                        SaveSettings();
                    }
                    shouldUpdateActiveList = true;
                }
            }
        }

        static List<string> GetPotentialCodesFromMessage(string message)
        {
            List<string> potentialCodes = new List<string>();

            char[] arr = message.ToLower().ToCharArray();

            arr = Array.FindAll<char>(arr, (c => (char.IsLetter(c)
                                              || char.IsWhiteSpace(c))));

            var messageNoSymbols = new string(arr);

            string[] words = messageNoSymbols.Split(' ');

            foreach(var word in words)
            {
                if (!blacklistedWords.Contains(word) && word.Length > minWordLength)
                {
                    potentialCodes.Add(word);
                }
            }

            return potentialCodes;
        }

        // obsolete
        static string SentenceContainsMultiCapWord(string message)
        {
            // get all words in the sentence
            string[] words = message.Split(' ');
            // go through all words in sentence
            foreach (string word in words)
            {
                // counter for number of caps in the word
                int numberOfCapsInWord = 0;
                // go through all letters in word
                foreach (var letter in word)
                {
                    // check if its a capital
                    if (char.IsUpper(letter))
                    {
                        // letter is a capital
                        numberOfCapsInWord++;
                    }
                }
                // this word has more than 1 capital letter
                if (numberOfCapsInWord > 1 &&
                    word.Length > 3 &&
                    word.All(Char.IsLetterOrDigit) &&
                    !word.All(Char.IsUpper))
                    return word;
            }
            // no words contain more than 1 capital letter
            return null;
        }
        #endregion

        #region Helper Methods
        public static bool isWhitelistedUser(string user)
        {
            return whitelistedUsernames.Contains(user);
            //return Whitelist.GetIsWhitelistedUser(user);
        }
        public static string GenerateRandomSmiteCode()
        {
            int len = 17;

            Random random = new Random();

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return "AP" + new string(Enumerable.Repeat(chars, len - 2)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// Added to reduce duplicated code in OnMessageRecieved handler,
        /// checks if a message contains a valid code and adds it to the active codes list if it is valid.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        static void shouldAddCode(string code, string user)
        {
            // check if the...
            if (GetActiveCodes().Find(x => x.GetCode() == code) == null &&  // code isn't in the list of active codes
                GetExpiredCodes().Find(x => x.GetCode() == code) == null && // code isn't in the list of expired codes
                !code.Contains(" "))                                        // code contains no whitespace
            {
                // add the code to the list of active codes
                AddCodeToCodeList(code, true);
                // log that a new code was added
                Write("Code: " + code + " added to active codes (Grabbed from user: " + user + ").");
                // if the notification sound option is enabled then play a sound
                if (notificationSound)
                    PlayNotificationSound();
                // if the notification setting is enabled then show a notification
                if (notificationSetting)
                    DisplayNotification("New code added to active codes: \n" + code);
            }
        }
        /// <summary>
        /// Also added to reduce duplicated code, outputs
        /// a message to the log if a code is invalid.
        /// </summary>
        /// <param name="code"></param>
        static void badCode(string code)
        {
            //if (!code.Contains(" "))
            //    Write("Code Spotted: " + code + " (Already Redeemed).");
            //else
            //    Write("Potential Code Spotted: " + code + " (Invalid Format)");
        }
        #endregion

        #region Control Event Handlers

        #region Logs Tab
        private void logbox_TextChanged(object sender, EventArgs e)
        {
            logbox.SelectionStart = logbox.Text.Length;
            logbox.ScrollToCaret();
        }
        #endregion

        #region Whitelist Tab
        private void textbox_whitelistedUsernames_TextChanged(object sender, EventArgs e)
        {
            whitelistedUsernames.Clear();
            whitelistedUsernames.AddRange(textbox_whitelistedUsernames.Lines.ToArray());
        }
        #endregion

        #region Blacklist Tab
        private void textbox_BlacklistedWords_TextChanged(object sender, EventArgs e)
        {
            blacklistedWords.Clear();
            blacklistedWords.AddRange(textbox_BlacklistedWords.Lines.ToArray());
        }
        private void metroButton_GOTOBlacklistGist_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://gist.github.com/Lumbridge/c574bcafeb286867b0eda09e85b62380");
        }
        #endregion

        #region Active Tab
        private void listView_ActiveCodes_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (listView_ActiveCodes.FocusedItem.Bounds.Contains(e.Location) == true)
                    {
                        metroContextMenu_listViewRightClick.Show(Cursor.Position);
                    }
                }
                catch { }
            }
        }

        private void button_CopySelectedToClipboard_Click(object sender, EventArgs e)
        {
            if(listView_ActiveCodes.SelectedIndices[0] >= 0)
            {
                try
                {
                    Clipboard.SetText(listView_ActiveCodes.SelectedItems[0].SubItems[2].Text);
                    Write("Copied code to clipboard: " + listView_ActiveCodes.SelectedItems[0].SubItems[2].Text);
                }
                catch{ }
            }
        }
        private void button_redeemAllActive_Click(object sender, EventArgs e)
        {
            IsRunning = true;
            if (GetActiveCodes().Count > 0)
                RedeemAllActive();
            else
                MetroFramework.MetroMessageBox.Show(this, "There are no codes currently active.");
        }
        private void button_redeemSelected_Click(object sender, EventArgs e)
        {
            IsRunning = true;
            var codes = GetActiveCodes();
            var selectedIndex = listView_ActiveCodes.SelectedIndices[0];
            if (selectedIndex > -1)
                RedeemSingle(codes[selectedIndex]);
        }
        private void metroButton_RemoveAllActive_Click(object sender, EventArgs e)
        {
            ClearActiveCodes();
            shouldUpdateActiveList = true;
        }

        private void metroButton_AddTestCode_Click(object sender, EventArgs e)
        {
            AddCodeToCodeListDebug(GenerateRandomSmiteCode(), true, DateTime.Now.Subtract(new TimeSpan(0,29,0)));
        }
        private void metroButton_RemoveSelectedActiveCode_Click(object sender, EventArgs e)
        {
            if (listView_ActiveCodes.SelectedItems.Count > 0)
            {
                var codes = GetActiveCodes();
                RemoveCodeFromList(codes[listView_ActiveCodes.SelectedIndices[0]].GetCode());
                shouldUpdateActiveList = true;
            }
        }

        private void toolStripMenuItem_RemoveSelected_Click(object sender, EventArgs e)
        {
            if (listView_ActiveCodes.SelectedItems.Count > 0)
            {
                var codes = GetActiveCodes();
                RemoveCodeFromList(codes[listView_ActiveCodes.SelectedIndices[0]].GetCode());
                shouldUpdateActiveList = true;
            }
        }
        private void copySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_ActiveCodes.SelectedItems.Count > 0)
            {
                try
                {
                    Clipboard.SetText(listView_ActiveCodes.SelectedItems[0].SubItems[2].Text);
                    Write("Copied code to clipboard: " + listView_ActiveCodes.SelectedItems[0].SubItems[2].Text);
                }
                catch { }
            }
        }
        private void addTestCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCodeToCodeListDebug(GenerateRandomSmiteCode(), true, DateTime.Now);
        }
        #endregion

        #region Menu Bar Control Events
        private void expiredListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearExpiredCodes();
        }
        private void expiredToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddCodeToCodeList(GenerateRandomSmiteCode(), false);
        }
        #endregion

        #region Settings Tab
        // killswitch
        private void comboBox_vKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            killswitchKey = (int)EnumHelper.GetEnumValue<VirtualKeyStates>(comboBox_vKeys.SelectedItem.ToString());

            if (killswitchKeyString == "None")
                label_ksNote.Text = "No killswitch key selected.";
            else
                label_ksNote.Text = $"Note: Press {killswitchKeyString} to stop automation script.";
        }
        private void checkBox_disableKillswitch_CheckedChanged(object sender, EventArgs e)
        {
            killswitchEnabled = checkBox_disableKillswitch.Checked;
        }
        // notification stuff
        private void button_sendTestNotification_Click(object sender, EventArgs e)
        {
            if (notificationSound)
                PlayNotificationSound();
            if (notificationSetting)
                DisplayNotification("This is a test notification.");
        }
        private void button_BrowseNotificationSound_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.DefaultExt = ".wav";
            o.Filter = "wav files (*.wav)|*.wav|All files (*.*)|*.*";
            var result = o.ShowDialog();
            if (result == DialogResult.OK)
            {
                notificationSoundFilePath = o.FileName;
                textbox_NotificationSound.Text = o.FileName;
            }
        }
        private void textbox_NotificationSound_TextChanged(object sender, EventArgs e)
        {
            notificationSoundFilePath = textbox_NotificationSound.Text;
        }
        private void checkbox_showNotifications_CheckedChanged(object sender, EventArgs e)
        {
            notificationSetting = checkbox_showNotifications.Checked;

            if (notificationSetting)
                Write("Visual notifications enabled.");
            else
                Write("Visual notifications disabled.");
        }
        private void checkbox_NotificationSound_CheckedChanged(object sender, EventArgs e)
        {
            notificationSound = checkbox_NotificationSound.Checked;

            if (notificationSound)
                Write("Sound notifications enabled.");
            else
                Write("Sound notifications disabled.");
        }

        // key code help
        private void metroLink_KeyCodeHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx");
        }

        // redeem delay stuff
        private void trackbar_RedeemDelay_Scroll(object sender, ScrollEventArgs e)
        {
            label_redeemDelay.Text = trackbar_RedeemDelay.Value + " Minutes.";
        }
        private void trackbar_RedeemDelay_MouseUp(object sender, MouseEventArgs e)
        {
            redeemDelay = trackbar_RedeemDelay.Value;
            label_redeemDelay.Text = redeemDelay + " Minutes.";
        }

        // min word length stuff
        private void metroTrackBar_wordLength_Scroll(object sender, ScrollEventArgs e)
        {
            label_minWordLength.Text = metroTrackBar_minWordLength.Value + " Characters.";
        }
        private void metroTrackBar_wordLength_MouseUp(object sender, MouseEventArgs e)
        {
            minWordLength = metroTrackBar_minWordLength.Value;
            label_minWordLength.Text = minWordLength + " Characters.";
        }
        // max word length stuff
        private void metroTrackBar_maxWordLength_Scroll(object sender, ScrollEventArgs e)
        {
            metroLabel_maxWordLength.Text = metroTrackBar_maxWordLength.Value + " Characters.";
        }
        private void metroTrackBar_maxWordLength_MouseUp(object sender, MouseEventArgs e)
        {
            maxWordLength = metroTrackBar_maxWordLength.Value;
            metroLabel_maxWordLength.Text = maxWordLength + " Characters.";
        }

        // afk mode 
        private void checkbox_AFKMode_CheckedChanged(object sender, EventArgs e)
        {
            AFKMode = checkbox_AFKMode.Checked;
            IsRunning = checkbox_AFKMode.Checked;

            if (AFKMode)
                Write("AFK Mode Enabled, will automatically redeem codes as they become active.");
            else
                Write("AFK Mode Disabled, will not automatically redeem codes as they become active.");
        }
        // misc
        private void checkbox_MinimiseAfterRedeeming_CheckedChanged(object sender, EventArgs e)
        {
            minimiseAfterRedeeming = checkbox_MinimiseAfterRedeeming.Checked;

            if (minimiseAfterRedeeming)
                Write("Minimise after redeeming enabled: " + minimiseAfterRedeeming + "; Will minimise the SMITE client after redeeming codes.");
            else
                Write("Minimise after redeeming disabled: " + minimiseAfterRedeeming + "; Will not minimise the SMITE client after redeeming codes.");
        }
        #endregion

        #region Help Tab
        private void metroTile_Wiki_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Lumbridge/SmiteMixerCodeRedeemer/blob/master/README.md");
        }

        private void metroTile_Credits_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, MetaInfo.GetMetaInfoMessageBox(), "Smite Mixer Code Grabber Credits");
        }

        private void metroTile_ReportBug_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Lumbridge/SmiteMixerCodeRedeemer/issues");
        }

        private void metroTile_UserGuide_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Lumbridge/SmiteMixerCodeRedeemer/blob/master/README.md");
        }

        private void metroTile_Donate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.me/RyanSainty");
        }
        #endregion

        #endregion

        private void metroComboBox_Theme_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTheme = metroComboBox_Theme.SelectedItem.ToString();
            if (selectedTheme == "Light")
            {
                useDarkTheme = false;

                metroStyleManager.Theme = MetroThemeStyle.Light;

                ManualControlColours(System.Drawing.Color.White);
            }
            else
            {
                useDarkTheme = true;

                metroStyleManager.Theme = MetroThemeStyle.Dark;

                ManualControlColours(System.Drawing.Color.DarkGray);
            }

            this.Refresh();
        }

        void ManualControlColours(System.Drawing.Color col)
        {
            listView_ActiveCodes.BackColor = col;
            listView_ExpiredCodes.BackColor = col;
            textbox_BlacklistedWords.BackColor = col;
            textbox_whitelistedUsernames.BackColor = col;
            textbox_NotificationSound.BackColor = col;
            logbox.BackColor = col;
        }

        private void metroContextMenu_listViewRightClick_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listView_ActiveCodes.SelectedItems.Count != 1)
            {
                toolStripMenuItem_RemoveSelected.Visible = false;
                copySelectedToolStripMenuItem.Visible = false;
            }
            else
            {
                toolStripMenuItem_RemoveSelected.Visible = true;
                copySelectedToolStripMenuItem.Visible = true;
            }

            metroContextMenu_listViewRightClick.Refresh();
        }
    }
}