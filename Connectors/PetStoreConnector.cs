using RestSharp;

namespace DotNetTestingFramework.Connectors
{
    internal class PetStoreConnector
    {
        private RestClient baseRequest() => new RestClient($"{Constants.SessionVariables.Config.urls.petBaseURI}/store");

        public void PlaceAnOrder(string body)
        {
            RestRequest request = new RestRequest("/order", Method.Post).AddBody(body);
            RestResponse response = baseRequest().Execute(request);
            Assert.IsTrue(response.IsSuccessful);
        }

        public RestResponse FetchOrder(int orderId)
        {
            RestRequest request = new RestRequest("/order/" + orderId, Method.Get);
            RestResponse response = baseRequest().Execute(request);
            Assert.IsTrue(response.IsSuccessful);
            return response;
        }
        
        public void DeleteOrder(int orderId)
        {
            RestRequest request = new RestRequest("/order/" + orderId, Method.Delete);
            RestResponse response = baseRequest().Execute(request);
            Assert.IsTrue(response.IsSuccessful);
        }

        public RestResponse FetchDeletedOrder(int orderId)
        {
            RestRequest request = new RestRequest("/order/" + orderId, Method.Get);
            RestResponse response = baseRequest().Execute(request);
            return response;
        }

    }
}
