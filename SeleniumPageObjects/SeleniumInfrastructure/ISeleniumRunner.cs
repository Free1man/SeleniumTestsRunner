using OpenQA.Selenium;

namespace SeleniumFramework.SeleniumInfrastructure
{
    public interface ISeleniumRunner
    {
        IWebDriver Driver { get; }
        void Quit();
    }

}