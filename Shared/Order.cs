namespace Shared
{
    public class Order
    {
        public int Id { get; set; } // do każdego ID w serwisie zrobić counter żeby było unikalne dla nowego uruchomienia programu
        public List<Product>? OrderProductList { get; set; }
        public double Price { get; set; }

        public Order(Cart cart, int id){
            this.Id = id;
            this.OrderProductList = cart.GetProducts();
            this.Price = cart.CalculateCartPrice();
        }
    }
}