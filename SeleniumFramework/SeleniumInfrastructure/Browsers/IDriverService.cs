using OpenQA.Selenium;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    interface IDriverService
    {
        IWebDriver GetDriver(string browser);
    }
}
