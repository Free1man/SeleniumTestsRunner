using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework.SeleniumInfrastructure.PageObject;

namespace PageObjects.Google
{
    public class GoogleTranslatePage : BasePageObject
    {
        [FindsBy(How = How.Id, Using = "source")]
        public IWebElement txtSourceText { get; set; }

        [FindsBy(How = How.Id, Using = "result_box")]
        public IWebElement txtTranslationsResult { get; set; }


        public void TransalteText(string textToTranslate)
        {
            txtSourceText.SendKeys(textToTranslate);
        }

        public string GetTranslationsResult()
        {
            Wait.Until(driver => txtTranslationsResult.Text.Length > 0 ? txtTranslationsResult : null);
            return txtTranslationsResult.Text;
        }
    }
}