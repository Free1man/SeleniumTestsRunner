﻿using OpenQA.Selenium;
using SeleniumFramework.SeleniumInfrastructure.Config;
using SeleniumFramework.SeleniumInfrastructure.Logging;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    internal class BrowserService : IBrowserService
    {
        private readonly Settings _settings;

        public BrowserService(Settings settings)
        {
            _settings = settings;
        }

        public Browser GetBrowser(Browser.BrowserType browserType)
        {
            IWebDriver driver;
            if (_settings.UseLogging)
            {
                ILoggingService loggingService = new LoggingService();
                driver = SelectDriver(browserType);
                driver = loggingService.EnableLoggingForDriver(driver);

            }
            else
            {
                driver = SelectDriver(browserType);
            }

            var browserSettingsService = new BrowserSettingsService();
            browserSettingsService.SetBrowserSettings(driver, _settings);

            return new Browser(driver);
        }

        
        private IWebDriver SelectDriver(Browser.BrowserType browserType)
        {
            IWebDriver driver;
            var driverService = new DriverService();

            switch (browserType)
            {
                default:
                    driver = driverService.GetDriver(browserType.ToString());
                    break;
                case Browser.BrowserType.ReadFromSettings:
                    driver = driverService.GetDriver(_settings.Browser);
                    break;
            }
            return driver;
        }
    }
}