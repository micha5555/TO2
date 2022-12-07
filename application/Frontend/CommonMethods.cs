namespace Frontend;

using System;


public class CommonMethods
{
    //TODO do przerobienia - nie podoba mi się
    public UserStatus processLoginMenu(AdministratorHandler administratorHandler, ClientHandler clientHandler)
    {
        MessagesPresenter.showLoginMessage();
        char optionChosen = getUserOptionInput();
        if (!optionChosen.Equals('1') && !optionChosen.Equals('2') && !optionChosen.Equals('3') && !optionChosen.Equals('0'))
        {
            MessagesPresenter.showErrorOptionMessage();
            MessagesPresenter.showAwaitingMessage();
            waitForUser();
            return processLoginMenu(administratorHandler, clientHandler);
        }

        Console.Clear();

        if (optionChosen == '0')
        {
            return UserStatus.Exiting;
        }
        if (optionChosen == '1' || optionChosen == '2' || optionChosen == '3')
        {
            (string login, string password) credentials = getCredentials();
            if (optionChosen == '1' && clientHandler.checkClientLogin(credentials.login, credentials.password))
            {
                return UserStatus.Client;
            }
            else if (optionChosen == '2' && administratorHandler.checkAdministratorLogin(credentials.login, credentials.password))
            {
                return UserStatus.Administrator;
            }
            else if (optionChosen == '3')
            {
                clientHandler.createClient(credentials.login, credentials.password);
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
            return processLoginMenu(administratorHandler, clientHandler);
        }

        return processLoginMenu(administratorHandler, clientHandler);
    }

    public static char getUserOptionInput()
    {
        Console.Write("Wybrana opcja: ");
        return Console.ReadKey().KeyChar;
    }

    public static bool isOptionValid(List<char> validOptions, char option)
    {
        return validOptions.Contains(option);
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

    public static void waitForUser()
    {
        Console.ReadKey();
        Console.Clear();
    }
}