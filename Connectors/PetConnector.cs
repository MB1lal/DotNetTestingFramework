using DotNetTestingFramework.Models;
using RestSharp;

namespace DotNetTestingFramework.Connectors
{
    internal class PetConnector
    {
        private RestClient baseRequest() => new RestClient($"{Constants.SessionVariables.Config.urls.petBaseURI}/pet");

        public void AddAPetUsingId(string pet)
        {
            RestRequest request = new RestRequest("", Method.Post).AddBody(pet);
            RestResponse response = baseRequest().Execute(request);
            Assert.IsTrue(response.IsSuccessful);
        }

        public RestResponse GetPetUsingId(int id)
        {
            RestRequest request = new RestRequest("/" + id, Method.Get);
            RestResponse response = baseRequest().Execute(request);
            Assert.IsTrue(response.IsSuccessful);
            return response;
        }

        public RestResponse GetPetUsingStatus(string status)
        {
            RestRequest request = new RestRequest("/findByStatus", Method.Get).AddParameter("status", status);
            RestResponse response = baseRequest().Execute<PetModel[]>(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
            return response;
        }

        public void DeletePetUsingId(int id)
        {
            RestRequest request = new RestRequest("/" + id, Method.Delete);
            RestResponse response = baseRequest().Execute(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        public RestResponse GetDeletedPetUsingId(int id)
        {
            RestRequest request = new RestRequest("/" + id, Method.Get);
            RestResponse response = baseRequest().Execute(request);
            return response;
        }

        public void UpdateThePetData(string attribute, string value)
        {
            RestRequest request = new RestRequest("/" + Constants.SessionVariables.PetModel.id, Method.Post)
                .AddHeader("Content-Type", ContentType.FormUrlEncoded)
                .AddParameter(ContentType.FormUrlEncoded, attribute + "=" + value, ParameterType.RequestBody);
            RestResponse response = baseRequest().Execute(request);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}
