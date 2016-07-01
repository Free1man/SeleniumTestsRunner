using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework.SeleniumInfrastructure.Runner;

namespace SeleniumFramework.SeleniumInfrastructure.PageObject
{
    public abstract class BasePageObject
    {
        public BasePageObject()
        {
            PageFactory.InitElements(Driver, this);
        }

        public IWebDriver Driver => SeleniumDriverRunner.Instance.Browser.Driver;
    }
}