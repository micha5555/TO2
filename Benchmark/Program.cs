using Benchmark;
using BenchmarkDotNet.Running;

public class ddd
{
    public static void Main()
    {
        var summary = BenchmarkRunner.Run<ProductsToOfferBenchmark>();
        var summary2 = BenchmarkRunner.Run<OrderBenchmark>();
        var summary3 = BenchmarkRunner.Run<ProductsToCartBenchmark>();
        var summary4 = BenchmarkRunner.Run<ProposeItemsBenchmark>();
    }

}