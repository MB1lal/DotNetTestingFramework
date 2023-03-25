using DotNetTestingFramework.Utils;
using OpenQA.Selenium;

namespace DotNetTestingFramework.Tests.SeleniumTests
{
    public class Hooks
    {
        private IWebDriver _driver;
        private Browser browser = new Browser();

        [SetUp]
        public void Setup()
        {
            _driver = browser.GetWebDriver("chrome", true, true);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Constants.SessionVariables.Driver = _driver;
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }

  
}
