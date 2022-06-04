// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using NunitOnControllers;

var summary = BenchmarkRunner.Run<WeatherForecastConstrollerTests>(
    ManualConfig
        .Create(DefaultConfig.Instance)
        .WithOptions(ConfigOptions.JoinSummary)
        .WithOptions(ConfigOptions.DisableOptimizationsValidator));