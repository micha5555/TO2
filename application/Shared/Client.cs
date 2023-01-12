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
        public Cart Cart = new Cart();

        public Client(string Name, string Surname, string? Address, string? PostalCode, string Login, string? Password)
        {
            this.Id = Guid.NewGuid();
            this.Name = Name;
            this.Surname = Surname;
            this.Address = Address;
            this.PostalCode = PostalCode;
            this.Login = Login;
            this.Password = Password;
        }

        public Client(){
            
        }
    }
}