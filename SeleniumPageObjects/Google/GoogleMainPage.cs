using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPageObjects.Google
{
    public class GoogleMainPage
    {
        private IWebDriver _driver;

        public GoogleMainPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        
        [FindsBy(How = How.Id, Using = "lst-ib")]
        public IWebElement txtSearch { get; set; }
                

        [FindsBy(How = How.Id, Using = "lst-ib")]
        public IWebElement mySelect { get; set; }


        public void Search (string textToSearch)
        {
            txtSearch.SendKeys(textToSearch);
        }

        public void ClickSearchResultLink(string linkToClickText)
        {
            var linkToClick = _driver.FindElement(By.LinkText(linkToClickText));
            linkToClick.Click();
        }
      
    }
}
