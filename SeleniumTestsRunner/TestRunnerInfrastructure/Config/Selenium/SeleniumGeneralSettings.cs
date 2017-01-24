using System;
using System.Configuration;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Config.Selenium
{
    internal class SeleniumGeneralSettings : ISeleniumGeneralSettings
    {
        private string _browser;
        private TimeSpan _implicitWaitTime;
        private bool _useLogging;

        public TimeSpan ImplicitWaitTime
        {
            get
            {
                _implicitWaitTime =
                    TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["DefaultImplicitlyWait"]));
                if (_implicitWaitTime == TimeSpan.Zero)
                    throw new InvalidOperationException("Non 0 ImplicitWaitTime must be set in Configuration");
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


        public string Browser
        {
            get
            {
                _browser = ConfigurationManager.AppSettings["Browser"];
                if (string.IsNullOrWhiteSpace(_browser))
                    throw new InvalidOperationException("Browser must be set in Configuration");
                return _browser;
            }
        }
    }
}