using NUnit.Framework;
using Repo;
using Services;
using Shared;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using TechTalk.SpecFlow;

namespace BDDTests.StepDefinitions
{
    [Binding]
    public class ListingItemsStepDefinitions
    {
        private ClientOperations _clientOperations;
        private CartOperations _cartOperations;
        private OrderOperations _orderOperations;
        private bool _clientIsLoggedIn;
        private OfferOperations _offerOperations;
        private List<Product> offerList;
        private List<CartProduct> cartList;
        private List<CartProduct> orderList;
        private Guid guida;
        private Product product;
        private CartProduct cp;
        private Order order;
        private Client client;

        [Given(@"Client is logged in")]
        public void GivenClientIsLoggedIn()
        {
            _orderOperations = new OrderOperations();
            _offerOperations = new OfferOperations();
            Offer offer = new Offer();
            _offerOperations.AddOfferToOfferList(offer);

            _clientOperations = new ClientOperations();
            _clientOperations.registerNewClient("Maciej", "Maciejowski", "Bazantarnia", "04-550", "login", "password");

            client = _clientOperations.GetClientByLogin("login");
            _cartOperations = new CartOperations(client.Id);
            _clientIsLoggedIn = _clientOperations.checkClientCredentials("login", "password");
        }

        [Given(@"Offer list is not empty")]
        public void GivenOfferListIsNotEmpty()
        {
            guida = Guid.NewGuid();
            Product prod = new Product("Wiertarkaaa", 121.0, Category.Narzêdzia, "Wierciaaa");
            _offerOperations.AddToOffer(prod);
        }

        [When(@"Client lists offer")]
        public void WhenClientListsOffer()
        {
            offerList = _offerOperations.GetAllProductList();
        }

        [Then(@"Offer list display is not empty")]
        public void ThenOfferListDisplayIsNotEmpty()
        {
            int expected = 1;
            int actual = offerList.Count;
            Assert.AreEqual(expected, actual);
        }

        [Given(@"Offer list is empty")]
        public void GivenOfferListIsEmpty()
        {
            _offerOperations.RemoveFromOffer(product);
            _offerOperations.RemoveFromOffer(new Product("Wiertarkaaa", 121.0, Category.Narzêdzia, "Wierciaaa"));
        }

        [Then(@"Offer list display is empty")]
        public void ThenOfferListDisplayIsEmpty()
        {
            int expected = 0;
            int actual = offerList.Count;
            Assert.AreEqual(expected, actual);
        }

        [Given(@"Cart list is not empty")]
        public void GivenCartListIsNotEmpty()
        {
            Product heh = new Product("Wiertarkaaa", 121.0, Category.Narzêdzia, "Wierciaaa");
            _offerOperations.AddToOffer(heh);
            cp = new CartProduct(heh, 1);
            _cartOperations.AddToCart(cp);
        }

        [When(@"Client lists cart items")]
        public void WhenClientListsCartItems()
        {
            cartList = _cartOperations.GetProducts();
        }

        [Then(@"Cart list display is not empty")]
        public void ThenCartListDisplayIsNotEmpty()
        {
            Assert.AreEqual(1, cartList.Count);
        }

        [Given(@"Cart list is empty")]
        public void GivenCartListIsEmpty()
        {
            _cartOperations.cart.ClearCart();
            cartList = _cartOperations.GetProducts();
        }

        [Then(@"Cart list display is empty")]
        public void ThenCartListDisplayIsEmpty()
        {
            Assert.AreEqual(0, cartList.Count);
        }

        [Given(@"Order list is not empty")]
        public void GivenOrderListIsNotEmpty()
        {
            product = new Product {
                CategoryClass = Category.AGD,
                Description = "yes",
                Id = guida,
                isActive = true,
                Name = "Yessir",
                Price = 120.0
            };
            cp = new CartProduct(product, 1);
            _cartOperations.AddToCart(cp);
            client.Cart = new Cart(new List<CartProduct> { cp });
            order = new Order(client);
        }

        [When(@"Client lists orders")]
        public void WhenClientListsOrders()
        {
            orderList = order.GetProducts();
        }

        [Then(@"Order list display is not empty")]
        public void ThenOrderListDisplayIsNotEmpty()
        {
            Assert.AreEqual(1, orderList.Count);
        }

        [Given(@"Order list is empty")]
        public void GivenOrderListIsEmpty()
        {
            _cartOperations.cart.ClearCart();
            order = new Order(client);
            orderList = order.GetProducts();
        }

        [Then(@"Order list display is empty")]
        public void ThenOrderListDisplayIsEmpty()
        {
            Assert.AreEqual(0, orderList.Count);
        }
    }
}
