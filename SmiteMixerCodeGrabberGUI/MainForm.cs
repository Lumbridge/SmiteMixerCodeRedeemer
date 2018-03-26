using System;
using System.Text;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using MixerChat;
using MixerChat.Classes;

using static SmiteMixerListener.Classes.Common;

using static SmiteMixerCodeGrabberGUI.Classes.AllCodes;

using static SmiteMixerCodeGrabberGUI.Classes.Common;
using System.Collections.Specialized;

namespace SmiteMixerCodeGrabberGUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            numberbox_codeLength.Value = Properties.Settings.Default.codeLength;
            textbox_startCharacters.Text = Properties.Settings.Default.codesStartWith;
            textbox_whitelistedUsernames.Lines = Properties.Settings.Default.whitelistedUsernames.Cast<string>().ToArray();
            checkbox_showNotifications.Checked = Properties.Settings.Default.notificationSetting;
            checkbox_whiteListOnly.Checked = Properties.Settings.Default.whitelistOnly;

            // meta info
            Write(Classes.MetaInfo.GetMetaInfoConsole(), false);

            Mixer chat = new Mixer();
            chat.OnMessageReceived += Chat_OnMessageReceived;
            chat.OnUserJoined += Chat_OnUserJoined;
            chat.OnUserLeft += Chat_OnUserLeft;
            chat.OnError += Chat_OnError;
            var connected = chat.Connect("SmiteGame");

            Task.Run(() => MainLoop());
        }

        #region Mixer Chat Handlers
        private static void Chat_OnMessageReceived(ChatMessageEventArgs e)
        {
            if (!Properties.Settings.Default.whitelistOnly)
            {
                if (e.Message.Contains("AP"))
                {
                    var m = e.Message;
                    try
                    {
                        var code = m.Substring(m.IndexOf("AP"), 17);

                        if (GetActiveCodes().Find(x => x.GetCode() == code) == null && GetExpiredCodes().Find(x => x.GetCode() == code) == null && !code.Contains(" "))
                        {
                            AddCodeToCodeList(code, true);
                            if (Properties.Settings.Default.notificationSetting)
                                DisplayNotification("New potential code added to active codes: \n" + code);
                        }
                        else
                        {
                            if (!code.Contains(" "))
                                Write("Code Spotted: " + code + " (Already Redeemed).", true);
                            else
                                Write("Potential Code Spotted: " + code + " (Invalid)", true);
                        }
                    }
                    catch { }
                }
                else
                {
                    if (isWhitelistedUser(e.User) && e.Message.Contains("AP"))
                    {
                        var m = e.Message;
                        try
                        {
                            var code = m.Substring(m.IndexOf("AP"), 17);

                            if (GetActiveCodes().Find(x => x.GetCode() == code) == null && GetExpiredCodes().Find(x => x.GetCode() == code) == null && !code.Contains(" "))
                            {
                                AddCodeToCodeList(code, true);
                                if (Properties.Settings.Default.notificationSetting)
                                    DisplayNotification("New potential code added to active codes: \n" + code);
                            }
                            else
                            {
                                if (!code.Contains(" "))
                                    Write("Code Spotted: " + code + " (Already Redeemed).", true);
                                else
                                    Write("Potential Code Spotted: " + code + " (Invalid)", true);
                            }
                        }
                        catch { }
                    }
                }
            }
        }

        private static void Chat_OnError(ErrorEventArgs e)
        {
            Write(e.Exception.Message, true);
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
        }
        private void button_redeemAllActive_Click(object sender, EventArgs e)
        {
            if (GetActiveCodes().Count > 0)
                Classes.Automation.RedeemAllActive();
            else
                MessageBox.Show("There are no codes currently active.");
        }
        private void button_redeemSelected_Click(object sender, EventArgs e)
        {
            var codes = GetActiveCodes();
            var selectedIndex = listbox_Active.SelectedIndex;
            if (selectedIndex > -1)
                Classes.Automation.RedeemSingle(codes[selectedIndex]);
        }
        private void checkbox_whiteListOnly_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.whitelistOnly = checkbox_whiteListOnly.Checked;
            Properties.Settings.Default.Save();
        }
        private void checkbox_AFKMode_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AFKMode = checkbox_AFKMode.Checked;
        }
        private void button_sendTestEmail_Click(object sender, EventArgs e)
        {
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
            Properties.Settings.Default.whitelistedUsernames.Clear();
            Properties.Settings.Default.whitelistedUsernames.AddRange(textbox_whitelistedUsernames.Lines.ToArray());
            Properties.Settings.Default.Save();
        }        
        private void timer_MainForm_Tick(object sender, EventArgs e)
        {
            var s = listbox_Active.SelectedIndex;

            listbox_Active.Items.Clear();
            foreach (var aCode in GetActiveCodes())
            {
                listbox_Active.Items.Add(aCode.GetCode() + " " + aCode.GetTimeLeftString() + " Redeemed: " + aCode.GetIsRedeemed());
            }
            listbox_Expired.Items.Clear();
            foreach (var eCode in GetExpiredCodes())
            {
                listbox_Expired.Items.Add(eCode.GetCode() + " Redeemed: " + eCode.GetIsRedeemed());
            }

            if (s < listbox_Active.Items.Count)
                listbox_Active.SelectedIndex = s;
            else
                listbox_Active.SelectedIndex = listbox_Active.Items.Count - 1;
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
            AddCodeToCodeList(GenerateRandomSmiteCode(), true);
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
            MessageBox.Show(Classes.MetaInfo.GetMetaInfoMessageBox(), "Smite Mixer Code Grabber Credits");
        }
        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Lumbridge/SmiteMixerCodeRedeemer/issues");
        }
        #endregion

        #region Helper Methods
        public static bool isWhitelistedUser(string user)
        {
            return Classes.Whitelist.GetIsWhitelistedUser(user);
        }
        public static string GenerateRandomSmiteCode()
        {
            int len = Properties.Settings.Default.codeLength;

            Random random = new Random();

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return Properties.Settings.Default.codesStartWith + new string(Enumerable.Repeat(chars, len - 2)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static void MainLoop()
        {
            while (Properties.Settings.Default.AFKMode)
            {
                if (Properties.Settings.Default.AFKMode == true)
                {
                    foreach (var code in GetActiveCodes())
                    {
                        if (code.GetIsRedeemed() == false)
                        {
                            // get the event list and pass it the code we want it to type
                            //
                            var loop = Classes.Automation.GetRedeemLoop(code.GetCode());

                            foreach (var ev in loop)
                                ev.DoEvent();

                            code.SetIsRedeemed(true);
                        }
                    }
                }
                else
                    Write("No codes currently in the queue...", true);

                Thread.Sleep(15000);
            }
        }
        #endregion

    }
}
