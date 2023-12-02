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
            AddNewPetUsingId();
            logger.Info("Fetching newly created pet");
            RestResponse restResponse = GetPetUsingId(int.Parse(Constants.SessionVariables.PetModel.Id.ToString()));
            PetModel actualPetModel = JsonSerializer.Deserialize<PetModel>(restResponse.Content);
            logger.Info("Verifying pet is correctly created");
            Assert.Multiple(() =>
            {
                Assert.That(actualPetModel.Name, Is.EqualTo(Constants.SessionVariables.PetModel.Name));
                Assert.That(actualPetModel.Category.Name, Is.EqualTo(Constants.SessionVariables.PetModel.Category.Name));
            });
        }

        [TestCase(null, TestName = "Verify a new pet can be added with 'sold' status")]
        public void VerifyNewlyAddedPetThroughStatus(object? ignored)
        {
            logger.Info("Creating a pet with status 'sold'");
            AddNewPetWithStatus("sold");
            logger.Info("Fetching all pets with status 'sold'");
            RestResponse restResponse = GetPetUsingStatus("sold");
            bool isMatchFound = false;
            string actualStatus = "";

            PetModel[] actualPetModel = JsonSerializer.Deserialize<PetModel[]>(restResponse.Content);
            foreach (var pet in actualPetModel)
            {
                if (pet.Id == Constants.SessionVariables.PetModel.Id)
                {
                    isMatchFound = true;
                    actualStatus = pet.Status;
                }
            }
            logger.Info("Verifying newly created pet has correct status");
            Assert.Multiple(() =>
            {
                Assert.That(isMatchFound, Is.True);
                Assert.That(actualStatus, Is.EqualTo(Constants.SessionVariables.PetModel.Status));
            });
        }

        [TestCase(null, TestName = "Verify pet can be deleted")]
        public void VerifyPetCanBeDeleted(object? ignored)
        {
            logger.Info("Creating a pet");
            AddNewPetUsingId();
            logger.Info("Deleting newly created pet");
            DeletePetData(int.Parse(Constants.SessionVariables.PetModel.Id.ToString()));
            RestResponse restResponse = GetDeletedPetUsingId(int.Parse(Constants.SessionVariables.PetModel.Id.ToString()));
            logger.Debug(restResponse.Content);
            logger.Info("Verifying pet is deleted");
            Assert.That(restResponse.Content, Does.Contain("Pet not found"));

        }

        [TestCase(null, TestName = "Verify pet details can be updated")]
        public void VerifyPetsDetailsCanBeUpdated(object? ignored)
        {
            logger.Info("Creating a pet");
            AddNewPetUsingId();
            logger.Info("Updating pet details");
            UpdateThePet("name", "Unicorn");
            UpdateThePet("status", "sold");
            logger.Info("Fetching newly created pet");
            RestResponse restResponse = GetPetUsingId(int.Parse(Constants.SessionVariables.PetModel.Id.ToString()));
            PetModel actualPetModel = JsonSerializer.Deserialize<PetModel>(restResponse.Content);
            logger.Info("Verifying pet details are updated");
            Assert.Multiple(() =>
            {
                Assert.That(actualPetModel.Name, Is.EqualTo("Unicorn"));
                Assert.That(actualPetModel.Status, Is.EqualTo("sold"));
            });
        }

    }
}
