using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    internal interface IBrowserService
    {
        Browser GetBrowser(Browser.BrowserType browserType);
        Browser GetBrowser(Browser.BrowserType browserType, bool useLogging);
    }
}
