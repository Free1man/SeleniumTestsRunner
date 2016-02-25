using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using SeleniumFramework.SeleniumInfrastructure.Logging;
using System;
using System.Drawing.Imaging;

namespace SeleniumFramework.SeleniumInfrastructure
{
    public class Browser
    {
        
        private EventFiringWebDriver Driver { get; set; }
        public Logger Logger { get; set; }

        internal Browser()
        {
            Driver = DriverContext.Driver;
            Logger = new Logger(Driver);
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
