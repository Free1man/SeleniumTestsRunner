using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;
using System.Collections.Generic;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    public class ChromeOptions : IBrowserOptions
    {

        private readonly ISettings _settings;
        
        public ChromeOptions(ISettings settings)
        {
            _settings = settings;
        }
              
        public Dictionary<string,string> AdditionalRemoteDriverCapabilities => _settings.AdditionalRemoteDriverCapabilities;

        public DriverOptions GetOptions()
        {
            var options = new OpenQA.Selenium.Chrome.ChromeOptions();
            return options;
        }


    }
}
