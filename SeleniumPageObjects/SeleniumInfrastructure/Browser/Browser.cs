using OpenQA.Selenium;
using SeleniumFramework.SeleniumInfrastructure.Config;
using System;

namespace SeleniumFramework.SeleniumInfrastructure
{
    public class Browser 
    {
        private readonly IWebDriver _driver;

        public Browser()
        {
            _driver = DriverContext.Driver;
        }

        private BrowserType Type { get; set; }

        public enum BrowserType
        {
            Firefox,
            Chrome,
            ReadFromAppConfig
        }

        public void GoToUrl(string url)
        {
            DriverContext.Driver.Url = url;
        }

        public void Quit()
        {
            DriverContext.Driver.Quit();
        }

        public void SetImplicitlyWaitTime(TimeSpan licitlyWaitTime)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitlyWait(licitlyWaitTime);
        }

    }
}
