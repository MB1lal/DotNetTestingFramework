using DotNetTestingFramework.Utils;
using NLog;
using OpenQA.Selenium;

namespace DotNetTestingFramework.Tests.Core
{
    public class Hooks
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        [ThreadStatic] protected static IWebDriver driver;

        private Boolean isSeleniumTest()
        {
            // Check if any of the test methods have the "Selenium" category
            return Attribute.IsDefined(GetType(), typeof(CategoryAttribute), false) &&
               ((CategoryAttribute)Attribute.GetCustomAttribute(GetType(), typeof(CategoryAttribute))).Name == "Selenium";
        }


        [SetUp]
        public void Setup()
        {
            var config = new NLog.Config.XmlLoggingConfiguration("NLog.config");
            LogManager.Configuration = config;
            if (isSeleniumTest())
            {
                Browser browser = new Browser();
                logger.Info("Test detected as 'Selenium' based");
                driver = browser.GetWebDriver("Chrome", true, true);
            }
        }

        [TearDown]
        public void TearDown()
        {
            if(isSeleniumTest())
            {
                logger.Info("Quitting browser");
                driver.Quit();
                driver.Dispose();
            }
        }

       
    }


}
