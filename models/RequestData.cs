using Newtonsoft.Json;

namespace GeminiApiApp.Models
{
    public class RequestData
    {
        [JsonProperty("contents")]
        public Content[] Contents { get; set; }
    }
}