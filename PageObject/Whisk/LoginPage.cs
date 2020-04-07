using OpenQA.Selenium;
using SeleniumTestsRunner.TestRunnerInfrastructure.PageObject;

namespace PageObjects.Whisk
{
    public class LoginPage : PageObjectHelper
    {
        private IWebElement UserIdInput => Driver.FindElement(By.XPath("//*[@data-testid='email-phone-number-auth-input']//input"));

        private IWebElement PasswordInput => Driver.FindElement(By.XPath("//*[@data-testid='auth-password-input']//input"));

        private IWebElement ContinueButton => Driver.FindElement(By.XPath("//button[@data-testid='auth-continue-button']"));

        private IWebElement LoginButton =>
            Driver.FindElement(By.XPath("//button[@data-testid='auth-login-button']"));

        private string _loginSuccessMessage = "You’ve been signed in, welcome back!";


        public void Login(string userId, string password)
        {
            UserIdInput.SendKeys(userId);
            ContinueButton.Click();
            Wait.Until(driver => PasswordInput.Displayed);
            PasswordInput.SendKeys(password);
            LoginButton.Click();
            WaitTextIsDisplayed(_loginSuccessMessage);
            WaitTextIsNotDisplayed(_loginSuccessMessage);
        }
    }
}