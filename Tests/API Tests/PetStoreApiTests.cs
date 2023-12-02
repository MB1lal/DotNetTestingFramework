using DotNetTestingFramework.Models;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using RestSharp;
using System.Text.Json;

namespace DotNetTestingFramework.Tests.API_Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureTag("@PetStore")]
    [Category("PetStore")]
    [Category("API")]
    internal class PetStoreApiTests : BaseSteps
    {
        [TestCase(null, TestName = "Verify pet order can be placed")]
        public void OrderIsSuccesfullyPlaced(object? ignored)
        {
            logger.Info("Placing a pet order");
            CreateNewPetStoreOder();
            logger.Info("Fetching all placed orders");
            RestResponse restResponse = FetchPetStoreOrder(Constants.SessionVariables.PetStore.Id);
            PetStoreModel actualStoreModel = JsonSerializer.Deserialize<PetStoreModel>(restResponse.Content);
            logger.Info("Verifying newly placed order exists");
            Assert.That(actualStoreModel.Id.Equals(Constants.SessionVariables.PetStore.Id));
        }

        [TestCase(null, TestName = "Verify pet order can be deleted")]
        public void OrderIsSuccessfullyDeleted(object? ignored)
        {
            logger.Info("Placing a pet order");
            CreateNewPetStoreOder();
            logger.Info("Deletting newly placed pet order");
            DeletePetStoreOrder(Constants.SessionVariables.PetStore.Id);
            RestResponse restResponse = FetchInvalidPetStoreOrder(Constants.SessionVariables.PetStore.Id);
            logger.Info("Verifying order is deleted");
            Assert.That(restResponse.Content.Contains("Order not found"));
        }
    }
}
