using DotNetTestingFramework.Models;
using DotNetTestingFramework.Tests.Core;
using RestSharp;
using System.Text.Json;

namespace DotNetTestingFramework.Tests.ApiTests
{
    [TestFixture]
    [Category("PetStore")]
    [Parallelizable(ParallelScope.Fixtures)]
    internal class PetStoreApiTests : BaseSteps
    {
        [Test]
        public void OrderIsSuccesfullyPlaced()
        {
            createNewPetStoreOder();
            RestResponse restResponse = fetchPetStoreOrder(Constants.SessionVariables.PetStore.id);
            PetStoreModel actualStoreModel = JsonSerializer.Deserialize<PetStoreModel>(restResponse.Content);
            Assert.That(actualStoreModel.id.Equals(Constants.SessionVariables.PetStore.id));
        }

        [Test]
        public void OrderIsSuccessfullyDeleted()
        {
            createNewPetStoreOder();
            deletePetStoreOrder(Constants.SessionVariables.PetStore.id);
            RestResponse restResponse = fetchInvalidPetStoreOrder(Constants.SessionVariables.PetStore.id);
            Assert.That(restResponse.Content.Contains("Order not found"));
        }
    }
}
