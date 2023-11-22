using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace DotNetTestingFramework.Tests.SeleniumTests
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
          
            FramesPage framesPage = new FramesPage(driver);
            framesPage.NavigateToXFramesPage("Nested Frames");
           
            NestedFramesPage nestedFramesPage = new NestedFramesPage(driver);

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
                Assert.AreEqual(expectedText, nestedFramesPage.GetFrameText(frameName));
            }

        }

        [TestCase(null, TestName = "Verify text in an iFrame")]
        public void VerifyiFrames(object? ignored)
        {
            NavigateToPage("Frames");

            logger.Info("Navigating to iFrame page");
            FramesPage framesPage = new FramesPage(driver);
            framesPage.NavigateToXFramesPage("iFrame");

            IFramePage iFramePage = new IFramePage(driver);
            logger.Info("Switching to iFrame");
            iFramePage.SwitchToIFrame();

            logger.Info("Entering text");
            iFramePage.EnterTextIntoContent("NUnit Automation Framework");

            logger.Info("Verifying text is entered correctly");
            Assert.AreEqual("NUnit Automation Framework", iFramePage.GetContentText(), $"The text in content box is {iFramePage.GetContentText()}");

        }
    }
}
