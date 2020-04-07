using OpenQA.Selenium;
using System;
using System.Threading;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.PageObject
{
    /// <summary>
    ///     Represents a class which contains common Selenium methods.
    /// </summary>
    public abstract class PageObjectHelper : BasePageObject
    {

        public void WaitTextIsNotDisplayed(string text)
        {
            int i = 0;
            int elementCount = 0;
            while (i < 10)
            {
                elementCount = Driver.FindElements(By.XPath($"//*[text()='{text}']")).Count;
                if (elementCount == 0)
                {
                    break;
                }
                Thread.Sleep(1000);
                i++;
            }
            if (elementCount != 0)
            {
                throw new Exception($"{text} is displayed");
            }
        }
        public void WaitTextIsDisplayed(string text)
        {
            Wait.Until(Driver => Driver.FindElement(By.XPath($"//*[text()='{text}']")).Displayed);
        }

        public void ClickByText(string textToClick)
        {
            Driver.FindElement(By.XPath($"//*[text()='{textToClick}']")).Click();
        }

    }
}
