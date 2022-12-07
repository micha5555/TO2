namespace Test;
using Shared;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Product p1 = new Product("p1", 1, Category.CAT1, "desc jakis");
        Product p2 = new Product("p2", 2, Category.CAT2, "desc jakis");
        Product p3 = new Product("p3", 4, Category.CAT3, "desc jakis");
        Product p4 = new Product("p4", 5, Category.CAT1, "desc jakis");
        Product p5 = new Product("p5", 6, Category.CAT2, "desc jakis");
        Product p6 = new Product("p6", 7, Category.CAT3, "desc jmmmm");
        Product p7 = new Product("p7", 8, Category.CAT1, "desc jmmmm");
        Product p8 = new Product("p8", 1, Category.CAT2, "desc jakis");
        Product p9 = new Product("p9", 2, Category.CAT3, "desc jakis");
        Product p10 = new Product("p10", 4, Category.CAT1, "desc jakis");
        Product p11 = new Product("p11", 5, Category.CAT2, "desc jakis");
        Product p12 = new Product("p12", 6, Category.CAT3, "desc jakis");
        Product p13 = new Product("p13", 7, Category.CAT1, "desc jmmmm");
        Product p14 = new Product("p14", 8, Category.CAT2, "desc jmmmm");

        Cart cart = new Cart();
        cart.AddToCart(p1);
        cart.AddToCart(p2);
        cart.AddToCart(p3);

        List<Order> orders = new List<Order>();
        orders.Add(new Order(new List<Product> { p1, p2, p3, p4, p5}));
        orders.Add(new Order(new List<Product> { p1, p2, p7, p4, p8}));
        orders.Add(new Order(new List<Product> { p9, p10, p11, p12, p13}));
        orders.Add(new Order(new List<Product> { p1, p9, p10, p11, p12}));
        
        //powinno zaproponować p4, p5
        List<Product> prop1 = Operations.ProposeProductsBasedOnCart(cart, orders, 2);
        //powinno zaproponować p4, p5, p7, p8
        List<Product> prop2 = Operations.ProposeProductsBasedOnCart(cart, orders, 4);
        //powinno zaproponować p4, p5, p7, p8, p9, p10, p11, p12
        List<Product> prop3 = Operations.ProposeProductsBasedOnCart(cart, orders, 8);

        Console.WriteLine("Proposal 1");
        foreach (Product p in prop1)
        {
            Console.Write(p.Name + " ");
        }
        Console.WriteLine();

        Console.WriteLine("Proposal 2");
        foreach (Product p in prop2)
        {
            Console.Write(p.Name + " ");
        }
        Console.WriteLine();

        Console.WriteLine("Proposal 3");
        foreach (Product p in prop3)
        {
            Console.Write(p.Name + " ");
        }
        Console.WriteLine();
    }
}