using System;
using OpenQA.Selenium.Support.Events;
using RelevantCodes.ExtentReports;
using SeleniumFramework.SpecflowContext;

namespace SeleniumFramework.SeleniumInfrastructure.Logging
{
    public class LoggingService : ILoggingService
    {
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
            var report = new ExtentReports(_testFolder + "\\testReprot.html", false);
            var test = report.StartTest(CurrentTestContext.TestName, "");
            test.Log(LogStatus.Fail, "Snapshot below: " + test.AddBase64ScreenCapture("data: image / png; base64," + Screenshot));
            report.EndTest(test);
            report.Flush();
            report.Close();
        }

        private string _testFolder;
        private EventFiringWebDriver _eventFiringDriver;
    }
}
