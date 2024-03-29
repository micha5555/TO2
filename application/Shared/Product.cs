namespace Shared
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category CategoryClass { get; set; }
        public string Description { get; set; }

        public bool isActive { get; set; }

        public Product()
        {
            this.Description = "";
        }

        public Product(string Name, double Price, Category CategoryClass, string Description)
        {
            this.Id = Guid.NewGuid();
            this.Name = Name;
            this.CategoryClass = CategoryClass;
            this.Description = Description;
            this.isActive = true;
            this.Price = Price;
        }

        public void Activate()
        {
            this.isActive = true;
        }
        public void Deactivate()
        {
            this.isActive = false;
        }
        public void changePrice(double price)
        {
            this.Price = price;
        }

        public override string ToString()
        {
            string message = "";
            message += $"{Name}\t\t{CategoryClass}\t\t{Price}";
            return message;
        }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Product p = (Product)obj;
                return (Name.Equals(p.Name)) && (Price == p.Price) && (CategoryClass.Equals(p.CategoryClass));
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() * 17 + this.Price.GetHashCode() * 17 + this.CategoryClass.GetHashCode() * 17;
        }


    }
}