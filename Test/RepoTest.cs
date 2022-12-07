namespace Test;
using Shared;
using Repo.DataAccess;

public class RepoTest
{
    private DataAccess da;
    [SetUp]
    public void Setup()
    {
        da = DataAccess.Instance;
        List<Product> productList = new List<Product>{
            new Product("p1", 1, Category.CAT1, "desc jakis"),
            new Product("p2", 2, Category.CAT2, "desc jakis"),
            new Product("p3", 4, Category.CAT3, "desc jakis"),
            new Product("p4", 5, Category.CAT1, "desc jakis"),
            new Product("p5", 6, Category.CAT2, "desc jakis"),
            new Product("p6", 7, Category.CAT3, "desc jmmmm")
        };
        da.CartList.Add(new Cart(productList));
        da.CartList.Add(new Cart(productList));
        da.OfferList.Add(new Offer(productList));
        for (int i = 0; i <= 9; i++)
        {
            da.ClientList.Add(new Client("Michalek" + i, "Marciski" + i, "PrzyBazantarnii" + i, "07-990" + i));
            da.AdminList.Add(new Administrator("Marcin" + i, "Niewiadomski" + i, "niepodam" + i, "tajemnica123" + i));
        }
    }

    [Test]
    public void ShouldDeserialize()
    {
        da.SerializeAll();
        da.AdminList = new List<Administrator>();
        da.CartList = new List<Cart>();
        da.ClientList = new List<Client>();
        da.OfferList = new List<Offer>();
       
        da.DeserializeAll();
        //check admin
        string adminNameActual = da.AdminList[0].Name;
        string adminNameExpected = "Marcin0";
        //check client
        string clientNameActual = da.ClientList[0].Name;
        string clientNameExpected = "Michalek0";
        //check offer
        int offerCountActual = da.OfferList[0].GetProductList().Count;
        int offerCountExpected = 6;
        //check cart
        int cartCountActual = da.CartList[0].GetProducts().Count;
        int cartCountExpected = 6;

        Assert.AreEqual(adminNameExpected, adminNameActual);
        Assert.AreEqual(clientNameExpected, clientNameActual);
        Assert.AreEqual(cartCountExpected, cartCountActual);
        Assert.AreEqual(offerCountExpected, offerCountActual);
    }
}