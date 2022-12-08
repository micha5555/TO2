namespace Shared
{
    public class Administrator
    {
        public Guid Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public Administrator(string? Login, string? Password) 
        {
            this.Id = Guid.NewGuid();
            this.Login = Login;
            this.Password = Password;
        }
    }
}