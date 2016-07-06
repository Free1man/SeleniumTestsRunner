using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    public class DriverService : IDriverService
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
    }
}