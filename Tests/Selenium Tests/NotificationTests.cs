using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace DotNetTestingFramework.Tests.Selenium_Tests
{
    [TestFixture, Description("Heroku notification messages")]
    [AllureNUnit]
    [AllureTag("@Heroku", "@Notifications")]
    [Category("Selenium")]
    internal class NotificationTests : BaseSteps
    {
        [Test, Description("Verify notification messages")]
        public void VerifyNotificationMessages()
        {
            List<string> expectedMessages = new()
            {
                "Action successful",
                "Action unsuccesful, please try again"
            };
            NavigateToXPage("Notification Messages");
            NotificationsPage notificationsPage = new(driver);
            logger.Info("Generating a new notification");
            notificationsPage.GenerateNewNotification();
            logger.Info("Verifying notifcation displayed is one of the correct notification");
            Assert.That(notificationsPage.GetNotificationMessage(), Is.AnyOf(expectedMessages));

            logger.Info("Generating a new notification");
            notificationsPage.GenerateNewNotification();
            logger.Info("Verifying notifcation displayed is one of the correct notification");
            Assert.That(notificationsPage.GetNotificationMessage(), Is.AnyOf(expectedMessages));
        }

    }
}
