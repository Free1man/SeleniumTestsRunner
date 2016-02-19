using OpenQA.Selenium;
using SeleniumFramework.SeleniumInfrastructure.Config;
using System;

namespace SeleniumFramework.SeleniumInfrastructure
{
    public class Browser 
    {
        private readonly IWebDriver _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        public BrowserType Type { get; set; }

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

        public void ManageImplicitlyWaitTime(TimeSpan licitlyWaitTime)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitlyWait(licitlyWaitTime);
        }

    }
}
