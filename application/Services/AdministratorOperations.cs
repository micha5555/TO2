using Repo;
using Shared;

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

    public void createNewAdministrator(string name, string surname, string login, string password)
    {
        Administrator admin = new Administrator(name, surname, login, password);
    }
}