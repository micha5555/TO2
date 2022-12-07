namespace Services;
using Shared;

public interface IGeneralOperations
{
    public List<Product> ProposeProductsBasedOnCart(Cart cart, List<Order> orders, int quantity);

    public List<Product> ProposeProductsBasedOnProduct(Product product, List<Order> orders, int quantity);
}