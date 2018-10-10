using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumTestsRunner.TestRunnerInfrastructure.PageObject;

namespace PageObjects.Google
{
    public class GoogleMainPage : BasePageObject
    {
        private IWebElement TxtSearch => Driver.FindElement(By.Name("q"));

        public void Search(string textToSearch)
        {
            TxtSearch.SendKeys(textToSearch);
            TxtSearch.SendKeys(Keys.Enter);
        }

        public void ClickSearchResultLink(string text)
        {
            string XPath = new XPathConstructor().ConstructXPathFluent(text);
            FindElementByXPath("//*" + XPath).Click();
        }

        public bool CheckTextPresence(string text)
        {
            string XPath = new XPathConstructor().ConstructXPathFluent(text);
            return FindElementByXPath("//*" + XPath).Displayed;
        }
    }
}