using BDDTests.StepDefinitions.Helper;
using Shared;
using Services;
using System.Collections.Generic;
using NUnit.Framework;
using System;

namespace BDDTests.StepDefinitions;

[Binding]
public class ProposingByProductStepDefinitions  
{
    private Product product;
    private OrderOperations orders;
    IGeneralOperations generalOperations;


    [Given(@"Previous orders exist")]
    public void WhenPreviousOrdersExist(){
        CommonMethods.CreateGivenNumberOfOrdersForGivenClient(new Client("Jan", "Kowalski", "Warszawa", "01-111", "jakow", "passw"), 4);
        orders = BaseServices.OrderOperations;
    }

    [When(@"Client choose product")]
    public void WhenCliententChooseProduct()
    {
        product = CommonMethods.CreateNewCorrectProduct();
    }

    [Then(@"Client get list of proposed products based on product")]
    public void ThenClientgetlistofProposedProductsBasedOnProduct()
    {
        generalOperations = new GeneralOperations();
        List<Product> proposed = generalOperations.ProposeProductsBasedOnProduct(CommonMethods.CreateNewCorrectAGDProduct(), 2);
        Assert.True(proposed.Count == 2);
        Assert.True(proposed.Contains(CommonMethods.CreateNewCorrectProduct()));
        Assert.True(proposed.Contains(CommonMethods.CreateNewCorrectNarzedziaProduct()));
    }

}