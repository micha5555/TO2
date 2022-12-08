namespace Services;
using Shared;
public interface ICartOperations
{
    public void AddToCart(CartProduct p);
    public void RemoveFromCart(CartProduct p);
    public double CalculateCartPrice();
    public List<CartProduct> GetProducts();
}

