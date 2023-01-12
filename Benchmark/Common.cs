using Bogus;
using Shared;

namespace Benchmark;

public class Common{
    public static List<Product> GenerateProductsList(int quantity){
        List<Product> products = new List<Product>();
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

        for (int i = 0; i < quantity; i++)
        {
            products.Add(ProductFaker.Generate());
        }
        return products;
    }
}