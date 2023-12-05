using DotNetTestingFramework.Models;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using RestSharp;
using System.Text.Json;

namespace DotNetTestingFramework.Tests.API_Tests
{
    [TestFixture, Description("Verify pet store API")]
    [AllureNUnit]
    [AllureTag("@PetStore")]
    [Category("PetStore")]
    [Category("API")]
    internal class PetStoreApiTests : BaseSteps
    {
        [Test, Description("Verify pet order can be placed")]
        public void OrderIsSuccesfullyPlaced()
        {
            logger.Info("Placing a pet order");
            CreateNewPetStoreOder();
            logger.Info("Fetching all placed orders");
            RestResponse restResponse = FetchPetStoreOrder(Constants.SessionVariables.PetStore.id);
            PetStoreModel actualStoreModel = JsonSerializer.Deserialize<PetStoreModel>(restResponse.Content);
            logger.Info("Verifying newly placed order exists");
            Assert.That(actualStoreModel.id, Is.EqualTo(Constants.SessionVariables.PetStore.id));
        }

        [Test, Description("Verify pet order can be deleted")]
        public void OrderIsSuccessfullyDeleted()
        {
            logger.Info("Placing a pet order");
            CreateNewPetStoreOder();
            logger.Info("Deletting newly placed pet order");
            DeletePetStoreOrder(Constants.SessionVariables.PetStore.id);
            RestResponse restResponse = FetchInvalidPetStoreOrder(Constants.SessionVariables.PetStore.id);
            logger.Info("Verifying order is deleted");
            Assert.That(restResponse.Content, Does.Contain("Order not found"));
        }
    }
}
