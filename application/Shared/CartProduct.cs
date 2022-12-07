namespace Shared
{
    public class CartProduct
    {

        public Product Product {get; set; }
        public int Quantity {get; set; }

        public CartProduct(Product Product, int Quantity)
        {
            this.Product = Product;
            this.Quantity = Quantity;
        }
    }
}