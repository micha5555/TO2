``` ini

BenchmarkDotNet=v0.13.3, OS=ubuntu 22.04
AMD Ryzen 5 5600H with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.113
  [Host]     : .NET 6.0.13 (6.0.1322.60201), X64 RyuJIT AVX2
  Job-MBPRDL : .NET 6.0.13 (6.0.1322.60201), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|               Method |     N |         Mean |        Error |       StdDev | Allocated |
|--------------------- |------ |-------------:|-------------:|-------------:|----------:|
| **AddingProductsToCart** |   **100** |     **161.7 μs** |      **2.39 μs** |      **2.46 μs** |   **3.39 KB** |
| **AddingProductsToCart** |  **1000** |   **9,173.3 μs** |    **182.37 μs** |    **261.55 μs** |  **17.46 KB** |
| **AddingProductsToCart** | **10000** | **978,414.2 μs** | **18,903.71 μs** | **17,682.54 μs** |  **257.6 KB** |
