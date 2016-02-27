using System;
using OpenQA.Selenium.Support.Events;
using SeleniumFramework.SeleniumInfrastructure.Config;
using SeleniumFramework.SeleniumInfrastructure.Driver;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    internal class BrowserService : IBrowserService
    {
        public Browser GetBrowser(Browser.BrowserType browserType)
        {
            return GetBrowser(browserType, false);
        }

        public Browser GetBrowser(Browser.BrowserType browserType, bool useLogging)
        {
            EventFiringWebDriver driver = null;
            switch (browserType)
            {
                case Browser.BrowserType.Firefox:
                case Browser.BrowserType.Chrome:
                    driver = new EventFiringWebDriver(DriverService.GetBrowserForDriver(browserType.ToString()));
                    break;
                case Browser.BrowserType.ReadFromAppConfig:
                    driver = new EventFiringWebDriver(DriverService.GetBrowserForDriver(Settings.Browser));
                    break;
                default:
                    throw new ArgumentException("Browser type invalid");
            }

            return useLogging ? new LoggingBrowser(driver) : new Browser(driver);
        }
    }
}
