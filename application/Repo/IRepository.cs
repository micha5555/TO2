using Shared;
namespace Repo
{

    public interface IRepository
    {
        public bool AddAdministrator(Administrator admin);
        public bool CheckCredentialsAdmin(string login, string password);
        public bool CheckCredentialsClient(string login, string password);
        public List<Product> GetAllOfferProducts();
        public List<Product> FilterProductsByCategory(Category category);
        public List<Product> SearchForProductsByName(string name);
        public List<Order> GetClientOrders(Guid clientID);
        public void AddClientOrder(Order order);
        public List<Order> GetOrders();
        public bool UpdateClient(Client clientData);
        public bool UpdateOrder(Order order);
        public bool AddProductToOffer(Product product);
        public bool AddProductsToOffer(List<Product> plist);
        public bool RemoveProductFromOffer(Product product);
        public void ReadDataOnLaunch();
        public void SaveDataOnExit();
        public Client GetClientById(Guid id);
        public bool AddClient(Client client);
    }

}