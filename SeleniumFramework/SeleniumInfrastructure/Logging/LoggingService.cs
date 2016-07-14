using System.Drawing.Imaging;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium;

namespace SeleniumFramework.SeleniumInfrastructure.Logging
{
    internal class LoggingService : ILoggingService
    {
        private EventFiringWebDriver _loggingDriver;       

        public IWebDriver EnableLoggingForDriver(IWebDriver driver)
        {   
            _loggingDriver = new EventFiringWebDriver(driver);
            driver = _loggingDriver;
            _loggingDriver.ExceptionThrown += LoggingDriver_ExceptionThrown;
            return driver;
        }

        private void LoggingDriver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            _loggingDriver.GetScreenshot().SaveAsFile("failScreenshot.png", ImageFormat.Png);
        }

    }
}