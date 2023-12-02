using Newtonsoft.Json;

namespace DotNetTestingFramework.Models
{
    internal class Category
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
