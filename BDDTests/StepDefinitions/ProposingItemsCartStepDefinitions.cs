using System.Collections.Generic;
using NUnit.Framework;
using Shared;

namespace BDDTests.StepDefinitions;

[Binding]
public class ProposingItemsCartStepDefinitions  
{
    private List<Product> proposedProducts;
    
    [Given(@"Other clients orders exist")]
    public void GivenOtherClientsOrdersExist(){
        Helper.CommonMethods.CreateGivenNumberOfOrdersForGivenClient(new Client("Janusz", "Tracz", "Warszawa ul. Konopianki", "04-050", "Jantex", "Tralala"), 3);
        Helper.CommonMethods.CreateGivenNumberOfOrdersForGivenClient(new Client("Mariusz", "Pudzianowski", "Lubicz", "14-200", "BYczunio", "ByCzEk"), 2);
        Helper.CommonMethods.CreateGivenNumberOfOrdersForGivenClient(new Client("Tomasz", "Hajto", "Gelsenkirchen", "1212-1", "Pasiasty", "SzyBko"), 2,3);
    }

    [When(@"Client enters his cart")]
    public void WhenCliententershiscart()
    {
        proposedProducts = Helper.BaseServices.GeneralOperations.ProposeProductsBasedOnCart(Helper.BaseClient.Client.Cart, 2);
    }

    [Then(@"Client get list of proposed products")]
    public void ThenClientgetlistofproposedproducts()
    {
        Assert.AreEqual(2, proposedProducts.Count);
        Assert.Contains(Helper.CommonMethods.CreateNewCorrectAGDProduct(), proposedProducts);
        Assert.Contains(Helper.CommonMethods.CreateNewCorrectNarzedziaProduct(), proposedProducts);
    }

}
