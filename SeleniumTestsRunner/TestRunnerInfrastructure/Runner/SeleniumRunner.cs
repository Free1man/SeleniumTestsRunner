using OpenQA.Selenium;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;
using SeleniumTestsRunner.TestRunnerInfrastructure.Drivers;
using System.Collections.Generic;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Runner
{
    /// <summary>
    /// Represents a singleton which manages creating and closing the browser.
    /// </summary>
    public class SeleniumRunner
    {
        private static SeleniumRunner _instance;

        private readonly ISettings _settings;

        private SeleniumRunner(ISettings settings)
        {
            _settings = settings;
        }

        public static SeleniumRunner Instance
        {
            get
            {
                if (_instance == null)
                {
                    ISettings settings = new Settings();
                    _instance = new SeleniumRunner(settings);
                }
                return _instance;
            }
        }

        public Browser Browser { get; private set; }

        /// <summary>
        ///     Creates the browser instance.
        ///     Exception thrown if more than one browser was started.
        /// </summary>
        /// <param name="additionalCapabilities">Additional selenium capabilities specific to test, like Title, Tags, etc.</param>
        public void StartBrowser(Dictionary<string, string> additionalCapabilities = null)
        {
            if (Browser == null)
            {
                _settings.ExtendAdditionalRemoteDriverCapabilities(additionalCapabilities);
                var driverFactory = new RemoteDriverFactory(_settings);
                Browser = new Browser(driverFactory.GetDriver(), _settings);
            }
            else
            {
                throw new WebDriverException("Multiple browser instances for this test has been detected, test will be terminated.");
            }
        }

        public void CloseBrowser()
        {
            Browser.Driver.Quit();
            _instance = null;
        }
    }
}
