using Repo;
using Shared;

namespace Services;

public class ClientOperations : IClientOperations
{
    IRepository repository;
    public ClientOperations()
    {
        repository = Repository.Instance;
    }
    public bool checkClientCredentials(string login, string password)
    {
        return repository.CheckCredentialsClient(login, password);
    }

    public void registerNewClient(string name, string surname, string address, string postalCode, string login, string password)
    {
        Client client = new Client(name, surname, address, postalCode, login, password);
        //repository.AddClient(client);
    }
    public void updateClientAddress(Guid clientID, string address, string postalCode)
    {
        /*Client client = repository.GetClient(clientID);
        client.Address = address;
        client.PostalCode = postalCode;
        repository.UpdateClient(client)*/
    }

    public void AddClientOrder(Order order)
    {
        repository.AddClientOrder(order);
    }

    public List<Order> GetClientOrders(Guid clientID)
    {
        return repository.GetClientOrders(clientID);
    }


}