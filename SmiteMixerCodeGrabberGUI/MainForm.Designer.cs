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
            this.textbox_whitelistedUsernames = new System.Windows.Forms.RichTextBox();
            this.timer_MainForm = new System.Windows.Forms.Timer(this.components);
            this.logbox = new System.Windows.Forms.RichTextBox();
            this.textbox_BlacklistedWords = new System.Windows.Forms.RichTextBox();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage_Active = new MetroFramework.Controls.MetroTabPage();
            this.metroButton_RemoveAllActive = new MetroFramework.Controls.MetroButton();
            this.metroButton_RemoveSelectedActiveCode = new MetroFramework.Controls.MetroButton();
            this.metroButton_AddTestCode = new MetroFramework.Controls.MetroButton();
            this.button_CopySelectedToClipboard = new MetroFramework.Controls.MetroButton();
            this.button_redeemAllActive = new MetroFramework.Controls.MetroButton();
            this.button_redeemSelected = new MetroFramework.Controls.MetroButton();
            this.listView_ActiveCodes = new MetroFramework.Controls.MetroListView();
            this.col_GrabbedAt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_RedeemingAt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Redeemed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_ExpiringAt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroTabPage_Expired = new MetroFramework.Controls.MetroTabPage();
            this.listView_ExpiredCodes = new MetroFramework.Controls.MetroListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroTabPage_Blacklist = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.metroButton_GOTOBlacklistGist = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage_Logs = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage_Whitelist = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage_Settings = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox_Theme = new MetroFramework.Controls.MetroComboBox();
            this.metroPanel5 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel87 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_maxWordLength = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroTrackBar_maxWordLength = new MetroFramework.Controls.MetroTrackBar();
            this.label_minWordLength = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroTrackBar_minWordLength = new MetroFramework.Controls.MetroTrackBar();
            this.label_redeemDelay = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.trackbar_RedeemDelay = new MetroFramework.Controls.MetroTrackBar();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.comboBox_vKeys = new MetroFramework.Controls.MetroComboBox();
            this.checkBox_disableKillswitch = new MetroFramework.Controls.MetroCheckBox();
            this.metroLink_KeyCodeHelp = new MetroFramework.Controls.MetroLink();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.button_sendTestNotification = new MetroFramework.Controls.MetroButton();
            this.textbox_NotificationSound = new MetroFramework.Controls.MetroTextBox();
            this.button_BrowseNotificationSound = new MetroFramework.Controls.MetroButton();
            this.checkbox_NotificationSound = new MetroFramework.Controls.MetroCheckBox();
            this.checkbox_showNotifications = new MetroFramework.Controls.MetroCheckBox();
            this.metroTabPage_Help = new MetroFramework.Controls.MetroTabPage();
            this.metroTile_Donate = new MetroFramework.Controls.MetroTile();
            this.metroTile_ReportBug = new MetroFramework.Controls.MetroTile();
            this.metroTile_UserGuide = new MetroFramework.Controls.MetroTile();
            this.metroTile_Credits = new MetroFramework.Controls.MetroTile();
            this.metroTile_Wiki = new MetroFramework.Controls.MetroTile();
            this.metroTabPage5 = new MetroFramework.Controls.MetroTabPage();
            this.metroContextMenu_listViewRightClick = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.toolStripMenuItem_RemoveSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTestCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_ksNote = new MetroFramework.Controls.MetroLabel();
            this.label_SmiteClientVersion = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_AFKMode = new MetroFramework.Controls.MetroLabel();
            this.checkbox_AFKMode = new MetroFramework.Controls.MetroToggle();
            this.metroLabel_MinimiseSmiteAfterRedeeming = new MetroFramework.Controls.MetroLabel();
            this.checkbox_MinimiseAfterRedeeming = new MetroFramework.Controls.MetroToggle();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage_Active.SuspendLayout();
            this.metroTabPage_Expired.SuspendLayout();
            this.metroTabPage_Blacklist.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.metroTabPage_Logs.SuspendLayout();
            this.metroTabPage_Whitelist.SuspendLayout();
            this.metroTabPage_Settings.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            this.metroPanel5.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroTabPage_Help.SuspendLayout();
            this.metroContextMenu_listViewRightClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // textbox_whitelistedUsernames
            // 
            this.textbox_whitelistedUsernames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textbox_whitelistedUsernames.Location = new System.Drawing.Point(3, 3);
            this.textbox_whitelistedUsernames.Name = "textbox_whitelistedUsernames";
            this.textbox_whitelistedUsernames.Size = new System.Drawing.Size(789, 369);
            this.textbox_whitelistedUsernames.TabIndex = 0;
            this.textbox_whitelistedUsernames.Text = "";
            this.textbox_whitelistedUsernames.TextChanged += new System.EventHandler(this.textbox_whitelistedUsernames_TextChanged);
            // 
            // timer_MainForm
            // 
            this.timer_MainForm.Enabled = true;
            this.timer_MainForm.Interval = 1000;
            this.timer_MainForm.Tick += new System.EventHandler(this.timer_MainForm_Tick);
            // 
            // logbox
            // 
            this.logbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logbox.Location = new System.Drawing.Point(3, 4);
            this.logbox.Name = "logbox";
            this.logbox.ReadOnly = true;
            this.logbox.Size = new System.Drawing.Size(789, 368);
            this.logbox.TabIndex = 16;
            this.logbox.Text = "";
            this.logbox.TextChanged += new System.EventHandler(this.logbox_TextChanged);
            // 
            // textbox_BlacklistedWords
            // 
            this.textbox_BlacklistedWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textbox_BlacklistedWords.Location = new System.Drawing.Point(3, 3);
            this.textbox_BlacklistedWords.Name = "textbox_BlacklistedWords";
            this.textbox_BlacklistedWords.Size = new System.Drawing.Size(789, 266);
            this.textbox_BlacklistedWords.TabIndex = 0;
            this.textbox_BlacklistedWords.Text = "";
            this.textbox_BlacklistedWords.TextChanged += new System.EventHandler(this.textbox_BlacklistedWords_TextChanged);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabControl1.Controls.Add(this.metroTabPage_Active);
            this.metroTabControl1.Controls.Add(this.metroTabPage_Expired);
            this.metroTabControl1.Controls.Add(this.metroTabPage_Blacklist);
            this.metroTabControl1.Controls.Add(this.metroTabPage_Logs);
            this.metroTabControl1.Controls.Add(this.metroTabPage_Whitelist);
            this.metroTabControl1.Controls.Add(this.metroTabPage_Settings);
            this.metroTabControl1.Controls.Add(this.metroTabPage_Help);
            this.metroTabControl1.Location = new System.Drawing.Point(23, 63);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(804, 417);
            this.metroTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.metroTabControl1.TabIndex = 20;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage_Active
            // 
            this.metroTabPage_Active.Controls.Add(this.metroButton_RemoveAllActive);
            this.metroTabPage_Active.Controls.Add(this.metroButton_RemoveSelectedActiveCode);
            this.metroTabPage_Active.Controls.Add(this.metroButton_AddTestCode);
            this.metroTabPage_Active.Controls.Add(this.button_CopySelectedToClipboard);
            this.metroTabPage_Active.Controls.Add(this.button_redeemAllActive);
            this.metroTabPage_Active.Controls.Add(this.button_redeemSelected);
            this.metroTabPage_Active.Controls.Add(this.listView_ActiveCodes);
            this.metroTabPage_Active.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Active.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Active.HorizontalScrollbarSize = 10;
            this.metroTabPage_Active.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Active.Name = "metroTabPage_Active";
            this.metroTabPage_Active.Size = new System.Drawing.Size(796, 375);
            this.metroTabPage_Active.TabIndex = 0;
            this.metroTabPage_Active.Text = "Active";
            this.metroTabPage_Active.VerticalScrollbarBarColor = true;
            this.metroTabPage_Active.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Active.VerticalScrollbarSize = 10;
            // 
            // metroButton_RemoveAllActive
            // 
            this.metroButton_RemoveAllActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton_RemoveAllActive.Location = new System.Drawing.Point(713, 349);
            this.metroButton_RemoveAllActive.Name = "metroButton_RemoveAllActive";
            this.metroButton_RemoveAllActive.Size = new System.Drawing.Size(80, 23);
            this.metroButton_RemoveAllActive.TabIndex = 15;
            this.metroButton_RemoveAllActive.Text = "Clear Active";
            this.metroButton_RemoveAllActive.UseSelectable = true;
            this.metroButton_RemoveAllActive.Click += new System.EventHandler(this.metroButton_RemoveAllActive_Click);
            // 
            // metroButton_RemoveSelectedActiveCode
            // 
            this.metroButton_RemoveSelectedActiveCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton_RemoveSelectedActiveCode.Location = new System.Drawing.Point(578, 349);
            this.metroButton_RemoveSelectedActiveCode.Name = "metroButton_RemoveSelectedActiveCode";
            this.metroButton_RemoveSelectedActiveCode.Size = new System.Drawing.Size(129, 23);
            this.metroButton_RemoveSelectedActiveCode.TabIndex = 14;
            this.metroButton_RemoveSelectedActiveCode.Text = "Remove Selected Code";
            this.metroButton_RemoveSelectedActiveCode.UseSelectable = true;
            this.metroButton_RemoveSelectedActiveCode.Click += new System.EventHandler(this.metroButton_RemoveSelectedActiveCode_Click);
            // 
            // metroButton_AddTestCode
            // 
            this.metroButton_AddTestCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton_AddTestCode.Location = new System.Drawing.Point(486, 349);
            this.metroButton_AddTestCode.Name = "metroButton_AddTestCode";
            this.metroButton_AddTestCode.Size = new System.Drawing.Size(86, 23);
            this.metroButton_AddTestCode.TabIndex = 13;
            this.metroButton_AddTestCode.Text = "Add Test Code";
            this.metroButton_AddTestCode.UseSelectable = true;
            this.metroButton_AddTestCode.Click += new System.EventHandler(this.metroButton_AddTestCode_Click);
            // 
            // button_CopySelectedToClipboard
            // 
            this.button_CopySelectedToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_CopySelectedToClipboard.Location = new System.Drawing.Point(290, 349);
            this.button_CopySelectedToClipboard.Name = "button_CopySelectedToClipboard";
            this.button_CopySelectedToClipboard.Size = new System.Drawing.Size(129, 23);
            this.button_CopySelectedToClipboard.TabIndex = 12;
            this.button_CopySelectedToClipboard.Text = "Copy Selected Code";
            this.button_CopySelectedToClipboard.UseSelectable = true;
            this.button_CopySelectedToClipboard.Click += new System.EventHandler(this.button_CopySelectedToClipboard_Click);
            // 
            // button_redeemAllActive
            // 
            this.button_redeemAllActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_redeemAllActive.Location = new System.Drawing.Point(139, 349);
            this.button_redeemAllActive.Name = "button_redeemAllActive";
            this.button_redeemAllActive.Size = new System.Drawing.Size(145, 23);
            this.button_redeemAllActive.TabIndex = 11;
            this.button_redeemAllActive.Text = "Redeem All Active Codes";
            this.button_redeemAllActive.UseSelectable = true;
            this.button_redeemAllActive.Click += new System.EventHandler(this.button_redeemAllActive_Click);
            // 
            // button_redeemSelected
            // 
            this.button_redeemSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_redeemSelected.Location = new System.Drawing.Point(4, 349);
            this.button_redeemSelected.Name = "button_redeemSelected";
            this.button_redeemSelected.Size = new System.Drawing.Size(129, 23);
            this.button_redeemSelected.TabIndex = 10;
            this.button_redeemSelected.Text = "Redeem Selected Code";
            this.button_redeemSelected.UseSelectable = true;
            this.button_redeemSelected.Click += new System.EventHandler(this.button_redeemSelected_Click);
            // 
            // listView_ActiveCodes
            // 
            this.listView_ActiveCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_ActiveCodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_ActiveCodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_GrabbedAt,
            this.col_RedeemingAt,
            this.col_Code,
            this.col_Redeemed,
            this.col_ExpiringAt});
            this.listView_ActiveCodes.ContextMenuStrip = this.metroContextMenu_listViewRightClick;
            this.listView_ActiveCodes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.listView_ActiveCodes.FullRowSelect = true;
            this.listView_ActiveCodes.GridLines = true;
            this.listView_ActiveCodes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_ActiveCodes.Location = new System.Drawing.Point(4, 13);
            this.listView_ActiveCodes.MultiSelect = false;
            this.listView_ActiveCodes.Name = "listView_ActiveCodes";
            this.listView_ActiveCodes.OwnerDraw = true;
            this.listView_ActiveCodes.Size = new System.Drawing.Size(789, 330);
            this.listView_ActiveCodes.TabIndex = 0;
            this.listView_ActiveCodes.UseCompatibleStateImageBehavior = false;
            this.listView_ActiveCodes.UseCustomBackColor = true;
            this.listView_ActiveCodes.UseSelectable = true;
            this.listView_ActiveCodes.View = System.Windows.Forms.View.Details;
            this.listView_ActiveCodes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_ActiveCodes_MouseClick);
            // 
            // col_GrabbedAt
            // 
            this.col_GrabbedAt.Text = "Grabbed At";
            this.col_GrabbedAt.Width = 158;
            // 
            // col_RedeemingAt
            // 
            this.col_RedeemingAt.Text = "Redeeming At";
            this.col_RedeemingAt.Width = 158;
            // 
            // col_Code
            // 
            this.col_Code.Text = "Code";
            this.col_Code.Width = 158;
            // 
            // col_Redeemed
            // 
            this.col_Redeemed.Text = "Redeemed";
            this.col_Redeemed.Width = 158;
            // 
            // col_ExpiringAt
            // 
            this.col_ExpiringAt.Text = "Expiring At";
            this.col_ExpiringAt.Width = 157;
            // 
            // metroTabPage_Expired
            // 
            this.metroTabPage_Expired.Controls.Add(this.listView_ExpiredCodes);
            this.metroTabPage_Expired.Controls.Add(this.metroButton3);
            this.metroTabPage_Expired.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Expired.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Expired.HorizontalScrollbarSize = 10;
            this.metroTabPage_Expired.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Expired.Name = "metroTabPage_Expired";
            this.metroTabPage_Expired.Size = new System.Drawing.Size(796, 375);
            this.metroTabPage_Expired.TabIndex = 1;
            this.metroTabPage_Expired.Text = "Expired";
            this.metroTabPage_Expired.VerticalScrollbarBarColor = true;
            this.metroTabPage_Expired.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Expired.VerticalScrollbarSize = 10;
            // 
            // listView_ExpiredCodes
            // 
            this.listView_ExpiredCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_ExpiredCodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_ExpiredCodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView_ExpiredCodes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.listView_ExpiredCodes.FullRowSelect = true;
            this.listView_ExpiredCodes.GridLines = true;
            this.listView_ExpiredCodes.Location = new System.Drawing.Point(4, 13);
            this.listView_ExpiredCodes.MultiSelect = false;
            this.listView_ExpiredCodes.Name = "listView_ExpiredCodes";
            this.listView_ExpiredCodes.OwnerDraw = true;
            this.listView_ExpiredCodes.Size = new System.Drawing.Size(789, 330);
            this.listView_ExpiredCodes.TabIndex = 12;
            this.listView_ExpiredCodes.UseCompatibleStateImageBehavior = false;
            this.listView_ExpiredCodes.UseSelectable = true;
            this.listView_ExpiredCodes.UseStyleColors = true;
            this.listView_ExpiredCodes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Grabbed At";
            this.columnHeader1.Width = 197;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Expired At";
            this.columnHeader2.Width = 197;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Code";
            this.columnHeader3.Width = 197;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Was Redeemed";
            this.columnHeader4.Width = 196;
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroButton3.Location = new System.Drawing.Point(4, 349);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(120, 23);
            this.metroButton3.TabIndex = 11;
            this.metroButton3.Text = "Clear Expired List";
            this.metroButton3.UseSelectable = true;
            // 
            // metroTabPage_Blacklist
            // 
            this.metroTabPage_Blacklist.Controls.Add(this.metroPanel3);
            this.metroTabPage_Blacklist.Controls.Add(this.textbox_BlacklistedWords);
            this.metroTabPage_Blacklist.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Blacklist.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Blacklist.HorizontalScrollbarSize = 10;
            this.metroTabPage_Blacklist.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Blacklist.Name = "metroTabPage_Blacklist";
            this.metroTabPage_Blacklist.Size = new System.Drawing.Size(796, 375);
            this.metroTabPage_Blacklist.TabIndex = 2;
            this.metroTabPage_Blacklist.Text = "Blacklist";
            this.metroTabPage_Blacklist.VerticalScrollbarBarColor = true;
            this.metroTabPage_Blacklist.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Blacklist.VerticalScrollbarSize = 10;
            // 
            // metroPanel3
            // 
            this.metroPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel3.Controls.Add(this.metroButton_GOTOBlacklistGist);
            this.metroPanel3.Controls.Add(this.metroButton1);
            this.metroPanel3.Controls.Add(this.metroLabel4);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(3, 275);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(789, 97);
            this.metroPanel3.TabIndex = 28;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // metroButton_GOTOBlacklistGist
            // 
            this.metroButton_GOTOBlacklistGist.Location = new System.Drawing.Point(395, 58);
            this.metroButton_GOTOBlacklistGist.Name = "metroButton_GOTOBlacklistGist";
            this.metroButton_GOTOBlacklistGist.Size = new System.Drawing.Size(374, 23);
            this.metroButton_GOTOBlacklistGist.TabIndex = 4;
            this.metroButton_GOTOBlacklistGist.Text = "Take Me To The Latest Blacklist";
            this.metroButton_GOTOBlacklistGist.UseSelectable = true;
            this.metroButton_GOTOBlacklistGist.Click += new System.EventHandler(this.metroButton_GOTOBlacklistGist_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Enabled = false;
            this.metroButton1.Location = new System.Drawing.Point(15, 58);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(374, 23);
            this.metroButton1.TabIndex = 3;
            this.metroButton1.Text = "Update The Blacklist For Me Now";
            this.metroButton1.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(8, 13);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(761, 57);
            this.metroLabel4.TabIndex = 2;
            this.metroLabel4.Text = resources.GetString("metroLabel4.Text");
            // 
            // metroTabPage_Logs
            // 
            this.metroTabPage_Logs.Controls.Add(this.logbox);
            this.metroTabPage_Logs.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Logs.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Logs.HorizontalScrollbarSize = 10;
            this.metroTabPage_Logs.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Logs.Name = "metroTabPage_Logs";
            this.metroTabPage_Logs.Size = new System.Drawing.Size(796, 375);
            this.metroTabPage_Logs.TabIndex = 0;
            this.metroTabPage_Logs.Text = "Logs";
            this.metroTabPage_Logs.VerticalScrollbarBarColor = true;
            this.metroTabPage_Logs.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Logs.VerticalScrollbarSize = 10;
            // 
            // metroTabPage_Whitelist
            // 
            this.metroTabPage_Whitelist.Controls.Add(this.textbox_whitelistedUsernames);
            this.metroTabPage_Whitelist.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Whitelist.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Whitelist.HorizontalScrollbarSize = 10;
            this.metroTabPage_Whitelist.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Whitelist.Name = "metroTabPage_Whitelist";
            this.metroTabPage_Whitelist.Size = new System.Drawing.Size(796, 375);
            this.metroTabPage_Whitelist.TabIndex = 3;
            this.metroTabPage_Whitelist.Text = "Whitelist";
            this.metroTabPage_Whitelist.VerticalScrollbarBarColor = true;
            this.metroTabPage_Whitelist.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Whitelist.VerticalScrollbarSize = 10;
            // 
            // metroTabPage_Settings
            // 
            this.metroTabPage_Settings.Controls.Add(this.metroPanel4);
            this.metroTabPage_Settings.Controls.Add(this.metroPanel5);
            this.metroTabPage_Settings.Controls.Add(this.metroPanel2);
            this.metroTabPage_Settings.Controls.Add(this.metroPanel1);
            this.metroTabPage_Settings.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Settings.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Settings.HorizontalScrollbarSize = 10;
            this.metroTabPage_Settings.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Settings.Name = "metroTabPage_Settings";
            this.metroTabPage_Settings.Size = new System.Drawing.Size(796, 375);
            this.metroTabPage_Settings.TabIndex = 4;
            this.metroTabPage_Settings.Text = "Settings";
            this.metroTabPage_Settings.VerticalScrollbarBarColor = true;
            this.metroTabPage_Settings.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Settings.VerticalScrollbarSize = 10;
            // 
            // metroPanel4
            // 
            this.metroPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel4.Controls.Add(this.metroLabel10);
            this.metroPanel4.Controls.Add(this.metroComboBox_Theme);
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 10;
            this.metroPanel4.Location = new System.Drawing.Point(380, 175);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(406, 197);
            this.metroPanel4.TabIndex = 37;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(19, 17);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(49, 19);
            this.metroLabel10.TabIndex = 3;
            this.metroLabel10.Text = "Theme";
            // 
            // metroComboBox_Theme
            // 
            this.metroComboBox_Theme.FormattingEnabled = true;
            this.metroComboBox_Theme.ItemHeight = 23;
            this.metroComboBox_Theme.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this.metroComboBox_Theme.Location = new System.Drawing.Point(19, 39);
            this.metroComboBox_Theme.Name = "metroComboBox_Theme";
            this.metroComboBox_Theme.Size = new System.Drawing.Size(139, 29);
            this.metroComboBox_Theme.TabIndex = 2;
            this.metroComboBox_Theme.UseSelectable = true;
            this.metroComboBox_Theme.SelectedIndexChanged += new System.EventHandler(this.metroComboBox_Theme_SelectedIndexChanged);
            // 
            // metroPanel5
            // 
            this.metroPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel5.Controls.Add(this.metroLabel87);
            this.metroPanel5.Controls.Add(this.metroLabel_maxWordLength);
            this.metroPanel5.Controls.Add(this.metroLabel9);
            this.metroPanel5.Controls.Add(this.metroTrackBar_maxWordLength);
            this.metroPanel5.Controls.Add(this.label_minWordLength);
            this.metroPanel5.Controls.Add(this.metroLabel7);
            this.metroPanel5.Controls.Add(this.metroTrackBar_minWordLength);
            this.metroPanel5.Controls.Add(this.label_redeemDelay);
            this.metroPanel5.Controls.Add(this.metroLabel5);
            this.metroPanel5.Controls.Add(this.trackbar_RedeemDelay);
            this.metroPanel5.HorizontalScrollbarBarColor = true;
            this.metroPanel5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel5.HorizontalScrollbarSize = 10;
            this.metroPanel5.Location = new System.Drawing.Point(4, 124);
            this.metroPanel5.Name = "metroPanel5";
            this.metroPanel5.Size = new System.Drawing.Size(340, 248);
            this.metroPanel5.TabIndex = 29;
            this.metroPanel5.VerticalScrollbarBarColor = true;
            this.metroPanel5.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel5.VerticalScrollbarSize = 10;
            // 
            // metroLabel87
            // 
            this.metroLabel87.AutoSize = true;
            this.metroLabel87.Location = new System.Drawing.Point(8, 201);
            this.metroLabel87.Name = "metroLabel87";
            this.metroLabel87.Size = new System.Drawing.Size(321, 38);
            this.metroLabel87.TabIndex = 36;
            this.metroLabel87.Text = "Note: The longest code to date was 17 characters and\r\nthe shortest was 8 characte" +
    "rs.";
            // 
            // metroLabel_maxWordLength
            // 
            this.metroLabel_maxWordLength.AutoSize = true;
            this.metroLabel_maxWordLength.Location = new System.Drawing.Point(231, 179);
            this.metroLabel_maxWordLength.Name = "metroLabel_maxWordLength";
            this.metroLabel_maxWordLength.Size = new System.Drawing.Size(92, 19);
            this.metroLabel_maxWordLength.TabIndex = 35;
            this.metroLabel_maxWordLength.Text = "{x} Characters.";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(8, 131);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(196, 19);
            this.metroLabel9.TabIndex = 34;
            this.metroLabel9.Text = "Only pick up words shorter than";
            // 
            // metroTrackBar_maxWordLength
            // 
            this.metroTrackBar_maxWordLength.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar_maxWordLength.Location = new System.Drawing.Point(10, 153);
            this.metroTrackBar_maxWordLength.Maximum = 30;
            this.metroTrackBar_maxWordLength.Minimum = 10;
            this.metroTrackBar_maxWordLength.MouseWheelBarPartitions = 1;
            this.metroTrackBar_maxWordLength.Name = "metroTrackBar_maxWordLength";
            this.metroTrackBar_maxWordLength.Size = new System.Drawing.Size(310, 23);
            this.metroTrackBar_maxWordLength.TabIndex = 33;
            this.metroTrackBar_maxWordLength.Text = "metroTrackBar1";
            this.metroTrackBar_maxWordLength.Value = 17;
            this.metroTrackBar_maxWordLength.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroTrackBar_maxWordLength_Scroll);
            this.metroTrackBar_maxWordLength.MouseUp += new System.Windows.Forms.MouseEventHandler(this.metroTrackBar_maxWordLength_MouseUp);
            // 
            // label_minWordLength
            // 
            this.label_minWordLength.AutoSize = true;
            this.label_minWordLength.Location = new System.Drawing.Point(231, 116);
            this.label_minWordLength.Name = "label_minWordLength";
            this.label_minWordLength.Size = new System.Drawing.Size(92, 19);
            this.label_minWordLength.TabIndex = 32;
            this.label_minWordLength.Text = "{x} Characters.";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(8, 68);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(192, 19);
            this.metroLabel7.TabIndex = 31;
            this.metroLabel7.Text = "Only pick up words longer than";
            // 
            // metroTrackBar_minWordLength
            // 
            this.metroTrackBar_minWordLength.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar_minWordLength.Location = new System.Drawing.Point(10, 90);
            this.metroTrackBar_minWordLength.Maximum = 20;
            this.metroTrackBar_minWordLength.MouseWheelBarPartitions = 1;
            this.metroTrackBar_minWordLength.Name = "metroTrackBar_minWordLength";
            this.metroTrackBar_minWordLength.Size = new System.Drawing.Size(310, 23);
            this.metroTrackBar_minWordLength.TabIndex = 30;
            this.metroTrackBar_minWordLength.Text = "metroTrackBar_wordLength";
            this.metroTrackBar_minWordLength.Value = 5;
            this.metroTrackBar_minWordLength.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroTrackBar_wordLength_Scroll);
            this.metroTrackBar_minWordLength.MouseUp += new System.Windows.Forms.MouseEventHandler(this.metroTrackBar_wordLength_MouseUp);
            // 
            // label_redeemDelay
            // 
            this.label_redeemDelay.AutoSize = true;
            this.label_redeemDelay.Location = new System.Drawing.Point(248, 55);
            this.label_redeemDelay.Name = "label_redeemDelay";
            this.label_redeemDelay.Size = new System.Drawing.Size(75, 19);
            this.label_redeemDelay.TabIndex = 4;
            this.label_redeemDelay.Text = "{x} Minutes.";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(8, 7);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(171, 19);
            this.metroLabel5.TabIndex = 3;
            this.metroLabel5.Text = "Delay Code Redemption by";
            // 
            // trackbar_RedeemDelay
            // 
            this.trackbar_RedeemDelay.BackColor = System.Drawing.Color.Transparent;
            this.trackbar_RedeemDelay.Location = new System.Drawing.Point(10, 29);
            this.trackbar_RedeemDelay.Maximum = 20;
            this.trackbar_RedeemDelay.MouseWheelBarPartitions = 1;
            this.trackbar_RedeemDelay.Name = "trackbar_RedeemDelay";
            this.trackbar_RedeemDelay.Size = new System.Drawing.Size(310, 23);
            this.trackbar_RedeemDelay.TabIndex = 2;
            this.trackbar_RedeemDelay.Text = "Delay Code Redemption";
            this.trackbar_RedeemDelay.Value = 5;
            this.trackbar_RedeemDelay.Scroll += new System.Windows.Forms.ScrollEventHandler(this.trackbar_RedeemDelay_Scroll);
            // 
            // metroPanel2
            // 
            this.metroPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.comboBox_vKeys);
            this.metroPanel2.Controls.Add(this.checkBox_disableKillswitch);
            this.metroPanel2.Controls.Add(this.metroLink_KeyCodeHelp);
            this.metroPanel2.Controls.Add(this.metroLabel3);
            this.metroPanel2.Controls.Add(this.metroLabel2);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(380, 14);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(413, 155);
            this.metroPanel2.TabIndex = 26;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // comboBox_vKeys
            // 
            this.comboBox_vKeys.FormattingEnabled = true;
            this.comboBox_vKeys.ItemHeight = 23;
            this.comboBox_vKeys.Location = new System.Drawing.Point(19, 94);
            this.comboBox_vKeys.Name = "comboBox_vKeys";
            this.comboBox_vKeys.Size = new System.Drawing.Size(371, 29);
            this.comboBox_vKeys.TabIndex = 3;
            this.comboBox_vKeys.UseSelectable = true;
            this.comboBox_vKeys.SelectedIndexChanged += new System.EventHandler(this.comboBox_vKeys_SelectedIndexChanged);
            // 
            // checkBox_disableKillswitch
            // 
            this.checkBox_disableKillswitch.AutoSize = true;
            this.checkBox_disableKillswitch.Location = new System.Drawing.Point(279, 129);
            this.checkBox_disableKillswitch.Name = "checkBox_disableKillswitch";
            this.checkBox_disableKillswitch.Size = new System.Drawing.Size(111, 15);
            this.checkBox_disableKillswitch.TabIndex = 6;
            this.checkBox_disableKillswitch.Text = "Enable Killswitch";
            this.checkBox_disableKillswitch.UseSelectable = true;
            this.checkBox_disableKillswitch.CheckedChanged += new System.EventHandler(this.checkBox_disableKillswitch_CheckedChanged);
            // 
            // metroLink_KeyCodeHelp
            // 
            this.metroLink_KeyCodeHelp.Location = new System.Drawing.Point(297, 72);
            this.metroLink_KeyCodeHelp.Name = "metroLink_KeyCodeHelp";
            this.metroLink_KeyCodeHelp.Size = new System.Drawing.Size(93, 23);
            this.metroLink_KeyCodeHelp.TabIndex = 5;
            this.metroLink_KeyCodeHelp.Text = "Key Code Help";
            this.metroLink_KeyCodeHelp.UseSelectable = true;
            this.metroLink_KeyCodeHelp.Click += new System.EventHandler(this.metroLink_KeyCodeHelp_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(19, 72);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(83, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Killswitch Key";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(3, 7);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(402, 57);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "The killswitch is a safety mechanism which allows you to stop the\r\nautomation scr" +
    "ipt at any time. If the redeemer is redeeming a code\r\nand you press this key it " +
    "will stop redeeming immediately.";
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.button_sendTestNotification);
            this.metroPanel1.Controls.Add(this.textbox_NotificationSound);
            this.metroPanel1.Controls.Add(this.button_BrowseNotificationSound);
            this.metroPanel1.Controls.Add(this.checkbox_NotificationSound);
            this.metroPanel1.Controls.Add(this.checkbox_showNotifications);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(4, 14);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(340, 104);
            this.metroPanel1.TabIndex = 21;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // button_sendTestNotification
            // 
            this.button_sendTestNotification.Location = new System.Drawing.Point(4, 75);
            this.button_sendTestNotification.Name = "button_sendTestNotification";
            this.button_sendTestNotification.Size = new System.Drawing.Size(331, 23);
            this.button_sendTestNotification.TabIndex = 21;
            this.button_sendTestNotification.Text = "Send Test Notification";
            this.button_sendTestNotification.UseSelectable = true;
            this.button_sendTestNotification.Click += new System.EventHandler(this.button_sendTestNotification_Click);
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
            // metroTabPage_Help
            // 
            this.metroTabPage_Help.Controls.Add(this.metroTile_Donate);
            this.metroTabPage_Help.Controls.Add(this.metroTile_ReportBug);
            this.metroTabPage_Help.Controls.Add(this.metroTile_UserGuide);
            this.metroTabPage_Help.Controls.Add(this.metroTile_Credits);
            this.metroTabPage_Help.Controls.Add(this.metroTile_Wiki);
            this.metroTabPage_Help.HorizontalScrollbarBarColor = true;
            this.metroTabPage_Help.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Help.HorizontalScrollbarSize = 10;
            this.metroTabPage_Help.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage_Help.Name = "metroTabPage_Help";
            this.metroTabPage_Help.Size = new System.Drawing.Size(796, 375);
            this.metroTabPage_Help.TabIndex = 5;
            this.metroTabPage_Help.Text = "Help";
            this.metroTabPage_Help.VerticalScrollbarBarColor = true;
            this.metroTabPage_Help.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage_Help.VerticalScrollbarSize = 10;
            // 
            // metroTile_Donate
            // 
            this.metroTile_Donate.ActiveControl = null;
            this.metroTile_Donate.Location = new System.Drawing.Point(583, 3);
            this.metroTile_Donate.Name = "metroTile_Donate";
            this.metroTile_Donate.Size = new System.Drawing.Size(139, 65);
            this.metroTile_Donate.TabIndex = 6;
            this.metroTile_Donate.Text = "Donate";
            this.metroTile_Donate.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile_Donate.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTile_Donate.UseSelectable = true;
            this.metroTile_Donate.UseStyleColors = true;
            this.metroTile_Donate.Click += new System.EventHandler(this.metroTile_Donate_Click);
            // 
            // metroTile_ReportBug
            // 
            this.metroTile_ReportBug.ActiveControl = null;
            this.metroTile_ReportBug.Location = new System.Drawing.Point(293, 3);
            this.metroTile_ReportBug.Name = "metroTile_ReportBug";
            this.metroTile_ReportBug.Size = new System.Drawing.Size(139, 65);
            this.metroTile_ReportBug.TabIndex = 5;
            this.metroTile_ReportBug.Text = "Report Bug";
            this.metroTile_ReportBug.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile_ReportBug.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTile_ReportBug.UseSelectable = true;
            this.metroTile_ReportBug.UseStyleColors = true;
            this.metroTile_ReportBug.Click += new System.EventHandler(this.metroTile_ReportBug_Click);
            // 
            // metroTile_UserGuide
            // 
            this.metroTile_UserGuide.ActiveControl = null;
            this.metroTile_UserGuide.Location = new System.Drawing.Point(438, 3);
            this.metroTile_UserGuide.Name = "metroTile_UserGuide";
            this.metroTile_UserGuide.Size = new System.Drawing.Size(139, 65);
            this.metroTile_UserGuide.TabIndex = 4;
            this.metroTile_UserGuide.Text = "User Guide";
            this.metroTile_UserGuide.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile_UserGuide.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTile_UserGuide.UseSelectable = true;
            this.metroTile_UserGuide.UseStyleColors = true;
            this.metroTile_UserGuide.Click += new System.EventHandler(this.metroTile_UserGuide_Click);
            // 
            // metroTile_Credits
            // 
            this.metroTile_Credits.ActiveControl = null;
            this.metroTile_Credits.Location = new System.Drawing.Point(148, 3);
            this.metroTile_Credits.Name = "metroTile_Credits";
            this.metroTile_Credits.Size = new System.Drawing.Size(139, 65);
            this.metroTile_Credits.TabIndex = 3;
            this.metroTile_Credits.Text = "Credits";
            this.metroTile_Credits.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile_Credits.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTile_Credits.UseSelectable = true;
            this.metroTile_Credits.UseStyleColors = true;
            this.metroTile_Credits.Click += new System.EventHandler(this.metroTile_Credits_Click);
            // 
            // metroTile_Wiki
            // 
            this.metroTile_Wiki.ActiveControl = null;
            this.metroTile_Wiki.Location = new System.Drawing.Point(3, 3);
            this.metroTile_Wiki.Name = "metroTile_Wiki";
            this.metroTile_Wiki.Size = new System.Drawing.Size(139, 65);
            this.metroTile_Wiki.TabIndex = 2;
            this.metroTile_Wiki.Text = "Wiki";
            this.metroTile_Wiki.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile_Wiki.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTile_Wiki.UseSelectable = true;
            this.metroTile_Wiki.UseStyleColors = true;
            this.metroTile_Wiki.Click += new System.EventHandler(this.metroTile_Wiki_Click);
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
            // metroContextMenu_listViewRightClick
            // 
            this.metroContextMenu_listViewRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_RemoveSelected,
            this.copySelectedToolStripMenuItem,
            this.addTestCodeToolStripMenuItem});
            this.metroContextMenu_listViewRightClick.Name = "metroContextMenu_listViewRightClick";
            this.metroContextMenu_listViewRightClick.Size = new System.Drawing.Size(183, 92);
            this.metroContextMenu_listViewRightClick.Opening += new System.ComponentModel.CancelEventHandler(this.metroContextMenu_listViewRightClick_Opening);
            // 
            // toolStripMenuItem_RemoveSelected
            // 
            this.toolStripMenuItem_RemoveSelected.Name = "toolStripMenuItem_RemoveSelected";
            this.toolStripMenuItem_RemoveSelected.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem_RemoveSelected.Text = "Remove from Active";
            this.toolStripMenuItem_RemoveSelected.Click += new System.EventHandler(this.toolStripMenuItem_RemoveSelected_Click);
            // 
            // copySelectedToolStripMenuItem
            // 
            this.copySelectedToolStripMenuItem.Name = "copySelectedToolStripMenuItem";
            this.copySelectedToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.copySelectedToolStripMenuItem.Text = "Copy Selected";
            this.copySelectedToolStripMenuItem.Click += new System.EventHandler(this.copySelectedToolStripMenuItem_Click);
            // 
            // addTestCodeToolStripMenuItem
            // 
            this.addTestCodeToolStripMenuItem.Name = "addTestCodeToolStripMenuItem";
            this.addTestCodeToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.addTestCodeToolStripMenuItem.Text = "Add Test Code";
            this.addTestCodeToolStripMenuItem.Click += new System.EventHandler(this.addTestCodeToolStripMenuItem_Click);
            // 
            // label_ksNote
            // 
            this.label_ksNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ksNote.AutoSize = true;
            this.label_ksNote.Location = new System.Drawing.Point(31, 489);
            this.label_ksNote.Name = "label_ksNote";
            this.label_ksNote.Size = new System.Drawing.Size(173, 19);
            this.label_ksNote.TabIndex = 28;
            this.label_ksNote.Text = "[Killswitch Note Placeholder]";
            // 
            // label_SmiteClientVersion
            // 
            this.label_SmiteClientVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_SmiteClientVersion.AutoSize = true;
            this.label_SmiteClientVersion.Location = new System.Drawing.Point(31, 517);
            this.label_SmiteClientVersion.Name = "label_SmiteClientVersion";
            this.label_SmiteClientVersion.Size = new System.Drawing.Size(287, 19);
            this.label_SmiteClientVersion.TabIndex = 26;
            this.label_SmiteClientVersion.Text = "SMITE Client Not Found (Automation Disabled).";
            // 
            // metroLabel_AFKMode
            // 
            this.metroLabel_AFKMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel_AFKMode.AutoSize = true;
            this.metroLabel_AFKMode.Location = new System.Drawing.Point(663, 489);
            this.metroLabel_AFKMode.Name = "metroLabel_AFKMode";
            this.metroLabel_AFKMode.Size = new System.Drawing.Size(71, 19);
            this.metroLabel_AFKMode.TabIndex = 29;
            this.metroLabel_AFKMode.Text = "AFK Mode";
            // 
            // checkbox_AFKMode
            // 
            this.checkbox_AFKMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkbox_AFKMode.AutoSize = true;
            this.checkbox_AFKMode.Location = new System.Drawing.Point(740, 491);
            this.checkbox_AFKMode.Name = "checkbox_AFKMode";
            this.checkbox_AFKMode.Size = new System.Drawing.Size(80, 17);
            this.checkbox_AFKMode.TabIndex = 27;
            this.checkbox_AFKMode.Text = "Off";
            this.checkbox_AFKMode.UseSelectable = true;
            this.checkbox_AFKMode.CheckedChanged += new System.EventHandler(this.checkbox_AFKMode_CheckedChanged);
            // 
            // metroLabel_MinimiseSmiteAfterRedeeming
            // 
            this.metroLabel_MinimiseSmiteAfterRedeeming.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel_MinimiseSmiteAfterRedeeming.AutoSize = true;
            this.metroLabel_MinimiseSmiteAfterRedeeming.Location = new System.Drawing.Point(536, 514);
            this.metroLabel_MinimiseSmiteAfterRedeeming.Name = "metroLabel_MinimiseSmiteAfterRedeeming";
            this.metroLabel_MinimiseSmiteAfterRedeeming.Size = new System.Drawing.Size(203, 19);
            this.metroLabel_MinimiseSmiteAfterRedeeming.TabIndex = 32;
            this.metroLabel_MinimiseSmiteAfterRedeeming.Text = "Minimise SMITE after Redeeming";
            // 
            // checkbox_MinimiseAfterRedeeming
            // 
            this.checkbox_MinimiseAfterRedeeming.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkbox_MinimiseAfterRedeeming.AutoSize = true;
            this.checkbox_MinimiseAfterRedeeming.Location = new System.Drawing.Point(740, 516);
            this.checkbox_MinimiseAfterRedeeming.Name = "checkbox_MinimiseAfterRedeeming";
            this.checkbox_MinimiseAfterRedeeming.Size = new System.Drawing.Size(80, 17);
            this.checkbox_MinimiseAfterRedeeming.TabIndex = 31;
            this.checkbox_MinimiseAfterRedeeming.Text = "Off";
            this.checkbox_MinimiseAfterRedeeming.UseSelectable = true;
            this.checkbox_MinimiseAfterRedeeming.CheckedChanged += new System.EventHandler(this.checkbox_MinimiseAfterRedeeming_CheckedChanged);
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 556);
            this.Controls.Add(this.metroLabel_MinimiseSmiteAfterRedeeming);
            this.Controls.Add(this.checkbox_MinimiseAfterRedeeming);
            this.Controls.Add(this.label_ksNote);
            this.Controls.Add(this.label_SmiteClientVersion);
            this.Controls.Add(this.metroLabel_AFKMode);
            this.Controls.Add(this.checkbox_AFKMode);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "MainForm";
            this.Text = "Smite Mixer Code Grabber v2.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage_Active.ResumeLayout(false);
            this.metroTabPage_Expired.ResumeLayout(false);
            this.metroTabPage_Blacklist.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.metroTabPage_Logs.ResumeLayout(false);
            this.metroTabPage_Whitelist.ResumeLayout(false);
            this.metroTabPage_Settings.ResumeLayout(false);
            this.metroPanel4.ResumeLayout(false);
            this.metroPanel4.PerformLayout();
            this.metroPanel5.ResumeLayout(false);
            this.metroPanel5.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroTabPage_Help.ResumeLayout(false);
            this.metroContextMenu_listViewRightClick.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox textbox_whitelistedUsernames;
        private System.Windows.Forms.Timer timer_MainForm;
        public System.Windows.Forms.RichTextBox logbox;
        private System.Windows.Forms.RichTextBox textbox_BlacklistedWords;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Active;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Expired;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Blacklist;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Logs;
        private MetroFramework.Controls.MetroTabPage metroTabPage5;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Whitelist;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Settings;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroCheckBox checkbox_NotificationSound;
        private MetroFramework.Controls.MetroCheckBox checkbox_showNotifications;
        private MetroFramework.Controls.MetroButton button_sendTestNotification;
        private MetroFramework.Controls.MetroTextBox textbox_NotificationSound;
        private MetroFramework.Controls.MetroButton button_BrowseNotificationSound;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroCheckBox checkBox_disableKillswitch;
        private MetroFramework.Controls.MetroLink metroLink_KeyCodeHelp;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox comboBox_vKeys;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroListView listView_ActiveCodes;
        private System.Windows.Forms.ColumnHeader col_GrabbedAt;
        private System.Windows.Forms.ColumnHeader col_RedeemingAt;
        private System.Windows.Forms.ColumnHeader col_Code;
        private System.Windows.Forms.ColumnHeader col_Redeemed;
        private MetroFramework.Controls.MetroButton button_CopySelectedToClipboard;
        private MetroFramework.Controls.MetroButton button_redeemAllActive;
        private MetroFramework.Controls.MetroButton button_redeemSelected;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroButton metroButton_GOTOBlacklistGist;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu_listViewRightClick;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RemoveSelected;
        private MetroFramework.Controls.MetroTabPage metroTabPage_Help;
        private MetroFramework.Controls.MetroTile metroTile_ReportBug;
        private MetroFramework.Controls.MetroTile metroTile_UserGuide;
        private MetroFramework.Controls.MetroTile metroTile_Credits;
        private MetroFramework.Controls.MetroTile metroTile_Wiki;
        private MetroFramework.Controls.MetroButton metroButton_RemoveSelectedActiveCode;
        private MetroFramework.Controls.MetroButton metroButton_AddTestCode;
        private MetroFramework.Controls.MetroListView listView_ExpiredCodes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroLabel label_ksNote;
        private MetroFramework.Controls.MetroLabel label_SmiteClientVersion;
        private MetroFramework.Controls.MetroLabel metroLabel_AFKMode;
        public MetroFramework.Controls.MetroToggle checkbox_AFKMode;
        private MetroFramework.Controls.MetroLabel metroLabel_MinimiseSmiteAfterRedeeming;
        public MetroFramework.Controls.MetroToggle checkbox_MinimiseAfterRedeeming;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTestCodeToolStripMenuItem;
        private MetroFramework.Controls.MetroButton metroButton_RemoveAllActive;
        private System.Windows.Forms.ColumnHeader col_ExpiringAt;
        private MetroFramework.Controls.MetroTile metroTile_Donate;
        private MetroFramework.Controls.MetroPanel metroPanel5;
        private MetroFramework.Controls.MetroLabel label_redeemDelay;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTrackBar trackbar_RedeemDelay;
        private MetroFramework.Controls.MetroLabel label_minWordLength;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar_minWordLength;
        private MetroFramework.Controls.MetroLabel metroLabel87;
        private MetroFramework.Controls.MetroLabel metroLabel_maxWordLength;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar_maxWordLength;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroComboBox metroComboBox_Theme;
    }
}

