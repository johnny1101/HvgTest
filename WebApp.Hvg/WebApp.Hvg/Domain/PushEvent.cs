using Newtonsoft.Json;

namespace WebApp.Hvg.Domain
{
    public class PushEvent
    {
        [JsonProperty("ref")]
        public string Reference { get; set; }

        [JsonProperty("head")]
        public string Head { get; set; }

        [JsonProperty("before")]
        public string Before { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("distinct_size")]
        public int DistinctSize { get; set; }

        [JsonProperty("commits")]
        public Commit[] Commits { get; set; }
    }
}