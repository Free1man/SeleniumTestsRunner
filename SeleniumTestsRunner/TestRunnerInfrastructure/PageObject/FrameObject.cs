using System.Linq;
using OpenQA.Selenium;
using SeleniumTestsRunner.TestRunnerInfrastructure.Helpers;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.PageObject
{
    /// <summary>
    ///     Represents a class which contains common Selenium methods.
    /// </summary>
    public abstract class FrameObject : BasePageObject
    {

        /// <summary>
        ///     Click text when it is displayed.
        ///     Exception will be thrown if there are more than one elements displayed.
        ///     Exception will be thrown if there is no elements found.
        /// </summary>
        /// <param name="text">Text in the clickable elements.</param>
        public void ClickByText(string text)
        {
            var webElements = Driver.FindElements(By.XPath(".//*[text()[contains(.,'" + text + "')]]"));
            var displayedElements = webElements.Count(webElement => webElement.Displayed);
            if (displayedElements == 1)
            {
                var displayedElement = webElements.First(webElement => webElement.Displayed);
                displayedElement.Click();
            }
            else if (displayedElements > 1)
            {
                throw new MoreThanOneElementException("There are " + displayedElements + " elements with the name '" + text + "'found. Unable to proceed further.");
            }
            else
            {
                throw new NoSuchElementException("There are no elements with the name '" + text + "' found. Unable to proceed further.");
            }
        }

        /// <summary>
        ///     Split "link" string by "separator" char to array,
        ///     for each element in array will try to find "LinkText" element on the webpage and click.
        /// </summary>
        /// <param name="links">Link, or links with the separators</param>
        /// <param name="separator">Separator character, default is '>'</param>
        public void ClickLinks(string links, char separator = '>')
        {
            var linksArray = links.Split(separator);
            foreach (var link in linksArray)
            {
                Driver.FindElement(By.LinkText(link)).Click();
            }
        }
        
        /// <summary>
        ///     Return true if one or more text is found in the webpage(even if text occurs multiple times), otherwise return false.
        /// </summary>
        /// <param name="text">Text in the displayed elements.</param>
        public bool TextIsDisplayed(string text)
        {
            var webElements = Driver.FindElements(By.XPath(".//*[text()[contains(.,'" + text + "')]]"));
            return webElements.Count(webElement => webElement.Displayed) > 0;
        }

        /// <summary>
        /// Switch to frame under test.
        /// </summary>
        public abstract void SwitchToFrame();

    }
}
