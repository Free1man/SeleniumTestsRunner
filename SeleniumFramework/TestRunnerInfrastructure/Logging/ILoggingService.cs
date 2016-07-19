using OpenQA.Selenium;

namespace SeleniumFramework.SeleniumInfrastructure.Logging
{
    public interface ILoggingService
    {
        IWebDriver EnableLoggingForDriver(IWebDriver driver);
    }
}