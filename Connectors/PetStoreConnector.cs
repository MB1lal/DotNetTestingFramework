using RestSharp;

namespace DotNetTestingFramework.Connectors
{
    internal class PetStoreConnector
    {
        private static RestClient BaseRequest() => new($"{Constants.SessionVariables.Config.Urls.PetBaseURI}/store");

        public static void PlaceAnOrder(string body)
        {
            RestRequest request = new RestRequest("/order", Method.Post).AddBody(body);
            RestResponse response = BaseRequest().Execute(request);
            Assert.That(response.IsSuccessful, Is.True);
        }

        public static RestResponse FetchOrder(int orderId)
        {
            RestRequest request = new RestRequest("/order/" + orderId, Method.Get);
            RestResponse response = BaseRequest().Execute(request);
            Assert.That(response.IsSuccessful, Is.True);
            return response;
        }

        public static void DeleteOrder(int orderId)
        {
            RestRequest request = new RestRequest("/order/" + orderId, Method.Delete);
            RestResponse response = BaseRequest().Execute(request);
            Assert.That(response.IsSuccessful, Is.True);
        }

        public static RestResponse FetchDeletedOrder(int orderId)
        {
            RestRequest request = new RestRequest("/order/" + orderId, Method.Get);
            RestResponse response = BaseRequest().Execute(request);
            return response;
        }

    }
}
