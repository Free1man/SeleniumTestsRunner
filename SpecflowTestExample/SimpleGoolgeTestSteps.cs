using NUnit.Framework;
using PageObject.Google;
using SeleniumFramework.SeleniumInfrastructure.Browsers;
using SeleniumFramework.SeleniumInfrastructure.Config;
using SeleniumFramework.SeleniumInfrastructure.Driver;
using SeleniumFramework.SpecflowContext;
using TechTalk.SpecFlow;

namespace SpecflowTestExample
{
    [Binding]
    public sealed class SimpleGoolgeTestSteps
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            DriverContext.Instance.SetBrowser(Browser.BrowserType.ReadFromAppConfig, true);
            DriverContext.Instance.Browser.GoToUrl(Settings.Url);
            //DriverContext.Instance.Browser.SetImplicitlyWaitTime(Settings.ImplicitWaitTime);






            CurrentTestContext.SetTestName(TestContext.CurrentContext.Test.Name);


        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverContext.Instance.Browser.Quit();
            CurrentTestContext.SetTestOutcome(TestContext.CurrentContext.Result.Outcome.Status.ToString());
           
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
