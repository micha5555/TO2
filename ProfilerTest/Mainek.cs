using Shared;
using Services;
using Benchmark;

namespace mainek;

public class Mainek
{
    public static void AddProductToOfferTest(int N)
    {
        OfferOperations _offerOperations = new OfferOperations();
        GeneralOperations _generalOperations = new GeneralOperations();
        _generalOperations.ReadDataOnLaunch();
        List<Product> products = Common.GenerateProductsList(N);

        for (int i = 0; i < N; i++)
        {
            _offerOperations.AddToOffer(products);
        }
        Repo.Repository.DeInstantiate;
    }

    public static void AddProductsToCartTest(int N)
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
        Repo.Repository.DeInstantiate;

    }

    public static void ProposeItemsByCart()
    {
        int clientsQuantity = 500;
        int productsQuantity = 500;
        int proposeProductsQuantity = 30;
        List<Product> _products = new List<Product>();
        List<Client> _clients = new List<Client>();
        IGeneralOperations _generalOperations = new GeneralOperations();
        IOfferOperations _offerOperations = new OfferOperations();


        _offerOperations = new OfferOperations();
        _generalOperations = new GeneralOperations();
        _generalOperations.ReadDataOnLaunch();
        _clients = Common.GenerateClients(clientsQuantity);
        _products = Common.GenerateProductsList(productsQuantity);
        Common.FillClientsCarts(_clients, _products);
        Common.GenerateOrders(_clients);
        Common.FillClientsCarts(_clients, _products);


        foreach (var client in _clients)
        {
            _generalOperations.ProposeProductsBasedOnCart(client.Cart, proposeProductsQuantity);
        }
        Repo.Repository.DeInstantiate;

    }

    public static void ProposeItemsByProduct()
    {
        int clientsQuantity = 500;
        int productsQuantity = 500;
        int proposeProductsQuantity = 30;
        List<Product> _products = new List<Product>();
        List<Client> _clients = new List<Client>();
        IGeneralOperations _generalOperations = new GeneralOperations();
        IOfferOperations _offerOperations = new OfferOperations();


        _offerOperations = new OfferOperations();
        _generalOperations = new GeneralOperations();
        _generalOperations.ReadDataOnLaunch();
        _clients = Common.GenerateClients(clientsQuantity);
        _products = Common.GenerateProductsList(productsQuantity);
        Common.FillClientsCarts(_clients, _products);
        Common.GenerateOrders(_clients);
        Common.FillClientsCarts(_clients, _products);


        foreach (var product in _products)
        {
            _generalOperations.ProposeProductsBasedOnProduct(product, proposeProductsQuantity);
        }
        Repo.Repository.DeInstantiate;

    }
}