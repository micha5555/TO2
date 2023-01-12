using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Bogus;
using Services;
using Shared;

public class ProductsToOfferBenchmark
{
    private List<Product> products = new List<Product>();
    private IGeneralOperations _generalOperations = new GeneralOperations();
    private IOfferOperations _offerOperations = new OfferOperations();

    [Params(10)]
    public int N;

    [GlobalSetup]
    public void setup()
    {
        _generalOperations.ReadDataOnLaunch();

        var ProductFaker = new Faker<Product>(locale: "pl")
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
        // foreach (Product p in products)
        // {
        //     Console.WriteLine(JsonSerializer.Serialize(p));
        // }
    }

    [Benchmark]
    public void AddingProductsToOffer()
    {
        _offerOperations.AddToOffer(products);
    }
}