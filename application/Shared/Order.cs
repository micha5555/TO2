namespace Shared
{
    public class Order
    {
        public Guid Id { get; set; } 
        public List<Product>? OrderProductList { get; set; }
        public double Price { get; set; }

        public Guid ClientId {get;set;}

        public Order() { }
        public Order(Client client)
        {
            this.Id = Guid.NewGuid();
            ClientId = client.Id;
            this.OrderProductList = client.Cart.GetProducts();
            this.Price = client.Cart.CalculateCartPrice();
        }

//Bedzie do wywalenia potem
        public Order(List<Product> products)
        {
            this.Id = Guid.NewGuid();
            this.OrderProductList = products;
            Cart c = new Cart(products);
            this.Price = c.CalculateCartPrice();
        }
        public List<Product> GetProducts(){
            return this.OrderProductList;
        }
    }
}
