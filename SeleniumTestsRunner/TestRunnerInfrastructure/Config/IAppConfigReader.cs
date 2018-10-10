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

        string ReadStringSettingFromAppConfig(string settingName, string defaultValue = null);
    }
}