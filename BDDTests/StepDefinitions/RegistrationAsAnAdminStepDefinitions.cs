using NUnit.Framework;
using Repo;
using Services;

namespace BDDTests.StepDefinitions
{
    [Binding]
    public class RegistrationAsAnAdminStepDefinitions
    {
        private AdministratorOperations _administratorOperations;
        private string _registrationLogin, _registrationPassword;
        private IRepository _repository;
        private bool _doesAdminExistsInDB;

        [Given(@"Admin is not registered")]
        public void GivenAdminIsNotRegistered()
        {
            _administratorOperations = Helper.BaseServices.AdministratorOperations;
            Helper.BaseServices.GeneralOperations = new GeneralOperations();
            Helper.BaseServices.GeneralOperations.ReadDataOnLaunch();
            Helper.ClearMethods.ClearAllAdministrators();
        }

        [When(@"Admin provides correct login and password when registering")]
        public void WhenAdminProvidesCorrectLoginAndPasswordWhenRegistering(Table table)
        {
            _registrationLogin = table.Rows[0]["login"];
            _registrationPassword = table.Rows[0]["password"];
            _administratorOperations.registerNewAdministrator(_registrationLogin, _registrationPassword);

            _repository = Repository.Instance;
            _doesAdminExistsInDB = _repository.CheckIfAdminExists(_registrationLogin);

        }

        [Then(@"The administrator account is created in the database")]
        public void ThenTheAdministratorAccountIsCreatedInTheDatabase()
        {
            Assert.IsTrue(_doesAdminExistsInDB);
        }

        [When(@"Admin provides invalid (.*) and (.*) while registering")]
        public void WhenAdminEntersProvidesInvalidLoginAndPasswordWhileRegistering(string login, string password)
        {
            _administratorOperations.registerNewAdministrator(login, password);
            //_doesAdminExistsInDB = _repository.AddAdministrator(new Shared.Administrator(login, password));
        }

        [Then(@"The administrator account is not created in the database")]
        public void ThenTheAdministratorAccountIsNotCreatedInTheDatabase()
        {
            Assert.IsFalse(_doesAdminExistsInDB);
        }

    }
}
