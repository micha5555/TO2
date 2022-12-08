namespace Frontend;

using System;
using System.ComponentModel;

public static class CommonMethods
{
    //TODO do przerobienia - nie podoba mi się
    public static UserStatus processLoginMenu(AdministratorHandler administratorHandler, ClientHandler clientHandler)
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

    public static char getValidUserOptionInput(List<char> validOptions){
        while(true){
            char option = getUserOptionInput();
            Console.WriteLine();
            if (isOptionValid(validOptions, option)){
                return option;
            }
        }

    }

    public static (string, string) getCredentials()
    {
        string login = getLogin();
        string password = getPassword();
        return (login, password);
    }

    private static string getPassword()
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

    private static string getLogin()
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

    public static List<List<T>> divideListIntoMulitipleLists<T>(List<T> list, int size) where T : class
    {
        var partitions = new List<List<T>>();
        for (int i = 0; i < list.Count; i += size)
        {
            partitions.Add(list.GetRange(i, Math.Min(size, list.Count - i)));
        }
        return partitions;
    }

    public static Boolean canConvert(String value, Type type)
    {
        if (type == typeof(double)){
            double temp;
            return Double.TryParse(value, System.Globalization.NumberStyles.AllowDecimalPoint, null, out temp);
        }
        TypeConverter converter = TypeDescriptor.GetConverter(type);
        return converter.IsValid(value);
    }


    public static T? choseOptionFromPagedList<T>(List<T> list, string headMessage) where T : class
    {
        if (list.Count == 0){
            Console.Clear();
            Console.WriteLine(headMessage);
            MessagesPresenter.showEmptyListMessage();
            return null;
        }


        int maxListQuantity = 9;
        List<List<T>> partitions = divideListIntoMulitipleLists<T>(list, maxListQuantity);

        T? chosen = null;

        foreach (List<T> partition in partitions)
        {
            bool isValid = false;
            char option = 'i';
            while (!isValid)
            {
                Console.Clear();
                Console.Write(headMessage);

                showPagedList<T>(list, maxListQuantity);

                option = getUserOptionInput();
                isValid = isOptionValid(validPagingOptions<T>(partition, maxListQuantity), option);
            }

            chosen = partition.ElementAt(option - '0' - 1);
        }

        if (chosen == null)
        {
            throw new Exception();
        }

        return chosen;
    }
    public static void showPagedList<T>(List<T> list,int maxListQuantity) where T : class
    {
        string message = "";
        for (int i = 0; i < list.Count; i++)
        {
            message += $"{i + 1}. {list.ElementAt(i)}\n";
        }
        if (list.Count == maxListQuantity)
        {
            message += "0. Następna strona\n";
        }
        message += "------------------------------------------------------------------\n";
        Console.WriteLine(message);
    }


    public static List<char> validPagingOptions<T>(List<T> list, int maxListQuantity) where T : class
    {
        List<char> validOptions = new List<char>();
        if (list.Count == maxListQuantity)
        {
            validOptions.Add('0');
        }
        int quantintyOfItemsInList = list.Count;
        for (int i = 1; i < quantintyOfItemsInList + 1; i++)
        {
            validOptions.Add((char)(i + '0'));
        }
        return validOptions;
    }

    public static List<char> validConfirmationOptions(){
        List<char> list = new List<char>{
            '1','2'
        };
        return list;
    }
}