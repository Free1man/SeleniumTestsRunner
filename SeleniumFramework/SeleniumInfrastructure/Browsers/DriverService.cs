using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    public class DriverForBrowserService
    {
        public IWebDriver GetDriverForBrowser(string browser)
        {
            switch (browser)
            {
                case "Firefox":
                    return new FirefoxDriver();
                case "Chrome":
                    return new ChromeDriver();
                case "PhantomJS":
                    return new PhantomJSDriver();
                case "RemoteFirefox":
                    //TO DO: create separate service for Selenium Grid Drivers, this is just example
                    var capability = DesiredCapabilities.Firefox();
                    return new RemoteWebDriver(new Uri("http://172.17.16.45:5555/wd/hub"), capability);
                default:
                    throw new ArgumentException(browser + "- Not supported browser");
            }
        }
    }
}