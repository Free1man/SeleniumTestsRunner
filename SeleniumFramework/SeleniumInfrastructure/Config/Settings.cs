using System;
using System.Configuration;

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

            TestFolder = ConfigurationManager.AppSettings["TestFolder"] + DateTime.Now.ToString("yyyy-MM-dd-hhmm");
            if (string.IsNullOrWhiteSpace(TestFolder))
            {
                throw new InvalidOperationException("TestFolder must be set in Configuration");
            }
        }

        public string Browser { get; private set; }
        public string Url { get; private set; }
        public string TestFolder { get; private set; }

        private TimeSpan _implicitWaitTime;
        public TimeSpan ImplicitWaitTime
        {
            get
            {
                if (_implicitWaitTime == TimeSpan.Zero)
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
