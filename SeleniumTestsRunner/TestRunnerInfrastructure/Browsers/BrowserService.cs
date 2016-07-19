using OpenQA.Selenium;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;
using SeleniumTestsRunner.TestRunnerInfrastructure.Logging;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Browsers
{
    internal class BrowserService : IBrowserService
    {
        private readonly ISettings _settings;

        public BrowserService(ISettings settings)
        {
            _settings = settings;
        }

        public Browser GetBrowser(Browser.BrowserType browserType)
        {
            IWebDriver driver;         

            if (_settings.UseLogging)
            {
                ILoggingService loggingService = new LoggingService();             
                driver = loggingService.EnableLoggingForDriver(SelectDriver(browserType));
            }
            else
            {
                driver = SelectDriver(browserType);
            }
      
            var browserSettingsService = new BrowserSettingsService();
            browserSettingsService.SetBrowserSettings(driver, _settings);

            return new Browser(driver);
        }

        
        private IWebDriver SelectDriver(Browser.BrowserType browserType)
        {
            IWebDriver driver;
            IDriverService driverService;
            if (_settings.UseRemoteBrowser)
            {
                driverService = new RemoteDriverService();
            }
            else
            {
                driverService = new DriverService();
            }
           
            switch (browserType)
            {
                default:
                    driver = driverService.GetDriver(browserType.ToString());
                    break;
                case Browser.BrowserType.ReadFromSettings:
                    driver = driverService.GetDriver(_settings.Browser);
                    break;
            }
            return driver;
        }
    }
}