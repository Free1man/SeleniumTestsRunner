using SeleniumFramework.PageObjects.Google;
using SeleniumFramework.SeleniumInfrastructure;
using TechTalk.SpecFlow;

namespace SpecflowTestExample
{
    [Binding]
    public sealed class SimpleGoolgeTestSteps
    {
        [AfterScenario]
        public void AfterScenario()
        {
            DriverContext.Browser.Quit();
        }
      
        [When(@"I type (.*) to search text field")]
        public void WhenITypeToSearchTextField(string textToSearch)
        {
            var googleManiPage = new GoogleMainPage();
            googleManiPage.Search(textToSearch);     
        }

        [Then(@"in text results i should see (.*)")]
        public void ThenInTextResultsIShouldSee(string results)
        {
            var googleManiPage = new GoogleMainPage();
            googleManiPage.CheckLinkPresence(results);
        }

    }
}
