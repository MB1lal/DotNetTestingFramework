using DotNetTestingFramework.Utils;
using NLog;
using OpenQA.Selenium;
using Configuration = DotNetTestingFramework.Utils.Configuration;


namespace DotNetTestingFramework.Tests.Core
{
    public class Hooks
    {
        protected readonly static Logger logger = LogManager.GetCurrentClassLogger();
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [ThreadStatic] protected static IWebDriver driver;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private readonly string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");

        private bool IsSeleniumTest()
        {
            try
            {
                var attribute = Attribute.GetCustomAttribute(GetType(), typeof(CategoryAttribute)) as CategoryAttribute;

                return attribute != null && attribute.Name == "Selenium";
            }
            catch
            {
                return false;
            }
        }


        [SetUp]
        public void Setup()
        {
            var config = new NLog.Config.XmlLoggingConfiguration("NLog.config");
            LogManager.Configuration = config;

            Constants.SessionVariables.Config = Configuration.LoadConfiguration(absolutePath);

            if (IsSeleniumTest())
            {
                logger.Info("Test detected as 'Selenium' based");
                var browserConfig = Constants.SessionVariables.Config.WebBrowser;
                driver = Browser.GetWebDriver(browserConfig.BrowserName, browserConfig.IsHeadless, browserConfig.IsPrivate);
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (IsSeleniumTest())
            {
                logger.Info("Quitting browser");
                driver.Quit();
                driver.Dispose();
            }
        }

    }


}
