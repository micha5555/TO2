namespace Shared
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public Category CategoryClass { get; set; }
        string Description { get; set; }
        public Product() { }
        public Product(string Name, double Price, Category CategoryClass, string Description)
        {
            this.Id = Guid.NewGuid();
            this.Name = Name;
            this.CategoryClass = CategoryClass;
            this.Description = Description;
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
    }
}