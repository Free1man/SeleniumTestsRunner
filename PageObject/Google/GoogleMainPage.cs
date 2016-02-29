using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework.SeleniumInfrastructure.PageObject;

namespace PageObject.Google 
{   

    public class GoogleMainPage : BasePageObject
    { 
        
        [FindsBy(How = How.Name, Using = "q1")]
        public IWebElement txtSearch { get; set; }
                
        public void Search (string textToSearch)
        {
            txtSearch.SendKeys(textToSearch);
            txtSearch.SendKeys(Keys.Enter);
        }

        public void ClickSearchResultLink(string linkToClickText)
        {
            var linkToClick = Driver.FindElement(By.LinkText(linkToClickText));
            linkToClick.Click();
        }

        public void CheckLinkPresence(string linkToCheckText)
        {
            var linkToCheck = Driver.FindElement(By.LinkText(linkToCheckText)).Displayed;
        }

    }
}
