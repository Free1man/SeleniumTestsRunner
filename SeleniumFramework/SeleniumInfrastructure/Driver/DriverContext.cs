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
            Settings = settings;
            _appWorkingDirectoryService = appWorkingDirectoryService;

            _appWorkingDirectoryService.SetCurrentDirectory();
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

        public Settings Settings;

        public Browser Browser { get; private set; }

        public Browser SetBrowser(Browser.BrowserType browserType = Browser.BrowserType.ReadFromSettings)
        {
            Browser = _browserService.GetBrowser(browserType);
            if (Settings.UseLogging)
            {
                var logger = new LoggingService(Browser, Settings.TestFolder);
            }
            return Browser;
        }

        private readonly IBrowserService _browserService;
        private readonly IAppWorkingDirectoryService _appWorkingDirectoryService;
    }
}
