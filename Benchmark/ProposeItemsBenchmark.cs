using BenchmarkDotNet.Attributes;
using Services;
using Shared;

namespace Benchmark;

[MemoryDiagnoser]
public class ProposeItemsBenchmark
{
    [Params(10, 100, 500)] public int clientsQuantity;

    [Params(10, 100, 500)] public int productsQuantity;

    [Params(5, 10, 20, 30)] public int proposeProductsQuantity;
    private List<Product> _products = new List<Product>();
    private List<Client> _clients = new List<Client>();
    private IGeneralOperations _generalOperations = new GeneralOperations();
    private IOfferOperations _offerOperations = new OfferOperations();

    [IterationSetup]
    public void setup()
    {
        _offerOperations = new OfferOperations();
        _generalOperations = new GeneralOperations();
        _generalOperations.ReadDataOnLaunch();
        _clients = Common.GenerateClients(clientsQuantity);
        _products = Common.GenerateProductsList(productsQuantity);
        Common.FillClientsCarts(_clients,_products);
        Common.GenerateOrders(_clients);
        Common.FillClientsCarts(_clients, _products);
    }

    [Benchmark]
    public void ProposingItemsByCart()
    {
        foreach (var client in _clients)
        {
            _generalOperations.ProposeProductsBasedOnCart(client.Cart, proposeProductsQuantity);
        }
    }

    [Benchmark]
    public void ProposingItemsByProduct()
    {
        foreach (var product in _products)
        {
            _generalOperations.ProposeProductsBasedOnProduct(product, proposeProductsQuantity);
        }
    }
}