﻿using OpenQA.Selenium;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    public class InternetExplorerOptions : IBrowserOptions
    {
        public ISettings Settings { get; set; }

        public DriverOptions GetOptions()
        {
            var options = new OpenQA.Selenium.IE.InternetExplorerOptions();
            options.IgnoreZoomLevel = true;
            return options;
        }
    }
}
