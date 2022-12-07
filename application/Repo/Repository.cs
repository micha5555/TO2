using Shared;
using Repo.DataAccessClass;
namespace Repo
{

    public class Repository : IRepository
    {
        private DataAccess dataAccess;
        private static Repository instance = null;
        private Repository() { 
            this.dataAccess = DataAccess.Instance;
        }
        public static Repository Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new Repository();
                }
                return instance;
            }
        }
        public void AddAdministrator(Administrator admin)
        {
            throw new NotImplementedException();
        }

        public bool CheckCredentialsAdmin(string login, string password)
        {
            throw new NotImplementedException();
        }

        public bool CheckCredentialsClient(string login, string password)
        {
            throw new NotImplementedException();
        }

        public List<Product> FilterProducts(string name, double price, Category category)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllOfferProducts()
        {
            throw new NotImplementedException();
        }

        public Cart GetCart(Guid clientID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders(Guid clientID)
        {
            return dataAccess.OrderList.Select(o => {
                return new { success = o.Id.Equals(clientID), value = o};
            })
            .Where(o => o.success)
            .Select(v => (Order)v.value).ToList();
        }

        public bool UpdateClient(Client clientData)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }

}