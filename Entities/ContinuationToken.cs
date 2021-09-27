using Newtonsoft.Json;

namespace AzFunctionCosmosDbPagination.Entities
{
    public class ContinuationToken
    {
        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("QueryPlan")]
        public string QueryPlan { get; set; }

        [JsonProperty("SourceContinuationToken")]
        public string SourceContinuationToken { get; set; }
    }
}