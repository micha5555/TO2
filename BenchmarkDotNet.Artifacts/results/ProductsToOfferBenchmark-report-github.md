``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 10 (10.0.19044.2364/21H2/November2021Update)
11th Gen Intel Core i5-11600KF 3.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2
  Job-HBWIOJ : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|                Method |     N |     Mean |     Error |    StdDev | Allocated |
|---------------------- |------ |---------:|----------:|----------:|----------:|
| **AddingProductsToOffer** |   **100** | **4.398 μs** | **0.4473 μs** | **1.3119 μs** |   **1.76 KB** |
| **AddingProductsToOffer** |  **1000** | **4.883 μs** | **0.3258 μs** | **0.9190 μs** |   **8.79 KB** |
| **AddingProductsToOffer** | **10000** | **8.782 μs** | **0.4974 μs** | **1.4111 μs** |   **79.1 KB** |
