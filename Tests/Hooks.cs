using DotNetTestingFramework.Utils;
using OpenQA.Selenium;

namespace DotNetTestingFramework.Tests
{
    public class Hooks
    {
        private IWebDriver _driver;
        private Browser browser = new Browser();

        protected ExtentReporting extentReporting;

        private bool testIsSelenium()
        {
            return TestContext.CurrentContext.Test.Properties["Category"].Contains("Selenium");
        }

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extentReporting = new ExtentReporting();
            extentReporting.SetupReport();
        }

        [SetUp]
        public void Setup()
        {
            if(testIsSelenium())
            {
                _driver = browser.GetWebDriver("chrome", true, true);
                _driver.Manage().Window.Maximize();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                Constants.SessionVariables.Driver = _driver;
            }
            
        }

        [TearDown]
        public void TearDown()
        {
            if (testIsSelenium())
            {
                _driver.Quit();
            }
               
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extentReporting.Flush();
        }
    }


}
