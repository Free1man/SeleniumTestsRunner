using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTestsRunner.TestRunnerInfrastructure.Runner;
using System;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Helpers
{
    /// <summary>
    ///     Represents class that contains method to wait for angular.
    /// </summary>
    internal class WaitHelpers
    {
        /// <summary>
        ///     Current selenium WebDriver instance.
        /// </summary>
        private IWebDriver Driver => SeleniumRunner.Instance.Browser.Driver;

        /// <summary>
        ///     Current selenium WebDriverWait instance.
        /// </summary>
        private WebDriverWait Wait => SeleniumRunner.Instance.Browser.Wait;

        /// <summary>
        ///     Wait for angular until the animations in angular page.
        ///     Also waits for all API responses to be received.
        /// </summary>
        /// <param name="rootElement">The root element of AngularJS application. Default to [ng-app]</param>
        internal void WaitForAngular(string rootElement = "[ng-app]")
        {
            var script = "function result(){return !window.angular;}; return result()";
            var javascriptExecutor = (IJavaScriptExecutor)Driver;
            var isAngularPage = !Convert.ToBoolean(javascriptExecutor.ExecuteScript(script));
            if (isAngularPage)
            {
                string hasAngularFinishedScript =
                    $@"var callback = arguments[arguments.length - 1];
            var el = document.querySelector('{rootElement}');
            if (!window.angular) {{
                callback('False')
            }}
            if (angular.getTestability) {{
                angular.getTestability(el).whenStable(function(){{callback('True')}});
            }} else {{
                if (!angular.element(el).injector()) {{
                    callback('False')
                }}
                var browser = angular.element(el).injector().get('$browser');
                browser.notifyWhenNoOutstandingRequests(function(){{callback('True')}});
            }}";
                Wait.Until(driver => Convert.ToBoolean(javascriptExecutor.ExecuteAsyncScript(hasAngularFinishedScript)));
            }
        }
    }
}