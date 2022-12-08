using Repo;
using Shared;

using Frontend;


namespace Services;

public class AdministratorOperations : IAdministratorOperations
{
    IRepository repository;
    public AdministratorOperations()
    {
        repository = Repository.Instance;
    }
    public bool checkAdministratorCredentials(string login, string password)
    {
        return repository.CheckCredentialsAdmin(login, password);
    }

    public RegistrationStatus registerNewAdministrator(string login, string password)
    {
        Administrator admin = new Administrator(login, password);
        bool response = repository.AddAdministrator(admin);
        if (response)
        {
            return RegistrationStatus.Registered;    
        }
        return RegistrationStatus.NotRegistered;
    }
}