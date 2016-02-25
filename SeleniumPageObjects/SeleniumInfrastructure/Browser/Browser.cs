using System;

namespace SeleniumFramework.SeleniumInfrastructure
{
    public class Browser : DriverContext
    {     
        internal Browser()
        {
            Logger = Logger;
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
