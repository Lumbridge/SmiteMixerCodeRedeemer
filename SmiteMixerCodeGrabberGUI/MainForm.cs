using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using SmiteMixerCodeGrabberGUI.Classes;
using static SmiteMixerListener.Classes.Common;
using static SmiteMixerCodeGrabberGUI.Classes.Common;
using static SmiteMixerCodeGrabberGUI.Classes.AllCodes;
using static SmiteMixerCodeGrabberGUI.Classes.Automation;
using static SmiteMixerCodeGrabberGUI.Classes.Globals;

using MixerChat;
using MixerChat.Classes;

using static DolphinScript.Lib.Backend.WinAPI;
using static DolphinScript.Lib.Backend.Common;
using System.Collections.Generic;
using System.IO;

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
            shouldUpdateActiveList = true;

            // set whether to catch calls on the wrong thread that access a control's handle property when an application is being debugged
            CheckForIllegalCrossThreadCalls = false;

            foreach (var key in Enum.GetNames(typeof(VirtualKeyStates)))
            {
                comboBox_vKeys.Items.Add(key);
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
            label_redeemDelay.Text = redeemDelay + " Minutes";
            // trackbar
            trackbar_RedeemDelay.Value = redeemDelay;

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
        /// This method is called each second that passes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_MainForm_Tick(object sender, EventArgs e)
        {
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
                    listView_ActiveCodes.Items.Add(lvi);
                }
                listView_ActiveCodes.EndUpdate();
                                
                shouldUpdateActiveList = false;
            }

            // clear the contents of the expired codes box
            listbox_Expired.Items.Clear();
            // loop through all expired codes
            foreach (var eCode in GetExpiredCodes())
            {
                // add each expired code to the expired codes box
                listbox_Expired.Items.Add(eCode.GetCode() + " Redeemed: " + eCode.GetIsRedeemed());
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
                if (!blacklistedWords.Contains(word))
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

        #region Main Form Controls
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
        private void checkbox_AFKMode_CheckedChanged(object sender, EventArgs e)
        {
            AFKMode = checkbox_AFKMode.Checked;
            IsRunning = checkbox_AFKMode.Checked;

            if (AFKMode)
                Write("AFK Mode Enabled, will automatically redeem codes as they become active.");
            else
                Write("AFK Mode Disabled, will not automatically redeem codes as they become active.");
        }
        private void checkbox_MinimiseAfterRedeeming_CheckedChanged(object sender, EventArgs e)
        {
            minimiseAfterRedeeming = checkbox_MinimiseAfterRedeeming.Checked;

            if (minimiseAfterRedeeming)
                Write("Minimise after redeeming enabled: " + minimiseAfterRedeeming + "; Will attempt to minimise the SMITE client after redeeming codes.");
            else
                Write("Minimise after redeeming disabled: " + minimiseAfterRedeeming + "; Will not attempt to minimise the SMITE client after redeeming codes.");
        }
        private void checkBox_disableKillswitch_CheckedChanged(object sender, EventArgs e)
        {
            killswitchEnabled = checkBox_disableKillswitch.Checked;
        }
        
        private void button_redeemAllActive_Click(object sender, EventArgs e)
        {
            IsRunning = true;
            if (GetActiveCodes().Count > 0)
                RedeemAllActive();
            else
                MessageBox.Show("There are no codes currently active.");
        }
        private void button_redeemSelected_Click(object sender, EventArgs e)
        {
            IsRunning = true;
            var codes = GetActiveCodes();
            var selectedIndex = listView_ActiveCodes.SelectedIndices[0];
            if (selectedIndex > -1)
                RedeemSingle(codes[selectedIndex]);
        }
        private void button_sendTestEmail_Click(object sender, EventArgs e)
        {
            if (notificationSound)
                PlayNotificationSound();
            if(notificationSetting)
                DisplayNotification("This is a test notification.");
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

        private void textbox_whitelistedUsernames_TextChanged(object sender, EventArgs e)
        {
            whitelistedUsernames.Clear();
            whitelistedUsernames.AddRange(textbox_whitelistedUsernames.Lines.ToArray());
        }        
        private void textbox_BlacklistedWords_TextChanged(object sender, EventArgs e)
        {
            blacklistedWords.Clear();
            blacklistedWords.AddRange(textbox_BlacklistedWords.Lines.ToArray());
        }
        private void textbox_NotificationSound_TextChanged(object sender, EventArgs e)
        {
            notificationSoundFilePath = textbox_NotificationSound.Text;
        }

        private void logbox_TextChanged(object sender, EventArgs e)
        {
            logbox.SelectionStart = logbox.Text.Length;
            logbox.ScrollToCaret();
        }

        private void comboBox_vKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            killswitchKey = (int)EnumHelper.GetEnumValue<VirtualKeyStates>(comboBox_vKeys.SelectedItem.ToString());
            label_ksNote.Text = $"Note: Press {killswitchKeyString} to stop automation script.";
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx");
        }
        #endregion

        #region Menu Bar Controls
        private void activeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearActiveCodes();
        }
        private void expiredListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearExpiredCodes();
        }
        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listView_ActiveCodes.SelectedIndices[0] >= 0 && listView_ActiveCodes.SelectedIndices[0] < listView_ActiveCodes.Items.Count)
            {
                var codes = GetActiveCodes();
                RemoveCodeFromList(codes[listView_ActiveCodes.SelectedIndices[0]].GetCode());
            }
        }
        private void expiredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listbox_Expired.SelectedIndex >= 0 && listbox_Expired.SelectedIndex < listbox_Expired.Items.Count)
            {
                var i = listbox_Expired.SelectedIndex;
                var codes = GetExpiredCodes();
                RemoveCodeFromList(codes[i].GetCode());
            }
        }
        private void activeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddCodeToCodeListDebug(GenerateRandomSmiteCode(), true, DateTime.Now);
        }
        private void expiredToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddCodeToCodeList(GenerateRandomSmiteCode(), false);
        }
        private void wikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Lumbridge/SmiteMixerCodeRedeemer/blob/master/README.md");
        }
        private void webVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.lumbridge.org/dashboard");
        }
        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MetaInfo.GetMetaInfoMessageBox(), "Smite Mixer Code Grabber Credits");
        }
        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Lumbridge/SmiteMixerCodeRedeemer/issues");
        }
        private void userGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Lumbridge/SmiteMixerCodeRedeemer/blob/master/README.md");
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
                                shouldMinimise = true;
                            }
                        }
                    }
                    if (minimiseAfterRedeeming && shouldMinimise)
                    {
                        MinimiseSMITEClient();
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

        private void trackbar_RedeemDelay_Scroll(object sender, ScrollEventArgs e)
        {
            label_redeemDelay.Text = trackbar_RedeemDelay.Value + " Minutes";
        }

        private void trackbar_RedeemDelay_MouseUp(object sender, MouseEventArgs e)
        {
            redeemDelay = trackbar_RedeemDelay.Value;
            label_redeemDelay.Text = redeemDelay + " Minutes";
        }
    }
}