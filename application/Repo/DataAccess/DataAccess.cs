using Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Repo.DataAccess
{

    public class DataAccess : IDataAccess
    {
        public List<Cart> CartList { get; set; }
        public List<Offer> OfferList { get; set; }
        public List<Client> ClientList { get; set; }
        public List<Administrator> AdminList { get; set; }
        private string cartPath = "carts.json";
        private string offerPath = "offers.json";
        private string clientPath = "clients.json";
        private string adminPath = "admins.json";
        private JsonSerializerOptions options = new JsonSerializerOptions() { IncludeFields = true };


        private static DataAccess instance = null;
        private DataAccess()
        {
            this.CartList = new List<Cart>();
            this.OfferList = new List<Offer>();
            this.ClientList = new List<Client>();
            this.AdminList = new List<Administrator>();
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

        object IDataAccess.DeleteRecord(int id, string name)
        {
            throw new NotImplementedException();
        }

        object IDataAccess.GetRecord(int id, string name)
        {
            throw new NotImplementedException();
        }

        int IDataAccess.SaveRecord(object o)
        {
            throw new NotImplementedException();
        }

        int IDataAccess.UpdateRecord(object o)
        {
            throw new NotImplementedException();
        }

        public void SerializeAll()
        {
            SerializeObject(this.CartList, cartPath);
            SerializeObject(this.OfferList, offerPath);
            SerializeObject(this.ClientList, clientPath);
            SerializeObject(this.AdminList, adminPath);
        }
        public void DeserializeAll()
        {
            this.CartList = DeserializeCarts(cartPath);
            this.OfferList = DeserializeOffers(offerPath);
            this.ClientList = DeserializeClients(clientPath);
            this.AdminList = DeserializeAdmins(adminPath);
        }
        private bool SerializeObject<T>(List<T> list, string path)
        {
            using (FileStream fs = File.Create(path)) ;
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
            if (File.Exists(path))
            {
                File.Delete(path);
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
            if (File.Exists(path))
            {
                File.Delete(path);
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
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            return offers;
        }
        private List<Cart> DeserializeCarts(string path)
        {
            string json = File.ReadAllText(path);
            List<Cart>? carts = JsonSerializer.Deserialize<List<Cart>>(json, options);

            if (carts is null)
            {
                throw new Exception("Deserialized list is not valid.");
            }
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            return carts;
        }
    }

}