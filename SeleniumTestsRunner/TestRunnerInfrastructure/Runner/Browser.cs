using OpenQA.Selenium;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Runner
{
    public class Browser
    {
        internal Browser(IWebDriver driver, ISettings settings)
        {
            Driver = driver;
            //Navigate to url from app.config
            Driver.Url = settings.Url;
            //Set ImplicitWaitTime from app.config
            Driver.Manage().Timeouts().ImplicitlyWait(settings.ImplicitWaitTime);
        }

        internal IWebDriver Driver { get; set; }

        public void Url(string url)
        {
            Driver.Url = url;
        }

        public void MaximiseWindow()
        {
            Driver.Manage().Window.Maximize();
        }
    }
}