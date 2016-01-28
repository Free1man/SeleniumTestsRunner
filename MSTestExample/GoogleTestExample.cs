using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumFramework.PageObjects.Google;
using SeleniumFramework.SeleniumInfrastructure;


namespace MSTestExample
{
    [TestClass]
    public class GoogleTestExample
    {
        private ISeleniumRunner _seleniumRunner;

        [TestInitialize]
        public void TestInitialize()
        {
            _seleniumRunner = new SeleniumRunner(new SeleniumRunnerInitialisationParameters { Browser = "Chrome", Url = "https://www.google.co.nz" });         
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _seleniumRunner.Quit();
        }

        [TestMethod]
        public void SimpleGoogleSearch()
        {
            var googleMainPage = new GoogleMainPage(_seleniumRunner);

            googleMainPage.Search("test");
        }      

        [TestMethod]
        public void SimpleGoogleTransalteTest()
        {
            var googleMainPage = new GoogleMainPage(_seleniumRunner);
            var googleTranslatePage = new GoogleTranslatePage(_seleniumRunner);

            googleMainPage.Search("google translate");
            googleMainPage.ClickSearchResultLink("Google Translate");
            googleTranslatePage.TransalteText("Test");

            var result = googleTranslatePage.GetTranslationsResult();
            Console.WriteLine(result);
        }


        
    }
}
