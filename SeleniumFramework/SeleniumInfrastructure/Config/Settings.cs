using System;
using System.Configuration;
using System.IO;

namespace SeleniumFramework.SeleniumInfrastructure.Config
{
    public class Settings
    {
        public Settings()
        {
            Initialise();
        }            

        private void Initialise()
        {
            Url = ConfigurationManager.AppSettings["DefaultUrl"];
            if (string.IsNullOrEmpty(Url)) {
                throw new InvalidOperationException("DefaultUrl must be set in Configuration");
            }

            Browser = ConfigurationManager.AppSettings["DefaultBrowser"];
            if (string.IsNullOrWhiteSpace(Browser))
            {
                throw new InvalidOperationException("DefaultBrowser must be set in Configuration");
            }

            TestFolder = "D:\\wall\\" + DateTime.Now.ToString("yyyy-MM-dd");
        }

        public string Browser { get; private set; }
        public string Url { get; private set; }
        public string TestFolder { get; private set; }

        private TimeSpan _implicitWaitTime;
        public TimeSpan ImplicitWaitTime
        {
            get
            {
                if (_implicitWaitTime == null)
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
