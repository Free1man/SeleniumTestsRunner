using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using RelevantCodes.ExtentReports;
using SeleniumFramework.SpecflowContext;
using System;
using System.Drawing.Imaging;

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
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd");
            string fileName = "Exception-" + timestamp + ".png";
            _eventFiringDriver.GetScreenshot().SaveAsFile(fileName, ImageFormat.Png);
            GenerateReport(fileName);
        }

        private void GenerateReport(string fileName)
        {
            var report = new ExtentReports(_testFolder + "\\testReprot.html");
            var test = report.StartTest(CurrentTestContext.TestName, "");
            test.Log(LogStatus.Fail, "Snapshot below: " + test.AddScreenCapture(_testFolder + "\\" + fileName));
            test.AddScreencast(_testFolder);
            report.EndTest(test);
            report.Flush();
            report.Close();
        }

        private string _testFolder;
        private EventFiringWebDriver _eventFiringDriver;
    }
}
