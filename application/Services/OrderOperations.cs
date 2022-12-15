namespace Services;

using Repo;
using Shared;

public class OrderOperations : IOrderOperations
{
    IRepository repository;

    public OrderOperations()
    {
        repository = Repository.Instance;
    }

    public bool UpdateOrder(Order order)
    {
        return repository.UpdateOrder(order);
    }

    public List<Order> GetOrders()
    {
        return repository.GetOrders();
    }
    public void AddOrderToOrderList(Order o)
    {
        repository.AddOrder(o);
    }

    public bool CreateOrder(Client client)
    {
        List<CartProduct> products = client.Cart.GetCartProducts();
        if (products.Count == 0)
        {
            return false;
        }
        Order order = new Order(client);
        repository.AddOrder(order);
        client.Cart.ClearCart();
        return true;
    }
}