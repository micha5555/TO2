using System.ComponentModel;
namespace Frontend;

using System;
using Services;
using Shared;

public class AdministratorHandler
{
    private IAdministratorOperations _administratorOperations = new AdministratorOperations();
    private IOfferOperations _offerOperations = new OfferOperations();
    private IOrderOperations _orderOperations = new OrderOperations();

    public UserStatus processLoggedAdministrator()
    {
        UserStatus userStatus = UserStatus.Administrator;
        while (userStatus == UserStatus.Administrator)
        {
            MessagesPresenter.showAdministratorMenuMessage();

            //User choose option
            char choosenOption = CommonMethods.getUserOptionInput();

            //Process choosen option
            userStatus = processAdministratorMenuChoosenOption(choosenOption);
        }
        return userStatus;
    }

    private UserStatus processAdministratorMenuChoosenOption(char chosenOption)
    {
        if (!validateChosenOption(chosenOption))
            return UserStatus.Administrator;

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
            registerNewAdministrator();
        }
        else if (chosenOption == '2')
        {
            addNewProduct();
        }
        else if (chosenOption == '3')
        {
            getAllProducts();
        }
        else if (chosenOption == '4')
        {
            getAllProductsWithGivenName();
        }
        else if (chosenOption == '5')
        {
            checkClientsOrders();
        }

        return UserStatus.Administrator;
    }

    private void checkClientsOrders()
    {
        List<Order> list = _orderOperations.GetOrders();
        Order? chosenOrder = CommonMethods.choseOptionFromPagedList<Order>(list, Messages.getAllOrdersHeader());

        if (chosenOrder == null)
        {
            return;
        }
        orderManagingAdministrator(chosenOrder);
    }

    private void orderManagingAdministrator(Order order)
    {
        MessagesPresenter.showOrderAdministrator(order);
        char option = CommonMethods.getUserOptionInput();
        bool isValid = CommonMethods.isOptionValid(getValidOrderManageOptions(), option);

        while (!isValid)
        {
            MessagesPresenter.showOrderAdministrator(order);
            char chosenOption = CommonMethods.getUserOptionInput();

            isValid = CommonMethods.isOptionValid(getValidOrderManageOptions(), chosenOption);
            if (isValid)
                option = chosenOption;
        }

        if(option == 'q')
        {
            _orderOperations.UpdateOrder(order);
            return;
        }
        // if(option == '1')
        // {
        //     // SOME ACTIONS
        //     orderManagingAdministrator(order);
        //     return;
        // }
        if(option == '1')
        {
            CartProduct? cartProduct = CommonMethods.choseOptionFromPagedList(order.GetProducts(), "TESTTESTTEST\n");
            // CartProduct page handling

            orderManagingAdministrator(order);
            return;
        }
    }

    private void cartProductManagingAdministrator(CartProduct cartProduct){
        //Show message with cartProduct

        //show awaiting message
        //wait for response
    }

    private List<char> getValidOrderManageOptions()
    {
        return new List<char>(){'1','q'};
    }

    private void getAllProductsWithGivenName()
    {
        String name = ProductMethods.getNameForFilteringProducts();
        List<Product> list = _offerOperations.SearchForAllProductsByName(name);
        Product? chosenProduct = CommonMethods.choseOptionFromPagedList<Product>(list, Messages.getAllProductsMessage()); //TODO Create header message
        if (chosenProduct == null)
        {
            return;
        }
        productManagingAdministrator(chosenProduct);
    }

    private void getAllProducts()
    {
        // get list of all products
        List<Product> list = _offerOperations.GetAllProductList();
        Product? chosenProduct = CommonMethods.choseOptionFromPagedList<Product>(list, Messages.getAllProductsMessage()); //TODO Create header message
        if (chosenProduct == null)
        {
            return;
        }
        productManagingAdministrator(chosenProduct);
    }

    private void productManagingAdministrator(Product product)
    {
        MessagesPresenter.showProductParametersAdministratorManagingMessage(ProductMethods.getProductParametersFromProduct(product), product.isActive);
        char option = CommonMethods.getUserOptionInput();
        bool isValid = CommonMethods.isOptionValid(getValidProductManageOptions(), option);

        while (!isValid)
        {
            MessagesPresenter.showProductParametersAdministratorManagingMessage(ProductMethods.getProductParametersFromProduct(product), product.isActive);
            char chosenOption = CommonMethods.getUserOptionInput();

            isValid = CommonMethods.isOptionValid(getValidProductManageOptions(), chosenOption);
            if (isValid)
                option = chosenOption;
        }

        if (option == 'q')
        {
            _offerOperations.AddToOffer(product);
            return;
        }
        if (option == '1')
        {
            if (product.isActive)
            {
                _offerOperations.DeactivateProduct(product);
            }
            else
            {
                _offerOperations.ActivateProduct(product);
            }

            productManagingAdministrator(product);
            return;
        }
        if (option == '2')
        {
            product.Price = ProductMethods.getNewPriceFromUser();
            productManagingAdministrator(product);
            return;
        }


    }

    private List<char> getValidProductManageOptions()
    {
        return new List<char>() { '1', '2', 'q' };
    }

    private void addNewProduct()
    {
        bool isValid;
        (string name, string price, string descrition, Category category) parameters;

        MessagesPresenter.showAddNewProduct();
        parameters = ProductMethods.getProductParametersFromUser();
        isValid = ProductMethods.validateProductParameters(parameters);
        if (!isValid)
        {
            MessagesPresenter.showGivenProductParametersAreNotValid();
        }

        while (!isValid)
        {
            MessagesPresenter.showAddNewProduct();
            parameters = ProductMethods.getProductParametersFromUser();
            isValid = ProductMethods.validateProductParameters(parameters);
            if (!isValid)
            {
                MessagesPresenter.showGivenProductParametersAreNotValid();
            }
        }

        Confirmation confirmation = MessagesPresenter.showProductParametersSummary(parameters, true);


        if (confirmation == Confirmation.Rejected)
        {
            return;
        }

        if (confirmation == Confirmation.Confirmed)
        {
            bool added = _offerOperations.AddToOffer(parameters.name, Double.Parse(parameters.price, System.Globalization.NumberStyles.AllowDecimalPoint), parameters.category, parameters.descrition); //TODO replece true wiht service call

            if (added)
            {
                MessagesPresenter.showProductAddedCorrectly();
            }
            else
            {
                MessagesPresenter.showProductNotAdded();
            }
        }
    }

    private void registerNewAdministrator()
    {
        MessagesPresenter.showAdministratorRegistrationMessage();

        (string login, string password) = CommonMethods.getCredentials();
        RegistrationStatus status = _administratorOperations.registerNewAdministrator(login, password);

        if (status == RegistrationStatus.Registered)
        {
            MessagesPresenter.showAdministratorSuccesfulRegistrationMessage();
        }
        else if (status == RegistrationStatus.NotRegistered)
        {
            MessagesPresenter.showAdministratorUnsuccesfulRegistrationMessage();
        }

        MessagesPresenter.showAwaitingMessage();
        CommonMethods.waitForUser();
    }

    private bool validateChosenOption(char chosenOption)
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

    public bool checkAdministratorLogin(string login, string password)
    {
        return _administratorOperations.checkAdministratorCredentials(login, password);
    }
}