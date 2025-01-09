using Newtonsoft.Json;

namespace GeminiApiApp.Models
{
    public class Content
    {
        [JsonProperty("parts")]
        public Part[] Parts { get; set; }
    }
}