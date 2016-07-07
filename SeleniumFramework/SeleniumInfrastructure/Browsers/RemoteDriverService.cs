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
                case "Firefox":
                    //For demo, works only for F46
                    //register Hub - java -jar selenium-server-standalone-2.53.1.jar -role hub
                    //register Node - java -jar selenium-server-standalone-2.53.1.jar -role webdriver -hub http://192.168.1.6:4444/grid/register
                    DesiredCapabilities capabilites = DesiredCapabilities.Firefox();
                    return new RemoteWebDriver(new Uri("http://192.168.1.6:4444/wd/hub"), capabilites);
                default:
                    throw new ArgumentException(browser + "- Not supported browser");
            }
        }
    }
}
