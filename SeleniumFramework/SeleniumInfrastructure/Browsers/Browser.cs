using OpenQA.Selenium;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    public class Browser
    {
        public enum BrowserType
        {
            Firefox,
            Chrome,
            ReadFromSettings
        }

        internal IWebDriver Driver { get; set; }

        internal Browser(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void Url(string url)
        {
            this.Driver.Url = url;
        }

        public void Quit()
        {
            this.Driver.Quit();
        }

        protected BrowserType _browserType;
    }
}
