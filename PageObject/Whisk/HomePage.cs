using OpenQA.Selenium;
using SeleniumTestsRunner.TestRunnerInfrastructure.PageObject;
using System;
using System.Linq;
using System.Threading;

namespace PageObjects.Whisk
{
    public class HomePage : PageObjectHelper
    {
        private IWebElement ListNameInput => Driver.FindElement(By.XPath("//*[@data-testid='create-new-shopping-list-name-input']//input"));
        private IWebElement AddItemInput => Driver.FindElement(By.XPath("//input[@data-testid ='desktop-add-item-autocomplete']"));

        private const string ListItemXPath = "//*[@data-testid='shopping-lists-list-name']";

        private const string ListItemsXPath = "//*[@data-testid='shopping-list-item']";

        private const string ListThreeDotMenuButtonXpath = "//*[@data-testid='shopping-lists-list-name']/parent::div/following::div[@class= 'sc-1oueva3 ceNMEA']";


        public void CreateList(string listName)
        {
            ClickByText("Create new list");
            //Clear not working -> using workaround
            //ListNameInput.Clear();
            ListNameInput.SendKeys(Keys.Control + "a");
            ListNameInput.SendKeys(Keys.Delete);
            ListNameInput.SendKeys(listName);
            ClickByText("Create");
            var newElementXpath = ListItemXPath + $"[contains(text(), '{listName}')]";
            Wait.Until(driver => driver.FindElement(By.XPath(newElementXpath)).Displayed);
        }

        public void AddItemToList(string listName, string itemName)
        {
            var listXPath = ListItemXPath + $"[contains(text(), '{listName}')]";
            try
            {
                //this may fail if list already selected, this implementation not suitable for real test
                Driver.FindElement(By.XPath(listXPath)).Click();
            }
            catch (Exception)
            {
                //Do nothing
            }
            AddItemInput.SendKeys(itemName);
            //Don't use sleep for real test
            Thread.Sleep(1000);
            AddItemInput.SendKeys(Keys.Enter);
            var newListItemXPath = $"//*[@data-testid = 'shopping-list-item-name'][text()='{itemName}']";
            Wait.Until(driver => driver.FindElement(By.XPath(newListItemXPath)).Displayed);
        }

        public void DeleteAllListsExceptDefault()
        {
            var allElements = Driver.FindElements(By.XPath(ListThreeDotMenuButtonXpath));
            var length = allElements.Count;
            var elementsList
                = allElements.ToList();
            //Removing default list and other button,
            //this is very bad way of doing this,
            //but it is better to improve locator and simplify this part.
            elementsList.RemoveAt(length - 1);
            elementsList.RemoveAt(length - 2);

            foreach (var element in elementsList)
            {
                element.Click();
                //Don't use sleep for real test
                Thread.Sleep(1000);
                ClickByText("Delete list");
                ClickByText("Confirm delete");
                WaitTextIsNotDisplayed("List was deleted");
            }
        }

        public int ListItemsCount()
        {
            return Driver.FindElements(By.XPath(ListItemsXPath)).Count;
        }
    }
}