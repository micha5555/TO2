using BenchmarkDotNet.Attributes;
using Services;
using Shared;

namespace Benchmark;

[MemoryDiagnoser]
public class OrderBenchmark{

    private List<CartProduct> products = new List<CartProduct>();
    private IOrderOperations _orderOperations = new OrderOperations();
    private IGeneralOperations _generalOperations = new GeneralOperations();
    private Client? client;
    private Order? order;

    [Params(1, 10, 20)]
    public int N;

    [IterationSetup]
    public void IterationSetup(){
        _generalOperations.ReadDataOnLaunch();
        products = Common.GenerateCartProducts(5);
        List<Client> clients = Common.GenerateClients(1);
        client = clients[0];
        foreach(CartProduct cp in products){
            client.Cart.AddToCart(cp);
        }
        order = new Order(client);
    }

    [Benchmark]
    public void CreatingOrder()
    {
        _orderOperations.CreateOrder(client);
    }
}