using System;
using BDDTests.StepDefinitions.Helper;
using NUnit.Framework;
using Shared;
using TechTalk.SpecFlow;
	
namespace BDDTests.StepDefinitions;

[Binding]
public class EditingOfferStepDefinitions
{
    private int baseOfferSize;
    private Product addedProduct;
 
    [Given(@"Primary offer exists")]
    public void PrimaryOfferExists()
    {
        Helper.BaseOffer.Offer = Helper.CommonMethods.CreateNewCorrectOffer();
        baseOfferSize = Helper.BaseOffer.Offer.ProductList.Count;
    }

    [When(@"Admin adds product to offer")]
    public void WhenAdminAddsProductToOffer()
    {
        addedProduct = CommonMethods.CreateNewCorrectProduct();
        Helper.BaseOffer.Offer.AddToOffer(addedProduct);
    }

    [Then(@"Offer contains this product")]
    public void ThenOfferContainsThisProduct()
    {
        Assert.True(Helper.BaseOffer.Offer.ProductList.Count == (baseOfferSize+1));
        Assert.True(Helper.BaseOffer.Offer.ProductList.Contains(addedProduct));
    }

}


