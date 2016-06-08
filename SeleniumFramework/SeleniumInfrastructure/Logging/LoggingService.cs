﻿using OpenQA.Selenium.Support.Events;
using System.Drawing.Imaging;

namespace SeleniumFramework.SeleniumInfrastructure.Logging
{
    public class LoggingService : ILoggingService
    {
        //TO DO: Will be used for advanced logging
        public LoggingService(Browsers.Browser browser)
        {

            _eventFiringDriver = new EventFiringWebDriver(browser.Driver);
            _eventFiringDriver.ExceptionThrown += Driver_ExceptionThrown;
            //TO DO: unclear logic - fix that later
            browser.Driver = _eventFiringDriver;
        }


        private void Driver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            //Save screenshot for use by external reporting tool.
            _eventFiringDriver.GetScreenshot().SaveAsFile("failScreenshot.png", ImageFormat.Png);
        }

        private EventFiringWebDriver _eventFiringDriver;
    }
}
