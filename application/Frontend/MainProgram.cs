namespace Frontend;

public class MainProgram
{
    private AdministratorHandler _administratorHandler = new AdministratorHandler();
    private ClientHandler _clientHandler = new ClientHandler();
    private CommonMethods _commonMethods = new CommonMethods();
    private UserStatus _userStatus;

    public void handleWelcomeScreen()
    {
        MessagesPresenter.showWelcomeMessage();
        MessagesPresenter.showArtPic();
        MessagesPresenter.showAwaitingMessage();
        CommonMethods.waitForUser();
        _userStatus = UserStatus.NotLoggedIn;
    }

    public void handleLoginScreen()
    {
        _userStatus = _commonMethods.processLoginMenu(_administratorHandler, _clientHandler);
    }

    public void handleUser()
    {
        while (true)
        {
            if (_userStatus == UserStatus.Exiting)
            {
                //Show Goodbye message - TODO Group up to one cast
                MessagesPresenter.showGoodbyeMessage();
                MessagesPresenter.showArtPic();
                MessagesPresenter.showAwaitingMessage();
                CommonMethods.waitForUser();

                //Exit Program
                Environment.Exit(0);
            }
            else if (_userStatus == UserStatus.Client)
            {
                _userStatus = _clientHandler.processLoggedClient();
            }
            else if (_userStatus == UserStatus.Administrator)
            {
                _userStatus = _administratorHandler.processLoggedAdministrator();
            }
            else if (_userStatus == UserStatus.NotLoggedIn)
            {
                handleLoginScreen();
            }
        }

    }


}
