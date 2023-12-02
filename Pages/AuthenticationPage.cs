using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    public class AuthenticationPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "username")]
        private readonly IWebElement? _txtUsername;

        [FindsBy(How = How.Id, Using = "password")]
        private readonly IWebElement? _txtPassword;

        [FindsBy(How = How.CssSelector, Using = ".fa.fa-2x.fa-sign-in")]
        private readonly IWebElement? _btnLogin;

        [FindsBy(How = How.CssSelector, Using = ".icon-2x.icon-signout")]
        private readonly IWebElement? _btnLogout;

        private readonly string loggedInText = "You logged into a secure area!";
        private readonly string loggedOutText = "You logged out of the secure area!";

        public AuthenticationPage(IWebDriver driver)
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
