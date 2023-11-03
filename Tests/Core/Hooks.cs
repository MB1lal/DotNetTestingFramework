using DotNetTestingFramework.Utils;
using OpenQA.Selenium;
using System.Reflection;

namespace DotNetTestingFramework.Tests.Core
{
    public class Hooks
    {
        private IWebDriver? _driver;
        private Browser browser = new Browser();
        //Add logger
        
        private Boolean isSeleniumTest()
        {
            // Check if any of the test methods have the "Selenium" category
            return Attribute.IsDefined(GetType(), typeof(CategoryAttribute), false) &&
               ((CategoryAttribute)Attribute.GetCustomAttribute(GetType(), typeof(CategoryAttribute))).Name == "Selenium";
        }

        private void setupBrowser(string browserName, Boolean isHeadless, Boolean isPrivate)
        {
            _driver = browser.GetWebDriver(browserName, isHeadless, isPrivate);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Constants.SessionVariables.Driver = _driver;
        }

        [SetUp]
        public void Setup()
        {
            if (isSeleniumTest())
            {
                setupBrowser("Chrome", true, true);
            }
        }

        [TearDown]
        public void TearDown()
        {
            if(isSeleniumTest() && _driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }
    }


}
