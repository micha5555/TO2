using Shared;

namespace BDDTests.StepDefinitions.Helper;

public static class CommonMethods
{
    public static Product CreateNewCorrectProduct()
    {
        return new Product(
            "Pralka",
            120.0,
            Category.AGD,
            "Bardzo fajna pralka"
        );
    }

    public static Product CreateNewCorrectNarzedziaProduct()
    {
        return new Product(
            "Wiertarka",
            250.0,
            Category.Narzędzia,
            "Skuteczna, szybka i elegancka wiertarka"
        );
    }

    public static Product CreateNewCorrectElektrotechnikaProduct()
    {
        return new Product(
            "Oscyloskop",
            500.0,
            Category.Elektrotechnika,
            "Dokładny i szybki oscyloskop"
        );
    }

    public static CartProduct CreateNewCorrectCartProduct()
    {
        return new CartProduct(
            CreateNewCorrectProduct(),
            1
        );
    }
    public static CartProduct CreateNewCorrectCartProduct(int quantity)
    {
        return new CartProduct(
            CreateNewCorrectProduct(),
            quantity
        );
    }

    public static void CreateGivenNumberOfOrdersForGivenClient(Client client, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            int mode = i % 3 ;
            if (mode == 0)
            {
                BaseServices.CartOperations.AddToCart(new CartProduct(CreateNewCorrectProduct(), i + 1));
            }
            else if (mode == 1)
            {
                BaseServices.CartOperations.AddToCart(new CartProduct(CreateNewCorrectNarzedziaProduct(), i + 1));

            }
            else if (mode == 2)
            {
                BaseServices.CartOperations.AddToCart(new CartProduct(CreateNewCorrectElektrotechnikaProduct(), i + 1));
            }
            BaseServices.OrderOperations.CreateOrder(client);
        }
    }
}