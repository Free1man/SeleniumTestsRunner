using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using SeleniumFramework.SpecflowContext;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    public class LoggingBrowser : Browser
    {
        public EventFiringWebDriver EventFiringDriver { get; set; }
        internal LoggingBrowser(IWebDriver driver) : base(driver)
        {
            EventFiringDriver = new EventFiringWebDriver(this.Driver);
            this.Driver = EventFiringDriver;
            EventFiringDriver.ExceptionThrown += Driver_ExceptionThrown;
        }

        private void Driver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {            
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");
            string fileName = "Exception-" + timestamp + ".png";
            Directory.CreateDirectory(timestamp);
            string dir = Directory.GetCurrentDirectory() + "\\" + timestamp;
            Directory.SetCurrentDirectory(dir);
            using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\test.htm", FileMode.Append))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine("<H1>"+ CurrentTestContext.TestName + " FAILED </H1>");
                    w.WriteLine(@"<img src="+ fileName + @" alt=""HTML5 Icon"" style=""width: 128px; height: 128px; "">");

                }
            }

            EventFiringDriver.GetScreenshot().SaveAsFile(fileName, ImageFormat.Png);
        }


    }
}
