namespace Shared
{
    public class Offer
    {
        public List<Product> ProductList{get; set;}

        public Offer()
        {
            this.ProductList = new List<Product>();
        }

        public void AddToOffer(Product product)
        {
            this.ProductList.Add(product);
        }

        public void AddToOffer(List<Product> pList)
        {
            ProductList.AddRange(pList);
        }

        public void RemoveFromOffer(Product product)
        {
            this.ProductList.Remove(product);
        }

        public List<Product> GetProductList()
        {
            return this.ProductList;
        }
    }
}