﻿namespace SmiteMixerCodeGrabberGUI
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
            this.groupbox_whitelistedUsernames = new System.Windows.Forms.GroupBox();
            this.textbox_whitelistedUsernames = new System.Windows.Forms.RichTextBox();
            this.groupbox_activeCodes = new System.Windows.Forms.GroupBox();
            this.button_CopySelectedToClipboard = new System.Windows.Forms.Button();
            this.groupbox_expiredCodes = new System.Windows.Forms.GroupBox();
            this.timer_MainForm = new System.Windows.Forms.Timer(this.components);
            this.logbox = new System.Windows.Forms.RichTextBox();
            this.groupBox_blacklist = new System.Windows.Forms.GroupBox();
            this.textbox_BlacklistedWords = new System.Windows.Forms.RichTextBox();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage_Active = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage_Expired = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage_Blacklist = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage_Logs = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage_Whitelist = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage_Settings = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.checkBox_disableKillswitch = new MetroFramework.Controls.MetroCheckBox();
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.comboBox_vKeys = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.checkbox_MinimiseAfterRedeeming = new MetroFramework.Controls.MetroCheckBox();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.button_sendTestEmail = new MetroFramework.Controls.MetroButton();
            this.textbox_NotificationSound = new MetroFramework.Controls.MetroTextBox();
            this.button_BrowseNotificationSound = new MetroFramework.Controls.MetroButton();
            this.checkbox_NotificationSound = new MetroFramework.Controls.MetroCheckBox();
            this.checkbox_showNotifications = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.checkbox_AFKMode = new MetroFramework.Controls.MetroToggle();
            this.metroTabPage5 = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.label_SmiteClientVersion = new MetroFramework.Controls.MetroLabel();
            this.label_ksNote = new MetroFramework.Controls.MetroLabel();
            this.menustrip_mainForm.SuspendLayout();
            this.groupbox_whitelistedUsernames.SuspendLayout();
            this.groupbox_activeCodes.SuspendLayout();
            this.groupbox_expiredCodes.SuspendLayout();
            this.groupBox_blacklist.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage_Active.SuspendLayout();
            this.metroTabPage_Expired.SuspendLayout();
            this.metroTabPage_Blacklist.SuspendLayout();
            this.metroTabPage_Logs.SuspendLayout();
            this.metroTabPage_Whitelist.SuspendLayout();
            this.metroTabPage_Settings.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listbox_Active
            // 
            this.listbox_Active.FormattingEnabled = true;
            this.listbox_Active.Location = new System.Drawing.Point(6, 19);
            this.listbox_Active.Name = "listbox_Active";
            this.listbox_Active.Size = new System.Drawing.Size(340, 134);
            this.listbox_Active.TabIndex = 0;
            // 
            // menustrip_mainForm
            // 
            this.menustrip_mainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.webVersionToolStripMenuItem});
            this.menustrip_mainForm.Location = new System.Drawing.Point(20, 60);
            this.menustrip_mainForm.Name = "menustrip_mainForm";
            this.menustrip_mainForm.Size = new System.Drawing.Size(1013, 24);
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
            this.wikiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.wikiToolStripMenuItem.Text = "Wiki";
            this.wikiToolStripMenuItem.Click += new System.EventHandler(this.wikiToolStripMenuItem_Click);
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.creditsToolStripMenuItem.Text = "Credits";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
            // 
            // reportBugToolStripMenuItem
            // 
            this.reportBugToolStripMenuItem.Name = "reportBugToolStripMenuItem";
            this.reportBugToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reportBugToolStripMenuItem.Text = "Report Bug";
            this.reportBugToolStripMenuItem.Click += new System.EventHandler(this.reportBugToolStripMenuItem_Click);
            // 
            // userGuideToolStripMenuItem
            // 
            this.userGuideToolStripMenuItem.Name = "userGuideToolStripMenuItem";
            this.userGuideToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.activeToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.activeToolStripMenuItem1.Text = "Active";
            this.activeToolStripMenuItem1.Click += new System.EventHandler(this.activeToolStripMenuItem1_Click);
            // 
            // expiredToolStripMenuItem1
            // 
            this.expiredToolStripMenuItem1.Name = "expiredToolStripMenuItem1";
            this.expiredToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
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
            this.activeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.activeToolStripMenuItem.Text = "Active";
            this.activeToolStripMenuItem.Click += new System.EventHandler(this.activeToolStripMenuItem_Click);
            // 
            // expiredToolStripMenuItem
            // 
            this.expiredToolStripMenuItem.Name = "expiredToolStripMenuItem";
            this.expiredToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.listbox_Expired.Size = new System.Drawing.Size(340, 199);
            this.listbox_Expired.TabIndex = 2;
            // 
            // button_redeemSelected
            // 
            this.button_redeemSelected.Location = new System.Drawing.Point(6, 157);
            this.button_redeemSelected.Name = "button_redeemSelected";
            this.button_redeemSelected.Size = new System.Drawing.Size(170, 23);
            this.button_redeemSelected.TabIndex = 5;
            this.button_redeemSelected.Text = "Redeem Selected Code";
            this.button_redeemSelected.UseVisualStyleBackColor = true;
            this.button_redeemSelected.Click += new System.EventHandler(this.button_redeemSelected_Click);
            // 
            // button_redeemAllActive
            // 
            this.button_redeemAllActive.Location = new System.Drawing.Point(182, 157);
            this.button_redeemAllActive.Name = "button_redeemAllActive";
            this.button_redeemAllActive.Size = new System.Drawing.Size(164, 23);
            this.button_redeemAllActive.TabIndex = 6;
            this.button_redeemAllActive.Text = "Redeem All Active Codes";
            this.button_redeemAllActive.UseVisualStyleBackColor = true;
            this.button_redeemAllActive.Click += new System.EventHandler(this.button_redeemAllActive_Click);
            // 
            // groupbox_whitelistedUsernames
            // 
            this.groupbox_whitelistedUsernames.Controls.Add(this.textbox_whitelistedUsernames);
            this.groupbox_whitelistedUsernames.Enabled = false;
            this.groupbox_whitelistedUsernames.Location = new System.Drawing.Point(3, 3);
            this.groupbox_whitelistedUsernames.Name = "groupbox_whitelistedUsernames";
            this.groupbox_whitelistedUsernames.Size = new System.Drawing.Size(473, 279);
            this.groupbox_whitelistedUsernames.TabIndex = 11;
            this.groupbox_whitelistedUsernames.TabStop = false;
            this.groupbox_whitelistedUsernames.Text = "Only get codes from these users";
            // 
            // textbox_whitelistedUsernames
            // 
            this.textbox_whitelistedUsernames.Location = new System.Drawing.Point(6, 19);
            this.textbox_whitelistedUsernames.Name = "textbox_whitelistedUsernames";
            this.textbox_whitelistedUsernames.Size = new System.Drawing.Size(461, 254);
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
            this.groupbox_activeCodes.Location = new System.Drawing.Point(9, 13);
            this.groupbox_activeCodes.Name = "groupbox_activeCodes";
            this.groupbox_activeCodes.Size = new System.Drawing.Size(352, 223);
            this.groupbox_activeCodes.TabIndex = 12;
            this.groupbox_activeCodes.TabStop = false;
            this.groupbox_activeCodes.Text = "Active Codes";
            // 
            // button_CopySelectedToClipboard
            // 
            this.button_CopySelectedToClipboard.Location = new System.Drawing.Point(6, 186);
            this.button_CopySelectedToClipboard.Name = "button_CopySelectedToClipboard";
            this.button_CopySelectedToClipboard.Size = new System.Drawing.Size(340, 30);
            this.button_CopySelectedToClipboard.TabIndex = 8;
            this.button_CopySelectedToClipboard.Text = "Copy Selected Code To Clipboard";
            this.button_CopySelectedToClipboard.UseVisualStyleBackColor = true;
            this.button_CopySelectedToClipboard.Click += new System.EventHandler(this.button_CopySelectedToClipboard_Click);
            // 
            // groupbox_expiredCodes
            // 
            this.groupbox_expiredCodes.Controls.Add(this.listbox_Expired);
            this.groupbox_expiredCodes.Location = new System.Drawing.Point(3, 4);
            this.groupbox_expiredCodes.Name = "groupbox_expiredCodes";
            this.groupbox_expiredCodes.Size = new System.Drawing.Size(352, 223);
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
            // logbox
            // 
            this.logbox.Location = new System.Drawing.Point(3, 4);
            this.logbox.Name = "logbox";
            this.logbox.ReadOnly = true;
            this.logbox.Size = new System.Drawing.Size(352, 226);
            this.logbox.TabIndex = 16;
            this.logbox.Text = "";
            this.logbox.TextChanged += new System.EventHandler(this.logbox_TextChanged);
            // 
            // groupBox_blacklist
            // 
            this.groupBox_blacklist.Controls.Add(this.textbox_BlacklistedWords);
            this.groupBox_blacklist.Enabled = false;
            this.groupBox_blacklist.Location = new System.Drawing.Point(3, 4);
            this.groupBox_blacklist.Name = "groupBox_blacklist";
            this.groupBox_blacklist.Size = new System.Drawing.Size(352, 233);
            this.groupBox_blacklist.TabIndex = 12;
            this.groupBox_blacklist.TabStop = false;
            this.groupBox_blacklist.Text = "Don\'t redeem these phrases";
            // 
            // textbox_BlacklistedWords
            // 
            this.textbox_BlacklistedWords.Location = new System.Drawing.Point(6, 19);
            this.textbox_BlacklistedWords.Name = "textbox_BlacklistedWords";
            this.textbox_BlacklistedWords.Size = new System.Drawing.Size(340, 207);
            this.textbox_BlacklistedWords.TabIndex = 0;
            this.textbox_BlacklistedWords.Text = "";
            this.textbox_BlacklistedWords.TextChanged += new System.EventHandler(this.textbox_BlacklistedWords_TextChanged);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage_Active);
            this.metroTabControl1.Controls.Add(this.metroTabPage_Expired);
            this.metroTabControl1.Controls.Add(this.metroTabPage_Blacklist);
            this.metroTabControl1.Controls.Add(this.metroTabPage_Logs);
            this.metroTabControl1.Controls.Add(this.metroTabPage_Whitelist);
            this.metroTabControl1.Controls.Add(this.metroTabPage_Settings);
            this.metroTabControl1.Location = new System.Drawing.Point(20, 96);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 2;
            this.metroTabControl1.Size = new System.Drawing.Size(730, 355);
            this.metroTabControl1.TabIndex = 20;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage_Active
            // 
            this.metroTabPage_Active.Controls.Add(this.groupbox_activeCodes);
            this.metroTabPage_Active.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Active.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Active.HorizontalScrollbarSize = 10;
            this.metroTabPage_Active.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Active.Name = "metroTabPage_Active";
            this.metroTabPage_Active.Size = new System.Drawing.Size(722, 313);
            this.metroTabPage_Active.TabIndex = 0;
            this.metroTabPage_Active.Text = "Active";
            this.metroTabPage_Active.VerticalScrollbarBarColor = true;
            this.metroTabPage_Active.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Active.VerticalScrollbarSize = 10;
            // 
            // metroTabPage_Expired
            // 
            this.metroTabPage_Expired.Controls.Add(this.groupbox_expiredCodes);
            this.metroTabPage_Expired.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Expired.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Expired.HorizontalScrollbarSize = 10;
            this.metroTabPage_Expired.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Expired.Name = "metroTabPage_Expired";
            this.metroTabPage_Expired.Size = new System.Drawing.Size(722, 313);
            this.metroTabPage_Expired.TabIndex = 1;
            this.metroTabPage_Expired.Text = "Expired";
            this.metroTabPage_Expired.VerticalScrollbarBarColor = true;
            this.metroTabPage_Expired.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Expired.VerticalScrollbarSize = 10;
            // 
            // metroTabPage_Blacklist
            // 
            this.metroTabPage_Blacklist.Controls.Add(this.groupBox_blacklist);
            this.metroTabPage_Blacklist.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Blacklist.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Blacklist.HorizontalScrollbarSize = 10;
            this.metroTabPage_Blacklist.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Blacklist.Name = "metroTabPage_Blacklist";
            this.metroTabPage_Blacklist.Size = new System.Drawing.Size(722, 313);
            this.metroTabPage_Blacklist.TabIndex = 2;
            this.metroTabPage_Blacklist.Text = "Blacklist";
            this.metroTabPage_Blacklist.VerticalScrollbarBarColor = true;
            this.metroTabPage_Blacklist.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Blacklist.VerticalScrollbarSize = 10;
            // 
            // metroTabPage_Logs
            // 
            this.metroTabPage_Logs.Controls.Add(this.logbox);
            this.metroTabPage_Logs.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Logs.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Logs.HorizontalScrollbarSize = 10;
            this.metroTabPage_Logs.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Logs.Name = "metroTabPage_Logs";
            this.metroTabPage_Logs.Size = new System.Drawing.Size(722, 313);
            this.metroTabPage_Logs.TabIndex = 0;
            this.metroTabPage_Logs.Text = "Logs";
            this.metroTabPage_Logs.VerticalScrollbarBarColor = true;
            this.metroTabPage_Logs.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Logs.VerticalScrollbarSize = 10;
            // 
            // metroTabPage_Whitelist
            // 
            this.metroTabPage_Whitelist.Controls.Add(this.groupbox_whitelistedUsernames);
            this.metroTabPage_Whitelist.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Whitelist.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Whitelist.HorizontalScrollbarSize = 10;
            this.metroTabPage_Whitelist.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Whitelist.Name = "metroTabPage_Whitelist";
            this.metroTabPage_Whitelist.Size = new System.Drawing.Size(722, 313);
            this.metroTabPage_Whitelist.TabIndex = 3;
            this.metroTabPage_Whitelist.Text = "Whitelist";
            this.metroTabPage_Whitelist.VerticalScrollbarBarColor = true;
            this.metroTabPage_Whitelist.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Whitelist.VerticalScrollbarSize = 10;
            // 
            // metroTabPage_Settings
            // 
            this.metroTabPage_Settings.Controls.Add(this.metroPanel3);
            this.metroTabPage_Settings.Controls.Add(this.metroPanel2);
            this.metroTabPage_Settings.Controls.Add(this.checkbox_MinimiseAfterRedeeming);
            this.metroTabPage_Settings.Controls.Add(this.metroPanel1);
            this.metroTabPage_Settings.Controls.Add(this.metroLabel1);
            this.metroTabPage_Settings.Controls.Add(this.checkbox_AFKMode);
            this.metroTabPage_Settings.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Settings.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Settings.HorizontalScrollbarSize = 10;
            this.metroTabPage_Settings.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Settings.Name = "metroTabPage_Settings";
            this.metroTabPage_Settings.Size = new System.Drawing.Size(722, 313);
            this.metroTabPage_Settings.TabIndex = 4;
            this.metroTabPage_Settings.Text = "Settings";
            this.metroTabPage_Settings.VerticalScrollbarBarColor = true;
            this.metroTabPage_Settings.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Settings.VerticalScrollbarSize = 10;
            // 
            // metroPanel2
            // 
            this.metroPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.checkBox_disableKillswitch);
            this.metroPanel2.Controls.Add(this.metroLink1);
            this.metroPanel2.Controls.Add(this.metroLabel3);
            this.metroPanel2.Controls.Add(this.comboBox_vKeys);
            this.metroPanel2.Controls.Add(this.metroLabel2);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(3, 132);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(340, 178);
            this.metroPanel2.TabIndex = 26;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // checkBox_disableKillswitch
            // 
            this.checkBox_disableKillswitch.AutoSize = true;
            this.checkBox_disableKillswitch.Location = new System.Drawing.Point(12, 143);
            this.checkBox_disableKillswitch.Name = "checkBox_disableKillswitch";
            this.checkBox_disableKillswitch.Size = new System.Drawing.Size(111, 15);
            this.checkBox_disableKillswitch.TabIndex = 6;
            this.checkBox_disableKillswitch.Text = "Enable Killswitch";
            this.checkBox_disableKillswitch.UseSelectable = true;
            this.checkBox_disableKillswitch.CheckedChanged += new System.EventHandler(this.checkBox_disableKillswitch_CheckedChanged);
            // 
            // metroLink1
            // 
            this.metroLink1.Location = new System.Drawing.Point(193, 82);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(93, 23);
            this.metroLink1.TabIndex = 5;
            this.metroLink1.Text = "Key Code Help";
            this.metroLink1.UseSelectable = true;
            this.metroLink1.Click += new System.EventHandler(this.metroLink1_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(12, 85);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(83, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Killswitch Key";
            // 
            // comboBox_vKeys
            // 
            this.comboBox_vKeys.FormattingEnabled = true;
            this.comboBox_vKeys.ItemHeight = 23;
            this.comboBox_vKeys.Location = new System.Drawing.Point(12, 107);
            this.comboBox_vKeys.Name = "comboBox_vKeys";
            this.comboBox_vKeys.Size = new System.Drawing.Size(274, 29);
            this.comboBox_vKeys.TabIndex = 3;
            this.comboBox_vKeys.UseSelectable = true;
            this.comboBox_vKeys.SelectedIndexChanged += new System.EventHandler(this.comboBox_vKeys_SelectedIndexChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(3, 3);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(329, 76);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "The killswitch is a safety mechanism which allows you to\r\nstop the automation scr" +
    "ipt at any time. If the redeemer\r\nis redeeming a code and you press this key it " +
    "will stop\r\nredeeming immediately.";
            // 
            // checkbox_MinimiseAfterRedeeming
            // 
            this.checkbox_MinimiseAfterRedeeming.AutoSize = true;
            this.checkbox_MinimiseAfterRedeeming.Location = new System.Drawing.Point(497, 285);
            this.checkbox_MinimiseAfterRedeeming.Name = "checkbox_MinimiseAfterRedeeming";
            this.checkbox_MinimiseAfterRedeeming.Size = new System.Drawing.Size(200, 15);
            this.checkbox_MinimiseAfterRedeeming.TabIndex = 25;
            this.checkbox_MinimiseAfterRedeeming.Text = "Minimise SMITE After Redeeming";
            this.checkbox_MinimiseAfterRedeeming.UseSelectable = true;
            this.checkbox_MinimiseAfterRedeeming.CheckedChanged += new System.EventHandler(this.checkbox_MinimiseAfterRedeeming_CheckedChanged);
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.button_sendTestEmail);
            this.metroPanel1.Controls.Add(this.textbox_NotificationSound);
            this.metroPanel1.Controls.Add(this.button_BrowseNotificationSound);
            this.metroPanel1.Controls.Add(this.checkbox_NotificationSound);
            this.metroPanel1.Controls.Add(this.checkbox_showNotifications);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(3, 22);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(340, 104);
            this.metroPanel1.TabIndex = 21;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // button_sendTestEmail
            // 
            this.button_sendTestEmail.Location = new System.Drawing.Point(4, 75);
            this.button_sendTestEmail.Name = "button_sendTestEmail";
            this.button_sendTestEmail.Size = new System.Drawing.Size(331, 23);
            this.button_sendTestEmail.TabIndex = 21;
            this.button_sendTestEmail.Text = "Send Test Notification";
            this.button_sendTestEmail.UseSelectable = true;
            this.button_sendTestEmail.Click += new System.EventHandler(this.button_sendTestEmail_Click);
            // 
            // textbox_NotificationSound
            // 
            // 
            // 
            // 
            this.textbox_NotificationSound.CustomButton.Image = null;
            this.textbox_NotificationSound.CustomButton.Location = new System.Drawing.Point(273, 1);
            this.textbox_NotificationSound.CustomButton.Name = "";
            this.textbox_NotificationSound.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textbox_NotificationSound.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textbox_NotificationSound.CustomButton.TabIndex = 1;
            this.textbox_NotificationSound.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textbox_NotificationSound.CustomButton.UseSelectable = true;
            this.textbox_NotificationSound.CustomButton.Visible = false;
            this.textbox_NotificationSound.Lines = new string[0];
            this.textbox_NotificationSound.Location = new System.Drawing.Point(4, 46);
            this.textbox_NotificationSound.MaxLength = 32767;
            this.textbox_NotificationSound.Name = "textbox_NotificationSound";
            this.textbox_NotificationSound.PasswordChar = '\0';
            this.textbox_NotificationSound.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textbox_NotificationSound.SelectedText = "";
            this.textbox_NotificationSound.SelectionLength = 0;
            this.textbox_NotificationSound.SelectionStart = 0;
            this.textbox_NotificationSound.ShortcutsEnabled = true;
            this.textbox_NotificationSound.Size = new System.Drawing.Size(295, 23);
            this.textbox_NotificationSound.TabIndex = 21;
            this.textbox_NotificationSound.UseSelectable = true;
            this.textbox_NotificationSound.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textbox_NotificationSound.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textbox_NotificationSound.TextChanged += new System.EventHandler(this.textbox_NotificationSound_TextChanged);
            // 
            // button_BrowseNotificationSound
            // 
            this.button_BrowseNotificationSound.Location = new System.Drawing.Point(305, 46);
            this.button_BrowseNotificationSound.Name = "button_BrowseNotificationSound";
            this.button_BrowseNotificationSound.Size = new System.Drawing.Size(30, 23);
            this.button_BrowseNotificationSound.TabIndex = 21;
            this.button_BrowseNotificationSound.Text = "...";
            this.button_BrowseNotificationSound.UseSelectable = true;
            this.button_BrowseNotificationSound.Click += new System.EventHandler(this.button_BrowseNotificationSound_Click);
            // 
            // checkbox_NotificationSound
            // 
            this.checkbox_NotificationSound.AutoSize = true;
            this.checkbox_NotificationSound.Location = new System.Drawing.Point(4, 28);
            this.checkbox_NotificationSound.Name = "checkbox_NotificationSound";
            this.checkbox_NotificationSound.Size = new System.Drawing.Size(230, 15);
            this.checkbox_NotificationSound.TabIndex = 27;
            this.checkbox_NotificationSound.Text = "Play a sound when a new code is active";
            this.checkbox_NotificationSound.UseSelectable = true;
            this.checkbox_NotificationSound.CheckedChanged += new System.EventHandler(this.checkbox_NotificationSound_CheckedChanged);
            // 
            // checkbox_showNotifications
            // 
            this.checkbox_showNotifications.AutoSize = true;
            this.checkbox_showNotifications.Location = new System.Drawing.Point(4, 7);
            this.checkbox_showNotifications.Name = "checkbox_showNotifications";
            this.checkbox_showNotifications.Size = new System.Drawing.Size(265, 15);
            this.checkbox_showNotifications.TabIndex = 26;
            this.checkbox_showNotifications.Text = "Show a notification when a new code is active";
            this.checkbox_showNotifications.UseSelectable = true;
            this.checkbox_showNotifications.CheckedChanged += new System.EventHandler(this.checkbox_showNotifications_CheckedChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(497, 238);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(71, 19);
            this.metroLabel1.TabIndex = 22;
            this.metroLabel1.Text = "AFK Mode";
            // 
            // checkbox_AFKMode
            // 
            this.checkbox_AFKMode.AutoSize = true;
            this.checkbox_AFKMode.Location = new System.Drawing.Point(497, 260);
            this.checkbox_AFKMode.Name = "checkbox_AFKMode";
            this.checkbox_AFKMode.Size = new System.Drawing.Size(80, 17);
            this.checkbox_AFKMode.TabIndex = 21;
            this.checkbox_AFKMode.Text = "Off";
            this.checkbox_AFKMode.UseSelectable = true;
            this.checkbox_AFKMode.CheckedChanged += new System.EventHandler(this.checkbox_AFKMode_CheckedChanged);
            // 
            // metroTabPage5
            // 
            this.metroTabPage5.HorizontalScrollbarBarColor = true;
            this.metroTabPage5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.HorizontalScrollbarSize = 10;
            this.metroTabPage5.Location = new System.Drawing.Point(0, 0);
            this.metroTabPage5.Name = "metroTabPage5";
            this.metroTabPage5.Size = new System.Drawing.Size(200, 100);
            this.metroTabPage5.TabIndex = 0;
            this.metroTabPage5.VerticalScrollbarBarColor = true;
            this.metroTabPage5.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.VerticalScrollbarSize = 10;
            // 
            // metroPanel3
            // 
            this.metroPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel3.Controls.Add(this.metroButton2);
            this.metroPanel3.Controls.Add(this.metroButton1);
            this.metroPanel3.Controls.Add(this.metroLabel4);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(349, 22);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(352, 160);
            this.metroPanel3.TabIndex = 27;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(2, 6);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(345, 95);
            this.metroLabel4.TabIndex = 2;
            this.metroLabel4.Text = resources.GetString("metroLabel4.Text");
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(8, 93);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(328, 23);
            this.metroButton1.TabIndex = 3;
            this.metroButton1.Text = "Update The Blacklist For Me Now";
            this.metroButton1.UseSelectable = true;
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(8, 122);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(328, 23);
            this.metroButton2.TabIndex = 4;
            this.metroButton2.Text = "Take Me To The Latest Blacklist";
            this.metroButton2.UseSelectable = true;
            // 
            // label_SmiteClientVersion
            // 
            this.label_SmiteClientVersion.AutoSize = true;
            this.label_SmiteClientVersion.Location = new System.Drawing.Point(20, 659);
            this.label_SmiteClientVersion.Name = "label_SmiteClientVersion";
            this.label_SmiteClientVersion.Size = new System.Drawing.Size(287, 19);
            this.label_SmiteClientVersion.TabIndex = 21;
            this.label_SmiteClientVersion.Text = "SMITE Client Not Found (Automation Disabled).";
            // 
            // label_ksNote
            // 
            this.label_ksNote.AutoSize = true;
            this.label_ksNote.Location = new System.Drawing.Point(20, 640);
            this.label_ksNote.Name = "label_ksNote";
            this.label_ksNote.Size = new System.Drawing.Size(173, 19);
            this.label_ksNote.TabIndex = 22;
            this.label_ksNote.Text = "[Killswitch Note Placeholder]";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 698);
            this.Controls.Add(this.label_ksNote);
            this.Controls.Add(this.label_SmiteClientVersion);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.menustrip_mainForm);
            this.MainMenuStrip = this.menustrip_mainForm;
            this.Name = "MainForm";
            this.Text = "Smite Mixer Code Grabber v2.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menustrip_mainForm.ResumeLayout(false);
            this.menustrip_mainForm.PerformLayout();
            this.groupbox_whitelistedUsernames.ResumeLayout(false);
            this.groupbox_activeCodes.ResumeLayout(false);
            this.groupbox_expiredCodes.ResumeLayout(false);
            this.groupBox_blacklist.ResumeLayout(false);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage_Active.ResumeLayout(false);
            this.metroTabPage_Expired.ResumeLayout(false);
            this.metroTabPage_Blacklist.ResumeLayout(false);
            this.metroTabPage_Logs.ResumeLayout(false);
            this.metroTabPage_Whitelist.ResumeLayout(false);
            this.metroTabPage_Settings.ResumeLayout(false);
            this.metroTabPage_Settings.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupbox_whitelistedUsernames;
        private System.Windows.Forms.RichTextBox textbox_whitelistedUsernames;
        private System.Windows.Forms.GroupBox groupbox_activeCodes;
        private System.Windows.Forms.GroupBox groupbox_expiredCodes;
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
        public System.Windows.Forms.RichTextBox logbox;
        private System.Windows.Forms.ToolStripMenuItem userGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webVersionToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox_blacklist;
        private System.Windows.Forms.RichTextBox textbox_BlacklistedWords;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Active;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Expired;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Blacklist;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Logs;
        private MetroFramework.Controls.MetroTabPage metroTabPage5;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Whitelist;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Settings;
        public MetroFramework.Controls.MetroToggle checkbox_AFKMode;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroCheckBox checkbox_MinimiseAfterRedeeming;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroCheckBox checkbox_NotificationSound;
        private MetroFramework.Controls.MetroCheckBox checkbox_showNotifications;
        private MetroFramework.Controls.MetroButton button_sendTestEmail;
        private MetroFramework.Controls.MetroTextBox textbox_NotificationSound;
        private MetroFramework.Controls.MetroButton button_BrowseNotificationSound;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroCheckBox checkBox_disableKillswitch;
        private MetroFramework.Controls.MetroLink metroLink1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox comboBox_vKeys;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel label_SmiteClientVersion;
        private MetroFramework.Controls.MetroLabel label_ksNote;
    }
}

