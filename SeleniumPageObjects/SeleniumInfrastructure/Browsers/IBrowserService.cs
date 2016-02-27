namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    internal interface IBrowserService
    {
        Browser GetBrowser(Browser.BrowserType browserType);
        Browser GetBrowser(Browser.BrowserType browserType, bool useLogging);
    }
}
