using DotNetTestingFramework.Models;
using RestSharp;
using Configuration = DotNetTestingFramework.Utils.Configuration;

namespace DotNetTestingFramework.Constants
{
    static class SessionVariables
    {
        public static string? Username;
        public static string? Password;

        public static PetStoreModel? PetStore;
        public static PetModel? PetModel;

        public static RestResponse? UserResponse;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static Configuration Config;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    }
}
