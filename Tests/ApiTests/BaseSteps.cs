using DotNetTestingFramework.Connectors;
using DotNetTestingFramework.Models;
using OpenQA.Selenium.DevTools.V108.Debugger;
using RestSharp;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace DotNetTestingFramework.Tests.ApiTests
{
    internal class BaseSteps : Hooks
    {
        private UserConnector _userConnector = new UserConnector();
        private PetStoreConnector _petStoreConnector = new PetStoreConnector();
        private PetConnector _petConnector = new PetConnector();

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

        private PetModel createNewPetData()
        {
            PetModel petModel = new PetModel();

            petModel.id = Faker.RandomNumber.Next(1, 5000);
            petModel.status = "Available";
            Category category = new Category();
            category.id = Faker.RandomNumber.Next(1, 5000);
            category.name = Faker.Lorem.Words(1).ToString();
            petModel.category = category;
            petModel.name = Faker.Lorem.Words(1).ToString();
            petModel.photoUrls = new List<string>() { "", ""};
            Tag tag = new Tag();
            tag.id  = Faker.RandomNumber.Next(1, 400);
            tag.name = Faker.Lorem.Words(1).ToString();
            petModel.tags = new List<Tag>() { tag };

            Constants.SessionVariables.PetModel = petModel;

            return petModel;
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

        protected void addNewPetUsingId()
        {
            PetModel petModel = createNewPetData();
            _petConnector.AddAPetUsingId(JsonSerializer.Serialize(petModel));
        }

        protected RestResponse getPetUsingId(int id)
        {
            return _petConnector.GetPetUsingId(id);
        }

        protected void addNewPetWithStatus(string status)
        {
            PetModel petModel = createNewPetData();
            petModel.status = status;
            _petConnector.AddAPetUsingId(JsonSerializer.Serialize(petModel));
        }

        protected RestResponse getPetUsingStatus(string status)
        {
            return _petConnector.GetPetUsingStatus(status);
        }

        protected void deletePetData(int id)
        {
            _petConnector.DeletePetUsingId(id);
        }

        protected RestResponse getDeletedPetUsingId(int id)
        {
            return _petConnector.GetDeletedPetUsingId(id);
        }

        protected void updateThePet(string attribute, string value)
        {
            _petConnector.UpdateThePetData(attribute, value);
        }
    }
}
