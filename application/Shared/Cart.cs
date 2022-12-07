namespace Shared
{
    public class Cart
    {
        public Guid Id { get; set; }
        private double ActualPrice;
        public List<Product> ProductList;
        public Cart(double price, List<Product> pl)
        {
            this.Id = Guid.NewGuid();
            this.ActualPrice = price;
            this.ProductList = pl;
        }
        public Cart()
        {
            this.Id = System.Guid.NewGuid();
            this.ProductList = new List<Product>();
            this.ActualPrice = 0;
        }

        public Cart(List<Product> products)
        {
            this.Id = System.Guid.NewGuid();
            this.ProductList = products;
            this.ActualPrice = 0;
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

        public List<Product> GetProducts()
        {
            return this.ProductList;
        }
    }
}