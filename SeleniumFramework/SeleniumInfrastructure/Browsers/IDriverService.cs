using OpenQA.Selenium;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    internal interface IDriverService
    {
        IWebDriver GetDriver(string browser);
    }
}
