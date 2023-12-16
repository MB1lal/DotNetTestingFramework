using DotNetTestingFramework.Models;
using DotNetTestingFramework.Tests.Core;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using RestSharp;
using System.Text.Json;

namespace DotNetTestingFramework.Tests.API_Tests
{
    [TestFixture, Description("Verify pet controller API")]
    [AllureNUnit]
    [AllureTag("@Pets")]
    [Category("PetsTest")]
    [Category("API")]
    internal class PetsTest : BaseSteps
    {

        [Test, Description("Verify a pet can be added")]
        public void VerifyPetCanBeAddedThroughId()
        {
            logger.Info("Creating a pet");
            AddNewPetUsingId();
            logger.Info("Fetching newly created pet");
            RestResponse restResponse = GetPetUsingId(int.Parse(Constants.SessionVariables.PetModel!.id.ToString()));
            PetModel actualPetModel = JsonSerializer.Deserialize<PetModel>(restResponse.Content!)!;
            logger.Info("Verifying pet is correctly created");
            Assert.Multiple(() =>
            {
                Assert.That(actualPetModel.name, Is.EqualTo(Constants.SessionVariables.PetModel.name));
                Assert.That(actualPetModel.category.name, Is.EqualTo(Constants.SessionVariables.PetModel.category.name));
            });
        }

        [Test, Description("Verify a new pet can be added with 'sold' status")]
        public void VerifyNewlyAddedPetThroughStatus()
        {
            logger.Info("Creating a pet with status 'sold'");
            AddNewPetWithStatus("sold");
            logger.Info("Fetching all pets with status 'sold'");
            RestResponse restResponse = GetPetUsingStatus("sold");
            bool isMatchFound = false;
            string actualStatus = "";

            PetModel[] actualPetModel = JsonSerializer.Deserialize<PetModel[]>(restResponse.Content!)!;
            foreach (var pet in actualPetModel)
            {
                if (pet.id == Constants.SessionVariables.PetModel!.id)
                {
                    isMatchFound = true;
                    actualStatus = pet.status;
                }
            }
            logger.Info("Verifying newly created pet has correct status");
            Assert.Multiple(() =>
            {
                Assert.That(isMatchFound, Is.True);
                Assert.That(actualStatus, Is.EqualTo(Constants.SessionVariables.PetModel!.status));
            });
        }

        [Test, Description("Verify pet can be deleted")]
        public void VerifyPetCanBeDeleted()
        {
            logger.Info("Creating a pet");
            AddNewPetUsingId();
            logger.Info("Deleting newly created pet");
            DeletePetData(int.Parse(Constants.SessionVariables.PetModel!.id.ToString()));
            RestResponse restResponse = GetDeletedPetUsingId(int.Parse(Constants.SessionVariables.PetModel.id.ToString()));
            logger.Debug(restResponse.Content);
            logger.Info("Verifying pet is deleted");
            Assert.That(restResponse.Content, Does.Contain("Pet not found"));

        }

        [Test, Description("Verify pet details can be updated")]
        public void VerifyPetsDetailsCanBeUpdated()
        {
            logger.Info("Creating a pet");
            AddNewPetUsingId();
            logger.Info("Updating pet details");
            UpdateThePet("name", "Unicorn");
            UpdateThePet("status", "sold");
            logger.Info("Fetching newly created pet");
            RestResponse restResponse = GetPetUsingId(int.Parse(Constants.SessionVariables.PetModel!.id.ToString()));
            PetModel actualPetModel = JsonSerializer.Deserialize<PetModel>(restResponse.Content!)!;
            logger.Info("Verifying pet details are updated");
            Assert.Multiple(() =>
            {
                Assert.That(actualPetModel.name, Is.EqualTo("Unicorn"));
                Assert.That(actualPetModel.status, Is.EqualTo("sold"));
            });
        }

    }
}
