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
            this.listbox_Active = new System.Windows.Forms.ListBox();
            this.menustrip_mainForm = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listbox_Expired = new System.Windows.Forms.ListBox();
            this.button_redeemSelected = new System.Windows.Forms.Button();
            this.button_redeemAllActive = new System.Windows.Forms.Button();
            this.checkbox_whiteListOnly = new System.Windows.Forms.CheckBox();
            this.checkbox_emailNewCodes = new System.Windows.Forms.CheckBox();
            this.groupbox_Options = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button_sendTestEmail = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textbox_emailAddress = new System.Windows.Forms.TextBox();
            this.groupbox_whitelistedUsernames = new System.Windows.Forms.GroupBox();
            this.textbox_whitelistedUsernames = new System.Windows.Forms.RichTextBox();
            this.groupbox_activeCodes = new System.Windows.Forms.GroupBox();
            this.groupbox_expiredCodes = new System.Windows.Forms.GroupBox();
            this.menustrip_mainForm.SuspendLayout();
            this.groupbox_Options.SuspendLayout();
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
            // 
            // button_redeemAllActive
            // 
            this.button_redeemAllActive.Location = new System.Drawing.Point(150, 156);
            this.button_redeemAllActive.Name = "button_redeemAllActive";
            this.button_redeemAllActive.Size = new System.Drawing.Size(142, 23);
            this.button_redeemAllActive.TabIndex = 6;
            this.button_redeemAllActive.Text = "Redeem All Active Codes";
            this.button_redeemAllActive.UseVisualStyleBackColor = true;
            // 
            // checkbox_whiteListOnly
            // 
            this.checkbox_whiteListOnly.AutoSize = true;
            this.checkbox_whiteListOnly.Location = new System.Drawing.Point(6, 19);
            this.checkbox_whiteListOnly.Name = "checkbox_whiteListOnly";
            this.checkbox_whiteListOnly.Size = new System.Drawing.Size(217, 17);
            this.checkbox_whiteListOnly.TabIndex = 3;
            this.checkbox_whiteListOnly.Text = "Only Grab Codes From Whitelisted Users";
            this.checkbox_whiteListOnly.UseVisualStyleBackColor = true;
            // 
            // checkbox_emailNewCodes
            // 
            this.checkbox_emailNewCodes.AutoSize = true;
            this.checkbox_emailNewCodes.Location = new System.Drawing.Point(6, 42);
            this.checkbox_emailNewCodes.Name = "checkbox_emailNewCodes";
            this.checkbox_emailNewCodes.Size = new System.Drawing.Size(206, 17);
            this.checkbox_emailNewCodes.TabIndex = 10;
            this.checkbox_emailNewCodes.Text = "Email Me When a New Code is Active";
            this.checkbox_emailNewCodes.UseVisualStyleBackColor = true;
            // 
            // groupbox_Options
            // 
            this.groupbox_Options.Controls.Add(this.checkbox_emailNewCodes);
            this.groupbox_Options.Controls.Add(this.checkbox_whiteListOnly);
            this.groupbox_Options.Location = new System.Drawing.Point(316, 28);
            this.groupbox_Options.Name = "groupbox_Options";
            this.groupbox_Options.Size = new System.Drawing.Size(301, 76);
            this.groupbox_Options.TabIndex = 9;
            this.groupbox_Options.TabStop = false;
            this.groupbox_Options.Text = "Options";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button_sendTestEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textbox_emailAddress);
            this.groupBox1.Location = new System.Drawing.Point(316, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 105);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Email Options";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(153, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save Email Address";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button_sendTestEmail
            // 
            this.button_sendTestEmail.Location = new System.Drawing.Point(6, 62);
            this.button_sendTestEmail.Name = "button_sendTestEmail";
            this.button_sendTestEmail.Size = new System.Drawing.Size(142, 23);
            this.button_sendTestEmail.TabIndex = 2;
            this.button_sendTestEmail.Text = "Send Test Email";
            this.button_sendTestEmail.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Email Address";
            // 
            // textbox_emailAddress
            // 
            this.textbox_emailAddress.Location = new System.Drawing.Point(7, 35);
            this.textbox_emailAddress.Name = "textbox_emailAddress";
            this.textbox_emailAddress.Size = new System.Drawing.Size(288, 20);
            this.textbox_emailAddress.TabIndex = 0;
            // 
            // groupbox_whitelistedUsernames
            // 
            this.groupbox_whitelistedUsernames.Controls.Add(this.textbox_whitelistedUsernames);
            this.groupbox_whitelistedUsernames.Location = new System.Drawing.Point(316, 221);
            this.groupbox_whitelistedUsernames.Name = "groupbox_whitelistedUsernames";
            this.groupbox_whitelistedUsernames.Size = new System.Drawing.Size(301, 136);
            this.groupbox_whitelistedUsernames.TabIndex = 11;
            this.groupbox_whitelistedUsernames.TabStop = false;
            this.groupbox_whitelistedUsernames.Text = "Whitelisted Usernames";
            // 
            // textbox_whitelistedUsernames
            // 
            this.textbox_whitelistedUsernames.Location = new System.Drawing.Point(9, 20);
            this.textbox_whitelistedUsernames.Name = "textbox_whitelistedUsernames";
            this.textbox_whitelistedUsernames.Size = new System.Drawing.Size(286, 110);
            this.textbox_whitelistedUsernames.TabIndex = 0;
            this.textbox_whitelistedUsernames.Text = "Scottybot\nHiRezAuvey\nHiRezHinduman\nHiRezFinch";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 368);
            this.Controls.Add(this.groupbox_expiredCodes);
            this.Controls.Add(this.groupbox_activeCodes);
            this.Controls.Add(this.groupbox_whitelistedUsernames);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupbox_Options);
            this.Controls.Add(this.menustrip_mainForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menustrip_mainForm;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smite Mixer Code Grabber";
            this.menustrip_mainForm.ResumeLayout(false);
            this.menustrip_mainForm.PerformLayout();
            this.groupbox_Options.ResumeLayout(false);
            this.groupbox_Options.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupbox_whitelistedUsernames.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox checkbox_emailNewCodes;
        private System.Windows.Forms.GroupBox groupbox_Options;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_sendTestEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textbox_emailAddress;
        private System.Windows.Forms.GroupBox groupbox_whitelistedUsernames;
        private System.Windows.Forms.RichTextBox textbox_whitelistedUsernames;
        private System.Windows.Forms.GroupBox groupbox_activeCodes;
        private System.Windows.Forms.GroupBox groupbox_expiredCodes;
    }
}

