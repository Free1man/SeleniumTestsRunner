using OpenQA.Selenium;
using System.Collections.Generic;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    public interface IBrowser
    {
        Dictionary<string, string> AdditionalRemoteDriverCapabilities { get; }
        DriverOptions GetOptions();
    }
}