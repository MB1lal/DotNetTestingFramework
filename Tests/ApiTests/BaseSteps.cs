using DotNetTestingFramework.Connectors;
using DotNetTestingFramework.Models;
using RestSharp;
using System.Text.Json;

namespace DotNetTestingFramework.Tests.ApiTests
{
    internal class BaseSteps : Hooks
    {
        private UserConnector _userConnector = new UserConnector();
        private PetStoreConnector _petStoreConnector = new PetStoreConnector();

        private UserModel createNewUserData()
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

        private PetStoreModel createNewStoreData()
        {
            PetStoreModel petStore = new PetStoreModel();
            petStore.id = Faker.RandomNumber.Next(1,5000);
            petStore.petId = Faker.RandomNumber.Next(1,5000);
            petStore.quantity = Faker.RandomNumber.Next(1, 3);
            petStore.shipDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            petStore.status = "placed";
            petStore.complete = true;
           
            Constants.SessionVariables.PetStore = petStore;

            return petStore;
        }

        protected void createNewUser()
        {
            UserModel userModel = createNewUserData();
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

        protected void createNewPetStoreOder()
        {
            PetStoreModel petStoreModel = createNewStoreData();
            _petStoreConnector.PlaceAnOrder(JsonSerializer.Serialize(petStoreModel));

        }

        protected RestResponse fetchPetStoreOrder(int orderId)
        {
            return _petStoreConnector.FetchOrder(orderId);
        }
        protected RestResponse  fetchInvalidPetStoreOrder(int orderId)
        {
            return _petStoreConnector.FetchDeletedOrder(orderId);
        }

        protected void deletePetStoreOrder(int orderId)
        {
            _petStoreConnector.DeleteOrder(orderId);
        }
    }
}
