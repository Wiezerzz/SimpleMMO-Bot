namespace SimpleMMO_Bot
{
    public static class Json
    {
        public class AccountStatus
        {
            public string Loggedin { get; set; }
            public string Username { get; set; }
            public string Avatar { get; set; }
            public int Level { get; set; }
            public int Stepsleft { get; set; }
            public int Maxsteps { get; set; }
            public int Events { get; set; }
            public int Messages { get; set; }
            public int Gold { get; set; }
            public int Diamonds { get; set; }
            public int Exp { get; set; }
            public int Max_exp { get; set; }
            public int Exp_percent { get; set; }
            public int Current_hp { get; set; }
            public int Max_hp { get; set; }
            public int Hp_percent { get; set; }
            public int Energy { get; set; }
            public int Max_energy { get; set; }
            public int Energy_percent { get; set; }
        }

        public class TravelResponse
        {
            public string Text { get; set; }
            public string ResultText { get; set; }
            public string RewardType { get; set; }
            public string RewardAmount { get; set; }
            public int CurrentEXP { get; set; }
            public int CurrentGold { get; set; }
            public int Level { get; set; }
            public int NextWait { get; set; }
        }

        public class Battle
        {
            public bool NewBattle { get; set; }
            public bool They_are_dead { get; set; }
            public string You_are_dead { get; set; }
            public string Their_death { get; set; }
            public string Dmg_given { get; set; }
            public string Dmg_taken { get; set; }
            public int Updated_their_hp { get; set; }
            public int Updated_your_hp { get; set; }
            public string Item_drop { get; set; }
        }
    }
}
