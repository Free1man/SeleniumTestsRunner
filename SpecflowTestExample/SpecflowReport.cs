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
            test = report.StartTest(TestContext.CurrentContext.Test.Name, FeatureContext.Current.FeatureInfo.Description);
        }

        [AfterScenario]
        public void AfterScenarioR()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            LogStatus logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
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

            test.Log(logstatus, "Test ended with " + logstatus);
            test.EndTime = DateTime.Now;
            report.Flush();
        }

        [AfterStep]
        public void AfterStepR()
        {
            var stepname = ScenarioStepContext.Current.StepInfo.Text;

            if (ScenarioContext.Current.TestError != null)
            {
                test.Log(LogStatus.Fail, stepname);
                AddScreenshotToReport();
                test.Log(LogStatus.Fail, ScenarioContext.Current.TestError);
                

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
            else
            {
                    test.Log(LogStatus.Fail, "No screenshot to attach");
            }         
        }
    }
}
