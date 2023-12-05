using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class MultiWindowPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "div[class='example'] a")]
        private readonly IWebElement _btnClickHere;


        [FindsBy(How = How.CssSelector, Using = "h3")]
        private readonly IWebElement _lblH3;

        public MultiWindowPage(IWebDriver driver)
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
