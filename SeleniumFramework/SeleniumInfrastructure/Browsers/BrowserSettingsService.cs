using OpenQA.Selenium;
using SeleniumFramework.SeleniumInfrastructure.Config;
using SeleniumFramework.SeleniumInfrastructure.Logging;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    public class BrowserSettingsService
    {
             
        public void SetBrowserSettings(IWebDriver driver, Settings settings)
        {
            driver.Manage().Timeouts().ImplicitlyWait(settings.ImplicitWaitTime);

            driver.Url = settings.Url;

            if (settings.UseLogging)
            {
                var logger = new LoggingService(new Browser(driver));
            }
        }
    }
}
