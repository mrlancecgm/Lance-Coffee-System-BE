using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using LanceCoffeeSystem.Application.Interfaces.Shared;
using LanceCoffeeSystem.Api;

namespace LanceCoffeeSystem.Tests.Factories.TempWith29Celsius;

public class TempWith29CelsiusFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddTransient<IWeatherService, CoolerWeatherMock>();
            services.AddTransient<IDateTimeService, NormalDateMock>();
            services.AddTransient<ICoffeeCounterService, AvailableCounterMock>();
        });
    }
}

public class CoolerWeatherMock : IWeatherService
{
    public Task<WeatherAPIResponse> GetCurrentWeatherAsync(string location)
    {
        return Task.FromResult(new WeatherAPIResponse
        {
            main = new MainInfo { temp = 29.0 }
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