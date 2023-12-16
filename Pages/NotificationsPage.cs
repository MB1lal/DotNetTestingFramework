using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DotNetTestingFramework.Pages
{
    internal class NotificationsPage
    {
#pragma warning disable CS0649
        [FindsBy(How = How.CssSelector, Using = "p a")]
        private readonly IWebElement _btnClickHere;

        [FindsBy(How = How.Id, Using = "flash")]
        private readonly IWebElement _flashNotification;
#pragma warning restore CS0649
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public NotificationsPage(IWebDriver driver) => PageFactory.InitElements(driver, this);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void GenerateNewNotification() => _btnClickHere.Click();

        public string GetNotificationMessage() => _flashNotification.Text.Replace("\u00D7", "").Trim();
    }
}
