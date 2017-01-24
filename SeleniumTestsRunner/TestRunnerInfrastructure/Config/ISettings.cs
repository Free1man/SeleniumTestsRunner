using System;
using System.Collections.Generic;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Config
{
    public interface ISettings
    {
        bool UseLogging { get; }
        string RemoteDriverHubUrl { get; }
        string Browser { get; }
        string Url { get; }
        string ScreenshotsFolder { get; }
        TimeSpan ImplicitWaitTime { get; }
        string BrowserVer { get; }
        string Platform { get; }
        Dictionary<string, string> AdditionalRemoteDriverCapabilities { get; set; }
    }
}