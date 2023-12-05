using RestSharp;

namespace DotNetTestingFramework.Connectors
{
    internal class UserConnector
    {
        private static RestClient BaseRequest() => new(Constants.SessionVariables.Config.Urls.PetBaseURI);


        public static void CreateNewUser(string user)
        {
            RestRequest restRequest = new RestRequest("/user", Method.Post).AddStringBody(user, ContentType.Json);
            RestResponse restResponse = BaseRequest().Execute(restRequest);
            Assert.That(restResponse.IsSuccessful, Is.True);
        }

        public static RestResponse GetUser(string username)
        {
            RestRequest restRequest = new RestRequest("/user/" + username, Method.Get);
            RestResponse restResponse = BaseRequest().Execute(restRequest);
            Assert.That(restResponse.IsSuccessful, Is.True);
            return restResponse;
        }

        public static RestResponse LoginUser(string username, string password)
        {
            RestRequest restRequest = new RestRequest("/user/login", Method.Get)
                .AddParameter("username", username)
                .AddParameter("password", password);
            RestResponse restResponse = BaseRequest().Execute(restRequest);
            Assert.That(restResponse.IsSuccessful, Is.True);
            return restResponse;
        }

        public static void LogoutUser()
        {
            RestRequest restRequest = new RestRequest("/user/logout", Method.Get);
            RestResponse restResponse = BaseRequest().Execute(restRequest);
            Assert.That(restResponse.IsSuccessful, Is.True);
        }

    }
}
