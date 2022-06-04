``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.4 (21F79) [Darwin 21.5.0]
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.300
  [Host] : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT DEBUG


```
|                          Method | Mean | Error | Ratio | RatioSD |
|-------------------------------- |-----:|------:|------:|--------:|
| List_weather_forecast_summaries |   NA |    NA |     ? |       ? |

Benchmarks with issues:
  WeatherForecastConstrollerOverHttpTests.List_weather_forecast_summaries: DefaultJob
