using Newtonsoft.Json;

namespace DotNetTestingFramework.Models
{
    internal class Category
    {
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("name")]
        public string? name { get; set; }
    }
}
