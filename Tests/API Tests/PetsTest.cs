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
    [AllureTag("@Pets")]
    [Category("PetsTest")]
    [Category("API")]
    internal class PetsTest : BaseSteps
    {

        [TestCase(null, TestName = "Verify a pet can be added")]
        public void VerifyPetCanBeAddedThroughId(object? ignored)
        {
            logger.Info("Creating a pet");
            addNewPetUsingId();
            logger.Info("Fetching newly created pet");
            RestResponse restResponse = getPetUsingId(int.Parse(Constants.SessionVariables.PetModel.id.ToString()));
            PetModel actualPetModel = JsonSerializer.Deserialize<PetModel>(restResponse.Content);
            logger.Info("Verifying pet is correctly created");
            Assert.That(actualPetModel.name.Equals(Constants.SessionVariables.PetModel.name));
            Assert.That(actualPetModel.category.name.Equals(Constants.SessionVariables.PetModel.category.name));
        }

        [TestCase(null, TestName = "Verify a new pet can be added with 'sold' status")]
        public void VerifyNewlyAddedPetThroughStatus(object? ignored)
        {
            logger.Info("Creating a pet with status 'sold'");
            addNewPetWithStatus("sold");
            logger.Info("Fetching all pets with status 'sold'");
            RestResponse restResponse = getPetUsingStatus("sold");
            Boolean isMatchFound = false;
            string actualStatus = "";

            PetModel[] actualPetModel = JsonSerializer.Deserialize<PetModel[]>(restResponse.Content);
            foreach (var pet in actualPetModel)
            {
                if (pet.id == Constants.SessionVariables.PetModel.id)
                {
                    isMatchFound = true;
                    actualStatus = pet.status;
                }
            }
            logger.Info("Verifying newly created pet has correct status");
            Assert.True(isMatchFound);
            Assert.IsTrue(actualStatus.Equals(Constants.SessionVariables.PetModel.status));
        }

        [TestCase(null, TestName = "Verify pet can be deleted")]
        public void VerifyPetCanBeDeleted(object? ignored)
        {
            logger.Info("Creating a pet");
            addNewPetUsingId();
            logger.Info("Deleting newly created pet");
            deletePetData(int.Parse(Constants.SessionVariables.PetModel.id.ToString()));
            RestResponse restResponse = getDeletedPetUsingId(int.Parse(Constants.SessionVariables.PetModel.id.ToString()));
            logger.Debug(restResponse.Content);
            logger.Info("Verifying pet is deleted");
            Assert.True(restResponse.Content.Contains("Pet not found"));

        }

        [TestCase(null, TestName = "Verify pet details can be updated")]
        public void VerifyPetsDetailsCanBeUpdated(object? ignored)
        {
            logger.Info("Creating a pet");
            addNewPetUsingId();
            logger.Info("Updating pet details");
            updateThePet("name", "Unicorn");
            updateThePet("status", "sold");
            logger.Info("Fetching newly created pet");
            RestResponse restResponse = getPetUsingId(int.Parse(Constants.SessionVariables.PetModel.id.ToString()));
            PetModel actualPetModel = JsonSerializer.Deserialize<PetModel>(restResponse.Content);
            logger.Info("Verifying pet details are updated");
            Assert.That(actualPetModel.name, Is.EqualTo("Unicorn"));
            Assert.That(actualPetModel.status, Is.EqualTo("sold"));
        }

    }
}
