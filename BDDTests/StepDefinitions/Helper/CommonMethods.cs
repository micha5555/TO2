using Shared;

namespace BDDTests.StepDefinitions.Helper;

public static class CommonMethods
{
    public static Product CreateNewCorrectProduct(){
        return new Product(
            "Pralka",
            120.0,
            Category.AGD,
            "Bardzo fajna pralka"
        );
    }

    public static Product CreateNewCorrectNarzedziaProduct(){
        return new Product(
            "Wiertarka",
            250.0,
            Category.Narzędzia,
            "Skuteczna, szybka i elegancka wiertarka"
        );
    }

    public static CartProduct CreateNewCorrectCartProduct(){
        return new CartProduct(
            CreateNewCorrectProduct(),
            1
        );
    }
    public static CartProduct CreateNewCorrectCartProduct(int quantity){
        return new CartProduct(
            CreateNewCorrectProduct(),
            quantity
        );
    }
}