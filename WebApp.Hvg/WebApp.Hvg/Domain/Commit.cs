using Newtonsoft.Json;

namespace WebApp.Hvg.Domain
{
    public class Commit
    {
        [JsonProperty("id")]
        public string Sha { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("distinct")]
        public bool Distinct { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        public string BranchName { get; set; }

        public string ShortUrl { get; set; }
    }
}