using System.Text.Json;
using Benchmark;
using BenchmarkDotNet.Attributes;
using Bogus;
using Services;
using Shared;

[MemoryDiagnoser]
public class ProductsToCartBenchmark
{
    private List<CartProduct> cproducts;
    private List<Client> clients;
    private IGeneralOperations _generalOperations;
    private ICartOperations _cartOperations;
    private IClientOperations _clientOperations;


    [Params(100, 1000, 10000)]
    public int N;

    [IterationSetup]
    public void setup()
    {
        _generalOperations = new GeneralOperations();
        _generalOperations.ReadDataOnLaunch();
        _clientOperations = new ClientOperations();
        clients = Common.GenerateClients(1);
        _cartOperations = new CartOperations(clients[0].Id);
        

        cproducts = Common.GenerateCartProducts(N);
    }

    [Benchmark]
    public void AddingProductsToCart()
    {
        foreach(CartProduct cp in cproducts){
        _cartOperations.AddToCart(cp);
        }
    }
}