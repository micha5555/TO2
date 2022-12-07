namespace Shared
{
    public class Client
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        public Client(string Name, string Surname, string? Address, string? PostalCode)
        {
            this.Id = Guid.NewGuid();
            this.Name = Name;
            this.Surname = Surname;
            this.Address = Address;
            this.PostalCode = PostalCode;
        }
    }
}