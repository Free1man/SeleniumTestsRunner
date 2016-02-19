using System;
using System.Configuration;


namespace SeleniumFramework.SeleniumInfrastructure.Config
{
    public static class Settings
    {

        private static string _browser;

        public static string Browser
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_browser))
                {
                    _browser = ConfigurationManager.AppSettings["DefaultBrowser"];
                }
                return _browser;
            }
            set
            {
                _browser = value;
            }

        }

        private static string _url;

        public static string Url
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_url))
                {
                    _url = ConfigurationManager.AppSettings["DefaultUrl"];
                }
                return _url;
            }
            set
            {
                _url = value;
            }

        }

        private static TimeSpan _implicitWaitTime;

        public static TimeSpan ImplicitWaitTime
        {
            get
            {
                if (_implicitWaitTime != null)
                {
                    _implicitWaitTime = TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["DefaultImplicitlyWait"]));
                }
                return _implicitWaitTime;
            }
            set
            {
                _implicitWaitTime = value;
            }

        }
    }
}
