using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shared;
using TechTalk.SpecFlow;

namespace BDDTests.StepDefinitions;

[Binding]
public class CartProductOperationsStepDefinition
{
    private int customProductQuantity = 31;

    [Given(@"Product is in cart")]
    public void GivenProductisincart()
    {
        Helper.ClearMethods.ClearCart();
        Helper.BaseProducts.CartProduct = Helper.CommonMethods.CreateNewCorrectCartProduct();
        Helper.BaseServices.CartOperations.AddToCart(Helper.BaseProducts.CartProduct);
    }

    [When(@"Client removes product from cart")]
    public void WhenClientremovesproductfromcart()
    {
        Helper.BaseServices.CartOperations.RemoveFromCart(Helper.BaseProducts.CartProduct);
    }

    [Then(@"Cart does not contain product")]
    public void ThenCartdoesnotcontainproduct()
    {
        List<CartProduct> cartProducts = Helper.BaseServices.CartOperations.GetProducts();
        Assert.False(cartProducts.Contains(Helper.BaseProducts.CartProduct));
    }

    [Given(@"Product is not in cart")]
    public void GivenProductisnotincart()
    {
        Helper.ClearMethods.ClearCart();
    }

    [When(@"Client adds product to cart")]
    public void WhenClientaddsproducttocart()
    {
        Helper.BaseServices.CartOperations.AddToCart(Helper.BaseProducts.CartProduct);
    }

    [Then(@"Product quantity in cart is increased")]
    public void ThenProductquantityincartisincreased()
    {
        List<CartProduct> cartProducts = Helper.BaseServices.CartOperations.GetProducts();
        int actualQuantity = cartProducts.Find(p => p.Product == Helper.BaseProducts.CartProduct.Product).Quantity;
        int expectedQuantity = customProductQuantity * 2;
        Assert.AreEqual(expectedQuantity, actualQuantity);   
    }

    [Given(@"Product quantity is one")]
    public void GivenProductquantityisone()
    {
        Helper.BaseProducts.CartProduct = Helper.CommonMethods.CreateNewCorrectCartProduct();
    }


    [Then(@"Product is in cart")]
    public void ThenProductisincart()
    {
        List<CartProduct> cartProducts = Helper.BaseServices.CartOperations.GetProducts();
        Assert.True(cartProducts.Contains(Helper.BaseProducts.CartProduct));
    }



    [Given(@"Product quantity is bigger than one")]
    public void GivenProductquantityisbiggerthanone()
    {
        Helper.BaseProducts.CartProduct.Quantity = customProductQuantity;
    }

    [When(@"Client adds products to cart")]
    public void WhenClientaddsproductstocart()
    {
        Helper.BaseServices.CartOperations.AddToCart(Helper.BaseProducts.CartProduct);
    }

    [Then(@"Products are in cart")]
    public void ThenProductsareincart()
    {
        List<CartProduct> cartProducts = Helper.BaseServices.CartOperations.GetProducts();
        Assert.True(cartProducts.Contains(Helper.BaseProducts.CartProduct));
    }

    [Given(@"Product quantity is negative")]
    public void GivenProductquantityisnegative()
    {
        Helper.BaseProducts.CartProduct.Quantity = -1;
    }
}

