using OpenQA.Selenium;
using System.Collections.Generic;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    public interface IBrowserOptions
    {
        Dictionary<string, string> AdditionalRemoteDriverCapabilities { get; }
        DriverOptions GetOptions();
    }
}