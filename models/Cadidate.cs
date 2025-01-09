    using Newtonsoft.Json;
    using GeminiApiApp.Models;
    public class Candidate
    {
        [JsonProperty("content")]
        public Content Content { get; set; }
    }