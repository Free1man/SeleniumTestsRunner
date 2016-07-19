using OpenQA.Selenium;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Logging
{
    public interface ILoggingService
    {
        IWebDriver EnableLoggingForDriver(IWebDriver driver);
    }
}