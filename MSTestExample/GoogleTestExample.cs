using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumPageObjects;
using SeleniumPageObjects.Google;


namespace MSTestExample
{
    [TestClass]
    public class GoogleTestExample
    {
        private ISeleniumRunner _seleniumRunner;

        [TestInitialize]
        public void TestInitialize()
        {
            _seleniumRunner = new SeleniumRunner();
        }
        
        [TestCleanup]
        public void TestCleanup()
        {
            _seleniumRunner.Quit();
        }

        [TestMethod]
        public void SimpleGoogleSearch()
        {
            var googleManiPage = new GoogleMainPage(_seleniumRunner);

            googleManiPage.Search("test");
        }      

        [TestMethod]
        public void SimpleGoogleTransalteTest()
        {
            var googleManiPage = new GoogleMainPage(_seleniumRunner);
            var googleTranslatePage = new GoogleTranslatePage(_seleniumRunner);

            googleManiPage.Search("google translate");
            googleManiPage.ClickSearchResultLink("Google Translate");
            googleTranslatePage.TransalteText("Test");

            var result = googleTranslatePage.GetTranslationsResult();
            Console.WriteLine(result);
        }


        
    }
}
