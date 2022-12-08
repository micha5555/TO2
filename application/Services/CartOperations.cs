namespace Services;

using Repo;
using Shared;
public class CartOperations : ICartOperations
{
    Cart cart;
    public CartOperations(Guid clientID)
    {
        cart = new Cart();
    }
   
    public void AddToCart(CartProduct p)
    {
        cart.AddToCart(p);
    }
  
    public void RemoveFromCart(CartProduct p)
    {
        cart.RemoveFromCart(p);
    }
 
    public double CalculateCartPrice()
    { 
        return cart.CalculateCartPrice();;
    }
  
    public List<CartProduct> GetProducts()
    {
        return cart.GetCartProducts();
    }
}
