using Frontend;
using NUnit.Framework;
using Repo;
using Services;

namespace BDDTests.StepDefinitions
{
    [Binding]
    public class RegistrationAsAClientStepDefinitions
    {
        private ClientOperations _clientOperations;
        private string _registrationLogin, _registrationPassword;
        private string _name, _surname, _address, _postalCode;
        private IRepository _repository = Repository.Instance;
        private bool _doesClientExistsInDB;
        private RegistrationStatus _registrationStatus;

        [Given(@"Client is not registered")]
        public void GivenClientIsNotRegistered()
        {
            Helper.BaseServices.GeneralOperations.ReadDataOnLaunch();
            _clientOperations = Helper.BaseServices.ClientOperations;
            Helper.BaseServices.GeneralOperations = new GeneralOperations();
        }

        [When(@"Client provides correct data when registering")]
        public void WhenClientProvidesCorrectDataWhenRegistering(Table table)
        {
            _name = table.Rows[0]["name"];
            _surname = table.Rows[0]["surname"];
            _address = table.Rows[0]["address"];
            _postalCode = table.Rows[0]["postalCode"];
            _registrationLogin = table.Rows[0]["login"];
            _registrationPassword = table.Rows[0]["password"];
            _clientOperations.registerNewClient(
                _name,
                _surname,
                _address,
                _postalCode,
                _registrationLogin,
                _registrationPassword);

            _doesClientExistsInDB = _repository.CheckIfClientExists(_registrationLogin);

        }

        [Then(@"The client account is created in the database")]
        public void ThenTheClientAccountIsCreatedInTheDatabase()
        {
            Assert.IsTrue(_doesClientExistsInDB);
        }

        [When(@"Client provides invalid (.*) and invalid (.*) and (.*) and (.*) and (.*) and (.*) while registering")]
        public void WhenClientProvidesInvalid_ClientAndTestWhileRegistering(string login, string password, string name, string surname, string address, string postalCode)
        {
            _clientOperations.registerNewClient(
                name, 
                surname, 
                address, 
                postalCode,
                login, 
                password);
            _doesClientExistsInDB = _repository.CheckIfClientExists(login);
        }

        [Then(@"The client account is not created in the database")]
        public void ThenTheClientAccountIsNotCreatedInTheDatabase()
        {
            Assert.IsFalse(_doesClientExistsInDB);
        }

        [Given(@"Client is registered using login and password")]
        public void GivenClientIsRegisteredUsingLoginAndPassword(Table table)
        {
            Helper.BaseServices.GeneralOperations.ReadDataOnLaunch();
            _clientOperations = Helper.BaseServices.ClientOperations;

            _name = table.Rows[0]["name"];
            _surname = table.Rows[0]["surname"];
            _address = table.Rows[0]["address"];
            _postalCode = table.Rows[0]["postalCode"];
            _registrationLogin = table.Rows[0]["login"];
            _registrationPassword = table.Rows[0]["password"];
            _clientOperations.registerNewClient(
                _name,
                _surname,
                _address,
                _postalCode,
                _registrationLogin,
                _registrationPassword);
        }

        [When(@"Client provides already registered <login> and <password> while registering again")]
        public void WhenClientProvidesAlreadyRegisteredLoginAndPasswordWhileRegisteringAgain()
        {
            _registrationStatus = _clientOperations.registerNewClient(
                _name,
                _surname,
                _address,
                _postalCode,
                _registrationLogin,
                _registrationPassword);
        }

        [Then(@"The client can not register using existing login")]
        public void ThenTheClientCanNotRegisterUsingExistingLogin()
        {
            Assert.AreEqual(RegistrationStatus.NotRegistered, _registrationStatus);
        }
    }
}
