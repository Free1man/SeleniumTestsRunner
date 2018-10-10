using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumTestsRunner.TestRunnerInfrastructure.PageObject;


namespace PageObjects.Google
{
    public class GoogleTranslatePage : BasePageObject
    {
        private IWebElement TxtSourceText => Driver.FindElement(By.Id("source"));

        private IWebElement TxtTranslationsResult => Driver.FindElement(By.Id("result_box"));

        public void TransalteText(string textToTranslate)
        {
            TxtSourceText.SendKeys(textToTranslate);
        }

        public string GetTranslationsResult()
        {
            Wait.Until(driver => TxtTranslationsResult.Text.Length > 0);
            return TxtTranslationsResult.Text;
        }

        
    }
}