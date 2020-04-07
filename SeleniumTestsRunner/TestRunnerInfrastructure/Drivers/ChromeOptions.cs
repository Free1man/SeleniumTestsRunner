using OpenQA.Selenium;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    public class ChromeOptions : IBrowserOptions
    {

        public ISettings Settings { get; set; }

        public DriverOptions GetOptions()
        {
            var options = new OpenQA.Selenium.Chrome.ChromeOptions();
            return options;
        }


    }
}
