using System;
using System.Configuration;


namespace SeleniumPageObjects
{
    public class SeleniumRunnerInitialisationParameters
    {
        private string _browser;

        public string Browser
        {
            get
            {
                _browser = ConfigurationManager.AppSettings["DefaultBrowser"];
                return _browser;
            }
            set
            {
                _browser = value;
            }

        }

        private string _url;

        public string Url
        {
            get
            {
                _url = ConfigurationManager.AppSettings["DefaultUrl"];
                return _url;
            }

        }

        private TimeSpan _implicitWaitTime;

        public TimeSpan ImplicitWaitTime
        {
            get
            {
                _implicitWaitTime = TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["DefaultImplicitlyWait"]));
                return _implicitWaitTime;
            }

        }
    }
}


