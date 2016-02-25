using OpenQA.Selenium.Support.Events;
using SeleniumFramework.SeleniumInfrastructure.Logging;
using System;

namespace SeleniumFramework.SeleniumInfrastructure
{
    public class Browser
    {
        
        private EventFiringWebDriver Driver { get; }
        private Logger Logger { get; }

        internal Browser()
        {
            Driver = DriverContext.Driver;
            Logger = DriverContext.Logger;        
        }
               
        private  BrowserType Type { get; }

        public enum BrowserType
        {
            Firefox,
            Chrome,
            ReadFromAppConfig
        }

        public void GoToUrl(string url)
        {
            Driver.Url = url;
        }

        public void Quit()
        {
            Driver.Quit();
        }

        public void SetImplicitlyWaitTime(TimeSpan licitlyWaitTime)
        {
            Driver.Manage().Timeouts().ImplicitlyWait(licitlyWaitTime);
        }

    }
}
