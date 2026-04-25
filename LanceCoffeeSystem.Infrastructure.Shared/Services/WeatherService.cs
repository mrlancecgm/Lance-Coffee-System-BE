using LanceCoffeeSystem.Application.DTOs.Settings;
using LanceCoffeeSystem.Application.Interfaces.Shared;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LanceCoffeeSystem.Infrastructure.Shared.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly WeatherSettings _weatherSettings;

        public WeatherService(HttpClient httpClient, IOptions<WeatherSettings> weatherSettings)
        {
            _httpClient = httpClient;
            _weatherSettings = weatherSettings.Value;
        }

        public async Task<WeatherAPIResponse> GetCurrentWeatherAsync(string city)
        {
            var apiKey = _weatherSettings.ApiKey;
            var baseUrl = _weatherSettings.BaseUrl;

            var url = $"{baseUrl}weather?q={city}&appid={apiKey}&units=metric";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<WeatherAPIResponse>(json);
            return result;
        }
    }
}