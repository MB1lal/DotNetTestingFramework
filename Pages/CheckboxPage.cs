using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    public class CheckboxPage
    {
        private readonly IWebDriver _driver;
        private readonly static Logger logger = LogManager.GetCurrentClassLogger();
#pragma warning disable CS0649
        [FindsBy(How = How.CssSelector, Using = "#checkboxes > input:first-of-type")]
        private readonly IWebElement checkbox1;

        [FindsBy(How = How.CssSelector, Using = "#checkboxes > input:nth-of-type(2)")]
        private readonly IWebElement checkbox2;
#pragma warning restore CS0649
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CheckboxPage(IWebDriver driver)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void ClickCheckbox(int index)
        {
            switch (index)
            {
                case 1:
                    checkbox1.Click();
                    break;
                case 2:
                    checkbox2.Click();
                    break;
                default:
                    logger.Error("Invalid checkbox specified");
                    throw new ArgumentOutOfRangeException($"{index} checkbox doesn't exist");
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
                    throw new ArgumentOutOfRangeException($"{index} checkbox doesn't exist");
            }
        }
    }
}
