namespace SimpleMMO_Bot
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
            this.txtbEmail = new System.Windows.Forms.TextBox();
            this.txtbPassword = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.gbAccount = new System.Windows.Forms.GroupBox();
            this.lblEnergy = new System.Windows.Forms.Label();
            this.lblHealth = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.lblSteps = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTravel = new System.Windows.Forms.Button();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.gbLogin.SuspendLayout();
            this.gbAccount.SuspendLayout();
            this.gbActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbEmail
            // 
            this.txtbEmail.Location = new System.Drawing.Point(6, 50);
            this.txtbEmail.Name = "txtbEmail";
            this.txtbEmail.Size = new System.Drawing.Size(195, 22);
            this.txtbEmail.TabIndex = 0;
            this.txtbEmail.Text = "";
            // 
            // txtbPassword
            // 
            this.txtbPassword.Location = new System.Drawing.Point(6, 95);
            this.txtbPassword.Name = "txtbPassword";
            this.txtbPassword.PasswordChar = '*';
            this.txtbPassword.Size = new System.Drawing.Size(195, 22);
            this.txtbPassword.TabIndex = 1;
            this.txtbPassword.Text = "";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(3, 30);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 17);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(3, 75);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 17);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            // 
            // btnLogin
            // 
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogin.Location = new System.Drawing.Point(3, 127);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(201, 27);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.lblEmail);
            this.gbLogin.Controls.Add(this.btnLogin);
            this.gbLogin.Controls.Add(this.txtbEmail);
            this.gbLogin.Controls.Add(this.lblPassword);
            this.gbLogin.Controls.Add(this.txtbPassword);
            this.gbLogin.Location = new System.Drawing.Point(12, 12);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(207, 157);
            this.gbLogin.TabIndex = 5;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Login";
            // 
            // gbAccount
            // 
            this.gbAccount.Controls.Add(this.lblEnergy);
            this.gbAccount.Controls.Add(this.lblHealth);
            this.gbAccount.Controls.Add(this.lblExperience);
            this.gbAccount.Controls.Add(this.lblSteps);
            this.gbAccount.Controls.Add(this.lblGold);
            this.gbAccount.Controls.Add(this.lblLevel);
            this.gbAccount.Controls.Add(this.lblUsername);
            this.gbAccount.Location = new System.Drawing.Point(225, 12);
            this.gbAccount.Name = "gbAccount";
            this.gbAccount.Size = new System.Drawing.Size(198, 157);
            this.gbAccount.TabIndex = 6;
            this.gbAccount.TabStop = false;
            this.gbAccount.Text = "Account";
            // 
            // lblEnergy
            // 
            this.lblEnergy.AutoSize = true;
            this.lblEnergy.Location = new System.Drawing.Point(6, 133);
            this.lblEnergy.Name = "lblEnergy";
            this.lblEnergy.Size = new System.Drawing.Size(89, 17);
            this.lblEnergy.TabIndex = 6;
            this.lblEnergy.Text = "Energy: 0 / 0";
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.Location = new System.Drawing.Point(6, 116);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(63, 17);
            this.lblHealth.TabIndex = 5;
            this.lblHealth.Text = "HP: 0 / 0";
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Location = new System.Drawing.Point(6, 99);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(71, 17);
            this.lblExperience.TabIndex = 4;
            this.lblExperience.Text = "EXP: 0 / 0";
            // 
            // lblSteps
            // 
            this.lblSteps.AutoSize = true;
            this.lblSteps.Location = new System.Drawing.Point(6, 82);
            this.lblSteps.Name = "lblSteps";
            this.lblSteps.Size = new System.Drawing.Size(60, 17);
            this.lblSteps.TabIndex = 3;
            this.lblSteps.Text = "Steps: 0";
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(6, 65);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(54, 17);
            this.lblGold.TabIndex = 2;
            this.lblGold.Text = "Gold: 0";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(6, 48);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(58, 17);
            this.lblLevel.TabIndex = 1;
            this.lblLevel.Text = "Level: 0";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(6, 30);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(165, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username: Not logged in";
            // 
            // gbActions
            // 
            this.gbActions.Controls.Add(this.rtbLog);
            this.gbActions.Controls.Add(this.button1);
            this.gbActions.Controls.Add(this.btnTravel);
            this.gbActions.Enabled = false;
            this.gbActions.Location = new System.Drawing.Point(12, 172);
            this.gbActions.Name = "gbActions";
            this.gbActions.Padding = new System.Windows.Forms.Padding(7);
            this.gbActions.Size = new System.Drawing.Size(411, 182);
            this.gbActions.TabIndex = 7;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "Actions";
            // 
            // rtbLog
            // 
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbLog.Location = new System.Drawing.Point(7, 54);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(397, 121);
            this.rtbLog.TabIndex = 2;
            this.rtbLog.Text = "";
            this.rtbLog.TextChanged += new System.EventHandler(this.RtbLog_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "Test something";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnTravel
            // 
            this.btnTravel.Location = new System.Drawing.Point(7, 21);
            this.btnTravel.Name = "btnTravel";
            this.btnTravel.Size = new System.Drawing.Size(122, 27);
            this.btnTravel.TabIndex = 0;
            this.btnTravel.Text = "Start Traveling";
            this.btnTravel.UseVisualStyleBackColor = true;
            this.btnTravel.Click += new System.EventHandler(this.BtnTravel_Click);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 1000;
            this.timerUpdate.Tick += new System.EventHandler(this.TimerUpdate_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(435, 366);
            this.Controls.Add(this.gbActions);
            this.Controls.Add(this.gbAccount);
            this.Controls.Add(this.gbLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "SimpleMMO Bot";
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.gbAccount.ResumeLayout(false);
            this.gbAccount.PerformLayout();
            this.gbActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtbEmail;
        private System.Windows.Forms.TextBox txtbPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.GroupBox gbAccount;
        private System.Windows.Forms.Label lblEnergy;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.Label lblSteps;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTravel;
        private System.Windows.Forms.Timer timerUpdate;
    }
}

