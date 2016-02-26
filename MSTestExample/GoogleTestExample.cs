using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumFramework.PageObjects.Google;
using SeleniumFramework.SeleniumInfrastructure;
using SeleniumFramework.SeleniumInfrastructure.Browsers;
using SeleniumFramework.SeleniumInfrastructure.Config;

namespace MSTestExample
{
    [TestClass]
    public class GoogleTestExample
    {
        [TestInitialize]
        public void TestInitialize()
        {
            DriverContext.Instance.SetBrowser(Browser.BrowserType.ReadFromAppConfig, true);
            DriverContext.Instance.Browser.GoToUrl(Settings.Url);
            DriverContext.Instance.Browser.SetImplicitlyWaitTime(Settings.ImplicitWaitTime);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DriverContext.Instance.Browser.Quit();
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
