namespace Frontend;

public class MainProgram
{
    private HelperMethods _helperMethods;
    private UserStatus _userStatus;

    public MainProgram(HelperMethods helperMethods)
    {
        this._helperMethods = helperMethods;
    }

    public MainProgram()
    {
        this._helperMethods = new HelperMethods(this);
    }

    public void handleWelcomeScreen()
    {
        MessagesPresenter.showWelcomeMessage();
        MessagesPresenter.showArtPic();
        MessagesPresenter.showAwaitingMessage();
        _helperMethods.waitForUser();
        _userStatus = UserStatus.NotLoggedIn;
    }

    public void handleLoginScreen()
    {
        _userStatus = _helperMethods.processLoginMenu();
    }

    public void handleUser()
    {
        while (true)
        {
            if (_userStatus == UserStatus.Exiting)
            {
                //Show Goodbye message
                MessagesPresenter.showGoodbyeMessage();
                MessagesPresenter.showArtPic();
                MessagesPresenter.showAwaitingMessage();
                _helperMethods.waitForUser();

                //Exit Program
                Environment.Exit(0);
            }
            else if (_userStatus == UserStatus.Client)
            {
                _userStatus = _helperMethods.processLoggedClient();
            }
            else if (_userStatus == UserStatus.Administrator)
            {
                _userStatus = _helperMethods.processLoggedAdministrator();
            }
            else if (_userStatus == UserStatus.NotLoggedIn)
            {
                handleLoginScreen();
            }
        }

    }


}
