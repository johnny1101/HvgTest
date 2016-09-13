using Newtonsoft.Json;

namespace WebApp.Hvg.Domain
{
    public class Author
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}