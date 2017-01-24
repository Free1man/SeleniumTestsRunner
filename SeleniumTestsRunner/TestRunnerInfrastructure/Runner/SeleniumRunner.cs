using System;
using System.Collections.Generic;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;
using SeleniumTestsRunner.TestRunnerInfrastructure.Drivers;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Runner
{
    public class SeleniumRunner 
    {
        private static SeleniumRunner _instance;

        private readonly ISettings _settings;

        private SeleniumRunner(ISettings settings)
        {
            _settings = settings;
        }

        public static SeleniumRunner Instance
        {
            get
            {
                if (_instance == null)
                {
                    ISettings settings = new Settings();
                    _instance = new SeleniumRunner(settings);
                }
                return _instance;
            }
        }

        public Browser Browser { get; private set; }

        public void StartBrowser(Dictionary<string, string> additionalCapabilities = null)
        {
            if (Browser == null)
            {
                _settings.AdditionalRemoteDriverCapabilities = additionalCapabilities;
                var driverCreator = new DriverCreator(_settings);
                Browser = new Browser(driverCreator.CreateDriverForBrowser(), _settings);
            }
            else
            {
                throw new Exception("Only one browser allowed per test thread");
            }       
        }

        public void CloseBrowser()
        {
            Browser.Driver.Quit();
            _instance = null;
        }
    }
}