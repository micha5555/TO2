namespace Frontend;

using Shared;
using Services;
public class ClientHandler
{
    private IClientOperations _clientOperations = new ClientOperations();

    private IOfferOperations _offerOperations = new OfferOperations();

    public Client LoggedClient = null;
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
            // Show logout message 
            return UserStatus.NotLoggedIn;
        }
        if (chosenOption == '1')
        {
            //Show products in offer
            showAllProducts();
        }
        else if (chosenOption == '2')
        {
            //TODO Show products by name
        }
        else if (chosenOption == '3')
        {
            //TODO Show cart
        }
        else if (chosenOption == '4')
        {
            //TODO Set Delivery address
        }
        else if (chosenOption == '5')
        {
            //TODO Show all client orders
        }

        return UserStatus.Client;
    }

    public bool validateChosenOption(char chosenOption)
    {
        List<char> validOptions = new List<char> { '0', '1', '2', '3', '4', '5', '9' };

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
        if(logged)
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
        List<Product> list = _offerOperations.GetAllProductList();
        Product? chosenProduct = CommonMethods.choseOptionFromPagedList(list, Messages.getAllProductsMessage());
        //Product chosenProduct = (Product)Convert.ChangeType(chosen, typeof(Product));
        if (chosenProduct == null) return;
        //handleProductPage(chosenProduct, client);
        productManagingClient(chosenProduct);
    }

    private void productManagingClient(Product product)
    {
        //TODO: użyć metody z ProductMethod getProductParametersFromProduct
        MessagesPresenter.showProductForClient((product.Name, product.Price.ToString(), product.Description, product.CategoryClass));
        
        bool exit = false;
        while (!exit)
        {
            MessagesPresenter.showProductForClient((product.Name, product.Price.ToString(), product.Description, product.CategoryClass));
            char chosen = CommonMethods.getUserOptionInput();
            if (chosen == '1')
            {
                bool exitQuantity = false;
                //ask abount quantity
                while(!exitQuantity)
                {
                    MessagesPresenter.showAskQuantity();
                    string quantity = Console.ReadLine();
                    try
                    {
                        int parsed = int.Parse(quantity);
                        LoggedClient.Cart.AddToCart(new CartProduct(product, parsed));
                        exitQuantity = true;
                    }
                    catch{}
                }
                
            }
            else if (chosen == 'q')
            {
                exit = true;
            }
        }
        
    }

}