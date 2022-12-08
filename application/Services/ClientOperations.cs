using Repo;
using Shared;

namespace Services;

public class ClientOperations : IClientOperations
{
    IRepository repository;
    public ClientOperations()
    {
        IRepository repository = Repository.Instance;
    }
    public bool checkClientCredentials(string login, string password)
    {
        return repository.CheckCredentialsClient(login, password);
    }

    public void registerNewClient(string login, string password)
    {
        Client client = new Client("name", "surname", "address", "postalCode", login, password);
    }
    /*
    public void registerNewClient(string name, string surname, string address, string postalCode, string login, string password)
    {
        Client client = new Client(name, surname, address, postalCode, login, password);
    }*/

    public bool updateClient(Client client)
    {
        return repository.UpdateClient(client);
    }
    /*
    public bool updateClient(string name, string surname, string address, string postalCode, string login, string password)
    {
        Client client = new Client(name, surname, address, postalCode, login, password);
        return repository.UpdateClient(client);
    }*/

    public void AddClientOrder(Order order)
    {
        repository.AddClientOrder(order);
    }

    public List<Order> GetClientOrders(Guid clientID)
    {
        return repository.GetClientOrders(clientID);
    }


}