using DotNetTestingFramework.Models;
using OpenQA.Selenium;
using RestSharp;

namespace DotNetTestingFramework.Constants
{
    class SessionVariables
    {
        public static IWebDriver? Driver;

        public static string? Username;
        public static string? Password;

        public static PetStoreModel? PetStore;
        public static PetModel? PetModel;

        public static RestResponse? UserResponse;

    }
}
