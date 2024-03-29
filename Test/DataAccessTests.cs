namespace Test;
using Shared;
using Repo.DataAccessClass;

public class DataAccessTests
{
    private DataAccess da;
    [SetUp]
    public void Setup()
    {
        da = DataAccess.Instance;
        List<Product> productList = new List<Product>{
            new Product("p1", 1, Category.AGD, "desc jakis"),
            new Product("p2", 2, Category.AGD, "desc jakis"),
            new Product("p3", 4, Category.AGD, "desc jakis"),
            new Product("p4", 5, Category.AGD, "desc jakis"),
            new Product("p5", 6, Category.AGD, "desc jakis"),
            new Product("p6", 7, Category.AGD, "desc jmmmm")
        };
        da.CartList.Add(new Cart(productList));
        da.CartList.Add(new Cart(productList));
        da.OfferList.Add(new Offer(productList));
        List<CartProduct> cartProdList = new List<CartProduct>();
        foreach (Product p in productList)
        {
            cartProdList.Add(new CartProduct(p, 1));
        }
        da.OrderList.Add(new Order(cartProdList));
        for (int i = 0; i <= 9; i++)
        {
            da.ClientList.Add(new Client("Michalek" + i, "Marciski" + i, "PrzyBazantarnii" + i, "07-990" + i, "login", "password"));
            da.AdminList.Add(new Administrator("login", "password"));
        }
    }

    // [Test]
    // public void ShouldDeserialize()
    // {
    //     da.SerializeAll();
    //     da.AdminList = new List<Administrator>();
    //     da.CartList = new List<Cart>();
    //     da.ClientList = new List<Client>();
    //     da.OfferList = new List<Offer>();
    //     da.OrderList = new List<Order>();

    //     da.DeserializeAll();
    //     //check admin
    //     string adminNameActual = da.AdminList[0].Name;
    //     string adminNameExpected = "Marcin0";
    //     //check client
    //     string clientNameActual = da.ClientList[0].Name;
    //     string clientNameExpected = "Michalek0";
    //     //check offer
    //     int offerCountActual = da.OfferList[0].GetProductList().Count;
    //     int offerCountExpected = 6;
    //     //check cart
    //     int cartCountActual = da.CartList[0].GetCartProducts().Count;
    //     int cartCountExpected = 6;
    //     //check order
    //     int orderCountActual = da.OrderList[0].GetProducts().Count;
    //     int orderCountExpected = 6;

    //     Assert.AreEqual(adminNameExpected, adminNameActual);
    //     Assert.AreEqual(clientNameExpected, clientNameActual);
    //     Assert.AreEqual(cartCountExpected, cartCountActual);
    //     Assert.AreEqual(offerCountExpected, offerCountActual);
    //     Assert.AreEqual(orderCountExpected, orderCountActual);
    // }
}