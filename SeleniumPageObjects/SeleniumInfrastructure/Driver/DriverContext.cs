using SeleniumFramework.SeleniumInfrastructure.Browsers;

namespace SeleniumFramework.SeleniumInfrastructure.Driver
{
    public class DriverContext
    {
        private static DriverContext _instance;
        private DriverContext(IBrowserService browserService)
        {
            _browserService = browserService;
        }

        public static DriverContext Instance
        {
            get { return _instance ?? (_instance = new DriverContext(new BrowserService())); }
        }

        public Browser Browser { get; private set; }

        public Browser SetBrowser(Browser.BrowserType browserType)
        {
            return SetBrowser(browserType, false);
        }

        public Browser SetBrowser(Browser.BrowserType browserType, bool useLogging)
        {
            Browser = _browserService.GetBrowser(browserType, useLogging);
            return Browser;
        }

        private readonly IBrowserService _browserService;
    }
}
