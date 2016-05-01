using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using SeleniumFramework.SpecflowContext;
using System;
using System.Drawing.Imaging;
using System.IO;
using RelevantCodes.ExtentReports;

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
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd");
            string fileName = "Exception-" + timestamp + ".png";
            Directory.CreateDirectory(timestamp);
            string dir = Directory.GetCurrentDirectory() + "\\" + timestamp;
            Directory.SetCurrentDirectory(dir);
            EventFiringDriver.GetScreenshot().SaveAsFile(fileName, ImageFormat.Png);
            GenerateReprot(dir, fileName);
        }

        private static void GenerateReprot(string testFolder, string fileName)
        {
            var report = new ExtentReports(testFolder + "\\testReprot.html");
            var test = report.StartTest(CurrentTestContext.TestName, "");
            test.Log(LogStatus.Fail, "Snapshot below: " + test.AddScreenCapture(testFolder + "\\" + fileName));
            test.AddScreencast(testFolder);
            report.EndTest(test);
            report.Flush();
            report.Close();

        }


    }
}
