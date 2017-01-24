using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumTestsRunner.TestRunnerInfrastructure.PageObject;

namespace PageObjects.Google
{
    public class GoogleTranslatePage : BasePageObject
    {
        [FindsBy(How = How.Id, Using = "source")]
        private IWebElement txtSourceText { get; set; }

        [FindsBy(How = How.Id, Using = "result_box")]
        private IWebElement txtTranslationsResult { get; set; }


        public void TransalteText(string textToTranslate)
        {
            txtSourceText.SendKeys(textToTranslate);
        }

        public string GetTranslationsResult()
        {
            Wait.Until(driver => txtTranslationsResult.Text.Length > 0);
            return txtTranslationsResult.Text;
        }
    }
}