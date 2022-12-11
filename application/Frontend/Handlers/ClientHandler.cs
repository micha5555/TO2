namespace Frontend;

using Shared;
using Services;
using System;

public class ClientHandler
{
    private IClientOperations _clientOperations = new ClientOperations();

    private IOfferOperations _offerOperations = new OfferOperations();
    private ICartOperations _cartOperations = null!;
    private IOrderOperations _orderOperations = new OrderOperations();
    private IGeneralOperations _generalOpearions = new GeneralOperations();

    public Client LoggedClient = null!;

    // public ClientHandler(string login){
    //     LoggedClient = _clientOperations.GetClientByLogin(login);
    // }
    public void setLoggedClient(string? login)
    {
        if (login is not null)
        {
            LoggedClient = _clientOperations.GetClientByLogin(login);
            _cartOperations = new CartOperations(LoggedClient.Id);
        }

    }


    public UserStatus processLoggedClient()
    {
        UserStatus userStatus = UserStatus.Client;
        while (userStatus == UserStatus.Client)
        {
            //TODO
            //Show menu with available options
            MessagesPresenter.showClientMenuMessage();

            //User choose option
            char chosenOption = CommonMethods.getUserOptionInput();

            //Process choosen option
            userStatus = processClientMenuChosenOption(chosenOption);
        }

        return userStatus;
    }

    private UserStatus processClientMenuChosenOption(char chosenOption)
    {
        if (!validateChosenOption(chosenOption))
            return UserStatus.Client;


        if (chosenOption == '0')
        {
            return UserStatus.Exiting;
        }
        if (chosenOption == '9')
        {
            return UserStatus.NotLoggedIn;
        }
        if (chosenOption == '1')
        {
            showAllProducts();
        }
        else if (chosenOption == '2')
        {
            showAllProductsWithGivenName();
        }
        else if (chosenOption == '3')
        {
            showClientCart();
        }
        else if (chosenOption == '4')
        {
            showAllClientOrders();
        }

        return UserStatus.Client;
    }

    private void showAllClientOrders()
    {
        Order? order = CommonMethods.choseOptionFromPagedList(_clientOperations.GetClientOrders(LoggedClient.Id), Messages.getClientOrders());
        if (order is not null)
        {
            orderManagingClient(order);
        }
    }

    private void orderManagingClient(Order order)
    {
        MessagesPresenter.showOrderAdministrator(order);
        MessagesPresenter.showAwaitingMessage();
        CommonMethods.waitForUser();
        CartProduct? cartProduct = CommonMethods.choseOptionFromPagedList(order.GetProducts(), Messages.getOrderProductsHeader());
        MessagesPresenter.showAwaitingMessage();
        CommonMethods.waitForUser();
    }

    private void showClientCart()
    {
        //Show Client Cart Message with header 1. value, and show options, check cart check proposed items
        MessagesPresenter.showCartClientMessage(LoggedClient.Cart);
        char chosenOption = CommonMethods.getUserOptionInput();
        bool isValid = CommonMethods.isOptionValid(cartValidOptions(), chosenOption);

        while (!isValid)
        {
            MessagesPresenter.showCartClientMessage(LoggedClient.Cart);
            chosenOption = CommonMethods.getUserOptionInput();
            isValid = CommonMethods.isOptionValid(cartValidOptions(), chosenOption);
        }

        if (chosenOption == 'q')
        {
            return;
        }
        if (chosenOption == '1')
        {
            CartProduct? cartProduct = CommonMethods.choseOptionFromPagedList(LoggedClient.Cart.GetCartProducts(), Messages.getCartHeader());

            showClientCart();
            return;
        }
        if (chosenOption == '2')
        {
            Order order = new Order(LoggedClient);
            _clientOperations.AddClientOrder(order);
            LoggedClient.Cart.ClearCart();

            showClientCart();
            return;
        }
        if (chosenOption == '3')
        {
            List<Product> list = _generalOpearions.ProposeProductsBasedOnCart(LoggedClient.Cart, 3);

            Product? product = CommonMethods.choseOptionFromPagedList(list, Messages.getProposedItemsHeader());
            if (product is not null)
            {
                productManagingClient(product);
            }

            showClientCart();
            return;
        }
    }

    private List<char> cartValidOptions()
    {
        return new List<char>() { '1', '2', '3', 'q' };
    }

    private void showAllProductsWithGivenName()
    {
        String name = ProductMethods.getNameForFilteringProducts();
        List<Product> list = _offerOperations.SearchForActiveProductsByName(name);
        Product? chosenProduct = CommonMethods.choseOptionFromPagedList(list, Messages.getAllProductsMessage());
        //Product chosenProduct = (Product)Convert.ChangeType(chosen, typeof(Product));
        if (chosenProduct == null) return;
        //handleProductPage(chosenProduct, client);
        productManagingClient(chosenProduct);
    }

    public bool validateChosenOption(char chosenOption)
    {
        List<char> validOptions = new List<char> { '0', '1', '2', '3', '4', '9' };

        if (!CommonMethods.isOptionValid(validOptions, chosenOption))
        {
            MessagesPresenter.showErrorOptionMessage();
            MessagesPresenter.showAwaitingMessage();
            CommonMethods.waitForUser();
            return false;
        }
        return true;
    }

    public bool checkClientLogin(string login, string password)
    {
        bool logged = _clientOperations.checkClientCredentials(login, password);
        if (logged)
        {
            LoggedClient = _clientOperations.GetClientByLogin(login);
        }
        return logged;
    }

    public void createClient(string login, string password)
    {
        _clientOperations.registerNewClient("", "", "", "", login, password);
    }

    private void showAllProducts()
    {
        List<Product> list = _offerOperations.GetActiveProductList();
        Product? chosenProduct = CommonMethods.choseOptionFromPagedList(list, Messages.getAllProductsMessage());
        //Product chosenProduct = (Product)Convert.ChangeType(chosen, typeof(Product));
        if (chosenProduct == null) return;
        //handleProductPage(chosenProduct, client);
        productManagingClient(chosenProduct);
    }

    private void productManagingClient(Product product) //TODO -> paskudna zagnieżdżona konstrukcja
    {
        //TODO: użyć metody z ProductMethod getProductParametersFromProduct
        MessagesPresenter.showProductForClient((product.Name, product.Price.ToString(), product.Description, product.CategoryClass), product.isActive);

        bool exit = false;
        while (!exit)
        {
            MessagesPresenter.showProductForClient((product.Name, product.Price.ToString(), product.Description, product.CategoryClass), product.isActive);
            char chosen = CommonMethods.getUserOptionInput();
            if (chosen == '1')
            {
                bool exitQuantity = false;
                //ask abount quantity
                while (!exitQuantity)
                {
                    MessagesPresenter.showAskQuantity();
                    string? quantity = Console.ReadLine();
                    int parsed;
                    if (quantity is not null)
                    {
                        try
                        {
                            parsed = int.Parse(quantity);
                            LoggedClient.Cart.AddToCart(new CartProduct(product, parsed));
                            exitQuantity = true;
                        }
                        catch { }
                    }

                }

            }
            else if (chosen == 'q')
            {
                exit = true;
            }
        }

    }

}