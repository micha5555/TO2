namespace Shared
{
    public class Operations
    {
        public List<Product> ProposeProductsBasedOnCart(Cart cart, List<Order> orders, Offer offer, int quantity)
        {
            List<Product> basketProducts = new List<Product>();
            foreach (Product prod in cart.GetProducts())
            {
                if (!basketProducts.Contains(prod))
                {
                    basketProducts.Add(prod);
                }
                
            }
            List<Product> offerProducts = offer.GetProductList();
            var ordersWithCount = new Dictionary<Order, int>();
            foreach (Order order in orders)
            {
                ordersWithCount.Add(order, 0);
            }

            foreach (Product product in basketProducts)
            {
                foreach (Order order in ordersWithCount.Keys)
                {
                    if (order.OrderProductList.Contains(product))
                    {
                        ordersWithCount[order]++;
                    }
                }
            }
            var sortedDict = (Dictionary<Order, int>)from entry in ordersWithCount orderby entry.Value descending select entry;
            //TODO: posortować listę, wybrać proponowane produkty(po kolei brać te któych nei ma w baskecie a są najpopularniejsze w orderach? jakieś losowanie może?)
            List<Product> proposal = new List<Product>();
            int i = 0;
            foreach (Order order in sortedDict.Keys)
            {
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
    }
}