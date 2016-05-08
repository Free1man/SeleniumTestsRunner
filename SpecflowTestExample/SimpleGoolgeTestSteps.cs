using PageObject.Google;
using SeleniumFramework.SeleniumInfrastructure.Browsers;
using SeleniumFramework.SeleniumInfrastructure.Config;
using SeleniumFramework.SeleniumInfrastructure.Driver;
using TechTalk.SpecFlow;

namespace SpecflowTestExample
{
    [Binding]
    public sealed class SimpleGoolgeTestSteps : ExtentBase
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            DriverContext context = DriverContext.Instance;
            Settings settings = context.Settings;
            context.SetBrowser(Browser.BrowserType.Firefox, true);
            context.Browser.GoToUrl(settings.Url);

            context.Browser.SetImplicitlyWaitTime(settings.ImplicitWaitTime);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverContext.Instance.Browser.Quit();
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
