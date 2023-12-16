using Newtonsoft.Json;

namespace DotNetTestingFramework.Models
{
    internal class PetModel
    {
        [JsonProperty("id")]
#pragma warning disable IDE1006 // Naming Styles
        public long id { get; set; }


        [JsonProperty("category")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Category category { get; set; }


        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("photoUrls")]
        public List<string> photoUrls { get; set; }

        [JsonProperty("tags")]
        public List<Tag> tags { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore IDE1006 // Naming Styles
    }
}
