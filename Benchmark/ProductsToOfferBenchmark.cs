using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Bogus;
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
        products = new List<Product>();

        Randomizer.Seed = new Random(543345);
        var ProductFaker = new Faker<Product>()
        .RuleFor(product => product.Id, Guid.NewGuid())
        .RuleFor(product => product.Name, x => x.Commerce.ProductName())
        .RuleFor(product => product.Price, x => Math.Round(x.Random.Double(5, 3000), 2))
        .RuleFor(product => product.CategoryClass, x =>
        {
            int tmp = x.Random.Int(0, 3);
            return (Category)tmp;
        })
        .RuleFor(product => product.Description, x => x.Lorem.Sentences(3, " "))
        .RuleFor(product => product.isActive, true);

        for (int i = 0; i < N; i++)
        {
            products.Add(ProductFaker.Generate());
        }
    }

    [Benchmark]
    public void AddingProductsToOffer()
    {
        _offerOperations.AddToOffer(products);
    }
}