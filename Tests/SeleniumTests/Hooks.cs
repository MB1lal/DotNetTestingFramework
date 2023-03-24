using DotNetTestingFramework.Constants;
using DotNetTestingFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTestingFramework.Tests.SeleniumTests
{
    public class Hooks
    {
        private IWebDriver _driver;


        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-download-notification");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");
            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Constants.SessionVariables.Driver = _driver;
        }

        [TearDown]
        public void TearDown()
        {
            //Thread.Sleep(5000);
            _driver.Quit();
        }
    }

  
}
