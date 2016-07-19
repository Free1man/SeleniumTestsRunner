using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Browsers
{
    internal class RemoteDriverService : IDriverService
    {
        public IWebDriver GetDriver(string browser)
        {
            switch (browser)
            {
                case "Firefox":
                    //For demo, works only for F46
                    //register Hub - java -jar selenium-server-standalone-2.53.1.jar -role hub
                    //register Node - java -jar selenium-server-standalone-2.53.1.jar -role webdriver -hub http://192.168.1.6:4444/grid/register
                    DesiredCapabilities capabilites = DesiredCapabilities.Firefox();
                    return new RemoteWebDriver(new Uri("http://192.168.1.6:4444/wd/hub"), capabilites);
                case "Android":
                    //set ANDROID_HOME = C:\Users\Admin\AppData\Local\Android\android - sdk
                    //set PATH=%PATH%;%ANDROID_HOME%\tools;%ANDROID_HOME%\platform - tools
                    //pause
                    DesiredCapabilities capabilitesAndroid =new DesiredCapabilities();
                    capabilitesAndroid.SetCapability("deviceName", "donatello");
                    capabilitesAndroid.SetCapability("platformName", "Android");
                    capabilitesAndroid.SetCapability("appActivity", "Browser");
                    //capabilitesAndroid.SetCapability("appPackage", "Browser");
                    return new RemoteWebDriver(new Uri("http://127.0.0.1:4723/wd/hub"), capabilitesAndroid);

                default:
                    throw new ArgumentException(browser + "- Not supported browser");

            }
        }
    }
}
