using System;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Config.Selenium
{
    internal interface ISeleniumGeneralSettings
    {
        TimeSpan ImplicitWaitTime { get; }
        bool UseLogging { get; }
        string Browser { get; }
    }
}