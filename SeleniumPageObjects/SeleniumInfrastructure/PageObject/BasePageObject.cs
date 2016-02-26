using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumFramework.SeleniumInfrastructure
{
    public abstract class BasePageObject
    {
        public EventFiringWebDriver Driver
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
