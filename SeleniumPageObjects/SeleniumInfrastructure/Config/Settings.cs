using System.Configuration;


namespace SeleniumFramework.SeleniumInfrastructure.Config
{
    public static class Settings
    {

        private static string _url;

        public static string Url
        {
            get {
                _url = ConfigurationManager.AppSettings["DefaultUrl"];
                return _url;
                }
            set { _url = value; }
        }

        private static string _browser;

        public static string Browser
        {
            get {
                _browser = ConfigurationManager.AppSettings["DefaultBrowser"];
                return _browser;
                }
            set { _browser = value; }
        }



    }
}
