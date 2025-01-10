using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using GeminiApiApp.Models;

namespace GeminiApiApp
{
    public partial class MainPage : ContentPage
    {
        // Substitua pelo seu API Key
        private const string ApiKey = "SUA API KEY";
        private const string ApiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key=";

        private readonly HttpClient _httpClient;

        public MainPage()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async void OnGenerateContentClicked(object sender, EventArgs e)
        {
            var inputText = inputTextEditor.Text;

            var requestData = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new
                            {
                                text = inputText
                            }
                        }
                    }
                }
            };

            var jsonContent = JsonConvert.SerializeObject(requestData);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(ApiUrl + ApiKey, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ApiResponse>(responseData);

                    if (result?.Candidates != null && result.Candidates.Length > 0)
                    {
                        responseLabel.Text = result.Candidates[0].Content.Parts[0].Text;
                    }
                    else
                    {
                        responseLabel.Text = "No content generated.";
                    }
                }
                else
                {
                    responseLabel.Text = "Error: " + response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                responseLabel.Text = "Error: " + ex.Message;
            }
        }
    }

    public class ApiResponse
    {
        [JsonProperty("candidates")]
        public Candidate[] Candidates { get; set; }
    }

    public class Candidate
    {
        [JsonProperty("content")]
        public Content Content { get; set; }
    }

    public class Content
    {
        [JsonProperty("parts")]
        public Part[] Parts { get; set; }
    }

    public class Part
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
