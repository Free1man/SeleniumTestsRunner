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

        private string _url;

        public string Url
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

        private TimeSpan _implicitWaitTime;

        public TimeSpan ImplicitWaitTime
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


