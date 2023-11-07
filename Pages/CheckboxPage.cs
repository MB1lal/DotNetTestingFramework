using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    public class CheckboxPage
    {
        private IWebDriver _driver;
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        [FindsBy(How = How.CssSelector, Using = "#checkboxes > input:first-of-type")]
        private IWebElement? checkbox1;

        [FindsBy(How = How.CssSelector, Using = "#checkboxes > input:nth-of-type(2)")]
        private IWebElement? checkbox2;

        public CheckboxPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void ClickCheckbox(int index)
        {
            switch(index)
            {
                case 1:
                    checkbox1.Click(); 
                    break;
                case 2:
                    checkbox2.Click();
                    break;
                default:
                    logger.Error("Invalid checkbox specified");
                    throw new ArgumentOutOfRangeException("Invalid checkbox specified");
            }
        }

        public bool IsChecked(int index)
        {
            switch (index)
            {
                case 1:
                    return checkbox1.Selected;
                   
                case 2:
                    return checkbox2.Selected;

                default:
                    logger.Error("Invalid checkbox specified");
                    throw new ArgumentOutOfRangeException("Invalid checkbox specified");
            }
        }
    }
}
