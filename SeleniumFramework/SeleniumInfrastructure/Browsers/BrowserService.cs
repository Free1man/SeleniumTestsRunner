using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using SeleniumFramework.SeleniumInfrastructure.Config;

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
                //Don't like this code, but it is really important to wrap driver here, or it will not work with SeleniumGrid
                driver = new EventFiringWebDriver(SelectDriver(browserType));
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
            var driverForBrowserService = new DriverForBrowserService();

            switch (browserType)
            {
                default:
                    driver = driverForBrowserService.GetDriverForBrowser(browserType.ToString());
                    break;
                case Browser.BrowserType.ReadFromSettings:
                    driver = driverForBrowserService.GetDriverForBrowser(_settings.Browser);
                    break;
            }
            return driver;
        }
    }
}