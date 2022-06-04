``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.4 (21F79) [Darwin 21.5.0]
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT DEBUG
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|                          Method |     Mean |     Error |    StdDev |   Median | Ratio |  Gen 0 | Allocated |
|-------------------------------- |---------:|----------:|----------:|---------:|------:|-------:|----------:|
| List_weather_forecast_summaries | 1.546 μs | 0.0291 μs | 0.0704 μs | 1.518 μs |  1.00 | 0.3662 |      2 KB |
