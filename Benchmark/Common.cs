using Bogus;
using Services;
using Shared;

namespace Benchmark;

public class Common
{
    public static List<Product> GenerateProductsList(int quantity)
    {
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

    public static List<Client> GenerateClients(int quantity)
    {
        List<Client> clients = new List<Client>();
        var ClientFaker = new Faker<Client>()
            .RuleFor(client => client.Id, Guid.NewGuid())
            .RuleFor(client => client.Name, x => x.Name.FirstName())
            .RuleFor(client => client.Surname, x => x.Name.LastName())
            .RuleFor(client => client.Address, x => x.Address.StreetAddress())
            .RuleFor(client => client.PostalCode, x => x.Address.ZipCode())
            .RuleFor(client => client.Login, x => "login")
            .RuleFor(client => client.Password, x => "passwd");

        for (int i = 0; i < quantity; i++)
        {
            clients.Add(ClientFaker.Generate());
        }

        return clients;
    }

    public static void FillClientsCarts(List<Client> clients, List<Product> products, int chanceOfAddingToCart = 20)
    {
        var random = new Random();
        foreach (var client in clients)
        {
            CartOperations cartOperations = new CartOperations(client.Id);
            foreach (var product in products)
            {
                if (random.Next(100) < chanceOfAddingToCart)
                {
                    cartOperations.AddToCart(new CartProduct(product, random.Next(1, 10)));
                }
            }
        }
    }

    public static void GenerateOrders(List<Client> clients)
    {
        OrderOperations orderOperations = new OrderOperations();
        foreach (var client in clients)
        {
            orderOperations.CreateOrder(client);
        }
    }
}