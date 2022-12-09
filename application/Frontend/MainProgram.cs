using Services;

namespace Frontend;

public class MainProgram
{
    private AdministratorHandler _administratorHandler = new AdministratorHandler();
    private ClientHandler _clientHandler = new ClientHandler();
    private UserStatus _userStatus;
    private string? _login;
    private IGeneralOperations _generalOperations = new GeneralOperations();

    public void handleWelcomeScreen()
    {
        MessagesPresenter.showWelcomeMessage();
        MessagesPresenter.showArtPic();
        MessagesPresenter.showAwaitingMessage();
        CommonMethods.waitForUser();
        _userStatus = UserStatus.NotLoggedIn;
        _generalOperations.ReadDataOnLaunch();
    }

    public void handleLoginScreen()
    {
        (_userStatus, _login) = CommonMethods.processLoginMenu(_administratorHandler, _clientHandler);
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

                _generalOperations.SaveDataOnExit();

                //Exit Program
                Environment.Exit(0);
            }
            else if (_userStatus == UserStatus.Client)
            {
                _clientHandler.setLoggedClient(_login); 
                _userStatus = _clientHandler.processLoggedClient();
            }
            else if (_userStatus == UserStatus.Administrator)
            {
                _userStatus = _administratorHandler.processLoggedAdministrator();
            }
            else if (_userStatus == UserStatus.NotLoggedIn)
            {
                _login = null;
                handleLoginScreen();
            }
        }

    }


}
