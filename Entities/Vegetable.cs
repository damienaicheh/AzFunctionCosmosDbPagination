using System.Text.Json.Serialization;

namespace AzFunctionCosmosDbPagination.Entities
{
    public class Vegetable
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}