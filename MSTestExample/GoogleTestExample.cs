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
            _seleniumRunner = new SeleniumRunner(new SeleniumRunnerInitialisationParameters { Browser = "Firefox" });
            //_seleniumRunner = new SeleniumRunner(new SeleniumRunnerInitialisationParameters { Browser = "Firefox", ImplicitWaitTime = 0});
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
