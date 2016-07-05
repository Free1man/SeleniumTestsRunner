using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework.SeleniumInfrastructure.PageObject;

namespace PageObjects.Google
{
    public class GoogleMainPage : BasePageObject
    {
        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement txtSearch { get; set; }

        public void Search(string textToSearch)
        {
            txtSearch.SendKeys(textToSearch);
            txtSearch.SendKeys(Keys.Enter);
        }

        public void ClickSearchResultLink(string linkToClickText)
        {
            var linkToClick = Driver.FindElement(By.LinkText(linkToClickText));
            linkToClick.Click();
        }

        public bool CheckLinkPresence(string linkToCheckText)
        {
            return Driver.FindElement(By.LinkText(linkToCheckText)).Displayed;
        }
    }
}