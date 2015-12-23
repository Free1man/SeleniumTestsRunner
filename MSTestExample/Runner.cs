using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestExample
{
    public class Runner
    {
        public IWebDriver DefaultBrowser()
        {
            IWebDriver driver = null;
            string caseSwitch = ConfigurationManager.AppSettings["DefaultBrowser"];
            switch (caseSwitch)
            {
                case "Firefox":
                    Console.WriteLine("Starting FireFox browser");
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    Console.WriteLine("Starting Chrome browser");
                    driver = new ChromeDriver();
                    break;

                default:
                    Console.WriteLine("Not supported browser");
                    driver = null;
                    break;
            }

            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["DefaultUrl"]);

            double time = Convert.ToDouble(ConfigurationManager.AppSettings["DefaultImplicitlyWait"]);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(time));

            return driver;
        }       
    }
}
