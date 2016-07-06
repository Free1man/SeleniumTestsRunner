using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    public class RemoteDriverService : IDriverService
    {
        public IWebDriver GetDriver(string browser)
        {
            switch (browser)
            {
                case "RemoteFirefox":
                    //TO DO: create separate service for Selenium Grid Drivers, this is just example
                    DesiredCapabilities capabilites = new DesiredCapabilities();
                    Environment.SetEnvironmentVariable("webdriver.gecko.driver", @"C:\");
                    capabilites.SetCapability("marionette", true);
                    return new RemoteWebDriver(new Uri("http://172.17.16.45:5555/wd/hub"), capabilites);
                default:
                    throw new ArgumentException(browser + "- Not supported browser");
            }
        }
    }
}
