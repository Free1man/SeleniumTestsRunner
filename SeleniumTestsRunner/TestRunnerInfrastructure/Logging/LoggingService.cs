using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Logging
{
    internal class LoggingService
    {
        private readonly ISettings _settings;
        private EventFiringWebDriver _loggingDriver;

        public LoggingService(ISettings settings)
        {
            _settings = settings;
        }

        public IWebDriver EnableLoggingForDriver(IWebDriver driver)
        {
            _loggingDriver = new EventFiringWebDriver(driver);
            driver = _loggingDriver;
            _loggingDriver.ExceptionThrown += LoggingDriver_ExceptionThrown;
            return driver;
        }

        private void LoggingDriver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            //TODO Consider to move somewere
            var path = _settings.ScreenshotsFolder;
            Directory.CreateDirectory(path);
            _loggingDriver.GetScreenshot().SaveAsFile(path + @"\failScreenshot.png", ImageFormat.Png);
        }
    }
}