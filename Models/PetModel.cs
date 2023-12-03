using Newtonsoft.Json;

namespace DotNetTestingFramework.Models
{
    internal class PetModel
    {
        [JsonProperty("id")]
        public Int64 id { get; set; }

        [JsonProperty("category")]
        public Category category { get; set; }

        [JsonProperty(nameof(name))]
        public string name { get; set; }

        [JsonProperty("photoUrls")]
        public List<string> photoUrls { get; set; }

        [JsonProperty("tags")]
        public List<Tag> tags { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }
    }
}
