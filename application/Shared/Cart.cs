namespace Shared
{
    public class Cart
    {
        private double ActualPrice;
        public List<CartProduct> CartProductList;

        public Cart()
        {
            this.CartProductList = new List<CartProduct>();
            this.ActualPrice = 0;
        }

        public Cart(List<Product> products)
        {
            this.CartProductList = new List<CartProduct>();
            foreach (Product p in products)
            {
                CartProductList.Add(new CartProduct(p, 1));
            }
            this.ActualPrice = 0;
        }

        public Cart(List<CartProduct> products)
        {
            this.CartProductList = products;
            this.ActualPrice = 0;
        }

        public Cart(double price, List<Product> pl)
        {
            this.ActualPrice = price;
            this.CartProductList = new List<CartProduct>();
            foreach (Product p in pl)
            {
                CartProductList.Add(new CartProduct(p, 1));
            }
        }

        public bool AddToCart(CartProduct p)
        {
            if (this.CartProductList.Contains(p))
            {
                this.CartProductList.FirstOrDefault(p).Quantity += p.Quantity;
            }
            else
            {
                this.CartProductList.Add(p);
            }
            return true;
        }

        public bool RemoveFromCart(CartProduct p)
        {
            if (this.CartProductList.Contains(p))
            {
                this.CartProductList.FirstOrDefault(p).Quantity -= 1;
                if (this.CartProductList.FirstOrDefault(p).Quantity < 1)
                {
                    this.CartProductList.Remove(p);
                }
                return true;
            }
            return false;
        }

        public double CalculateCartPrice()
        {
            double cartPrice = 0;
            if (CartProductList.Count <= 0)
            {
                return -1;
            }
            foreach (CartProduct cp in CartProductList)
            {
                cartPrice += cp.Product.Price * cp.Quantity;
            }
            if (cartPrice < 0)
            {
                return -2;
            }
            return cartPrice;
        }

        public List<CartProduct> GetCartProducts()
        {
            return this.CartProductList;
        }

        public void ClearCart()
        {
            CartProductList = new List<CartProduct>();
        }
    }
}