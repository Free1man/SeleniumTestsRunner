using System;
using System.Configuration;

namespace SeleniumFramework.SeleniumInfrastructure.Config
{
    internal class Settings : ISettings
    {
        private string _browser;
        private TimeSpan _implicitWaitTime;
        private string _testFolder;
        private string _url;
        private bool _useLogging;
        private bool _useRemoteBrowser;

        public string Url
        {
            get
            {
                _url = ConfigurationManager.AppSettings["DefaultUrl"];
                if (string.IsNullOrEmpty(_url))
                {
                    throw new InvalidOperationException("DefaultUrl must be set in Configuration");
                }
                return _url;
            }
        }

        public TimeSpan ImplicitWaitTime
        {
            get
            {
                _implicitWaitTime =
                    TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["DefaultImplicitlyWait"]));
                if (_implicitWaitTime == TimeSpan.Zero)
                {
                    throw new InvalidOperationException("Non 0 ImplicitWaitTime must be set in Configuration");
                }
                return _implicitWaitTime;
            }
        }


        public bool UseLogging
        {
            get
            {
                _useLogging = Convert.ToBoolean(ConfigurationManager.AppSettings["UseLogging"]);
                return _useLogging;
            }
        }

        public bool UseRemoteBrowser
        {
            get
            {
                _useRemoteBrowser = Convert.ToBoolean(ConfigurationManager.AppSettings["UseRemoteBrowser"]);
                return _useRemoteBrowser;
            }
        }

        public string Browser
        {
            get
            {
                _browser = ConfigurationManager.AppSettings["DefaultBrowser"];
                if (string.IsNullOrWhiteSpace(_browser))
                {
                    throw new InvalidOperationException("DefaultBrowser must be set in Configuration");
                }
                return _browser;
            }
        }

        public string TestFolder
        {
            get
            {
                _testFolder = ConfigurationManager.AppSettings["TestFolder"] + DateTime.Now.ToString("yyyy-MM-dd-hhmm");
                if (string.IsNullOrWhiteSpace(_testFolder))
                {
                    throw new InvalidOperationException("TestFolder must be set in Configuration");
                }
                return _testFolder;
            }
        }
    }
}