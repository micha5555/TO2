namespace Test;
using Shared;
using Repo.DataAccessClass;

public class RepoTests
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
    }

    [Test]
    public void ShouldGetOrders_FromClientId()
    {
        
    }
}