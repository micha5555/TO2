namespace Services;
using Shared;
public interface ICartOperations
{
    public void AddToCart(Product p);
    public void RemoveFromCart(Product p);
    public double CalculateCartPrice();
    public List<Product> GetProducts();
}

