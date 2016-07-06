using System.Drawing.Imaging;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium;

namespace SeleniumFramework.SeleniumInfrastructure.Logging
{
    public class LoggingService : ILoggingService
    {
        private EventFiringWebDriver loggingDriver;       

        public IWebDriver EnableLoggingForDriver(IWebDriver driver)
        {   
            loggingDriver = new EventFiringWebDriver(driver);
            driver = loggingDriver;
            loggingDriver.ExceptionThrown += LoggingDriver_ExceptionThrown;
            return driver;
        }

        private void LoggingDriver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            loggingDriver.GetScreenshot().SaveAsFile("failScreenshot.png", ImageFormat.Png);
        }

    }
}