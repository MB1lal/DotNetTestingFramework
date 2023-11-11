using DotNetTestingFramework.Pages;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace DotNetTestingFramework.Tests.SeleniumTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureTag("@Heroku")]
    [Category("Selenium")]
    [Parallelizable(ParallelScope.Fixtures)]
    internal class AuthenticationTests : BaseSteps
    {
        private HerokuMain? herokuMain;
        private AuthenticationPage? authenticationPage;


        [TestCase("tomsmith", "SuperSecretPassword!", true, TestName = "Verify successful login")]
        [TestCase("admin", "admin", false, TestName = "Verify unsuccessful login")]
        public void UserAuthenticationTest(string username, string password, bool shouldSucceed)
    {
            herokuMain = new HerokuMain();
            herokuMain.NavigateToPage("Form Authentication");
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

        [TestCase(null, TestName = "Verify user logout")]
        public void UserLogoutTest(object? ignored)
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
