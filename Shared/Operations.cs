namespace Shared
{
    public class Operations
    {
        public List<Product> ProposeProductsBasedOnCart(Cart cart, Offer offer)
        {
            List<Product> basketProducts = cart.GetProducts();
            List<Product> offerPRoducts = offer.GetProductList();
            return null;
        }
    }
}