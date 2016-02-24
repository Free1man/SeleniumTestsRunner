using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
                    DriverContext.Driver = DriverService.GetBrowserForDriver(browserType.ToString());
                    break;
                case Browser.BrowserType.Chrome:
                    DriverContext.Driver = DriverService.GetBrowserForDriver(browserType.ToString());            
                    break;
                case Browser.BrowserType.ReadFromAppConfig:
                    DriverContext.Driver = DriverService.GetBrowserForDriver(Settings.Browser);
                    break;               
            }

        }
    }
}
