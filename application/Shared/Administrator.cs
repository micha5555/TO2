namespace Shared
{
    public class Administrator
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public Administrator(string Name, string Surname, string? Login, string? Password) 
        {
            this.Id = Guid.NewGuid();
            this.Name = Name;
            this.Surname = Surname;
            this.Login = Login;
            this.Password = Password;
        }
    }
}