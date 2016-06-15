using System.Drawing.Imaging;
using OpenQA.Selenium.Support.Events;
using SeleniumFramework.SeleniumInfrastructure.Browsers;

namespace SeleniumFramework.SeleniumInfrastructure.Logging
{
    public class LoggingService : ILoggingService
    {
        private readonly EventFiringWebDriver _eventFiringDriver;
        //TO DO: Will be used for advanced logging
        public LoggingService(Browser browser)
        {
            _eventFiringDriver = new EventFiringWebDriver(browser.Driver);
            _eventFiringDriver.ExceptionThrown += Driver_ExceptionThrown;
            //TO DO: unclear logic - fix that later
        }


        private void Driver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            //Save screenshot for use by external reporting tool.
            _eventFiringDriver.GetScreenshot().SaveAsFile("failScreenshot.png", ImageFormat.Png);
        }
    }
}