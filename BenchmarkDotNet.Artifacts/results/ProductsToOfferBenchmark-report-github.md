``` ini

BenchmarkDotNet=v0.13.3, OS=ubuntu 22.04
AMD Ryzen 5 5600H with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.113
  [Host]     : .NET 6.0.13 (6.0.1322.60201), X64 RyuJIT AVX2
  Job-MBPRDL : .NET 6.0.13 (6.0.1322.60201), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|                Method |     N |      Mean |     Error |    StdDev | Allocated |
|---------------------- |------ |----------:|----------:|----------:|----------:|
| **AddingProductsToOffer** |   **100** |  **2.878 μs** | **0.3250 μs** | **0.9168 μs** |   **1.76 KB** |
| **AddingProductsToOffer** |  **1000** |  **6.046 μs** | **0.5815 μs** | **1.6402 μs** |   **8.79 KB** |
| **AddingProductsToOffer** | **10000** | **15.212 μs** | **1.0891 μs** | **3.1073 μs** |   **79.1 KB** |
