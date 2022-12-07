using Services;
using System.Text.Json.Serialization;

namespace Shared
{
    public class Offer : IOfferOperations
    {
        public Guid Id { get; set; }
        public List<Product> ProductList { get; set; }

        [JsonConstructor]
        public Offer(){
            this.ProductList = new List<Product>();
        }

        public Offer(List<Product> products)
        {
            this.Id = Guid.NewGuid();
            this.ProductList = products;
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