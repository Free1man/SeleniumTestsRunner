using System;
using System.Collections.Generic;
using System.Configuration;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Config
{
    public interface IAppConfigReader
    {
        Dictionary<string, string> ReadSectionSettingFromAppConfig(string sectionName);

        TimeSpan ReadTimeSpanSettingFromAppConfig(string settingName, TimeSpan defaultValue);

        bool ReadBoolSettingFromAppConfig(string settingName, bool defaultValue = false);

        /// <summary>
        /// Find a key in section appSettings in appconfig and read its value as a string.
        /// </summary>
        /// <param name="settingName">Key in appconfig.</param>
        /// <param name="defaultValue">Default value, if not null will be used if failed to read desired setting from appconfig.</param>
        /// <exception cref="ConfigurationErrorsException">Will be thrown if failed to read setting from app config and default value was null.</exception>
        string ReadStringSettingFromAppConfig(string settingName, string defaultValue = null);
    }
}