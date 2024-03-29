namespace Test;
using Shared;
using Repo;

public class RepoTests
{
    private Repository repo;
    private List<Client> listaJanuszy;
    private List<Order> orderyJanuszy;
    [SetUp]
    public void Setup()
    {
        repo = Repository.Instance;
        List<Product> productList = new List<Product>{
            new Product("p1", 1, Category.AGD, "desc jakis"),
            new Product("p2", 2, Category.Narzędzia, "desc jakis"),
            new Product("p3", 4, Category.Elektrotechnika, "desc jakis"),
            new Product("p4", 5, Category.AGD, "desc jakis"),
            new Product("p5", 6, Category.Narzędzia, "desc jakis"),
            new Product("p6", 7, Category.Elektrotechnika, "desc jmmmm")
        };
        List<Product> productList2 = new List<Product>{
            new Product("p1", 1, Category.AGD, "desc jakis"),
            new Product("p2", 2, Category.Narzędzia, "desc jakis")
        };
        listaJanuszy = new List<Client>{ new Client("Marcin", "Marcinoski", "Niepowiem", "13-37", "login", "password"),
                                         new Client("BratMarcina", "RowniezMarcinoski", "TezNiepowiem", "21-37", "login", "password")};
        listaJanuszy[0].Cart = new Cart(productList);
        listaJanuszy[1].Cart = new Cart(productList2);
        orderyJanuszy = new List<Order>{ new Order(listaJanuszy[0]),
                                         new Order(listaJanuszy[1])};
    }

    [Test]
    public void ShouldGetOrders_FromClientId()
    {
        //arrange
        repo.AddClientOrder(orderyJanuszy[0]);
        repo.AddClientOrder(orderyJanuszy[1]);

        //act
        var order = repo.GetClientOrders(listaJanuszy[0].Id);
        int actualOrderCount = order[0].OrderProductList.Count;
        int expectedOrderCount = 6;
        //assert
        Assert.AreEqual(expectedOrderCount, actualOrderCount);
    }
}