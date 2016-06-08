using SeleniumFramework.SeleniumInfrastructure.Config;
using OpenQA.Selenium;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    internal class BrowserService : IBrowserService
    {
        public BrowserService(Settings settings)
        {
            _settings = settings;
        }

        public Browser GetBrowser(Browser.BrowserType browserType)
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

            var browserSettingsService = new BrowserSettingsService(driver, _settings);
            browserSettingsService.SetBrowserSettings();
            return new Browser(driver);
        }
        private Settings _settings;
    }
}
