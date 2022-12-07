using Frontend;

namespace Services;

public class AdministratorOperations : IAdministratorOperations
{
    public bool checkAdministratorCredentials(string login, string password)
    {
        return true;
        //TODO To Implement!
    }

    public RegistrationStatus registerNewAdministrator(string login, string password)
    {
        return RegistrationStatus.Registered;
        //TODO To Implement!@
    }
}