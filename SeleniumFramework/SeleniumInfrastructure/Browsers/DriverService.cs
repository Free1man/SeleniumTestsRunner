using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using System.Net;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    public class DriverService
    {
        public IWebDriver GetDriver(string browser)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            switch (browser)
            {
                case "Firefox":
                    //TO DO: hotfix for Firefox 47, should be refactored, all parameters should go to app.config
                    FirefoxOptions option1 = new FirefoxOptions();
                    //Copy wires.exe file to output directory or this code will fail.
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(path, "wires.exe");
                    service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    return new FirefoxDriver(service);
                case "Chrome":
                    return new ChromeDriver();
                case "PhantomJS":
                    return new PhantomJSDriver();
                case "RemoteFirefox":
                    //TO DO: create separate service for Selenium Grid Drivers, this is just example
                    Environment.SetEnvironmentVariable("webdriver.gecko.driver", @"C:\");
                    //WebClient Client = new WebClient();
                    //Client.DownloadFile("http://chromedriver.storage.googleapis.com/2.22/chromedriver_linux32.zip", @"C:\Report\stackoverflowlogo.png");
                    var capability = DesiredCapabilities.Firefox();
                    //capability.SetCapability("marionette", true);
                    return new RemoteWebDriver(new Uri("http://172.17.16.45:5555/wd/hub"), capability);
                default:
                    throw new ArgumentException(browser + "- Not supported browser");
            }
        }
    }
}