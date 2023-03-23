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
        private IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Constants.SessionVariables.driver = driver;
        }

        [TearDown]
        public void TearDown()
        {
            //Thread.Sleep(5000);
            driver.Quit();
        }
    }

  
}
