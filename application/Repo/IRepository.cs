using Shared;
namespace Repo
{

    public interface IRepository
    {
        List<Order> GetOrders();
        public void DoSomething1();
        public void DoSomething2();
        public void DoSomething3();
    }

}