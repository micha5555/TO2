﻿using Benchmark;
using BenchmarkDotNet.Running;

public class ddd
{
    public static void Main()
    {

        var summary = BenchmarkRunner.Run<ProductsToOfferBenchmark>();
    }

}
