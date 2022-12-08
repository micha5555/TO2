using Shared;

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

    public static void showAddNewProduct()
    {
        Console.Clear();
        Console.WriteLine(Messages.getAddingNewProductHeader());
    }

    public static void showGivenProductParametersAreNotValid()
    {
        Console.WriteLine("\n" + Messages.getProductParametersAreNotValid());
        Console.WriteLine(Messages.getAwaitingMessage());
        CommonMethods.waitForUser();
    }

    public static Confirmation showProductParametersSummary((string? name, string? price, string? descrition, Category category) parameters)
    {
        Console.Clear();
        Console.WriteLine(Messages.getProductSummaryMessage(parameters));
        Confirmation answer = showConfirmationMessage();
        Console.WriteLine(Messages.getAwaitingMessage());
        CommonMethods.waitForUser();
        return answer;
    }

    public static Confirmation showConfirmationMessage()
    {
        Console.WriteLine(Messages.getConfirmationMessage());
        if (CommonMethods.getValidUserOptionInput(CommonMethods.validConfirmationOptions()) == '1')
        {
            return Confirmation.Confirmed;
        }
        return Confirmation.Rejected;
    }

    public static void showProductNotAdded(){
        Console.Clear();
        Console.WriteLine(Messages.getNewProductNotAdded());
        Console.WriteLine(Messages.getAwaitingMessage());
        CommonMethods.waitForUser();
    }

    public static void showProductAddedCorrectly(){
        Console.Clear();
        Console.WriteLine(Messages.getNewProductAddedCorrectly());
        Console.WriteLine(Messages.getAwaitingMessage());
        CommonMethods.waitForUser();
    }
}