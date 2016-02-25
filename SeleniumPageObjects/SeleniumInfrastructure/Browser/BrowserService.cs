using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Events;
using SeleniumFramework.SeleniumInfrastructure.Config;

namespace SeleniumFramework.SeleniumInfrastructure
{
    static public class BrowserService
    {

        public static void OpenBrowser(Browser.BrowserType browserType)
        {
            switch (browserType)
            {
                case Browser.BrowserType.Firefox:
                    DriverContext.Driver = new EventFiringWebDriver(DriverService.GetBrowserForDriver(browserType.ToString()));
                    break;
                case Browser.BrowserType.Chrome:
                    DriverContext.Driver = new EventFiringWebDriver(DriverService.GetBrowserForDriver(browserType.ToString()));            
                    break;
                case Browser.BrowserType.ReadFromAppConfig:
                    DriverContext.Driver = new EventFiringWebDriver(DriverService.GetBrowserForDriver(Settings.Browser));
                    break;               
            }

        }

    }
}
