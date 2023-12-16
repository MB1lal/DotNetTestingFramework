using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace DotNetTestingFramework.Tests.Selenium_Tests
{
    [TestFixture, Description("Verify login/logout cases for Heroku Web App")]
    [AllureNUnit]
    [AllureTag("@Heroku", "@Login")]
    [Category("Selenium")]
    internal class AuthenticationTests : BaseSteps
    {
        private AuthenticationPage? authenticationPage;


        [TestCase("tomsmith", "SuperSecretPassword!", true, TestName = "Verify successful login")]
        [TestCase("admin", "admin", false, TestName = "Verify unsuccessful login")]
        public void UserAuthenticationTest(string username, string password, bool shouldSucceed)
        {
            NavigateToXPage("Form Authentication");
            authenticationPage = new AuthenticationPage(driver);

            // Log steps
            logger.Info("Entering username");
            authenticationPage.EnterUsername(username);
            logger.Info("Entering password");
            authenticationPage.EnterPassword(password);
            logger.Info("Clicking login");
            authenticationPage.ClickLogin();

            // Verify the login result
            bool actualResult = authenticationPage.IsLoggedIn();
            string expectedResult = shouldSucceed ? "successful" : "unsuccessful";
            Assert.That(actualResult, Is.EqualTo(shouldSucceed), $"User login should be {expectedResult}.");
        }

        [Test, Description("Verify user logout")]
        public void UserLogoutTest()
        {
            UserAuthenticationTest("tomsmith", "SuperSecretPassword!", true);

            // Log out
            logger.Info("Logging out");
            authenticationPage.ClickLogout();

            // Verify logout
            bool actualResult = authenticationPage.IsLoggedOut();
            Assert.That(actualResult, Is.True, "User logout should be successful.");

        }
    }
}
