using Benchmark;
using BenchmarkDotNet.Attributes;
using Services;
using Shared;

[MemoryDiagnoser]
public class ProductsToOfferBenchmark
{
    private List<Product> products = new List<Product>();
    private IGeneralOperations _generalOperations = new GeneralOperations();
    private IOfferOperations _offerOperations = new OfferOperations();


    [Params(100, 1000, 10000)]
    public int N;

    [IterationSetup]
    public void setup()
    {
        _offerOperations = new OfferOperations();
        _generalOperations = new GeneralOperations();
        _generalOperations.ReadDataOnLaunch();

        products = Common.GenerateProductsList(N);
    }

    [Benchmark]
    public void AddingProductsToOffer()
    {
        _offerOperations.AddToOffer(products);
    }
}