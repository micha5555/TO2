``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 10 (10.0.19044.2364/21H2/November2021Update)
11th Gen Intel Core i5-11600KF 3.90GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2
  Job-HBWIOJ : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2

InvocationCount=1  UnrollFactor=1  

```
|               Method |     N | Mean | Error |
|--------------------- |------ |-----:|------:|
| **AddingProductsToCart** |   **100** |   **NA** |    **NA** |
| **AddingProductsToCart** |  **1000** |   **NA** |    **NA** |
| **AddingProductsToCart** | **10000** |   **NA** |    **NA** |

Benchmarks with issues:
  ProductsToCartBenchmark.AddingProductsToCart: Job-HBWIOJ(InvocationCount=1, UnrollFactor=1) [N=100]
  ProductsToCartBenchmark.AddingProductsToCart: Job-HBWIOJ(InvocationCount=1, UnrollFactor=1) [N=1000]
  ProductsToCartBenchmark.AddingProductsToCart: Job-HBWIOJ(InvocationCount=1, UnrollFactor=1) [N=10000]
