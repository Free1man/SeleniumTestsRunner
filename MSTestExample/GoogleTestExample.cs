using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObject.Google;
using SeleniumFramework.SeleniumInfrastructure.Browsers;
using SeleniumFramework.SeleniumInfrastructure.Config;
using SeleniumFramework.SeleniumInfrastructure.Driver;

namespace MSTestExample
{
    [TestClass]
    public class GoogleTestExample
    {
        [TestInitialize]
        public void TestInitialize()
        {
            var context = DriverContext.Instance;
            context.SetBrowser(Browser.BrowserType.Firefox, true);
            context.Browser.GoToUrl(context.Settings.Url);
            //DriverContext.Instance.Browser.SetImplicitlyWaitTime(Settings.ImplicitWaitTime);
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
