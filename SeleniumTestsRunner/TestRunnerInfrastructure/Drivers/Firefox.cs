using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;
using System.Collections.Generic;


namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    public class Firefox : IBrowser
    {
        private ISettings _settings;

        public Firefox(ISettings settings)
        {
            _settings = settings;
        }     

        public Dictionary<string, string> AdditionalRemoteDriverCapabilities
        {
            get { return _settings.AdditionalRemoteDriverCapabilities; }
        }

        public DriverOptions GetOptions()
        {
            var profile = new FirefoxProfile();
            var options = new FirefoxOptions();
            options.AddAdditionalCapability(FirefoxDriver.ProfileCapabilityName, profile.ToBase64String());
            return options;
        }

        

       
    }
}
