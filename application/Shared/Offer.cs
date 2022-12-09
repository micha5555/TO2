using Services;
using System.Text.Json.Serialization;

namespace Shared
{
    public class Offer
    {
        public Guid Id { get; set; }
        public List<Product> ProductList { get; set; }

        [JsonConstructor]
        public Offer()
        {
            this.ProductList = new List<Product>();
        }

        public Offer(List<Product> products)
        {
            this.Id = Guid.NewGuid();
            this.ProductList = products;
        }

        public bool AddToOffer(Product product)
        {
            bool isHere = false;
            foreach (Product p in this.ProductList)
            {
                if (p.Equals(product))
                {
                    isHere = true;
                }
            }
            if (isHere)
            {
                return false;
            }
            else
            {
                this.ProductList.Add(product);
                return true;
            }

        }
        public bool UpdateProductInOffer(Guid id, Product product) 
        { 
            foreach(Product p in this.ProductList) 
            {
                if (p.Id.Equals(id)) {
                    this.ProductList.Remove(p);
                    this.ProductList.Add(product);
                    return true;
                }
            }
            return false;
        }

        public void AddToOffer(List<Product> pList)
        {
            ProductList.AddRange(pList);
        }

        public bool RemoveFromOffer(Product product)
        {
            return this.ProductList.Remove(product);
        }

        public List<Product> GetProductList()
        {
            return this.ProductList;
        }
    }
}