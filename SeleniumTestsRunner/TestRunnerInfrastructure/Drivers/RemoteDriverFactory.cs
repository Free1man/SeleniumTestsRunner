using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;
using SeleniumTestsRunner.TestRunnerInfrastructure.Events;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    /// <summary>
    ///     Represents a service that creates IWebDriver.
    /// </summary>
    internal class RemoteDriverFactory
    {
        private readonly ISettings _settings;
        private EventFiringWebDriver _eventFiringWebDriver;

        /// <summary>
        ///     Configure RemoteDriverService service based on the settings.
        /// </summary>
        /// <param name="settings">Settings that will define IWebDriver configuration</param>
        public RemoteDriverFactory(ISettings settings)
        {
            _settings = settings;
        }

        public IWebDriver GetDriver()
        {
            var driver = GetEventFiringWebDriver(GetRemoteDriver());
            return driver;
        }

        private DesiredCapabilities AddFirefoxSpecificCapabilities(DesiredCapabilities capabilities)
        {
            var profile = new FirefoxProfile();
            capabilities.SetCapability(FirefoxDriver.ProfileCapabilityName, profile.ToBase64String());
            return capabilities;
        }

        private IWebDriver GetEventFiringWebDriver(IWebDriver driver)
        {
            _eventFiringWebDriver = new EventFiringWebDriver(driver);
            var eventsListener = new WebDriverEventsListener(_settings, _eventFiringWebDriver);
            eventsListener.SubscribeToEvents();
            driver = _eventFiringWebDriver;
            return driver;
        }

        /// <summary>
        ///     Returns IWebDriver based on the RemoteDriverService settings.
        /// </summary>
        private IWebDriver GetRemoteDriver()
        {
            var capabilities = new DesiredCapabilities();
            if (_settings.AdditionalRemoteDriverCapabilities != null)
            {
                foreach (var capability in _settings.AdditionalRemoteDriverCapabilities)
                {
                    capabilities.SetCapability(capability.Key, capability.Value);
                }
            }
            if (capabilities.BrowserName == "firefox")
            {
                capabilities = AddFirefoxSpecificCapabilities(capabilities);
            }
            return new RemoteWebDriver(new Uri(_settings.RemoteDriverHubUrl), capabilities,
                TimeSpan.FromSeconds(60));
        }
    }
}