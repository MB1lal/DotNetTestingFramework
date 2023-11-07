using DotNetTestingFramework.Models;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using RestSharp;
using System.Text.Json;

namespace DotNetTestingFramework.Tests.ApiTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureTag("@PetStore")]
    [Category("PetStore")]
    [Parallelizable(ParallelScope.Fixtures)]
    internal class PetStoreApiTests : BaseSteps
    {
        [TestCase(null, TestName = "Verify pet order can be placed")]
        public void OrderIsSuccesfullyPlaced(object? ignored)
        {
            logger.Info("Placing a pet order");
            createNewPetStoreOder();
            logger.Info("Fetching all placed orders");
            RestResponse restResponse = fetchPetStoreOrder(Constants.SessionVariables.PetStore.id);
            PetStoreModel actualStoreModel = JsonSerializer.Deserialize<PetStoreModel>(restResponse.Content);
            logger.Info("Verifying newly placed order exists");
            Assert.That(actualStoreModel.id.Equals(Constants.SessionVariables.PetStore.id));
        }

        [TestCase(null, TestName = "Verify pet order can be deleted")]
        public void OrderIsSuccessfullyDeleted(object? ignored)
        {
            logger.Info("Placing a pet order");
            createNewPetStoreOder();
            logger.Info("Deletting newly placed pet order");
            deletePetStoreOrder(Constants.SessionVariables.PetStore.id);
            RestResponse restResponse = fetchInvalidPetStoreOrder(Constants.SessionVariables.PetStore.id);
            logger.Info("Verifying order is deleted");
            Assert.That(restResponse.Content.Contains("Order not found"));
        }
    }
}
