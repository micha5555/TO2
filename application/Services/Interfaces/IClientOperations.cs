using Shared;

namespace Services;

public interface IClientOperations
{
    public bool checkClientCredentials(string login, string password);
    public void registerNewClient(string name, string surname, string address, string postalCode, string login, string password);
    public void updateClientAddress(Guid clientID, string address, string postalCode);
    public void AddClientOrder(Order order);
    public List<Order> GetClientOrders(Guid clientID);
    
}
