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
            this.listbox_Expired = new System.Windows.Forms.ListBox();
            this.button_redeemSelected = new System.Windows.Forms.Button();
            this.button_redeemAllActive = new System.Windows.Forms.Button();
            this.checkbox_whiteListOnly = new System.Windows.Forms.CheckBox();
            this.checkbox_showNotifications = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_sendTestEmail = new System.Windows.Forms.Button();
            this.groupbox_whitelistedUsernames = new System.Windows.Forms.GroupBox();
            this.textbox_whitelistedUsernames = new System.Windows.Forms.RichTextBox();
            this.groupbox_activeCodes = new System.Windows.Forms.GroupBox();
            this.groupbox_expiredCodes = new System.Windows.Forms.GroupBox();
            this.timer_MainForm = new System.Windows.Forms.Timer(this.components);
            this.checkbox_AFKMode = new System.Windows.Forms.CheckBox();
            this.menustrip_mainForm.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupbox_whitelistedUsernames.SuspendLayout();
            this.groupbox_activeCodes.SuspendLayout();
            this.groupbox_expiredCodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // listbox_Active
            // 
            this.listbox_Active.FormattingEnabled = true;
            this.listbox_Active.Location = new System.Drawing.Point(6, 17);
            this.listbox_Active.Name = "listbox_Active";
            this.listbox_Active.Size = new System.Drawing.Size(286, 134);
            this.listbox_Active.TabIndex = 0;
            // 
            // menustrip_mainForm
            // 
            this.menustrip_mainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menustrip_mainForm.Location = new System.Drawing.Point(0, 0);
            this.menustrip_mainForm.Name = "menustrip_mainForm";
            this.menustrip_mainForm.Size = new System.Drawing.Size(629, 24);
            this.menustrip_mainForm.TabIndex = 1;
            this.menustrip_mainForm.Text = "menustrip_mainForm";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wikiToolStripMenuItem,
            this.creditsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // wikiToolStripMenuItem
            // 
            this.wikiToolStripMenuItem.Name = "wikiToolStripMenuItem";
            this.wikiToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.wikiToolStripMenuItem.Text = "Wiki";
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.creditsToolStripMenuItem.Text = "Credits";
            // 
            // listbox_Expired
            // 
            this.listbox_Expired.FormattingEnabled = true;
            this.listbox_Expired.Location = new System.Drawing.Point(6, 19);
            this.listbox_Expired.Name = "listbox_Expired";
            this.listbox_Expired.Size = new System.Drawing.Size(286, 108);
            this.listbox_Expired.TabIndex = 2;
            // 
            // button_redeemSelected
            // 
            this.button_redeemSelected.Location = new System.Drawing.Point(6, 156);
            this.button_redeemSelected.Name = "button_redeemSelected";
            this.button_redeemSelected.Size = new System.Drawing.Size(142, 23);
            this.button_redeemSelected.TabIndex = 5;
            this.button_redeemSelected.Text = "Redeem Selected Code";
            this.button_redeemSelected.UseVisualStyleBackColor = true;
            this.button_redeemSelected.Click += new System.EventHandler(this.button_redeemSelected_Click);
            // 
            // button_redeemAllActive
            // 
            this.button_redeemAllActive.Location = new System.Drawing.Point(150, 156);
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
            this.groupBox1.Controls.Add(this.checkbox_showNotifications);
            this.groupBox1.Controls.Add(this.button_sendTestEmail);
            this.groupBox1.Location = new System.Drawing.Point(316, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 105);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notification Options";
            // 
            // button_sendTestEmail
            // 
            this.button_sendTestEmail.Location = new System.Drawing.Point(9, 42);
            this.button_sendTestEmail.Name = "button_sendTestEmail";
            this.button_sendTestEmail.Size = new System.Drawing.Size(142, 23);
            this.button_sendTestEmail.TabIndex = 2;
            this.button_sendTestEmail.Text = "Send Test Notification";
            this.button_sendTestEmail.UseVisualStyleBackColor = true;
            this.button_sendTestEmail.Click += new System.EventHandler(this.button_sendTestEmail_Click);
            // 
            // groupbox_whitelistedUsernames
            // 
            this.groupbox_whitelistedUsernames.Controls.Add(this.checkbox_whiteListOnly);
            this.groupbox_whitelistedUsernames.Controls.Add(this.textbox_whitelistedUsernames);
            this.groupbox_whitelistedUsernames.Location = new System.Drawing.Point(316, 139);
            this.groupbox_whitelistedUsernames.Name = "groupbox_whitelistedUsernames";
            this.groupbox_whitelistedUsernames.Size = new System.Drawing.Size(301, 195);
            this.groupbox_whitelistedUsernames.TabIndex = 11;
            this.groupbox_whitelistedUsernames.TabStop = false;
            this.groupbox_whitelistedUsernames.Text = "Code Grab Options";
            // 
            // textbox_whitelistedUsernames
            // 
            this.textbox_whitelistedUsernames.Location = new System.Drawing.Point(6, 42);
            this.textbox_whitelistedUsernames.Name = "textbox_whitelistedUsernames";
            this.textbox_whitelistedUsernames.Size = new System.Drawing.Size(286, 142);
            this.textbox_whitelistedUsernames.TabIndex = 0;
            this.textbox_whitelistedUsernames.Text = "";
            this.textbox_whitelistedUsernames.TextChanged += new System.EventHandler(this.textbox_whitelistedUsernames_TextChanged);
            // 
            // groupbox_activeCodes
            // 
            this.groupbox_activeCodes.Controls.Add(this.listbox_Active);
            this.groupbox_activeCodes.Controls.Add(this.button_redeemSelected);
            this.groupbox_activeCodes.Controls.Add(this.button_redeemAllActive);
            this.groupbox_activeCodes.Location = new System.Drawing.Point(12, 172);
            this.groupbox_activeCodes.Name = "groupbox_activeCodes";
            this.groupbox_activeCodes.Size = new System.Drawing.Size(298, 185);
            this.groupbox_activeCodes.TabIndex = 12;
            this.groupbox_activeCodes.TabStop = false;
            this.groupbox_activeCodes.Text = "Active Codes";
            // 
            // groupbox_expiredCodes
            // 
            this.groupbox_expiredCodes.Controls.Add(this.listbox_Expired);
            this.groupbox_expiredCodes.Location = new System.Drawing.Point(12, 28);
            this.groupbox_expiredCodes.Name = "groupbox_expiredCodes";
            this.groupbox_expiredCodes.Size = new System.Drawing.Size(298, 138);
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
            this.checkbox_AFKMode.Location = new System.Drawing.Point(507, 340);
            this.checkbox_AFKMode.Name = "checkbox_AFKMode";
            this.checkbox_AFKMode.Size = new System.Drawing.Size(110, 17);
            this.checkbox_AFKMode.TabIndex = 14;
            this.checkbox_AFKMode.Text = "Run in AFK Mode";
            this.checkbox_AFKMode.UseVisualStyleBackColor = true;
            this.checkbox_AFKMode.CheckedChanged += new System.EventHandler(this.checkbox_AFKMode_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 368);
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
            this.Text = "Smite Mixer Code Grabber";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menustrip_mainForm.ResumeLayout(false);
            this.menustrip_mainForm.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupbox_whitelistedUsernames.ResumeLayout(false);
            this.groupbox_whitelistedUsernames.PerformLayout();
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
        private System.Windows.Forms.CheckBox checkbox_AFKMode;
    }
}

