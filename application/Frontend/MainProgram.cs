namespace Frontend;

public class MainProgram
{
    private HelperMethods helperMethods;

    public MainProgram(HelperMethods helperMethods)
    {
        this.helperMethods = helperMethods;
    }

    public MainProgram()
    {
        this.helperMethods = new HelperMethods(this);
    }

    public void handleWelcomeScreen()
    {
        helperMethods.showWelcomeMessage();
        helperMethods.showArtPic();
        helperMethods.showAwaitingMessage();
        helperMethods.waitForUser();
    }

    public LoggedInAs handleLoginScreen()
    {
        helperMethods.showLoginMessage();
        return helperMethods.login();
    }



}
