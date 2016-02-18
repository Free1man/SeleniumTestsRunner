using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework.SeleniumInfrastructure;

namespace SeleniumFramework.PageObjects.Google 
{
   

    public class GoogleMainPage : BasePageObject
    { 
        
        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement txtSearch { get; set; }
                
        public void Search (string textToSearch)
        {
            txtSearch.SendKeys(textToSearch);
            txtSearch.SendKeys(Keys.Enter);
        }

        public void ClickSearchResultLink(string linkToClickText)
        {
            var linkToClick = DriverContext.Driver.FindElement(By.LinkText(linkToClickText));
            linkToClick.Click();
        }

        public void CheckLinkPresence(string linkToCheckText)
        {
            var linkToCheck = DriverContext.Driver.FindElement(By.LinkText(linkToCheckText)).Displayed;
        }

    }
}
