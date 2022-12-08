using Frontend;
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

    public RegistrationStatus registerNewClient(string name, string surname, string address, string postalCode, string login, string password)
    {
        Client client = new Client(name, surname, address, postalCode, login, password);
        bool status = repository.AddClient(client);
        return status? RegistrationStatus.Registered : RegistrationStatus.NotRegistered;
    }
    public void updateClientAddress(Guid clientID, string address, string postalCode)
    {
        Client client = repository.GetClientById(clientID);
        client.Address = address;
        client.PostalCode = postalCode;
        repository.UpdateClient(client);
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