using PageObjects.Google;
using SeleniumFramework.SeleniumInfrastructure.Runner;
using TechTalk.SpecFlow;

namespace SpecflowTestExample
{
    [Binding]
    public sealed class SimpleGoolgeTestSteps : ExtentBase
    {
        private readonly SeleniumDriverRunner _runner = SeleniumDriverRunner.Instance;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _runner.SetBrowser();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _runner.Browser.Quit();
        }

        [When(@"I type (.*) in the Search field")]
        public void WhenITypeToSearchTextField(string textToSearch)
        {
            var googleManiPage = new GoogleMainPage();
            googleManiPage.Search(textToSearch);
        }

        [Then(@"I should see (.*) on the webpage")]
        public void ThenInTextResultsIShouldSee(string results)
        {
            var googleManiPage = new GoogleMainPage();
            googleManiPage.CheckLinkPresence(results);
        }
    }
}