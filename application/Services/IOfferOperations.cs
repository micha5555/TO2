namespace Services;
using Shared;

public interface IOfferOperations
{
    public void AddToOffer(Product product);
    public void AddToOffer(List<Product> pList);
    public void RemoveFromOffer(Product product);
    public List<Product> GetProductList();
}