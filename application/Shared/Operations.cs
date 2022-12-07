using Repo;
namespace Shared
{
    using Services;
    public class Operations : IGeneralOperations
    {
        List<Order> orders = new List<Order>();

        public Operations()
        {
            IRepository repository = new Repository();
            this.orders = repository.GetOrders();
        }

        public List<Product> ProposeProductsBasedOnCart(Cart cart, int quantity)
        {
            List<Product> basketProducts = new List<Product>();
            foreach (Product prod in cart.GetProducts())
            {
                if (!basketProducts.Contains(prod))
                {
                    basketProducts.Add(prod);
                }
                
            }
            
            var sortedDict = PrepareSortedOrders(basketProducts);
            List<Product> proposal = new List<Product>();
            int i = 0;
            foreach (Order order in sortedDict.Keys)
            {
                if (order.OrderProductList == null) continue;
                foreach (Product product in order.OrderProductList)
                {
                    if (!proposal.Contains(product) && !basketProducts.Contains(product))
                    {
                        proposal.Add(product);
                        i++;
                        if (i == quantity) return proposal;
                    }
                }
            }
            return proposal;
        }

        private Dictionary<Order, int> PrepareSortedOrders(List<Product> basketProducts)
        {
            var ordersWithCount = new Dictionary<Order, int>();
            foreach (Order order in orders)
            {
                ordersWithCount.Add(order, 0);
            }

            foreach (Product product in basketProducts)
            {
                foreach (Order order in ordersWithCount.Keys)
                {
                    if (order.OrderProductList == null) continue;
                    if (order.OrderProductList.Contains(product))
                    {
                        ordersWithCount[order]++;
                    }
                }
            }
            var sorted = from entry in ordersWithCount orderby entry.Value descending select entry;
            var sortedDict = new Dictionary<Order, int>();
            foreach (var entry in sorted)
            {
                sortedDict.Add(entry.Key, entry.Value);
            }
            return sortedDict;
        }

        public List<Product> ProposeProductsBasedOnProduct(Product product, int quantity)
        
        {    
            Dictionary<Product, int> sortedDict = PrepareSortedProducts(orders, product);

            List<Product> proposal = new List<Product>();
            int i = 0;
            foreach (Product p in sortedDict.Keys)
            {
                proposal.Add(p);
                i++;
                if (i == quantity) return proposal;          
            }
            return proposal;
        }

        private static Dictionary<Product, int> PrepareSortedProducts(List<Order> orders, Product product)
        {
            Dictionary<Product, int> Dict = new Dictionary<Product, int>();
            foreach (Order o in orders)
            {
                if (o.OrderProductList == null) continue;
                if (o.OrderProductList.Contains(product))
                {
                    foreach(Product p in o.OrderProductList)
                    {
                        if( Dict.ContainsKey(p))
                        {
                            Dict[p]++;
                        }
                        else
                        {
                            Dict.Add(p, 1);
                        }
                    }
                }
            }
            Dict.Remove(product);
            var sortedDict = Dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return sortedDict;
        }
    }
}