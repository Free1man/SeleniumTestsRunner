using System;
using OpenQA.Selenium.Support.Events;
using RelevantCodes.ExtentReports;


namespace SeleniumFramework.SeleniumInfrastructure.Logging
{
    public class LoggingService : ILoggingService
    {
        //TO DO: Will be used for advanced logging
        public LoggingService(Browsers.Browser browser, string testFolder)
        {
            _testFolder = testFolder;

            _eventFiringDriver = new EventFiringWebDriver(browser.Driver);
            _eventFiringDriver.ExceptionThrown += Driver_ExceptionThrown;
            
            browser.Driver = _eventFiringDriver;
        }


        private void Driver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            var Screenshot = _eventFiringDriver.GetScreenshot().AsBase64EncodedString;
            AddScreenshotToReport(Screenshot);
        }

        private void AddScreenshotToReport(string Screenshot)
        {
            var report = new ExtentReports(_testFolder + "\\SeleniumReprot.html", false);
            var test = report.StartTest(DateTime.Now.ToString("yyyy-MM-dd-hhmm"), "");
            test.Log(LogStatus.Fail, "Snapshot below: " + test.AddBase64ScreenCapture("data: image / png; base64," + Screenshot));
            report.EndTest(test);
            report.Flush();
            report.Close();
        }

        private string _testFolder;
        private EventFiringWebDriver _eventFiringDriver;
    }
}
