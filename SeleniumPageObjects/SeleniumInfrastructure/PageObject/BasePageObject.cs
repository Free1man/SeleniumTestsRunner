using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumFramework.SeleniumInfrastructure
{
    public abstract class BasePageObject 
    {

        internal IWebDriver Driver { get; }

        public BasePageObject()
        {
            Driver = DriverContext.Driver;
            PageFactory.InitElements(Driver, this);
        }

    }
}
