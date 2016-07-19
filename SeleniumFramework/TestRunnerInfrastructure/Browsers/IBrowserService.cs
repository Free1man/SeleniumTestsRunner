namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    internal interface IBrowserService
    {
        Browser GetBrowser(Browser.BrowserType browserType);
    }
}