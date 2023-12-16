using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace DotNetTestingFramework.Tests.Selenium_Tests
{
    [TestFixture, Description("Verify hovering scenarios on Heroku Web App")]
    [AllureNUnit]
    [AllureTag("@Heroku", "@hover")]
    [Category("Selenium")]
    internal class HoverTests : BaseSteps
    {
        private static int GetId(string profile)
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
                    throw new Exception("Invalid profile specified");
            }
        }

        [Test, Description("Verify all names are correct on hovering over profile images")]
        public void VerifyProfileTextOnHover()
        {
            try
            {
                NavigateToXPage("Hovers");

                HoverPage hoverPage = new(driver);

                var profiles = new Dictionary<string, string>
            {
                { "first", "name: user1" },
                { "second", "name: user2" },
                { "third", "name: user3" }
            };

                foreach (var (profile, expectedText) in profiles)
                {
                    logger.Info($"Hovering over {profile} profile");
                    hoverPage!.HoverOverUserAvatar(profile);
                    logger.Info("Verifying profile text");
                    Assert.That(hoverPage.GetProfileText(GetId(profile)), Is.EqualTo(expectedText));
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Test failed: {ex.Message}");
                throw;
            }
        }
    }

}
