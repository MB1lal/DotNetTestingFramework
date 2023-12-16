using DotNetTestingFramework.Connectors;
using DotNetTestingFramework.Models;
using DotNetTestingFramework.Pages;
using RestSharp;
using System.Text.Json;

namespace DotNetTestingFramework.Tests.Core
{
    internal class BaseSteps : Hooks
    {
        private static UserModel CreateNewUserData()
        {
            UserModel user = new()
            {
                id = Faker.RandomNumber.Next(),
                username = Faker.Internet.UserName(),
                firstName = Faker.Name.First(),
                lastName = Faker.Name.Last(),
                email = Faker.Internet.Email(),
                password = Faker.Internet.DomainWord() + Faker.Internet.UserName(),
                phone = Faker.Phone.Number(),
                userStatus = Faker.RandomNumber.Next()
            };

            Constants.SessionVariables.Username = user.username;
            Constants.SessionVariables.Password = user.password;

            return user;
        }

        private static PetStoreModel CreateNewStoreData()
        {
            PetStoreModel petStore = new()
            {
                id = Faker.RandomNumber.Next(1, 5000),
                petId = Faker.RandomNumber.Next(1, 5000),
                quantity = Faker.RandomNumber.Next(1, 3),
                shipDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                status = "placed",
                complete = true
            };

            Constants.SessionVariables.PetStore = petStore;

            return petStore;
        }

        private static PetModel CreateNewPetData()
        {
            PetModel petModel = new()
            {
                id = Faker.RandomNumber.Next(1, 5000),
                status = "Available"
            };
            Category category = new()
            {
                id = Faker.RandomNumber.Next(1, 5000),
                name = Faker.Company.CatchPhrase()
            };

            petModel.category = category;
            petModel.name = Faker.Company.CatchPhrase();
            petModel.photoUrls = new List<string>() { "", "" };
            Tag tag = new()
            {
                id = Faker.RandomNumber.Next(1, 400),
                name = Faker.Company.CatchPhrase()
            };
            petModel.tags = new List<Tag>() { tag };

            Constants.SessionVariables.PetModel = petModel;

            return petModel;
        }

        protected static void CreateNewUser()
        {
            UserModel userModel = CreateNewUserData();
            UserConnector.CreateNewUser(JsonSerializer.Serialize(userModel));
        }

        protected static RestResponse GetUser(string username)
        {
            return UserConnector.GetUser(username);
        }

        protected static void LoginUser(string username, string password)
        {
            Constants.SessionVariables.UserResponse = UserConnector.LoginUser(username, password);
        }

        protected static void LogoutUser()
        {
            logger.Info("Logging out user");
            UserConnector.LogoutUser();
        }

        protected static void CreateNewPetStoreOder()
        {
            PetStoreModel petStoreModel = CreateNewStoreData();
            PetStoreConnector.PlaceAnOrder(JsonSerializer.Serialize(petStoreModel));

        }

        protected static RestResponse FetchPetStoreOrder(int orderId)
        {
            return PetStoreConnector.FetchOrder(orderId);
        }
        protected static RestResponse FetchInvalidPetStoreOrder(int orderId)
        {
            return PetStoreConnector.FetchDeletedOrder(orderId);
        }

        protected static void DeletePetStoreOrder(int orderId)
        {
            PetStoreConnector.DeleteOrder(orderId);
        }

        protected static void AddNewPetUsingId()
        {
            PetModel petModel = CreateNewPetData();
            PetConnector.AddAPetUsingId(JsonSerializer.Serialize(petModel));
        }

        protected static RestResponse GetPetUsingId(int id)
        {
            return PetConnector.GetPetUsingId(id);
        }

        protected static void AddNewPetWithStatus(string status)
        {
            PetModel petModel = CreateNewPetData();
            petModel.status = status;
            PetConnector.AddAPetUsingId(JsonSerializer.Serialize(petModel));
        }

        protected static RestResponse GetPetUsingStatus(string status)
        {
            return PetConnector.GetPetUsingStatus(status);
        }

        protected static void DeletePetData(int id)
        {
            PetConnector.DeletePetUsingId(id);
        }

        protected static RestResponse GetDeletedPetUsingId(int id)
        {
            return PetConnector.GetDeletedPetUsingId(id);
        }

        protected static void UpdateThePet(string attribute, string value)
        {
            PetConnector.UpdateThePetData(attribute, value);
        }

        protected static void NavigateToXPage(string pageName)
        {
            HerokuHomePage herokuHomePage = new(driver);
            logger.Info($"Navigating to {pageName}");
            herokuHomePage.NavigateToPage(pageName);
        }

    }
}
