using Xunit;
using Shared;
using Services;
using Benchmark;

namespace clrtests;

public class clrprofilerxUNIT2
{
    [Theory]
    [InlineData(100)]
    [InlineData(1000)]
    [InlineData(10000)]
    public void AddProductToOfferTest(int N)
    {
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

}