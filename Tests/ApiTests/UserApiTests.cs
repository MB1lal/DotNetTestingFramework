using DotNetTestingFramework.Models;
using System.Text.Json;

namespace DotNetTestingFramework.Tests.ApiTests
{
    [TestFixture]
    [Category("UserOperations")]
    [Parallelizable(ParallelScope.Fixtures)]
    internal class UserApiTests : BaseSteps
    {


        [Test]
        public void UserLoginTest()
        {
            createNewUser();
            UserModel model = JsonSerializer.Deserialize<UserModel>(getUser(Constants.SessionVariables.Username).Content);
            Assert.That(model.username.Equals(Constants.SessionVariables.Username));
            loginUser(Constants.SessionVariables.Username, Constants.SessionVariables.Password);
        }

        [Test] 
        public void UserLogoutTest() 
        {
            UserLoginTest();
            logoutUser();
        }
        
    }
}
