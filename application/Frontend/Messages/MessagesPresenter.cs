namespace Frontend;

public static class MessagesPresenter
{
    public static void showWelcomeMessage()
    {
        Console.Clear();
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
        Console.Clear();
        Console.WriteLine(Messages.getLoginMessage());
    }
    public static void showErrorOptionMessage()
    {
        Console.WriteLine("\n" + Messages.getErrorOptionMessage() + "\n");
    }

    public static void showGoodbyeMessage()
    {
        Console.Clear();
        Console.WriteLine(Messages.getGoodbyeMessage());
    }

    public static void showErrorInputMessage()
    {
        Console.WriteLine(Messages.getErrorInputMessage());
    }

    public static void showAdministratorMenuMessage()
    {
        Console.Clear();
        Console.WriteLine(Messages.getAdministratorMenuMessage());
    }

    public static void showClientMenuMessage()
    {
        Console.Clear();
        Console.WriteLine(Messages.getClientMenuMessage());
    }

    public static void showAdministratorRegistrationMessage()
    {
        Console.Clear();
        Console.WriteLine(Messages.getAdministratorRegistrationMessage());
    }

    public static void showAdministratorSuccesfulRegistrationMessage()
    {
        Console.WriteLine("\n" + Messages.getAdministratorSuccesfulRegistrationMessage());
    }

    public static void showAdministratorUnsuccesfulRegistrationMessage()
    {
        Console.WriteLine("\n" + Messages.getAdministratorUnsuccesfulRegistrationMessage());
    }
}