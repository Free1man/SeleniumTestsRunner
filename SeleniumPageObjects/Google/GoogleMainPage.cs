using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumPageObjects.Google
{
   

    public class GoogleMainPage
    {
        private ISeleniumRunner _runner;

        public GoogleMainPage(ISeleniumRunner runner)
        {
            this._runner = runner;
            PageFactory.InitElements(_runner.Driver, this);
        }
        
        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement txtSearch { get; set; }
                
        public void Search (string textToSearch)
        {
            txtSearch.SendKeys(textToSearch);
            txtSearch.SendKeys(Keys.Enter);
        }

        public void ClickSearchResultLink(string linkToClickText)
        {
            var linkToClick = _runner.Driver.FindElement(By.LinkText(linkToClickText));
            linkToClick.Click();
        }

    }
}
