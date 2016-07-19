using OpenQA.Selenium;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Browsers
{
    internal interface IDriverService
    {
        IWebDriver GetDriver(string browser);
    }
}
