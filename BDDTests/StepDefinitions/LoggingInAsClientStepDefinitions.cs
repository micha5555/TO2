using NUnit.Framework;
using Services;
using System;
using TechTalk.SpecFlow;

namespace BDDTests.StepDefinitions
{
    [Binding]
    public class LoggingInAsClientStepDefinitions
    {
        private ClientOperations _clientOperations;
        private string _registrationLogin, _registrationPassword;
        private string _providedLogin, _providedPassword;
        private string _name, _surname, _address, _postalCode;
        private Table _invalidLoginData;
        private bool _isLogged;

        [Given(@"Client in not logged in")]
        public void GivenClientInNotLoggedIn()
        {
            _clientOperations= new ClientOperations();
        }

        [Given(@"Client has registered before")]
        public void GivenClientHasRegisteredBefore(Table table)
        {
            _name = table.Rows[0]["name"];
            _surname = table.Rows[0]["surname"];
            _address= table.Rows[0]["address"];
            _postalCode = table.Rows[0]["postalCode"];
            _registrationLogin = table.Rows[0]["login"];
            _registrationPassword= table.Rows[0]["password"];

            _clientOperations
                .registerNewClient(_name, _surname, _address, _postalCode, _registrationLogin, _registrationPassword);
        }

        [When(@"Client enters correct login")]
        public void WhenClientEntersCorrectLogin()
        {
            _providedLogin = _registrationLogin;
        }

        [When(@"Client enters correct password")]
        public void WhenClientEntersCorrectPassword()
        {
            _providedPassword = _registrationPassword;
        }

        [Then(@"The clients' login data are correct")]
        public void ThenTheClientsLoginDataAreCorrect()
        {
            _isLogged = _clientOperations.checkClientCredentials(_providedLogin, _providedPassword);

            Assert.IsTrue( _isLogged );
        }

        [When(@"Client enters incorrect login and password")]
        public void WhenClientEntersIncorrectLoginAndPassword(Table table)
        {
            _invalidLoginData = table;
        }

        [Then(@"The client's login data are not correct")]
        public void ThenTheClientsLoginDataAreNotCorrect()
        {
            foreach (var row in _invalidLoginData.Rows)
            {
                _providedLogin = row[0];
                _providedPassword = row[1];
                _isLogged = _clientOperations.checkClientCredentials(_providedLogin, _providedPassword);
                Assert.IsFalse(_isLogged);
            }
        }
    }
}
