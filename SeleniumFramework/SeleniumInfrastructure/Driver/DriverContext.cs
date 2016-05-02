using SeleniumFramework.SeleniumInfrastructure.Browsers;
using SeleniumFramework.SeleniumInfrastructure.Config;
using SeleniumFramework.SeleniumInfrastructure.Infrastructure;
using SeleniumFramework.SeleniumInfrastructure.Logging;

namespace SeleniumFramework.SeleniumInfrastructure.Driver
{
    public class DriverContext
    {
        private static DriverContext _instance;
        
        private DriverContext(IBrowserService browserService, Settings settings, IInfrastructureService infrastructureService)
        {
            _browserService = browserService;
            Settings = settings;
            _infrastructureService = infrastructureService;

            _infrastructureService.SetCurrentDirectory();
        }

        public static DriverContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    var settings = new Settings();
                    var browserService = new BrowserService(settings);
                    var infrastructureService = new InfrastructureService(settings);

                   _instance = new DriverContext(browserService, settings, infrastructureService);                    
                }
                return _instance;
            }
        }

        public Settings Settings;

        public Browser Browser { get; private set; }

        public Browser SetBrowser(Browser.BrowserType browserType)
        {
            return SetBrowser(browserType, false);
        }

        public Browser SetBrowser(Browser.BrowserType browserType, bool useLogging)
        {
            Browser = _browserService.GetBrowser(browserType);
            if (useLogging)
            {
                var logger = new LoggingService(Browser, Settings.TestFolder);
            }

            return Browser;
        }

        private readonly IBrowserService _browserService;
        private readonly IInfrastructureService _infrastructureService;
    }
}
