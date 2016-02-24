using OpenQA.Selenium;
using System;

namespace SeleniumFramework.SeleniumInfrastructure
{
    public class Browser
    {
        
        private IWebDriver Driver { get; set; }

        internal Browser()
        {
            Driver = DriverContext.Driver;
        }

        private  BrowserType Type { get; set; }

        public enum BrowserType
        {
            Firefox,
            Chrome,
            ReadFromAppConfig
        }

        public  void GoToUrl(string url)
        {
            Driver.Url = url;
        }

        public  void Quit()
        {
            Driver.Quit();
        }

        public  void SetImplicitlyWaitTime(TimeSpan licitlyWaitTime)
        {
            Driver.Manage().Timeouts().ImplicitlyWait(licitlyWaitTime);
        }

    }
}
