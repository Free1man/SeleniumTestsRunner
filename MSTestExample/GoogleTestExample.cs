using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using SeleniumPageObjects.Google;

namespace MSTestExample
{
    [TestClass]
    public class GoogleTestExample
    {

        public IWebDriver driver = new FirefoxDriver();


        [TestInitialize]
        public void TestInitialize()
        {
            driver.Navigate().GoToUrl("https://www.google.co.nz/");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Close();
        }

        [TestMethod]
        public void SimpleGoogleSearch()
        {
            var googleManiPage = new GoogleMainPage(driver);

            googleManiPage.Search("test");    
        }

        [TestMethod]
        public void SimpleGoogleTransalteTest()
        {
            var googleManiPage = new GoogleMainPage(driver);
            var googleTranslatePage = new GoogleTranslatePage(driver);

            googleManiPage.Search("google translate");
            googleManiPage.ClickSearchResultLink("Google Translate");
            googleTranslatePage.TransalteText("Test");

            var result = googleTranslatePage.GetTranslationsResult();
            Console.WriteLine(result);
        }
    }
}
