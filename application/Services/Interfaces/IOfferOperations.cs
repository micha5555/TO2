namespace Services;
using Shared;

public interface IOfferOperations
{
    public bool AddToOffer(Product product);
    public bool AddToOffer(List<Product> pList);
    public bool RemoveFromOffer(Product product);
    public List<Product> GetProductList();
    public List<Product> FilterProductsByCategory(Category category);
    public List<Product> SearchForProductsByName(string name);
}