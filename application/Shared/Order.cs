namespace Shared
{
    public class Order
    {
        public Guid Id { get; set; } // do każdego ID w serwisie zrobić counter żeby było unikalne dla nowego uruchomienia programu
        public List<Product>? OrderProductList { get; set; }
        public double Price { get; set; }
        public Guid clientId {get;set;}

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