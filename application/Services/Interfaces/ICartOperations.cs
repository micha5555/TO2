namespace Services;
using Shared;
public interface ICartOperations
{
    public bool AddToCart(CartProduct p);
    public bool RemoveFromCart(CartProduct p);
    public double CalculateCartPrice();
    public List<CartProduct> GetProducts();
}

