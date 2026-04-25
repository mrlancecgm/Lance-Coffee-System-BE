using System;
using System.Threading.Tasks;

namespace LanceCoffeeSystem.Application.Interfaces.Shared
{
    public interface IWeatherService
    {
        Task<WeatherAPIResponse> GetCurrentWeatherAsync(string city);
    }
}