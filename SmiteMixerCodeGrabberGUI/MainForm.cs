using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using MixerChat;
using MixerChat.Classes;

using static SmiteMixerListener.Classes.Common;

using static SmiteMixerCodeGrabberGUI.Classes.AllCodes;
using static SmiteMixerCodeGrabberGUI.Classes.Common;
using static SmiteMixerCodeGrabberGUI.Classes.DynamicResolution;

using static DolphinScript.Lib.Backend.WinAPI;
using static DolphinScript.Lib.Backend.Common;

using SmiteMixerCodeGrabberGUI.Classes;

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
            textbox_startCharacters.Text = Properties.Settings.Default.codesStartWith;
            textbox_whitelistedUsernames.Lines = Properties.Settings.Default.whitelistedUsernames.Cast<string>().ToArray();
            textbox_NotificationSound.Text = Properties.Settings.Default.notificationSoundFilePath;
            // checkboxes
            checkbox_NotificationSound.Checked = Properties.Settings.Default.notificationSound;
            checkbox_whiteListOnly.Checked = Properties.Settings.Default.whitelistOnly;
            checkbox_showNotifications.Checked = Properties.Settings.Default.notificationSetting;
            // numberboxes
            numberbox_codeLength.Value = Properties.Settings.Default.codeLength;

            // write the meta info to the console
            Console.Write(MetaInfo.GetMetaInfoConsole());

            // hook up the mixer API callbacks
            Mixer chat = new Mixer();
            chat.OnMessageReceived += Chat_OnMessageReceived;
            chat.OnUserJoined += Chat_OnUserJoined;
            chat.OnUserLeft += Chat_OnUserLeft;
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
            if (!Properties.Settings.Default.AFKMode)
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
                Properties.Settings.Default.AFKMode = false;
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
            if (!Properties.Settings.Default.whitelistOnly)
            {
                if (e.Message.Contains(Properties.Settings.Default.codesStartWith))
                {
                    var m = e.Message;
                    try
                    {
                        var code = m.Substring(m.IndexOf(Properties.Settings.Default.codesStartWith), Properties.Settings.Default.codeLength);

                        if (GetActiveCodes().Find(x => x.GetCode() == code) == null && GetExpiredCodes().Find(x => x.GetCode() == code) == null && !code.Contains(" "))
                        {
                            AddCodeToCodeList(code, true);
                            Write("Code: " + code + " added to active codes (Grabbed from user: " + e.User + ").");
                        }
                        else
                        {
                            if (!code.Contains(" "))
                                Write("Code Spotted: " + code + " (Already Redeemed).");
                            else
                                Write("Potential Code Spotted: " + code + " (Invalid)");
                        }
                    }
                    catch { }
                }
            }
            else
            {
                if (isWhitelistedUser(e.User))
                {
                    var m = e.Message;
                    try
                    {
                        var code = m.Substring(m.IndexOf(Properties.Settings.Default.codesStartWith), Properties.Settings.Default.codeLength);

                        if (GetActiveCodes().Find(x => x.GetCode() == code) == null && GetExpiredCodes().Find(x => x.GetCode() == code) == null && !code.Contains(" "))
                        {
                            AddCodeToCodeList(code, true);
                            Write("Code: " + code + " added to active codes (Grabbed from user: " + e.User + ").");
                            if (Properties.Settings.Default.notificationSound)
                                PlayNotificationSound();
                            if (Properties.Settings.Default.notificationSetting)
                                DisplayNotification("New code added to active codes: \n" + code);
                        }
                        else
                        {
                            if (!code.Contains(" "))
                                Write("Code Spotted: " + code + " (Already Redeemed).");
                            else
                                Write("Potential Code Spotted: " + code + " (Invalid Format)");
                        }
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        var m = e.Message;
                        var code = m.Substring(m.IndexOf(Properties.Settings.Default.codesStartWith), Properties.Settings.Default.codeLength);
                        Write("Code matching specified criteria was observed: " + code + " posted by user: " + e.User);
                    } catch { }
                }
            }
        }

        private static void Chat_OnError(ErrorEventArgs e)
        {
            Write(e.Exception.Message);
        }

        private static void Chat_OnUserLeft(UserEventArgs e)
        {
            //Console.WriteLine(string.Format("{0} left", e.User));
        }

        private static void Chat_OnUserJoined(UserEventArgs e)
        {
            //Console.WriteLine(string.Format("{0} joined", e.User));
        }
        #endregion

        #region Main Form Controls
        private void checkbox_showNotifications_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.notificationSetting = checkbox_showNotifications.Checked;
            Properties.Settings.Default.Save();
            Write("Show notification when new code is active: " + Properties.Settings.Default.notificationSetting);
        }
        private void button_redeemAllActive_Click(object sender, EventArgs e)
        {
            IsRunning = true;
            if (GetActiveCodes().Count > 0)
                Classes.Automation.RedeemAllActive();
            else
                MessageBox.Show("There are no codes currently active.");
        }
        private void button_redeemSelected_Click(object sender, EventArgs e)
        {
            IsRunning = true;
            var codes = GetActiveCodes();
            var selectedIndex = listbox_Active.SelectedIndex;
            if (selectedIndex > -1)
                Automation.RedeemSingle(codes[selectedIndex]);
        }
        private void checkbox_whiteListOnly_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.whitelistOnly = checkbox_whiteListOnly.Checked;
            Properties.Settings.Default.Save();
        }
        private void checkbox_AFKMode_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AFKMode = checkbox_AFKMode.Checked;
            IsRunning = checkbox_AFKMode.Checked;
            Write("AFK Mode Enabled: " + Properties.Settings.Default.AFKMode);
        }
        private void button_sendTestEmail_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.notificationSound)
                PlayNotificationSound();
            if(Properties.Settings.Default.notificationSetting)
                DisplayNotification("This is a test notification.");
        }
        private void numberbox_codeLength_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.codeLength = (int)numberbox_codeLength.Value;
            Properties.Settings.Default.Save();
        }
        private void textbox_startCharacters_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.codesStartWith = textbox_startCharacters.Text;
            Properties.Settings.Default.Save();
        }
        private void textbox_whitelistedUsernames_TextChanged(object sender, EventArgs e)
        {
            Whitelist.SaveWhitelist(textbox_whitelistedUsernames);
            Properties.Settings.Default.whitelistedUsernames.Clear();
            Properties.Settings.Default.whitelistedUsernames.AddRange(textbox_whitelistedUsernames.Lines.ToArray());
            Properties.Settings.Default.Save();
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
                Properties.Settings.Default.notificationSoundFilePath = o.FileName;
                Properties.Settings.Default.Save();
                textbox_NotificationSound.Text = o.FileName;
            }
        }
        private void textbox_NotificationSound_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.notificationSoundFilePath = textbox_NotificationSound.Text;
            Properties.Settings.Default.Save();
        }
        private void checkbox_NotificationSound_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_NotificationSound.Checked)
            {
                Properties.Settings.Default.notificationSound = true;
                Properties.Settings.Default.Save();
                Write("Notification sound enabled: " + Properties.Settings.Default.notificationSound + "; A sound will be played when a new code becomes active.");
            }
            else
            {
                Properties.Settings.Default.notificationSound = false;
                Properties.Settings.Default.Save();
                Write("Notification sound enabled: " + Properties.Settings.Default.notificationSound + "; A sound will not be played when a new code becomes active.");
            }
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
            int len = Properties.Settings.Default.codeLength;

            Random random = new Random();

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return Properties.Settings.Default.codesStartWith + new string(Enumerable.Repeat(chars, len - 2)
                .Select(s => s[random.Next(s.Length)]).ToArray());
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
                if (Properties.Settings.Default.AFKMode == true)
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
                            if(IsRunning)
                                code.SetIsRedeemed(true);
                        }
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
                    Properties.Settings.Default.AFKMode = false;
                    Properties.Settings.Default.Save();

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
                    Properties.Settings.Default.smiteWindowTitle = ProcessInfo.GetSmiteWindowTitle();
                else
                    // no process found: set smite window title to error message
                    Properties.Settings.Default.smiteWindowTitle = "SMITE Client Not Found (Automation Disabled).";
                // sleep to reduce CPU usage
                Thread.Sleep(100);
            }
        }
        #endregion
    }
}