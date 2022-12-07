namespace Frontend;

using System;
using Services;
public class AdministratorHandler
{
    private IAdministratorOperations _administratorOperations = new AdministratorOperations();

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
            //TODO Add new product
            addNewProduct();
        }
        else if (chosenOption == '3')
        {
            //TODO Show all products
        }
        else if (chosenOption == '4')
        {
            //TODO Show all products with name that contains given fraze
        }
        else if (chosenOption == '5')
        {
            //TODO Set shop payment details
        }

        return UserStatus.Administrator;
    }

    private void addNewProduct()
    {
        // Show Adding New Product Message

        
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