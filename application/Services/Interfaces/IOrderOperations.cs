using Shared;

namespace Services;


public interface IOrderOperations
{
    public bool UpdateOrder(Order order);
    public List<Order> GetOrders();
}

