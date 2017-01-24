using OpenQA.Selenium;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;
using SeleniumTestsRunner.TestRunnerInfrastructure.Logging;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    internal class DriverCreator
    {
        private readonly ISettings _settings;

        public DriverCreator(ISettings settings)
        {
            _settings = settings;
        }

        internal IWebDriver CreateDriverForBrowser()
        {
            IWebDriver driver;
            var driverService = new RemoteDriverService(_settings);
            if (_settings.UseLogging)
            {
                var loggingService = new LoggingService(_settings);
                driver = loggingService.EnableLoggingForDriver(driverService.GetDriver());
            }
            else
            {
                driver = driverService.GetDriver();
            }
            return driver;
        }
    }
}