using System.Linq;
using System.Collections.Generic;
using Shared;

namespace BDDTests.StepDefinitions.Helper;

public static class ClearMethods
{
    public static void ClearOffer()
    {
        List<Product> list = Helper.BaseServices.OfferOperations.GetAllProductList();
        foreach (Product product in list)
        {
            Helper.BaseServices.OfferOperations.RemoveFromOffer(product);
        }
    }

    public static void ClearCart()
    {
        Helper.BaseServices.CartOperations.cart.ClearCart();
    }

    public static void ClearAllAdministrators()
    {
        List<Administrator> list = Helper.BaseServices.AdministratorOperations.getAllAdministrators();
        foreach (Administrator admin in list)
        {
            Helper.BaseServices.AdministratorOperations.removeAdministrator(admin);
        }
    }
}