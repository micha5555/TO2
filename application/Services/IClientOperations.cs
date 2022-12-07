namespace Services;

public interface IClientOperations
{
    public bool checkClientCredentials(string login, string password);
    public void registerNewClient(string login, string password);
    
}

