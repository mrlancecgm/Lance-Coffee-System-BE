using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System;
using LanceCoffeeSystem.Application.Interfaces.Shared;
using LanceCoffeeSystem.Api;

namespace LanceCoffeeSystem.Tests.Factories.Success;

public class SuccessFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddTransient<IDateTimeService, NormalDateMock>();
            services.AddTransient<ICoffeeCounterService, AvailableCounterMock>();
        });
    }
}

public class NormalDateMock : IDateTimeService
{
    public DateTime NowUtc => new DateTime(2026, 3, 10);
}

public class AvailableCounterMock : ICoffeeCounterService
{
    public int Increment() => 1;
}