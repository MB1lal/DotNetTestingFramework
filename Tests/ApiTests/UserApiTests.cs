using DotNetTestingFramework.Models;
using System.Text.Json;

namespace DotNetTestingFramework.Tests.ApiTests
{
    [TestFixture]
    [Category("UserOperations")]
    [Category("api")]
    [Parallelizable(ParallelScope.Fixtures)]
    internal class UserApiTests : BaseSteps
    {


        [Test]
        public void UserLoginTest()
        {
            extentReporting.AddTestCase("Verify user is able to login");
            try
            {
                extentReporting.LogStatusInReport(info, "Creating a new user");
                createNewUser();
                UserModel model = JsonSerializer.Deserialize<UserModel>(getUser(Constants.SessionVariables.Username).Content);
                extentReporting.LogStatusInReport(info, "Response = " + model.ToString);
                Assert.That(model.username.Equals(Constants.SessionVariables.Username));
                extentReporting.LogStatusInReport(info, "Logging in using newly created user");
                loginUser(Constants.SessionVariables.Username, Constants.SessionVariables.Password);

                extentReporting.LogStatusInReport(pass, "User succesfully logged in");
            } catch (Exception ex)
            {
                extentReporting.LogStatusInReport(fail, ex.ToString());
                throw;
            }

        }

        [Test] 
        public void UserLogoutTest() 
        {
            extentReporting.AddTestCase("Verify user is able to logout");
            try
            {
                extentReporting.LogStatusInReport(info, "Creating a new user");
                extentReporting.LogStatusInReport(info, "Logging in using newly created user");
                UserLoginTest();
                extentReporting.LogStatusInReport(info, "Logging out newly created user");
                logoutUser();

                extentReporting.LogStatusInReport(pass, "User succesfully logged out");
            } catch (Exception ex)
            {
                extentReporting.LogStatusInReport(fail, ex.ToString());
                throw;
            }

        }
        
    }
}
