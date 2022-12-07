namespace Frontend;

public static class MessagesPresenter{
    public static void showWelcomeMessage()
    {
        Console.WriteLine(Messages.getWelcomeMessage());
    }
    public static void showArtPic()
    {
        Console.WriteLine(Messages.getArtPicMessage());
    }

    public static void showAwaitingMessage()
    {
        Console.WriteLine(Messages.getAwaitingMessage());
    }

    public static void showLoginMessage()
    {
        Console.WriteLine(Messages.getLoginMessage());
    }
    public static void showErrorOptionMessage()
    {
        Console.WriteLine("\n" + Messages.getErrorOptionMessage() + "\n");
    }

    public static void showGoodbyeMessage()
    {
        Console.WriteLine(Messages.getGoodbyeMessage());
    }

    public static void showErrorInputMessage()
    {
        Console.WriteLine(Messages.getErrorInputMessage());
    }

    public static void showAdministratorMenuMessage()
    {
        Console.WriteLine(Messages.getAdministratorMenuMessage());
    }

}