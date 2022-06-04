using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace Api.Specs;

[Binding]
public class WeatherSteps
{
    public WeatherSteps()
    {
        _application = new WebApplicationFactory<Program>();
    }
    private List<WeatherForecast> res;
    private WebApplicationFactory<Program> _application;

    [When(@"i get the forecasts")]
    public async Task WhenIGetTheForecasts()
    {
        var client = _application.CreateClient();
        var responseMessage = await client.GetAsync("/WeatherForecast");
        responseMessage.EnsureSuccessStatusCode();
        var responseContent = await responseMessage.Content.ReadAsStringAsync();
        res = JsonConvert.DeserializeObject<List<WeatherForecast>>(responseContent);
    }

    [Then(@"i get (.*) results")]
    public void ThenIGetResults(int p0)
    {
        res.Should().NotBeEmpty();
    }
}