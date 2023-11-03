using DotNetTestingFramework.Models;
using DotNetTestingFramework.Tests.Core;
using RestSharp;
using System.Text.Json;

namespace DotNetTestingFramework.Tests.ApiTests
{
    [TestFixture]
    [Category("PetsTest")]
    [Parallelizable(ParallelScope.Fixtures)]
    internal class PetsTest : BaseSteps
    {

        [Test]
        public void VerifyPetCanBeAddedThroughId()
        {
            addNewPetUsingId();

            RestResponse restResponse = getPetUsingId(int.Parse(Constants.SessionVariables.PetModel.id.ToString()));
            PetModel actualPetModel = JsonSerializer.Deserialize<PetModel>(restResponse.Content);

            Assert.That(actualPetModel.name.Equals(Constants.SessionVariables.PetModel.name));
            Assert.That(actualPetModel.category.name.Equals(Constants.SessionVariables.PetModel.category.name));
        }

        [Test]
        public void VerifyNewlyAddedPetThroughStatus()
        {
            addNewPetWithStatus("sold");
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

            Assert.True(isMatchFound);
            Assert.IsTrue(actualStatus.Equals(Constants.SessionVariables.PetModel.status));
        }

        [Test]
        public void VerifyPetCanBeDeleted()
        {
            addNewPetUsingId();
            deletePetData(int.Parse(Constants.SessionVariables.PetModel.id.ToString()));
            RestResponse restResponse = getDeletedPetUsingId(int.Parse(Constants.SessionVariables.PetModel.id.ToString()));
            Console.WriteLine   (restResponse.Content);
            Assert.True(restResponse.Content.Contains("Pet not found"));

        }

        [Test]
        public void VerifyPetsDetailsCanBeUpdated()
        {
            addNewPetUsingId();
            updateThePet("name", "Unicorn");
            updateThePet("status", "sold");

            RestResponse restResponse = getPetUsingId(int.Parse(Constants.SessionVariables.PetModel.id.ToString()));
            PetModel actualPetModel = JsonSerializer.Deserialize<PetModel>(restResponse.Content);

            Assert.That(actualPetModel.name, Is.EqualTo("Unicorn"));
            Assert.That(actualPetModel.status, Is.EqualTo("sold"));
        }

    }
}
