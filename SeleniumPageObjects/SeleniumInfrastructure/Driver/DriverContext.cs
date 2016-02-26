using SeleniumFramework.SeleniumInfrastructure.Browsers;

namespace SeleniumFramework.SeleniumInfrastructure
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
            get
            {
                if (_instance == null)
                {
                    _instance = new DriverContext(new BrowserService());
                }

                return _instance;
            }
        }

        public Browser Browser { get { return _browser; } }

        public Browser SetBrowser(Browser.BrowserType browserType)
        {
            return SetBrowser(browserType, false);
        }

        public Browser SetBrowser(Browser.BrowserType browserType, bool useLogging)
        {
            _browser = _browserService.GetBrowser(browserType, useLogging);
            return _browser;
        }

        private Browser _browser;
        private IBrowserService _browserService;
    }
}
