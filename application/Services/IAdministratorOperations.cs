namespace Services;

public interface IAdministratorOperations{
    public bool checkAdministratorCredentials(string login, string password);
    public void createNewAdministrator(string login, string password);
}