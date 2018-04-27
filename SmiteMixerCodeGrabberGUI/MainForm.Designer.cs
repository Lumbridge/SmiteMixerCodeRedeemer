namespace SmiteMixerCodeGrabberGUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listbox_Active = new System.Windows.Forms.ListBox();
            this.menustrip_mainForm = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportBugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTestCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.expiredToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearActiveListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expiredListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expiredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listbox_Expired = new System.Windows.Forms.ListBox();
            this.button_redeemSelected = new System.Windows.Forms.Button();
            this.button_redeemAllActive = new System.Windows.Forms.Button();
            this.checkbox_showNotifications = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkbox_NotificationSound = new System.Windows.Forms.CheckBox();
            this.button_BrowseNotificationSound = new System.Windows.Forms.Button();
            this.textbox_NotificationSound = new System.Windows.Forms.TextBox();
            this.button_sendTestEmail = new System.Windows.Forms.Button();
            this.groupbox_whitelistedUsernames = new System.Windows.Forms.GroupBox();
            this.textbox_whitelistedUsernames = new System.Windows.Forms.RichTextBox();
            this.groupbox_activeCodes = new System.Windows.Forms.GroupBox();
            this.button_CopySelectedToClipboard = new System.Windows.Forms.Button();
            this.groupbox_expiredCodes = new System.Windows.Forms.GroupBox();
            this.timer_MainForm = new System.Windows.Forms.Timer(this.components);
            this.checkbox_AFKMode = new System.Windows.Forms.CheckBox();
            this.label_ksNote = new System.Windows.Forms.Label();
            this.logbox = new System.Windows.Forms.RichTextBox();
            this.label_SmiteClientVersion = new System.Windows.Forms.Label();
            this.checkbox_MinimiseAfterRedeeming = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_killswitch = new System.Windows.Forms.TabPage();
            this.linkLabel_KeyCodes = new System.Windows.Forms.LinkLabel();
            this.checkBox_disableKillswitch = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_vKeys = new System.Windows.Forms.ComboBox();
            this.label_killswitch = new System.Windows.Forms.Label();
            this.tabPage_ParserSettings = new System.Windows.Forms.TabPage();
            this.checkBox_aggressiveParser = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage_Whitelist = new System.Windows.Forms.TabPage();
            this.tabPage_Blacklist = new System.Windows.Forms.TabPage();
            this.groupBox_blacklist = new System.Windows.Forms.GroupBox();
            this.textbox_BlacklistedWords = new System.Windows.Forms.RichTextBox();
            this.menustrip_mainForm.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupbox_whitelistedUsernames.SuspendLayout();
            this.groupbox_activeCodes.SuspendLayout();
            this.groupbox_expiredCodes.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_killswitch.SuspendLayout();
            this.tabPage_ParserSettings.SuspendLayout();
            this.tabPage_Whitelist.SuspendLayout();
            this.tabPage_Blacklist.SuspendLayout();
            this.groupBox_blacklist.SuspendLayout();
            this.SuspendLayout();
            // 
            // listbox_Active
            // 
            this.listbox_Active.FormattingEnabled = true;
            this.listbox_Active.Location = new System.Drawing.Point(6, 19);
            this.listbox_Active.Name = "listbox_Active";
            this.listbox_Active.Size = new System.Drawing.Size(286, 95);
            this.listbox_Active.TabIndex = 0;
            // 
            // menustrip_mainForm
            // 
            this.menustrip_mainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.webVersionToolStripMenuItem});
            this.menustrip_mainForm.Location = new System.Drawing.Point(0, 0);
            this.menustrip_mainForm.Name = "menustrip_mainForm";
            this.menustrip_mainForm.Size = new System.Drawing.Size(624, 24);
            this.menustrip_mainForm.TabIndex = 1;
            this.menustrip_mainForm.Text = "menustrip_mainForm";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wikiToolStripMenuItem,
            this.creditsToolStripMenuItem,
            this.reportBugToolStripMenuItem,
            this.userGuideToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // wikiToolStripMenuItem
            // 
            this.wikiToolStripMenuItem.Name = "wikiToolStripMenuItem";
            this.wikiToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.wikiToolStripMenuItem.Text = "Wiki";
            this.wikiToolStripMenuItem.Click += new System.EventHandler(this.wikiToolStripMenuItem_Click);
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.creditsToolStripMenuItem.Text = "Credits";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
            // 
            // reportBugToolStripMenuItem
            // 
            this.reportBugToolStripMenuItem.Name = "reportBugToolStripMenuItem";
            this.reportBugToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.reportBugToolStripMenuItem.Text = "Report Bug";
            this.reportBugToolStripMenuItem.Click += new System.EventHandler(this.reportBugToolStripMenuItem_Click);
            // 
            // userGuideToolStripMenuItem
            // 
            this.userGuideToolStripMenuItem.Name = "userGuideToolStripMenuItem";
            this.userGuideToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.userGuideToolStripMenuItem.Text = "User Guide";
            this.userGuideToolStripMenuItem.Click += new System.EventHandler(this.userGuideToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTestCodeToolStripMenuItem,
            this.clearActiveListToolStripMenuItem,
            this.removeSelectedToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // addTestCodeToolStripMenuItem
            // 
            this.addTestCodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeToolStripMenuItem1,
            this.expiredToolStripMenuItem1});
            this.addTestCodeToolStripMenuItem.Name = "addTestCodeToolStripMenuItem";
            this.addTestCodeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addTestCodeToolStripMenuItem.Text = "Add Test Code";
            // 
            // activeToolStripMenuItem1
            // 
            this.activeToolStripMenuItem1.Name = "activeToolStripMenuItem1";
            this.activeToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.activeToolStripMenuItem1.Text = "Active";
            this.activeToolStripMenuItem1.Click += new System.EventHandler(this.activeToolStripMenuItem1_Click);
            // 
            // expiredToolStripMenuItem1
            // 
            this.expiredToolStripMenuItem1.Name = "expiredToolStripMenuItem1";
            this.expiredToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.expiredToolStripMenuItem1.Text = "Expired";
            this.expiredToolStripMenuItem1.Click += new System.EventHandler(this.expiredToolStripMenuItem1_Click);
            // 
            // clearActiveListToolStripMenuItem
            // 
            this.clearActiveListToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeListToolStripMenuItem,
            this.expiredListToolStripMenuItem});
            this.clearActiveListToolStripMenuItem.Name = "clearActiveListToolStripMenuItem";
            this.clearActiveListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearActiveListToolStripMenuItem.Text = "Clear List";
            // 
            // activeListToolStripMenuItem
            // 
            this.activeListToolStripMenuItem.Name = "activeListToolStripMenuItem";
            this.activeListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.activeListToolStripMenuItem.Text = "Active";
            this.activeListToolStripMenuItem.Click += new System.EventHandler(this.activeListToolStripMenuItem_Click);
            // 
            // expiredListToolStripMenuItem
            // 
            this.expiredListToolStripMenuItem.Name = "expiredListToolStripMenuItem";
            this.expiredListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.expiredListToolStripMenuItem.Text = "Expired";
            this.expiredListToolStripMenuItem.Click += new System.EventHandler(this.expiredListToolStripMenuItem_Click);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeToolStripMenuItem,
            this.expiredToolStripMenuItem});
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeSelectedToolStripMenuItem.Text = "Remove Selected";
            // 
            // activeToolStripMenuItem
            // 
            this.activeToolStripMenuItem.Name = "activeToolStripMenuItem";
            this.activeToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.activeToolStripMenuItem.Text = "Active";
            this.activeToolStripMenuItem.Click += new System.EventHandler(this.activeToolStripMenuItem_Click);
            // 
            // expiredToolStripMenuItem
            // 
            this.expiredToolStripMenuItem.Name = "expiredToolStripMenuItem";
            this.expiredToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.expiredToolStripMenuItem.Text = "Expired";
            this.expiredToolStripMenuItem.Click += new System.EventHandler(this.expiredToolStripMenuItem_Click);
            // 
            // webVersionToolStripMenuItem
            // 
            this.webVersionToolStripMenuItem.Name = "webVersionToolStripMenuItem";
            this.webVersionToolStripMenuItem.Size = new System.Drawing.Size(140, 20);
            this.webVersionToolStripMenuItem.Text = "Get Email Notifications";
            this.webVersionToolStripMenuItem.Click += new System.EventHandler(this.webVersionToolStripMenuItem_Click);
            // 
            // listbox_Expired
            // 
            this.listbox_Expired.FormattingEnabled = true;
            this.listbox_Expired.Location = new System.Drawing.Point(6, 19);
            this.listbox_Expired.Name = "listbox_Expired";
            this.listbox_Expired.Size = new System.Drawing.Size(286, 95);
            this.listbox_Expired.TabIndex = 2;
            // 
            // button_redeemSelected
            // 
            this.button_redeemSelected.Location = new System.Drawing.Point(6, 120);
            this.button_redeemSelected.Name = "button_redeemSelected";
            this.button_redeemSelected.Size = new System.Drawing.Size(142, 23);
            this.button_redeemSelected.TabIndex = 5;
            this.button_redeemSelected.Text = "Redeem Selected Code";
            this.button_redeemSelected.UseVisualStyleBackColor = true;
            this.button_redeemSelected.Click += new System.EventHandler(this.button_redeemSelected_Click);
            // 
            // button_redeemAllActive
            // 
            this.button_redeemAllActive.Location = new System.Drawing.Point(150, 120);
            this.button_redeemAllActive.Name = "button_redeemAllActive";
            this.button_redeemAllActive.Size = new System.Drawing.Size(142, 23);
            this.button_redeemAllActive.TabIndex = 6;
            this.button_redeemAllActive.Text = "Redeem All Active Codes";
            this.button_redeemAllActive.UseVisualStyleBackColor = true;
            this.button_redeemAllActive.Click += new System.EventHandler(this.button_redeemAllActive_Click);
            // 
            // checkbox_showNotifications
            // 
            this.checkbox_showNotifications.AutoSize = true;
            this.checkbox_showNotifications.Location = new System.Drawing.Point(9, 19);
            this.checkbox_showNotifications.Name = "checkbox_showNotifications";
            this.checkbox_showNotifications.Size = new System.Drawing.Size(246, 17);
            this.checkbox_showNotifications.TabIndex = 10;
            this.checkbox_showNotifications.Text = "Show a notification when a new code is active";
            this.checkbox_showNotifications.UseVisualStyleBackColor = true;
            this.checkbox_showNotifications.CheckedChanged += new System.EventHandler(this.checkbox_showNotifications_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkbox_NotificationSound);
            this.groupBox1.Controls.Add(this.button_BrowseNotificationSound);
            this.groupBox1.Controls.Add(this.textbox_NotificationSound);
            this.groupBox1.Controls.Add(this.checkbox_showNotifications);
            this.groupBox1.Controls.Add(this.button_sendTestEmail);
            this.groupBox1.Location = new System.Drawing.Point(316, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 126);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notification Options";
            // 
            // checkbox_NotificationSound
            // 
            this.checkbox_NotificationSound.AutoSize = true;
            this.checkbox_NotificationSound.Location = new System.Drawing.Point(9, 42);
            this.checkbox_NotificationSound.Name = "checkbox_NotificationSound";
            this.checkbox_NotificationSound.Size = new System.Drawing.Size(217, 17);
            this.checkbox_NotificationSound.TabIndex = 13;
            this.checkbox_NotificationSound.Text = "Play a sound when a new code is active";
            this.checkbox_NotificationSound.UseVisualStyleBackColor = true;
            this.checkbox_NotificationSound.CheckedChanged += new System.EventHandler(this.checkbox_NotificationSound_CheckedChanged);
            // 
            // button_BrowseNotificationSound
            // 
            this.button_BrowseNotificationSound.Location = new System.Drawing.Point(261, 63);
            this.button_BrowseNotificationSound.Name = "button_BrowseNotificationSound";
            this.button_BrowseNotificationSound.Size = new System.Drawing.Size(30, 23);
            this.button_BrowseNotificationSound.TabIndex = 12;
            this.button_BrowseNotificationSound.Text = "...";
            this.button_BrowseNotificationSound.UseVisualStyleBackColor = true;
            this.button_BrowseNotificationSound.Click += new System.EventHandler(this.button_BrowseNotificationSound_Click);
            // 
            // textbox_NotificationSound
            // 
            this.textbox_NotificationSound.Location = new System.Drawing.Point(9, 65);
            this.textbox_NotificationSound.Name = "textbox_NotificationSound";
            this.textbox_NotificationSound.Size = new System.Drawing.Size(246, 20);
            this.textbox_NotificationSound.TabIndex = 11;
            this.textbox_NotificationSound.TextChanged += new System.EventHandler(this.textbox_NotificationSound_TextChanged);
            // 
            // button_sendTestEmail
            // 
            this.button_sendTestEmail.Location = new System.Drawing.Point(9, 91);
            this.button_sendTestEmail.Name = "button_sendTestEmail";
            this.button_sendTestEmail.Size = new System.Drawing.Size(283, 23);
            this.button_sendTestEmail.TabIndex = 2;
            this.button_sendTestEmail.Text = "Send Test Notification";
            this.button_sendTestEmail.UseVisualStyleBackColor = true;
            this.button_sendTestEmail.Click += new System.EventHandler(this.button_sendTestEmail_Click);
            // 
            // groupbox_whitelistedUsernames
            // 
            this.groupbox_whitelistedUsernames.Controls.Add(this.textbox_whitelistedUsernames);
            this.groupbox_whitelistedUsernames.Enabled = false;
            this.groupbox_whitelistedUsernames.Location = new System.Drawing.Point(6, 6);
            this.groupbox_whitelistedUsernames.Name = "groupbox_whitelistedUsernames";
            this.groupbox_whitelistedUsernames.Size = new System.Drawing.Size(281, 151);
            this.groupbox_whitelistedUsernames.TabIndex = 11;
            this.groupbox_whitelistedUsernames.TabStop = false;
            this.groupbox_whitelistedUsernames.Text = "Only get codes from these users";
            // 
            // textbox_whitelistedUsernames
            // 
            this.textbox_whitelistedUsernames.Location = new System.Drawing.Point(6, 19);
            this.textbox_whitelistedUsernames.Name = "textbox_whitelistedUsernames";
            this.textbox_whitelistedUsernames.Size = new System.Drawing.Size(269, 126);
            this.textbox_whitelistedUsernames.TabIndex = 0;
            this.textbox_whitelistedUsernames.Text = "";
            this.textbox_whitelistedUsernames.TextChanged += new System.EventHandler(this.textbox_whitelistedUsernames_TextChanged);
            // 
            // groupbox_activeCodes
            // 
            this.groupbox_activeCodes.Controls.Add(this.button_CopySelectedToClipboard);
            this.groupbox_activeCodes.Controls.Add(this.listbox_Active);
            this.groupbox_activeCodes.Controls.Add(this.button_redeemSelected);
            this.groupbox_activeCodes.Controls.Add(this.button_redeemAllActive);
            this.groupbox_activeCodes.Location = new System.Drawing.Point(12, 160);
            this.groupbox_activeCodes.Name = "groupbox_activeCodes";
            this.groupbox_activeCodes.Size = new System.Drawing.Size(298, 191);
            this.groupbox_activeCodes.TabIndex = 12;
            this.groupbox_activeCodes.TabStop = false;
            this.groupbox_activeCodes.Text = "Active Codes";
            // 
            // button_CopySelectedToClipboard
            // 
            this.button_CopySelectedToClipboard.Location = new System.Drawing.Point(6, 149);
            this.button_CopySelectedToClipboard.Name = "button_CopySelectedToClipboard";
            this.button_CopySelectedToClipboard.Size = new System.Drawing.Size(286, 30);
            this.button_CopySelectedToClipboard.TabIndex = 8;
            this.button_CopySelectedToClipboard.Text = "Copy Selected Code To Clipboard";
            this.button_CopySelectedToClipboard.UseVisualStyleBackColor = true;
            this.button_CopySelectedToClipboard.Click += new System.EventHandler(this.button_CopySelectedToClipboard_Click);
            // 
            // groupbox_expiredCodes
            // 
            this.groupbox_expiredCodes.Controls.Add(this.listbox_Expired);
            this.groupbox_expiredCodes.Location = new System.Drawing.Point(12, 28);
            this.groupbox_expiredCodes.Name = "groupbox_expiredCodes";
            this.groupbox_expiredCodes.Size = new System.Drawing.Size(298, 126);
            this.groupbox_expiredCodes.TabIndex = 13;
            this.groupbox_expiredCodes.TabStop = false;
            this.groupbox_expiredCodes.Text = "Expired Codes";
            // 
            // timer_MainForm
            // 
            this.timer_MainForm.Enabled = true;
            this.timer_MainForm.Interval = 1000;
            this.timer_MainForm.Tick += new System.EventHandler(this.timer_MainForm_Tick);
            // 
            // checkbox_AFKMode
            // 
            this.checkbox_AFKMode.AutoSize = true;
            this.checkbox_AFKMode.Location = new System.Drawing.Point(507, 462);
            this.checkbox_AFKMode.Name = "checkbox_AFKMode";
            this.checkbox_AFKMode.Size = new System.Drawing.Size(110, 17);
            this.checkbox_AFKMode.TabIndex = 14;
            this.checkbox_AFKMode.Text = "Run in AFK Mode";
            this.checkbox_AFKMode.UseVisualStyleBackColor = true;
            this.checkbox_AFKMode.CheckedChanged += new System.EventHandler(this.checkbox_AFKMode_CheckedChanged);
            // 
            // label_ksNote
            // 
            this.label_ksNote.AutoSize = true;
            this.label_ksNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ksNote.Location = new System.Drawing.Point(12, 460);
            this.label_ksNote.Name = "label_ksNote";
            this.label_ksNote.Size = new System.Drawing.Size(0, 15);
            this.label_ksNote.TabIndex = 15;
            // 
            // logbox
            // 
            this.logbox.Location = new System.Drawing.Point(12, 357);
            this.logbox.Name = "logbox";
            this.logbox.ReadOnly = true;
            this.logbox.Size = new System.Drawing.Size(605, 98);
            this.logbox.TabIndex = 16;
            this.logbox.Text = "";
            this.logbox.TextChanged += new System.EventHandler(this.logbox_TextChanged);
            // 
            // label_SmiteClientVersion
            // 
            this.label_SmiteClientVersion.AutoSize = true;
            this.label_SmiteClientVersion.Location = new System.Drawing.Point(386, 9);
            this.label_SmiteClientVersion.Name = "label_SmiteClientVersion";
            this.label_SmiteClientVersion.Size = new System.Drawing.Size(231, 13);
            this.label_SmiteClientVersion.TabIndex = 17;
            this.label_SmiteClientVersion.Text = "SMITE Client Not Found (Automation Disabled).";
            // 
            // checkbox_MinimiseAfterRedeeming
            // 
            this.checkbox_MinimiseAfterRedeeming.AutoSize = true;
            this.checkbox_MinimiseAfterRedeeming.Location = new System.Drawing.Point(325, 461);
            this.checkbox_MinimiseAfterRedeeming.Name = "checkbox_MinimiseAfterRedeeming";
            this.checkbox_MinimiseAfterRedeeming.Size = new System.Drawing.Size(178, 17);
            this.checkbox_MinimiseAfterRedeeming.TabIndex = 18;
            this.checkbox_MinimiseAfterRedeeming.Text = "Minimise SMITE after redeeming";
            this.checkbox_MinimiseAfterRedeeming.UseVisualStyleBackColor = true;
            this.checkbox_MinimiseAfterRedeeming.CheckedChanged += new System.EventHandler(this.checkbox_MinimiseAfterRedeeming_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_killswitch);
            this.tabControl1.Controls.Add(this.tabPage_ParserSettings);
            this.tabControl1.Controls.Add(this.tabPage_Whitelist);
            this.tabControl1.Controls.Add(this.tabPage_Blacklist);
            this.tabControl1.Location = new System.Drawing.Point(316, 160);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(301, 191);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage_killswitch
            // 
            this.tabPage_killswitch.Controls.Add(this.linkLabel_KeyCodes);
            this.tabPage_killswitch.Controls.Add(this.checkBox_disableKillswitch);
            this.tabPage_killswitch.Controls.Add(this.label1);
            this.tabPage_killswitch.Controls.Add(this.comboBox_vKeys);
            this.tabPage_killswitch.Controls.Add(this.label_killswitch);
            this.tabPage_killswitch.Location = new System.Drawing.Point(4, 22);
            this.tabPage_killswitch.Name = "tabPage_killswitch";
            this.tabPage_killswitch.Size = new System.Drawing.Size(293, 165);
            this.tabPage_killswitch.TabIndex = 2;
            this.tabPage_killswitch.Text = "Killswitch Settings";
            this.tabPage_killswitch.UseVisualStyleBackColor = true;
            // 
            // linkLabel_KeyCodes
            // 
            this.linkLabel_KeyCodes.AutoSize = true;
            this.linkLabel_KeyCodes.Location = new System.Drawing.Point(194, 74);
            this.linkLabel_KeyCodes.Name = "linkLabel_KeyCodes";
            this.linkLabel_KeyCodes.Size = new System.Drawing.Size(78, 13);
            this.linkLabel_KeyCodes.TabIndex = 4;
            this.linkLabel_KeyCodes.TabStop = true;
            this.linkLabel_KeyCodes.Text = "Key Code Help";
            this.linkLabel_KeyCodes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_KeyCodes_LinkClicked);
            // 
            // checkBox_disableKillswitch
            // 
            this.checkBox_disableKillswitch.AutoSize = true;
            this.checkBox_disableKillswitch.Location = new System.Drawing.Point(15, 127);
            this.checkBox_disableKillswitch.Name = "checkBox_disableKillswitch";
            this.checkBox_disableKillswitch.Size = new System.Drawing.Size(105, 17);
            this.checkBox_disableKillswitch.TabIndex = 3;
            this.checkBox_disableKillswitch.Text = "Enable Killswitch";
            this.checkBox_disableKillswitch.UseVisualStyleBackColor = true;
            this.checkBox_disableKillswitch.CheckedChanged += new System.EventHandler(this.checkBox_disableKillswitch_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Killswitch Key";
            // 
            // comboBox_vKeys
            // 
            this.comboBox_vKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vKeys.FormattingEnabled = true;
            this.comboBox_vKeys.Location = new System.Drawing.Point(15, 90);
            this.comboBox_vKeys.Name = "comboBox_vKeys";
            this.comboBox_vKeys.Size = new System.Drawing.Size(257, 21);
            this.comboBox_vKeys.TabIndex = 1;
            this.comboBox_vKeys.SelectedIndexChanged += new System.EventHandler(this.comboBox_vKeys_SelectedIndexChanged);
            // 
            // label_killswitch
            // 
            this.label_killswitch.AutoSize = true;
            this.label_killswitch.Location = new System.Drawing.Point(12, 10);
            this.label_killswitch.Name = "label_killswitch";
            this.label_killswitch.Size = new System.Drawing.Size(260, 52);
            this.label_killswitch.TabIndex = 0;
            this.label_killswitch.Text = "The killswitch is a safety mechanism which allows you\r\nto stop the automation scr" +
    "ipt at any time. If the\r\nredeemer is redeeming a code and you press this\r\nkey it" +
    " will stop redeeming immediately.";
            // 
            // tabPage_ParserSettings
            // 
            this.tabPage_ParserSettings.Controls.Add(this.checkBox_aggressiveParser);
            this.tabPage_ParserSettings.Controls.Add(this.label2);
            this.tabPage_ParserSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ParserSettings.Name = "tabPage_ParserSettings";
            this.tabPage_ParserSettings.Size = new System.Drawing.Size(293, 165);
            this.tabPage_ParserSettings.TabIndex = 3;
            this.tabPage_ParserSettings.Text = "Parser Settings";
            this.tabPage_ParserSettings.UseVisualStyleBackColor = true;
            // 
            // checkBox_aggressiveParser
            // 
            this.checkBox_aggressiveParser.AutoSize = true;
            this.checkBox_aggressiveParser.Location = new System.Drawing.Point(16, 135);
            this.checkBox_aggressiveParser.Name = "checkBox_aggressiveParser";
            this.checkBox_aggressiveParser.Size = new System.Drawing.Size(147, 17);
            this.checkBox_aggressiveParser.TabIndex = 1;
            this.checkBox_aggressiveParser.Text = "Enable Aggressive Parser";
            this.checkBox_aggressiveParser.UseVisualStyleBackColor = true;
            this.checkBox_aggressiveParser.CheckedChanged += new System.EventHandler(this.checkBox_aggressiveParser_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 117);
            this.label2.TabIndex = 0;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // tabPage_Whitelist
            // 
            this.tabPage_Whitelist.Controls.Add(this.groupbox_whitelistedUsernames);
            this.tabPage_Whitelist.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Whitelist.Name = "tabPage_Whitelist";
            this.tabPage_Whitelist.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Whitelist.Size = new System.Drawing.Size(293, 165);
            this.tabPage_Whitelist.TabIndex = 0;
            this.tabPage_Whitelist.Text = "Whitelist";
            this.tabPage_Whitelist.UseVisualStyleBackColor = true;
            // 
            // tabPage_Blacklist
            // 
            this.tabPage_Blacklist.Controls.Add(this.groupBox_blacklist);
            this.tabPage_Blacklist.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Blacklist.Name = "tabPage_Blacklist";
            this.tabPage_Blacklist.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Blacklist.Size = new System.Drawing.Size(293, 165);
            this.tabPage_Blacklist.TabIndex = 1;
            this.tabPage_Blacklist.Text = "Blacklist";
            this.tabPage_Blacklist.UseVisualStyleBackColor = true;
            // 
            // groupBox_blacklist
            // 
            this.groupBox_blacklist.Controls.Add(this.textbox_BlacklistedWords);
            this.groupBox_blacklist.Enabled = false;
            this.groupBox_blacklist.Location = new System.Drawing.Point(6, 7);
            this.groupBox_blacklist.Name = "groupBox_blacklist";
            this.groupBox_blacklist.Size = new System.Drawing.Size(281, 151);
            this.groupBox_blacklist.TabIndex = 12;
            this.groupBox_blacklist.TabStop = false;
            this.groupBox_blacklist.Text = "Don\'t redeem these phrases";
            // 
            // textbox_BlacklistedWords
            // 
            this.textbox_BlacklistedWords.Location = new System.Drawing.Point(6, 19);
            this.textbox_BlacklistedWords.Name = "textbox_BlacklistedWords";
            this.textbox_BlacklistedWords.Size = new System.Drawing.Size(269, 126);
            this.textbox_BlacklistedWords.TabIndex = 0;
            this.textbox_BlacklistedWords.Text = "";
            this.textbox_BlacklistedWords.TextChanged += new System.EventHandler(this.textbox_BlacklistedWords_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 486);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.checkbox_MinimiseAfterRedeeming);
            this.Controls.Add(this.label_SmiteClientVersion);
            this.Controls.Add(this.logbox);
            this.Controls.Add(this.label_ksNote);
            this.Controls.Add(this.checkbox_AFKMode);
            this.Controls.Add(this.groupbox_expiredCodes);
            this.Controls.Add(this.groupbox_activeCodes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menustrip_mainForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menustrip_mainForm;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smite Mixer Code Grabber v1.0.9";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menustrip_mainForm.ResumeLayout(false);
            this.menustrip_mainForm.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupbox_whitelistedUsernames.ResumeLayout(false);
            this.groupbox_activeCodes.ResumeLayout(false);
            this.groupbox_expiredCodes.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_killswitch.ResumeLayout(false);
            this.tabPage_killswitch.PerformLayout();
            this.tabPage_ParserSettings.ResumeLayout(false);
            this.tabPage_ParserSettings.PerformLayout();
            this.tabPage_Whitelist.ResumeLayout(false);
            this.tabPage_Blacklist.ResumeLayout(false);
            this.groupBox_blacklist.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listbox_Active;
        private System.Windows.Forms.MenuStrip menustrip_mainForm;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wikiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
        private System.Windows.Forms.ListBox listbox_Expired;
        private System.Windows.Forms.Button button_redeemSelected;
        private System.Windows.Forms.Button button_redeemAllActive;
        private System.Windows.Forms.CheckBox checkbox_showNotifications;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupbox_whitelistedUsernames;
        private System.Windows.Forms.RichTextBox textbox_whitelistedUsernames;
        private System.Windows.Forms.GroupBox groupbox_activeCodes;
        private System.Windows.Forms.GroupBox groupbox_expiredCodes;
        private System.Windows.Forms.Button button_sendTestEmail;
        private System.Windows.Forms.Timer timer_MainForm;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTestCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearActiveListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expiredToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expiredListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem expiredToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reportBugToolStripMenuItem;
        private System.Windows.Forms.Button button_CopySelectedToClipboard;
        private System.Windows.Forms.Label label_ksNote;
        public System.Windows.Forms.CheckBox checkbox_AFKMode;
        public System.Windows.Forms.RichTextBox logbox;
        private System.Windows.Forms.CheckBox checkbox_NotificationSound;
        private System.Windows.Forms.Button button_BrowseNotificationSound;
        private System.Windows.Forms.TextBox textbox_NotificationSound;
        private System.Windows.Forms.ToolStripMenuItem userGuideToolStripMenuItem;
        private System.Windows.Forms.Label label_SmiteClientVersion;
        public System.Windows.Forms.CheckBox checkbox_MinimiseAfterRedeeming;
        private System.Windows.Forms.ToolStripMenuItem webVersionToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Whitelist;
        private System.Windows.Forms.TabPage tabPage_Blacklist;
        private System.Windows.Forms.GroupBox groupBox_blacklist;
        private System.Windows.Forms.RichTextBox textbox_BlacklistedWords;
        private System.Windows.Forms.TabPage tabPage_killswitch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_vKeys;
        private System.Windows.Forms.Label label_killswitch;
        private System.Windows.Forms.CheckBox checkBox_disableKillswitch;
        private System.Windows.Forms.LinkLabel linkLabel_KeyCodes;
        private System.Windows.Forms.TabPage tabPage_ParserSettings;
        private System.Windows.Forms.CheckBox checkBox_aggressiveParser;
        private System.Windows.Forms.Label label2;
    }
}

