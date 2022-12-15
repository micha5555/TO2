using NUnit.Framework;
using Services;
using Shared;
using System;
using System.Collections.Generic;

namespace BDDTests.StepDefinitions;

[Binding]
public class ListingItemsStepDefinitions : BaseStepDefinitions
{
    
    private Product product;
    private Order order;


    [Given(@"Offer list is not empty")]
    public void GivenOfferListIsNotEmpty()
    {
        // Helper.ClearMethods.ClearOffer();
        Helper.BaseProducts.NarzedziaProduct = Helper.CommonMethods.CreateNewCorrectNarzedziaProduct();
        Helper.BaseServices.OfferOperations.AddToOffer(Helper.BaseProducts.NarzedziaProduct);
    }

    [When(@"Client lists offer")]
    public void WhenClientListsOffer()
    {
        Helper.BaseLists.OfferList = Helper.BaseServices.OfferOperations.GetAllProductList();
    }

    [Then(@"Offer list display is not empty")]
    public void ThenOfferListDisplayIsNotEmpty()
    {
        int expected = 1;
        int actual = Helper.BaseLists.OfferList.Count;
        
        Assert.AreEqual(expected, actual);
    }

    [Given(@"Offer list is empty")]
    public void GivenOfferListIsEmpty()
    {
        Helper.ClearMethods.ClearOffer();
    }

    [Then(@"Offer list display is empty")]
    public void ThenOfferListDisplayIsEmpty()
    {
        int expected = 0;
        int actual = Helper.BaseLists.OfferList.Count;
        Assert.AreEqual(expected, actual);
    }

    [Given(@"Cart list is not empty")]
    public void GivenCartListIsNotEmpty()
    {
        Helper.BaseProducts.Product = Helper.CommonMethods.CreateNewCorrectProduct();
        Helper.BaseServices.OfferOperations.AddToOffer(Helper.BaseProducts.Product);
        Helper.BaseProducts.CartProduct = new CartProduct(Helper.BaseProducts.Product, 1);
        Helper.BaseServices.CartOperations.AddToCart(Helper.BaseProducts.CartProduct);
    }

    [When(@"Client lists cart items")]
    public void WhenClientListsCartItems()
    {
        Helper.BaseLists.CartList = Helper.BaseServices.CartOperations.GetProducts();
    }

    [Then(@"Cart list display is not empty")]
    public void ThenCartListDisplayIsNotEmpty()
    {
        Assert.AreEqual(1, Helper.BaseLists.CartList.Count);
    }

    [Given(@"Cart list is empty")]
    public void GivenCartListIsEmpty()
    {
        // Helper.ClearMethods.ClearCart(); 
        Helper.BaseLists.CartList = Helper.BaseServices.CartOperations.GetProducts();
    }

    [Then(@"Cart list display is empty")]
    public void ThenCartListDisplayIsEmpty()
    {
        Assert.AreEqual(0, Helper.BaseLists.CartList.Count);
    }

    [Given(@"Order list is not empty")]
    public void GivenOrderListIsNotEmpty()
    {
        product = Helper.CommonMethods.CreateNewCorrectProduct();
        Helper.BaseProducts.CartProduct = new CartProduct(product, 1);
        Helper.BaseServices.CartOperations.AddToCart(Helper.BaseProducts.CartProduct);
        Helper.BaseClient.Client.Cart = new Cart(new List<CartProduct> { Helper.BaseProducts.CartProduct });
        order = new Order(Helper.BaseClient.Client);
    }

    [When(@"Client lists orders")]
    public void WhenClientListsOrders()
    {
        Helper.BaseLists.OrderList = order.GetProducts();
    }

    [Then(@"Order list display is not empty")]
    public void ThenOrderListDisplayIsNotEmpty()
    {
        Assert.AreEqual(1, Helper.BaseLists.OrderList.Count);
    }

    [Given(@"Order list is empty")] // DO ZMIANY - Lista przedmitow w zamowieniu nie moze byc pusta
    public void GivenOrderListIsEmpty()
    {
        // Helper.ClearMethods.ClearCart();

        order = new Order(Helper.BaseClient.Client);
        Helper.BaseLists.OrderList = order.GetProducts();
    }

    [Then(@"Order list display is empty")] // Analogicznie jak poprzednie
    public void ThenOrderListDisplayIsEmpty()
    {
        Assert.AreEqual(0, Helper.BaseLists.OrderList.Count);
    }
}

