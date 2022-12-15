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
        bool status = repository.AddAdministrator(admin);

        return status ? RegistrationStatus.Registered : RegistrationStatus.NotRegistered;
    }

    public List<Administrator> getAllAdministrators(){
        return repository.GetAllAdministrators();
    }

    public void removeAdministrator(Administrator administrator){
        repository.RemoveAdministrator(administrator);   
    }
}