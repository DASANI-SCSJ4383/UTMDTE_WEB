using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using UTMDTE_WEB.API;
using static System.Net.Mime.MediaTypeNames;

namespace UTMDTE.API
{
    public class RESTFulRequest
    {
        private readonly HttpClient _httpClient; 

        public RESTFulRequest(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("http://localhost:8000/api/");
        }

        private void SetAccessToken(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        private JsonNode? GetJsonNodeObj(dynamic httpResponseMessage)
        {
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var responseString = httpResponseMessage.Content.ReadAsStringAsync().Result;
                JsonNode response = JsonNode.Parse(responseString);

                return response;
            }
            else
            {
                return null;
            }
        }

        private StringContent? Serialization(dynamic data)
        {
            return new StringContent(
                                JsonSerializer.Serialize(data, JsonSetting.GetSerializeSetting()),
                                Encoding.UTF8,
                                Application.Json);
        }

        public async Task<JsonNode?> GetAsync(string path, string accessToken = "")
        {
            SetAccessToken(accessToken);

            using var httpResponseMessage =
            await _httpClient.GetAsync(path);

            return GetJsonNodeObj(httpResponseMessage);
        }

        public async Task<JsonNode?> PostAsync(string path, dynamic data, string accessToken = "")
        {
            SetAccessToken(accessToken);

            var dataJson = Serialization(data);

            using var httpResponseMessage =
            await _httpClient.PostAsync(path, dataJson);

            return GetJsonNodeObj(httpResponseMessage);
        }

        public async Task<JsonNode?> PutAsync(string path, dynamic data, string accessToken = "")
        {
            SetAccessToken(accessToken);

            var dataJson = Serialization(data);

            using var httpResponseMessage =
            await _httpClient.PutAsync(path, dataJson);

            return GetJsonNodeObj(httpResponseMessage);
        }

        public async Task<JsonNode?> PatchAsync(string path, dynamic data, string accessToken = "")
        {
            SetAccessToken(accessToken);

            var dataJson = Serialization(data);

            using var httpResponseMessage =
            await _httpClient.PatchAsync(path, dataJson);

            return GetJsonNodeObj(httpResponseMessage);
        }

        public async Task<JsonNode?> DeleteAsync(string path, string accessToken = "")
        {
            SetAccessToken(accessToken);

            using var httpResponseMessage =
            await _httpClient.DeleteAsync(path);

            return GetJsonNodeObj(httpResponseMessage);
        }
    }
}
