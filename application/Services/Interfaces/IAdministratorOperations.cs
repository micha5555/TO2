using Frontend;

namespace Services;

public interface IAdministratorOperations{
    public bool checkAdministratorCredentials(string login, string password);
    public RegistrationStatus registerNewAdministrator(string login, string password);
}