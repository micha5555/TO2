using NUnit.Framework;
using Services;
using System;
using TechTalk.SpecFlow;

namespace BDDTests.StepDefinitions
{
    [Binding]
    public class LoggingInAsClientStepDefinitions
    {
        private string _registrationLogin, _registrationPassword;
        private string _providedLogin, _providedPassword;
        private string _name, _surname, _address, _postalCode;
        private bool _isLogged;

        [Given(@"Client is not logged in")]
        public void GivenClientIsNotLoggedIn()
        {
            Helper.BaseServices.ClientOperations = new ClientOperations();
            Helper.BaseServices.GeneralOperations = new GeneralOperations();

            Helper.BaseServices.GeneralOperations.ReadDataOnLaunch();
        }

        [Given(@"Client has registered before")]
        public void GivenClientHasRegisteredBefore(Table table)
        {
            _name = table.Rows[0]["name"];
            _surname = table.Rows[0]["surname"];
            _address = table.Rows[0]["address"];
            _postalCode = table.Rows[0]["postalCode"];
            _registrationLogin = table.Rows[0]["login"];
            _registrationPassword = table.Rows[0]["password"];

            Helper.BaseServices.ClientOperations.registerNewClient(
                _name,
                _surname,
                _address,
                _postalCode,
                _registrationLogin,
                _registrationPassword);
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
            _isLogged = Helper.BaseServices
                .ClientOperations.checkClientCredentials(
                    _providedLogin,
                    _providedPassword);

            Assert.IsTrue(_isLogged);
        }

        [When(@"Client enters incorrect (.*) and (.*)")]
        public void WhenClientEntersIncorrectLoginAndPassword(String invalid_login, String invalid_password)
        {
            _providedLogin = invalid_login;
            _providedPassword = invalid_password;
        }

        [Then(@"The client's login data are not correct")]
        public void ThenTheClientsLoginDataAreNotCorrect()
        {
            Assert.IsFalse(
                Helper
                    .BaseServices
                    .ClientOperations
                    .checkClientCredentials(_providedLogin,_providedPassword));
        }

        
// [Given(@"Client is not logged in")]
// public void GivenClientisnotloggedin()
// {
// 	_scenarioContext.Pending();
// }

// [When(@"Client enters incorrect <invalid_login> and <invalid_password>")]
// public void WhenCliententersincorrectinvalidloginandinvalidpassword()
// {
// 	_scenarioContext.Pending();
// }

// [Then(@"The client's login data are not correct")]
// public void ThenTheclientslogindataarenotcorrect()
// {
// 	_scenarioContext.Pending();
// }

    }
}

//Dobra muszę się na to zapisać
//No 30 sekund
//Dobra to nie
