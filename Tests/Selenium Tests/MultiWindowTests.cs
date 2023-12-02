using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace DotNetTestingFramework.Tests.Selenium_Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureTag("@Heroku", "@MultiWindow")]
    [Category("Selenium")]
    internal class MultiWindowTests : BaseSteps
    {
        [TestCase(null, TestName = "Verify navigation between multiple tabs in a browser")]
        public void VerifyMultipleTabsHandling(object? ignored)
        {
            NavigateToPage("multiple windows");
            MultiWindowPage multiWindowPage = new(driver);

            logger.Info("Clicking button to open link in a new tab");
            multiWindowPage.OpenClickHereLink();
            logger.Info("Switching to newly opened tab");
            multiWindowPage.SwitchToTab("newly opened");
            logger.Info("Verifying text on newly opened tab");
            Assert.That(multiWindowPage.GetHeaderText(), Is.EqualTo("New Window"));
            logger.Info("Switching to previous opened tab");
            multiWindowPage.SwitchToTab("previous");
            logger.Info("Verifying text on previous tab");
            Assert.That(multiWindowPage.GetHeaderText(), Is.EqualTo("Opening a new window"));
        }
    }
}
