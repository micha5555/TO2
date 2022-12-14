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

    public bool AddToOffer(Product product)
    {
        return repository.AddProductToOffer(product);
    }
    public bool AddToOffer(string name, double price, Category categoryClass, string description)
    {
        Product product = new Product(name, price, categoryClass, description);
        return repository.AddProductToOffer(product);
    }

    public bool AddToOffer(List<Product> pList)
    {
        // todo
        repository.AddProductsToOffer(pList);
        return true;
    }

    public bool RemoveFromOffer(Product product)
    {
        if (repository.GetAllOfferProducts().Contains(product))
        {
            repository.RemoveProductFromOffer(product);
            return true;
        }
        return false;
    }

    public List<Product> GetAllProductList()
    {
        return repository.GetAllOfferProducts();
    }

    public List<Product> GetActiveProductList()
    {
        List<Product> activeProducts = repository.GetAllOfferProducts(); 
        activeProducts = activeProducts.Where(p => p.isActive == true).ToList();
        return repository.GetAllOfferProducts();
    }

    public List<Product> FilterProductsByCategory(Category category)
    {
        return repository.FilterProductsByCategory(category);
    }

    public List<Product> SearchForAllProductsByName(string name)
    {
        return repository.SearchForProductsByName(name);
    }

    public List<Product> SearchForActiveProductsByName(string name)
    {
        List<Product> activeProducts = repository.SearchForProductsByName(name); 
        activeProducts = activeProducts.Where(p => p.isActive == true).ToList();
        return repository.GetAllOfferProducts();
    }

    public void ActivateProduct(Product product){
        product.Activate();
    }
    public void DeactivateProduct(Product product){
        product.Deactivate();
    }

    public void AddOfferToOfferList(Offer o) {
        repository.AddOffer(o);
    }
}