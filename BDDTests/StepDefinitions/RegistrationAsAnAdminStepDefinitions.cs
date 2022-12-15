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
    }
}
