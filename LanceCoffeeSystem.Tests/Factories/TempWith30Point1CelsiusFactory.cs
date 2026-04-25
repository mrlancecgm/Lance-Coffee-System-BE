using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using LanceCoffeeSystem.Application.Interfaces.Shared;
using LanceCoffeeSystem.Api;
using LanceCoffeeSystem.Tests.Factories.TempWith30Celsius;

namespace LanceCoffeeSystem.Tests.Factories.TempWith30Point1Celsius;

public class TempWith30Point1CelsiusFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddTransient<IWeatherService, LittleExcessOn30WeatherMock>();
            services.AddTransient<IDateTimeService, NormalDateMock>();
            services.AddTransient<ICoffeeCounterService, AvailableCounterMock>();
        });
    }
}

public class LittleExcessOn30WeatherMock : IWeatherService
{
    public Task<WeatherAPIResponse> GetCurrentWeatherAsync(string location)
    {
        return Task.FromResult(new WeatherAPIResponse
        {
            main = new MainInfo { temp = 30.1 }
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