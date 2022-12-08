using Shared;

namespace Services;

public interface IClientOperations
{
    public bool checkClientCredentials(string login, string password);
    //public void registerNewClient(string Name, string Surname, string Address, string PostalCode, string Login, string Password);
    public void registerNewClient(string Login, string Password);
    public void AddClientOrder(Order order);
    public List<Order> GetClientOrders(Guid clientID);
    
}

