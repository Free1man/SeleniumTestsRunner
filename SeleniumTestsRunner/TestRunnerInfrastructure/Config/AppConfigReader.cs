using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using SeleniumTestsRunner.TestRunnerInfrastructure.Logger;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Config
{
    internal class AppConfigReader : IAppConfigReader
    {
        private readonly ILogger _logger;

        public AppConfigReader(ILogger logger = null)
        {
            _logger = logger ?? new CustomLogger();
        }
        public Dictionary<string, string> ReadSectionSettingFromAppConfig(string sectionName)
        {
            var section =
                ConfigurationManager.GetSection(sectionName) as NameValueCollection;
            if (section == null)
            {
                _logger.Log($"Misconfiguration: The {sectionName} section is missing in app.config");
            }
            var setting = section?.AllKeys.ToDictionary(x => x, x => section[x]);
            return setting;
        }

        public TimeSpan ReadTimeSpanSettingFromAppConfig(string settingName, TimeSpan defaultValue)
        {
            TimeSpan setting;
            try
            {
                setting = TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings[settingName]));
                if (setting == TimeSpan.Zero)
                {
                    throw new FormatException();
                }
            }
            catch (FormatException ex)
            {
                _logger.Log("Misconfiguration:" +
                            $" The {settingName} setting in app.config must be TimeSpan non zero value." +
                            $" {settingName} will be set to {defaultValue.Seconds} seconds.");
                _logger.Log("Exception: " + ex.Message);
                setting = defaultValue;
            }
            return setting;
        }

        public bool ReadBoolSettingFromAppConfig(string settingName, bool defaultValue = false)
        {
            var rawSetting = ConfigurationManager.AppSettings[settingName];
            bool setting;
            if (string.IsNullOrWhiteSpace(rawSetting))
            {
                _logger.Log("Misconfiguration: " +
                            $"The {settingName} setting in app.config is not found. " +
                            $"{settingName} will be set to {defaultValue}.");
                setting = defaultValue;
            }
            else
            {
                try
                {
                    setting = Convert.ToBoolean(rawSetting);
                }
                catch (FormatException e)
                {
                    _logger.Log("Misconfiguration: " +
                                $"The {settingName} setting in app.config should be a boolean value. " +
                                $"{settingName} will be set to {defaultValue}.");
                    _logger.Log("Exception: " + e.Message);
                    setting = defaultValue;
                }
            }
            return setting;
        }
        /// <summary>
        /// Find a key in section appSettings in appconfig and read its value as a string.
        /// </summary>
        /// <param name="settingName">Key in appconfig.</param>
        /// <param name="defaultValue">Default value, if not null will be used if faled to read desired setting from appconfig.</param>
        /// <exception cref="ConfigurationErrorsException">Will be thrown if failed to read setting from app config and default value was null.</exception>
        public string ReadStringSettingFromAppConfig(string settingName, string defaultValue = null)
        {
            var setting = ConfigurationManager.AppSettings[settingName];
            if (defaultValue == null && string.IsNullOrWhiteSpace(setting))
            {
                throw new ConfigurationErrorsException($"The {settingName} setting in app.config must be set.");
            }
            if (!string.IsNullOrWhiteSpace(setting))
            {
                return setting;
            }
            _logger.Log($"The {settingName} setting in app.config was not found using default value: {defaultValue}");
            setting = defaultValue;
            return setting;
        }
    }
}