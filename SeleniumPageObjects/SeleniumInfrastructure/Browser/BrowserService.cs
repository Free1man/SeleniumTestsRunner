using System;
using OpenQA.Selenium.Support.Events;
using SeleniumFramework.SeleniumInfrastructure.Config;

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
            if (browserType == Browser.BrowserType.Firefox || browserType == Browser.BrowserType.Chrome)
            {
                driver = new EventFiringWebDriver(DriverService.GetBrowserForDriver(browserType.ToString()));
            } else if (browserType == Browser.BrowserType.ReadFromAppConfig)
            {
                driver = new EventFiringWebDriver(DriverService.GetBrowserForDriver(Settings.Browser));
            } else
            {
                throw new ArgumentException("Browser type invalid");
            }

            if (useLogging)
            {
                return new LoggingBrowser(driver);
            } else
            {
                return new Browser(driver);
            }
        }
    }
}
