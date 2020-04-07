using OpenQA.Selenium;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    public interface IBrowserOptions
    {
        ISettings Settings { get; set; }

        DriverOptions GetOptions();
    }
}