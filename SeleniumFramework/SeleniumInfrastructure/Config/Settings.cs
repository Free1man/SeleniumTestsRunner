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

        public bool UseLogging { get; private set; }
        public bool UseRemoteBrowser { get; private set; }
        public string Browser { get; private set; }
        public string Url { get; private set; }
        public string TestFolder { get; private set; }
        public TimeSpan ImplicitWaitTime { get; private set; }

        private void Initialise()
        {
            Url = ConfigurationManager.AppSettings["DefaultUrl"];
            if (string.IsNullOrEmpty(Url))
            {
                throw new InvalidOperationException("DefaultUrl must be set in Configuration");
            }

            UseRemoteBrowser = Convert.ToBoolean(ConfigurationManager.AppSettings["UseRemoteBrowser"]);
           
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

            ImplicitWaitTime =
                TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["DefaultImplicitlyWait"]));
            if (ImplicitWaitTime == TimeSpan.Zero)
            {
                throw new InvalidOperationException("Non 0 ImplicitWaitTime must be set in Configuration");
            }

            UseLogging = Convert.ToBoolean(ConfigurationManager.AppSettings["UseLogging"]);
        }
    }
}