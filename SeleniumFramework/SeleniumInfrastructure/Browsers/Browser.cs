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

        internal Browser(IWebDriver driver)
        {
            Driver = driver;
        }

        internal IWebDriver Driver { get; set; }

        public void Url(string url)
        {
            Driver.Url = url;
        }

        public void Quit()
        {
            Driver.Quit();
        }
    }
}