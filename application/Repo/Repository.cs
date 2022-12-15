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
            // Administrator admin = new Administrator("test", "test");
            // dataAccess.AdminList.Add(admin);
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
        public bool AddAdministrator(Administrator admin)
        {
            if (dataAccess.AdminList.Contains(admin))
            {
                return false;
            }
            dataAccess.AdminList.Add(admin);
            return true;
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
            return dataAccess.OfferList[0].GetProductList().ToList();
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
            return dataAccess.OrderList.ToList();
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
            return filteredList.ToList();
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
            return filteredList.ToList();
        }

        public bool AddProductToOffer(Product product)
        {
            dataAccess.OfferList[0].AddToOffer(product);
            return true;
        }

        public bool AddProductsToOffer(List<Product> plist)
        {
            dataAccess.OfferList[0].AddToOffer(plist);
            return true;
        }

        public bool RemoveProductFromOffer(Product product)
        {
            dataAccess.OfferList[0].RemoveFromOffer(product);
            return true;
        }

        public void ReadDataOnLaunch()
        {
            dataAccess.DeserializeAll();
        }

        public void SaveDataOnExit()
        {
            dataAccess.SerializeAll();
        }

        public bool AddClient(Client client)
        {
            dataAccess.ClientList.Add(client);
            return true;
        }

        public Client GetClientById(Guid id)
        {
            foreach (Client c in dataAccess.ClientList)
            {
                if (c.Id.Equals(id))
                {
                    return c;
                }
            }
            return null;
        }
        public Client GetClientByLogin(string login) 
        {
            foreach (Client c in dataAccess.ClientList) 
            {
                if (c.Login.Equals(login)) 
                {
                    return c;
                }
            }
            return null;
        }
        public bool UpdateProduct(Guid id, Product product) 
        {
            dataAccess.OfferList[0].UpdateProductInOffer(id, product);
            return true;
        }

        public bool AddOffer(Offer offer) 
        {
            dataAccess.OfferList.Add(offer);
            return true;
        }

        public bool AddOrder(Order o) 
        {
            dataAccess.OrderList.Add(o);
            return true;
        }

        public List<Administrator> GetAllAdministrators()
        {
            return dataAccess.AdminList.ToList();
        }

        public bool RemoveAdministrator(Administrator admin)
        {
            dataAccess.AdminList.Remove(admin);
            return true;
        }

        public bool CheckIfAdminExists(string adminLogin)
        {
            return dataAccess.AdminList.ToList().Any(item => item.Login == adminLogin);
        }
    }

}