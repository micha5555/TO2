namespace Repo
{

    public interface IRepository
    {
        public void AddAdministrator(Shared.Administrator admin);
        public bool CheckCredentialsAdmin(string login, string password);
        public bool CheckCredentialsClient(string login, string password);
        public List<Shared.Product> GetAllOfferProducts();
        public List<Shared.Product> FilterProducts(string name, double price, Shared.Category category);
        public Shared.Cart GetCart(Guid clientID);
        public List<Shared.Order> GetOrders(Guid clientID);
        public bool UpdateClient(Shared.Client clientData);
        public bool UpdateOrder(Shared.Order order);
    }

}