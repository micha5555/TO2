using Shared;
using Repo.DataAccessClass;
namespace Repo
{

    public class Repository : IRepository
    {
        private DataAccess dataAccess;
        private static Repository instance = null;
        private Repository()
        {
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
        public int AddAdministrator(Administrator admin)
        {
            if (dataAccess.AdminList.Contains(admin))
            {
                return -1;
            }
            dataAccess.AdminList.Add(admin);
            return 0;
        }

        public bool CheckCredentialsAdmin(string login, string password)
        {
            var item = dataAccess.AdminList.FirstOrDefault(x => (x.Login.Equals(login) && x.Password.Equals(password)));
            if (item is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckCredentialsClient(string login, string password)
        {
            var item = dataAccess.ClientList.FirstOrDefault(x => (x.Login.Equals(login) && x.Password.Equals(password)));
            if (item is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Product> GetAllOfferProducts()
        {
            return dataAccess.OfferList[0].GetProductList();
        }

        public List<Order> GetClientOrders(Guid clientID)
        {
            return dataAccess.OrderList.Select(o =>
            {
                return new { success = o.ClientId.Equals(clientID), value = o };
            })
            .Where(o => o.success)
            .Select(v => (Order)v.value).ToList();
        }
        public List<Order> GetOrders()
        {
            return dataAccess.OrderList;
        }
        public void AddClientOrder(Order order)
        {
            dataAccess.OrderList.Add(order);
        }
        public bool UpdateClient(Client clientData)
        {
            int index = dataAccess.ClientList.FindIndex(x => x.Id == clientData.Id);
            if (index == -1)
            {
                return false;
            }
            dataAccess.ClientList[index] = clientData;
            return true;
        }

        public bool UpdateOrder(Order order)
        {
            int index = dataAccess.OrderList.FindIndex(x => x.Id == order.Id);
            if (index == -1)
            {
                return false;
            }
            dataAccess.OrderList[index] = order;
            return true;
        }

        public List<Product> FilterProductsByCategory(Category category)
        {
            var offerList = GetAllOfferProducts();
            var filteredList = new List<Product>();
            foreach (Product p in offerList)
            {
                if (p.CategoryClass == category)
                {
                    filteredList.Add(p);
                }
            }
            return filteredList;
        }
    
        public List<Product> SearchForProductsByName(string name)
        {
            var offerList = GetAllOfferProducts();
            var filteredList = new List<Product>();
            foreach (Product p in offerList)
            {
                if (p.Name.Contains(name))
                {
                    filteredList.Add(p);
                }
            }
            return filteredList;
        }
    }

}