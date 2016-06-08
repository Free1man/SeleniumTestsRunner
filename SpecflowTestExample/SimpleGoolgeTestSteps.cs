using PageObject.Google;
using SeleniumFramework.SeleniumInfrastructure.Browsers;
using SeleniumFramework.SeleniumInfrastructure.Driver;
using TechTalk.SpecFlow;

namespace SpecflowTestExample
{
    [Binding]
    public sealed class SimpleGoolgeTestSteps : ExtentBase
    {
        DriverContext context = DriverContext.Instance;

        [BeforeScenario]
        public void BeforeScenario()
        {                    
            context.SetBrowser(Browser.BrowserType.Firefox);        
        }

        [AfterScenario]
        public void AfterScenario()
        {
            context.Browser.Quit();
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
