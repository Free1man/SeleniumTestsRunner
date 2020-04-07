using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;
using System;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Runner
{
    /// <summary>
    ///     Represents a wrapper around IWebDriver to not expose the selenium library to tests.
    /// </summary>
    public class Browser
    {
        internal Browser(IWebDriver driver, ISettings settings)
        {
            Driver = driver;
            Driver.Url = settings.Url;
            WaitTime = settings.WaitTime;
            Driver.Manage().Timeouts().AsynchronousJavaScript = WaitTime;
            Driver.Manage().Timeouts().ImplicitWait = WaitTime;
        }

        private TimeSpan WaitTime { get; }

        internal IWebDriver Driver { get; }

        internal WebDriverWait Wait => new WebDriverWait(Driver, WaitTime);


        public void MaximiseWindow()
        {
            Driver.Manage().Window.Maximize();
        }

        public void Url(string url)
        {
            Driver.Url = url;
        }
    }
}
