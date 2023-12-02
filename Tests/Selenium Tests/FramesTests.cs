using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace DotNetTestingFramework.Tests.Selenium_Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureTag("@Heroku", "@iFrames")]
    [Category("Selenium")]
    internal class FramesTests : BaseSteps
    {
        [TestCase(null, TestName = "Verify text in Nested iFrames")]
        public void VerifyNestedFrames(object? ignored)
        {
            NavigateToPage("Frames");

            logger.Info("Navigating to Nested iFrames page");

            FramesPage framesPage = new(driver);
            framesPage.NavigateToXFramesPage("Nested Frames");

            NestedFramesPage nestedFramesPage = new(driver);

            var frameVerifications = new Dictionary<string, string>
            {
                { "Top Left", "LEFT" },
                { "Top Middle", "MIDDLE" },
                { "Bottom", "BOTTOM" },
                { "Top Right", "RIGHT" }
            };

            foreach (var (frameName, expectedText) in frameVerifications)
            {
                logger.Info($"Verifying text in {frameName} iFrames");
                Assert.That(nestedFramesPage.GetFrameText(frameName), Is.EqualTo(expectedText));
            }

        }

        [TestCase(null, TestName = "Verify text in an iFrame")]
        public void VerifyiFrames(object? ignored)
        {
            NavigateToPage("Frames");

            logger.Info("Navigating to iFrame page");
            FramesPage framesPage = new(driver);
            framesPage.NavigateToXFramesPage("iFrame");

            IFramePage iFramePage = new(driver);
            logger.Info("Switching to iFrame");
            iFramePage.SwitchToIFrame();

            logger.Info("Entering text");
            iFramePage.EnterTextIntoContent("NUnit Automation Framework");

            logger.Info("Verifying text is entered correctly");
            Assert.That(iFramePage.GetContentText(), Is.EqualTo("NUnit Automation Framework"), $"The text in content box is {iFramePage.GetContentText()}");

        }
    }
}
