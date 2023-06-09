﻿using RestSharp;

namespace DotNetTestingFramework.Connectors
{
    internal class UserConnector
    {
        private string _baseURI = "https://petstore.swagger.io/v2";


        private RestClient baseRequest()
        {
           return new RestClient(_baseURI);
           
        }

        public void CreateNewUser(string user)
        {
            RestRequest restRequest = new RestRequest("/user", Method.Post).AddStringBody(user, ContentType.Json);
            RestResponse restResponse = baseRequest().Execute(restRequest);
            Assert.IsTrue(restResponse.IsSuccessful);
        }

        public RestResponse GetUser(string username)
        {
            RestRequest restRequest = new RestRequest("/user/" + username, Method.Get);
            RestResponse restResponse = baseRequest().Execute(restRequest);
            Assert.IsTrue(restResponse.IsSuccessful);
            return restResponse;
        } 

        public RestResponse loginUser(string username, string password)
        {
            RestRequest restRequest = new RestRequest("/user/login", Method.Get)
                .AddParameter("username", username)
                .AddParameter("password", password);
            RestResponse restResponse = baseRequest().Execute(restRequest);
            Assert.IsTrue(restResponse.IsSuccessful);
            return restResponse;
        }

        public void logoutUser()
        {
            RestRequest restRequest = new RestRequest("/user/logout", Method.Get);
            RestResponse restResponse = baseRequest().Execute(restRequest);
            Assert.IsTrue(restResponse.IsSuccessful);
        }
        
    }
}
