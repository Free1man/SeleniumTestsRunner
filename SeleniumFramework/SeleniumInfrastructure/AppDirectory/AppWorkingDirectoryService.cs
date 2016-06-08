using System.IO;

namespace SeleniumFramework.SeleniumInfrastructure.AppDirectory
{
    public class AppWorkingDirectoryService : IAppWorkingDirectoryService
    {
        public AppWorkingDirectoryService(string workingDirectoryPath)
        {
            _workingDirectoryPath = workingDirectoryPath;
        }

        public void SetCurrentDirectory()
        {
            Directory.CreateDirectory(_workingDirectoryPath);
            Directory.SetCurrentDirectory(_workingDirectoryPath);
        }

        private string _workingDirectoryPath;
    }
}
