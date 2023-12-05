using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class NotificationsPage
    {
        [FindsBy(How = How.CssSelector, Using = "p a")]
        private readonly IWebElement? _btnClickHere;

        [FindsBy(How = How.Id, Using = "flash")]
        private readonly IWebElement? _flashNotification;

        public NotificationsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void GenerateNewNotification() => _btnClickHere.Click();

        public string GetNotificationMessage() => _flashNotification.Text.Replace("\u00D7", "").Trim();
    }
}
