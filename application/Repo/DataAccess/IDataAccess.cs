namespace Repo.DataAccessClass
{

    public interface IDataAccess
    {
        List<Shared.Cart> CartList { get; set; }
        List<Shared.Offer> OfferList { get; set; }
        List<Shared.Client> ClientList { get; set; }
        List<Shared.Administrator> AdminList { get; set; }
        List<Shared.Order> OrderList { get; set; }
        public void SerializeAll();
        public void DeserializeAll();
    }

}