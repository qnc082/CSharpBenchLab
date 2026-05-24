```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7922/25H2/2025Update/HudsonValley2)
Intel Core i5-10210U CPU 1.60GHz (Max: 2.11GHz), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.200
  [Host]     : .NET 10.0.4 (10.0.4, 10.0.426.12010), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.4 (10.0.4, 10.0.426.12010), X64 RyuJIT x86-64-v3


```
| Method                | Mean     | Error     | StdDev    | Median   | Gen0     | Gen1     | Gen2    | Allocated |
|---------------------- |---------:|----------:|----------:|---------:|---------:|---------:|--------:|----------:|
| FilterWithIEnumerable | 3.692 ms | 0.0727 ms | 0.1470 ms | 3.624 ms | 789.0625 | 640.6250 | 15.6250 |   4.53 MB |
| FilterWithIQueryable  | 1.566 ms | 0.0487 ms | 0.1412 ms | 1.506 ms | 273.4375 | 148.4375 |       - |   1.29 MB |
