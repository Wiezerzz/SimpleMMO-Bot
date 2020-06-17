namespace SimpleMMO_Bot
{
    public static class Constants
    {
        public const string URL = "http://simple-mmo.com";
        public const string LoginPage = "/login";
        public const string HomePage = "/home";
        public const string AccountStatus = "/mobapi";
        public const string TravelPage = "/travel";
        public const string GetTravel = "/travel/get/travel";
        public const string AddStepsApi = "/addstepsapi";
        public const string AddKeyApi = "/addkeyapi";
        public const string OpenChest = "/openchest/open/";
        public const string ExchangeKeys = "/exchangekeys/";
        public const string MarketSell = "/market/sell/";

        public static class Regex
        {
            public const string CsrfToken = "<meta name=\"csrf-token\" content=\"(.*)\">";

            /*
            public const string NameAndLevel = "color:#555555;'>(.*) Level (.*)";
            public const string GoldAndSteps = "span class='gold-amount'>\n(.*)\n</span>\n</span>\n<span style='padding-right:10px;'><img src='http://simple-mmo.com/img/footsteps.png' height=\"15\"> <span id=\"stepsleft\">(.*)</span></";
            public const string HpAndMaxHp = "right:5px;\">(.*) / (.*) Health </span></";
            public const string ExpAndExpRequired = "exp-amount\">\n(.*)\n</span> / (.*) Experience";
            public const string EnergyAndMaxEnergy = "right:5px;\">(.*) / (.*) Energy";
            */
        }
    }
}
