using Newtonsoft.Json;

namespace DotNetTestingFramework.Models
{
    internal class Tag
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }
}
