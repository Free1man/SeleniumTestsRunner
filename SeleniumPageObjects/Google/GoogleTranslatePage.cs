using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPageObjects.Google
{
    public class GoogleTranslatePage
    {
        private ISeleniumRunner _runner;

        public GoogleTranslatePage(ISeleniumRunner runner)
        {
            this._runner = runner;
            PageFactory.InitElements(_runner.Driver, this);
        }

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
            var result = "";
            //TO DO: Fix this    
            while (string.IsNullOrWhiteSpace(result) == true)
            {   
                result = txtTranslationsResult.Text;
            }
            return result;
        }
    }
}
