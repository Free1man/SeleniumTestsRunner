using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    internal class RemoteDriverService
    {
        private readonly ISettings _settings;

        public RemoteDriverService(ISettings settings)
        {
            _settings = settings;
        }

        public IWebDriver GetDriver()
        {
          
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, _settings.Browser);
            capabilities.SetCapability(CapabilityType.Version, _settings.BrowserVer);
            capabilities.SetCapability(CapabilityType.Platform, _settings.Platform);
            if (_settings.AdditionalRemoteDriverCapabilities !=null)
            {
                foreach (var capability in _settings.AdditionalRemoteDriverCapabilities)
                {
                    capabilities.SetCapability(capability.Key, capability.Value);
                }
            }      
            return new RemoteWebDriver(new Uri(_settings.RemoteDriverHubUrl), capabilities,
                TimeSpan.FromSeconds(60));                      
        }
    }
}