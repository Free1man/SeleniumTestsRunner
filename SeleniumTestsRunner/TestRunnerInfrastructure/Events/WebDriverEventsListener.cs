using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium.Support.Events;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;
using SeleniumTestsRunner.TestRunnerInfrastructure.Helpers;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Events
{
    /// <summary>
    ///     Represents a Events Provider class for IWebDriver.
    /// </summary>
    internal class WebDriverEventsListener
    {
        private readonly ISettings _settings;
        private readonly EventFiringWebDriver _eventFiringWebDriver;

        public WebDriverEventsListener(ISettings settings, EventFiringWebDriver driver)
        {
            _settings = settings;
            _eventFiringWebDriver = driver;
        }

        public void SubscribeToEvents()
        {
            _eventFiringWebDriver.ExceptionThrown += EventFiringWebDriverExceptionThrown;
            if (_settings.EnableWaitForAngular)
            {
                _eventFiringWebDriver.FindingElement += WaitForAngularBeforeFindingElement;
            }
        }

        private void WaitForAngularBeforeFindingElement(object sender, FindElementEventArgs e)
        {
            var waitHelper = new WaitHelpers();
            waitHelper.WaitForAngular();
        }

        private void EventFiringWebDriverExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            var path = _settings.ScreenshotsFolder;
            Directory.CreateDirectory(path);
            path = Path.GetFullPath(path);
            var screenshotName = "failScreenshot";
            //we are using "name" here because it is the standard capability name for BrowserStack and Saucelabs to identify the name of the test.
            if (_settings.AdditionalRemoteDriverCapabilities.ContainsKey("name"))
            {
                screenshotName = _settings.AdditionalRemoteDriverCapabilities["name"];
                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    screenshotName = screenshotName.Replace(c, '_');
                }
            }
            _eventFiringWebDriver.GetScreenshot().SaveAsFile(path + $@"\{screenshotName}.png");
        }
        
    }
}