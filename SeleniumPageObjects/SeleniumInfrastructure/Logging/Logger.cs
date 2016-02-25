using OpenQA.Selenium.Support.Events;
using System;
using System.Drawing.Imaging;


namespace SeleniumFramework.SeleniumInfrastructure.Logging
{
    public class Logger
    {
        public EventFiringWebDriver Driver { get; set; }
        public Logger(EventFiringWebDriver driver)
        {
            Driver = driver;
            Driver.ExceptionThrown += Driver_ExceptionThrown;
        }

        private void Driver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");
            Driver.GetScreenshot().SaveAsFile("Exception-" + timestamp + ".png", ImageFormat.Png);
        }
    }
}
