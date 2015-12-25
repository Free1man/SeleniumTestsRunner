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
        private ISeleniumRunner _runner;

        public GoogleMainPage(ISeleniumRunner runner)
        {
            this._runner = runner;
            PageFactory.InitElements(_runner.Driver, this);
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
            var linkToClick = _runner.Driver.FindElement(By.LinkText(linkToClickText));
            linkToClick.Click();
        }
      
    }
}
