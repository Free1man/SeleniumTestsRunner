using NUnit.Framework;
using PageObjects.Google;
using SeleniumTestsRunner.TestRunnerInfrastructure.Runner;
using TechTalk.SpecFlow;

namespace SpecflowTestExample
{
    [Binding]
    public sealed class SimpleGoolgeTestSteps 
    {
        private readonly SeleniumRunner _runner = SeleniumRunner.Instance;

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
            Assert.IsTrue(googleManiPage.CheckLinkPresence(results));
        }

        [When(@"I click (.*) link")]
        public void WhenIClickLink(string link)
        {
            var googleManiPage = new GoogleMainPage();
            googleManiPage.ClickSearchResultLink(link);
        }

        [When(@"I trying to translate (.*)")]
        public void WhenITryingToTranslate(string textToTranslate)
        {
            var googleTranslatePage = new GoogleTranslatePage();
            googleTranslatePage.TransalteText(textToTranslate);
        }

        [Then(@"I should see (.*) on transaltion page")]
        public void ThenIShouldSee(string translationResult)
        {
            var googleTranslatePage = new GoogleTranslatePage();
            Assert.AreEqual(googleTranslatePage.GetTranslationsResult(), translationResult);
        }

    }
}