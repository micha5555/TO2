using Services;
using Shared;

namespace BDDTests.StepDefinitions;

public class BaseStepDefinitions
{

    [Given(@"Client is logged in")]
    public void GivenClientIsLoggedIn()
    {
        //TODO Metoda do czyszczenia wszelkich zserializowanych danych do json'a - do przemyslenie bo chyba jednak niepotrzebna

        Helper.BaseServices.GeneralOperations = new GeneralOperations();
        Helper.BaseServices.GeneralOperations.ReadDataOnLaunch();


        Helper.BaseServices.OrderOperations = new OrderOperations();
        Helper.BaseServices.OfferOperations = new OfferOperations();

        Offer offer = new Offer();
        Helper.BaseServices.OfferOperations.AddOfferToOfferList(offer);

        Helper.BaseServices.ClientOperations = new ClientOperations();
        Helper.BaseServices.ClientOperations.registerNewClient("Maciej", "Maciejowski", "Bazantarnia", "04-550", "login", "password");

        Helper.BaseClient.Client = Helper.BaseServices.ClientOperations.GetClientByLogin("login");
        Helper.BaseServices.CartOperations = new CartOperations(Helper.BaseClient.Client.Id);
        // _clientIsLoggedIn = _clientOperations.checkClientCredentials("login", "password");
    }
}