namespace SeleniumTestsRunner.TestRunnerInfrastructure.Browsers
{
    internal interface IBrowserService
    {
        Browser GetBrowser(Browser.BrowserType browserType);
    }
}