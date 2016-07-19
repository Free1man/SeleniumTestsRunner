using SeleniumTestsRunner.TestRunnerInfrastructure.AppDirectory;
using SeleniumTestsRunner.TestRunnerInfrastructure.Browsers;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Runner
{
    public class SeleniumDriverRunner
    {
        private static SeleniumDriverRunner _instance;

        private readonly IBrowserService _browserService;

        private SeleniumDriverRunner(IBrowserService browserService, IAppWorkingDirectoryService appWorkingDirectoryService)
        {
            _browserService = browserService;
            appWorkingDirectoryService.SetCurrentDirectory();
        }

        public static SeleniumDriverRunner Instance
        {
            get
            {
                if (_instance == null)
                {
                    ISettings settings = new Settings();
                    IBrowserService browserService = new BrowserService(settings);
                    IAppWorkingDirectoryService appWorkingDirectoryService = new AppWorkingDirectoryService(settings.TestFolder);

                    _instance = new SeleniumDriverRunner(browserService, appWorkingDirectoryService);
                }
                return _instance;
            }
        }

        public Browser Browser { get; private set; }

        public Browser SetBrowser(Browser.BrowserType browserType = Browser.BrowserType.ReadFromSettings)
        {
            Browser = _browserService.GetBrowser(browserType);
            return Browser;
        }
    }
}