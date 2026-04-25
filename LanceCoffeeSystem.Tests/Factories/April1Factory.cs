using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System;
using LanceCoffeeSystem.Application.Interfaces.Shared;
using LanceCoffeeSystem.Api;

namespace LanceCoffeeSystem.Tests.Factories.AprilOne;

public class April1Factory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddTransient<IDateTimeService, AprilOneDateMock>();
            services.AddTransient<ICoffeeCounterService, AvailableCounterMock>();
        });
    }
}

public class AprilOneDateMock : IDateTimeService
{
    public DateTime NowUtc => new DateTime(2026, 4, 1);
}

public class AvailableCounterMock : ICoffeeCounterService
{
    public int Increment() => 1;
}