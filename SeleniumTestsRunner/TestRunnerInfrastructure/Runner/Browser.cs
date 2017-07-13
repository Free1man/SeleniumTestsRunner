using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Runner
{
    /// <summary>
    ///     Represents a wrapper around IWebDriver to not exposing the selenium library to tests
    /// </summary>
    public class Browser
    {
        internal Browser(IWebDriver driver, ISettings settings)
        {
            Driver = driver;
            Driver.Url = settings.Url;
            WaitTime = settings.WaitTime;
            Driver.Manage().Timeouts().SetScriptTimeout(WaitTime);
            Driver.Manage().Timeouts().ImplicitlyWait(WaitTime);
        }

        private TimeSpan WaitTime { get; }

        internal IWebDriver Driver { get; }

        internal WebDriverWait Wait => new WebDriverWait(Driver, WaitTime);

        /// <summary>
        ///     Maximise the current window
        /// </summary>
        public void MaximiseWindow()
        {
            Driver.Manage().Window.Maximize();
        }

        /// <summary>
        ///     Navigate to URL
        /// </summary>
        /// <param name="url">Webpage url</param>
        public void Url(string url)
        {
            Driver.Url = url;
        }
        /// <summary>
        /// Send results to SauceLabs.
        /// </summary>
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
