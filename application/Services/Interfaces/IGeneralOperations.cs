namespace Services;
using Shared;

public interface IGeneralOperations
{
    public List<Product> ProposeProductsBasedOnCart(Cart cart, int quantity);

    public List<Product> ProposeProductsBasedOnProduct(Product product, int quantity);
}