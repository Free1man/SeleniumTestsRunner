using SeleniumFramework.SeleniumInfrastructure.Config;
using System.IO;

namespace SeleniumFramework.SeleniumInfrastructure.AppDirectory
{
    public class AppWorkingDirectoryService : IAppWorkingDirectoryService
    {
        public AppWorkingDirectoryService(Settings settings)
        {
            _settings = settings;
        }

        public void SetCurrentDirectory()
        {
            Directory.CreateDirectory(_settings.TestFolder);
            Directory.SetCurrentDirectory(_settings.TestFolder);
        }

        private Settings _settings;
    }
}
