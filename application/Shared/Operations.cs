namespace Shared
{
    using Services;
    public class Operations : IGeneralOperations
    {

        public List<Product> ProposeProductsBasedOnCart(Cart cart, List<Order> orders, int quantity)
        {
            List<Product> basketProducts = new List<Product>();
            foreach (Product prod in cart.GetProducts())
            {
                if (!basketProducts.Contains(prod))
                {
                    basketProducts.Add(prod);
                }
                
            }
            
            var sortedDict = PrepareSortedOrders(orders, basketProducts);
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

        private static Dictionary<Order, int> PrepareSortedOrders(List<Order> orders, List<Product> basketProducts)
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
    }
}