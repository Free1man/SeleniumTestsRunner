using OpenQA.Selenium;

namespace SeleniumPageObjects
{

    public class SeleniumRunner : ISeleniumRunner
    {
        public IWebDriver Driver { get; }

        private SeleniumRunnerInitialisationParameters _initParms;

        public SeleniumRunnerInitialisationParameters InitParms
        {
            get
            {
                _initParms = new SeleniumRunnerInitialisationParameters();
                return _initParms;
            }
            set
            {
                _initParms = this.InitParms;
            }         
        }

        public SeleniumRunner()
        {
            Driver = new DriverService().GetBrowserForDriver(InitParms.Browser);
            Driver.Navigate().GoToUrl(InitParms.Url);
            Driver.Manage().Timeouts().ImplicitlyWait(InitParms.ImplicitWaitTime);
        }

        public SeleniumRunner(SeleniumRunnerInitialisationParameters initParms) 
        {
            Driver = new DriverService().GetBrowserForDriver(initParms.Browser);
            Driver.Navigate().GoToUrl(initParms.Url);
            Driver.Manage().Timeouts().ImplicitlyWait(initParms.ImplicitWaitTime);
        }


        public void Quit()
        {
            Driver.Quit();
        }

    }
}
