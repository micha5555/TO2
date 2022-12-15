using System.Collections.Generic;
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

    public static Offer CreateNewCorrectOffer(){
        List<Product> products = new List<Product>();
        products.Add(new Product("Szlifierka", 300, Category.Narzędzia, "Szlifierka o wadze 2kg"));
        products.Add(new Product("Zmywarka", 2150, Category.AGD, "Ilość półek: 2"));
        products.Add(new Product("Lodówka", 2700, Category.AGD, "Minimalna temperatura: 1 stopień Celsjusza"));
        products.Add(new Product("Oscyloskop", 800, Category.Elektrotechnika, "Nie lizać ekranu"));
        products.Add(new Product("Generator", 600, Category.Elektrotechnika, "Bardzo mocny, O S T R O Ż N I E"));
        return new Offer(products);
    }
}