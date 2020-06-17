using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SimpleMMO_Bot
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbEmail.Text) || string.IsNullOrWhiteSpace(txtbPassword.Text))
                MessageBox.Show("Please fill in both email and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            gbLogin.Enabled = false;
            gbLogin.Update();

            try
            {
                Game.CurrentPlayer = new Player(txtbEmail.Text, txtbPassword.Text);

                TimerUpdate_Tick(null, EventArgs.Empty);
                timerUpdate.Enabled = true;
                gbActions.Enabled = true;
            }
            catch (InvalidOperationException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gbLogin.Enabled = true;
            }

            txtbPassword.Text = string.Empty;
        }

        private void TimerUpdate_Tick(object sender, EventArgs e)
        {
            if (Game.CurrentPlayer == null)
            {
                lblUsername.Text = "Username: Not logged in";
                lblLevel.Text = "Level: 0";
                lblGold.Text = "Gold: 0";
                lblSteps.Text = "Steps: 0";
                lblExperience.Text = "EXP: 0 / 0";
                lblHealth.Text = "HP: 0 / 0";
                lblEnergy.Text = "Energy: 0 / 0";

                timerUpdate.Enabled = false;
            }
            else
            {
                lblUsername.Text = string.Format("Username: {0}", Game.CurrentPlayer.Username);
                lblLevel.Text = string.Format("Level: {0}", Game.CurrentPlayer.Level);
                lblGold.Text = string.Format("Gold: {0}", Game.CurrentPlayer.Gold);
                lblSteps.Text = string.Format("Steps: {0}", Game.CurrentPlayer.Steps);
                lblExperience.Text = string.Format("EXP: {0} / {1}", Game.CurrentPlayer.Exp, Game.CurrentPlayer.ExpRequired);
                lblHealth.Text = string.Format("HP: {0} / {1}", Game.CurrentPlayer.Hp, Game.CurrentPlayer.MaxHp);
                lblEnergy.Text = string.Format("Energy: {0} / {1}", Game.CurrentPlayer.Energy, Game.CurrentPlayer.MaxEnergy);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int amountOfChestsToOpen = 100000;

            for (int i = 0; i < amountOfChestsToOpen; i++)
            {
                try
                {
                    Game.CurrentPlayer.CheatBronzeKey();
                    Thread.Sleep(7000);
                    Game.CurrentPlayer.OpenChest(Game.ChestType.bronze);

                    foreach (KeyValuePair<int, int> item in Game.CurrentPlayer.GetInventory())
                    {
                        for (int j = 0; j < item.Value; j++)
                        {
                            if (item.Key != 18)
                                Game.CurrentPlayer.ListItem(item.Key, 1);
                        }
                    }
                }
                catch (WebException)
                {}
            }
        }

        public void Log(string text)
        {
            if (!rtbLog.InvokeRequired)
            {
                rtbLog.Text += text + Environment.NewLine;
            }
            else
            {
                rtbLog.Invoke((MethodInvoker)delegate
                {
                    rtbLog.Text += text + Environment.NewLine;
                });
            }
        }

        private void BtnTravel_Click(object sender, EventArgs e)
        {
            btnTravel.Text = Game.CurrentPlayer.IsAutoTraveling ? "Start Traveling" : "Stop Traveling";
            Game.CurrentPlayer.AutoTravel();
        }

        private void RtbLog_TextChanged(object sender, EventArgs e)
        {
            // Set the current caret position to the end
            rtbLog.SelectionStart = rtbLog.Text.Length;

            // Scroll it automatically
            rtbLog.ScrollToCaret();
        }
    }
}
