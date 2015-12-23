using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestExample
{
    public interface ISeleniumRunner
    {
        IWebDriver Driver { get; }
        void Close();
    }

    public class Runner : ISeleniumRunner
    {
        private IWebDriver _driver;

        public IWebDriver Driver
        {
            get
            {
                return _driver;
            }
        }

        public Runner()
        {
            string caseSwitch = ConfigurationManager.AppSettings["DefaultBrowser"];
            switch (caseSwitch)
            {
                case "Firefox":
                    Console.WriteLine("Starting FireFox browser");
                    _driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    Console.WriteLine("Starting Chrome browser");
                    _driver = new ChromeDriver();
                    break;

                default:
                    Console.WriteLine("Not supported browser");
                    _driver = null;
                    break;
            }


            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["DefaultUrl"]);

            double time = Convert.ToDouble(ConfigurationManager.AppSettings["DefaultImplicitlyWait"]);
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(time));
        
            
        }

       
        public void Close()
        {
            _driver.Close();
        }

        public WebDriverWait Wait(IWebDriver driver)
        {
            var customWait =new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return customWait;
        }
    }
}
