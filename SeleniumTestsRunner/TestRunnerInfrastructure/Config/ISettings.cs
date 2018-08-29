using SeleniumTestsRunner.TestRunnerInfrastructure.Drivers;
using System;
using System.Collections.Generic;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Config
{
    /// <summary>
    ///     Represents interface that will define WebDriver configuration.
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        ///     Enbale Wait for Angular for WebDriver, requires EnableEvents = true.
        /// </summary>
        bool EnableWaitForAngular { get;}
        /// <summary>
        ///     Selenium Server hub url.
        /// </summary>
        string RemoteDriverHubUrl { get; }
        /// <summary>
        ///     Webpage under test initial url.
        /// </summary>
        string Url { get; }
        /// <summary>
        ///     Path where screenshots will be created by WebDriver, requires EnableEvents = true..
        /// </summary>
        string ScreenshotsFolder { get; }
        /// <summary>
        /// Used in Browser class to set timeouts for: 
        ///     Driver.Manage().Timeouts().SetScriptTimeout(WaitTime);
        ///     internal WebDriverWait Wait => new WebDriverWait(Driver, WaitTime);
        /// </summary>
        TimeSpan WaitTime { get; }
        /// <summary>
        ///     WebDriver capabilities like browserName,version, platform and etc.
        /// </summary>
        Dictionary<string, string> AdditionalRemoteDriverCapabilities { get; }

        string Browser { get; }

        /// <summary>
        /// Add more capabilities to existing set.
        /// </summary>
        void ExtendAdditionalRemoteDriverCapabilities(Dictionary<string, string> dictionary);
    }
}