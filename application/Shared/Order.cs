namespace Shared
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<Product>? OrderProductList { get; set; }
        public double Price { get; set; }

        public Order(Cart cart){
            this.Id = Guid.NewGuid();
            this.OrderProductList = cart.GetProducts();
            this.Price = cart.CalculateCartPrice();
        }

        public Order(List<Product> products)
        {
            this.Id = Guid.NewGuid();
            this.OrderProductList = products;
            Cart c = new Cart(products);
            this.Price = c.CalculateCartPrice();
        }
    }
}