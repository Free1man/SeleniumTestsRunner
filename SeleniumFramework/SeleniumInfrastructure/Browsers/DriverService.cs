using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    internal class DriverService : IDriverService
    {
        public IWebDriver GetDriver(string browser)
        {
            //TO DO move all hardcoded values to the Settings
            string pathToDriver = AppDomain.CurrentDomain.BaseDirectory;
            string driverExecutableFileName;
           
            switch (browser)
            {
                case "Firefox":
                    driverExecutableFileName = "geckodriver.exe";
                    var firefoxDriverService = FirefoxDriverService.CreateDefaultService(pathToDriver, driverExecutableFileName);
                    string firefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                    firefoxDriverService.FirefoxBinaryPath = firefoxBinaryPath;
                    return new FirefoxDriver(firefoxDriverService);
                case "Chrome":
                    driverExecutableFileName = "chromedriver.exe";
                    var chromeDriverService = ChromeDriverService.CreateDefaultService(pathToDriver, driverExecutableFileName);
                    return new ChromeDriver(chromeDriverService);
                case "PhantomJS":
                    driverExecutableFileName = "phantomjs.exe";
                    var phantomJsDriverService = PhantomJSDriverService.CreateDefaultService(pathToDriver, driverExecutableFileName);
                    return new PhantomJSDriver(phantomJsDriverService);
                default:
                    throw new ArgumentException(browser + "- Not supported browser");
            }
        }
    }
}