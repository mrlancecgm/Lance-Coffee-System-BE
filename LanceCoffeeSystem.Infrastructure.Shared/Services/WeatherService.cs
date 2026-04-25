using LanceCoffeeSystem.Application.DTOs.Settings;
using LanceCoffeeSystem.Application.Helpers;
using LanceCoffeeSystem.Application.Interfaces.Shared;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text;
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
            HexConverter hexConverter = new HexConverter();
            var apiKey_raw = _weatherSettings.ApiKey;
            byte[] base64EncodedBytes = Convert.FromBase64String(apiKey_raw);
            var apiKey_phase1 = Encoding.UTF8.GetString(base64EncodedBytes);
            var apiKey_phase2 = hexConverter.HexToString(apiKey_phase1);

            var baseUrl = _weatherSettings.BaseUrl;

            var url = $"{baseUrl}weather?q={city}&appid={apiKey_phase2}&units=metric";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<WeatherAPIResponse>(json);
            return result;
        }
    }
}