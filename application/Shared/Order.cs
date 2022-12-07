namespace Shared
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<CartProduct>? OrderProductList { get; set; }
        public double Price { get; set; }

        public Guid ClientId { get; set; }

        public Order() { }
        public Order(Client client)
        {
            this.Id = Guid.NewGuid();
            ClientId = client.Id;
            this.OrderProductList = client.Cart.GetCartProducts();
            this.Price = client.Cart.CalculateCartPrice();
        }

        //Bedzie do wywalenia potem
        public Order(List<CartProduct> products)
        {
            this.Id = Guid.NewGuid();
            this.OrderProductList = products;
            Cart c = new Cart(products);
            this.Price = c.CalculateCartPrice();
        }
        public List<CartProduct> GetProducts()
        {
            return this.OrderProductList;
        }
    }
}
