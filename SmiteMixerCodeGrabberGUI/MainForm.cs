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

namespace SmiteMixerCodeGrabberGUI
{
    public partial class MainForm : Form
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
            // set whether to catch calls on the wrong thread that access a control's handle property when an application is being debugged
            CheckForIllegalCrossThreadCalls = false;

            // override the console to output console.writeline to our custom console log
            Console.SetOut(new LogWriter(logbox));
            
            // load up all saved properties
            //
            // textboxes
            textbox_startCharacters.Text = codesStartWith;
            textbox_whitelistedUsernames.Lines = whitelistedUsernames.Cast<string>().ToArray();
            textbox_NotificationSound.Text = notificationSoundFilePath;
            // checkboxes
            checkbox_NotificationSound.Checked = notificationSound;
            checkbox_whiteListOnly.Checked = whitelistOnly;
            checkbox_showNotifications.Checked = notificationSetting;
            checkbox_MinimiseAfterRedeeming.Checked = minimiseAfterRedeeming;
            // numberboxes
            numberbox_codeLength.Value = codeLength;

            // write the meta info to the console
            Console.Write(MetaInfo.GetMetaInfoConsole());

            // hook up the mixer API callbacks
            Mixer chat = new Mixer();
            chat.OnMessageReceived += Chat_OnMessageReceived;
            chat.OnError += Chat_OnError;
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
            // save the whitelist contents to the whitelist static list
            Whitelist.SaveWhitelist(textbox_whitelistedUsernames);
            // set is running to true by default
            IsRunning = true;
        }

        /// <summary>
        /// This method is called each second that passes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_MainForm_Tick(object sender, EventArgs e)
        {
            // get the selected index of the active codes box
            var currentlySelectedIndex = listbox_Active.SelectedIndex;

            // clear the contents of the active codes box
            listbox_Active.Items.Clear();
            // loop through all active codes
            foreach (var aCode in GetActiveCodes())
            {
                // add each active code to the active codes box
                listbox_Active.Items.Add(aCode.GetCode() + " " + aCode.GetTimeLeftString() + " Redeemed: " + aCode.GetIsRedeemed());
            }
            // clear the contents of the expired codes box
            listbox_Expired.Items.Clear();
            // loop through all expired codes
            foreach (var eCode in GetExpiredCodes())
            {
                // add each expired code to the expired codes box
                listbox_Expired.Items.Add(eCode.GetCode() + " Redeemed: " + eCode.GetIsRedeemed());
            }

            // here we want to reselect the item that was selected by the user in the active codes box
            //
            // check that the active codes box isn't empty
            if (listbox_Active.Items.Count == 0)
            { /* do nothing */ }
            // check that the selected index was in the bounds of the array
            else if (currentlySelectedIndex >= 0 && currentlySelectedIndex < listbox_Active.Items.Count)
                listbox_Active.SelectedIndex = currentlySelectedIndex;
            // if the selected index is +1 over the current count then select the last item
            else if (currentlySelectedIndex == listbox_Active.Items.Count + 1)
                listbox_Active.SelectedIndex = listbox_Active.Items.Count - 1;
            else { /* do nothing */ }

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
            // this branch will run if the user is not using the white list
            if (!whitelistOnly)
            {
                // check if the message has the code start in it
                if (e.Message.Contains(codesStartWith)
                    && e.Message.Length >= codeLength)
                {
                    shouldAddCode(e.Message, e.User);
                }
            }
            else // whitelist branch
            {
                // check if the message was from a whitelisted user and message contains the start of the code
                if (isWhitelistedUser(e.User) &&
                    e.Message.Contains(codesStartWith)
                    && e.Message.Length >= codeLength)
                {
                    shouldAddCode(e.Message, e.User);
                }
                else // code observed from non-whitelist user
                {
                    // remove everything before the code start
                    var lTest = e.Message.Remove(0, e.Message.IndexOf(codesStartWith));
                    // check that the length of the remaining message is equal to or greater than the length of a code
                    if (lTest.Length >= codeLength)
                    {
                        var m = e.Message;
                        var code = m.Substring(m.IndexOf(codesStartWith), codeLength);
                        Write("Code matching specified criteria was observed: " + code + " posted by user: " + e.User);
                    }
                }
            }
        }
        private static void Chat_OnError(ErrorEventArgs e)
        {
            //Write(e.Exception.Message);
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
                Write("Notification sound enabled: " + notificationSound + "; A sound will be played when a new code becomes active.");
            else
                Write("Notification sound disabled: " + notificationSound + "; A sound will not be played when a new code becomes active.");
        }
        private void checkbox_whiteListOnly_CheckedChanged(object sender, EventArgs e)
        {
            whitelistOnly = checkbox_whiteListOnly.Checked;

            if (whitelistOnly)
                Write("Whitelist mode enabled, will only add active codes from whitelisted usernames.");
            else
                Write("Whitelist mode disabled, will grab potentially active codes from any username.");
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
            var selectedIndex = listbox_Active.SelectedIndex;
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
            if(listbox_Active.SelectedIndex >= 0)
            {
                try
                {
                    Clipboard.SetText(GetActiveCodes()[listbox_Active.SelectedIndex].GetCode());
                    Write("Copied code to clipboard: " + GetActiveCodes()[listbox_Active.SelectedIndex].GetCode());
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

        private void textbox_startCharacters_TextChanged(object sender, EventArgs e)
        {
            codesStartWith = textbox_startCharacters.Text;
            Write("Will search for codes which start with the characters: " + codesStartWith + ".");
        }
        private void textbox_whitelistedUsernames_TextChanged(object sender, EventArgs e)
        {
            Whitelist.SaveWhitelist(textbox_whitelistedUsernames);
            whitelistedUsernames.Clear();
            whitelistedUsernames.AddRange(textbox_whitelistedUsernames.Lines.ToArray());
        }        
        private void textbox_NotificationSound_TextChanged(object sender, EventArgs e)
        {
            notificationSoundFilePath = textbox_NotificationSound.Text;
        }

        private void numberbox_codeLength_ValueChanged(object sender, EventArgs e)
        {
            codeLength = (int)numberbox_codeLength.Value;
            Write("Will search for codes which are " + codeLength + " characters long.");
        }

        private void logbox_TextChanged(object sender, EventArgs e)
        {
            logbox.SelectionStart = logbox.Text.Length;
            logbox.ScrollToCaret();
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
            if(listbox_Active.SelectedIndex >= 0 && listbox_Active.SelectedIndex < listbox_Active.Items.Count)
            {
                var i = listbox_Active.SelectedIndex;
                var codes = GetActiveCodes();
                RemoveCodeFromList(codes[i].GetCode());
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
            AddCodeToCodeListDebug(GenerateRandomSmiteCode(), true, DateTime.Now.Subtract(new TimeSpan(0,27,00)));
        }
        private void expiredToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddCodeToCodeList(GenerateRandomSmiteCode(), false);
        }
        private void wikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Lumbridge/SmiteMixerCodeRedeemer/blob/master/README.md");
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
            return Whitelist.GetIsWhitelistedUser(user);
        }
        public static string GenerateRandomSmiteCode()
        {
            int len = codeLength;

            Random random = new Random();

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return codesStartWith + new string(Enumerable.Repeat(chars, len - 2)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// Added to reduce duplicated code in OnMessageRecieved handler,
        /// checks if a message contains a valid code and adds it to the active codes list if it is valid.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="user"></param>
        static void shouldAddCode(string message, string user)
        {
            // remove everything before the code start
            var lTest = message.Remove(0, message.IndexOf(codesStartWith));
            // check that the length of the remaining message is equal to or greater than the length of a code
            if (lTest.Length >= codeLength)
            {
                // get the message
                var m = message;
                // extract the code from the message
                var code = m.Substring(m.IndexOf(codesStartWith), codeLength);
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
                else // code is already in a list or is invalid format
                {
                    badCode(code);
                }
            }
        }
        /// <summary>
        /// Also added to reduce duplicated code, outputs
        /// a message to the log if a code is invalid.
        /// </summary>
        /// <param name="code"></param>
        static void badCode(string code)
        {
            if (!code.Contains(" "))
                Write("Code Spotted: " + code + " (Already Redeemed).");
            else
                Write("Potential Code Spotted: " + code + " (Invalid Format)");
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
                    foreach (var code in GetActiveCodes())
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
        /// This method listens for the F5 killswitch key which disables automation.
        /// </summary>
        public static void CheckForTerminationKey()
        {
            // runs until application is closed
            while (true)
            {
                // listen for the F5 key
                if (GetAsyncKeyState(VirtualKeyStates.VK_F5) < 0)
                {
                    // set is running flag to false
                    IsRunning = false;

                    // disable afk mode
                    AFKMode = false;

                    // output notification to show afk mode is disabled
                    DisplayNotification("F5 Key Detected: AFK Mode disabled.");
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
    }
}