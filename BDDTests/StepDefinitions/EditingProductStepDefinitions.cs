using System;
using NUnit.Framework;
using Shared;
using TechTalk.SpecFlow;
	
namespace BDDTests.StepDefinitions;

[Binding]
public class ProductEditStepDefinitions
{
    private Product product;
    private double newProductPrice = 123.32;
    private double oldProductPrice;
 

    [Given(@"Product exists")]
    public void GivenProductexists()
    {
        Helper.BaseProducts.NarzedziaProduct = Helper.CommonMethods.CreateNewCorrectNarzedziaProduct();
        oldProductPrice = Helper.BaseProducts.NarzedziaProduct.Price;
    }

    [When(@"Admin edit product activity")]
    public void WhenAdmineditproductactivity()
    {
        Helper.BaseProducts.NarzedziaProduct.Deactivate();
    }

    [Then(@"Product activity is changed")]
    public void ThenProductactivityischanged()
    {
        bool expected = false;
        bool actual = Helper.BaseProducts.NarzedziaProduct.isActive;

        Assert.AreEqual(expected, actual);
    }

    [When(@"Admin edit product price")]
    public void WhenAdmineditproductprice()
    {
       Helper.BaseProducts.NarzedziaProduct.changePrice(newProductPrice);
    }

    [Then(@"Product price is changed")]
    public void ThenProductpriceischanged()
    {
        double expected = newProductPrice;
        double actual = Helper.BaseProducts.NarzedziaProduct.Price;

        Assert.AreNotEqual(expected, oldProductPrice);
        Assert.AreEqual(expected, actual);

    }
	
}


