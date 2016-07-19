using OpenQA.Selenium;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Browsers
{
    internal class BrowserSettingsService
    {
        public void SetBrowserSettings(IWebDriver driver, ISettings settings)
        {
            driver.Manage().Timeouts().ImplicitlyWait(settings.ImplicitWaitTime);

            driver.Url = settings.Url;
        }
    }
}