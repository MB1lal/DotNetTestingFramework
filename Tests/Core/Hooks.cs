using DotNetTestingFramework.Utils;
using NLog;
using OpenQA.Selenium;
using Configuration = DotNetTestingFramework.Utils.Configuration;


namespace DotNetTestingFramework.Tests.Core
{
    public class Hooks
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        [ThreadStatic] protected static IWebDriver driver;
        string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");

       
        private bool isSeleniumTest()
        {
            try
            {
                return Attribute.IsDefined(GetType(), typeof(CategoryAttribute), false) &&
              ((CategoryAttribute)Attribute.GetCustomAttribute(GetType(), typeof(CategoryAttribute))).Name == "Selenium";
            } catch { return false; }
           
        }


        [SetUp]
        public void Setup()
        {
            var config = new NLog.Config.XmlLoggingConfiguration("NLog.config");
            LogManager.Configuration = config;

            Constants.SessionVariables.Config = Configuration.LoadConfiguration(absolutePath);

            if (isSeleniumTest())
            {
                Browser browser = new Browser();
                logger.Info("Test detected as 'Selenium' based");
                driver = browser.GetWebDriver(Constants.SessionVariables.Config.webBrowser.BrowserName,
                                                 Constants.SessionVariables.Config.webBrowser.IsHeadless,
                                                 Constants.SessionVariables.Config.webBrowser.IsPrivate);
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
