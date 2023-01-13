using Benchmark;
using BenchmarkDotNet.Attributes;
using Services;
using Shared;

[MemoryDiagnoser]
public class UserRegisterBenchmark
{
    private List<Client> clients = new List<Client>();
    private IClientOperations _clientOperations = new ClientOperations();
    private IGeneralOperations _generalOperations = new GeneralOperations();


    [Params(100, 1000, 10000)]
    public int N;

    [IterationSetup]
    public void setup()
    {
        _clientOperations = new ClientOperations();
        _generalOperations = new GeneralOperations();
        _generalOperations.ReadDataOnLaunch();

        clients = Common.GenerateClients(N);
    }

    [Benchmark]
    public void AddingProductsToOffer()
    {
        foreach (Client c in clients)
        {
            _clientOperations.registerNewClient(c.Name, c.Surname, c.Address, c.PostalCode, c.Login, c.Password);
        }
    }
}