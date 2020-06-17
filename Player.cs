using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace SimpleMMO_Bot
{
    public class Player
    {
        private CFWebClient webClient;
        private Thread autoTravelThread;

        public bool IsAutoTraveling { get; private set; }
        public string Username { get; private set; }
        public int Level { get; private set; }
        public int Gold { get; private set; }
        public int Steps { get; private set; }
        public int Exp { get; private set; }
        public int ExpRequired { get; private set; }
        public int Hp { get; private set; }
        public int MaxHp { get; private set; }
        public int Energy { get; private set; }
        public int MaxEnergy { get; private set; }

        public Player(string email, string password)
        {
            webClient = new CFWebClient();

            // Get CSRF token
            string csrfToken = Regex.Match(webClient.DownloadString(Constants.URL + Constants.LoginPage), Constants.Regex.CsrfToken).Groups[1].Value;

            // Set CSRF token as header (Laravel stuff?)
            webClient.Headers["X-CSRF-TOKEN"] = csrfToken;

            // Perform login
            NameValueCollection parameters = new NameValueCollection
            {
                { "_token", csrfToken },
                { "email", email },
                { "password", password },
                { "remember", "on" }
            };
            string responsebody = Encoding.UTF8.GetString(webClient.UploadValues(Constants.URL + Constants.LoginPage, "POST", parameters));

            // Check if login is successful
            if (responsebody.Contains("Start Your Travels"))
            {
                Json.AccountStatus accountStatus = JsonConvert.DeserializeObject<Json.AccountStatus>(webClient.DownloadString(Constants.URL + Constants.AccountStatus));
                Username = accountStatus.Username;
                Level = accountStatus.Level;
                Gold = accountStatus.Gold;
                Steps = accountStatus.Stepsleft;
                Exp = accountStatus.Exp;
                ExpRequired = accountStatus.Max_exp;
                Hp = accountStatus.Current_hp;
                MaxHp = accountStatus.Max_hp;
                Energy = accountStatus.Energy;
                MaxEnergy = accountStatus.Max_energy;
            }
            else
            {
                throw new InvalidOperationException("Wrong email or password.");
            }
        }

        public void UpdateStatus()
        {
            Json.AccountStatus data = JsonConvert.DeserializeObject<Json.AccountStatus>(webClient.DownloadString(Constants.URL + Constants.AccountStatus));

            Level = data.Level;
            Gold = data.Gold;
            Steps = data.Stepsleft;
            Exp = data.Exp;
            ExpRequired = data.Max_exp;
            Hp = data.Current_hp;
            MaxHp = data.Max_hp;
            Energy = data.Energy;
            MaxEnergy = data.Max_energy;
        }

        public Dictionary<int, int> GetInventory()
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            string source = webClient.DownloadString(Constants.URL + "/inventory");
            MatchCollection matchesCount = Regex.Matches(source, "padding-left:0px;padding-right:0px;'>(.*)x");
            MatchCollection matchesItemId = Regex.Matches(source, "/market/sell/(.*)' style");

            for (int i = 0; i < matchesCount.Count; i++)
            {
                dict.Add(int.Parse(matchesItemId[i].Groups[1].Value), int.Parse(matchesCount[i].Groups[1].Value));
            }

            return dict;
        }

        public void ListItem(int itemId, int amountToSellFor)
        {
            string source = webClient.DownloadString(Constants.URL + Constants.MarketSell + itemId);
            string listUrl = Constants.URL + Constants.MarketSell + Regex.Match(source, "/market/sell/(.*)/submit").Groups[1].Value + "/submit";
            string token = Regex.Match(source , "_token\" value=\"(.*)\">").Groups[1].Value;

            NameValueCollection parameters = new NameValueCollection
            {
                { "_token", token },
                { "amount", amountToSellFor.ToString() }
            };
            webClient.AutoRedirect = false;
            string responsebody = Encoding.UTF8.GetString(webClient.UploadValues(listUrl, "POST", parameters));
            webClient.AutoRedirect = true;
        }

        public void Travel(out int waitTime)
        {
            // Remove?
            if (Steps == 0)
            {
                CheatSteps();
                Steps += 10;
            }

            Json.TravelResponse data = JsonConvert.DeserializeObject<Json.TravelResponse>(Encoding.UTF8.GetString(webClient.UploadValues(Constants.URL + Constants.GetTravel, "POST", new NameValueCollection())));

            Game.HandleTravel(this, data, out waitTime);

            UpdateStatus();
        }

        public void AutoTravel()
        {
            if (!IsAutoTraveling)
            {
                autoTravelThread = new Thread(() =>
                {
                    while (IsAutoTraveling)
                    {
                        Travel(out int waitTime);
                        Thread.Sleep(waitTime * 1000);
                    }
                });

                autoTravelThread.IsBackground = true;
                autoTravelThread.Start();
            }
            else
            {
                autoTravelThread.Abort();
            }

            IsAutoTraveling = !IsAutoTraveling;
        }

        public void FightNPC(string battleURL)
        {
            // Fix URL
            battleURL = battleURL.Replace("/npcs/attack/", "/npcs/attack/api/");

            do
            {
                Json.Battle data = JsonConvert.DeserializeObject<Json.Battle>(webClient.DownloadString(battleURL));

                if (data.They_are_dead == true)
                {
                    Program.Log("[BATTLE] " + data.Their_death.RemoveHTMLTags());
                    if (data.Item_drop != null && string.IsNullOrEmpty(data.Item_drop))
                    {
                        string itemDrop = data.Item_drop.RemoveHTMLTags();

                        // Substring from 0 to second occurence of \n
                        itemDrop = itemDrop.Substring(0, itemDrop.IndexOf("\n", itemDrop.IndexOf("\n") + 1)).Replace("\n   ", string.Empty);
                        Program.Log("[BATTLE] " + itemDrop);
                    }

                    break;
                }

                if (data.You_are_dead != null && !string.IsNullOrEmpty(data.You_are_dead))
                {
                    Program.Log("[BATTLE] " + data.You_are_dead);
                    break;
                }

                if (data.Updated_your_hp <= 0)
                    break;

            } while (true);

        }

        public void CheatSteps()
        {
            NameValueCollection parameters = new NameValueCollection
            {
                { "time", "12343254534" }
            };
            webClient.UploadValues(Constants.URL + Constants.AddStepsApi, "POST", parameters);
        }

        public void CheatBronzeKey()
        {
            NameValueCollection parameters = new NameValueCollection
            {
                { "time", "12343254534" }
            };
            webClient.UploadValues(Constants.URL + Constants.AddKeyApi, "POST", parameters);
        }

        public void OpenChest(Game.ChestType chestType)
        {
            webClient.AutoRedirect = false;
            webClient.DownloadString(Constants.URL + Constants.OpenChest + chestType);
            webClient.AutoRedirect = true;
        }

        public void ExchangeKey(Game.ChestType chestType)
        {
            webClient.AutoRedirect = false;
            webClient.DownloadString(Constants.URL + Constants.ExchangeKeys + chestType);
            webClient.AutoRedirect = true;
        }

        public string Test(string url)
        {
            return webClient.DownloadString(url);
        }
    }
}
