using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shared;
using TechTalk.SpecFlow;

namespace BDDTests.StepDefinitions;

[Binding]
public class PlacingOrderStepDefinition
{
    List<Order> orderList;

    [Given(@"Client did not add product to cart")]
    public void GivenClientdidnotaddproducttocart()
    {
        Helper.ClearMethods.ClearCart();
    }



    [Given(@"Client added product to cart")]
    public void GivenClientaddedproducttocart()
    {
        Helper.ClearMethods.ClearCart();
        Helper.BaseProducts.CartProduct = Helper.CommonMethods.CreateNewCorrectCartProduct();
        Helper.BaseServices.CartOperations.AddToCart(Helper.BaseProducts.CartProduct);
    }

    [When(@"Client places an order")]
    public void WhenClientplacesanorder()
    {
        Helper.BaseServices.OrderOperations.CreateOrder(Helper.BaseClient.Client);
    }

    [Then(@"Order is added to order list")]
    public void ThenOrderisaddedtoorderlist()
    {
        orderList = Helper.BaseServices.OrderOperations.GetOrders();
        bool actual = orderList.Exists(o => o.ClientId == Helper.BaseClient.Client.Id);
        Assert.IsTrue(actual);
    }

    [Then(@"Order is not added to order list")]
    public void ThenOrderisnotaddedtoorderlist()
    {
        orderList = Helper.BaseServices.OrderOperations.GetOrders();
        bool actual = orderList.Exists(o => o.ClientId == Helper.BaseClient.Client.Id);
        Assert.IsFalse(actual);
    }

}