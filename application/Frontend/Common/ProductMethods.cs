using Shared;

namespace Frontend;

public static class ProductMethods{
    //Need to get Name, Price, CategoryClass, And Description
    
    // Prepratations for Category enum
    public static List<string> getCategoryEnumsList(){
        return Enum.GetNames(typeof(Category)).ToList();
    }

    public static (string?, string?, string?, Category) getProductParametersFromUser(){
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

        string categoryName = CommonMethods.choseOptionFromPagedList<string>(namesOfCategories, Messages.getProductCategorySelectHeader());
        category = Enum.Parse<Category>(categoryName);

        return (name, price, description, category);
    }
     
     public static bool validateProductParameters((string? name, string? price, string? descrition, Category category) parameters)
    {
        if (parameters.name is null || parameters.name.Equals(""))
        {
            return false;
        }
        if (parameters.price is null || parameters.price.Equals("")|| CommonMethods.canConvert(parameters.price, typeof(double)))
        {
            return false;
        }
        if (parameters.descrition is null || parameters.descrition.Equals(""))
        {
            return false;
        }

        return true;
    }
}