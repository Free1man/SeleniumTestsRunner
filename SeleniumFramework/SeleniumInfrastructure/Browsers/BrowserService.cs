using System;
using SeleniumFramework.SeleniumInfrastructure.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using SeleniumFramework.SeleniumInfrastructure.Logging;

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
            switch (browserType)
            {
                case Browser.BrowserType.Firefox:
                case Browser.BrowserType.Chrome:
                    driver = GetDriverForBrowser(browserType.ToString());
                    break;
                case Browser.BrowserType.ReadFromSettings:
                    driver = GetDriverForBrowser(_settings.Browser);
                    break;
                default:
                    throw new ArgumentException("Browser type invalid");
            }

            SetBrowserSettings(driver);
            return new Browser(driver);
        }

        private void SetBrowserSettings(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitlyWait(_settings.ImplicitWaitTime);
            driver.Url = _settings.Url;

            if (Settings.UseLogging)
            {
                var logger = new LoggingService(new Browser(driver));
            }
        }

        private IWebDriver GetDriverForBrowser(string browser)
        {
            switch (browser)
            {
                case "Firefox":
                    return new FirefoxDriver();
                case "Chrome":
                    return new ChromeDriver();
                case "PhantomJS":
                    return new PhantomJSDriver();
                default:
                    throw new ArgumentException(browser + "- Not supported browser");
            }
        }

        private Settings _settings;
    }
}
