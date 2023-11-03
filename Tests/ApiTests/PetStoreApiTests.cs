using DotNetTestingFramework.Models;
using RestSharp;
using System.Text.Json;

namespace DotNetTestingFramework.Tests.ApiTests
{
    [TestFixture]
    [Category("PetStore")]
    [Category("api")]
    [Parallelizable(ParallelScope.Fixtures)]
    internal class PetStoreApiTests : BaseSteps
    {
        [Test]
        public void OrderIsSuccesfullyPlaced()
        {
            extentReporting.AddTestCase("Verify order is succesfully placed");
            try
            {
                extentReporting.LogStatusInReport(info, "Creating a new pet store order");
                createNewPetStoreOder();
                extentReporting.LogStatusInReport(info, "Fetching pet store order using id");
                RestResponse restResponse = fetchPetStoreOrder(Constants.SessionVariables.PetStore.id);
                extentReporting.LogStatusInReport(info, "Response = " + restResponse.Content);
                PetStoreModel actualStoreModel = JsonSerializer.Deserialize<PetStoreModel>(restResponse.Content);
                Assert.That(actualStoreModel.id.Equals(Constants.SessionVariables.PetStore.id));

                extentReporting.LogStatusInReport(pass, "Order is succesfully placed");
            }
            catch (Exception ex)
            {
                extentReporting.LogStatusInReport(fail, ex.ToString());
                throw;
            }

        }

        [Test]
        public void OrderIsSuccessfullyDeleted()
        {
            extentReporting.AddTestCase("Verify order is succesfully deleted");
            try
            {
                extentReporting.LogStatusInReport(info, "Creating a new pet store order");
                createNewPetStoreOder();
                extentReporting.LogStatusInReport(info, "Deleteing pet store order using id");
                deletePetStoreOrder(Constants.SessionVariables.PetStore.id);
                RestResponse restResponse = fetchInvalidPetStoreOrder(Constants.SessionVariables.PetStore.id);
                extentReporting.LogStatusInReport(info, "Response = " + restResponse.Content);
                Assert.That(restResponse.Content.Contains("Order not found"));

                extentReporting.LogStatusInReport(pass, "Order is succesfully deleted");
            }
            catch (Exception ex)
            {
                extentReporting.LogStatusInReport(fail, ex.ToString());
                throw;
            }
           
        }
    }
}
