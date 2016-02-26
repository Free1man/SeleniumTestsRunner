using OpenQA.Selenium.Support.Events;
using System;
using System.Drawing.Imaging;


namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    public class LoggingBrowser : Browser
    {
        internal LoggingBrowser(EventFiringWebDriver driver) : base(driver)
        {
            this.Driver.ExceptionThrown += Driver_ExceptionThrown;
        }

        private void Driver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");
            Driver.GetScreenshot().SaveAsFile("Exception-" + timestamp + ".png", ImageFormat.Png);
        }
    }
}
