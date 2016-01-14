using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPageObjects
{
   
    public class SeleniumRunner : ISeleniumRunner
    {
        public IWebDriver Driver { get; }

        public SeleniumRunner()
        {
            string caseSwitch = ConfigurationManager.AppSettings["DefaultBrowser"];
            switch (caseSwitch)
            {
                case "Firefox":
                    Console.WriteLine("Starting FireFox browser");
                    Driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    Console.WriteLine("Starting Chrome browser");
                    Driver = new ChromeDriver();
                    break;

                case "PhantomJS":
                    Console.WriteLine("Starting Chrome browser");
                    var phantomJsOptions = new PhantomJSOptions();
                    phantomJsOptions.AddAdditionalCapability("page.settings.userAgent", "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:42.0) Gecko/20100101 Firefox/42.0");
                    Driver = new PhantomJSDriver(phantomJsOptions);
                    break;

                default:
                    Console.WriteLine("Not supported browser");
                    Driver = null;
                    break;
            }


            Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["DefaultUrl"]);

            double defaultWaitTime = Convert.ToDouble(ConfigurationManager.AppSettings["DefaultImplicitlyWait"]);
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(defaultWaitTime));
            Driver.Manage().Window.Maximize();
                  
        }
       
        public void Quit()
        {
            Driver.Quit();
        }

        public WebDriverWait Wait()
        {
            var customWait =new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            return customWait;
        }
    }
}
