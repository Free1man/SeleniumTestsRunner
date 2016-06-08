using OpenQA.Selenium;
using SeleniumFramework.SeleniumInfrastructure.Config;
using SeleniumFramework.SeleniumInfrastructure.Logging;
using System;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    public class BrowserSettingsService
    {
        private IWebDriver _driver;
        private TimeSpan _implicitWaitTime;
        private string _url;
        private bool _useLogging;

        public BrowserSettingsService(IWebDriver driver, Settings settings)
        {
            _driver = driver;
            _implicitWaitTime = settings.ImplicitWaitTime;
            _url = settings.Url;
            _useLogging = settings.UseLogging;
        }

        public void SetBrowserSettings()
        {

            _driver.Manage().Timeouts().ImplicitlyWait(_implicitWaitTime);
            _driver.Url = _url;
            if (_useLogging)
            {
                var logger = new LoggingService(new Browser(_driver));
            }
        }
    }
}
