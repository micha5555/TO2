namespace Frontend;

using Services;
public class ClientHandler
{
    private IClientOperations _clientOperations = new ClientOperations();

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
            MessagesPresenter.showGoodbyeMessage();
            MessagesPresenter.showArtPic();
            MessagesPresenter.showAwaitingMessage();
            CommonMethods.waitForUser();
            Environment.Exit(0);
        }
        if (chosenOption == '9')
        {
            // Show logout message 
            return UserStatus.NotLoggedIn;
        }
        if (chosenOption == '1')
        {
            //TODO Show products in offer
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
        return _clientOperations.checkClientCredentials(login, password);
    }

    public void createClient(string login, string password)
    {
        _clientOperations.registerNewClient(login, password);
    }

}