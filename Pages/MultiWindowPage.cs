using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class MultiWindowPage
    {
        private readonly IWebDriver _driver;
#pragma warning disable CS0649
        [FindsBy(How = How.CssSelector, Using = "div[class='example'] a")]
        private readonly IWebElement _btnClickHere;


        [FindsBy(How = How.CssSelector, Using = "h3")]
        private readonly IWebElement _lblH3;
#pragma warning restore CS0649
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MultiWindowPage(IWebDriver driver)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void OpenClickHereLink() => _btnClickHere.Click();

        public void SwitchToTab(string tabId)
        {
            string[] windowHandle = _driver.WindowHandles.ToArray();
            switch (tabId.ToLower())
            {
                case "newly opened":
                    _driver.SwitchTo().Window(windowHandle[1]);
                    break;

                case "previous":
                    _driver.SwitchTo().Window(windowHandle[0]);
                    break;
            }
        }
        public string GetHeaderText() => _lblH3.Text;

    }
}
