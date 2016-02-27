using SeleniumFramework.PageObjects.Google;
using SeleniumFramework.SeleniumInfrastructure.Browsers;
using SeleniumFramework.SeleniumInfrastructure.Config;
using SeleniumFramework.SeleniumInfrastructure.Driver;
using TechTalk.SpecFlow;

namespace SpecflowTestExample
{
    [Binding]
    public sealed class SimpleGoolgeTestSteps
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            DriverContext.Instance.SetBrowser(Browser.BrowserType.ReadFromAppConfig);
            DriverContext.Instance.Browser.GoToUrl(Settings.Url);
            DriverContext.Instance.Browser.SetImplicitlyWaitTime(Settings.ImplicitWaitTime);

        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverContext.Instance.Browser.Quit();
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
