    using Newtonsoft.Json;
    public class ApiResponse
    {
        [JsonProperty("candidates")]
        public Candidate[] Candidates { get; set; }
    }