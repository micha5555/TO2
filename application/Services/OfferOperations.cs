namespace Services;

using Repo;
using Shared;

public class OfferOperations : IOfferOperations
{
    IRepository repository;
   
    public OfferOperations()
    {
        repository = Repository.Instance;
    }

    public void AddToOffer(Product product)
    {
        repository.AddProductToOffer(product);
    }

    public void AddToOffer(List<Product> pList)
    {
        repository.AddProductsToOffer(pList);
    }

    public void RemoveFromOffer(Product product)
    {
        repository.RemoveProductFromOffer(product);
    }

    public List<Product> GetProductList()
    {
        return repository.GetAllOfferProducts();
    }

    public List<Product> FilterProductsByCategory(Category category){
        return repository.FilterProductsByCategory(category);
    }
    
    public List<Product> SearchForProductsByName(string name){
        return repository.SearchForProductsByName(name);
    }

}