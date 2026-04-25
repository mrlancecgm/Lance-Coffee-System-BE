using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using LanceCoffeeSystem.Application.Interfaces.Shared;
using LanceCoffeeSystem.Api;

namespace LanceCoffeeSystem.Tests.Factories.TempWith30Celsius;

public class TempWith30CelsiusFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddTransient<IWeatherService, Equal30WeatherMock>();
            services.AddTransient<IDateTimeService, NormalDateMock>();
            services.AddTransient<ICoffeeCounterService, AvailableCounterMock>();
        });
    }
}

public class Equal30WeatherMock : IWeatherService
{
    public Task<WeatherAPIResponse> GetCurrentWeatherAsync(string location)
    {
        return Task.FromResult(new WeatherAPIResponse
        {
            main = new MainInfo { temp = 30.0 }
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