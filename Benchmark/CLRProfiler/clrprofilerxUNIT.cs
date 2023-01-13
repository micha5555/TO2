using Xunit;
using Shared;
using Services;
using Benchmark;

namespace clrtests;

public class clrprofilerxUNIT
{
    [Theory]
    [InlineData(100)]
    [InlineData(1000)]
    [InlineData(10000)]
    public void AddProductsToCartTest(int N)
    {
        List<CartProduct> cproducts;
        List<Client> clients;
        IGeneralOperations _generalOperations;
        ICartOperations _cartOperations;
        IClientOperations _clientOperations;
        _clientOperations = new ClientOperations();
        clients = Common.GenerateClients(1);
        _cartOperations = new CartOperations(clients[0].Id);
        _generalOperations = new GeneralOperations();
        _generalOperations.ReadDataOnLaunch();

        cproducts = Common.GenerateCartProducts(N);
        for (int i = 0; i < N; i++)
        {
            foreach (CartProduct cp in cproducts)
            {
                _cartOperations.AddToCart(cp);
            }
        }
    }
}