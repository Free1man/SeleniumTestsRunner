using System;
using System.Configuration;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Config.TestEnvironment
{
    internal class TestEnvironmentSettings 
    {
        private string _browserVer;
        private string _platform;
        private string _remoteDriverHubUrl;
        private string _screenshotsFolder;
        private string _url;

        public string ScreenshotsFolder
        {
            get
            {
                _screenshotsFolder = ConfigurationManager.AppSettings["ScreenshotsFolder"];
                if (string.IsNullOrWhiteSpace(_screenshotsFolder))
                    throw new InvalidOperationException("ScreenshotsFolder must be set in Configuration");
                return _screenshotsFolder + DateTime.Now.ToString("yyyy-MM-dd-hhmm");
            }
        }

        public string Url
        {
            get
            {
                _url = ConfigurationManager.AppSettings["DefaultUrl"];
                if (string.IsNullOrEmpty(_url))
                    throw new InvalidOperationException("DefaultUrl must be set in Configuration");
                return _url;
            }
        }

        public string RemoteDriverHubUrl
        {
            get
            {
                _remoteDriverHubUrl = ConfigurationManager.AppSettings["RemoteDriverHubUrl"];
                if (string.IsNullOrEmpty(_remoteDriverHubUrl))
                    throw new InvalidOperationException(
                        "RemoteDriverHubUrl must be set in Configuration");
                ;
                return _remoteDriverHubUrl;
            }
        }

        public string Platform
        {
            get
            {
                _platform = ConfigurationManager.AppSettings["Platform"];                  
                return _platform;
            }
        }

        public string BrowserVer
        {
            get
            {
                _browserVer = ConfigurationManager.AppSettings["BrowserVer"];
                return _browserVer;
            }
        }
    }
}