namespace SeleniumTestsRunner.TestRunnerInfrastructure.Config.TestEnvironment
{
    internal interface ITestEnvironmentSettings
    {
        string ScreenshotsFolder { get; }
        string Url { get; }
        string RemoteDriverHubUrl { get; }
        string Platform { get; }
        string BrowserVer { get; }
    }
}