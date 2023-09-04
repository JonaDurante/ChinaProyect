using StudioAdminData.Interfaces;
using StudioAdminData.Models.Business;
using System.Text.Json;

namespace StudioAdminData.Services
{
    public class HttpServices : IHttpServices
    {
        private readonly HttpClient _httpClient;
        public HttpServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async void HttpRequest(string AppId, string AppURL) 
        {         
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("app-id", AppId);
            var response = await _httpClient.GetStreamAsync(AppURL);
            var Data = await JsonSerializer.DeserializeAsync<User>(response);
            // To do agregar return
        }
    }
}
