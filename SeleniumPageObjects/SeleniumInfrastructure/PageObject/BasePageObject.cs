using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumFramework.SeleniumInfrastructure
{
    public abstract class BasePageObject : DriverContext
    {
        public BasePageObject()
        {
            PageFactory.InitElements(Driver, this);
        }

    }
}
