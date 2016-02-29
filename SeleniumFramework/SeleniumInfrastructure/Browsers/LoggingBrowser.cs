using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using System;
using System.Drawing.Imaging;


namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    public class LoggingBrowser : Browser
    {
        public EventFiringWebDriver EventFiringDriver { get; set; }
        internal LoggingBrowser(IWebDriver driver) : base(driver)
        {
            EventFiringDriver = new EventFiringWebDriver(this.Driver);
            this.Driver = EventFiringDriver;
            EventFiringDriver.ExceptionThrown += Driver_ExceptionThrown;
        }

        private void Driver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");
            EventFiringDriver.GetScreenshot().SaveAsFile("Exception-" + timestamp + ".png", ImageFormat.Png);
        }
    }
}
