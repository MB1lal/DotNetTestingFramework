using DotNetTestingFramework.Models;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using System.Text.Json;

namespace DotNetTestingFramework.Tests.ApiTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureTag("@User")]
    [Category("UserOperations")]
    [Category("api")]
    [Parallelizable(ParallelScope.Fixtures)]
    internal class UserApiTests : BaseSteps
    {
        [TestCase(null, TestName = "Verify user is able to login")]
        public void UserLoginTest(object? ignored)
        {
            logger.Info("Creating a new user");
            createNewUser();
            UserModel model = JsonSerializer.Deserialize<UserModel>(getUser(Constants.SessionVariables.Username).Content);
            logger.Info("Asserting new user is created");
            Assert.That(model.username.Equals(Constants.SessionVariables.Username));
            logger.Info("Logging in using created user");
            loginUser(Constants.SessionVariables.Username, Constants.SessionVariables.Password);
        }

        [TestCase(null, TestName = "Verify user is able to logout")]
        public void UserLogoutTest(object? ignored) 
        {
            UserLoginTest(ignored);
            logoutUser();
        }
        
    }
}
