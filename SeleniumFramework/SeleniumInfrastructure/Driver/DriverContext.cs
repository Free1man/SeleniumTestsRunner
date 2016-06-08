using SeleniumFramework.SeleniumInfrastructure.Browsers;
using SeleniumFramework.SeleniumInfrastructure.Config;
using SeleniumFramework.SeleniumInfrastructure.AppDirectory;
using SeleniumFramework.SeleniumInfrastructure.Logging;

namespace SeleniumFramework.SeleniumInfrastructure.Driver
{
    public class DriverContext
    {
        private static DriverContext _instance;
        
        private DriverContext(IBrowserService browserService, Settings settings, IAppWorkingDirectoryService appWorkingDirectoryService)
        {
            _browserService = browserService;
            _settings = settings;
            appWorkingDirectoryService.SetCurrentDirectory();
        }

        public static DriverContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    var settings = new Settings();
                    var browserService = new BrowserService(settings);
                    var appWorkingDirectoryService = new AppWorkingDirectoryService(settings);

                   _instance = new DriverContext(browserService, settings, appWorkingDirectoryService);                    
                }
                return _instance;
            }
        }

        public Browser Browser { get; private set; }

        public Browser SetBrowser(Browser.BrowserType browserType = Browser.BrowserType.ReadFromSettings)
        {
            Browser = _browserService.GetBrowser(browserType);
            Browser.Driver.Manage().Timeouts().ImplicitlyWait(_settings.ImplicitWaitTime);
            Browser.Driver.Url = _settings.Url;

            if (Settings.UseLogging)
            {
                var logger = new LoggingService(Browser);
            }
            return Browser;
        }

        private readonly IBrowserService _browserService;
        private readonly Settings _settings;
    }
}
