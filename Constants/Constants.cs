using DotNetTestingFramework.Models;
using OpenQA.Selenium;
using RestSharp;
using Configuration = DotNetTestingFramework.Utils.Configuration;

namespace DotNetTestingFramework.Constants
{
    static class SessionVariables
    {
        public static IWebDriver? Driver;

        public static string? Username;
        public static string? Password;

        public static PetStoreModel? PetStore;
        public static PetModel? PetModel;

        public static RestResponse? UserResponse;

        public static Configuration Config;

    }
}
