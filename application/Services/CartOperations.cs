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
        cart = repository.GetClientById(clientID).Cart;
    }

    public bool AddToCart(CartProduct p)
    {
        if (p == null)
        {
            return false;
        }
        if (p.Quantity < 1)
        {
            return false;
        }
        return cart.AddToCart(p);
    }

    public bool RemoveFromCart(CartProduct p)
    {
        if (p == null)
        {
            return false;
        }
        return cart.RemoveFromCart(p);
    }

    public double CalculateCartPrice()
    {
        return cart.CalculateCartPrice();
    }

    public List<CartProduct> GetProducts()
    {
        return cart.GetCartProducts();
    }
}
