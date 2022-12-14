using Repo;
namespace Shared
{
    using Services;
    public class Operations
    {
        List<Order> orders = new List<Order>();
        IRepository repository = null;
        public Operations()
        {
            repository = Repository.Instance;
            this.orders = repository.GetOrders();
        }

        public List<Product> ProposeProductsBasedOnCart(Cart cart, int quantity)
        {
            this.orders = repository.GetOrders();
            List<Product> basketProducts = new List<Product>();
            if(cart == null || cart.GetCartProducts().Count == 0 || quantity == 0)
            {
                return new List<Product>();
            }
            
            foreach (CartProduct prod in cart.GetCartProducts())
            {
                if (!basketProducts.Contains(prod.Product))
                {
                    basketProducts.Add(prod.Product);
                }
                
            }
            
            var sortedDict = PrepareSortedOrders(basketProducts);
            List<Product> proposal = new List<Product>();
            int i = 0;
            foreach (Order order in sortedDict.Keys)
            {
                if (order.OrderProductList == null) continue;
                foreach (CartProduct p in order.OrderProductList)
                {
                    Product product = p.Product;
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
                    List<Product> prodList = new List<Product>();
                    foreach (CartProduct cp in order.OrderProductList)
                    {
                        prodList.Add(cp.Product);
                    }
                    if (prodList == null) continue;
                    if (prodList.Contains(product))
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
            Dictionary<Product, int> sortedDict = PrepareSortedProducts(product);

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

        private Dictionary<Product, int> PrepareSortedProducts(Product product)
        {
            Dictionary<Product, int> Dict = new Dictionary<Product, int>();
            foreach (Order o in orders)
            {
                List<Product> prodList = new List<Product>();
                foreach (CartProduct cp in o.OrderProductList)
                {
                    prodList.Add(cp.Product);
                }
                if (prodList == null) continue;
                if (prodList.Contains(product))
                {
                    foreach(Product p in prodList)
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