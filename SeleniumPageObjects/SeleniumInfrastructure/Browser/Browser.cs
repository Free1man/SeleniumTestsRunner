using OpenQA.Selenium;
using SeleniumFramework.SeleniumInfrastructure.Config;
using System;

namespace SeleniumFramework.SeleniumInfrastructure
{
    public static class Browser
    {
        
        private static IWebDriver Driver { get; }   
        
        static Browser()
        {
            Driver = DriverContext.Driver;
        }

        private static BrowserType Type { get; set; }

        public enum BrowserType
        {
            Firefox,
            Chrome,
            ReadFromAppConfig
        }

        public static void GoToUrl(string url)
        {
            Driver.Url = url;
        }

        public static void Quit()
        {
            Driver.Quit();
        }

        public static void SetImplicitlyWaitTime(TimeSpan licitlyWaitTime)
        {
            Driver.Manage().Timeouts().ImplicitlyWait(licitlyWaitTime);
        }

    }
}
