using System.Text.RegularExpressions;

namespace SimpleMMO_Bot
{
    public static class Game
    {
        public const int StepsChargeTimeSeconds = 120;
        public static Player CurrentPlayer;

        public enum ChestType
        {
            bronze,
            silver,
            gold
        }

        public static void HandleTravel(Player player, Json.TravelResponse data, out int waitTime)
        {
            // Strip HTML tags from rewardText
            string resultText = Regex.Replace(data.ResultText, " ?<[^>]*>", string.Empty);

            if (data.RewardAmount == "Apples and Oranges")
            {
                // Found item
                if (data.RewardType == "item")
                {
                    // Substring from 0 to second occurence of \n
                    resultText = resultText.Substring(0, resultText.IndexOf("\n", resultText.IndexOf("\n") + 1)).Replace("\n   ", string.Empty);
                }

                // Found mob
                if (data.RewardType == "none")
                {
                    resultText = Regex.Replace(data.Text.TrimStart().Substring(0, data.Text.TrimStart().IndexOf(".<br")), " ?<[^>]*>", string.Empty);
                    Program.Log("[TRAVEL] " + resultText);

                    player.FightNPC(Constants.URL + Regex.Match(data.Text, "href='(.*)' onclick").Groups[1].Value);
                }
            }

            // Found nothing
            if (resultText != "none" && (data.RewardAmount != "Apples and Oranges" && data.RewardType != "none"))
                Program.Log("[TRAVEL] " + resultText);

            // Set amount we should wait unless we have no more steps. If so we wait 2 minutes and try again.
            if (!data.Text.Contains("You have no more steps left! You will get additional steps every"))
            {
                waitTime = data.NextWait;
            }
            else
            {
                waitTime = StepsChargeTimeSeconds;
                Program.Log(string.Format("[TRAVEL] No more steps, waiting {0} minutes", StepsChargeTimeSeconds / 60));
            }
        }
    }
}
