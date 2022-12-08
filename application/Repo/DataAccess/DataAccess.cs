using Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Repo.DataAccessClass
{

    public class DataAccess : IDataAccess
    {
        public List<Cart> CartList { get; set; }
        public List<Offer> OfferList { get; set; }
        public List<Client> ClientList { get; set; }
        public List<Administrator> AdminList { get; set; }
        public List<Order> OrderList { get; set; }
        private string cartPath = "carts.json";
        private string offerPath = "offers.json";
        private string clientPath = "clients.json";
        private string adminPath = "admins.json";
        private string orderPath = "orders.json";
        private JsonSerializerOptions options = new JsonSerializerOptions() { IncludeFields = true };


        private static DataAccess instance = null;
        private DataAccess()
        {
            this.CartList = new List<Cart>();
            this.OfferList = new List<Offer>();
            this.ClientList = new List<Client>();
            this.AdminList = new List<Administrator>();
            this.OrderList = new List<Order>();
        }

        public static DataAccess Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new DataAccess();
                }
                return instance;
            }
        }
        public void SerializeAll()
        {
            SerializeObject(this.CartList, cartPath);
            SerializeObject(this.OfferList, offerPath);
            SerializeObject(this.ClientList, clientPath);
            SerializeObject(this.AdminList, adminPath);
            SerializeObject(this.OrderList, orderPath);
        }
        public void DeserializeAll()
        {
            if (File.Exists(cartPath))
            {
                this.CartList = DeserializeCarts(cartPath);
            }
            else
            {
                this.CartList = new List<Cart>();
            }
            if (File.Exists(offerPath))
            {
                this.OfferList = DeserializeOffers(offerPath);
            }
            else
            {
                this.OfferList = new List<Offer> { new Offer() };
            }
            if (File.Exists(clientPath))
            {
                this.ClientList = DeserializeClients(clientPath);
            }
            else
            {
                this.ClientList = new List<Client>();
            }
            if (File.Exists(adminPath))
            {
                this.AdminList = DeserializeAdmins(adminPath);
            }
            else
            {
                this.AdminList = new List<Administrator>();
                this.AdminList.Add(new Administrator("test", "test"));
            }
            if (File.Exists(orderPath))
            {
                this.OrderList = DeserializeOrders(orderPath);
            }
            else
            {
                this.OrderList = new List<Order>();
            }
        }

        private bool SerializeObject<T>(List<T> list, string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fs = File.Create(path));
            Console.WriteLine("list");
            string json = JsonSerializer.Serialize(list, options);
            File.WriteAllText(path, json);
            return true;
        }

        // private List<T> DeserializeObject<T>(List<T> list, string path)
        // {
        //     string json = File.ReadAllText(path);
        //     List<T>? listT = JsonSerializer.Deserialize<List<T>>(json);
        //     if(listT is null){
        //         throw new Exception("Deserialized list is not valid.");
        //     }
        //     if (File.Exists(path))
        //     {
        //         File.Delete(path);
        //     }
        //     return listT;
        // }
        private List<Administrator> DeserializeAdmins(string path)
        {
            string json = File.ReadAllText(path);
            List<Administrator>? admins = JsonSerializer.Deserialize<List<Administrator>>(json, options);
            if (admins is null)
            {
                throw new Exception("Deserialized list is not valid.");
            }
            return admins;
        }
        private List<Client> DeserializeClients(string path)
        {
            string json = File.ReadAllText(path);
            List<Client>? clients = JsonSerializer.Deserialize<List<Client>>(json, options);

            if (clients is null)
            {
                throw new Exception("Deserialized list is not valid.");
            }
            return clients;
        }
        private List<Offer> DeserializeOffers(string path)
        {
            string json = File.ReadAllText(path);
            List<Offer>? offers = JsonSerializer.Deserialize<List<Offer>>(json, options);
            if (offers is null)
            {
                throw new Exception("Deserialized list is not valid.");
            }
            return offers;
        }
        private List<Order> DeserializeOrders(string path)
        {
            string json = File.ReadAllText(path);
            List<Order>? orders = JsonSerializer.Deserialize<List<Order>>(json, options);
            if (orders is null)
            {
                throw new Exception("Deserialized list is not valid.");
            }
            return orders;
        }
        private List<Cart> DeserializeCarts(string path)
        {
            string json = File.ReadAllText(path);
            List<Cart>? carts = JsonSerializer.Deserialize<List<Cart>>(json, options);

            if (carts is null)
            {
                throw new Exception("Deserialized list is not valid.");
            }
            return carts;
        }
    }

}