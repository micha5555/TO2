using NUnit.Framework;
using Services;
using Shared;
using System;
using System.Collections.Generic;

namespace BDDTests.StepDefinitions;

[Binding]
public class ListingItemsStepDefinitions
{
    
    private Product product;
    private Order order;


    [Given(@"Offer is not empty")]
    public void GivenOfferIsNotEmpty()
    {
        // Helper.ClearMethods.ClearOffer();
        Helper.BaseProducts.NarzedziaProduct = Helper.CommonMethods.CreateNewCorrectNarzedziaProduct();
        Helper.BaseServices.OfferOperations.AddToOffer(Helper.BaseProducts.NarzedziaProduct);
    }


    [When(@"Client lists active products from offer")]
    public void WhenClientListsOffer()
    {
        Helper.BaseLists.OfferList = Helper.BaseServices.OfferOperations.GetAllProductList();
    }

    [Then(@"List of active products is not empty")]
    public void ThenOfferListDisplayIsNotEmpty()
    {
        int expected = 1;
        int actual = Helper.BaseLists.OfferList.Count;
        
        Assert.AreEqual(expected, actual);
    }

    [Given(@"Offer is empty")]
    public void GivenOfferIsEmpty()
    {
        Helper.ClearMethods.ClearOffer();
    }

    [Then(@"List of offer products is empty")]
    public void ThenOfferListDisplayIsEmpty()
    {
        int expected = 0;
        int actual = Helper.BaseLists.OfferList.Count;
        Assert.AreEqual(expected, actual);
    }

    [Given(@"Cart is not empty")]
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

    [Then(@"List of cart items is not empty")]
    public void ThenCartListDisplayIsNotEmpty()
    {
        Assert.AreEqual(1, Helper.BaseLists.CartList.Count);
    }

    [Given(@"Cart is empty")]
    public void GivenCartListIsEmpty()
    {
        // Helper.ClearMethods.ClearCart(); 
        Helper.BaseLists.CartList = Helper.BaseServices.CartOperations.GetProducts();
    }

    [Then(@"List of cart items is empty")]
    public void ThenCartListDisplayIsEmpty()
    {
        Assert.AreEqual(0, Helper.BaseLists.CartList.Count);
    }

    [Given(@"Order is not empty")]
    public void GivenOrderListIsNotEmpty()
    {
        product = Helper.CommonMethods.CreateNewCorrectProduct();
        Helper.BaseProducts.CartProduct = new CartProduct(product, 1);
        Helper.BaseServices.CartOperations.AddToCart(Helper.BaseProducts.CartProduct);
        Helper.BaseClient.Client.Cart = new Cart(new List<CartProduct> { Helper.BaseProducts.CartProduct });
        order = new Order(Helper.BaseClient.Client);
    }

    [When(@"Client lists order items")]
    public void WhenClientListsOrders()
    {
        Helper.BaseLists.OrderList = order.GetProducts();
    }

    [Then(@"List of ordered items is not empty")]
    public void ThenOrderListDisplayIsNotEmpty()
    {
        Assert.AreEqual(1, Helper.BaseLists.OrderList.Count);
    }

    [Given(@"Order is empty")] // DO ZMIANY - Lista przedmitow w zamowieniu nie moze byc pusta
    public void GivenOrderListIsEmpty()
    {
        // Helper.ClearMethods.ClearCart();

        order = new Order(Helper.BaseClient.Client);
        Helper.BaseLists.OrderList = order.GetProducts();
    }

    [Then(@"List of ordered items is empty")] // Analogicznie jak poprzednie
    public void ThenOrderListDisplayIsEmpty()
    {
        Assert.AreEqual(0, Helper.BaseLists.OrderList.Count);
    }

    [Given(@"Client orders are empty")]
    public void GivenClientOrdersAreEmpty()
    {
    }

    [Given(@"Client have (.*) orders")]
    public void GivenClientOrdersAreNotEmpty(int numberOfOrders)
    {   
        Helper.CommonMethods.CreateGivenNumberOfOrdersForGivenClient(Helper.BaseClient.Client, numberOfOrders);
    }

    [When(@"Client lists his orders")]
    public void WhenClientListsHisOrders()
    {
        Helper.BaseLists.Orders = Helper.BaseServices.ClientOperations.GetClientOrders(Helper.BaseClient.Client.Id); 
    }

    [Then(@"(.*) orders are in list of orders")]
    public void ThenListOfOrdersIsNotEmpty(int expectedNumberOfOrders)
    {
        Assert.AreEqual(expectedNumberOfOrders, Helper.BaseLists.Orders.Count);
    }

    [Then(@"List of orders is empty")]
    public void ThenListOfOrdersIsEmpty()
    {
        Assert.AreEqual(0, Helper.BaseLists.Orders.Count);
    }

}

