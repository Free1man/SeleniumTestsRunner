using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;

namespace SeleniumFramework.SeleniumInfrastructure
{
    public static class DriverContext
    {
        private static EventFiringWebDriver _driver;

        internal static EventFiringWebDriver Driver
        {
            get { return _driver; }
            set { _driver = value; }
        }


        private static Browser _browser;
 
        public static Browser Browser
        {
            get
            {
                _browser = new Browser();
                return _browser;
            }
            set { _browser = value; }
        }
    }
}
