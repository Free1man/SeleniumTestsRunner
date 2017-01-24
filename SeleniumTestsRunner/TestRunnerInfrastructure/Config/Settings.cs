using System;
using System.Collections.Generic;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config.Selenium;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config.TestEnvironment;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Config
{
    internal class Settings : ISettings
    {
        public Settings()
        {
            ISeleniumGeneralSettings seleniumGeneralSettings = new SeleniumGeneralSettings();
            Browser = seleniumGeneralSettings.Browser;
            UseLogging = seleniumGeneralSettings.UseLogging;
            ImplicitWaitTime = seleniumGeneralSettings.ImplicitWaitTime;

            ITestEnvironmentSettings testEnvironmentSettings = new TestEnvironmentSettings();
            RemoteDriverHubUrl = testEnvironmentSettings.RemoteDriverHubUrl;
            Url = testEnvironmentSettings.Url;
            ScreenshotsFolder = testEnvironmentSettings.ScreenshotsFolder;
            Platform = testEnvironmentSettings.Platform;
            BrowserVer = testEnvironmentSettings.BrowserVer;
        }


        public string RemoteDriverHubUrl { get; }
        public string Url { get; }
        public string ScreenshotsFolder { get; }
        public bool UseLogging { get; }
        public string Browser { get; }
        public TimeSpan ImplicitWaitTime { get; }
        public string BrowserVer { get; }
        public string Platform { get; }
        public Dictionary<string, string> AdditionalRemoteDriverCapabilities { get; set; }
    }
}