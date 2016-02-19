using SeleniumFramework.PageObjects.Google;
using SeleniumFramework.SeleniumInfrastructure;
using SeleniumFramework.SeleniumInfrastructure.Config;
using TechTalk.SpecFlow;

namespace SpecflowTestExample
{
    [Binding]
    public sealed class SimpleGoolgeTestSteps
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            BrowserService.OpenBrowser(Browser.BrowserType.ReadFromAppConfig);
            DriverContext.Browser.GoToUrl(Settings.Url);
            DriverContext.Browser.ManageImplicitlyWaitTime(Settings.ImplicitWaitTime);
        }

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
