using OpenQA.Selenium;

namespace SeleniumFramework.SeleniumInfrastructure
{
    public class Browser
    {
        private readonly IWebDriver _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        public BrowserType Type { get; set; }

        public enum BrowserType
        {
            Firefox,
            Chrome,
            ReadFromAppConfig
        }

        public void GoToUrl(string url)
        {
            DriverContext.Driver.Url = url;
        }

        public void Quit()
        {
            DriverContext.Driver.Quit();
        }

    }
}
