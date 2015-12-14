using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumPageObjects.Google
{
    public class GoogleTranslatePage
    {
        public IWebDriver _driver;

        public GoogleTranslatePage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
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
            while(string.IsNullOrWhiteSpace(result) == true)
            {
                result = txtTranslationsResult.Text;
            }

            return result;
        }
    }
}
