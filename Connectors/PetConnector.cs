using DotNetTestingFramework.Models;
using RestSharp;

namespace DotNetTestingFramework.Connectors
{
    internal class PetConnector
    {
        private static RestClient BaseRequest() => new RestClient($"{Constants.SessionVariables.Config.Urls.PetBaseURI}/pet");

        public static void AddAPetUsingId(string pet)
        {
            RestRequest request = new RestRequest("", Method.Post).AddBody(pet);
            RestResponse response = BaseRequest().Execute(request);
            Assert.That(response.IsSuccessful, Is.True);
        }

        public static RestResponse GetPetUsingId(int id)
        {
            RestRequest request = new RestRequest("/" + id, Method.Get);
            RestResponse response = BaseRequest().Execute(request);
            Assert.That(response.IsSuccessful, Is.True);
            return response;
        }

        public static RestResponse GetPetUsingStatus(string status)
        {
            RestRequest request = new RestRequest("/findByStatus", Method.Get).AddParameter("status", status);
            RestResponse response = BaseRequest().Execute<PetModel[]>(request);
            Assert.That(response.IsSuccessStatusCode, Is.True);
            return response;
        }

        public static void DeletePetUsingId(int id)
        {
            RestRequest request = new RestRequest("/" + id, Method.Delete);
            RestResponse response = BaseRequest().Execute(request);
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        public static RestResponse GetDeletedPetUsingId(int id)
        {
            RestRequest request = new RestRequest("/" + id, Method.Get);
            RestResponse response = BaseRequest().Execute(request);
            return response;
        }

        public static void UpdateThePetData(string attribute, string value)
        {
            RestRequest request = new RestRequest($"/{Constants.SessionVariables.PetModel.Id}", Method.Post)
                .AddHeader("Content-Type", ContentType.FormUrlEncoded)
                .AddParameter(ContentType.FormUrlEncoded, attribute + "=" + value, ParameterType.RequestBody);
            RestResponse response = BaseRequest().Execute(request);
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }
    }
}
