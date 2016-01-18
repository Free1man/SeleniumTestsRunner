using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPageObjects
{

    public class SeleniumRunner : ISeleniumRunner
    {
        public IWebDriver Driver { get; set; }     

        public SeleniumRunner()
        {          
            Driver = new DriverService().GetBrowserForDriver(ConfigurationManager.AppSettings["DefaultBrowser"]);
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
            var customWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            return customWait;
        }
        
    }
}
