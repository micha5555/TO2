using BenchmarkDotNet.Attributes;
using Services;
using Shared;

namespace Benchmark;

[MemoryDiagnoser]
public class OrderBenchmark{


    private List<Product> products = new List<Product>();
    private IOrderOperations _orderOperations = new OrderOperations();
    private IGeneralOperations _generalOperations = new GeneralOperations();
    private Client client;
    private Order order;

    [GlobalSetup]
    public void GlobalSetup(){
        List<Client> clients = Common.GenerateClients(1);
        client = clients[0];
        order = new Order(client);
    }

    [IterationSetup]
    public void IterationSetup(){
        _generalOperations.ReadDataOnLaunch();
    }

    [Benchmark]
    public void CreratingOrder()
    {
        _orderOperations.CreateOrder(client);
    }
}