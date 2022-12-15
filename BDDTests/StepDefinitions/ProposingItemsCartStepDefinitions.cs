using Shared;

namespace BDDTests.StepDefinitions;

[Binding]
public class ProposingItemsCartStepDefinitions  
{

    // [Given(@"Client is logged in")]
    // public void GivenClientisloggedin()
    // {
    // }
    Cart _cart;

    [Given(@"Clients cart is not empty")]
    public void GivenClientscartisnotempty()
    {
        // _cart = client.Cart;
    }

    [When(@"Client enters his cart")]
    public void WhenCliententershiscart()
    {
    }

    [Then(@"Client get list of proposed products")]
    public void ThenClientgetlistofproposedproducts()
    {

    }

}
