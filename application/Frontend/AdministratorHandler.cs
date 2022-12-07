namespace Frontend;

using Services;
public class AdministratorHandler{
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

    private UserStatus processAdministratorMenuChoosenOption(char option)
    {
        List<char> validOptions = new List<char> { '0', '1', '2', '3', '4', '5', '9' };

        if (!CommonMethods.isOptionValid(validOptions, option))
        {
            MessagesPresenter.showErrorOptionMessage();
            MessagesPresenter.showAwaitingMessage();
            CommonMethods.waitForUser();
            return UserStatus.Administrator;
        }

        if (option == '0')
        {
            MessagesPresenter.showGoodbyeMessage();
            MessagesPresenter.showArtPic();
            MessagesPresenter.showAwaitingMessage();
            CommonMethods.waitForUser();
            Environment.Exit(0);
        }
        if (option == '9')
        {
            // Show logout message 
            return UserStatus.NotLoggedIn;
        }
        if (option == '1')
        {
            //TODO Register new administrator
        }
        else if (option == '2')
        {
            //TODO Add new product
        }
        else if (option == '3')
        {
            //TODO Show all products
        }
        else if (option == '4')
        {
            //TODO Show all products with name that contains given fraze
        }
        else if (option == '5')
        {
            //TODO Set shop payment details
        }

        return UserStatus.Administrator;
    }

    public bool checkAdministratorLogin(string login, string password)
    {
        return _administratorOperations.checkAdministratorCredentials(login, password);
    }
}