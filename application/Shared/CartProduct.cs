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

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                CartProduct p = (CartProduct)obj;
                return (this.Product.Equals(p.Product));
            }
        }
    }
}