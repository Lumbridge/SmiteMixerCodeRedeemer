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
            this.listbox_Expired = new System.Windows.Forms.ListBox();
            this.button_redeemSelected = new System.Windows.Forms.Button();
            this.button_redeemAllActive = new System.Windows.Forms.Button();
            this.checkbox_whiteListOnly = new System.Windows.Forms.CheckBox();
            this.checkbox_showNotifications = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkbox_NotificationSound = new System.Windows.Forms.CheckBox();
            this.button_BrowseNotificationSound = new System.Windows.Forms.Button();
            this.textbox_NotificationSound = new System.Windows.Forms.TextBox();
            this.button_sendTestEmail = new System.Windows.Forms.Button();
            this.groupbox_whitelistedUsernames = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textbox_startCharacters = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numberbox_codeLength = new System.Windows.Forms.NumericUpDown();
            this.textbox_whitelistedUsernames = new System.Windows.Forms.RichTextBox();
            this.groupbox_activeCodes = new System.Windows.Forms.GroupBox();
            this.button_CopySelectedToClipboard = new System.Windows.Forms.Button();
            this.groupbox_expiredCodes = new System.Windows.Forms.GroupBox();
            this.timer_MainForm = new System.Windows.Forms.Timer(this.components);
            this.checkbox_AFKMode = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.logbox = new System.Windows.Forms.RichTextBox();
            this.label_SmiteClientVersion = new System.Windows.Forms.Label();
            this.checkbox_MinimiseAfterRedeeming = new System.Windows.Forms.CheckBox();
            this.menustrip_mainForm.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupbox_whitelistedUsernames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberbox_codeLength)).BeginInit();
            this.groupbox_activeCodes.SuspendLayout();
            this.groupbox_expiredCodes.SuspendLayout();
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
            this.debugToolStripMenuItem});
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
            this.addTestCodeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
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
            this.clearActiveListToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.clearActiveListToolStripMenuItem.Text = "Clear List";
            // 
            // activeListToolStripMenuItem
            // 
            this.activeListToolStripMenuItem.Name = "activeListToolStripMenuItem";
            this.activeListToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.activeListToolStripMenuItem.Text = "Active";
            this.activeListToolStripMenuItem.Click += new System.EventHandler(this.activeListToolStripMenuItem_Click);
            // 
            // expiredListToolStripMenuItem
            // 
            this.expiredListToolStripMenuItem.Name = "expiredListToolStripMenuItem";
            this.expiredListToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.expiredListToolStripMenuItem.Text = "Expired";
            this.expiredListToolStripMenuItem.Click += new System.EventHandler(this.expiredListToolStripMenuItem_Click);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeToolStripMenuItem,
            this.expiredToolStripMenuItem});
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
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
            // checkbox_whiteListOnly
            // 
            this.checkbox_whiteListOnly.AutoSize = true;
            this.checkbox_whiteListOnly.Location = new System.Drawing.Point(6, 19);
            this.checkbox_whiteListOnly.Name = "checkbox_whiteListOnly";
            this.checkbox_whiteListOnly.Size = new System.Drawing.Size(255, 17);
            this.checkbox_whiteListOnly.TabIndex = 3;
            this.checkbox_whiteListOnly.Text = "Only grab codes from the whitelisted users below";
            this.checkbox_whiteListOnly.UseVisualStyleBackColor = true;
            this.checkbox_whiteListOnly.CheckedChanged += new System.EventHandler(this.checkbox_whiteListOnly_CheckedChanged);
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
            this.groupbox_whitelistedUsernames.Controls.Add(this.label4);
            this.groupbox_whitelistedUsernames.Controls.Add(this.label3);
            this.groupbox_whitelistedUsernames.Controls.Add(this.textbox_startCharacters);
            this.groupbox_whitelistedUsernames.Controls.Add(this.label2);
            this.groupbox_whitelistedUsernames.Controls.Add(this.label1);
            this.groupbox_whitelistedUsernames.Controls.Add(this.numberbox_codeLength);
            this.groupbox_whitelistedUsernames.Controls.Add(this.checkbox_whiteListOnly);
            this.groupbox_whitelistedUsernames.Controls.Add(this.textbox_whitelistedUsernames);
            this.groupbox_whitelistedUsernames.Location = new System.Drawing.Point(316, 160);
            this.groupbox_whitelistedUsernames.Name = "groupbox_whitelistedUsernames";
            this.groupbox_whitelistedUsernames.Size = new System.Drawing.Size(301, 191);
            this.groupbox_whitelistedUsernames.TabIndex = 11;
            this.groupbox_whitelistedUsernames.TabStop = false;
            this.groupbox_whitelistedUsernames.Text = "Code Grab Options";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "every time.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Codes begin with";
            // 
            // textbox_startCharacters
            // 
            this.textbox_startCharacters.Location = new System.Drawing.Point(97, 136);
            this.textbox_startCharacters.Name = "textbox_startCharacters";
            this.textbox_startCharacters.Size = new System.Drawing.Size(69, 20);
            this.textbox_startCharacters.TabIndex = 7;
            this.textbox_startCharacters.TextChanged += new System.EventHandler(this.textbox_startCharacters_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "characters long.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Codes are ";
            // 
            // numberbox_codeLength
            // 
            this.numberbox_codeLength.Location = new System.Drawing.Point(97, 162);
            this.numberbox_codeLength.Name = "numberbox_codeLength";
            this.numberbox_codeLength.Size = new System.Drawing.Size(69, 20);
            this.numberbox_codeLength.TabIndex = 4;
            this.numberbox_codeLength.ValueChanged += new System.EventHandler(this.numberbox_codeLength_ValueChanged);
            // 
            // textbox_whitelistedUsernames
            // 
            this.textbox_whitelistedUsernames.Location = new System.Drawing.Point(6, 42);
            this.textbox_whitelistedUsernames.Name = "textbox_whitelistedUsernames";
            this.textbox_whitelistedUsernames.Size = new System.Drawing.Size(286, 88);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 460);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(265, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Note: Press F5 to stop automation script.";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 486);
            this.Controls.Add(this.checkbox_MinimiseAfterRedeeming);
            this.Controls.Add(this.label_SmiteClientVersion);
            this.Controls.Add(this.logbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkbox_AFKMode);
            this.Controls.Add(this.groupbox_expiredCodes);
            this.Controls.Add(this.groupbox_activeCodes);
            this.Controls.Add(this.groupbox_whitelistedUsernames);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menustrip_mainForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menustrip_mainForm;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smite Mixer Code Grabber v1.0.7.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menustrip_mainForm.ResumeLayout(false);
            this.menustrip_mainForm.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupbox_whitelistedUsernames.ResumeLayout(false);
            this.groupbox_whitelistedUsernames.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberbox_codeLength)).EndInit();
            this.groupbox_activeCodes.ResumeLayout(false);
            this.groupbox_expiredCodes.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox checkbox_whiteListOnly;
        private System.Windows.Forms.CheckBox checkbox_showNotifications;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupbox_whitelistedUsernames;
        private System.Windows.Forms.RichTextBox textbox_whitelistedUsernames;
        private System.Windows.Forms.GroupBox groupbox_activeCodes;
        private System.Windows.Forms.GroupBox groupbox_expiredCodes;
        private System.Windows.Forms.Button button_sendTestEmail;
        private System.Windows.Forms.Timer timer_MainForm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textbox_startCharacters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numberbox_codeLength;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem reportBugToolStripMenuItem;
        private System.Windows.Forms.Button button_CopySelectedToClipboard;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.CheckBox checkbox_AFKMode;
        public System.Windows.Forms.RichTextBox logbox;
        private System.Windows.Forms.CheckBox checkbox_NotificationSound;
        private System.Windows.Forms.Button button_BrowseNotificationSound;
        private System.Windows.Forms.TextBox textbox_NotificationSound;
        private System.Windows.Forms.ToolStripMenuItem userGuideToolStripMenuItem;
        private System.Windows.Forms.Label label_SmiteClientVersion;
        public System.Windows.Forms.CheckBox checkbox_MinimiseAfterRedeeming;
    }
}

