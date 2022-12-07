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
        _helperMethods.showWelcomeMessage();
        _helperMethods.showArtPic();
        _helperMethods.showAwaitingMessage();
        _helperMethods.waitForUser();
    }

    public void handleLoginScreen()
    {
        // _helperMethods.showLoginMessage();
        _loggedInAs =  _helperMethods.handleLoginMenu();
        Console.WriteLine($"Logged in as: {_loggedInAs}");
    }

    public void handleUser()
    {

    }


}
