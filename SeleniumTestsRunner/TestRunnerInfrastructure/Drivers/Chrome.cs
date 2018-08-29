using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTestsRunner.TestRunnerInfrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Drivers
{
    public class Chrome : IBrowser
    {

        private ISettings _settings;
        
        public Chrome(ISettings settings)
        {
            _settings = settings;
        }
              
        public Dictionary<string,string> AdditionalRemoteDriverCapabilities
        {
            get { return _settings.AdditionalRemoteDriverCapabilities; }
        }

        public DriverOptions GetOptions()
        {
            var options = new ChromeOptions();
            return options;
        }


    }
}
