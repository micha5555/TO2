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
        if (repository.GetAllOfferProducts().Contains(product))
        {
            return false;
        }
        repository.AddProductToOffer(product);
        return true;
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

    public List<Product> GetProductList()
    {
        return repository.GetAllOfferProducts();
    }

    public List<Product> FilterProductsByCategory(Category category)
    {
        return repository.FilterProductsByCategory(category);
    }

    public List<Product> SearchForProductsByName(string name)
    {
        return repository.SearchForProductsByName(name);
    }

}