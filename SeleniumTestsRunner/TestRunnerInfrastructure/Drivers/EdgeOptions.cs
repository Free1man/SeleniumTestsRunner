using OpenQA.Selenium;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    public class EdgeOptions : IBrowserOptions
    {
        public ISettings Settings { get; set; }

        public DriverOptions GetOptions()
        {
            return new OpenQA.Selenium.Edge.EdgeOptions();
        }
    }
}
