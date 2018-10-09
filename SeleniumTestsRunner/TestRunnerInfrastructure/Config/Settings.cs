using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;


namespace SeleniumTestsRunner.TestRunnerInfrastructure.Config
{
    internal class Settings : ISettings
    {
        private Dictionary<string, string> _additionalRemoteDriverCapabilities;
        private TimeSpan _waitTime;
        private string _remoteDriverHubUrl;
        private string _screenshotsFolder;
        private string _url;
        private bool _enableWaitForAngular;
        private readonly IAppConfigReader _appConfigReader;

        public Settings(IAppConfigReader configReader = null)
        {
             _appConfigReader = configReader ?? new AppConfigReader();
        }

        /// <summary>
        ///     Gets a WaitTime data from the app.config file.
        /// </summary>
        public TimeSpan WaitTime
        {
            get
            {
                if (_waitTime != TimeSpan.Zero) return _waitTime;
                _waitTime = _appConfigReader.ReadTimeSpanSettingFromAppConfig("DefaultWaitTime", TimeSpan.FromSeconds(30));
                return _waitTime;
            }
        }

        /// <summary>
        ///     Gets EnableWaitForAngular data from the app.config file, will be defaulted to true if missing.
        /// </summary>
        public bool EnableWaitForAngular
        {
            get
            {
                if (!_enableWaitForAngular)
                {
                    _enableWaitForAngular = _appConfigReader.ReadBoolSettingFromAppConfig("EnableWaitForAngular", true);
                }
                return _enableWaitForAngular;
            }
        }

        /// <summary>
        ///     Gets a ScreenshotsFolder location from the app.config file.
        /// </summary>
        public string ScreenshotsFolder
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_screenshotsFolder))
                {
                    return _screenshotsFolder;
                }
                var defaultValue = CodeBaseString();
                var timeStamp = DateTimeStamp();
                _screenshotsFolder = 
                    _appConfigReader.ReadStringSettingFromAppConfig("ScreenshotsFolder", defaultValue) + timeStamp;
                return _screenshotsFolder;
            }
        }

        protected virtual string DateTimeStamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd-hhmm");
        }

        protected virtual string CodeBaseString()
        {
            return Assembly.GetExecutingAssembly().CodeBase;
        }

        /// <summary>
        ///     Gets a Url data from the app.config file.
        /// </summary>
        public string Url
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_url))
                {
                    _url = _appConfigReader.ReadStringSettingFromAppConfig("DefaultUrl");
                }
                return _url;
            }
        }

        /// <summary>
        ///     Gets a RemoteDriverHubUrl data from the app.config file.
        /// </summary>
        public string RemoteDriverHubUrl
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_remoteDriverHubUrl))
                {
                    _remoteDriverHubUrl = _appConfigReader.ReadStringSettingFromAppConfig("RemoteDriverHubUrl");
                }
                return _remoteDriverHubUrl;
            }
        }

        /// <summary>
        ///     Gets or sets AdditionalRemoteDriverCapabilities data from the app.config file.
        /// </summary>
        public Dictionary<string, string> AdditionalRemoteDriverCapabilities
        {
            get
            {
                if (_additionalRemoteDriverCapabilities != null)
                {
                    return _additionalRemoteDriverCapabilities;
                }
                _additionalRemoteDriverCapabilities = _appConfigReader.ReadSectionSettingFromAppConfig("AdditionalRemoteDriverCapabilities");
                return _additionalRemoteDriverCapabilities;
            }           
        }

        private string _browser;
        public string Browser
        {
            get
            {
                if (_browser != null)
                {
                    return _browser;
                }
                _browser = _appConfigReader.ReadStringSettingFromAppConfig("Browser");
                _browser = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_browser);
                return _browser;
            }
        }

        /// <summary>
        /// Add more capabilities to existing set.
        /// </summary>
        public void ExtendAdditionalRemoteDriverCapabilities(Dictionary<string, string> dictionary)
        {
            dictionary?.ToList().
                        ForEach(x => AdditionalRemoteDriverCapabilities.Add(x.Key, x.Value));
        }      
    }
}