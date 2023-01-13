using Shared;
using Services;
using Benchmark;

namespace TestCLR;

public class UnitTest1
{
    [Theory]
    [InlineData(100)]
    [InlineData(1000)]
    [InlineData(10000)]
    public void AddProductToOfferTest(int N)
    {
        Console.WriteLine("s");

        OfferOperations _offerOperations = new OfferOperations();
        GeneralOperations _generalOperations = new GeneralOperations();
        _generalOperations.ReadDataOnLaunch();

        List<Product> products = Common.GenerateProductsList(N);

        for (int i = 0; i < N; i++)
        {
            Console.WriteLine("s");
            _offerOperations.AddToOffer(products);
        }
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(4, 5, 9)]
    [InlineData(6, 7, 13)]
    public void TestMethod(int x, int y, int expected)
    {
        Console.WriteLine( x + " " + y + " " + expected);
    }
}