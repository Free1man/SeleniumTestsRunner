using SeleniumPageObjects;
using SeleniumPageObjects.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowTestExample
{
    [Binding]
    public sealed class SimpleGoolgeTestSteps
    {
        
        private ISeleniumRunner _seleniumRunner;

        [BeforeScenario("AppConfig")]
        public void BeforeScenario()
        {
            _seleniumRunner = new SeleniumRunner();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _seleniumRunner.Quit();
        }
      
        [When(@"I type (.*) to search text field")]
        public void WhenITypeToSearchTextField(string textToSearch)
        {
            var googleManiPage = new GoogleMainPage(_seleniumRunner);
            googleManiPage.Search(textToSearch);     
        }

        [Then(@"in text results i should see (.*)")]
        public void ThenInTextResultsIShouldSee(string results)
        {
            var googleManiPage = new GoogleMainPage(_seleniumRunner);
            googleManiPage.CheckLinkPresence(results);
        }

    }
}
