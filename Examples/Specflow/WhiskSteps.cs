using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjects.Whisk;
using SeleniumTestsRunner.TestRunnerInfrastructure.Runner;
using TechTalk.SpecFlow;

namespace Examples.Specflow
{
    [Binding]
    public sealed class WhiskSteps
    {
        private readonly SeleniumRunner _runner = SeleniumRunner.Instance;
        HomePage _homePage = new HomePage();

        [BeforeScenario]
        public void BeforeScenario()
        {
            _runner.StartBrowser();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _runner.CloseBrowser();
        }

        [StepDefinition(@"I login as (.*) with password (.*)")]
        public void GivenILoginAsWith(string userId, string password)
        {
            var loginPage = new LoginPage();
            loginPage.Login(userId, password);
        }


        [StepDefinition(@"I create list with next name (.*)")]
        public void WhenICreateListWithNextName(string listName)
        {
            _homePage.CreateList(listName);
        }

        [StepDefinition(@"I add next items to exiting (.*) list")]
        public void WhenIAddNextItemsToExitingList(string listName, Table table)
        {
            foreach (var row in table.Rows)
            {
                _homePage.AddItemToList(listName, row[0]);
            }
        }

        [Given(@"I delete all lists except default")]
        public void DeleteAllListsExceptDefault()
        {
            _homePage.DeleteAllListsExceptDefault();
        }

        [Then(@"there is (.*) item\(s\) in the list")]
        public void ThenThereIsItemSInTheList(int expected)
        {
            int actualCount = _homePage.ListItemsCount();
            Assert.AreEqual(expected, actualCount);
        }



    }
}
