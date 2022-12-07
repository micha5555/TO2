namespace Frontend;

using Services;

public class HelperMethods
{
    private IAdministratorOperations _administratorOperations = new AdministratorOperations();
    private IClientOperations _clientOperations = new ClientOperations();
    private MainProgram _mainProgram;

    public HelperMethods(MainProgram mainProgram)
    {
        _mainProgram = mainProgram;
    }

    public LoggedInAs handleLoginMenu()
    {
        showLoginMessage();
        Console.Write("Wybrana opcja: ");
        char optionChosen = Console.ReadKey().KeyChar;
        if (!optionChosen.Equals('1') && !optionChosen.Equals('2') && !optionChosen.Equals('3') && !optionChosen.Equals('0'))
        {
            showErrorOptionMessage();
            showAwaitingMessage();
            waitForUser();
            return handleLoginMenu();
        }

        Console.Clear();

        if (optionChosen == '0')
        {
            return LoggedInAs.NotLoggedIn;
        }
        if (optionChosen == '1' || optionChosen == '2' || optionChosen == '3')
        {
            (string login, string password) credentials = getCredentials();
            if (optionChosen == '1' && checkClientLogin(credentials.login, credentials.password))
            {
                return LoggedInAs.Client;
            }
            else if (optionChosen == '2' && checkAdministratorLogin(credentials.login, credentials.password))
            {
                return LoggedInAs.Administrator;
            }
            else if (optionChosen == '3')
            {
                createClient(credentials.login, credentials.password);
                Console.WriteLine("Rejestracja przebiegła pomyślnie!");
                showAwaitingMessage();
                waitForUser();
            }
        }
        else
        {
            showErrorOptionMessage();
            showAwaitingMessage();
            waitForUser();
            return handleLoginMenu();
        }

        return handleLoginMenu();
    }

    public void handleLoggedClient()
    {
        //TODO
    }

    private void createClient(string login, string password)
    {
        _clientOperations.registerNewClient(login, password);
    }

    private bool checkAdministratorLogin(string login, string password)
    {
        return _administratorOperations.checkAdministratorCredentials(login, password);
    }

    private bool checkClientLogin(string login, string password)
    {
        return _clientOperations.checkClientCredentials(login, password);
    }

    public (string, string) getCredentials()
    {
        string login = getLogin();
        string password = getPassword();
        return (login, password);
    }

    private string getPassword()
    {
        Console.Write("Podaj hasło: ");
        string? password = Console.ReadLine();
        if (password == null)
        {
            showErrorOptionMessage();
            showAwaitingMessage();
            waitForUser();
            password = getPassword();
        }
        return password;
    }

    private string getLogin()
    {
        Console.Write("Podaj login: ");
        string? login = Console.ReadLine();
        if (login == null)
        {
            showErrorInputMessage();
            showAwaitingMessage();
            waitForUser();
            login = getLogin();
        }
        return login;
    }

    public void showGoodbyeMessage()
    {
        Console.WriteLine(Messages.getGoodbyeMessage());
    }


    private void showErrorInputMessage()
    {
        Console.WriteLine(Messages.getErrorInputMessage());
    }

    public void waitForUser()
    {
        Console.ReadKey();
        Console.Clear();
    }

    public void showWelcomeMessage()
    {
        Console.WriteLine(Messages.getWelcomeMessage());
    }
    public void showArtPic()
    {
        Console.WriteLine(Messages.getArtPicMessage());
    }

    public void showAwaitingMessage()
    {
        Console.WriteLine(Messages.getAwaitingMessage());
    }

    public void showLoginMessage()
    {
        Console.WriteLine(Messages.getLoginMessage());
    }
    public void showErrorOptionMessage()
    {
        Console.WriteLine("\n" + Messages.getErrorOptionMessage() + "\n");
    }

    
}