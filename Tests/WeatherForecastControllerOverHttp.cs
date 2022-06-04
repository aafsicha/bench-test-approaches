using Api;
using Api.Controllers;
using BenchmarkDotNet.Attributes;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace NunitOnControllers;

[MemoryDiagnoser]
public class WeatherForecastConstrollerOverHttpTests
{
    private readonly ILogger<WeatherForecastController> _logger;
    private WeatherForecastController _controller;
    private readonly WebApplicationFactory<Program> _application;
    private readonly HttpClient _client;

    public WeatherForecastConstrollerOverHttpTests()
    {
        _application = new WebApplicationFactory<Program>();
        _client = _application.CreateClient();
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
    public async Task List_weather_forecast_summaries()
    {
        
        var responseMessage = await _client.GetAsync("/WeatherForecast");
        var responseContent = await responseMessage.Content.ReadAsStringAsync();
        var res = JsonConvert.DeserializeObject<List<WeatherForecast>>(responseContent);
        res.Should().NotBeEmpty();
    }
}