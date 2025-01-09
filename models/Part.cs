using Newtonsoft.Json;

namespace GeminiApiApp.Models
{
    public class Part
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}