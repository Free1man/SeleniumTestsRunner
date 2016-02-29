using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework.SeleniumInfrastructure.Driver;

namespace SeleniumFramework.SeleniumInfrastructure.PageObject
{
    public abstract class BasePageObject
    {
        public IWebDriver Driver
        {
            get
            {
                return DriverContext.Instance.Browser.Driver;
            }
        }
        public BasePageObject()
        {
            PageFactory.InitElements(Driver, this);
        }

    }
}
