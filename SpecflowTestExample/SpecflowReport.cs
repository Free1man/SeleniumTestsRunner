using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using TechTalk.SpecFlow;

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
            test = report.StartTest(TestContext.CurrentContext.Test.FullName, "");
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
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stepname = ScenarioStepContext.Current.StepInfo.Text;
            LogStatus logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    break;
              default:
                    logstatus = LogStatus.Pass;
                    break;
            }

            test.Log(logstatus, stepname);

            report.EndTest(test);
            report.Flush();

        }
    }
}
