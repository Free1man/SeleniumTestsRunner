using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;

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

        /// <param name="testPassed">'true' - test passed, 'false' - test failed </param>
        public void SendTestResultsToSauceLabs(bool testPassed)
        {
            try
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript("sauce:job-result=" + (testPassed ? "passed" : "failed"));
            }
            catch (InvalidOperationException e)
            {
                Trace.WriteLine("Failed to send test result to Saucelabs. " + e.Message);
            }
        }
    }
}
