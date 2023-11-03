using DotNetTestingFramework.Models;
using RestSharp;
using System.Text.Json;

namespace DotNetTestingFramework.Tests.ApiTests
{
    [TestFixture]
    [Category("PetsTest")]
    [Category("api")]
    [Parallelizable(ParallelScope.Fixtures)]
    internal class PetsTest : BaseSteps
    {

        [Test]
        public void VerifyPetCanBeAddedThroughId()
        {
            extentReporting.AddTestCase("Verify pet can be added through Id");
            try
            {
                extentReporting.LogStatusInReport(info, "Adding a new pet");
                addNewPetUsingId();
                extentReporting.LogStatusInReport(info, "Fetching a pet using Id");
                RestResponse restResponse = getPetUsingId(int.Parse(Constants.SessionVariables.PetModel.id.ToString()));
                extentReporting.LogStatusInReport(info, "Pet Response = " + restResponse.Content);
                PetModel actualPetModel = JsonSerializer.Deserialize<PetModel>(restResponse.Content);

                Assert.That(actualPetModel.name.Equals(Constants.SessionVariables.PetModel.name));
                Assert.That(actualPetModel.category.name.Equals(Constants.SessionVariables.PetModel.category.name));

                extentReporting.LogStatusInReport(pass, "The correct pet has been found against id");

            }
            catch (Exception ex)
            {
                extentReporting.LogStatusInReport(fail, ex.ToString());
                throw;
            }
            
        }

        [Test]
        public void VerifyNewlyAddedPetThroughStatus()
        {
            extentReporting.AddTestCase("Verify newly added pet through status");
            try
            {
                extentReporting.LogStatusInReport(info, "Adding a new pet with status 'sold'");
                addNewPetWithStatus("sold");
                extentReporting.LogStatusInReport(info, "Fetching all pets with 'sold' status");
                RestResponse restResponse = getPetUsingStatus("sold");
                extentReporting.LogStatusInReport(info, "Pet Response = " + restResponse.Content);
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

                Assert.True(isMatchFound);
                Assert.IsTrue(actualStatus.Equals(Constants.SessionVariables.PetModel.status));

                extentReporting.LogStatusInReport(pass, "The correct pet has been found with status");
            } catch (Exception ex)
            {
                extentReporting.LogStatusInReport(fail, ex.ToString());
                throw;
            }
            
        }

        [Test]
        public void VerifyPetCanBeDeleted()
        {
            extentReporting.AddTestCase("Verify pet can be deleted");
            try
            {
                extentReporting.LogStatusInReport(info, "Adding a new pet");
                addNewPetUsingId();
                extentReporting.LogStatusInReport(info, "Deleting a pet using id");
                deletePetData(int.Parse(Constants.SessionVariables.PetModel.id.ToString()));
                RestResponse restResponse = getDeletedPetUsingId(int.Parse(Constants.SessionVariables.PetModel.id.ToString()));
                extentReporting.LogStatusInReport(info, "Pet Response = " + restResponse.Content);
                
                Assert.That(restResponse.Content, Does.Contain("Pet not found"));

                extentReporting.LogStatusInReport(pass, "Pet has been succesfully deleted");
            } catch (Exception ex)
            {
                extentReporting.LogStatusInReport(fail, ex.ToString());
                throw;
            }


        }

        [Test]
        public void VerifyPetsDetailsCanBeUpdated()
        {
            extentReporting.AddTestCase("Verify pet details can be updated");
            try
            {
                extentReporting.LogStatusInReport(info, "Adding a new pet");
                addNewPetUsingId();
                extentReporting.LogStatusInReport(info, "Updating pet's name to Unicorn");
                updateThePet("name", "Unicorn");
                extentReporting.LogStatusInReport(info, "Updating pet's status to 'sold'");
                updateThePet("status", "sold");

                RestResponse restResponse = getPetUsingId(int.Parse(Constants.SessionVariables.PetModel.id.ToString()));
                extentReporting.LogStatusInReport(info, "Pet Response = " + restResponse.Content);
                PetModel actualPetModel = JsonSerializer.Deserialize<PetModel>(restResponse.Content);

                Assert.That(actualPetModel.name, Is.EqualTo("Unicorn"));
                Assert.That(actualPetModel.status, Is.EqualTo("sold"));

                extentReporting.LogStatusInReport(pass, "Pet details have been succesfully updated");
            } catch (Exception ex)
            {
                extentReporting.LogStatusInReport(fail, ex.ToString());
                throw;
            }
            
        }

    }
}
