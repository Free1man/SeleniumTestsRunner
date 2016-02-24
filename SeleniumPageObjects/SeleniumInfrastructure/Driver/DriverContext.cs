using OpenQA.Selenium;


namespace SeleniumFramework.SeleniumInfrastructure
{
    public static class DriverContext
    {
        private static IWebDriver _driver;

        internal static IWebDriver Driver
        {
            get { return _driver; }
            set { _driver = value; }
        }
       
    }
}
