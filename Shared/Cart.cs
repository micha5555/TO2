namespace Shared
{
    public class Cart
    {
        private double ActualPrice;
        private List<Product> ProductList;
        public Cart()
        {
            this.ProductList = new List<Product>();
        }
        public void AddToCart(Product p)
        {
            this.ProductList.Add(p);
        }
        public void RemoveFromCart(Product p)
        {
            this.ProductList.Remove(p);
        }
        public double CalculateCartPrice()
        {
            double cartPrice = 0;
            if (ProductList.Count <= 0)
            {
                return -1;
            }
            foreach (Product p in ProductList)
            {
                cartPrice += p.Price;
            }
            if (cartPrice < 0)
            {
                return -2;
            }
            return cartPrice;
        }

        public List<Product> GetProducts(){
            return this.ProductList;
        }
    }
}