using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    public class AuthenticationPage
    {
        private readonly IWebDriver _driver;
#pragma warning disable CS0649
        [FindsBy(How = How.Id, Using = "username")]
        private readonly IWebElement _txtUsername;

        [FindsBy(How = How.Id, Using = "password")]
        private readonly IWebElement _txtPassword;

        [FindsBy(How = How.CssSelector, Using = ".fa.fa-2x.fa-sign-in")]
        private readonly IWebElement _btnLogin;

        [FindsBy(How = How.CssSelector, Using = ".icon-2x.icon-signout")]
        private readonly IWebElement _btnLogout;
#pragma warning restore CS0649
        private readonly string loggedInText = "You logged into a secure area!";
        private readonly string loggedOutText = "You logged out of the secure area!";

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AuthenticationPage(IWebDriver driver)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void EnterUsername(string username)
        {
            _txtUsername.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            _txtPassword.SendKeys(password);
        }

        public void ClickLogin()
        {
            _btnLogin.Click();
        }

        public void ClickLogout()
        {
            _btnLogout.Click();
        }

        public bool IsLoggedIn()
        {
            return _driver.PageSource.Contains(loggedInText);
        }

        public bool IsLoggedOut()
        {
            return _driver.PageSource.Contains(loggedOutText);
        }
    }
}
