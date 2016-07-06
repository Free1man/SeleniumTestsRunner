using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    public class DriverService
    {
        public IWebDriver GetDriver(string browser)
        {
            string pathToDriver = AppDomain.CurrentDomain.BaseDirectory;
            string driverExecutableFileName = "geckodriver.exe";
            string firefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            switch (browser)
            {
                case "Firefox":
                    FirefoxDriverService firefoxDriverService = FirefoxDriverService.CreateDefaultService(pathToDriver, driverExecutableFileName);
                    firefoxDriverService.FirefoxBinaryPath = firefoxBinaryPath;
                    return new FirefoxDriver(firefoxDriverService);
                case "Chrome":
                    return new ChromeDriver();
                case "PhantomJS":
                    return new PhantomJSDriver();
                default:
                    throw new ArgumentException(browser + "- Not supported browser");
            }
        }

        public IWebDriver GetRemoteDriver(string browser)
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