using System.Text.Json;
using Benchmark;
using BenchmarkDotNet.Attributes;
using Bogus;
using Services;
using Shared;

[MemoryDiagnoser]
public class ProductsToCartBenchmark
{
    private List<Product> products;
    private IGeneralOperations _generalOperations;
    private ICartOperations _cartOperations;
    private IClientOperations _clientOperations;


    [Params(100, 1000, 10000)]
    public int N;

    [IterationSetup]
    public void setup()
    {
        _clientOperations = new ClientOperations();
        

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