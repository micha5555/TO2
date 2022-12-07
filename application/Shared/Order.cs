namespace Shared
{
    public class Order
    {
        public Guid Id { get; set; } 
        public List<CartProduct>? OrderProductList { get; set; }
        public double Price { get; set; }
        public Order() { }
        public Order(Cart cart)
        {
            this.Id = Guid.NewGuid();
            this.OrderProductList = cart.GetCartProducts();
            this.Price = cart.CalculateCartPrice();
        }

        public Order(List<CartProduct> products)
        {
            this.Id = Guid.NewGuid();
            this.OrderProductList = products;
            Cart c = new Cart(products);
            this.Price = c.CalculateCartPrice();
        }
        public List<CartProduct> GetProducts(){
            return this.OrderProductList;
        }
    }
}