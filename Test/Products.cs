using Shared;
using Repo;
public class Products
{
    
    [Test]
    public void createProducts()
    {
        IRepository repo = Repository.Instance;
        repo.ReadDataOnLaunch();
        repo.AddProductToOffer(new Product("Szlifierka", 300, Category.Narzędzia, "Szlifierka o wadze 2kg"));
        repo.AddProductToOffer(new Product("Młotek", 35, Category.Narzędzia, "Waga główki 0.4kg"));
        repo.AddProductToOffer(new Product("Wiertarka", 260, Category.Narzędzia, "Obrotów na minutę: 700"));
        repo.AddProductToOffer(new Product("Obcęgi", 15, Category.Narzędzia, "Waga całkowita: 150g"));
        repo.AddProductToOffer(new Product("Kombinerki", 18, Category.Narzędzia, "Materiał: guma, stal"));
        repo.AddProductToOffer(new Product("Śrubokręt", 13, Category.Narzędzia, "Typ: Płaski"));
        repo.AddProductToOffer(new Product("Piła mechaniczna", 444, Category.Narzędzia, "Długość prowadnicy: 0.8m"));
        repo.AddProductToOffer(new Product("Sprężarka", 550, Category.Narzędzia, "Kolor: żółty"));
        repo.AddProductToOffer(new Product("Spawarka", 499, Category.Narzędzia, "Waga: 40kg"));
        repo.AddProductToOffer(new Product("Pilarka", 300, Category.Narzędzia, "Producent: Tregeret"));
        repo.AddProductToOffer(new Product("Pralka", 2300, Category.AGD, "Max ładowność: 5kg"));
        repo.AddProductToOffer(new Product("Kuchenka Mikrofalowa", 350, Category.AGD, "Tryb rozmrażania, Low, High"));
        repo.AddProductToOffer(new Product("Zmywarka", 2150, Category.AGD, "Ilość półek: 2"));
        repo.AddProductToOffer(new Product("Piekarnik", 1300, Category.AGD, "Max temperatura: 240 stopni Celsjusza"));
        repo.AddProductToOffer(new Product("Okap", 405, Category.AGD, "Głośność pracy: 35dB"));
        repo.AddProductToOffer(new Product("Płyta indukcyjna", 1340, Category.AGD, "Ilość palników: 4"));
        repo.AddProductToOffer(new Product("Płyta gazowa", 800, Category.AGD, "Zastosowanie: Kuchnia"));
        repo.AddProductToOffer(new Product("Lodówka", 2700, Category.AGD, "Minimalna temperatura: 1 stopień Celsjusza"));
        repo.AddProductToOffer(new Product("Klimatyzator", 2600, Category.AGD, "Wymiary: 80cmx50cmx40cm"));
        repo.AddProductToOffer(new Product("Odkurzacz", 470, Category.AGD, "Możliwość regulacji mocy"));
        repo.AddProductToOffer(new Product("Rezystor 20 ohm", 0.5, Category.Elektrotechnika, "Mały, twardy, kwaśny"));
        repo.AddProductToOffer(new Product("Oscyloskop", 800, Category.Elektrotechnika, "Nie lizać ekranu"));
        repo.AddProductToOffer(new Product("Tranzystor", 0.7, Category.Elektrotechnika, "Wyprowadzenia: 3"));
        repo.AddProductToOffer(new Product("Generator", 600, Category.Elektrotechnika, "Bardzo mocny, O S T R O Ż N I E"));
        repo.AddProductToOffer(new Product("Przewód miedziany 2m", 10, Category.Elektrotechnika, "Rodzaj przewodnika: miedź"));
        repo.AddProductToOffer(new Product("Dioda LED", 0.3, Category.Elektrotechnika, "Kolor: żółty"));
        repo.AddProductToOffer(new Product("Czujnik temperatury", 5, Category.Elektrotechnika, "Max temperatura: 150 stopni Celsjusza"));
        repo.AddProductToOffer(new Product("Przycisk", 2, Category.Elektrotechnika, "PRzycisk przycisk przycisk"));
        repo.AddProductToOffer(new Product("Czujnik odległości", 7, Category.Elektrotechnika, "Tolerancja +-10cm"));
        repo.AddProductToOffer(new Product("Fotorezystor", 1, Category.Elektrotechnika, "Działa super, polecam"));
        repo.AddProductToOffer(new Product("Kask", 80, Category.Ubiór, "Mocny, odporny na spadające cegły"));
        repo.AddProductToOffer(new Product("Spodnie ogrodniki", 90, Category.Ubiór, "Wyglądaj jak prawdziwy ogrodnik"));
        repo.AddProductToOffer(new Product("Koszula flanelowa", 40, Category.Ubiór, "Kolor: czarny"));
        repo.AddProductToOffer(new Product("Rękawice ogrodowe", 7, Category.Ubiór, "Odpowiednie na każde dłonie"));
        repo.AddProductToOffer(new Product("Rękawice spawalnicze", 25, Category.Ubiór, "Zapobiega oparzeniom"));
        repo.AddProductToOffer(new Product("Fartuch spawalniczy", 160, Category.Ubiór, "Długośc całkowita: 1.3m"));
        repo.AddProductToOffer(new Product("Przyłbica", 254, Category.Ubiór, "Automatyczne ściemnianie szybki pod wpływem intensywnego światła"));
        repo.AddProductToOffer(new Product("Okulary ochronne", 30, Category.Ubiór, "Ochroń swoje oczy teraz"));
        repo.AddProductToOffer(new Product("Kamizelka", 120, Category.Ubiór, "Ciepła, idealna na jesienne prace na zewnątrz"));
        repo.AddProductToOffer(new Product("Kurtka przeciwdeszczowa", 170, Category.Ubiór, "Żaden deszcz jej nie straszny!"));
        
        repo.SaveDataOnExit();
        foreach (Product product in repo.GetAllOfferProducts())
        {
            Console.WriteLine(product.Name + " " + product.Price);
        }

    }
}