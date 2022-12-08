using Shared;

namespace Frontend;

public static class Messages
{
    public static string getErrorOptionMessage()
    {
        string message = "";
        message += "Podana opcja jest nieprawidłowa!";
        return message;
    }

    public static string getAwaitingMessage()
    {
        string awaitingMessage = "";
        awaitingMessage += "Wciśnij dowolny klawisz, aby kontynuować...";
        return awaitingMessage;
    }

    public static string getWelcomeMessage()
    {
        string welcomeMessage = "";
        welcomeMessage += "-----------------------------------------------------\n";
        welcomeMessage += "\tWitaj w sklepie techincznym PikaPika!\n";
        welcomeMessage += "-----------------------------------------------------\n";
        return welcomeMessage;
    }

    public static string getLoginMessage()
    {
        string loginMessage = "";
        loginMessage += "----------------------------\n";
        loginMessage += "Co chcesz zrobić?\n";
        loginMessage += "----------------------------\n";
        loginMessage += "1. Logowanie Klienta\n";
        loginMessage += "2. Logowanie Administratora\n";
        loginMessage += "3. Rejestracja Klienta\n";
        loginMessage += "0. Wyjście ze sklepu\n";
        return loginMessage;
    }

    public static string getGoodbyeMessage()
    {
        string message = "";
        message += "------------------------------------------------------------------\n";
        message += "          Dziękujemy za skorzystanie ze sklepu PikaPika!          \n";
        message += "\n";
        message += "                       Zapraszamy ponownie!                       \n";
        message += "------------------------------------------------------------------\n";
        return message;
    }

    public static string getErrorInputMessage()
    {
        string errorMessage = "";
        errorMessage += "Wprowadzone dane są nieprawidłowe!\n";
        return errorMessage;
    }

    public static string getArtPicMessage()
    {
        string artpic = "            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡾⠋⠉⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⠃⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n            ⠀⠀⠀⠀⠀⠀⠀⠀⢀⡏⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n            ⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣠⣤⣤⣤⣤⠀⠀\n            ⠀⠀⠀⠀⠀⠀⠀⠀⡏⠀⠀⠀⠀⢸⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡤⠴⠒⠊⠉⠉⠀⠀⣿⣿⣿⠿⠋⠀⠀\n            ⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⢀⡠⠼⠴⠒⠒⠒⠒⠦⠤⠤⣄⣀⠀⢀⣠⠴⠚⠉⠀⠀⠀⠀⠀⠀⠀⠀⣼⠿⠋⠁⠀⠀⠀⠀\n            ⠀⠀⠀⠀⠀⠀⠀⠀⣇⠔⠂⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢨⠿⠋⠀⠀⠀⠀⠀⠀⠀⠀⣀⡤⠖⠋⠁⠀⠀⠀⠀⠀⠀⠀\n            ⠀⠀⠀⠀⠀⠀⠀⢰⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣠⠤⠒⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n            ⠀⠀⠀⠀⠀⠀⢀⡟⠀⣠⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⢻⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣤⣤⡤⠤⢴\n            ⠀⠀⠀⠀⠀⠀⣸⠁⣾⣿⣀⣽⡆⠀⠀⠀⠀⠀⠀⠀⢠⣾⠉⢿⣦⠀⠀⠀⢸⡀⠀⠀⢀⣠⠤⠔⠒⠋⠉⠉⠀⠀⠀⠀⢀⡞\n            ⠀⠀⠀⠀⠀⢀⡏⠀⠹⠿⠿⠟⠁⠀⠰⠦⠀⠀⠀⠀⠸⣿⣿⣿⡿⠀⠀⠀⢘⡧⠖⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡼⠀\n            ⠀⠀⠀⠀⠀⣼⠦⣄⠀⠀⢠⣀⣀⣴⠟⠶⣄⡀⠀⠀⡀⠀⠉⠁⠀⠀⠀⠀⢸⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⠁⠀\n            ⠀⠀⠀⠀⢰⡇⠀⠈⡇⠀⠀⠸⡾⠁⠀⠀⠀⠉⠉⡏⠀⠀⠀⣠⠖⠉⠓⢤⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⠃⠀⠀\n            ⠀⠀⠀⠀⠀⢧⣀⡼⠃⠀⠀⠀⢧⠀⠀⠀⠀⠀⢸⠃⠀⠀⠀⣧⠀⠀⠀⣸⢹⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡰⠃⠀⠀⠀\n            ⠀⠀⠀⠀⠀⠈⢧⡀⠀⠀⠀⠀⠘⣆⠀⠀⠀⢠⠏⠀⠀⠀⠀⠈⠳⠤⠖⠃⡟⠀⠀⠀⢾⠛⠛⠛⠛⠛⠛⠛⠛⠁⠀⠀⠀⠀\n            ⠀⠀⠀⠀⠀⠀⠀⠙⣆⠀⠀⠀⠀⠈⠦⣀⡴⠋⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⠙⢦⠀⠀⠘⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n            ⠀⠀⠀⠀⠀⠀⠀⢠⡇⠙⠦⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⠴⠋⠸⡇⠈⢳⡀⠀⢹⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n            ⠀⠀⠀⠀⠀⠀⠀⡼⣀⠀⠀⠈⠙⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠀⠀⠀⠀⣷⠴⠚⠁⠀⣀⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n            ⠀⠀⠀⠀⠀⠀⡴⠁⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣆⡴⠚⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n            ⣼⢷⡆⠀⣠⡴⠧⣄⣇⠀⠀⠀⠀⠀⠀⠀⢲⠀⡟⠀⠀⠀⠀⠀⠀⠀⢀⡇⣠⣽⢦⣄⢀⣴⣶⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n            ⡿⣼⣽⡞⠁⠀⠀⠀⢹⡀⠀⠀⠀⠀⠀⠀⠈⣷⠃⠀⠀⠀⠀⠀⠀⠀⣼⠉⠁⠀⠀⢠⢟⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n            ⣷⠉⠁⢳⠀⠀⠀⠀⠈⣧⠀⠀⠀⠀⠀⠀⠀⣻⠀⠀⠀⠀⠀⠀⠀⣰⠃⠀⠀⠀⠀⠏⠀⠀⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n            ⠹⡆⠀⠈⡇⠀⠀⠀⠀⠘⣆⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⣰⠃⠀⠀⠀⠀⠀⠀⠀⣸⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n            ⠀⢳⡀⠀⠙⠀⠀⠀⠀⠀⠘⣆⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⣰⠃⠀⠀⠀⠀⢀⡄⠀⢠⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n            ⠀⠀⢳⡀⣰⣀⣀⣀⠀⠀⠀⠘⣦⣀⠀⠀⠀⡇⠀⠀⠀⢀⡴⠃⠀⠀⠀⠀⠀⢸⡇⢠⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n            ⠀⠀⠀⠉⠉⠀⠀⠈⠉⠉⠉⠙⠻⠿⠾⠾⠻⠓⢦⠦⡶⡶⠿⠛⠛⠓⠒⠒⠚⠛⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n";
        return artpic;
    }

    public static string getAdministratorMenuMessage()
    {
        string message = "";
        message += "------------------------------------------------------------------\n";
        message += "                        Menu Administratora                       \n";
        message += "------------------------------------------------------------------\n";
        message += "1. Rejestracja Nowego Administratora\n";
        message += "2. Dodanie produktu do oferty\n";
        message += "3. Przeglądanie produktów w ofercie\n";
        message += "4. Wyszukiwanie produktów po nazwie\n";
        message += "5. Przeglądanie zamówień klientów\n";
        message += "9. Wylogowanie\n";
        message += "0. Wyjście z programu\n";
        message += "------------------------------------------------------------------\n";
        return message;
    }

    public static string getClientMenuMessage()
    {
        string message = "";
        message += "------------------------------------------------------------------\n";
        message += "                           Menu Klienta                           \n";
        message += "------------------------------------------------------------------\n";
        message += "1. Przeglądanie produktów w ofercie\n";
        message += "2. Wyszukiwanie produktów po nazwie\n";
        message += "3. Wyświetlenie koszyka\n";
        message += "4. Ustawienie danych wysyłki\n";
        message += "5. Przeglądanie zamówień\n";
        message += "9. Wylogowanie\n";
        message += "0. Wyjście z programu\n";
        message += "------------------------------------------------------------------\n";
        return message;
    }

    public static string getAdministratorRegistrationMessage()
    {
        string message = "";
        message += "------------------------------------------------------------------\n";
        message += "                    Rejestracja Administratora                    \n";
        message += "------------------------------------------------------------------\n";
        return message;
    }

    public static string getAdministratorSuccesfulRegistrationMessage()
    {
        string message = "";
        message += "------------------------------------------------------------------\n";
        message += "                 Rejestracja przebiegła pomyślnie                 \n";
        message += "------------------------------------------------------------------\n";
        return message;
    }

    public static string getAdministratorUnsuccesfulRegistrationMessage()
    {
        string message = "";
        message += "------------------------------------------------------------------\n";
        message += "               Rejestracja nie przebiegła pomyślnie               \n";
        message += "------------------------------------------------------------------\n";
        return message;
    }

    public static string getProductCategorySelectHeader()
    {
        string message = "";
        message += "------------------------------------------------------------------\n";
        message += "                    Wybierz kategorię produktu                    \n";
        message += "------------------------------------------------------------------\n";
        return message;
    }

    public static string getAddingNewProductHeader()
    {
        string message = "";
        message += "------------------------------------------------------------------\n";
        message += "                     Dodawanie nowego produktu                    \n";
        message += "------------------------------------------------------------------\n";
        return message;
    }

    public static string getProductParametersAreNotValid()
    {
        string message = "";
        message += "------------------------------------------------------------------\n";
        message += "                 Podane parametry są nieprawidłowe                \n";
        message += "------------------------------------------------------------------\n";
        return message;
    }

    public static string getProductSummaryMessage((string? name, string? price, string? descrition, Category category) parameters)
    {
        string message = "";
        message += "------------------------------------------------------------------\n";
        message += "                        Parametry Produktu                        \n";
        message += "------------------------------------------------------------------\n";
        message += $"    Nazwa: {parameters.name}\n";
        message += $"    Cena: {parameters.price}\n";
        message += $"    Opis: {parameters.descrition}\n";
        message += $"    Kategoria: {parameters.category}\n";
        message += "------------------------------------------------------------------\n";
        return message;
    }

    public static string getConfirmationMessage()
    {
        string message = "";
        message += "------------------------------------------------------------------\n";
        message += "              Czy napewno chcesz kontynuować akcję?               \n";
        message += "------------------------------------------------------------------\n";
        message += "    1. Tak\n";
        message += "    2. Nie\n";
        message += "------------------------------------------------------------------\n";
        return message;
    }

    public static string getNewProductAddedCorrectly()
    {
        string message = "";
        message += "------------------------------------------------------------------\n";
        message += "                 Produkt został dodany prawidłowo                 \n";
        message += "------------------------------------------------------------------\n";
        return message;
    }

    public static string getNewProductNotAdded()
    {
        string message = "";
        message += "------------------------------------------------------------------\n";
        message += "                     Produkt nie został dodany                    \n";
        message += "------------------------------------------------------------------\n";
        return message;
    }

    public static string getAllProductsMessage()
    {
        string message = "";
        message += "------------------------------------------------------------------\n";
        message += "                    Lista wszystkich produktów                    \n";
        message += "------------------------------------------------------------------\n";
        return message;
    }

    public static string getListIsEmptyMessage(){
        string message = "";
        message += "\nLista jest pusta!\n";
        return message;
    }

    public static string getNameForFilteringProductsHeader()
    {
        string message = "";
        message += "------------------------------------------------------------------\n";
        message += "                      Wyszukiwanie po nazwie                      \n";
        message += "------------------------------------------------------------------\n";
        return message;
    }

}