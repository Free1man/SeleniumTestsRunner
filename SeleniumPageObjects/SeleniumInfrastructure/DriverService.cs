using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using System;

namespace SeleniumFramework.SeleniumInfrastructure
{
    class DriverService 
    {
        public IWebDriver GetBrowserForDriver(string browser)
        {
            switch (browser) { 
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
    }
}
