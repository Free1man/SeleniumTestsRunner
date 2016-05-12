using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using TechTalk.SpecFlow;
using System.Drawing;
using System;

namespace SpecflowTestExample
{
    internal class ExtentManager
    {      
        private static readonly ExtentReports _instance =
            new ExtentReports(Directory.GetCurrentDirectory() + "\\ExtentReports.html", DisplayOrder.OldestFirst);

        static ExtentManager() { }

        private ExtentManager() { }

        public static ExtentReports Instance
        {
            get
            {
                return _instance;
            }
        }
    }

    public abstract class ExtentBase
    {
        protected ExtentReports report;
        protected ExtentTest test;


        [BeforeScenario]
        public void BeforeScenarioR()
        {
            report = ExtentManager.Instance;
            test = report.StartTest(TestContext.CurrentContext.Test.Name, "");
        }

        [AfterScenario]
        public void AfterScenarioR()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
            LogStatus logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    AddScreenshotToReport();
                    break;
                case TestStatus.Inconclusive:
                    logstatus = LogStatus.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = LogStatus.Skip;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }

            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);

            report.EndTest(test);
            report.Flush();
        }

        [AfterStep]
        public void AfterStepR()
        {
            var stepname = ScenarioStepContext.Current.StepInfo.Text;

            if (ScenarioContext.Current.TestError != null)
            {
                test.Log(LogStatus.Fail, stepname);

                report.EndTest(test);
                report.Flush();
            }
            else
            {
                test.Log(LogStatus.Pass, stepname);

                report.EndTest(test);
                report.Flush();

            }
        }

        private void AddScreenshotToReport()
        {
           
            var screenshotPath = Directory.GetCurrentDirectory() + "\\" + "failScreenshot.png";
           
            if (File.Exists(screenshotPath))
            {
                Image screenshot = new Bitmap(screenshotPath);
                using (MemoryStream ms = new MemoryStream())
                {
                    // Convert Image to byte[]
                    screenshot.Save(ms, screenshot.RawFormat);
                    byte[] imageBytes = ms.ToArray();

                    // Add screenshot to report
                    test.Log(LogStatus.Fail, "Snapshot below: " + test.AddBase64ScreenCapture("data: image / png; base64," + Convert.ToBase64String(imageBytes)));
                }

                screenshot.Dispose();
                File.Delete(screenshotPath);

            }         
        }
    }
}
