namespace Shared
{
    public class Offer
    {
        private List<Product> ProductList;
        public Offer()
        {
            this.ProductList = new List<Product>();
        }
        public void AddToOffer(Product product){
            this.ProductList.Add(product);
        }
        public void RemoveFromOffer(Product product){
            this.ProductList.Remove(product);
        }
    }
}