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
                Id = Faker.RandomNumber.Next(),
                Username = Faker.Internet.UserName(),
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                Email = Faker.Internet.Email(),
                Password = Faker.Internet.DomainWord() + Faker.Internet.UserName(),
                Phone = Faker.Phone.Number(),
                UserStatus = Faker.RandomNumber.Next()
            };

            Constants.SessionVariables.Username = user.Username;
            Constants.SessionVariables.Password = user.Password;

            return user;
        }

        private static PetStoreModel CreateNewStoreData()
        {
            PetStoreModel petStore = new()
            {
                Id = Faker.RandomNumber.Next(1, 5000),
                PetId = Faker.RandomNumber.Next(1, 5000),
                Quantity = Faker.RandomNumber.Next(1, 3),
                ShipDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                Status = "placed",
                Complete = true
            };

            Constants.SessionVariables.PetStore = petStore;

            return petStore;
        }

        private static PetModel CreateNewPetData()
        {
            PetModel petModel = new()
            {
                Id = Faker.RandomNumber.Next(1, 5000),
                Status = "Available"
            };
            Category category = new()
            {
                Id = Faker.RandomNumber.Next(1, 5000),
                Name = Faker.Lorem.Words(1).ToString()
            };

            petModel.Category = category;
            petModel.Name = Faker.Lorem.Words(1).ToString();
            petModel.PhotoUrls = new List<string>() { "", "" };
            Tag tag = new()
            {
                Id = Faker.RandomNumber.Next(1, 400),
                Name = Faker.Lorem.Words(1).ToString()
            };
            petModel.Tags = new List<Tag>() { tag };

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
            petModel.Status = status;
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

        protected static void NavigateToPage(string pageName)
        {
            HerokuHomePage herokuHomePage = new(driver);
            logger.Info($"Navigating to {pageName}");
            herokuHomePage.NavigateToPage(pageName);
        }

    }
}
