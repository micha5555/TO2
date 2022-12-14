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
    public void AddOrderToOrderList(Order o) {
        repository.AddOrder(o);
    }
}