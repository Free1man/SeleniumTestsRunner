using OpenQA.Selenium;

namespace SeleniumPageObjects
{
    public interface ISeleniumRunner
    {
        IWebDriver Driver { get; }
        void Close();
    }

}