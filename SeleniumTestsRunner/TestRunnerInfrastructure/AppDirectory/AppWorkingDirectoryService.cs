using System.IO;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.AppDirectory
{
    public class AppWorkingDirectoryService : IAppWorkingDirectoryService
    {
        private readonly string _workingDirectoryPath;

        public AppWorkingDirectoryService(string workingDirectoryPath)
        {
            _workingDirectoryPath = workingDirectoryPath;
        }

        public void SetCurrentDirectory()
        {
            Directory.CreateDirectory(_workingDirectoryPath);
            Directory.SetCurrentDirectory(_workingDirectoryPath);
        }
    }
}