using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumFramework.PageObjects.Google;
using SeleniumFramework.SeleniumInfrastructure;
using SeleniumFramework.SeleniumInfrastructure.Config;

namespace MSTestExample
{
    [TestClass]
    public class GoogleTestExample
    {
        
        [TestInitialize]
        public void TestInitialize()
        {
            BrowserService.OpenBrowser(Browser.BrowserType.ReadFromAppConfig);
            Browser.GoToUrl(Settings.Url);
            Browser.SetImplicitlyWaitTime(Settings.ImplicitWaitTime);       
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Browser.Quit();
        }

        [TestMethod]
        public void SimpleGoogleSearch()
        {
            var googleMainPage = new GoogleMainPage();

            googleMainPage.Search("test");
        }      

        [TestMethod]
        public void SimpleGoogleTransalteTest()
        {
            var googleMainPage = new GoogleMainPage();
            var googleTranslatePage = new GoogleTranslatePage();

            googleMainPage.Search("google translate");
            googleMainPage.ClickSearchResultLink("Google Translate");
            googleTranslatePage.TransalteText("Test");

            var result = googleTranslatePage.GetTranslationsResult();
            Console.WriteLine(result);
        }


        
    }
}
