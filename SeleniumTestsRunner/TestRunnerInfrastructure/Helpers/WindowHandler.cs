using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTestsRunner.TestRunnerInfrastructure.Runner;
using System.Collections.Generic;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Helpers
{
    /// <summary>
    ///     This class represents methods to handle the browser windows.
    /// </summary>
    public class WindowHandler
    {
        /// <summary>
        ///     Current selenium WebDriver instance.
        /// </summary>
        private static IWebDriver Driver => SeleniumRunner.Instance.Browser.Driver;

        /// <summary>
        ///     Current selenium WebDriverWait instance.
        /// </summary>
        private static WebDriverWait Wait => SeleniumRunner.Instance.Browser.Wait;


        /// <summary>
        ///     Switch focus to the specific window by title
        /// </summary>
        /// <param name="title">Window title</param>
        public void SwitchToWindowByTitle(string title)
        {
            Wait.Until(driver => WindowSelected(title));
        }

        /// <summary>
        ///     Select window by title
        /// </summary>
        /// <param name="title">title name</param>
        /// <returns>true or false</returns>
        private bool WindowSelected(string title)
        {
            var availableWindows = new List<string>(Driver.WindowHandles);
            foreach (var window in availableWindows)
            {
                Driver.SwitchTo().Window(window);
                if (Driver.Title == title)
                {
                    return true;
                }
            }
            return false;
        }
    }
}