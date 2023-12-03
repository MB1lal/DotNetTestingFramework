using DotNetTestingFramework.Models;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using System.Text.Json;

namespace DotNetTestingFramework.Tests.API_Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureTag("@User")]
    [Category("UserOperations")]
    [Category("API")]
    internal class UserApiTests : BaseSteps
    {
        [TestCase(null, TestName = "Verify user is able to login")]
        public void UserLoginTest(object? ignored)
        {
            logger.Info("Creating a new user");
            CreateNewUser();
            UserModel model = JsonSerializer.Deserialize<UserModel>(GetUser(Constants.SessionVariables.Username).Content);
            logger.Info("Asserting new user is created");
            Assert.That(model.username.Equals(Constants.SessionVariables.Username));
            logger.Info("Logging in using created user");
            LoginUser(Constants.SessionVariables.Username, Constants.SessionVariables.Password);
        }

        [TestCase(null, TestName = "Verify user is able to logout")]
        public void UserLogoutTest(object? ignored)
        {
            UserLoginTest(ignored);
            LogoutUser();
        }

    }
}
