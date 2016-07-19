using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;
using SeleniumTestsRunner.TestRunnerInfrastructure.Runner;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.PageObject
{
    public abstract class BasePageObject
    {
        protected BasePageObject()
        {
            PageFactory.InitElements(Driver, this);
        }

        public IWebDriver Driver => SeleniumDriverRunner.Instance.Browser.Driver;
        //TO DO: Consider to move to other place
        private readonly TimeSpan _waitTime = new Settings().ImplicitWaitTime;
        public WebDriverWait Wait => new WebDriverWait(Driver, _waitTime);
    }
}