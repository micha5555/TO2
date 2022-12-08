namespace Services;

using Repo;
using Shared;
public class CartOperations : ICartOperations
{
    public Cart cart;
    IRepository repository;
    public CartOperations(Guid clientID)
    {
        repository = Repository.Instance;
        cart = new Cart();
        //cart = repository.GetClient(clientID).Cart;
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
