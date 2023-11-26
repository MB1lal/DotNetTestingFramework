using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace DotNetTestingFramework.Tests.SeleniumTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureTag("@Heroku", "@hover")]
    [Category("Selenium")]
    internal class HoverTests : BaseSteps
    {
        private int getId(string profile)
        {
            switch (profile)
            {
                case "first":
                   return 0;

                case "second":
                    return 1;

                case "third":
                    return 2;
                  
                default:
                    logger.Error("Invalid profile specified");
                    throw new ArgumentException();
            }
        }

        [TestCase(null, TestName = "Verify all names are correct on hovering over profile images")]
        public void VerifyProfileTextOnHover(object? ignored)
        {
            try
            {
                NavigateToPage("Hovers");

                HoverPage hoverPage = new HoverPage(driver);

                if (hoverPage == null)
                {
                    logger.Error("Failed to initialize HoverPage");
                    Assert.Fail("Failed to initialize HoverPage");
                }

                var profiles = new Dictionary<string, string>
            {
                { "first", "name: user1" },
                { "second", "name: user2" },
                { "third", "name: user3" }
            };

                foreach (var (profile, expectedText) in profiles)
                {
                    logger.Info($"Hovering over {profile} profile");
                    hoverPage.HoverOverUserAvatar(profile);
                    logger.Info("Verifying profile text");
                    Assert.That(hoverPage.GetProfileText(getId(profile)), Is.EqualTo(expectedText));
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Test failed: {ex.Message}");
                throw; // Re-throw the exception to mark the test as failed
            }
        }
    }

}
