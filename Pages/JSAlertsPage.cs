using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class JSAlertsPage
    {
        private readonly IWebDriver _driver;
#pragma warning disable CS0649
        [FindsBy(How = How.CssSelector, Using = "button[onclick='jsAlert()']")]
        private readonly IWebElement _btnJSAlert;

        [FindsBy(How = How.CssSelector, Using = "button[onclick='jsConfirm()']")]
        private readonly IWebElement _btnJSConfirm;

        [FindsBy(How = How.CssSelector, Using = "button[onclick='jsPrompt()']")]
        private readonly IWebElement _btnJSPrompt;

        [FindsBy(How = How.Id, Using = "result")]
        private readonly IWebElement _lblResult;
#pragma warning restore CS0649
        private IAlert _alert;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public JSAlertsPage(IWebDriver driver)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
            if (_btnJSAlert == null || _btnJSConfirm == null || _btnJSPrompt == null || _lblResult == null)
            {
                throw new NoSuchElementException("One or more elements on JSAlertsPage were not found.");
            }
        }

        public void TriggerJSALert(string alertType)
        {
            switch (alertType)
            {
                case "JS Alert":
                    _btnJSAlert.Click();
                    break;

                case "JS Confirm":
                    _btnJSConfirm.Click();
                    break;

                case "JS Prompt":
                    _btnJSPrompt.Click();
                    break;

                default:
                    throw new ArgumentException("Invalid alert type specified");
            }
        }

        public string GetResultText() => _lblResult.Text;

        public void InteractWithAlert(string interaction)
        {
            _alert = _driver.SwitchTo().Alert();
            switch (interaction)
            {
                case "OK":
                    _alert.Accept();
                    break;

                case "CANCEL":
                    _alert.Dismiss();
                    break;

                default:
                    throw new ArgumentException($"{interaction} is not a valid interaction");
            }
        }

        public void EnterTextIntoAlert(string inputText)
        {
            _alert = _driver.SwitchTo().Alert();
            _alert.SendKeys(inputText);
            _alert.Accept();
        }
    }
}
