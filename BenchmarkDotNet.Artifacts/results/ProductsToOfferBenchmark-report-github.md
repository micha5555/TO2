``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 10 (10.0.19044.2364/21H2/November2021Update)
11th Gen Intel Core i5-11600KF 3.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2
  Job-FPURMO : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|                Method |     N |     Mean |     Error |   StdDev | Allocated |
|---------------------- |------ |---------:|----------:|---------:|----------:|
| **AddingProductsToOffer** |   **100** | **4.392 μs** | **0.4496 μs** | **1.318 μs** |   **1.76 KB** |
| **AddingProductsToOffer** |  **1000** | **4.807 μs** | **0.3944 μs** | **1.138 μs** |   **8.79 KB** |
| **AddingProductsToOffer** | **10000** | **7.872 μs** | **0.3891 μs** | **1.097 μs** |   **79.1 KB** |
