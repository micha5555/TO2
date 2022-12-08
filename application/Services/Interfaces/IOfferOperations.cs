namespace Services;
using Shared;

public interface IOfferOperations
{
    public bool AddToOffer(Product product);
    public bool AddToOffer(string name, double price, Category categoryClass, string description);
    public bool AddToOffer(List<Product> pList);
    public bool RemoveFromOffer(Product product);
    public List<Product> GetAllProductList();
    public List<Product> GetActiveProductList();
    public List<Product> FilterProductsByCategory(Category category);
    public List<Product> SearchForAllProductsByName(string name);
    public List<Product> SearchForActiveProductsByName(string name);
}