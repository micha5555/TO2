namespace Test;
using Shared;
using Services;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        CartProduct p1 = new CartProduct(new Product("p1", 1, Category.AGD, "desc jakis"), 1);
        CartProduct p2 = new CartProduct(new Product("p2", 2, Category.AGD, "desc jakis"), 1);
        CartProduct p3 = new CartProduct(new Product("p3", 4, Category.AGD, "desc jakis"), 1);
        CartProduct p4 = new CartProduct(new Product("p4", 5, Category.AGD, "desc jakis"), 1);
        CartProduct p5 = new CartProduct(new Product("p5", 6, Category.AGD, "desc jakis"), 1);
        CartProduct p6 = new CartProduct(new Product("p6", 7, Category.AGD, "desc jmmmm"), 1);
        CartProduct p7 = new CartProduct(new Product("p7", 8, Category.AGD, "desc jmmmm"), 1);
        CartProduct p8 = new CartProduct(new Product("p8", 1, Category.AGD, "desc jakis"), 1);
        CartProduct p9 = new CartProduct(new Product("p9", 2, Category.AGD, "desc jakis"), 1);
        CartProduct p10 = new CartProduct(new Product("p10", 4, Category.AGD, "desc jakis"), 1);
        CartProduct p11 = new CartProduct(new Product("p11", 5, Category.AGD, "desc jakis"), 1);
        CartProduct p12 = new CartProduct(new Product("p12", 6, Category.AGD, "desc jakis"), 1);
        CartProduct p13 = new CartProduct(new Product("p13", 7, Category.AGD, "desc jmmmm"), 1);
        CartProduct p14 = new CartProduct(new Product("p14", 8, Category.AGD, "desc jmmmm"), 1);

        Cart cart = new Cart();
        cart.AddToCart(p1);
        cart.AddToCart(p2);
        cart.AddToCart(p3);

        List<Order> orders = new List<Order>();
        orders.Add(new Order(new List<CartProduct> { p1, p2, p3, p4, p5}));
        orders.Add(new Order(new List<CartProduct> { p1, p2, p7, p4, p8}));
        orders.Add(new Order(new List<CartProduct> { p9, p10, p11, p12, p13}));
        orders.Add(new Order(new List<CartProduct> { p1, p9, p10, p11, p12}));
        
        IGeneralOperations ge = new Operations();
        //powinno zaproponować p4, p5
        List<Product> prop1 = ge.ProposeProductsBasedOnCart(cart, 2);
        //powinno zaproponować p4, p5, p7, p8
        List<Product> prop2 = ge.ProposeProductsBasedOnCart(cart, 4);
        //powinno zaproponować p4, p5, p7, p8, p9, p10, p11, p12
        List<Product> prop3 = ge.ProposeProductsBasedOnCart(cart, 8);

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
    
    [Test]
    public void Test2()
    {
        CartProduct p1 = new CartProduct(new Product("p1", 1, Category.AGD, "desc jakis"), 1);
        CartProduct p2 = new CartProduct(new Product("p2", 2, Category.AGD, "desc jakis"), 1);
        CartProduct p3 = new CartProduct(new Product("p3", 4, Category.AGD, "desc jakis"), 1);
        CartProduct p4 = new CartProduct(new Product("p4", 5, Category.AGD, "desc jakis"), 1);
        CartProduct p5 = new CartProduct(new Product("p5", 6, Category.AGD, "desc jakis"), 1);
        CartProduct p6 = new CartProduct(new Product("p6", 7, Category.AGD, "desc jmmmm"), 1);
        CartProduct p7 = new CartProduct(new Product("p7", 8, Category.AGD, "desc jmmmm"), 1);
        CartProduct p8 = new CartProduct(new Product("p8", 1, Category.AGD, "desc jakis"), 1);
        CartProduct p9 = new CartProduct(new Product("p9", 2, Category.AGD, "desc jakis"), 1);
        CartProduct p10 = new CartProduct(new Product("p10", 4, Category.AGD, "desc jakis"), 1);
        CartProduct p11 = new CartProduct(new Product("p11", 5, Category.AGD, "desc jakis"), 1);
        CartProduct p12 = new CartProduct(new Product("p12", 6, Category.AGD, "desc jakis"), 1);
        CartProduct p13 = new CartProduct(new Product("p13", 7, Category.AGD, "desc jmmmm"), 1);
        CartProduct p14 = new CartProduct(new Product("p14", 8, Category.AGD, "desc jmmmm"), 1);

        List<Order> orders = new List<Order>();
        orders.Add(new Order(new List<CartProduct> {p1, p2,     p4, p5,     p7,     p9,      p11, p12,      p14}));
        orders.Add(new Order(new List<CartProduct> {p1, p2, p3, p4, p5,     p7, p8, p9, p10, p11,      p13, p14}));
        orders.Add(new Order(new List<CartProduct> {p1,     p3,     p5, p6,     p8, p9, p10, p11, p12, p13, p14}));
        orders.Add(new Order(new List<CartProduct> {    p2,     p4,     p6,     p8, p9, p10,      p12, p13,    }));
        
        IGeneralOperations ge = new Operations();
        //powinno zaproponować p5 p9 p11 p14
        List<Product> prop1 = ge.ProposeProductsBasedOnProduct(new Product("p1", 1, Category.AGD, "desc jakis"), 4);
        //powinno zaproponować p4 p9
        List<Product> prop2 = ge.ProposeProductsBasedOnProduct(new Product("p2", 2, Category.AGD, "desc jakis"),  2);
        //powinno zaproponować p1 p5 p8 p9 p10 p11 p13 p14 p2 p4
        List<Product> prop3 = ge.ProposeProductsBasedOnProduct(new Product("p3", 4, Category.AGD, "desc jakis"), 10);

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