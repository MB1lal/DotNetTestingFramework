using DotNetTestingFramework.Connectors;
using DotNetTestingFramework.Models;
using RestSharp;
using System.Text.Json;

namespace DotNetTestingFramework.Tests.ApiTests
{
    internal class BaseSteps : Hooks
    {
        private UserConnector _userConnector = new UserConnector();

        private UserModel createNewPayload()
        {
            UserModel user = new UserModel();
            user.id = Faker.RandomNumber.Next();
            user.username = Faker.Internet.UserName();
            user.firstName = Faker.Name.First();
            user.lastName = Faker.Name.Last();
            user.email = Faker.Internet.Email();
            user.password = Faker.Internet.DomainWord() + Faker.Internet.UserName();
            user.phone = Faker.Phone.Number();
            user.userStatus = Faker.RandomNumber.Next();

            Constants.SessionVariables.Username = user.username;
            Constants.SessionVariables.Password = user.password;

            return user;
        }

        protected void createNewUser()
        {
            UserModel userModel = createNewPayload();
            _userConnector.CreateNewUser(JsonSerializer.Serialize(userModel));
        }

        protected RestResponse getUser(string username)
        {
            return _userConnector.GetUser(username);
        }

        protected void loginUser(string username, string password)
        {
            Constants.SessionVariables.UserResponse = _userConnector.loginUser(username, password);
        }

        protected void logoutUser()
        {
            _userConnector.logoutUser();
        }
    }
}
