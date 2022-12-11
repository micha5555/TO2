using Shared;

namespace Frontend;

public static class ProductMethods
{
    //Need to get Name, Price, CategoryClass, And Description

    // Prepratations for Category enum
    public static List<string> getCategoryEnumsList()
    {
        return Enum.GetNames(typeof(Category)).ToList();
    }

    public static (string, string, string, Category) getProductParametersFromProduct(Product product)
    {
        return (product.Name, product.Price.ToString(), product.Description, product.CategoryClass);
    }

    public static (string, string, string, Category) getProductParametersFromUser()
    {
        string? name;
        string? price;
        string? description;
        Category category;
        Console.Write("Podaj nazwę produktu: ");
        name = Console.ReadLine();
        Console.Write("Podaj cenę produktu: ");
        price = Console.ReadLine();
        Console.Write("Podaj opis produktu: ");
        description = Console.ReadLine();

        List<string> namesOfCategories = getCategoryEnumsList();

        string? categoryName = CommonMethods.choseOptionFromPagedList<string>(namesOfCategories, Messages.getProductCategorySelectHeader());
        
        if (categoryName is not null)
            category = Enum.Parse<Category>(categoryName);
        else
            throw new NullReferenceException();

        if (name is null || price is null || description is null)
            throw new NullReferenceException();

        return (name, price, description, category);
    }

    public static bool validateProductParameters((string? name, string? price, string? descrition, Category category) parameters)
    {
        if (parameters.name is null || parameters.name.Equals(""))
        {
            return false;
        }
        if (parameters.price is null || parameters.price.Equals("") || !CommonMethods.canConvert(parameters.price, typeof(double)))
        {
            return false;
        }
        if (parameters.descrition is null || parameters.descrition.Equals(""))
        {
            return false;
        }

        return true;
    }

    public static string getNameForFilteringProducts()
    {
        while (true)
        {
            MessagesPresenter.showNameForFilteringProductsHeader();
            String? answer = getNameProduct();
            if (answer is not null && validateProductName(answer))
            {
                return answer;
            }
        }
    }

    public static double getNewPriceFromUser()
    {
        while (true)
        {
            MessagesPresenter.showNewPriceHeader();

            string? value = askForNewPrice();

            if (value is not null && CommonMethods.canConvert(value, typeof(double)))
                return Double.Parse(value);

            MessagesPresenter.showErrorInputMessage();
            MessagesPresenter.showAwaitingMessage();
            CommonMethods.waitForUser();
        }
    }

    private static string? askForNewPrice()
    {
        Console.Write("Podaj nową cenę: ");
        return Console.ReadLine();
    }

    private static bool validateProductName(string? answer)
    {
        if (answer is null)
        {
            return false;
        }
        return true;
    }

    private static string? getNameProduct()
    {
        Console.Write("\nPodaj nazwę produktu: ");
        return Console.ReadLine();
    }
}