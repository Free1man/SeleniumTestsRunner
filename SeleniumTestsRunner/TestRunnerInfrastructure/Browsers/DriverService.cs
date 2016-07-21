using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.IE;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Browsers
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
                    string firefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
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
                case "InternetExplorer":
                    // configure - http://stackoverflow.com/questions/21330079/i-o-exception-and-unable-to-find-element-in-ie-using-selenium-webdriver/21373224#21373224
                    driverExecutableFileName = "IEDriverServer.exe";
                    var iEDriverService = InternetExplorerDriverService.CreateDefaultService(pathToDriver, driverExecutableFileName);
                    return new InternetExplorerDriver();
                default:
                    throw new ArgumentException(browser + "- Not supported browser");
            }
        }
    }
}