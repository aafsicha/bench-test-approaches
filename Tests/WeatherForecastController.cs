using Api.Controllers;
using BenchmarkDotNet.Attributes;
using FluentAssertions;
using Microsoft.Extensions.Logging;
namespace NunitOnControllers;

[MemoryDiagnoser]
public class WeatherForecastConstrollerTests
{
    private readonly ILogger<WeatherForecastController> _logger;
    private WeatherForecastController _controller;

    public WeatherForecastConstrollerTests()
    {
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter("Microsoft", LogLevel.Warning)
                .AddFilter("System", LogLevel.Warning)
                .AddFilter("NonHostConsoleApp.Program", LogLevel.Debug)
                .AddConsole();
        });
        _logger = loggerFactory.CreateLogger<WeatherForecastController>();
    }
    
    [Benchmark(Baseline = true)]
    [Test]
    public void List_weather_forecast_summaries()
    {
        _controller = new WeatherForecastController(_logger);
        var liste = _controller.Get();
        liste.Should().NotBeEmpty();
    }
}