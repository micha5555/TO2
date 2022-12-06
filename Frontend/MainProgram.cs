namespace Frontend;

public static class MainProgram
{
    public static void showWelcomeScreen()
    {
        HelperMethods.showWelcomeMessage();
        HelperMethods.showArtPic();
        HelperMethods.showAwaitingMessage();
        HelperMethods.waitForUser();
    }

    public static void showLoginScreen()
    {
        HelperMethods.showLoginMessage();
        HelperMethods.login();
    }

    
}
