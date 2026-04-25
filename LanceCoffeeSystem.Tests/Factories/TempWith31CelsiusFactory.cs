using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using LanceCoffeeSystem.Application.Interfaces.Shared;
using LanceCoffeeSystem.Api;

namespace LanceCoffeeSystem.Tests.Factories.TempWith31Celsius;

public class TempWith31CelsiusFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddTransient<IWeatherService, HotterWeatherMock>();
            services.AddTransient<IDateTimeService, NormalDateMock>();
            services.AddTransient<ICoffeeCounterService, AvailableCounterMock>();
        });
    }
}

public class HotterWeatherMock : IWeatherService
{
    public Task<WeatherAPIResponse> GetCurrentWeatherAsync(string location)
    {
        return Task.FromResult(new WeatherAPIResponse
        {
            main = new MainInfo { temp = 31.0 }
        });
    }
}

public class NormalDateMock : IDateTimeService
{
    public DateTime NowUtc => new DateTime(2026, 4, 25);
}

public class AvailableCounterMock : ICoffeeCounterService
{
    public int Increment() => 1;
}