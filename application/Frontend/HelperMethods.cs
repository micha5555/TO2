namespace Frontend;

using System;
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

    public LoggedInAs processLoginMenu()
    {
        MessagesPresenter.showLoginMessage();
        char optionChosen = getUserOptionInput();
        if (!optionChosen.Equals('1') && !optionChosen.Equals('2') && !optionChosen.Equals('3') && !optionChosen.Equals('0'))
        {
            MessagesPresenter.showErrorOptionMessage();
            MessagesPresenter.showAwaitingMessage();
            waitForUser();
            return processLoginMenu();
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
                MessagesPresenter.showAwaitingMessage();
                waitForUser();
            }
        }
        else
        {
            MessagesPresenter.showErrorOptionMessage();
            MessagesPresenter.showAwaitingMessage();
            waitForUser();
            return processLoginMenu();
        }

        return processLoginMenu();
    }

    private static char getUserOptionInput()
    {
        Console.Write("Wybrana opcja: ");
        return Console.ReadKey().KeyChar;
    }

    public void processLoggedClient()
    {
        //TODO
        //Show menu with available options

        //User choose option

        //Process choosen option


    }

    public void processLoggedAdministrator()
    {
        bool isLogged = true;
        while (isLogged)
        {
            Console.Clear();
            MessagesPresenter.showAdministratorMenuMessage();

            //User choose option
            char choosenOption = getUserOptionInput();

            //Process choosen option
            isLogged = processAdministratorMenuChoosenOption(choosenOption);
        }
    }

    private bool processAdministratorMenuChoosenOption(char option)
    {
        List<char> validOptions = new List<char> { '0', '1', '2', '3', '4', '5', '9' };

        if (!isOptionValid(validOptions, option))
        {
            MessagesPresenter.showErrorOptionMessage();
            MessagesPresenter.showAwaitingMessage();
            waitForUser();
            return true;
        }
        
        return false;
    }

    private bool isOptionValid(List<char> validOptions, char option)
    {
        return validOptions.Contains(option);
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
            MessagesPresenter.showErrorOptionMessage();
            MessagesPresenter.showAwaitingMessage();
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
            MessagesPresenter.showErrorInputMessage();
            MessagesPresenter.showAwaitingMessage();
            waitForUser();
            login = getLogin();
        }
        return login;
    }



    public void waitForUser()
    {
        Console.ReadKey();
        Console.Clear();
    }



}