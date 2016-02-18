using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumFramework.SeleniumInfrastructure
{
    public abstract class BasePageObject 
    {

        public BasePageObject()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }

    }
}
