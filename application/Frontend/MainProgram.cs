namespace Frontend;

public class MainProgram
{
    private HelperMethods _helperMethods;
    private LoggedInAs _loggedInAs;

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
    }

    public void handleLoginScreen()
    {
        _loggedInAs =  _helperMethods.processLoginMenu();
    }

    public void handleUser()
    {
        if(_loggedInAs == LoggedInAs.NotLoggedIn){
            //Show Goodbye message
            MessagesPresenter.showGoodbyeMessage();
            MessagesPresenter.showArtPic();
            MessagesPresenter.showAwaitingMessage();
            _helperMethods.waitForUser();

            //Exit Program
            Environment.Exit(0);
        }
        else if(_loggedInAs == LoggedInAs.Client){
            _helperMethods.processLoggedClient();
        }
        else if(_loggedInAs == LoggedInAs.Administrator){
            _helperMethods.processLoggedAdministrator(); 
        }
    }


}
