using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;
using System.Collections.Generic;


namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    public class FirefoxOptions : IBrowserOptions
    {
        private readonly ISettings _settings;

        public FirefoxOptions(ISettings settings)
        {
            _settings = settings;
        }     

        public Dictionary<string, string> AdditionalRemoteDriverCapabilities => _settings.AdditionalRemoteDriverCapabilities;

        public DriverOptions GetOptions()
        {
            var profile = new FirefoxProfile();
            var options = new OpenQA.Selenium.Firefox.FirefoxOptions();
            options.SetPreference(FirefoxDriver.ProfileCapabilityName, profile.ToBase64String());
            return options;
        }

        

       
    }
}
