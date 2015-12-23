using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumPageObjects.Google;


namespace MSTestExample
{
    [TestClass]
    public class GoogleTestExample
    {
        private IWebDriver _driver;

        [TestInitialize]
        public void TestInitialize()
        {
            _driver = new Runner().DefaultBrowser();
        }
        
        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Close();
        }

        [TestMethod]
        public void SimpleGoogleSearch()
        {
            var googleManiPage = new GoogleMainPage(_driver);

            googleManiPage.Search("test");
        }      

        [TestMethod]
        public void SimpleGoogleTransalteTest()
        {
            var googleManiPage = new GoogleMainPage(_driver);
            var googleTranslatePage = new GoogleTranslatePage(_driver);

            googleManiPage.Search("google translate");
            googleManiPage.ClickSearchResultLink("Google Translate");
            googleTranslatePage.TransalteText("Test");

            var result = googleTranslatePage.GetTranslationsResult();
            Console.WriteLine(result);
        }


        
    }
}
