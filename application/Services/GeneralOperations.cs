namespace Services;

using Repo;
using Shared;

public class GeneralOperations : IGeneralOperations
{
    Operations o;
    IRepository repository;
    public GeneralOperations()
    {
        o = new Operations();
        repository = Repository.Instance;
    }

    public List<Product> ProposeProductsBasedOnCart(Cart cart, int quantity)
    {
        return o.ProposeProductsBasedOnCart(cart, quantity);;
    }

    public List<Product> ProposeProductsBasedOnProduct(Product product, int quantity)
    {
        return o.ProposeProductsBasedOnProduct(product, quantity);
    }

    public void ReadDataOnLaunch(){
        repository.ReadDataOnLaunch();
    }
    public void SaveDataOnExit(){
        repository.SaveDataOnExit();
    }
}