using FluentAssertions;
using LanceCoffeeSystem.Tests.Factories.AprilOne;
using LanceCoffeeSystem.Tests.Factories.FifthCall;
using LanceCoffeeSystem.Tests.Factories.SixthCall;
using LanceCoffeeSystem.Tests.Factories.Success;
using LanceCoffeeSystem.Tests.Factories.TempWith29Celsius;
using LanceCoffeeSystem.Tests.Factories.TempWith30Celsius;
using LanceCoffeeSystem.Tests.Factories.TempWith30Point1Celsius;
using LanceCoffeeSystem.Tests.Factories.TempWith31Celsius;
using LanceCoffeeSystem.Tests.Factories.TenthCall;
using System.Text.Json;

namespace LanceCoffeeSystem.Tests.Tests;

public class CoffeeSystemTest
{
    [Fact]
    public async Task Should_Return_Piping_Hot_Coffee_Status200_MessagePrepared_Keys()
    {
        var factory = new SuccessFactory();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/v1/BrewCoffee/brew-coffee");
        var content = await response.Content.ReadAsStringAsync();
        using var json = JsonDocument.Parse(content);
        var root = json.RootElement;
        
        content.Should().Contain("Your piping hot coffee is ready.");
        ((int)response.StatusCode).Should().Be(200);
        root.TryGetProperty("message", out _).Should().BeTrue();
        root.TryGetProperty("prepared", out _).Should().BeTrue();
    }

    [Fact]
    public async Task Should_Return_503_Status_Code_On_Fifth_Call()
    {
        var factory = new FifthCallFactory(); 
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/v1/BrewCoffee/brew-coffee");

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.ServiceUnavailable);
    }

    [Fact]
    public async Task Should_Return_418_Status_Code_If_April_One()
    {
        var factory = new April1Factory();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/v1/BrewCoffee/brew-coffee");

        ((int)response.StatusCode).Should().Be(418);
    }

    [Fact]
    public async Task Should_Not_Return_503_Status_Code_On_Sixth_Call()
    {
        var factory = new SixthCallFactory();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/v1/BrewCoffee/brew-coffee");
        var content = await response.Content.ReadAsStringAsync();
        using var json = JsonDocument.Parse(content);
        var root = json.RootElement;

        response.StatusCode.Should().NotBe(System.Net.HttpStatusCode.ServiceUnavailable);
        ((int)response.StatusCode).Should().Be(200);
        root.TryGetProperty("message", out _).Should().BeTrue();
        root.TryGetProperty("prepared", out _).Should().BeTrue();
    }

    [Fact]
    public async Task Should_Return_503_Status_Code_On_Tenth_Call()
    {
        var factory = new TenthCallFactory();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/v1/BrewCoffee/brew-coffee");

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.ServiceUnavailable);
    }

    [Fact]
    public async Task Should_Return_Iced_Coffee_When_Temp_Greater_Than_30()
    {
        var factory = new TempWith31CelsiusFactory();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/v1/BrewCoffee/brew-coffee");
        var content = await response.Content.ReadAsStringAsync();
        using var json = JsonDocument.Parse(content);
        var root = json.RootElement;

        content.Should().Contain("refreshing iced coffee");
        ((int)response.StatusCode).Should().Be(200);
        root.TryGetProperty("message", out _).Should().BeTrue();
        root.TryGetProperty("prepared", out _).Should().BeTrue();
    }

    [Fact]
    public async Task Should_Return_Hot_Coffee_When_Temp_Equals_30()
    {
        var factory = new TempWith30CelsiusFactory();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/v1/BrewCoffee/brew-coffee");
        var content = await response.Content.ReadAsStringAsync();
        using var json = JsonDocument.Parse(content);
        var root = json.RootElement;

        content.Should().Contain("piping hot coffee");
        ((int)response.StatusCode).Should().Be(200);
        root.TryGetProperty("message", out _).Should().BeTrue();
        root.TryGetProperty("prepared", out _).Should().BeTrue();
    }

    [Fact]
    public async Task Should_Return_Hot_Coffee_When_Temp_Less_Than_30()
    {
        var factory = new TempWith29CelsiusFactory();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/v1/BrewCoffee/brew-coffee");
        var content = await response.Content.ReadAsStringAsync();
        using var json = JsonDocument.Parse(content);
        var root = json.RootElement;

        content.Should().Contain("piping hot coffee");
        ((int)response.StatusCode).Should().Be(200);
        root.TryGetProperty("message", out _).Should().BeTrue();
        root.TryGetProperty("prepared", out _).Should().BeTrue();
    }

    [Fact]
    public async Task Should_Return_Iced_Coffee_When_Little_Excess_On_30()
    {
        var factory = new TempWith30Point1CelsiusFactory();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/v1/BrewCoffee/brew-coffee");
        var content = await response.Content.ReadAsStringAsync();
        content.Should().Contain("refreshing iced coffee");
        using var json = JsonDocument.Parse(content);
        var root = json.RootElement;

        ((int)response.StatusCode).Should().Be(200);
        root.TryGetProperty("message", out _).Should().BeTrue();
        root.TryGetProperty("prepared", out _).Should().BeTrue();
    }
}